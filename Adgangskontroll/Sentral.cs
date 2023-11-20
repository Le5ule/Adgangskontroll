using Microsoft.Windows.Themes;
using Npgsql;
using Sentral;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Adgangskontroll_Sentral
{
    public partial class Sentral : Form
    {
        // Oppretter sammenheng mellom sentral og database-klassen
        Database db;

        private Form activeForm;
        private Button currentButton;

        // VelgerTCP/IP og adresser + portnummer
        Socket lytteSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Oppgir server sin IP-adresse og portnummer
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        bool harforbindelse = true;

        public Sentral()
        {
            InitializeComponent();

            lytteSokkel.Bind(serverEP);
            lytteSokkel.Listen(10);

            // Endre disse parameterne for å koble til din/annen database
            string
                server = "",
                port = "",
                user_id = "",
                password = "",
                database = "";
            db = new Database(server, port, user_id, password, database);
        }
        private void Sentral_Load(object sender, EventArgs e)
        {

        }

        // Funkjsoner for å vise og åpne de ulike menyene som er separate forms, underordnet av sentral
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = SystemColors.GradientActiveCaption;
                    BTN_LukkMenyVindu.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in PanelMeny.Controls)
            {
                previousBtn.BackColor = SystemColors.GradientInactiveCaption;
                panelTopp.BackColor = SystemColors.ActiveCaption;
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelForms.Controls.Add(childForm);
            this.PanelForms.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lbl_Tittel.Text = childForm.Text;
        }
        // Returnerer til hjemskjermen
        private void Reset()
        {
            DisableButton();
            lbl_Tittel.Text = "Adgangskontroll";
            currentButton = null;
            BTN_LukkMenyVindu.Visible = false;
        }
        // Slutt på meny-vindu-funksjoner


        // For å opprette tilkobling mellom sentral og kortleser som kjører, starter ny tråd for hver kortleser
        private void KobleTilKortleser()
        {
            try
            {
                Socket kommSokkel = lytteSokkel.Accept(); // blokkerende metode
                IPEndPoint klientEP = (IPEndPoint)kommSokkel.RemoteEndPoint;

                Thread ht = new Thread(Klientkommunikasjon);
                ht.Start(kommSokkel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Oppretter kobling med kortleser ved bruk av IP-addresse
        public void Klientkommunikasjon(object o)
        {
            Socket kommSokkel = o as Socket;
            IPEndPoint klientEP = (IPEndPoint)kommSokkel.RemoteEndPoint;

            byte[] data = new byte[1024];
            string dataFraKortleser;
            string dataTilKortleser;

            bool harForbindelse = true;

            while (harForbindelse)
            {
                dataFraKortleser = MottaData(kommSokkel, out harForbindelse);

                if (harForbindelse)
                {
                    if (dataFraKortleser.Length == 20)  // String med denne lengden vil alltid være kort-ID, pin og kortleser-ID
                    {
                        // Deler opp tekststrengen vi mottar for å hente ut de ulike verdiene

                        int indeksKort = dataFraKortleser.IndexOf('K');
                        int indeksPin = dataFraKortleser.IndexOf('P');
                        int indeksLeser = dataFraKortleser.IndexOf('L');
                        string Kort_ID = dataFraKortleser.Substring(indeksKort + 2, 4);
                        string pin = dataFraKortleser.Substring(indeksPin + 2, 4);
                        string kortleser_id = dataFraKortleser.Substring(indeksLeser + 2, 4);

                        dataTilKortleser = db.Autentisering(Kort_ID, pin, kortleser_id);

                        if (dataTilKortleser == "Godkjent") db.LeggTilLogg(0, kortleser_id, Kort_ID);   //Loggfører godkjent
                        else db.LeggTilLogg(1, kortleser_id, Kort_ID);  //loggfører ikke godkjent
                    }
                    else if (dataFraKortleser.Length == 14)     // String med denne lengden vil alltid være kort-ID og kortleser-ID
                    {
                        // Deler opp tekststrengen vi mottar for å hente ut de ulike verdiene

                        int indeksKort = dataFraKortleser.IndexOf('K');
                        int indeksLeser = dataFraKortleser.IndexOf('L');
                        string kort_ID = dataFraKortleser.Substring(indeksKort + 2, 4);
                        string kortleser_ID = dataFraKortleser.Substring(indeksLeser + 2, 4);

                        db.LeggTilLogg(2, kortleser_ID, kort_ID);   // Loggfører at døren er åpent
                        dataTilKortleser = "trash";                 // Blir ikke brukt til noe, har ikke behov for melding til bake til kortleser
                    }
                    else if (dataFraKortleser.Length == 17)     // alarm
                    {
                        // Deler opp tekststrengen vi mottar for å hente ut de ulike verdiene

                        int indeksKort = dataFraKortleser.IndexOf('K');
                        int indeksLeser = dataFraKortleser.IndexOf('L');
                        int indeksAlarm = dataFraKortleser.IndexOf('A');
                        string kort_ID = dataFraKortleser.Substring(indeksKort + 2, 4);
                        string kortleser_ID = dataFraKortleser.Substring(indeksLeser + 2, 4);
                        int alarm = Convert.ToInt32(dataFraKortleser.Substring(indeksAlarm + 2, 1));

                        db.LeggTilLogg(alarm, kortleser_ID, kort_ID);   // Loggfører alarm utløst
                        dataTilKortleser = "trash";                     // Blir ikke brukt til noe, har ikke behov for melding til bake til kortleser   

                        MessageBox.Show($"Alarmtype {alarm} utløst!\nDør: {kortleser_ID}, Bruker: {kort_ID}");  // Viser melding i sentral om aktiv alarm
                    }
                    else if (dataFraKortleser == "RequestID")
                    {
                        dataTilKortleser = TB_KortleserID.Text;
                    }
                    else dataTilKortleser = "Retur: " + dataFraKortleser;           // Blir ikke brukt til annet enn testing

                    SendData(kommSokkel, dataTilKortleser, out harForbindelse);     // Sender aktuell data som har blitt generert ut ifra hvilken hendelse som har skjedd
                }
            }
            kommSokkel.Close();     // Lukker tilkoblingen når vi stenger en kortleser
        }


        // Metoder for å motta og sende data fra sentral og kortleser
        static string MottaData(Socket s, out bool gjennomført)
        {
            string svar = "";
            try
            {
                byte[] dataSomBytes = new byte[1024];
                int recv = s.Receive(dataSomBytes);
                if (recv > 0)
                {
                    svar = Encoding.ASCII.GetString(dataSomBytes, 0, recv);
                    gjennomført = true;
                }
                else
                    gjennomført = false;
            }
            catch (Exception)
            {
                throw;
            }
            return svar;
        }
        static void SendData(Socket s, string data, out bool gjennomført)
        {
            try
            {
                byte[] dataSomBytes = Encoding.ASCII.GetBytes(data);
                s.Send(dataSomBytes, dataSomBytes.Length, SocketFlags.None);
                gjennomført = true;
            }
            catch (Exception)
            {
                gjennomført = false;
            }
        }


        // Knapper for å åpne de ulike menyene
        private void iBTN_Brukere_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MenyBrukere(), sender);
        }
        private void iBTN_Kortlesere_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MenyKortlesere(), sender);
        }
        private void iBTN_Logg_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MenyLogg(), sender);
        }
        private void iBTN_Innstillinger_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MenyInnstillinger(), sender);
        }
        // Knapp for å lukke åpnet meny "X"
        private void BTN_LukkMenyVindu_Click(object sender, EventArgs e)
        {
            if (activeForm != null) activeForm.Close();

            Reset();
        }

        // For å etablere tilkobling mellom sentral og kortleser.
        // En kortleser må kjøre før man kan trykke på knappen
        private void BTN_KobleTilKortleser_Click(object sender, EventArgs e)
        {
            KobleTilKortleser();
        }

    }
}