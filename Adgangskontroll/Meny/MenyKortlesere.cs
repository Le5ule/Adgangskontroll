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
        // Etablerer tilgang til database-klassen
        Database db = new Database();

        // Brukes til sikkerhetsmekanismer
        static bool Avbryt = false;

        // Dataene som brukes for denne menyen
        static string kortleser_id;
        static string seksjon_id;
        static string beskrivelse;
        public MenyKortlesere()
        {
            InitializeComponent();
        }

        private void BTN_VisLesere_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

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
            TB_Beskrivelse.Visible = false;
            lbl_Beskrivelse.Visible = false;

        }

        private void BTN_alle_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.VisKortlesere();
        }

        private void BTN_seksjon_Click(object sender, EventArgs e)
        {
            // Legger inn de aktuelle verdiene
            seksjon_id = TB_SeksjonVis.Text;
            int seksjon = int.Parse(seksjon_id);
            dataGridView1.DataSource = db.VisKortleserVedSeksjon(seksjon);
        }

        private void BTN_Nyelesere_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

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
            TB_Beskrivelse.Visible = true;
            lbl_Beskrivelse.Visible = true;
        }

        private void BTN_EndreLesere_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

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
            TB_Beskrivelse.Visible = true;
            lbl_Beskrivelse.Visible = true;
        }

        private void BTN_endre_Click(object sender, EventArgs e)
        {
            kortleser_id = TB_LeserID.Text;
            seksjon_id = TB_seksjon.Text;
            beskrivelse = TB_Beskrivelse.Text;

            try
            {
                db.EndreKortleser(kortleser_id, seksjon_id, beskrivelse);
                MessageBox.Show($"Kortleser {kortleser_id} er endret");
            }
            catch (Exception)
            {
                MessageBox.Show($"Kortleser {kortleser_id} ble ikke endret.\nPrøv på nytt");
            }
            

            TB_LeserID.Clear();
            TB_seksjon.Clear();
            TB_Beskrivelse.Clear();
        }

        private void BTN_LeggTilNy_Click(object sender, EventArgs e)
        {
            // Legger inn de aktuelle verdiene
            kortleser_id = TB_LeserID.Text;
            seksjon_id = TB_seksjon.Text;
            beskrivelse = TB_Beskrivelse.Text;

            // Sender til database, og får "bekreftelse"
            try
            {
                db.LeggTilNyKortleser(kortleser_id, seksjon_id, beskrivelse);
                MessageBox.Show($"Kortleser {kortleser_id} er lagt til");
            }
            catch (Exception)
            {
                MessageBox.Show($"Kortleser {kortleser_id} ble ikke lagt til.\nPrøv på nytt");
            }
            

            // Tømmer feltene
            TB_LeserID.Clear();
            TB_seksjon.Clear();
            TB_Beskrivelse.Clear();
        }

        private void BTN_SlettLesere_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

            BTN_alle.Visible = false;
            BTN_seksjon.Visible = false;
            dataGridView1.Visible = false;
            TB_SeksjonVis.Visible = false;
            TB_seksjon.Visible = false;
            lbl_seksjon.Visible = false;
            BTN_LeggTilNy.Visible = false;
            BTN_endre.Visible = false;
            TB_Beskrivelse.Visible = false;
            lbl_Beskrivelse.Visible = false;
            TB_LeserID.Visible = true;
            BTN_Slett.Visible = true;
            lbl_ID.Visible = true;
        }

        // Slette kortleser fra databasen, sikkerhetsmekanisme ved evt. "trykket slett ved uhell"
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
