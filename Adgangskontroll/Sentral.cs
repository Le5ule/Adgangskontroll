using Npgsql;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Adgangskontroll_Sentral
{
    public partial class Sentral : Form
    {
        //List<Panel> panels = new List<Panel>();
        //int index;
        DataTable dtgetData = new DataTable();

        byte[] data = new byte[1024];       //eehhhhh
        static string dataFraKlient;
        static string dataTilKlient;

        string vstrConnection = "server=129.151.221.119 ; port=5432 ; user id=596237 ; password=Ha1FinDagIDag! ; database=596237 ;";
        NpgsqlConnection vCon = new NpgsqlConnection();
        NpgsqlCommand vCmd = new NpgsqlCommand();

        // VelgerTCP/IP og adresser + portnummer
        Socket lytteSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Oppgir server sin IP adresse og portnummer
        IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        bool harforbindelse = true;

        public Sentral()
        {
            InitializeComponent();
            connection();
            lytteSokkel.Bind(serverEP);
            lytteSokkel.Listen(10);

            //while (false)
            //{
            //Console.WriteLine("Venter på en klient ...");
            Socket kommSokkel = lytteSokkel.Accept(); // blokkerende metode

            //VisKommunikasjonsinfo(kommSokkel.LocalEndPoint as IPEndPoint, kommSokkel.RemoteEndPoint as IPEndPoint);
            IPEndPoint klientEP = (IPEndPoint)kommSokkel.RemoteEndPoint;

            Thread ht = new Thread(Klientkommunikasjon);
            ht.Start(kommSokkel);

            //}
            //lytteSokkel.Close();
        }
        private void connection()
        {
            vCon = new NpgsqlConnection();
            vCon.ConnectionString = vstrConnection;

            if (vCon.State == ConnectionState.Closed)
            {
                vCon.Open();
            }
        }
        private void Sentral_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();

            // frem og tilbake-opplegg
            //panels.Add(panel1);
            //panels.Add(panel2);
            //panels.Add(panel3);
            //panels[index].BringToFront();
        }
        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            vCmd = new NpgsqlCommand();
            vCmd.Connection = vCon;
            vCmd.CommandText = sql;

            NpgsqlDataReader dr = vCmd.ExecuteReader();
            dt.Load(dr);

            return dt;
        }
        static void VisKommunikasjonsinfo(IPEndPoint l, IPEndPoint r)
        {
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

            //SendData(kommSokkel, "Velkommen til en enkel testserver", out harForbindelse);

            while (harForbindelse)
            {
                dataFraKortleser = MottaData(kommSokkel, out harForbindelse);

                if (harForbindelse)
                {

                    MessageBox.Show("Sentral:" + dataFraKortleser);

                    dataTilKortleser = dataFraKortleser;
                    SendData(kommSokkel, dataTilKortleser, out harForbindelse);
                }
            }
            //IPEndPoint r = kommSokkel.RemoteEndPoint as IPEndPoint;
            //Console.WriteLine("Forbindelsen med {0}:{1} er brutt", r.Address, r.Port);
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
                throw;      // Trenger noe bedre enn dette
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
        private void button1_Click(object sender, EventArgs e)
        {
            dtgetData = getData("select * from ansatt0;");
            dataGridView1.DataSource = dtgetData;
        }

        private void BTN_LeggTil_Click(object sender, EventArgs e)
        {
            string id = TB_ID.Text;
            string navn = TB_Navn.Text;
            string identitet = $"INSERT INTO Brukere values({id}, '{navn}')";
            dtgetData = getData(identitet);

            TB_ID.Clear();
            TB_Navn.Clear();
        }
        private void BTN_VisTab_Click(object sender, EventArgs e)
        {
            dtgetData = getData("select * from Brukere_test;");
            dataGridView2.DataSource = dtgetData;

        }

        // Paneler og dems menyer
        private void BTN_LesAnsatt_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel4.Hide();
            panel3.Hide();
            panel2.Hide();
            panel1.BringToFront();

            // tror panel2 og 3 ligger inni panel1???

            //if (index < panels.Count-1)
            //{
            //    panels[++index].BringToFront();
            //}
        }

        private void BTN_Brukere_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
            panel4.Hide();
            panel2.BringToFront();

            //if (index > 0)
            //{
            //    panels[-- index].BringToFront();
            //}
        }

        private void BTN_info_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Hide();
            panel2.Hide();
            panel4.Hide();
            panel3.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.BringToFront();
        }
        
        //  Eksempel innlogging
        private void BTN_LoggInn_Click(object sender, EventArgs e)
        {
            string LoggID = TB_LoggID.Text;
            string LoggNavn = TB_LoggNavn.Text;

            string query = ($"select * from Brukere_test where bruker_id='{LoggID}' and navn = '{LoggNavn}';"); //endre
            NpgsqlCommand vCmd = new NpgsqlCommand(query, vCon);

            using NpgsqlDataReader reader = vCmd.ExecuteReader();
            if (reader.Read())
            {
                TB_suksess.Text = "korrekt";
            }
            else
            {
                TB_suksess.Text = "feil";
            }
        }
    }
}