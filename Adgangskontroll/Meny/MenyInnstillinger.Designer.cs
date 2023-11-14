namespace Sentral
{
    partial class MenyInnstillinger
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
            BTN_Om = new Button();
            lbl_info = new Label();
            SuspendLayout();
            // 
            // BTN_Om
            // 
            BTN_Om.BackColor = SystemColors.GradientActiveCaption;
            BTN_Om.FlatAppearance.BorderSize = 0;
            BTN_Om.FlatStyle = FlatStyle.Flat;
            BTN_Om.ForeColor = SystemColors.ActiveCaptionText;
            BTN_Om.Location = new Point(50, 35);
            BTN_Om.Name = "BTN_Om";
            BTN_Om.Size = new Size(49, 29);
            BTN_Om.TabIndex = 0;
            BTN_Om.Text = "Om";
            BTN_Om.UseVisualStyleBackColor = false;
            BTN_Om.Click += BTN_Om_Click;
            // 
            // lbl_info
            // 
            lbl_info.AutoSize = true;
            lbl_info.Location = new Point(99, 67);
            lbl_info.Name = "lbl_info";
            lbl_info.Size = new Size(181, 180);
            lbl_info.TabIndex = 1;
            lbl_info.Text = "Adgangskontroll\r\nOffentlig versjon: 1.0.0\r\n\r\nForfattere:\r\nLeander Surén Levinsen\r\nEivind Grimstad\r\nAlexander Akhtar\r\nSteffen Nanthen Balthasar\r\nJakub Jan Narakiewicz";
            lbl_info.Visible = false;
            // 
            // MenyInnstillinger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_info);
            Controls.Add(BTN_Om);
            Name = "MenyInnstillinger";
            Text = "Innstillinger";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BTN_Om;
        private Label lbl_info;
    }
}