namespace Sentral
{
    partial class MenyKortlesere
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
            BTN_Nyelesere = new Button();
            BTN_EndreLesere = new Button();
            BTN_VisLesere = new Button();
            dataGridView1 = new DataGridView();
            BTN_alle = new Button();
            BTN_seksjon = new Button();
            TB_SeksjonVis = new TextBox();
            TB_LeserID = new TextBox();
            TB_seksjon = new TextBox();
            BTN_LeggTilNy = new Button();
            lbl_ID = new Label();
            lbl_seksjon = new Label();
            BTN_endre = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // BTN_Nyelesere
            // 
            BTN_Nyelesere.BackColor = SystemColors.GradientActiveCaption;
            BTN_Nyelesere.FlatAppearance.BorderSize = 0;
            BTN_Nyelesere.FlatStyle = FlatStyle.Flat;
            BTN_Nyelesere.Location = new Point(50, 35);
            BTN_Nyelesere.Name = "BTN_Nyelesere";
            BTN_Nyelesere.Size = new Size(175, 29);
            BTN_Nyelesere.TabIndex = 1;
            BTN_Nyelesere.Text = "Legg til nye kortlesere";
            BTN_Nyelesere.UseVisualStyleBackColor = false;
            BTN_Nyelesere.Click += BTN_Nyelesere_Click;
            // 
            // BTN_EndreLesere
            // 
            BTN_EndreLesere.BackColor = SystemColors.GradientActiveCaption;
            BTN_EndreLesere.FlatAppearance.BorderSize = 0;
            BTN_EndreLesere.FlatStyle = FlatStyle.Flat;
            BTN_EndreLesere.Location = new Point(244, 35);
            BTN_EndreLesere.Name = "BTN_EndreLesere";
            BTN_EndreLesere.Size = new Size(138, 29);
            BTN_EndreLesere.TabIndex = 2;
            BTN_EndreLesere.Text = "Endre kortlesere";
            BTN_EndreLesere.UseVisualStyleBackColor = false;
            BTN_EndreLesere.Click += BTN_EndreLesere_Click;
            // 
            // BTN_VisLesere
            // 
            BTN_VisLesere.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisLesere.FlatAppearance.BorderSize = 0;
            BTN_VisLesere.FlatStyle = FlatStyle.Flat;
            BTN_VisLesere.Location = new Point(401, 35);
            BTN_VisLesere.Name = "BTN_VisLesere";
            BTN_VisLesere.Size = new Size(125, 29);
            BTN_VisLesere.TabIndex = 3;
            BTN_VisLesere.Text = "Vis kortlesere";
            BTN_VisLesere.UseVisualStyleBackColor = false;
            BTN_VisLesere.Click += BTN_VisLesere_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(50, 151);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(797, 336);
            dataGridView1.TabIndex = 4;
            dataGridView1.Visible = false;
            // 
            // BTN_alle
            // 
            BTN_alle.BackColor = SystemColors.GradientActiveCaption;
            BTN_alle.Location = new Point(50, 81);
            BTN_alle.Name = "BTN_alle";
            BTN_alle.Size = new Size(125, 29);
            BTN_alle.TabIndex = 5;
            BTN_alle.Text = "Vis alle";
            BTN_alle.UseVisualStyleBackColor = false;
            BTN_alle.Visible = false;
            BTN_alle.Click += BTN_alle_Click;
            // 
            // BTN_seksjon
            // 
            BTN_seksjon.BackColor = SystemColors.GradientActiveCaption;
            BTN_seksjon.Location = new Point(50, 116);
            BTN_seksjon.Name = "BTN_seksjon";
            BTN_seksjon.Size = new Size(125, 29);
            BTN_seksjon.TabIndex = 6;
            BTN_seksjon.Text = "Vis pr seksjon";
            BTN_seksjon.UseVisualStyleBackColor = false;
            BTN_seksjon.Visible = false;
            BTN_seksjon.Click += BTN_seksjon_Click;
            // 
            // TB_SeksjonVis
            // 
            TB_SeksjonVis.Location = new Point(182, 117);
            TB_SeksjonVis.Name = "TB_SeksjonVis";
            TB_SeksjonVis.Size = new Size(75, 27);
            TB_SeksjonVis.TabIndex = 7;
            TB_SeksjonVis.Visible = false;
            // 
            // TB_LeserID
            // 
            TB_LeserID.Location = new Point(50, 116);
            TB_LeserID.Name = "TB_LeserID";
            TB_LeserID.Size = new Size(101, 27);
            TB_LeserID.TabIndex = 8;
            TB_LeserID.Visible = false;
            // 
            // TB_seksjon
            // 
            TB_seksjon.Location = new Point(182, 116);
            TB_seksjon.Name = "TB_seksjon";
            TB_seksjon.Size = new Size(101, 27);
            TB_seksjon.TabIndex = 9;
            TB_seksjon.Visible = false;
            // 
            // BTN_LeggTilNy
            // 
            BTN_LeggTilNy.BackColor = SystemColors.GradientActiveCaption;
            BTN_LeggTilNy.FlatAppearance.BorderSize = 0;
            BTN_LeggTilNy.FlatStyle = FlatStyle.Flat;
            BTN_LeggTilNy.Location = new Point(302, 116);
            BTN_LeggTilNy.Name = "BTN_LeggTilNy";
            BTN_LeggTilNy.Size = new Size(92, 29);
            BTN_LeggTilNy.TabIndex = 10;
            BTN_LeggTilNy.Text = "Legg til";
            BTN_LeggTilNy.UseVisualStyleBackColor = false;
            BTN_LeggTilNy.Visible = false;
            BTN_LeggTilNy.Click += BTN_LeggTilNy_Click;
            // 
            // lbl_ID
            // 
            lbl_ID.AutoSize = true;
            lbl_ID.Location = new Point(50, 93);
            lbl_ID.Name = "lbl_ID";
            lbl_ID.Size = new Size(89, 20);
            lbl_ID.TabIndex = 11;
            lbl_ID.Text = "Kortleser-ID";
            lbl_ID.Visible = false;
            // 
            // lbl_seksjon
            // 
            lbl_seksjon.AutoSize = true;
            lbl_seksjon.Location = new Point(182, 93);
            lbl_seksjon.Name = "lbl_seksjon";
            lbl_seksjon.Size = new Size(59, 20);
            lbl_seksjon.TabIndex = 12;
            lbl_seksjon.Text = "Seksjon";
            lbl_seksjon.Visible = false;
            // 
            // BTN_endre
            // 
            BTN_endre.BackColor = SystemColors.GradientActiveCaption;
            BTN_endre.Location = new Point(302, 116);
            BTN_endre.Name = "BTN_endre";
            BTN_endre.Size = new Size(92, 29);
            BTN_endre.TabIndex = 13;
            BTN_endre.Text = "Endre";
            BTN_endre.UseVisualStyleBackColor = false;
            BTN_endre.Visible = false;
            BTN_endre.Click += BTN_endre_Click;
            // 
            // MenyKortlesere
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 505);
            Controls.Add(BTN_endre);
            Controls.Add(lbl_seksjon);
            Controls.Add(lbl_ID);
            Controls.Add(BTN_LeggTilNy);
            Controls.Add(TB_seksjon);
            Controls.Add(TB_LeserID);
            Controls.Add(TB_SeksjonVis);
            Controls.Add(BTN_seksjon);
            Controls.Add(BTN_alle);
            Controls.Add(dataGridView1);
            Controls.Add(BTN_VisLesere);
            Controls.Add(BTN_EndreLesere);
            Controls.Add(BTN_Nyelesere);
            Name = "MenyKortlesere";
            Text = "Kortlesere";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_Nyelesere;
        private Button BTN_EndreLesere;
        private Button BTN_VisLesere;
        private DataGridView dataGridView1;
        private Button BTN_alle;
        private Button BTN_seksjon;
        private TextBox TB_SeksjonVis;
        private TextBox TB_LeserID;
        private TextBox TB_seksjon;
        private Button BTN_LeggTilNy;
        private Label lbl_ID;
        private Label lbl_seksjon;
        private Button BTN_endre;
    }
}