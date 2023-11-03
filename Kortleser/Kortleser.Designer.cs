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
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // TB_Mottak
            // 
            TB_Mottak.Location = new Point(217, 75);
            TB_Mottak.Name = "TB_Mottak";
            TB_Mottak.ReadOnly = true;
            TB_Mottak.Size = new Size(141, 27);
            TB_Mottak.TabIndex = 37;
            // 
            // BTN0
            // 
            BTN0.Location = new Point(74, 228);
            BTN0.Name = "BTN0";
            BTN0.Size = new Size(23, 25);
            BTN0.TabIndex = 36;
            BTN0.Text = "0";
            BTN0.UseVisualStyleBackColor = true;
            BTN0.Click += BTN0_Click;
            // 
            // BTN9
            // 
            BTN9.Location = new Point(101, 200);
            BTN9.Name = "BTN9";
            BTN9.Size = new Size(23, 25);
            BTN9.TabIndex = 35;
            BTN9.Text = "9";
            BTN9.UseVisualStyleBackColor = true;
            BTN9.Click += BTN9_Click;
            // 
            // BTN8
            // 
            BTN8.Location = new Point(74, 200);
            BTN8.Name = "BTN8";
            BTN8.Size = new Size(23, 25);
            BTN8.TabIndex = 34;
            BTN8.Text = "8";
            BTN8.UseVisualStyleBackColor = true;
            BTN8.Click += BTN8_Click;
            // 
            // BTN7
            // 
            BTN7.Location = new Point(47, 200);
            BTN7.Name = "BTN7";
            BTN7.Size = new Size(23, 25);
            BTN7.TabIndex = 33;
            BTN7.Text = "7";
            BTN7.UseVisualStyleBackColor = true;
            BTN7.Click += BTN7_Click;
            // 
            // BTN6
            // 
            BTN6.Location = new Point(101, 171);
            BTN6.Name = "BTN6";
            BTN6.Size = new Size(23, 25);
            BTN6.TabIndex = 32;
            BTN6.Text = "6";
            BTN6.UseVisualStyleBackColor = true;
            BTN6.Click += BTN6_Click;
            // 
            // BTN5
            // 
            BTN5.Location = new Point(74, 171);
            BTN5.Name = "BTN5";
            BTN5.Size = new Size(23, 25);
            BTN5.TabIndex = 31;
            BTN5.Text = "5";
            BTN5.UseVisualStyleBackColor = true;
            BTN5.Click += BTN5_Click;
            // 
            // BTN4
            // 
            BTN4.Location = new Point(47, 171);
            BTN4.Name = "BTN4";
            BTN4.Size = new Size(23, 25);
            BTN4.TabIndex = 30;
            BTN4.Text = "4";
            BTN4.UseVisualStyleBackColor = true;
            BTN4.Click += BTN4_Click;
            // 
            // BTN3
            // 
            BTN3.Location = new Point(101, 142);
            BTN3.Name = "BTN3";
            BTN3.Size = new Size(23, 25);
            BTN3.TabIndex = 29;
            BTN3.Text = "3";
            BTN3.UseVisualStyleBackColor = true;
            BTN3.Click += BTN3_Click;
            // 
            // BTN2
            // 
            BTN2.Location = new Point(74, 142);
            BTN2.Name = "BTN2";
            BTN2.Size = new Size(23, 25);
            BTN2.TabIndex = 28;
            BTN2.Text = "2";
            BTN2.UseVisualStyleBackColor = true;
            BTN2.Click += BTN2_Click;
            // 
            // BTN1
            // 
            BTN1.Location = new Point(47, 142);
            BTN1.Name = "BTN1";
            BTN1.Size = new Size(23, 25);
            BTN1.TabIndex = 27;
            BTN1.Text = "1";
            BTN1.UseVisualStyleBackColor = true;
            BTN1.Click += BTN1_Click;
            // 
            // BTN_LesKort
            // 
            BTN_LesKort.Location = new Point(47, 74);
            BTN_LesKort.Name = "BTN_LesKort";
            BTN_LesKort.Size = new Size(77, 29);
            BTN_LesKort.TabIndex = 38;
            BTN_LesKort.Text = "Les kort";
            BTN_LesKort.UseVisualStyleBackColor = true;
            BTN_LesKort.Click += BTN_LesKort_Click;
            // 
            // TB_KortInput
            // 
            TB_KortInput.Location = new Point(47, 109);
            TB_KortInput.Name = "TB_KortInput";
            TB_KortInput.Size = new Size(77, 27);
            TB_KortInput.TabIndex = 40;
            TB_KortInput.Visible = false;
            TB_KortInput.KeyPress += TB_KortInput_KeyPress;
            // 
            // UgyldigLabel
            // 
            UgyldigLabel.AutoSize = true;
            UgyldigLabel.BackColor = SystemColors.ControlText;
            UgyldigLabel.ForeColor = SystemColors.ButtonHighlight;
            UgyldigLabel.Location = new Point(38, 16);
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
            // listBox1
            // 
            listBox1.BackColor = SystemColors.InfoText;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 20;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(158, 264);
            listBox1.TabIndex = 41;
            // 
            // Kortleser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 290);
            Controls.Add(TB_KortInput);
            Controls.Add(UgyldigLabel);
            Controls.Add(BTN_LesKort);
            Controls.Add(TB_Mottak);
            Controls.Add(BTN0);
            Controls.Add(BTN9);
            Controls.Add(BTN8);
            Controls.Add(BTN7);
            Controls.Add(BTN6);
            Controls.Add(BTN5);
            Controls.Add(BTN4);
            Controls.Add(BTN3);
            Controls.Add(BTN2);
            Controls.Add(BTN1);
            Controls.Add(listBox1);
            Name = "Kortleser";
            Text = "Kortleser";
            Load += Kortleser_Load;
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
        private ListBox listBox1;
    }
}