using Adgangskontroll_Bibliotek;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Adgangskontroll_Kortleser
{
    public partial class Kortleser : Form
    {
        byte[] data = new byte[1024];
        bool comMedSentral = false;
        string dataTilSentral;
        string dataFraSentral;
        static int kortID;
        string pin = "1";
        static int kortleserID = 0;

        Socket klientSokkel;
        Data autentisering = new Data();

        public Kortleser()
        {
            InitializeComponent();
        }

        public void access(int inn)
        {
            autentisering.Kodeinput().Add(inn);
            //TB_Kode.Text = "4";
            //MessageBox.Show("hmm");

            if (autentisering.Kodeinput().Count == 4)
            {
                autentisering.godkjenning(autentisering.Pin());
                pin = Data.pin;
                Data.pin = pin;
                autentisering.Kodeinput().Clear();
                kortID = Data.kortID;                  // dersom kortID ikke er oppgitt før kode, sendes ID som "0000", dermed nektet adgang.
                //pin = Data.pin;
                dataTilSentral = $"k_{kortID}_p_{pin}_l_{kortleserID}x";
                //TB_Mottak.Text = Data.pin;
                //SendData(klientSokkel, dataTilSentral, out comMedSentral);
                if (comMedSentral)
                {
                    //dataFraSentral = MottaData(klientSokkel, out comMedSentral);
                }
                if (dataTilSentral.Length > 0)
                {
                    //BTN_sendData.Enabled = false;
                    //TB_dataTilServer.Select();
                    BW_SendKvittering.RunWorkerAsync();
                    MessageBox.Show("terminal" + dataTilSentral);
                }
            }
        }
        static string MottaData(Socket s, out bool gjennomført)
        {
            byte[] data = new byte[1024];
            string svar = " ";
            gjennomført = false;
            try
            {
                int antallMottatt = s.Receive(data);
                svar = Encoding.ASCII.GetString(data, 0, antallMottatt);

            }
            catch (Exception e)
            {
                MessageBox.Show("Feil" + e.Message);
            }
            return svar;
            //string svar = "";
            //try
            //{
            //    byte[] dataSomBytes = new byte[1024];
            //    int recv = s.Receive(dataSomBytes);
            //    if (recv >= 0)
            //    {
            //        svar = Encoding.ASCII.GetString(dataSomBytes, 0, recv);
            //        gjennomført = true;
            //    }
            //    else
            //        gjennomført = false;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //return svar;
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
        private void Kortleser_Load(object sender, EventArgs e)
        {
            klientSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            // les ipadresse og port fra fil(config) kanskje??????
            try
            {
                klientSokkel.Connect(serverEP); // blokkerende metode
                comMedSentral = true;
            }
            catch (SocketException)
            {
                MessageBox.Show("Fikk ikke kontakt med serveren!");
                comMedSentral = false;
            }

            //if (comMedSentral)//==true)
            //{
            //    dataFraSentral = MottaData(klientSokkel, out comMedSentral);
            //    //MessageBox.Show(dataFraSentral);
            //    //TB_Mottak.Text = dataFraSentral;
            //}
            //noe som gir false
        }
        private void TB_KortInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (TB_KortInput.Text.Length == 4 && Int32.TryParse(TB_KortInput.Text, out Data.kortID))
                {
                    Data.kortID = Convert.ToInt32(TB_KortInput.Text);
                    TB_KortInput.Visible = false;
                    UgyldigLabel.Visible = false;
                    TB_KortInput.Clear();
                }
                else
                {
                    UgyldigLabel.Visible = true;
                    TB_KortInput.Clear();
                }
            }
        }
        private void BTN_LesKort_Click(object sender, EventArgs e)
        {
            TB_KortInput.Visible = true;
            TB_KortInput.Select();
        }
        private void BTN1_Click(object sender, EventArgs e)
        {
            access(1);
        }
        private void BTN2_Click(object sender, EventArgs e)
        {
            access(2);
        }
        private void BTN3_Click(object sender, EventArgs e)
        {
            access(3);
        }
        private void BTN4_Click(object sender, EventArgs e)
        {
            access(4);
        }
        private void BTN5_Click(object sender, EventArgs e)
        {
            access(5);
        }
        private void BTN6_Click(object sender, EventArgs e)
        {
            access(6);
        }
        private void BTN7_Click(object sender, EventArgs e)
        {
            access(7);
        }
        private void BTN8_Click(object sender, EventArgs e)
        {
            access(8);
        }
        private void BTN9_Click(object sender, EventArgs e)
        {
            access(9);
        }
        private void BTN0_Click(object sender, EventArgs e)
        {
            access(0);
        }

        private void BW_SendKvittering_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SendData(klientSokkel, dataTilSentral, out comMedSentral);
            if (comMedSentral) //her er den true
            {
                dataFraSentral = MottaData(klientSokkel, out comMedSentral);
            }
        }

        private void BW_SendKvittering_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (true)//comMedSentral)       // denne har blitt endret til false et sted, tydeligvis, for dette funker 
            {
                TB_Mottak.Text = dataFraSentral;
            }
            //else //Application.Exit();
        }
    }
}