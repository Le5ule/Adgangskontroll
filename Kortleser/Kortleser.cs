using System.Diagnostics;
using System.Net;
using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using System.IO.Ports;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic;

namespace Adgangskontroll_Kortleser
{
    public partial class Kortleser : Form
    {
        // Brukes for sikkerhetsmekanisme fir lukking av kortleser
        static bool Avbryt = false;

        // Brukes for å opprettholde forbindelsen med sentral
        static bool kommunikasjonMedSentral = false;

        // Datatypene for kortleser
        static string dataTilSentral;
        static string dataFraSentral;
        static string pin;
        static string kortID = "NaN_";  //Dersom vi ikke har oppgitt noen ID fra sentral, brukes når alarm utløses, hvis ikke krasjer sentral
        static string kortleserID;

        // Variabler for SimSim
        static string data = "";
        static string COMPort = "";
        static int råDørÅpen = 0;
        static int råDørLåst = 0;
        static int potensiometer = 0;
        static int sekDørÅpen = 0;
        static int alarm = 0;
        static int dørLåstOpp = 0;

        // Liste for å lagre koden som tastes inn
        List<int> kodeinput = new List<int>();

        // Etablerer bruk av seriellport
        SerialPort sp;

        // Etablerer IP-kommunikasjon
        Socket klientSokkel;

        public Kortleser()
        {
            InitializeComponent();
        }


        private void Kortleser_Load(object sender, EventArgs e)
        {
            // Oppretter tilkobling mot sentral ved bruk av TCP/IP

            klientSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            BTN_LesKort.Select();

            // Når kortleser startes skal døren være dynlig lukket og låst
            iPB_Unlock.Hide();
            iPB_DoorOpen.Hide();

            // prøver å "få tak i" tilkoblingen fra sentral
            try
            {
                klientSokkel.Connect(serverEP);
                kommunikasjonMedSentral = true;
                try
                {
                    // Kortleser vil spørre etter sin ID fra sentralen
                    dataTilSentral = "RequestID";
                    BW_SendKvittering.RunWorkerAsync();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            catch (SocketException)
            {
                MessageBox.Show("Fikk ikke kontakt med sentral!");
                kommunikasjonMedSentral = false;
            }

            //Kobling til SimSim
            COMPort = "COM" + Interaction.InputBox("Skriv inn COMportnummer for kortleser: ", "COM Port");
            sp = new SerialPort(COMPort, 9600);

            try
            {
                // Prøver å få kontakt med åpen seriellport
                sp.Open();
            }
            catch (Exception u)
            {
                MessageBox.Show("Feil: " + u.Message);
            }

            if (sp.IsOpen)
            {
                // Skal skrive til SimSim at døren skal være låst og lukket, samt ingen alarm
                sp.Write("$O50");
                sp.Write("$O60");
                sp.Write("$O70");

                // SimSim skal sende meldinger hvert sekund
                SendEnMelding("$S001", sp);
                bwSjekkForData.RunWorkerAsync();
            }
        }


        // Metode for å lese inn kode
        public void Kode(int inn)
        {
            kodeinput.Add(inn);
            try
            {
                if (kodeinput.Count == 4 && kommunikasjonMedSentral == true)
                {
                    kortID = TB_KortInput.Text;
                    TB_KortInput.Clear();
                    TB_KortInput.Visible = false;
                    pin = kodeinput[0].ToString() + kodeinput[1].ToString() + kodeinput[2].ToString() + kodeinput[3].ToString();
                    kodeinput.Clear();

                    // Sender informasjon til sentral for å autentisere brukeren
                    dataTilSentral = $"K:{kortID} P:{pin} L:{kortleserID}";

                    if (kommunikasjonMedSentral == true)
                    {
                        if (!BW_SendKvittering.IsBusy)     // BackgroundWorker skal i prinsipp aldri være opptatt, men den kan, derfor må vi sjekke for dette
                        {
                            BW_SendKvittering.RunWorkerAsync();
                        }
                        else
                        {
                            MessageBox.Show("feil");
                        }
                        /*MessageBox.Show("Lokal info i kortleser:\n" + dataTilSentral);*/     //debug: sjekker at informasjon lagres korrekt
                    }

                    pin = "";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Knapper for å åpne og lukke døren
        private void BTN_Åpne_Click(object sender, EventArgs e)
        {

            dataTilSentral = $"K:{kortID} L:{kortleserID}S";

            if (råDørÅpen == 0 && råDørLåst == 1)
            {
                SendEnMelding("$O61", sp);
                if (kommunikasjonMedSentral == true)
                {
                    BW_SendKvittering.RunWorkerAsync();
                }
            }

        }
        private void BTN_Lukk_Click(object sender, EventArgs e)
        {
            if (råDørÅpen == 1)
            {
                sekDørÅpen = 0;
                SendEnMelding("$O60", sp);
                SendEnMelding("$O50", sp);
                SendEnMelding("$O70", sp);
            }
        }



        //SimSim-funksjoner
        void SendEnMelding(string enMelding, SerialPort sp)     // Sender statusmelding til SimSIm
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
        // Mottar meldinger fra SimSim som senere skal evalueres
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
        //Slutt på SimSim-funksjoner


        //Funksjon for å konvertere rådata fra simsim til dør-status
        void VisDør(string enMelding)
        {
            int indeksStart = enMelding.IndexOf('E');
            råDørLåst = Convert.ToInt32(enMelding.Substring(indeksStart + 6, 1));
            råDørÅpen = Convert.ToInt32(enMelding.Substring(indeksStart + 7, 1));
            if (råDørLåst == 1)
            {
                iPB_Unlock.Show();              // Døren er nå ulåst
                iPB_Unlock.BringToFront();
                iPB_Lock.Hide();
                dørLåstOpp++;                   // teller antall "sekund" døren er låst opp

                if (dørLåstOpp == 15)
                {
                    sp.Write("$O50");   // SimSim låser døren etter 15 sekund
                    dørLåstOpp = 0;
                }
            }
            else
            {
                iPB_Lock.Show();            // Døren forblir låst (grafisk)
                iPB_Lock.BringToFront();
                iPB_Unlock.Hide();
            }
            if (råDørÅpen == 1)
            {
                iPB_DoorOpen.Show();        // Døren åpnes (grafisk)
                iPB_DoorOpen.BringToFront();
                iPB_DoorLocked.Hide();
            }
            else
            {
                iPB_DoorLocked.Show();      // Døren lukkes (grafisk)
                iPB_DoorLocked.BringToFront();
                iPB_DoorOpen.Hide();
            }
        }


        //alarmfunksjon
        void Alarm(string enMelding)
        {
            if (sekDørÅpen > 5 && alarm != 3 && alarm != 4)
            {
                SendEnMelding("$O71", sp);
                alarm = 3;

                dataTilSentral = $"K:{kortID} L:{kortleserID} A:{alarm}";   // Sender informasjon om bruker, kortleser og type alarm til sentral

                if (kommunikasjonMedSentral == true)
                {
                    BW_SendKvittering.RunWorkerAsync();
                }

            }
            int indeksStart = enMelding.IndexOf('G');
            potensiometer = Convert.ToInt32(enMelding.Substring(indeksStart + 1, 4));

            // "bryter opp døren"
            if (potensiometer > 500 && alarm != 4)
            {
                SendEnMelding("$O61", sp);
                SendEnMelding("$O71", sp);
                alarm = 4;

                dataTilSentral = $"K:{kortID} L:{kortleserID} A:{alarm}";

                if (kommunikasjonMedSentral == true)
                {
                    BW_SendKvittering.RunWorkerAsync();
                }
            }
            // Døren er ikke "brutt opp"
            if (potensiometer < 500 && sekDørÅpen < 5)
            {
                SendEnMelding("$O70", sp);
                alarm = 0;
            }
        }


        // Generelle funksjoner for å motta og sende data til sentral
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


        //Backgroundworker for å sende og motta data til og fra sentral
        private void BW_SendKvittering_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SendData(klientSokkel, dataTilSentral, out kommunikasjonMedSentral);
            if (kommunikasjonMedSentral)
            {
                dataFraSentral = MottaData(klientSokkel, out kommunikasjonMedSentral);
            }
        }
        private void BW_SendKvittering_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (kommunikasjonMedSentral)
            {
                if (dataFraSentral.Length == 4) //Dette vil alltid være kortleser sin ID
                {
                    Label_ID.Text = "Dør: " + dataFraSentral;
                    kortleserID = dataFraSentral;
                }
                else if (dataFraSentral == "Godkjent")
                {
                    SendEnMelding("$O51", sp);

                }
                else if (dataFraSentral == "Ikke godkjent")
                {
                    SendEnMelding("$O50", sp);
                }
                else
                {
                    // Tidligere brukt til debug
                }
            }
            //else //Application.Exit();
        }

        // BackgroundWorker for SimSim
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
                VisDør(enMelding);
                Alarm(enMelding);
                if (råDørÅpen == 1)
                {
                    sekDørÅpen++;
                }
                else
                {
                    sekDørÅpen = 0;
                }
            }
            bwSjekkForData.RunWorkerAsync();
        }


        // Knapper for å lese kort-ID og kode
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




        // Sikkerhetsmekanisme for å lukke kortleser
        private void Kortleser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Avbryt)
            {
                var result = MessageBox.Show("Er du sikker på at du vil fjerne denne kortleseren?", "Fjerne kortleser " + kortleserID, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Hvis man trykket "nei"
                if (result == DialogResult.No)
                {
                    // avbryter lukking og frakobling
                    e.Cancel = true;
                }
                else if (kommunikasjonMedSentral)
                {
                    klientSokkel.Shutdown(SocketShutdown.Both);
                    klientSokkel.Close();
                }
            }
        }
    }
}