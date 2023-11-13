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
    public partial class MenyKortlesere : Form
    {
        Database db = new Database();
        public MenyKortlesere()
        {
            InitializeComponent();
        }

        private void BTN_VisLesere_Click(object sender, EventArgs e)
        {
            BTN_alle.Visible = true;
            BTN_seksjon.Visible = true;
            dataGridView1.Visible = true;
            TB_SeksjonVis.Visible = true;
            TB_LeserID.Visible = false;
            TB_seksjon.Visible = false;
            lbl_ID.Visible = false;
            lbl_seksjon.Visible = false;
            BTN_LeggTilNy.Visible = false;
            BTN_endre.Visible = false;

        }

        private void BTN_alle_Click(object sender, EventArgs e)
        {
            //db.VisKortlesere(alle)    //noe slikt
        }

        private void BTN_seksjon_Click(object sender, EventArgs e)
        {
            string seksjon = TB_SeksjonVis.Text;
            //db.VisKortlesere(sekjson)     //noe slikt
        }

        private void BTN_Nyelesere_Click(object sender, EventArgs e)
        {
            BTN_alle.Visible = false;
            BTN_seksjon.Visible = false;
            dataGridView1.Visible = false;
            TB_SeksjonVis.Visible = false;
            TB_LeserID.Visible = true;
            TB_seksjon.Visible = true;
            lbl_ID.Visible = true;
            lbl_seksjon.Visible = true;
            BTN_LeggTilNy.Visible = true;
            BTN_endre.Visible = false;
        }

        private void BTN_EndreLesere_Click(object sender, EventArgs e)
        {
            BTN_alle.Visible = false;
            BTN_seksjon.Visible = false;
            dataGridView1.Visible = false;
            TB_SeksjonVis.Visible = false;
            TB_LeserID.Visible = true;
            TB_seksjon.Visible = true;
            lbl_ID.Visible = true;
            lbl_seksjon.Visible = true;
            BTN_LeggTilNy.Visible = false;
            BTN_endre.Visible = true;
        }

        private void BTN_endre_Click(object sender, EventArgs e)
        {
            //db.EndreKortleser();
        }

        private void BTN_LeggTilNy_Click(object sender, EventArgs e)
        {
            //db.LeggTilKortleser();
        }
    }
}
