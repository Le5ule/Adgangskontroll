using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        static bool Avbryt = false;
        static string kortleser_id;
        static string seksjon_id;
        static string beskrivelse;
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
            BTN_endre.Visible = false;
            TB_LeserID.Visible = false;
            TB_seksjon.Visible = false;
            lbl_ID.Visible = false;
            lbl_seksjon.Visible = false;
            BTN_LeggTilNy.Visible = false;
            BTN_endre.Visible = false;
            BTN_Slett.Visible = false;

        }

        private void BTN_alle_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.VisKortleser();
        }

        private void BTN_seksjon_Click(object sender, EventArgs e)
        {
            seksjon_id = TB_SeksjonVis.Text;
            int seksjon = int.Parse(seksjon_id);
            dataGridView1.DataSource = db.VisKortleserVedSeksjon(seksjon);
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
            BTN_Slett.Visible = false;
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
            BTN_Slett.Visible = false;
        }

        private void BTN_endre_Click(object sender, EventArgs e)
        {
            kortleser_id = TB_LeserID.Text;
            seksjon_id = TB_seksjon.Text;
            beskrivelse = TB_Beskrivelse.Text;

            db.EndreKortleser(kortleser_id, seksjon_id, beskrivelse);
            
            TB_LeserID.Clear();
            TB_seksjon.Clear();
            TB_Beskrivelse.Clear();
        }

        private void BTN_LeggTilNy_Click(object sender, EventArgs e)
        {
            kortleser_id = TB_LeserID.Text;
            seksjon_id = TB_seksjon.Text;
            beskrivelse = TB_Beskrivelse.Text;

            db.LeggTilNyKortleser(kortleser_id, seksjon_id, beskrivelse);

            TB_LeserID.Clear();
            TB_seksjon.Clear();
            TB_Beskrivelse.Clear();
        }

        private void BTN_SlettLesere_Click(object sender, EventArgs e)
        {
            BTN_alle.Visible = false;
            BTN_seksjon.Visible = false;
            dataGridView1.Visible = false;
            TB_SeksjonVis.Visible = false;
            TB_seksjon.Visible = false;
            lbl_seksjon.Visible = false;
            BTN_LeggTilNy.Visible = false;
            BTN_endre.Visible = false;

            TB_LeserID.Visible = true;
            BTN_Slett.Visible = true;
            lbl_ID.Visible = true;
        }

        private void BTN_Slett_Click(object sender, EventArgs e)
        {
            if (!Avbryt)
            {
                var result = MessageBox.Show("Er du sikker på at du vil fjerne denne kortleseren?", "Fjerne kortleser: " + TB_LeserID.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Hvis man trykket "nei"
                if (result == DialogResult.No)
                {

                }
                else if (result == DialogResult.Yes)
                {
                    db.SlettKortleser(TB_LeserID.Text);
                }
                TB_LeserID.Clear();
            }
        }
    }
}
