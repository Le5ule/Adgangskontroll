namespace Adgangskontroll_Kortleser
{
    partial class Kortleser
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
            TB_Mottak = new TextBox();
            BTN0 = new Button();
            BTN9 = new Button();
            BTN8 = new Button();
            BTN7 = new Button();
            BTN6 = new Button();
            BTN5 = new Button();
            BTN4 = new Button();
            BTN3 = new Button();
            BTN2 = new Button();
            BTN1 = new Button();
            BTN_LesKort = new Button();
            TB_KortInput = new TextBox();
            UgyldigLabel = new Label();
            BW_SendKvittering = new System.ComponentModel.BackgroundWorker();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TB_Mottak
            // 
            TB_Mottak.Location = new Point(216, 74);
            TB_Mottak.Name = "TB_Mottak";
            TB_Mottak.Size = new Size(141, 27);
            TB_Mottak.TabIndex = 37;
            // 
            // BTN0
            // 
            BTN0.Location = new Point(61, 216);
            BTN0.Name = "BTN0";
            BTN0.Size = new Size(23, 25);
            BTN0.TabIndex = 36;
            BTN0.Text = "0";
            BTN0.UseVisualStyleBackColor = true;
            BTN0.Click += BTN0_Click;
            // 
            // BTN9
            // 
            BTN9.Location = new Point(88, 188);
            BTN9.Name = "BTN9";
            BTN9.Size = new Size(23, 25);
            BTN9.TabIndex = 35;
            BTN9.Text = "9";
            BTN9.UseVisualStyleBackColor = true;
            BTN9.Click += BTN9_Click;
            // 
            // BTN8
            // 
            BTN8.Location = new Point(61, 188);
            BTN8.Name = "BTN8";
            BTN8.Size = new Size(23, 25);
            BTN8.TabIndex = 34;
            BTN8.Text = "8";
            BTN8.UseVisualStyleBackColor = true;
            BTN8.Click += BTN8_Click;
            // 
            // BTN7
            // 
            BTN7.Location = new Point(34, 188);
            BTN7.Name = "BTN7";
            BTN7.Size = new Size(23, 25);
            BTN7.TabIndex = 33;
            BTN7.Text = "7";
            BTN7.UseVisualStyleBackColor = true;
            BTN7.Click += BTN7_Click;
            // 
            // BTN6
            // 
            BTN6.Location = new Point(88, 159);
            BTN6.Name = "BTN6";
            BTN6.Size = new Size(23, 25);
            BTN6.TabIndex = 32;
            BTN6.Text = "6";
            BTN6.UseVisualStyleBackColor = true;
            BTN6.Click += BTN6_Click;
            // 
            // BTN5
            // 
            BTN5.Location = new Point(61, 159);
            BTN5.Name = "BTN5";
            BTN5.Size = new Size(23, 25);
            BTN5.TabIndex = 31;
            BTN5.Text = "5";
            BTN5.UseVisualStyleBackColor = true;
            BTN5.Click += BTN5_Click;
            // 
            // BTN4
            // 
            BTN4.Location = new Point(34, 159);
            BTN4.Name = "BTN4";
            BTN4.Size = new Size(23, 25);
            BTN4.TabIndex = 30;
            BTN4.Text = "4";
            BTN4.UseVisualStyleBackColor = true;
            BTN4.Click += BTN4_Click;
            // 
            // BTN3
            // 
            BTN3.Location = new Point(88, 130);
            BTN3.Name = "BTN3";
            BTN3.Size = new Size(23, 25);
            BTN3.TabIndex = 29;
            BTN3.Text = "3";
            BTN3.UseVisualStyleBackColor = true;
            BTN3.Click += BTN3_Click;
            // 
            // BTN2
            // 
            BTN2.Location = new Point(61, 130);
            BTN2.Name = "BTN2";
            BTN2.Size = new Size(23, 25);
            BTN2.TabIndex = 28;
            BTN2.Text = "2";
            BTN2.UseVisualStyleBackColor = true;
            BTN2.Click += BTN2_Click;
            // 
            // BTN1
            // 
            BTN1.Location = new Point(34, 130);
            BTN1.Name = "BTN1";
            BTN1.Size = new Size(23, 25);
            BTN1.TabIndex = 27;
            BTN1.Text = "1";
            BTN1.UseVisualStyleBackColor = true;
            BTN1.Click += BTN1_Click;
            // 
            // BTN_LesKort
            // 
            BTN_LesKort.Location = new Point(34, 61);
            BTN_LesKort.Name = "BTN_LesKort";
            BTN_LesKort.Size = new Size(77, 29);
            BTN_LesKort.TabIndex = 38;
            BTN_LesKort.Text = "Les kort";
            BTN_LesKort.UseVisualStyleBackColor = true;
            BTN_LesKort.Click += BTN_LesKort_Click;
            // 
            // TB_KortInput
            // 
            TB_KortInput.Location = new Point(34, 97);
            TB_KortInput.Name = "TB_KortInput";
            TB_KortInput.Size = new Size(77, 27);
            TB_KortInput.TabIndex = 40;
            TB_KortInput.Visible = false;
            TB_KortInput.KeyPress += TB_KortInput_KeyPress;
            // 
            // UgyldigLabel
            // 
            UgyldigLabel.AutoSize = true;
            UgyldigLabel.BackColor = Color.Transparent;
            UgyldigLabel.ForeColor = SystemColors.ActiveCaptionText;
            UgyldigLabel.Location = new Point(23, 14);
            UgyldigLabel.Name = "UgyldigLabel";
            UgyldigLabel.Size = new Size(102, 40);
            UgyldigLabel.TabIndex = 39;
            UgyldigLabel.Text = "Ugyldig input,\r\nprøv igjen";
            UgyldigLabel.Visible = false;
            // 
            // BW_SendKvittering
            // 
            BW_SendKvittering.DoWork += BW_SendKvittering_DoWork;
            BW_SendKvittering.RunWorkerCompleted += BW_SendKvittering_RunWorkerCompleted;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.WindowFrame;
            panel1.Controls.Add(TB_KortInput);
            panel1.Controls.Add(UgyldigLabel);
            panel1.Controls.Add(BTN_LesKort);
            panel1.Controls.Add(BTN0);
            panel1.Controls.Add(BTN9);
            panel1.Controls.Add(BTN8);
            panel1.Controls.Add(BTN7);
            panel1.Controls.Add(BTN6);
            panel1.Controls.Add(BTN5);
            panel1.Controls.Add(BTN4);
            panel1.Controls.Add(BTN3);
            panel1.Controls.Add(BTN2);
            panel1.Controls.Add(BTN1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(153, 265);
            panel1.TabIndex = 41;
            // 
            // Kortleser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 291);
            Controls.Add(panel1);
            Controls.Add(TB_Mottak);
            Name = "Kortleser";
            Text = "Kortleser";
            Load += Kortleser_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_Mottak;
        private Button BTN0;
        private Button BTN9;
        private Button BTN8;
        private Button BTN7;
        private Button BTN6;
        private Button BTN5;
        private Button BTN4;
        private Button BTN3;
        private Button BTN2;
        private Button BTN1;
        private Button BTN_LesKort;
        private TextBox TB_KortInput;
        private Label UgyldigLabel;
        private System.ComponentModel.BackgroundWorker BW_SendKvittering;
        private Panel panel1;
    }
}