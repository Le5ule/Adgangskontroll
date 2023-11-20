using Microsoft.Extensions.Logging;
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

    public partial class MenyLogg : Form
    {
        Database db = new Database();

        static string kort_ID;
        static string kortleser_ID;
        static string startTid;
        static string sluttTid;

        public MenyLogg()
        {
            InitializeComponent();
        }

        // Gjør det slik at denne hendelsen kun endrer på writable til feltene; lag en ny switch-case
        private void CB_Alarmtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            TB_FraDato.Clear();
            TB_TilDato.Clear();
            TB_KortID.Clear();
            TB_KortleserID.Clear();
        }

        // Noe
        private void BTN_HentData_Click(object sender, EventArgs e)
        {
            switch (CB_Alarmtype.Text)
            {
                case "Alle kortlesere":
                    dataGridView1.DataSource = db.VisKortleser();//ingen ekstra informasjon trengs å leses fra textbox
                    break;
                case "Alle brukere":
                    dataGridView1.DataSource = db.VisBrukere();
                    break;
                case "Alle adgangsforsøk knyttet til bruker i periode:":
                    kort_ID = TB_KortID.Text;
                    startTid = TB_FraDato.Text + " 00:00:00";
                    sluttTid = TB_TilDato.Text + " 00:00:00";
                    dataGridView1.DataSource = db.VisAdgangsloggForBrukerVedDato(kort_ID, startTid, sluttTid); //trenger kort id, date start og slutt
                    break;
                case "Alle ikke-godkjente adgangsforsøk knyttet til kortleser i periode:":
                    kortleser_ID = TB_KortleserID.Text;
                    startTid = TB_FraDato.Text + " 00:00:00";
                    sluttTid = TB_TilDato.Text + " 00:00:00";
                    dataGridView1.DataSource = db.VisNegativAdgangsloggKortleserVedDato(kortleser_ID, startTid, sluttTid);
                    break;
                case "Alle alarmer":
                    dataGridView1.DataSource = db.VisAlarm();
                    break;
                case "Alle alarmer knyttet til bruker:":
                    kort_ID = TB_KortID.Text;
                    dataGridView1.DataSource = db.VisAlarmVedBruker(kort_ID);
                    break;
                case "Alle alarmer knyttet til kortleser:":
                    kortleser_ID = TB_KortleserID.Text;
                    dataGridView1.DataSource = db.VisAlarmVedKortleser(kortleser_ID);
                    break;
                case "Alle alarmer i periode:":
                    startTid = TB_FraDato.Text + " 00:00:00";
                    sluttTid = TB_TilDato.Text + " 00:00:00";
                    dataGridView1.DataSource = db.VisAlarmVedDato(startTid, sluttTid);
                    break;
                case "Alle logger":
                    dataGridView1.DataSource = db.VisLogg();
                    break;
                case "Alle logger kyttet til bruker:":
                    kort_ID = TB_KortID.Text;
                    dataGridView1.DataSource = db.VisLoggVedBruker(kort_ID);
                    break;
                case "Alle logger knyttet til kortleser:":
                    kortleser_ID = TB_KortleserID.Text;
                    dataGridView1.DataSource = db.VisLoggVedKortleser(kortleser_ID);
                    break;
            }
        }
    }
}
