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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sentral));
            dataGridView1 = new DataGridView();
            BTN_LesDB = new Button();
            TB_ID = new TextBox();
            BTN_VisKode = new Button();
            label1 = new Label();
            BTN_LesAnsatt = new Button();
            BTN_Brukere = new Button();
            BTN_info = new Button();
            BTN_Innlogg = new Button();
            panel1 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            button5 = new Button();
            TB_Navn = new TextBox();
            panel4 = new Panel();
            TB_suksess = new TextBox();
            label4 = new Label();
            label5 = new Label();
            TB_LoggPin = new TextBox();
            TB_LoggID = new TextBox();
            BTN_LoggInn = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(779, 347);
            dataGridView1.TabIndex = 1;
            // 
            // BTN_LesDB
            // 
            BTN_LesDB.Location = new Point(26, 21);
            BTN_LesDB.Name = "BTN_LesDB";
            BTN_LesDB.Size = new Size(94, 29);
            BTN_LesDB.TabIndex = 3;
            BTN_LesDB.Text = "Les DB";
            BTN_LesDB.UseVisualStyleBackColor = true;
            BTN_LesDB.Click += BTN_VisAnsatte_Click;
            // 
            // TB_ID
            // 
            TB_ID.Location = new Point(24, 36);
            TB_ID.Name = "TB_ID";
            TB_ID.Size = new Size(125, 27);
            TB_ID.TabIndex = 4;
            // 
            // BTN_VisKode
            // 
            BTN_VisKode.Location = new Point(315, 35);
            BTN_VisKode.Name = "BTN_VisKode";
            BTN_VisKode.Size = new Size(94, 29);
            BTN_VisKode.TabIndex = 5;
            BTN_VisKode.Text = "Legg til";
            BTN_VisKode.UseVisualStyleBackColor = true;
            BTN_VisKode.Click += BTN_LeggTil_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 32);
            label1.Name = "label1";
            label1.Size = new Size(570, 320);
            label1.TabIndex = 6;
            label1.Text = resources.GetString("label1.Text");
            // 
            // BTN_LesAnsatt
            // 
            BTN_LesAnsatt.Location = new Point(29, 65);
            BTN_LesAnsatt.Name = "BTN_LesAnsatt";
            BTN_LesAnsatt.Size = new Size(94, 29);
            BTN_LesAnsatt.TabIndex = 8;
            BTN_LesAnsatt.Text = "les ansatt";
            BTN_LesAnsatt.UseVisualStyleBackColor = true;
            BTN_LesAnsatt.Click += BTN_LesAnsatt_Click;
            // 
            // BTN_Brukere
            // 
            BTN_Brukere.Location = new Point(29, 100);
            BTN_Brukere.Name = "BTN_Brukere";
            BTN_Brukere.Size = new Size(94, 29);
            BTN_Brukere.TabIndex = 9;
            BTN_Brukere.Text = "brukere";
            BTN_Brukere.UseVisualStyleBackColor = true;
            BTN_Brukere.Click += BTN_Brukere_Click;
            // 
            // BTN_info
            // 
            BTN_info.Location = new Point(29, 170);
            BTN_info.Name = "BTN_info";
            BTN_info.Size = new Size(94, 29);
            BTN_info.TabIndex = 10;
            BTN_info.Text = "info";
            BTN_info.UseVisualStyleBackColor = true;
            BTN_info.Click += BTN_info_Click;
            // 
            // BTN_Innlogg
            // 
            BTN_Innlogg.Location = new Point(29, 135);
            BTN_Innlogg.Name = "BTN_Innlogg";
            BTN_Innlogg.Size = new Size(94, 29);
            BTN_Innlogg.TabIndex = 11;
            BTN_Innlogg.Text = "innlogging";
            BTN_Innlogg.UseVisualStyleBackColor = true;
            BTN_Innlogg.Click += BTN_Innlogg_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(BTN_LesDB);
            panel1.Location = new Point(162, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(897, 436);
            panel1.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Location = new Point(162, 39);
            panel3.Name = "panel3";
            panel3.Size = new Size(897, 438);
            panel3.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dataGridView2);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(TB_Navn);
            panel2.Controls.Add(TB_ID);
            panel2.Controls.Add(BTN_VisKode);
            panel2.Location = new Point(162, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(897, 433);
            panel2.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(590, 75);
            label6.Name = "label6";
            label6.Size = new Size(280, 180);
            label6.TabIndex = 11;
            label6.Text = resources.GetString("label6.Text");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(165, 9);
            label3.Name = "label3";
            label3.Size = new Size(29, 20);
            label3.TabIndex = 10;
            label3.Text = "Pin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 9);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 9;
            label2.Text = "Kort-ID";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(24, 70);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(530, 328);
            dataGridView2.TabIndex = 8;
            // 
            // button5
            // 
            button5.Location = new Point(460, 35);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 7;
            button5.Text = "Vis tab";
            button5.UseVisualStyleBackColor = true;
            button5.Click += BTN_VisTab_Click;
            // 
            // TB_Navn
            // 
            TB_Navn.Location = new Point(165, 36);
            TB_Navn.Name = "TB_Navn";
            TB_Navn.Size = new Size(125, 27);
            TB_Navn.TabIndex = 6;
            // 
            // panel4
            // 
            panel4.Controls.Add(TB_suksess);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(TB_LoggPin);
            panel4.Controls.Add(TB_LoggID);
            panel4.Controls.Add(BTN_LoggInn);
            panel4.Location = new Point(162, 29);
            panel4.Name = "panel4";
            panel4.Size = new Size(902, 439);
            panel4.TabIndex = 14;
            // 
            // TB_suksess
            // 
            TB_suksess.Location = new Point(315, 106);
            TB_suksess.Name = "TB_suksess";
            TB_suksess.Size = new Size(94, 27);
            TB_suksess.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 9);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 10;
            label4.Text = "pin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 9);
            label5.Name = "label5";
            label5.Size = new Size(22, 20);
            label5.TabIndex = 9;
            label5.Text = "id";
            // 
            // TB_LoggPin
            // 
            TB_LoggPin.Location = new Point(165, 38);
            TB_LoggPin.Name = "TB_LoggPin";
            TB_LoggPin.Size = new Size(125, 27);
            TB_LoggPin.TabIndex = 6;
            // 
            // TB_LoggID
            // 
            TB_LoggID.Location = new Point(24, 37);
            TB_LoggID.Name = "TB_LoggID";
            TB_LoggID.Size = new Size(125, 27);
            TB_LoggID.TabIndex = 4;
            // 
            // BTN_LoggInn
            // 
            BTN_LoggInn.Location = new Point(315, 37);
            BTN_LoggInn.Name = "BTN_LoggInn";
            BTN_LoggInn.Size = new Size(94, 29);
            BTN_LoggInn.TabIndex = 5;
            BTN_LoggInn.Text = "Logg inn";
            BTN_LoggInn.UseVisualStyleBackColor = true;
            BTN_LoggInn.Click += BTN_LoggInn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 512);
            label7.Name = "label7";
            label7.Size = new Size(189, 120);
            label7.TabIndex = 15;
            label7.Text = "Vil også ha en form for\r\nenkel statusrapport her i\r\nhovedvinduet(ikke i panel)\r\nmed umiddelbar info om\r\naktiv/inaktiv alarm\r\n    -evt x/y online kortlesere";
            // 
            // Sentral
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 678);
            Controls.Add(label7);
            Controls.Add(BTN_Innlogg);
            Controls.Add(BTN_info);
            Controls.Add(BTN_Brukere);
            Controls.Add(BTN_LesAnsatt);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Name = "Sentral";
            Text = "Sentral";
            Load += Sentral_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button BTN_LesDB;
        private TextBox TB_ID;
        private Button BTN_VisKode;
        private Label label1;
        private Button BTN_LesAnsatt;
        private Button BTN_Brukere;
        private Button BTN_info;
        private Button BTN_Innlogg;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox TB_Navn;
        private DataGridView dataGridView2;
        private Button button5;
        private Label label3;
        private Label label2;
        private Panel panel4;
        private TextBox TB_suksess;
        private Label label4;
        private Label label5;
        private TextBox TB_LoggPin;
        private TextBox TB_LoggID;
        private Button BTN_LoggInn;
        private Label label6;
        private Label label7;
    }
}