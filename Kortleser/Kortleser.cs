using System.Net;
using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using System.IO.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        string data = "";
        List<int> kodeinput = new List<int>();
        SerialPort sp;

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

            //Kobling til Simsim
            sp = new SerialPort("COM6", 9600);

            try
            {
                sp.Open();
            }
            catch (Exception u)
            {
                MessageBox.Show("Feil: " + u.Message);
            }

            if (sp.IsOpen)
            {
                bwSjekkForData.RunWorkerAsync();
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
                // her kan vi ogs� ta � laste inn kortID uten � m�tte trykke p� enter-tasten, kanskje mer brukervennlig, slipper � forklare "trykk enter";
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

        //SimSim funksjoner
        void SendEnMelding(string enMelding, SerialPort sp)
        {
            try
            {
                sp.Write(enMelding);
            }
            catch (Exception u)
            {
                MessageBox.Show("Feil: " + u.Message);
            }
        }
        string HentUtEnMelding(ref string data)
        {
            string svar = "";

            int indeksStart = data.IndexOf('$');
            int indeksSlutt = data.IndexOf('#');

            if (indeksStart > 0) data = data.Substring(indeksStart);

            svar = data.Substring(0, (indeksSlutt - indeksStart) + 1);

            data = data.Substring((indeksSlutt - indeksStart) + 1);

            return svar;
        }
        string MottaDataSim(SerialPort sp)
        {
            string svar = "";
            try
            {
                svar = sp.ReadExisting();
            }
            catch (Exception u)
            {
                MessageBox.Show("Feil: " + u.Message);
            }
            return svar;
        }
        bool EnHelMeldingMotatt(string data)
        {
            bool svar = false;

            int indeksStart = data.IndexOf('$');
            int indeksSlutt = data.IndexOf('#');

            if (indeksStart != -1 && indeksSlutt != -1)
            {
                if (indeksStart < indeksSlutt) svar = true;
            }

            return svar;
        }
        //Slutt p� SimSim funksjoner

        //Funksjon for � konvertere r� data fra simsim til d�r status
        void VisD�r(string enMelding)
        {
            int indeksStart = enMelding.IndexOf('E');  
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
        // Denne funker, men bool gjennomfj�rt endres ikke slik som den bler brukt i server-klient i kommentert felt under
        static string MottaData(Socket s, out bool gjennomf�rt)
        {
            string svar = "";
            try
            {
                byte[] dataSomBytes = new byte[1024];
                int recv = s.Receive(dataSomBytes);
                if (recv > 0)
                {
                    svar = Encoding.ASCII.GetString(dataSomBytes, 0, recv);
                    gjennomf�rt = true;
                }
                else
                    gjennomf�rt = false;
            }
            catch (Exception)
            {
                throw;
            }
            return svar;
        }
        static void SendData(Socket s, string data, out bool gjennomf�rt)
        {
            try
            {
                byte[] dataSomBytes = Encoding.ASCII.GetBytes(data);
                s.Send(dataSomBytes, dataSomBytes.Length, SocketFlags.None);
                gjennomf�rt = true;
            }
            catch (Exception)
            {
                gjennomf�rt = false;
            }
        }
        private void TB_KortInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // samme som enter
            {
                // Trenger bare � h�ndtere lengden. Hvis ID oppgis f.eks: "abcd" s� er dette "feil" id, men godkjent input i databasen
                // Siden Kode() n� leser av TB_KortInput uten enter, s� vil ikke dette leses ved � trykke enter.
                // Detaljene om implementasjonen kan diskuteres senere n�r design er mer kritisk.
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

        //�pne og lukke d�r
        private void button1_Click(object sender, EventArgs e)
        {
            SendEnMelding("$O61", sp);
            label1.Text = data;
        }

        private void bwSjekkForData_DoWork_1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Thread.Sleep(500);

            data = data + MottaDataSim(sp);
        }

        private void bwSjekkForData_RunWorkerCompleted_1(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (EnHelMeldingMotatt(data))
            {
                string enMelding = HentUtEnMelding(ref data);

                label1.Text = enMelding;

            }
            bwSjekkForData.RunWorkerAsync();
        }
    }
}