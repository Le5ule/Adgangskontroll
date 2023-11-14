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
            // MenyLogg
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 521);
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
    }
}