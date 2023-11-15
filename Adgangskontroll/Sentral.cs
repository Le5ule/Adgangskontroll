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
        Database db = new Database();

        static string kobling;      // var ment til å bestå av en stren variabler som ikke er deklarert,
                                    // for å enkelt endre kobling til database

        static List<string> Kortleser_ID = new List<string>() { "A323" }; //Oppdater denne listen med så mange kortleser-IDer vi trenger
        static int index = 0;

        private Form activeForm;
        private Button currentButton;

        // VelgerTCP/IP og adresser + portnummer
        Socket lytteSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Oppgir server sin IP adresse og portnummer
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        bool harforbindelse = true;

        public Sentral()
        {
            InitializeComponent();
            db.Connection();    //skal endre dette til enten her eller i Database.cs at man setter inn egendefinerte parametre for tilkobling

            lytteSokkel.Bind(serverEP);
            lytteSokkel.Listen(10);

            KobleTilKortleser();
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
                //// Fra klient-server
                //// Her må vi endre til threadpool eller noe, for vi skal kunne starte flere tråder med flere lesere...
                //while (harforbindelse)    //slik løkke fungerer ikke her, uansett true eller false...
                //{
                //Console.WriteLine("Venter på en klient ...");
                Socket kommSokkel = lytteSokkel.Accept(); // blokkerende metode

                //VisKommunikasjonsinfo(kommSokkel.LocalEndPoint as IPEndPoint, kommSokkel.RemoteEndPoint as IPEndPoint);
                IPEndPoint klientEP = (IPEndPoint)kommSokkel.RemoteEndPoint;

                Thread ht = new Thread(Klientkommunikasjon);        //må starte mer enn én tråd, implementer ThreadPool i Public Senral() osv.
                ht.Start(kommSokkel);
                //}
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
                    //MessageBox.Show("Mottatt fra kortleser\n" + dataFraKortleser); //debug

                    //rotete kode her, men det funker foreløpig  
                    //legg også inn egen if-setning for COM-port
                    //legg også inn en der dataFraKortleser == "alarm" -> MessageBox.Show("Alarm aktivert"); eller noe sånt
                    if (dataFraKortleser == "RequestID")
                    {
                        if (Kortleser_ID.Count != index)
                        {
                            dataTilKortleser = Kortleser_ID[index];
                            index++;
                        }
                        else
                        {
                            index = 0;
                            dataTilKortleser = Kortleser_ID[index];
                            index++;
                        }
                    }
                    else dataTilKortleser = "Retur: " + dataFraKortleser;

                    SendData(kommSokkel, dataTilKortleser, out harForbindelse);
                }
            }
            //IPEndPoint r = kommSokkel.RemoteEndPoint as IPEndPoint;
            //Console.WriteLine("Forbindelsen med {0}:{1} er brutt", r.Address, r.Port);    // endre til noe mer passende
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
            //currentButton.BackColor = SystemColors.GradientActiveCaption;
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

        // Kopier noe herfra og gjenbruk til å koble til ny leser

        //private void Start_Click(object sender, EventArgs e)
        //{
              //***
        //    //endre til at vi åpner ny kortleser i debug, og dermed ikke foreach, men ID sendes med listen
        //    //der index vil øke for hver gang
              //***

        //    foreach (string kortleser in Kortleser_ID)
        //    {
        //        //Må endre til bane for Kortleser.exe
        //        Process.Start("C:\\Users\\leand\\OneDrive - Høgskulen på Vestlandet\\ELE 301\\Prosjektoppgave\\Adgangskontroll\\Kortleser\\bin\\Debug\\net7.0-windows\\Kortleser.exe");
        //        KobleTilKortleser();
        //    }
        //    BTN_Start.Enabled = false;
        //}
    }
}