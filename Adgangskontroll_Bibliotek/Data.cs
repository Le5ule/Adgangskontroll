namespace Adgangskontroll_Bibliotek
{
    public class Data : I_Data
    {
        List<int> kodeinput = new List<int>();
        int lestKort = 0000; 
        public static string pin = "";
        public static int kortID = 0000;

        public bool godkjenning(string user)
        {
            bool svar = false;
            if (svar == false)
            {
                pin = kodeinput[0].ToString() + kodeinput[1].ToString() + kodeinput[2].ToString() + kodeinput[3].ToString();
                svar = true;
            }
            else
            {
                //MessageBox.Show("Feil kode, skriv inn på nytt");      //funker ikke siden dette er klassebibliotek
                kodeinput.Clear();
            }
            return svar;
        }
        public bool Kort(int kort)
        {
            bool svar = false;
            if (svar == false)
            {
                kortID = KortID();
                //lestKort = KortID();
                svar = true;
            }
            else
            {
                kortID = 0000;
            }
            return svar;
        }

        public List<int> Kodeinput()
        {
            return kodeinput;
        }
        public string Pin()
        {
            return pin;
        }
        public int KortID()
        {
            return kortID;
        }
    }
}