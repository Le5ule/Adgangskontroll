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
                server = "129.151.221.119",
                port = "5432",
                user_id = "596237",
                password = "Ha1FinDagIDag!",
                database = "596237";
            db = new Database(server, port, user_id, password, database);
        }
        private void Sentral_Load(object sender, EventArgs e)
        {

        }
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
        private void Reset()
        {
            DisableButton();
            lbl_Tittel.Text = "Adgangskontroll";
            currentButton = null;
            BTN_LukkMenyVindu.Visible = false;
        }

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
                    if (dataFraKortleser.Length == 20)
                    {
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
                    else if (dataFraKortleser.Length == 14)
                    {
                        int indeksKort = dataFraKortleser.IndexOf('K');
                        int indeksLeser = dataFraKortleser.IndexOf('L');
                        string kort_ID = dataFraKortleser.Substring(indeksKort + 2, 4);
                        string kortleser_ID = dataFraKortleser.Substring(indeksLeser + 2, 4);

                        db.LeggTilLogg(2, kortleser_ID, kort_ID);
                        dataTilKortleser = "trash";
                    }
                    else if (dataFraKortleser.Length == 17)     // alarm
                    {
                        int indeksKort = dataFraKortleser.IndexOf('K');
                        int indeksLeser = dataFraKortleser.IndexOf('L');
                        int indeksAlarm = dataFraKortleser.IndexOf('A');
                        string kort_ID = dataFraKortleser.Substring(indeksKort + 2, 4);
                        string kortleser_ID = dataFraKortleser.Substring(indeksLeser + 2, 4);
                        int alarm = Convert.ToInt32(dataFraKortleser.Substring(indeksAlarm + 2, 1));

                        db.LeggTilLogg(alarm, kortleser_ID, kort_ID);
                        dataTilKortleser = "trash";

                        MessageBox.Show($"Alarmtype {alarm} utløst!\nDør: {kortleser_ID}, Bruker: {kort_ID}");
                    }
                    else if (dataFraKortleser == "RequestID")
                    {
                        dataTilKortleser = TB_KortleserID.Text;
                    }
                    else dataTilKortleser = "Retur: " + dataFraKortleser;

                    SendData(kommSokkel, dataTilKortleser, out harForbindelse);
                }
            }
            kommSokkel.Close();
        }
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
        private void BTN_LukkMenyVindu_Click(object sender, EventArgs e)
        {
            if (activeForm != null) activeForm.Close();

            Reset();
        }

        private void BTN_KobleTilKortleser_Click(object sender, EventArgs e)
        {
            KobleTilKortleser();
        }

    }
}