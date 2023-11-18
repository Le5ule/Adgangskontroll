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
            //dataGridView.DataSource = db.Historikk();     // altså alle entries i loggen...---
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
    }
}
