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
        // Etablerer tilgang til database-klassen
        Database db = new Database();

        // brukes til sikkerhetsmekanismer
        static bool Avbryt = false;

        // Dataene som brukes for denne menyen
        static string fornavn;
        static string etternavn;
        static string kort_id;
        static string seksjon;
        static string gyldigfra;
        static string gyldigtil;
        public MenyBrukere()
        {
            InitializeComponent();
        }
        
        // Legge til ny bruker
        private void BTN_LeggTil_Click(object sender, EventArgs e)
        {
            // Legger inn de aktuelle verdiene
            fornavn = TB_Fnavn.Text;
            etternavn = TB_Enavn.Text;
            kort_id = TB_ID.Text;
            seksjon = TB_Seksjon.Text;
            gyldigfra = TB_FraDato.Text + " 00:00:00";
            gyldigtil = TB_TilDato.Text + " 00:00:00";

            // Sender informasjon om ny bruker til databasen
            try
            {
                db.LeggTilNyBruker(fornavn, etternavn, kort_id, seksjon, gyldigfra, gyldigtil);
                MessageBox.Show($"Bruker {kort_id} ble lagt til");

            }
            catch (Exception)
            {
                MessageBox.Show($"Bruker {kort_id} ble ikke lagt til.\nPrøv på nytt");
            }
            

            // Tømmer feltene
            TB_Fnavn.Clear();
            TB_Enavn.Clear();
            TB_ID.Clear();
            TB_Seksjon.Clear();
            TB_FraDato.Clear();
            TB_TilDato.Clear();

            
        }

        // Endre eksisterende bruker
        private void BTN_Endre_Click(object sender, EventArgs e)
        {
            string fnavn = TB_Fnavn.Text;
            string enavn = TB_Enavn.Text;
            string id = TB_ID.Text;
            string seksjon = TB_Seksjon.Text;
            string gyldigfra = TB_FraDato.Text + " 00:00:00";
            string gyldigtil = TB_TilDato.Text + " 00:00:00";

            // Sender oppdatert informajson til databasen
            try
            {
                db.EndreBruker(fnavn, enavn, id, seksjon, gyldigfra, gyldigtil);
                MessageBox.Show($"Bruker {id} ble endret");
            }
            catch (Exception)
            {
                MessageBox.Show($"Bruker {id} ble ikke endret.\nPrøv på nytt");
            }

            // Tømmer feltene
            TB_Fnavn.Clear();
            TB_Enavn.Clear();
            TB_ID.Clear();
            TB_Seksjon.Clear();
            TB_FraDato.Clear();
            TB_TilDato.Clear();

            MessageBox.Show($"Bruker {id} er endret");
        }

        // Vise alle brukere
        private void BTN_VisBrukere_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

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

        // Åpne meny for å kunne endre brukere
        private void BTN_EndreBrukere_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

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

        // Åpne meny for å legge til nye brukere
        private void BTN_Ny_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

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

        // Åpne meny for å slette brukere
        private void BTN_SlettBrukere_Click(object sender, EventArgs e)
        {
            // For å vise/skjule felt som trengs/ikke trengs til denne undermenyen

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

        // Slette bruker fra databasen, sikkerhetsmekanisme ved evt. "trykket slett ved uhell"
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
