using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Adgangskontroll_Kortleser
{
    public partial class Kortleser : Form
    {
        //byte[] data = new byte[1024];     // Denne blir ikke brukt noen steder...
        bool comMedSentral = false;
        static string dataTilSentral;
        static string dataFraSentral;
        static string pin;
        static string kortID;
        static string kortleserID = "0";
        List<int> kodeinput = new List<int>();

        Socket klientSokkel;

        public Kortleser()
        {
            InitializeComponent();
        }
        private void Kortleser_Load(object sender, EventArgs e)
        {
            klientSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            BTN_LesKort.Select();

            try
            {
                klientSokkel.Connect(serverEP); // blokkerende metode
                comMedSentral = true;
            }
            catch (SocketException)
            {
                MessageBox.Show("Fikk ikke kontakt med sentral!");
                comMedSentral = false;
            }

            //if (comMedSentral)//==true)
            //{
            //    dataFraSentral = MottaData(klientSokkel, out comMedSentral);
            //    //MessageBox.Show(dataFraSentral);
            //    //TB_Mottak.Text = dataFraSentral;
            //}
            //noe som gir false                         eller??? idk hva dette engang var
        }
        public void Kode(int inn)
        {
            kodeinput.Add(inn);

            if (kodeinput.Count == 4 && comMedSentral == true)
            {
                // her kan vi også ta å laste inn kortID uten å måtte trykke på enter-tasten, kanskje mer brukervennlig, slipper å forklare "trykk enter";
                kortID = TB_KortInput.Text;
                TB_KortInput.Clear();
                TB_KortInput.Visible = false;
                //
                //comMedSentral = true;
                pin = kodeinput[0].ToString() + kodeinput[1].ToString() + kodeinput[2].ToString() + kodeinput[3].ToString();
                kodeinput.Clear();
                dataTilSentral = $" K:{kortID} P:{pin} L:{kortleserID}";
                if (comMedSentral == true)
                {
                    BW_SendKvittering.RunWorkerAsync();
                    MessageBox.Show("Lokal info i kortleser:\n" + dataTilSentral);     //debug
                }
                BTN_LesKort.Select();
                kortID = "";
                pin = "";
            }
        }
        public bool godkjenning(int BrukerPin)
        {
            bool svar = false;
            if (svar == false)
            {
                pin = kodeinput[0].ToString() + kodeinput[1].ToString() + kodeinput[2].ToString() + kodeinput[3].ToString();
                //pin = int.Parse(pinString);
                svar = true;
            }
            else
            {
                kodeinput.Clear();
            }
            return svar;
        }
        // Denne funker, men bool gjennomfjørt endres ikke slik som den bler brukt i server-klient i kommentert felt under
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
        private void TB_KortInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // samme som enter
            {
                // Trenger bare å håndtere lengden. Hvis ID oppgis f.eks: "abcd" så er dette "feil" id, men godkjent input i databasen
                // Siden Kode() nå leser av TB_KortInput uten enter, så vil ikke dette leses ved å trykke enter.
                // Detaljene om implementasjonen kan diskuteres senere når design er mer kritisk.
                if (TB_KortInput.Text.Length == 4)
                {
                    kortID = TB_KortInput.Text;
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
        private void BW_SendKvittering_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SendData(klientSokkel, dataTilSentral, out comMedSentral);
            if (comMedSentral)
            {
                dataFraSentral = MottaData(klientSokkel, out comMedSentral);
            }
        }
        private void BW_SendKvittering_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (comMedSentral)
            {
                TB_MottakFraSentral.Text = dataFraSentral;
            }
            //else //Application.Exit();
        }
        private void BTN_LesKort_Click(object sender, EventArgs e)
        {
            TB_KortInput.Visible = true;
            TB_KortInput.Select();
        }
        private void BTN1_Click(object sender, EventArgs e)
        {
            Kode(1);
        }
        private void BTN2_Click(object sender, EventArgs e)
        {
            Kode(2);
        }
        private void BTN3_Click(object sender, EventArgs e)
        {
            Kode(3);
        }
        private void BTN4_Click(object sender, EventArgs e)
        {
            Kode(4);
        }
        private void BTN5_Click(object sender, EventArgs e)
        {
            Kode(5);
        }
        private void BTN6_Click(object sender, EventArgs e)
        {
            Kode(6);
        }
        private void BTN7_Click(object sender, EventArgs e)
        {
            Kode(7);
        }
        private void BTN8_Click(object sender, EventArgs e)
        {
            Kode(8);
        }
        private void BTN9_Click(object sender, EventArgs e)
        {
            Kode(9);
        }
        private void BTN0_Click(object sender, EventArgs e)
        {
            Kode(0);
        }
    }
}