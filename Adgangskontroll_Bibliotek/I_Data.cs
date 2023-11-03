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
        public bool godkjenning(string user);
        public List<int> Kodeinput();
        public string Pin();
        public int KortID();
    }
}
