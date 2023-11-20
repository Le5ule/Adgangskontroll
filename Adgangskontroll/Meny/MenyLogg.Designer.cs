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
            TB_KortleserID = new TextBox();
            TB_KortID = new TextBox();
            CB_Alarmtype = new ComboBox();
            BTN_HentData = new Button();
            label1 = new Label();
            label2 = new Label();
            TB_FraDato = new TextBox();
            TB_TilDato = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(48, 174);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(797, 342);
            dataGridView1.TabIndex = 0;
            // 
            // TB_KortleserID
            // 
            TB_KortleserID.Location = new Point(105, 125);
            TB_KortleserID.Name = "TB_KortleserID";
            TB_KortleserID.Size = new Size(83, 27);
            TB_KortleserID.TabIndex = 14;
            // 
            // TB_KortID
            // 
            TB_KortID.Location = new Point(105, 86);
            TB_KortID.Name = "TB_KortID";
            TB_KortID.Size = new Size(83, 27);
            TB_KortID.TabIndex = 13;
            // 
            // CB_Alarmtype
            // 
            CB_Alarmtype.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Alarmtype.FormattingEnabled = true;
            CB_Alarmtype.Items.AddRange(new object[] { "Alle kortlesere", "Alle brukere", "Alle adgangsforsøk for bruker i periode:", "Alle ikke-godkjente adgangsforsøk for kortleser i periode:", "Alle alarmer", "Alle alarmer knyttet til bruker:", "Alle alarmer knyttet til kortleser:", "Alle alarmer i periode:", "Alle logger", "Alle logger kyttet til bruker:", "Alle logger knyttet til kortleser:" });
            CB_Alarmtype.Location = new Point(105, 38);
            CB_Alarmtype.Name = "CB_Alarmtype";
            CB_Alarmtype.Size = new Size(550, 28);
            CB_Alarmtype.TabIndex = 19;
            CB_Alarmtype.SelectedIndexChanged += CB_Alarmtype_SelectedIndexChanged;
            // 
            // BTN_HentData
            // 
            BTN_HentData.BackColor = SystemColors.GradientActiveCaption;
            BTN_HentData.FlatAppearance.BorderSize = 0;
            BTN_HentData.FlatStyle = FlatStyle.Flat;
            BTN_HentData.Location = new Point(671, 37);
            BTN_HentData.Name = "BTN_HentData";
            BTN_HentData.Size = new Size(113, 29);
            BTN_HentData.TabIndex = 20;
            BTN_HentData.Text = "Hent data";
            BTN_HentData.UseVisualStyleBackColor = false;
            BTN_HentData.Click += BTN_HentData_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 93);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 21;
            label1.Text = "Bruker:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 128);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 22;
            label2.Text = "Leser:";
            // 
            // TB_FraDato
            // 
            TB_FraDato.Location = new Point(292, 86);
            TB_FraDato.Name = "TB_FraDato";
            TB_FraDato.Size = new Size(113, 27);
            TB_FraDato.TabIndex = 23;
            // 
            // TB_TilDato
            // 
            TB_TilDato.Location = new Point(292, 125);
            TB_TilDato.Name = "TB_TilDato";
            TB_TilDato.Size = new Size(113, 27);
            TB_TilDato.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 89);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 25;
            label3.Text = "Fra:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(235, 128);
            label4.Name = "label4";
            label4.Size = new Size(28, 20);
            label4.TabIndex = 26;
            label4.Text = "Til:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(420, 106);
            label5.Name = "label5";
            label5.Size = new Size(194, 20);
            label5.TabIndex = 27;
            label5.Text = "Datoformat: ÅÅÅÅ-MM-DD";
            // 
            // MenyLogg
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 521);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(TB_TilDato);
            Controls.Add(TB_FraDato);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BTN_HentData);
            Controls.Add(CB_Alarmtype);
            Controls.Add(TB_KortleserID);
            Controls.Add(TB_KortID);
            Controls.Add(dataGridView1);
            Name = "MenyLogg";
            Text = "Logg";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox TB_KortleserID;
        private TextBox TB_KortID;
        private ComboBox CB_Alarmtype;
        private Button BTN_HentData;
        private Label label1;
        private Label label2;
        private TextBox TB_FraDato;
        private TextBox TB_TilDato;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}