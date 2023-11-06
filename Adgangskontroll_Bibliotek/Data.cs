namespace Adgangskontroll_Bibliotek
{
    public class Data : I_Data
    {
        List<int> kodeinput = new List<int>();
        int lestKort = 0000; 
        public static string pinString = "";
        public static int pin;
        public static int kortID = 0000;

        public bool godkjenning(int BrukerPin)
        {
            bool svar = false;
            if (svar == false)
            {
                pinString = kodeinput[0].ToString() + kodeinput[1].ToString() + kodeinput[2].ToString() + kodeinput[3].ToString();
                           pin = int.Parse(pinString);
                svar = true;
            }
            else
            {
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
        public int Pin()
        {
            return pin;
        }
        public int KortID()
        {
            return kortID;
        }
    }
}