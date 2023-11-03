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
            button1 = new Button();
            TB_Kombo = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(86, 201);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(824, 281);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(86, 148);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Les DB";
            button1.UseVisualStyleBackColor = true;
            // 
            // TB_Kombo
            // 
            TB_Kombo.Location = new Point(402, 81);
            TB_Kombo.Name = "TB_Kombo";
            TB_Kombo.ReadOnly = true;
            TB_Kombo.Size = new Size(125, 27);
            TB_Kombo.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(275, 79);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Vis kode";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Sentral
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 561);
            Controls.Add(button2);
            Controls.Add(TB_Kombo);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Sentral";
            Text = "Sentral";
            Load += Sentral_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private TextBox TB_Kombo;
        private Button button2;
    }
}