using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Adgangskontroll_Bibliotek
{
    public interface I_Data
    {
        public bool godkjenning(int BrukerPin);
        public List<int> Kodeinput();
        public int Pin();
        //public int KortID();
    }
}
