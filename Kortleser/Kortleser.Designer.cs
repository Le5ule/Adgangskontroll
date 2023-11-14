using System.Drawing;
using System.Windows.Forms;

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
            TB_MottakFraSentral = new TextBox();
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
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            bwSjekkForData = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TB_MottakFraSentral
            // 
            TB_MottakFraSentral.Location = new Point(174, 55);
            TB_MottakFraSentral.Margin = new Padding(3, 2, 3, 2);
            TB_MottakFraSentral.Name = "TB_MottakFraSentral";
            TB_MottakFraSentral.Size = new Size(222, 23);
            TB_MottakFraSentral.TabIndex = 37;
            // 
            // BTN0
            // 
            BTN0.Location = new Point(53, 162);
            BTN0.Margin = new Padding(3, 2, 3, 2);
            BTN0.Name = "BTN0";
            BTN0.Size = new Size(20, 19);
            BTN0.TabIndex = 36;
            BTN0.Text = "0";
            BTN0.UseVisualStyleBackColor = true;
            BTN0.Click += BTN0_Click;
            // 
            // BTN9
            // 
            BTN9.Location = new Point(77, 141);
            BTN9.Margin = new Padding(3, 2, 3, 2);
            BTN9.Name = "BTN9";
            BTN9.Size = new Size(20, 19);
            BTN9.TabIndex = 35;
            BTN9.Text = "9";
            BTN9.UseVisualStyleBackColor = true;
            BTN9.Click += BTN9_Click;
            // 
            // BTN8
            // 
            BTN8.Location = new Point(53, 141);
            BTN8.Margin = new Padding(3, 2, 3, 2);
            BTN8.Name = "BTN8";
            BTN8.Size = new Size(20, 19);
            BTN8.TabIndex = 34;
            BTN8.Text = "8";
            BTN8.UseVisualStyleBackColor = true;
            BTN8.Click += BTN8_Click;
            // 
            // BTN7
            // 
            BTN7.Location = new Point(30, 141);
            BTN7.Margin = new Padding(3, 2, 3, 2);
            BTN7.Name = "BTN7";
            BTN7.Size = new Size(20, 19);
            BTN7.TabIndex = 33;
            BTN7.Text = "7";
            BTN7.UseVisualStyleBackColor = true;
            BTN7.Click += BTN7_Click;
            // 
            // BTN6
            // 
            BTN6.Location = new Point(77, 119);
            BTN6.Margin = new Padding(3, 2, 3, 2);
            BTN6.Name = "BTN6";
            BTN6.Size = new Size(20, 19);
            BTN6.TabIndex = 32;
            BTN6.Text = "6";
            BTN6.UseVisualStyleBackColor = true;
            BTN6.Click += BTN6_Click;
            // 
            // BTN5
            // 
            BTN5.Location = new Point(53, 119);
            BTN5.Margin = new Padding(3, 2, 3, 2);
            BTN5.Name = "BTN5";
            BTN5.Size = new Size(20, 19);
            BTN5.TabIndex = 31;
            BTN5.Text = "5";
            BTN5.UseVisualStyleBackColor = true;
            BTN5.Click += BTN5_Click;
            // 
            // BTN4
            // 
            BTN4.Location = new Point(30, 119);
            BTN4.Margin = new Padding(3, 2, 3, 2);
            BTN4.Name = "BTN4";
            BTN4.Size = new Size(20, 19);
            BTN4.TabIndex = 30;
            BTN4.Text = "4";
            BTN4.UseVisualStyleBackColor = true;
            BTN4.Click += BTN4_Click;
            // 
            // BTN3
            // 
            BTN3.Location = new Point(77, 98);
            BTN3.Margin = new Padding(3, 2, 3, 2);
            BTN3.Name = "BTN3";
            BTN3.Size = new Size(20, 19);
            BTN3.TabIndex = 29;
            BTN3.Text = "3";
            BTN3.UseVisualStyleBackColor = true;
            BTN3.Click += BTN3_Click;
            // 
            // BTN2
            // 
            BTN2.Location = new Point(53, 98);
            BTN2.Margin = new Padding(3, 2, 3, 2);
            BTN2.Name = "BTN2";
            BTN2.Size = new Size(20, 19);
            BTN2.TabIndex = 28;
            BTN2.Text = "2";
            BTN2.UseVisualStyleBackColor = true;
            BTN2.Click += BTN2_Click;
            // 
            // BTN1
            // 
            BTN1.Location = new Point(30, 98);
            BTN1.Margin = new Padding(3, 2, 3, 2);
            BTN1.Name = "BTN1";
            BTN1.Size = new Size(20, 19);
            BTN1.TabIndex = 27;
            BTN1.Text = "1";
            BTN1.UseVisualStyleBackColor = true;
            BTN1.Click += BTN1_Click;
            // 
            // BTN_LesKort
            // 
            BTN_LesKort.Location = new Point(30, 46);
            BTN_LesKort.Margin = new Padding(3, 2, 3, 2);
            BTN_LesKort.Name = "BTN_LesKort";
            BTN_LesKort.Size = new Size(67, 22);
            BTN_LesKort.TabIndex = 38;
            BTN_LesKort.Text = "Les kort";
            BTN_LesKort.UseVisualStyleBackColor = true;
            BTN_LesKort.Click += BTN_LesKort_Click;
            // 
            // TB_KortInput
            // 
            TB_KortInput.Location = new Point(30, 73);
            TB_KortInput.Margin = new Padding(3, 2, 3, 2);
            TB_KortInput.Name = "TB_KortInput";
            TB_KortInput.Size = new Size(68, 23);
            TB_KortInput.TabIndex = 40;
            TB_KortInput.Visible = false;
            TB_KortInput.KeyPress += TB_KortInput_KeyPress;
            // 
            // UgyldigLabel
            // 
            UgyldigLabel.AutoSize = true;
            UgyldigLabel.BackColor = Color.Transparent;
            UgyldigLabel.ForeColor = SystemColors.ActiveCaptionText;
            UgyldigLabel.Location = new Point(20, 10);
            UgyldigLabel.Name = "UgyldigLabel";
            UgyldigLabel.Size = new Size(82, 30);
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
            panel1.Location = new Point(10, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(134, 199);
            panel1.TabIndex = 41;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 109);
            label1.Name = "label1";
            label1.Size = new Size(313, 60);
            label1.TabIndex = 42;
            label1.Text = "\"Dør åpen\"\r\nLabel skal vises når døren åpnes. Simulere virtuell dør elns.\r\nSammen med knapp som fungerer som håndtak.\r\nUtfordring: bryte opp her\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(174, 9);
            label2.Name = "label2";
            label2.Size = new Size(223, 45);
            label2.TabIndex = 43;
            label2.Text = "(debug)Her hentes data fra sentralen.\r\nIllustrerer bare at informasjon kan sendes\r\nfrem og tilbake";
            // 
            // button1
            // 
            button1.Location = new Point(174, 83);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 44;
            button1.Text = "Åpen/Lukk Dør";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // bwSjekkForData
            // 
            bwSjekkForData.DoWork += bwSjekkForData_DoWork_1;
            bwSjekkForData.RunWorkerCompleted += bwSjekkForData_RunWorkerCompleted_1;
            // 
            // Kortleser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 218);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(TB_MottakFraSentral);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Kortleser";
            Text = "Kortleser";
            Load += Kortleser_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_MottakFraSentral;
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
        private Label label1;
        private Label label2;
        private Button button1;
        private System.ComponentModel.BackgroundWorker bwSjekkForData;
    }
}