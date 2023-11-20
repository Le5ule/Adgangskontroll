namespace Adgangskontroll_Sentral
{
    partial class Sentral
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PanelMeny = new Panel();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            iBTN_Brukere = new FontAwesome.Sharp.IconButton();
            iBTN_Kortlesere = new FontAwesome.Sharp.IconButton();
            panelTopp = new Panel();
            panelBar = new Panel();
            BTN_LukkMenyVindu = new FontAwesome.Sharp.IconButton();
            lbl_Tittel = new Label();
            PanelForms = new Panel();
            PanelMeny.SuspendLayout();
            panelBar.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMeny
            // 
            PanelMeny.BackColor = SystemColors.GradientInactiveCaption;
            PanelMeny.Controls.Add(iconButton4);
            PanelMeny.Controls.Add(iconButton3);
            PanelMeny.Controls.Add(iBTN_Brukere);
            PanelMeny.Controls.Add(iBTN_Kortlesere);
            PanelMeny.Controls.Add(panelTopp);
            PanelMeny.Dock = DockStyle.Left;
            PanelMeny.Location = new Point(0, 0);
            PanelMeny.Name = "PanelMeny";
            PanelMeny.Size = new Size(195, 710);
            PanelMeny.TabIndex = 16;
            // 
            // iconButton4
            // 
            iconButton4.BackColor = SystemColors.GradientInactiveCaption;
            iconButton4.Dock = DockStyle.Top;
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.Gears;
            iconButton4.IconColor = Color.Black;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton4.Location = new Point(0, 280);
            iconButton4.Name = "iconButton4";
            iconButton4.Padding = new Padding(10, 0, 0, 0);
            iconButton4.Size = new Size(195, 60);
            iconButton4.TabIndex = 22;
            iconButton4.Text = "Innstillinger";
            iconButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton4.UseVisualStyleBackColor = false;
            iconButton4.Click += iBTN_Innstillinger_Click;
            // 
            // iconButton3
            // 
            iconButton3.BackColor = SystemColors.GradientInactiveCaption;
            iconButton3.Dock = DockStyle.Top;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            iconButton3.IconColor = Color.Black;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(0, 220);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(10, 0, 0, 0);
            iconButton3.Size = new Size(195, 60);
            iconButton3.TabIndex = 21;
            iconButton3.Text = "Logg";
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = false;
            iconButton3.Click += iBTN_Logg_Click;
            // 
            // iBTN_Brukere
            // 
            iBTN_Brukere.BackColor = SystemColors.GradientInactiveCaption;
            iBTN_Brukere.Dock = DockStyle.Top;
            iBTN_Brukere.FlatAppearance.BorderSize = 0;
            iBTN_Brukere.FlatStyle = FlatStyle.Flat;
            iBTN_Brukere.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            iBTN_Brukere.IconColor = Color.Black;
            iBTN_Brukere.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iBTN_Brukere.ImageAlign = ContentAlignment.MiddleLeft;
            iBTN_Brukere.Location = new Point(0, 160);
            iBTN_Brukere.Name = "iBTN_Brukere";
            iBTN_Brukere.Padding = new Padding(10, 0, 0, 0);
            iBTN_Brukere.Size = new Size(195, 60);
            iBTN_Brukere.TabIndex = 20;
            iBTN_Brukere.Text = "Brukere";
            iBTN_Brukere.TextImageRelation = TextImageRelation.ImageBeforeText;
            iBTN_Brukere.UseVisualStyleBackColor = false;
            iBTN_Brukere.Click += iBTN_Brukere_Click;
            // 
            // iBTN_Kortlesere
            // 
            iBTN_Kortlesere.BackColor = SystemColors.GradientInactiveCaption;
            iBTN_Kortlesere.Dock = DockStyle.Top;
            iBTN_Kortlesere.FlatAppearance.BorderSize = 0;
            iBTN_Kortlesere.FlatStyle = FlatStyle.Flat;
            iBTN_Kortlesere.IconChar = FontAwesome.Sharp.IconChar.Keyboard;
            iBTN_Kortlesere.IconColor = Color.Black;
            iBTN_Kortlesere.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iBTN_Kortlesere.ImageAlign = ContentAlignment.MiddleLeft;
            iBTN_Kortlesere.Location = new Point(0, 100);
            iBTN_Kortlesere.Name = "iBTN_Kortlesere";
            iBTN_Kortlesere.Padding = new Padding(10, 0, 0, 0);
            iBTN_Kortlesere.Size = new Size(195, 60);
            iBTN_Kortlesere.TabIndex = 19;
            iBTN_Kortlesere.Text = "Kortlesere";
            iBTN_Kortlesere.TextImageRelation = TextImageRelation.ImageBeforeText;
            iBTN_Kortlesere.UseVisualStyleBackColor = false;
            iBTN_Kortlesere.Click += iBTN_Kortlesere_Click;
            // 
            // panelTopp
            // 
            panelTopp.BackColor = SystemColors.ActiveCaption;
            panelTopp.Dock = DockStyle.Top;
            panelTopp.Location = new Point(0, 0);
            panelTopp.Name = "panelTopp";
            panelTopp.Size = new Size(195, 100);
            panelTopp.TabIndex = 18;
            // 
            // panelBar
            // 
            panelBar.BackColor = SystemColors.ActiveCaption;
            panelBar.Controls.Add(BTN_LukkMenyVindu);
            panelBar.Controls.Add(lbl_Tittel);
            panelBar.Dock = DockStyle.Top;
            panelBar.Location = new Point(195, 0);
            panelBar.Name = "panelBar";
            panelBar.Size = new Size(876, 100);
            panelBar.TabIndex = 18;
            // 
            // BTN_LukkMenyVindu
            // 
            BTN_LukkMenyVindu.BackColor = SystemColors.ActiveCaption;
            BTN_LukkMenyVindu.Dock = DockStyle.Left;
            BTN_LukkMenyVindu.FlatAppearance.BorderSize = 0;
            BTN_LukkMenyVindu.FlatStyle = FlatStyle.Flat;
            BTN_LukkMenyVindu.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            BTN_LukkMenyVindu.IconColor = Color.Black;
            BTN_LukkMenyVindu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BTN_LukkMenyVindu.Location = new Point(0, 0);
            BTN_LukkMenyVindu.Name = "BTN_LukkMenyVindu";
            BTN_LukkMenyVindu.Size = new Size(94, 100);
            BTN_LukkMenyVindu.TabIndex = 1;
            BTN_LukkMenyVindu.UseVisualStyleBackColor = false;
            BTN_LukkMenyVindu.Visible = false;
            BTN_LukkMenyVindu.Click += BTN_LukkMenyVindu_Click;
            // 
            // lbl_Tittel
            // 
            lbl_Tittel.AutoSize = true;
            lbl_Tittel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Tittel.Location = new Point(154, 33);
            lbl_Tittel.Name = "lbl_Tittel";
            lbl_Tittel.Size = new Size(233, 37);
            lbl_Tittel.TabIndex = 0;
            lbl_Tittel.Text = "Adgangskontroll";
            // 
            // PanelForms
            // 
            PanelForms.Dock = DockStyle.Fill;
            PanelForms.Location = new Point(195, 100);
            PanelForms.Name = "PanelForms";
            PanelForms.Size = new Size(876, 610);
            PanelForms.TabIndex = 14;
            // 
            // Sentral
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 710);
            Controls.Add(PanelForms);
            Controls.Add(panelBar);
            Controls.Add(PanelMeny);
            Name = "Sentral";
            Text = "Sentral";
            Load += Sentral_Load;
            PanelMeny.ResumeLayout(false);
            panelBar.ResumeLayout(false);
            panelBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label7;
        private Panel PanelMeny;
        private Panel panelTopp;
        private Panel panelBar;
        private Panel PanelForms;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iBTN_Brukere;
        private FontAwesome.Sharp.IconButton iBTN_Kortlesere;
        private Label lbl_Tittel;
        private FontAwesome.Sharp.IconButton BTN_LukkMenyVindu;
    }
}