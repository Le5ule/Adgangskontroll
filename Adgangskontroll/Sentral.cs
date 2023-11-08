using Npgsql;
using Sentral;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Adgangskontroll_Sentral
{
    public partial class Sentral : Form
    {
        Database db = new Database();

        byte[] data = new byte[1024];       // denne brukes ingen steder...
        static string dataFraKlient;
        static string dataTilKlient;

        // VelgerTCP/IP og adresser + portnummer
        Socket lytteSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Oppgir server sin IP adresse og portnummer
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        bool harforbindelse = true;

        public Sentral()
        {
            InitializeComponent();
            db.Connection();

            lytteSokkel.Bind(serverEP);
            lytteSokkel.Listen(10);

            KobleTilKortleser();
        }
        private void KobleTilKortleser()//object o)
        {
            try
            {
                //// Fra klient-server
                //// Her må vi endre til threadpool eller noe, for vi skal kunne starte flere tråder med flere lesere
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
        private void Sentral_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }
        static void VisKommunikasjonsinfo(IPEndPoint l, IPEndPoint r)
        {
            // Noe som samsvarer med at kommunikasjon eksisterer, slags godkjenning... spørs nødvendig med egen metode...
            // en slags løggføring at sentral er koblet til kortleser
            //Console.WriteLine("Serverinfo; {0}:{1}, Klientinfo: {2}:{3}", l.Address, l.Port, r.Address, r.Port);
        }
        public void Klientkommunikasjon(object o)
        {
            Socket kommSokkel = o as Socket;
            IPEndPoint klientEP = (IPEndPoint)kommSokkel.RemoteEndPoint;

            byte[] data = new byte[1024];
            string dataFraKortleser;
            string dataTilKortleser;

            bool harForbindelse = true;

            //SendData(kommSokkel, "Velkommen til en enkel testserver", out harForbindelse);    // fra server-klient
            // Trenger kanskje ikke slik implementasjon, med mindre KortLeserID skal hentes fra sentral

            while (harForbindelse)
            {
                dataFraKortleser = MottaData(kommSokkel, out harForbindelse);

                if (harForbindelse)
                {

                    MessageBox.Show("Mottatt fra kortleser\n" + dataFraKortleser); //debug

                    dataTilKortleser = "Retur: " + dataFraKortleser;
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
        private void BTN_VisAnsatte_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.VisAnsatt();
        }

        private void BTN_LeggTil_Click(object sender, EventArgs e)
        {
            string id = TB_ID.Text;
            string navn = TB_Navn.Text;
            db.LeggTilNyBruker(id, navn);
            TB_ID.Clear();
            TB_Navn.Clear();
        }
        private void BTN_VisTab_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.VisBrukere();
        }

        //  Eksempel innlogging
        private void BTN_LoggInn_Click(object sender, EventArgs e)
        {
            // dersom feltene er tomme så returneres bare "", altså tom strengverdi, som ikke finnes i databasen, men godtas som input
            string LoggID = TB_LoggID.Text;
            string LoggPin = TB_LoggPin.Text;
            TB_LoggID.Clear();
            TB_LoggPin.Clear();
            TB_suksess.Text = db.Innlogging(LoggID, LoggPin);  //debug, returnerer tekst: "korrekt" / "feil"
        }

        // Paneler og visning av dems menyer
        private void BTN_LesAnsatt_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel4.Hide();
            panel3.Hide();
            panel2.Hide();
            panel1.BringToFront();
        }

        private void BTN_Brukere_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
            panel4.Hide();
            panel2.BringToFront();
        }

        private void BTN_info_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Hide();
            panel2.Hide();
            panel4.Hide();
            panel3.BringToFront();
        }

        private void BTN_Innlogg_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.BringToFront();
        }

    }
}