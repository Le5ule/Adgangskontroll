using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentral
{
    public partial class MenyInnstillinger : Form
    {
        // Etablerer tilgang til database-klassen. Strengt tatt ikke nødvendig her, men ved implemetering av
        // flere funksjoner, kan det være behov.
        Database db = new Database();
        public MenyInnstillinger()
        {
            InitializeComponent();
        }

        // Viser "om programmet"
        private void BTN_Om_Click(object sender, EventArgs e)
        {
            if (lbl_info.Visible == false) lbl_info.Visible = true;
            else lbl_info.Visible = false;
        }
    }
}
