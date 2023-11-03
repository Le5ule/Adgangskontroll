using Npgsql;
using Adgangskontroll_Bibliotek;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Adgangskontroll_Sentral
{
    public partial class Sentral : Form
    {
        Data terminal = new Data();

        byte[] data = new byte[1024];       //eehhhhh
        static string dataFraKlient;               // trenger dette endring?
        static string dataTilKlient;               // trenger dette endring?

        string vstrConnection = "server=129.151.221.119 ; port=5432 ; user id=596237 ; password=Ha1FinDagIDag! ; database=596237 ;";
        NpgsqlConnection vCon;
        NpgsqlCommand vCmd;

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

                    MessageBox.Show(dataFraKortleser);

                    dataTilKortleser = "mottatt fra sentral";
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
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtgetData = new DataTable();
            dtgetData = getData("select * from ansatt0;");

            dataGridView1.DataSource = dtgetData;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TB_Kombo.Text = terminal.Kombo();
            //TB_Kombo.Text = MottaData(lytteSokkel, out harforbindelse);

        }
    }
}