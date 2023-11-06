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
            dataGridView1 = new DataGridView();
            BTN_LesDB = new Button();
            TB_ID = new TextBox();
            BTN_VisKode = new Button();
            label1 = new Label();
            BTN_LesAnsatt = new Button();
            BTN_Brukere = new Button();
            BTN_info = new Button();
            button4 = new Button();
            npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            panel1 = new Panel();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            button5 = new Button();
            TB_Navn = new TextBox();
            panel3 = new Panel();
            panel4 = new Panel();
            TB_suksess = new TextBox();
            label4 = new Label();
            label5 = new Label();
            TB_LoggNavn = new TextBox();
            TB_LoggID = new TextBox();
            BTN_LoggInn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel3.SuspendLayout();
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
            dataGridView1.Size = new Size(528, 223);
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
            BTN_LesDB.Click += button1_Click;
            // 
            // TB_ID
            // 
            TB_ID.Location = new Point(24, 37);
            TB_ID.Name = "TB_ID";
            TB_ID.Size = new Size(125, 27);
            TB_ID.TabIndex = 4;
            // 
            // BTN_VisKode
            // 
            BTN_VisKode.Location = new Point(315, 37);
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
            label1.Location = new Point(24, 43);
            label1.Name = "label1";
            label1.Size = new Size(430, 100);
            label1.TabIndex = 6;
            label1.Text = "Skal legge til paneler og knapper for å lage forskjellige menyer.\r\n-info kortlesere\r\n-info brukere\r\n-logg\r\n    -alarmer(eller egen tab)";
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
            BTN_info.Location = new Point(29, 135);
            BTN_info.Name = "BTN_info";
            BTN_info.Size = new Size(94, 29);
            BTN_info.TabIndex = 10;
            BTN_info.Text = "info";
            BTN_info.UseVisualStyleBackColor = true;
            BTN_info.Click += BTN_info_Click;
            // 
            // button4
            // 
            button4.Location = new Point(29, 170);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 11;
            button4.Text = "innlogging";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // npgsqlCommandBuilder1
            // 
            npgsqlCommandBuilder1.QuotePrefix = "\"";
            npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(BTN_LesDB);
            panel1.Location = new Point(238, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(574, 298);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dataGridView2);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(TB_Navn);
            panel2.Controls.Add(TB_ID);
            panel2.Controls.Add(BTN_VisKode);
            panel2.Location = new Point(238, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(574, 298);
            panel2.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(165, 9);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 10;
            label3.Text = "navn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 9);
            label2.Name = "label2";
            label2.Size = new Size(22, 20);
            label2.TabIndex = 9;
            label2.Text = "id";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(24, 70);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(530, 209);
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
            TB_Navn.Location = new Point(165, 38);
            TB_Navn.Name = "TB_Navn";
            TB_Navn.Size = new Size(125, 27);
            TB_Navn.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Location = new Point(238, 65);
            panel3.Name = "panel3";
            panel3.Size = new Size(574, 298);
            panel3.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Controls.Add(TB_suksess);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(TB_LoggNavn);
            panel4.Controls.Add(TB_LoggID);
            panel4.Controls.Add(BTN_LoggInn);
            panel4.Location = new Point(238, 65);
            panel4.Name = "panel4";
            panel4.Size = new Size(574, 298);
            panel4.TabIndex = 14;
            // 
            // TB_suksess
            // 
            TB_suksess.Location = new Point(315, 106);
            TB_suksess.Name = "TB_suksess";
            TB_suksess.Size = new Size(125, 27);
            TB_suksess.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(165, 9);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 10;
            label4.Text = "navn";
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
            // TB_LoggNavn
            // 
            TB_LoggNavn.Location = new Point(165, 38);
            TB_LoggNavn.Name = "TB_LoggNavn";
            TB_LoggNavn.Size = new Size(125, 27);
            TB_LoggNavn.TabIndex = 6;
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
            // Sentral
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1122, 672);
            Controls.Add(panel2);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(panel3);
            Controls.Add(button4);
            Controls.Add(BTN_info);
            Controls.Add(BTN_Brukere);
            Controls.Add(BTN_LesAnsatt);
            Name = "Sentral";
            Text = "Sentral";
            Load += Sentral_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
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
        private Button button4;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
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
        private TextBox TB_LoggNavn;
        private TextBox TB_LoggID;
        private Button BTN_LoggInn;
    }
}