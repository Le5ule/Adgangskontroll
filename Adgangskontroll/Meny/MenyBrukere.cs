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
    public partial class MenyBrukere : Form
    {
        Database db = new Database();
        public MenyBrukere()
        {
            InitializeComponent();
        }

        private void BTN_LeggTil_Click(object sender, EventArgs e)
        {
            string fnavn = TB_Fnavn.Text;
            string enavn = TB_Enavn.Text;
            string id = TB_ID.Text;
            DateTime gyldigfra = dtGyldigFra.Value;
            DateTime gyldigtil = dtGyldigTil.Value;
            db.LeggTilNyBruker(fnavn, enavn, id, gyldigfra, gyldigtil);
            TB_Fnavn.Clear();
            TB_Enavn.Clear();
            TB_ID.Clear();
        }
        private void BTN_Endre_Click(object sender, EventArgs e)
        {
            string fnavn = TB_Fnavn.Text;
            string enavn = TB_Enavn.Text;
            string id = TB_ID.Text;
            DateTime gyldigfra = dtGyldigFra.Value;
            DateTime gyldigtil = dtGyldigTil.Value;
            db.EndreBruker(fnavn, enavn, id, gyldigfra, gyldigtil);
            TB_Fnavn.Clear();
            TB_Enavn.Clear();
            TB_ID.Clear();
        }
        private void BTN_VisBrukere_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = true;
            TB_Fnavn.Visible = false;
            TB_Enavn.Visible = false;
            TB_ID.Visible = false;
            dtGyldigFra.Visible = false;
            dtGyldigTil.Visible = false;
            lbl_ENavn.Visible = false;
            lbl_FNavn.Visible = false;
            lbl_ID.Visible = false;
            lbl_GyldigFra.Visible = false;
            lbl_GyldigTil.Visible = false;
            BTN_Endre.Visible = false;
            BTN_LeggTil.Visible = false;
            dataGridView.DataSource = db.VisBrukere();
        }

        private void BTN_EndreBrukere_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = false;
            TB_Fnavn.Visible = true;
            TB_Enavn.Visible = true;
            TB_ID.Visible = true;
            dtGyldigFra.Visible = true;
            dtGyldigTil.Visible = true;
            lbl_ENavn.Visible = true;
            lbl_FNavn.Visible = true;
            lbl_ID.Visible = true;
            lbl_GyldigFra.Visible = true;
            lbl_GyldigTil.Visible = true;
            BTN_Endre.Visible = true;
            BTN_LeggTil.Visible = false;
        }
        private void BTN_Ny_Click(object sender, EventArgs e)
        {
            TB_Fnavn.Visible = true;
            TB_Enavn.Visible = true;
            TB_ID.Visible = true;
            dtGyldigFra.Visible = true;
            dtGyldigTil.Visible = true;
            lbl_ENavn.Visible = true;
            lbl_FNavn.Visible = true;
            lbl_ID.Visible = true;
            lbl_GyldigFra.Visible = true;
            lbl_GyldigTil.Visible = true;
            BTN_LeggTil.Visible = true;
            BTN_Endre.Visible = false;
            dataGridView.Visible = false;
        }
    }
}
