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


        public MenyLogg()
        {
            InitializeComponent();
        }

        private void BTN_UtvalgteBrukere_Click(object sender, EventArgs e)
        {
            string bruker = TB_Bruker.Text;
            //dataGridView.DataSource = db.Alarm(bruker);
            TB_Bruker.Clear();
        }

        private void BTN_VisLeser_Click(object sender, EventArgs e)
        {
            string leser = TB_Leser.Text;
            //dataGridView.DataSource = db.Alarm(leser);
            TB_Leser.Clear();
        }

        private void BTN_VisAlleAlarmer_Click(object sender, EventArgs e)
        {
            //dataGridView.DataSource = db.Alarm(alle);
        }

        private void BTN_Historikk_Click(object sender, EventArgs e)
        {
            BTN_VisBruker.Visible = true;
            BTN_VisLeser.Visible = true;
            BTN_VisAlleHendelser.Visible = true;
            BTN_VisAlleAlarmer.Visible = false;
            TB_Bruker.Visible = true;
            TB_Leser.Visible = true;
            BTN_VisBrukerAlarm.Visible = false;
            BTN_VisAlleAlarmer.Visible = false;
            TB_BrukerAlarm.Visible = false;
            TB_LeserAlarm.Visible = false;
            TB_Alarmtype.Visible = false;
            lbl_Alarmtype.Visible = false;

            lbl_fra.Visible = false;
            lbl_til.Visible = false;
            DTP_fra.Visible = false;
            DTP_til.Visible = false;

        }

        private void BTN_Alarmer_Click(object sender, EventArgs e)
        {
            BTN_VisBrukerAlarm.Visible = true;
            BTN_VisAlleAlarmer.Visible = true;
            BTN_VisLeserAlarm.Visible = true;
            BTN_VisAlleHendelser.Visible = false;
            TB_BrukerAlarm.Visible = true;
            TB_LeserAlarm.Visible = true;
            BTN_VisBruker.Visible = false;
            BTN_VisLeser.Visible = false;
            TB_Bruker.Visible = false;
            TB_Leser.Visible = false;
            TB_Alarmtype.Visible = true;
            lbl_Alarmtype.Visible = true;

            lbl_fra.Visible = true;
            lbl_til.Visible = true;
            DTP_fra.Visible = true;
            DTP_til.Visible = true;
        }

        private void BTN_VisAlleHendelser_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true; //noen grunn til å ikke ha denne visable hele tiden?
            dataGridView1.DataSource = db.VisLogg();     // altså alle entries i loggen...---
        }

        private void BTN_VisBrukerAlarm_Click(object sender, EventArgs e)
        {
            string alarmtype = TB_Alarmtype.Text;
            //db...
        }

        private void BTN_VisLeserAlarm_Click(object sender, EventArgs e)
        {
            string alarmtype = TB_Alarmtype.Text;
            //db...
        }

        // Gjør det slik at denne hendelsen kun endrer på writable til feltene; lag en ny switch-case
        private void CB_Alarmtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            switch (CB_Alarmtype.Text) //koble denne til trykk av hent-knapp
            {
                case "Alle kortlesere":
                    dataGridView1.DataSource = db.VisKortleser();//ingen ekstra informasjon trengs å leses fra textbox
                    break;
                case "Alle brukere":
                    dataGridView1.DataSource = db.VisBrukere();
                    break;
                case "Alle adgangsforsøk knyttet til bruker i periode:":
                    // dataGridView1.DataSource = db.VisAdgangsloggForBrukerVedDato(string kort_id, DateTime start, DateTime slutt); //trenger kort id, date start og slutt
                    break;
                case "Alle ikke-godkjente adgangsforsøk knyttet til kortleser i periode:":
                    // dataGridView1.DataSource = db.VisNegativAdgangsloggKortleserVedDato(string kortleser_id, DateTime start, DateTime slutt);
                    break;
                case "Alle alarmer":
                    dataGridView1.DataSource = db.VisAlarm();
                    break;
                case "Alle alarmer knyttet til bruker:":
                    // dataGridView1.DataSource = db.VisAlarmVedBruker(string kort_id);
                    break;
                case "Alle alarmer knyttet til kortleser:":
                    // dataGridView1.DataSource = db.VisAlarmVedKortleser(int kortleser_id);
                    break;
                case "Alle alarmer i periode:":
                    // dataGridView1.DataSource = db.VisAlarmVedDato(DateTime start, DateTime slutt);
                case "Alle logger":
                    dataGridView1.DataSource = db.VisLogg();
                    break;
                case "Alle logger kyttet til bruker:":
                    //dataGridView1.DataSource = db.VisLoggVedBruker(string kort_id);
                    break;
                case "Alle logger knyttet til kortleser:":
                    //dataGridView1.DataSource = db.VisLoggVedKortleser(string kortleser_id);
                    break;
            }
        }
    }
}
