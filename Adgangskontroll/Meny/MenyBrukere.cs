using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sentral
{
    public partial class MenyBrukere : Form
    {
        Database db = new Database();
        static bool Avbryt = false;
        public MenyBrukere()
        {
            InitializeComponent();
        }
        //må gå gjennom å reformaterer alle inputs, gjør det slik at det matcher som i database.cs
        private void BTN_LeggTil_Click(object sender, EventArgs e)
        {
            string fnavn = TB_Fnavn.Text;
            string enavn = TB_Enavn.Text;
            string id = TB_ID.Text;
            string seksjon = TB_Seksjon.Text;
            string gyldigfra = TB_FraDato.Text + " 00:00:00";
            string gyldigtil = TB_TilDato.Text + " 00:00:00";
            db.LeggTilNyBruker(fnavn, enavn, id, seksjon, gyldigfra, gyldigtil);
            TB_Fnavn.Clear();
            TB_Enavn.Clear();
            TB_ID.Clear();
            TB_Seksjon.Clear();
            TB_FraDato.Clear();
            TB_TilDato.Clear();

            MessageBox.Show($"Bruker {id} er lagt til");
        }
        private void BTN_Endre_Click(object sender, EventArgs e)
        {
            string fnavn = TB_Fnavn.Text;
            string enavn = TB_Enavn.Text;
            string id = TB_ID.Text;
            string seksjon = TB_Seksjon.Text;
            string gyldigfra = TB_FraDato.Text + " 00:00:00";
            string gyldigtil = TB_TilDato.Text + " 00:00:00";
            db.EndreBruker(fnavn, enavn, id, seksjon, gyldigfra, gyldigtil);
            TB_Fnavn.Clear();
            TB_Enavn.Clear();
            TB_ID.Clear();
            TB_Seksjon.Clear();
            TB_FraDato.Clear();
            TB_TilDato.Clear();

            MessageBox.Show($"Bruker {id} er endret");
        }
        private void BTN_VisBrukere_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = true;
            TB_Fnavn.Visible = false;
            TB_Enavn.Visible = false;
            TB_ID.Visible = false;
            TB_TilDato.Visible = false;
            TB_FraDato.Visible = false;
            lbl_ENavn.Visible = false;
            lbl_FNavn.Visible = false;
            lbl_ID.Visible = false;
            lbl_Seksjon.Visible = false;
            TB_Seksjon.Visible = false;
            lbl_fra.Visible = false;
            lbl_til.Visible = false;
            lbl_datoformat.Visible = false;
            BTN_Endre.Visible = false;
            BTN_LeggTil.Visible = false;
            TB_ID_2.Visible = false;
            lbl_ID_2.Visible = false;
            BTN_Slett.Visible = false;
            
            dataGridView.DataSource = db.VisBrukere();
        }

        private void BTN_EndreBrukere_Click(object sender, EventArgs e)
        {
            dataGridView.Visible = false;
            TB_Fnavn.Visible = true;
            TB_Enavn.Visible = true;
            TB_ID.Visible = true;
            lbl_fra.Visible = true;
            lbl_til.Visible = true;
            lbl_datoformat.Visible = true;
            lbl_ENavn.Visible = true;
            lbl_FNavn.Visible = true;
            lbl_ID.Visible = true;
            lbl_Seksjon.Visible = true;
            TB_Seksjon.Visible = true;
            TB_FraDato.Visible = true;
            TB_TilDato.Visible = true;
            BTN_Endre.Visible = true;
            BTN_LeggTil.Visible = false;
            TB_ID_2.Visible = false;
            lbl_ID_2.Visible = false;
            BTN_Slett.Visible = false;
        }
        private void BTN_Ny_Click(object sender, EventArgs e)
        {
            TB_Fnavn.Visible = true;
            TB_Enavn.Visible = true;
            TB_ID.Visible = true;
            TB_FraDato.Visible = true;
            TB_TilDato.Visible = true;
            lbl_ENavn.Visible = true;
            lbl_FNavn.Visible = true;
            lbl_ID.Visible = true;
            lbl_Seksjon.Visible = true;
            TB_Seksjon.Visible = true;
            lbl_fra.Visible = true;
            lbl_til.Visible = true;
            lbl_datoformat.Visible = true;
            BTN_LeggTil.Visible = true;
            BTN_Endre.Visible = false;
            dataGridView.Visible = false;
            TB_ID_2.Visible = false;
            lbl_ID_2.Visible = false;
            BTN_Slett.Visible = false;
        }

        private void BTN_SlettBrukere_Click(object sender, EventArgs e)
        {
            TB_ID_2.Visible = true;
            lbl_ID_2.Visible = true;
            BTN_Slett.Visible = true;
            TB_Fnavn.Visible = false;
            TB_Enavn.Visible = false;
            TB_ID.Visible = false;
            TB_FraDato.Visible = false;
            TB_TilDato.Visible = false;
            lbl_ENavn.Visible = false;
            lbl_FNavn.Visible = false;
            lbl_ID.Visible = false;
            lbl_Seksjon.Visible = false;
            TB_Seksjon.Visible = false;
            lbl_fra.Visible = false;
            lbl_til.Visible = false;
            lbl_datoformat.Visible = false;
            BTN_LeggTil.Visible = false;
            BTN_Endre.Visible = false;
            dataGridView.Visible = false;
        }

        private void BTN_Slett_Click(object sender, EventArgs e)
        {
            if (!Avbryt)
            {
                var result = MessageBox.Show("Er du sikker på at du vil fjerne denne brukeren?", "Fjerne bruker " + TB_ID_2.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Hvis man trykket "nei"
                if (result == DialogResult.No)
                {

                }
                else if (result == DialogResult.Yes)
                {
                    db.SlettBruker(TB_ID_2.Text);
                    MessageBox.Show($"Bruker {TB_ID_2.Text} er slettet");
                }
            }
        }
    }
}
