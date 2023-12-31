﻿namespace Sentral
{
    partial class MenyBrukere
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
            lbl_ENavn = new Label();
            lbl_FNavn = new Label();
            dataGridView = new DataGridView();
            BTN_VisBrukere = new Button();
            TB_Enavn = new TextBox();
            TB_Fnavn = new TextBox();
            BTN_LeggTil = new Button();
            BTN_Ny = new Button();
            BTN_EndreBru = new Button();
            lbl_ID = new Label();
            TB_ID = new TextBox();
            BTN_Endre = new Button();
            TB_Seksjon = new TextBox();
            lbl_Seksjon = new Label();
            BTN_SlettBrukere = new Button();
            BTN_Slett = new Button();
            lbl_ID_2 = new Label();
            TB_ID_2 = new TextBox();
            lbl_datoformat = new Label();
            lbl_til = new Label();
            lbl_fra = new Label();
            TB_TilDato = new TextBox();
            TB_FraDato = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // lbl_ENavn
            // 
            lbl_ENavn.AutoSize = true;
            lbl_ENavn.Location = new Point(192, 95);
            lbl_ENavn.Name = "lbl_ENavn";
            lbl_ENavn.Size = new Size(74, 20);
            lbl_ENavn.TabIndex = 17;
            lbl_ENavn.Text = "Etternavn:";
            lbl_ENavn.Visible = false;
            // 
            // lbl_FNavn
            // 
            lbl_FNavn.AutoSize = true;
            lbl_FNavn.Location = new Point(51, 95);
            lbl_FNavn.Name = "lbl_FNavn";
            lbl_FNavn.Size = new Size(64, 20);
            lbl_FNavn.TabIndex = 16;
            lbl_FNavn.Text = "Fornavn:";
            lbl_FNavn.Visible = false;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(50, 82);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(797, 336);
            dataGridView.TabIndex = 15;
            dataGridView.Visible = false;
            // 
            // BTN_VisBrukere
            // 
            BTN_VisBrukere.BackColor = SystemColors.GradientActiveCaption;
            BTN_VisBrukere.FlatAppearance.BorderSize = 0;
            BTN_VisBrukere.FlatStyle = FlatStyle.Flat;
            BTN_VisBrukere.Location = new Point(547, 35);
            BTN_VisBrukere.Name = "BTN_VisBrukere";
            BTN_VisBrukere.Size = new Size(94, 29);
            BTN_VisBrukere.TabIndex = 14;
            BTN_VisBrukere.Text = "Vis brukere";
            BTN_VisBrukere.UseVisualStyleBackColor = false;
            BTN_VisBrukere.Click += BTN_VisBrukere_Click;
            // 
            // TB_Enavn
            // 
            TB_Enavn.Location = new Point(192, 122);
            TB_Enavn.Name = "TB_Enavn";
            TB_Enavn.Size = new Size(125, 27);
            TB_Enavn.TabIndex = 13;
            TB_Enavn.Visible = false;
            // 
            // TB_Fnavn
            // 
            TB_Fnavn.Location = new Point(51, 122);
            TB_Fnavn.Name = "TB_Fnavn";
            TB_Fnavn.Size = new Size(125, 27);
            TB_Fnavn.TabIndex = 11;
            TB_Fnavn.Visible = false;
            // 
            // BTN_LeggTil
            // 
            BTN_LeggTil.BackColor = SystemColors.GradientActiveCaption;
            BTN_LeggTil.FlatAppearance.BorderSize = 0;
            BTN_LeggTil.FlatStyle = FlatStyle.Flat;
            BTN_LeggTil.Location = new Point(742, 123);
            BTN_LeggTil.Name = "BTN_LeggTil";
            BTN_LeggTil.Size = new Size(94, 29);
            BTN_LeggTil.TabIndex = 12;
            BTN_LeggTil.Text = "Legg til";
            BTN_LeggTil.UseVisualStyleBackColor = false;
            BTN_LeggTil.Visible = false;
            BTN_LeggTil.Click += BTN_LeggTil_Click;
            // 
            // BTN_Ny
            // 
            BTN_Ny.BackColor = SystemColors.GradientActiveCaption;
            BTN_Ny.FlatAppearance.BorderSize = 0;
            BTN_Ny.FlatStyle = FlatStyle.Flat;
            BTN_Ny.Location = new Point(50, 35);
            BTN_Ny.Name = "BTN_Ny";
            BTN_Ny.Size = new Size(150, 29);
            BTN_Ny.TabIndex = 18;
            BTN_Ny.Text = "Legg til nye brukere";
            BTN_Ny.UseVisualStyleBackColor = false;
            BTN_Ny.Click += BTN_Ny_Click;
            // 
            // BTN_EndreBru
            // 
            BTN_EndreBru.BackColor = SystemColors.GradientActiveCaption;
            BTN_EndreBru.FlatAppearance.BorderSize = 0;
            BTN_EndreBru.FlatStyle = FlatStyle.Flat;
            BTN_EndreBru.Location = new Point(229, 35);
            BTN_EndreBru.Name = "BTN_EndreBru";
            BTN_EndreBru.Size = new Size(150, 29);
            BTN_EndreBru.TabIndex = 19;
            BTN_EndreBru.Text = "Endre brukere";
            BTN_EndreBru.UseVisualStyleBackColor = false;
            BTN_EndreBru.Click += BTN_EndreBrukere_Click;
            // 
            // lbl_ID
            // 
            lbl_ID.AutoSize = true;
            lbl_ID.Location = new Point(328, 95);
            lbl_ID.Name = "lbl_ID";
            lbl_ID.Size = new Size(27, 20);
            lbl_ID.TabIndex = 28;
            lbl_ID.Text = "ID:";
            lbl_ID.Visible = false;
            // 
            // TB_ID
            // 
            TB_ID.Location = new Point(328, 122);
            TB_ID.Name = "TB_ID";
            TB_ID.Size = new Size(42, 27);
            TB_ID.TabIndex = 27;
            TB_ID.Visible = false;
            // 
            // BTN_Endre
            // 
            BTN_Endre.BackColor = SystemColors.GradientActiveCaption;
            BTN_Endre.FlatAppearance.BorderSize = 0;
            BTN_Endre.FlatStyle = FlatStyle.Flat;
            BTN_Endre.Location = new Point(742, 123);
            BTN_Endre.Name = "BTN_Endre";
            BTN_Endre.Size = new Size(94, 29);
            BTN_Endre.TabIndex = 29;
            BTN_Endre.Text = "Endre";
            BTN_Endre.UseVisualStyleBackColor = false;
            BTN_Endre.Visible = false;
            BTN_Endre.Click += BTN_Endre_Click;
            // 
            // TB_Seksjon
            // 
            TB_Seksjon.Location = new Point(376, 122);
            TB_Seksjon.Name = "TB_Seksjon";
            TB_Seksjon.Size = new Size(86, 27);
            TB_Seksjon.TabIndex = 30;
            TB_Seksjon.Visible = false;
            // 
            // lbl_Seksjon
            // 
            lbl_Seksjon.AutoSize = true;
            lbl_Seksjon.Location = new Point(376, 95);
            lbl_Seksjon.Name = "lbl_Seksjon";
            lbl_Seksjon.Size = new Size(62, 20);
            lbl_Seksjon.TabIndex = 31;
            lbl_Seksjon.Text = "Seksjon:";
            lbl_Seksjon.Visible = false;
            // 
            // BTN_SlettBrukere
            // 
            BTN_SlettBrukere.BackColor = SystemColors.GradientActiveCaption;
            BTN_SlettBrukere.FlatAppearance.BorderSize = 0;
            BTN_SlettBrukere.FlatStyle = FlatStyle.Flat;
            BTN_SlettBrukere.Location = new Point(407, 35);
            BTN_SlettBrukere.Name = "BTN_SlettBrukere";
            BTN_SlettBrukere.Size = new Size(113, 29);
            BTN_SlettBrukere.TabIndex = 32;
            BTN_SlettBrukere.Text = "Slett brukere";
            BTN_SlettBrukere.UseVisualStyleBackColor = false;
            BTN_SlettBrukere.Click += BTN_SlettBrukere_Click;
            // 
            // BTN_Slett
            // 
            BTN_Slett.BackColor = SystemColors.GradientActiveCaption;
            BTN_Slett.FlatAppearance.BorderSize = 0;
            BTN_Slett.FlatStyle = FlatStyle.Flat;
            BTN_Slett.Location = new Point(134, 120);
            BTN_Slett.Name = "BTN_Slett";
            BTN_Slett.Size = new Size(66, 29);
            BTN_Slett.TabIndex = 35;
            BTN_Slett.Text = "Slett";
            BTN_Slett.UseVisualStyleBackColor = false;
            BTN_Slett.Visible = false;
            BTN_Slett.Click += BTN_Slett_Click;
            // 
            // lbl_ID_2
            // 
            lbl_ID_2.AutoSize = true;
            lbl_ID_2.Location = new Point(51, 95);
            lbl_ID_2.Name = "lbl_ID_2";
            lbl_ID_2.Size = new Size(27, 20);
            lbl_ID_2.TabIndex = 34;
            lbl_ID_2.Text = "ID:";
            lbl_ID_2.Visible = false;
            // 
            // TB_ID_2
            // 
            TB_ID_2.Location = new Point(51, 122);
            TB_ID_2.Name = "TB_ID_2";
            TB_ID_2.Size = new Size(64, 27);
            TB_ID_2.TabIndex = 33;
            TB_ID_2.Visible = false;
            // 
            // lbl_datoformat
            // 
            lbl_datoformat.AutoSize = true;
            lbl_datoformat.Location = new Point(468, 67);
            lbl_datoformat.Name = "lbl_datoformat";
            lbl_datoformat.Size = new Size(194, 20);
            lbl_datoformat.TabIndex = 40;
            lbl_datoformat.Text = "Datoformat: ÅÅÅÅ-MM-DD";
            lbl_datoformat.Visible = false;
            // 
            // lbl_til
            // 
            lbl_til.AutoSize = true;
            lbl_til.Location = new Point(587, 95);
            lbl_til.Name = "lbl_til";
            lbl_til.Size = new Size(72, 20);
            lbl_til.TabIndex = 39;
            lbl_til.Text = "Gyldig til:";
            lbl_til.Visible = false;
            // 
            // lbl_fra
            // 
            lbl_fra.AutoSize = true;
            lbl_fra.Location = new Point(468, 95);
            lbl_fra.Name = "lbl_fra";
            lbl_fra.Size = new Size(77, 20);
            lbl_fra.TabIndex = 38;
            lbl_fra.Text = "Gyldig fra:";
            lbl_fra.Visible = false;
            // 
            // TB_TilDato
            // 
            TB_TilDato.Location = new Point(587, 122);
            TB_TilDato.Name = "TB_TilDato";
            TB_TilDato.Size = new Size(113, 27);
            TB_TilDato.TabIndex = 37;
            TB_TilDato.Visible = false;
            // 
            // TB_FraDato
            // 
            TB_FraDato.Location = new Point(468, 122);
            TB_FraDato.Name = "TB_FraDato";
            TB_FraDato.Size = new Size(113, 27);
            TB_FraDato.TabIndex = 36;
            TB_FraDato.Visible = false;
            // 
            // MenyBrukere
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 475);
            Controls.Add(lbl_datoformat);
            Controls.Add(lbl_til);
            Controls.Add(lbl_fra);
            Controls.Add(TB_TilDato);
            Controls.Add(TB_FraDato);
            Controls.Add(BTN_Slett);
            Controls.Add(lbl_ID_2);
            Controls.Add(TB_ID_2);
            Controls.Add(BTN_SlettBrukere);
            Controls.Add(lbl_Seksjon);
            Controls.Add(TB_Seksjon);
            Controls.Add(BTN_Endre);
            Controls.Add(lbl_ID);
            Controls.Add(TB_ID);
            Controls.Add(BTN_EndreBru);
            Controls.Add(BTN_Ny);
            Controls.Add(lbl_ENavn);
            Controls.Add(lbl_FNavn);
            Controls.Add(BTN_VisBrukere);
            Controls.Add(TB_Enavn);
            Controls.Add(TB_Fnavn);
            Controls.Add(BTN_LeggTil);
            Controls.Add(dataGridView);
            Name = "MenyBrukere";
            Text = "Brukere";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_ENavn;
        private Label lbl_FNavn;
        private DataGridView dataGridView;
        private Button BTN_VisBrukere;
        private TextBox TB_Enavn;
        private TextBox TB_Fnavn;
        private Button BTN_LeggTil;
        private Button BTN_Ny;
        private Button BTN_EndreBru;
        private Label lbl_ID;
        private TextBox TB_ID;
        private Button BTN_Endre;
        private TextBox TB_Seksjon;
        private Label lbl_Seksjon;
        private Button BTN_SlettBrukere;
        private Button BTN_Slett;
        private Label lbl_ID_2;
        private TextBox TB_ID_2;
        private Label lbl_datoformat;
        private Label lbl_til;
        private Label lbl_fra;
        private TextBox TB_TilDato;
        private TextBox TB_FraDato;
    }
}