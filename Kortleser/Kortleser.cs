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
        static bool Avbryt = false;
        static bool kommunikasjonMedSentral = false;
        static string dataTilSentral;
        static string dataFraSentral;
        static string pin;
        static string kortID;
        static string kortleserID;
        string data = "";
        string COMPort = "";
        int råDørÅpen = 0;
        int råDørLåst = 0;
        int potensiometer = 0;
        int sekDørÅpen = 0;
        int alarm = 0;
        int dørLåstOpp = 0;

        List<int> kodeinput = new List<int>();
        SerialPort sp;

        Socket klientSokkel;

        public Kortleser()
        {
            InitializeComponent();
        }


        private void Kortleser_Load(object sender, EventArgs e)
        {
            // Kortleser åpnes selv om det ikke er kommunikasjon med sentral eller SimSim, litt rart...

            klientSokkel = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            BTN_LesKort.Select();

            iPB_Unlock.Hide();
            iPB_DoorOpen.Hide();

            try
            {
                klientSokkel.Connect(serverEP); // blokkerende metode
                kommunikasjonMedSentral = true;
                try
                {
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

            //Kobling til Simsim
            COMPort = Interaction.InputBox("Skriv in COM Port nr", "COM Port");
            sp = new SerialPort(COMPort, 9600);

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
                sp.Write("$O50");
                sp.Write("$O60");
                sp.Write("$O70");

                SendEnMelding("$S001", sp);
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
            try
            {
                if (kodeinput.Count == 4 && kommunikasjonMedSentral == true)
                {
                    kortID = TB_KortInput.Text;
                    TB_KortInput.Clear();
                    TB_KortInput.Visible = false;
                    //comMedSentral = true;         // usikker på hvorfor denne er kommentert vekk her...
                    pin = kodeinput[0].ToString() + kodeinput[1].ToString() + kodeinput[2].ToString() + kodeinput[3].ToString();
                    kodeinput.Clear();


                    //dette må omformateres slik at det stemmer med query til db.
                    //lagre dette som string, inn i sentral,
                    //variabel i query inni sentral. Makes sense?
                    dataTilSentral = $"K:{kortID} P:{pin} L:{kortleserID}";

                    //"K:0000 P:0000 L:0000";


                    if (kommunikasjonMedSentral == true)
                    {
                        BW_SendKvittering.RunWorkerAsync();
                        MessageBox.Show("Lokal info i kortleser:\n" + dataTilSentral);     //debug
                    }

                    //if-setning som venter på å åpne dør, "blokkerende metode"


                    //BTN_LesKort.Select();
                    //kortID = "";
                    pin = "";

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        //SimSim-funksjoner
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
        //Slutt på SimSim-funksjoner

        //Funksjon for å konvertere rådata fra simsim til dør-status
        void VisDør(string enMelding)
        {
            int indeksStart = enMelding.IndexOf('E');
            råDørLåst = Convert.ToInt32(enMelding.Substring(indeksStart + 6, 1));
            råDørÅpen = Convert.ToInt32(enMelding.Substring(indeksStart + 7, 1));
            if (råDørLåst == 1)
            {
                iPB_Unlock.Show();
                iPB_Unlock.BringToFront();
                iPB_Lock.Hide();
                dørLåstOpp++;

                if(dørLåstOpp == 15)
                {
                    sp.Write("$O50");   // SimSim låser døren etter 15 sekund
                    dørLåstOpp = 0;
                }
            }
            else
            {
                iPB_Lock.Show();
                iPB_Lock.BringToFront();
                iPB_Unlock.Hide();
            }
            if (råDørÅpen == 1)
            {
                iPB_DoorOpen.Show();
                iPB_DoorOpen.BringToFront();
                iPB_DoorLocked.Hide();
            }
            else
            {
                iPB_DoorLocked.Show();
                iPB_DoorLocked.BringToFront();
                iPB_DoorOpen.Hide();
            }
        }
        //alarm funksjon
        void Alarm(string enMelding)
        {
            if (sekDørÅpen > 5 && alarm != 3 && alarm != 4)
            {
                SendEnMelding("$O71", sp);
                alarm = 3;

                dataTilSentral = $"K:{kortID} L:{kortleserID} A:{alarm}";
                  
                if (kommunikasjonMedSentral == true)
                {
                    BW_SendKvittering.RunWorkerAsync();
                }
                
            }
            int indeksStart = enMelding.IndexOf('G');
            potensiometer = Convert.ToInt32(enMelding.Substring(indeksStart + 1, 4));
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
            if (potensiometer < 500 && sekDørÅpen < 5)
            {
                SendEnMelding("$O70", sp);
                alarm = 0;
            }
        }


        // Denne funker, men bool gjennomfjørt endres ikke slik som den blir brukt i server-klient i kommentert felt under, tror jeg...
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
        private void BW_SendKvittering_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SendData(klientSokkel, dataTilSentral, out kommunikasjonMedSentral);
            if (kommunikasjonMedSentral)
            {
                dataFraSentral = MottaData(klientSokkel, out kommunikasjonMedSentral);
                // if eller try med at verdi er sann/usann, lik som Innlogging() i database.cs for sentral
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
                //if (dataFraSentral.Length == 4) //Dette vil alltid være kortleser sin ID
                //{
                //    Label_ID.Text = "Dør: " + dataFraSentral;
                //    kortleserID = dataFraSentral;
                //}
                else
                {
                    //metode for lås opp dør (datafrasentral) som her er enten "godkjent" eller "ikke godkjent"
                    TB_MottakFraSentral.Text = dataFraSentral;  //debug
                }
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
                //label1.Text = enMelding;      //Dette var bare for å se hele rå dataen fra simsim
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
                //if(alarm == 1)
                //{
                //    En funksjon for når alarmen går
                //}
            }
            bwSjekkForData.RunWorkerAsync();
        }
        private void LåsOppDør(string dataFraSentral)
        {
            if (dataFraSentral == "Godkjent")
            {
                SendEnMelding("$O51", sp);
            }
            if (dataFraSentral == "Ikke godkjent")
            {
                SendEnMelding("$O50", sp);
            }
        }
       

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