namespace Sentral
{
    partial class MenyLogg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            BTN_Alarmer = new Button();
            BTN_VisAlleAlarmer = new Button();
            BTN_Historikk = new Button();
            BTN_VisBruker = new Button();
            BTN_VisLeser = new Button();
            TB_Bruker = new TextBox();
            TB_Leser = new TextBox();
            BTN_VisAlleHendelser = new Button();
            TB_Alarmtype = new TextBox();
            lbl_Alarmtype = new Label();
            TB_LeserAlarm = new TextBox();
            TB_BrukerAlarm = new TextBox();
            BTN_VisLeserAlarm = new Button();
            BTN_VisBrukerAlarm = new Button();
            DTP_fra = new DateTimePicker();
            DTP_til = new DateTimePicker();
            lbl_fra = new Label();
            lbl_til = new Label();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(50, 162);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(797, 336);
            dataGridView1.TabIndex = 0;
            dataGridView1.Visible = false;
            // 
            // BTN_Alarmer
            // 
            BTN_Alarmer.BackColor = SystemColors.GradientActiveCaption;
            BTN_Alarmer.FlatAppearance.BorderSize = 0;
            BTN_Alarmer.FlatStyle = FlatStyle.Flat;
            BTN_Alarmer.Location = new Point(50, 35);
            BTN_Alarmer.Name = "BTN_Alarmer";
            BTN_Alarmer.Size = new Size(94, 29);
            BTN_Alarmer.TabIndex = 1;
            BTN_Alarmer.Text = "Alarmer";
            BTN_Alarmer.UseVisualStyleBackColor = false;
            BTN_Alarmer.Click += BTN_Alarmer_Click;
            // 
            // BTN_VisAlleAlarmer
            // 
            BTN_VisAlleAlarmer.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisAlleAlarmer.FlatAppearance.BorderSize = 0;
            BTN_VisAlleAlarmer.FlatStyle = FlatStyle.Flat;
            BTN_VisAlleAlarmer.Location = new Point(50, 83);
            BTN_VisAlleAlarmer.Name = "BTN_VisAlleAlarmer";
            BTN_VisAlleAlarmer.Size = new Size(94, 29);
            BTN_VisAlleAlarmer.TabIndex = 2;
            BTN_VisAlleAlarmer.Text = "Vis alle";
            BTN_VisAlleAlarmer.UseVisualStyleBackColor = false;
            BTN_VisAlleAlarmer.Visible = false;
            BTN_VisAlleAlarmer.Click += BTN_VisAlleAlarmer_Click;
            // 
            // BTN_Historikk
            // 
            BTN_Historikk.BackColor = SystemColors.GradientActiveCaption;
            BTN_Historikk.FlatAppearance.BorderSize = 0;
            BTN_Historikk.FlatStyle = FlatStyle.Flat;
            BTN_Historikk.Location = new Point(177, 35);
            BTN_Historikk.Name = "BTN_Historikk";
            BTN_Historikk.Size = new Size(94, 29);
            BTN_Historikk.TabIndex = 3;
            BTN_Historikk.Text = "Historikk";
            BTN_Historikk.UseVisualStyleBackColor = false;
            BTN_Historikk.Click += BTN_Historikk_Click;
            // 
            // BTN_VisBruker
            // 
            BTN_VisBruker.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisBruker.FlatAppearance.BorderSize = 0;
            BTN_VisBruker.FlatStyle = FlatStyle.Flat;
            BTN_VisBruker.Location = new Point(50, 127);
            BTN_VisBruker.Name = "BTN_VisBruker";
            BTN_VisBruker.Size = new Size(113, 29);
            BTN_VisBruker.TabIndex = 4;
            BTN_VisBruker.Text = "Vis for bruker:";
            BTN_VisBruker.UseVisualStyleBackColor = false;
            BTN_VisBruker.Visible = false;
            BTN_VisBruker.Click += BTN_UtvalgteBrukere_Click;
            // 
            // BTN_VisLeser
            // 
            BTN_VisLeser.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisLeser.FlatAppearance.BorderSize = 0;
            BTN_VisLeser.FlatStyle = FlatStyle.Flat;
            BTN_VisLeser.Location = new Point(278, 127);
            BTN_VisLeser.Name = "BTN_VisLeser";
            BTN_VisLeser.Size = new Size(113, 29);
            BTN_VisLeser.TabIndex = 5;
            BTN_VisLeser.Text = "Vis for leser:";
            BTN_VisLeser.UseVisualStyleBackColor = false;
            BTN_VisLeser.Visible = false;
            BTN_VisLeser.Click += BTN_VisLeser_Click;
            // 
            // TB_Bruker
            // 
            TB_Bruker.Location = new Point(169, 128);
            TB_Bruker.Name = "TB_Bruker";
            TB_Bruker.Size = new Size(83, 27);
            TB_Bruker.TabIndex = 6;
            TB_Bruker.Visible = false;
            // 
            // TB_Leser
            // 
            TB_Leser.Location = new Point(397, 128);
            TB_Leser.Name = "TB_Leser";
            TB_Leser.Size = new Size(83, 27);
            TB_Leser.TabIndex = 7;
            TB_Leser.Visible = false;
            // 
            // BTN_VisAlleHendelser
            // 
            BTN_VisAlleHendelser.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisAlleHendelser.FlatAppearance.BorderSize = 0;
            BTN_VisAlleHendelser.FlatStyle = FlatStyle.Flat;
            BTN_VisAlleHendelser.Location = new Point(177, 83);
            BTN_VisAlleHendelser.Name = "BTN_VisAlleHendelser";
            BTN_VisAlleHendelser.Size = new Size(94, 29);
            BTN_VisAlleHendelser.TabIndex = 8;
            BTN_VisAlleHendelser.Text = "Vis alle";
            BTN_VisAlleHendelser.UseVisualStyleBackColor = false;
            BTN_VisAlleHendelser.Visible = false;
            BTN_VisAlleHendelser.Click += BTN_VisAlleHendelser_Click;
            // 
            // TB_Alarmtype
            // 
            TB_Alarmtype.Location = new Point(580, 127);
            TB_Alarmtype.Name = "TB_Alarmtype";
            TB_Alarmtype.Size = new Size(41, 27);
            TB_Alarmtype.TabIndex = 9;
            TB_Alarmtype.Visible = false;
            // 
            // lbl_Alarmtype
            // 
            lbl_Alarmtype.AutoSize = true;
            lbl_Alarmtype.Location = new Point(493, 129);
            lbl_Alarmtype.Name = "lbl_Alarmtype";
            lbl_Alarmtype.Size = new Size(81, 20);
            lbl_Alarmtype.TabIndex = 10;
            lbl_Alarmtype.Text = "Alarmtype:";
            lbl_Alarmtype.Visible = false;
            // 
            // TB_LeserAlarm
            // 
            TB_LeserAlarm.Location = new Point(397, 128);
            TB_LeserAlarm.Name = "TB_LeserAlarm";
            TB_LeserAlarm.Size = new Size(83, 27);
            TB_LeserAlarm.TabIndex = 14;
            TB_LeserAlarm.Visible = false;
            // 
            // TB_BrukerAlarm
            // 
            TB_BrukerAlarm.Location = new Point(169, 128);
            TB_BrukerAlarm.Name = "TB_BrukerAlarm";
            TB_BrukerAlarm.Size = new Size(83, 27);
            TB_BrukerAlarm.TabIndex = 13;
            TB_BrukerAlarm.Visible = false;
            // 
            // BTN_VisLeserAlarm
            // 
            BTN_VisLeserAlarm.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisLeserAlarm.FlatAppearance.BorderSize = 0;
            BTN_VisLeserAlarm.FlatStyle = FlatStyle.Flat;
            BTN_VisLeserAlarm.Location = new Point(278, 127);
            BTN_VisLeserAlarm.Name = "BTN_VisLeserAlarm";
            BTN_VisLeserAlarm.Size = new Size(113, 29);
            BTN_VisLeserAlarm.TabIndex = 12;
            BTN_VisLeserAlarm.Text = "Vis for leser:";
            BTN_VisLeserAlarm.UseVisualStyleBackColor = false;
            BTN_VisLeserAlarm.Visible = false;
            BTN_VisLeserAlarm.Click += BTN_VisLeserAlarm_Click;
            // 
            // BTN_VisBrukerAlarm
            // 
            BTN_VisBrukerAlarm.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisBrukerAlarm.FlatAppearance.BorderSize = 0;
            BTN_VisBrukerAlarm.FlatStyle = FlatStyle.Flat;
            BTN_VisBrukerAlarm.Location = new Point(50, 127);
            BTN_VisBrukerAlarm.Name = "BTN_VisBrukerAlarm";
            BTN_VisBrukerAlarm.Size = new Size(113, 29);
            BTN_VisBrukerAlarm.TabIndex = 11;
            BTN_VisBrukerAlarm.Text = "Vis for bruker:";
            BTN_VisBrukerAlarm.UseVisualStyleBackColor = false;
            BTN_VisBrukerAlarm.Visible = false;
            BTN_VisBrukerAlarm.Click += BTN_VisBrukerAlarm_Click;
            // 
            // DTP_fra
            // 
            DTP_fra.Format = DateTimePickerFormat.Short;
            DTP_fra.Location = new Point(638, 129);
            DTP_fra.Name = "DTP_fra";
            DTP_fra.Size = new Size(97, 27);
            DTP_fra.TabIndex = 15;
            DTP_fra.Visible = false;
            // 
            // DTP_til
            // 
            DTP_til.Format = DateTimePickerFormat.Short;
            DTP_til.Location = new Point(741, 129);
            DTP_til.Name = "DTP_til";
            DTP_til.Size = new Size(97, 27);
            DTP_til.TabIndex = 16;
            DTP_til.Visible = false;
            // 
            // lbl_fra
            // 
            lbl_fra.AutoSize = true;
            lbl_fra.Location = new Point(638, 106);
            lbl_fra.Name = "lbl_fra";
            lbl_fra.Size = new Size(32, 20);
            lbl_fra.TabIndex = 17;
            lbl_fra.Text = "Fra:";
            lbl_fra.Visible = false;
            // 
            // lbl_til
            // 
            lbl_til.AutoSize = true;
            lbl_til.Location = new Point(741, 106);
            lbl_til.Name = "lbl_til";
            lbl_til.Size = new Size(32, 20);
            lbl_til.TabIndex = 18;
            lbl_til.Text = "Fra:";
            lbl_til.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "en", "to", "trr" });
            comboBox1.Location = new Point(383, 59);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 19;
            // 
            // MenyLogg
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 521);
            Controls.Add(comboBox1);
            Controls.Add(lbl_til);
            Controls.Add(lbl_fra);
            Controls.Add(DTP_til);
            Controls.Add(DTP_fra);
            Controls.Add(TB_LeserAlarm);
            Controls.Add(TB_BrukerAlarm);
            Controls.Add(BTN_VisLeserAlarm);
            Controls.Add(BTN_VisBrukerAlarm);
            Controls.Add(lbl_Alarmtype);
            Controls.Add(TB_Alarmtype);
            Controls.Add(BTN_VisAlleHendelser);
            Controls.Add(TB_Leser);
            Controls.Add(TB_Bruker);
            Controls.Add(BTN_VisLeser);
            Controls.Add(BTN_VisBruker);
            Controls.Add(BTN_Historikk);
            Controls.Add(BTN_VisAlleAlarmer);
            Controls.Add(BTN_Alarmer);
            Controls.Add(dataGridView1);
            Name = "MenyLogg";
            Text = "Logg";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button BTN_Alarmer;
        private Button BTN_VisAlleAlarmer;
        private Button BTN_Historikk;
        private Button BTN_VisBruker;
        private Button BTN_VisLeser;
        private TextBox TB_Bruker;
        private TextBox TB_Leser;
        private Button BTN_VisAlleHendelser;
        private TextBox TB_Alarmtype;
        private Label lbl_Alarmtype;
        private TextBox TB_LeserAlarm;
        private TextBox TB_BrukerAlarm;
        private Button BTN_VisLeserAlarm;
        private Button BTN_VisBrukerAlarm;
        private DateTimePicker DTP_fra;
        private DateTimePicker DTP_til;
        private Label lbl_fra;
        private Label lbl_til;
        private ComboBox comboBox1;
    }
}