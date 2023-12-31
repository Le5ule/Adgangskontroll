﻿using System.Drawing;
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
            BW_SendKvittering = new System.ComponentModel.BackgroundWorker();
            Panel_KortLeser = new Panel();
            BTN_Åpne = new Button();
            BTN_Lukk = new Button();
            Label_ID = new Label();
            iPB_Lock = new FontAwesome.Sharp.IconPictureBox();
            iPB_Unlock = new FontAwesome.Sharp.IconPictureBox();
            iPB_DoorLocked = new FontAwesome.Sharp.IconPictureBox();
            iPB_DoorOpen = new FontAwesome.Sharp.IconPictureBox();
            bwSjekkForData = new System.ComponentModel.BackgroundWorker();
            Panel_KortLeser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iPB_Lock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iPB_Unlock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iPB_DoorLocked).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iPB_DoorOpen).BeginInit();
            SuspendLayout();
            // 
            // BTN0
            // 
            BTN0.Location = new Point(73, 192);
            BTN0.Name = "BTN0";
            BTN0.Size = new Size(23, 25);
            BTN0.TabIndex = 36;
            BTN0.Text = "0";
            BTN0.UseVisualStyleBackColor = true;
            BTN0.Click += BTN0_Click;
            // 
            // BTN9
            // 
            BTN9.Location = new Point(100, 164);
            BTN9.Name = "BTN9";
            BTN9.Size = new Size(23, 25);
            BTN9.TabIndex = 35;
            BTN9.Text = "9";
            BTN9.UseVisualStyleBackColor = true;
            BTN9.Click += BTN9_Click;
            // 
            // BTN8
            // 
            BTN8.Location = new Point(73, 164);
            BTN8.Name = "BTN8";
            BTN8.Size = new Size(23, 25);
            BTN8.TabIndex = 34;
            BTN8.Text = "8";
            BTN8.UseVisualStyleBackColor = true;
            BTN8.Click += BTN8_Click;
            // 
            // BTN7
            // 
            BTN7.Location = new Point(46, 164);
            BTN7.Name = "BTN7";
            BTN7.Size = new Size(23, 25);
            BTN7.TabIndex = 33;
            BTN7.Text = "7";
            BTN7.UseVisualStyleBackColor = true;
            BTN7.Click += BTN7_Click;
            // 
            // BTN6
            // 
            BTN6.Location = new Point(100, 135);
            BTN6.Name = "BTN6";
            BTN6.Size = new Size(23, 25);
            BTN6.TabIndex = 32;
            BTN6.Text = "6";
            BTN6.UseVisualStyleBackColor = true;
            BTN6.Click += BTN6_Click;
            // 
            // BTN5
            // 
            BTN5.Location = new Point(73, 135);
            BTN5.Name = "BTN5";
            BTN5.Size = new Size(23, 25);
            BTN5.TabIndex = 31;
            BTN5.Text = "5";
            BTN5.UseVisualStyleBackColor = true;
            BTN5.Click += BTN5_Click;
            // 
            // BTN4
            // 
            BTN4.Location = new Point(46, 135);
            BTN4.Name = "BTN4";
            BTN4.Size = new Size(23, 25);
            BTN4.TabIndex = 30;
            BTN4.Text = "4";
            BTN4.UseVisualStyleBackColor = true;
            BTN4.Click += BTN4_Click;
            // 
            // BTN3
            // 
            BTN3.Location = new Point(100, 107);
            BTN3.Name = "BTN3";
            BTN3.Size = new Size(23, 25);
            BTN3.TabIndex = 29;
            BTN3.Text = "3";
            BTN3.UseVisualStyleBackColor = true;
            BTN3.Click += BTN3_Click;
            // 
            // BTN2
            // 
            BTN2.Location = new Point(73, 107);
            BTN2.Name = "BTN2";
            BTN2.Size = new Size(23, 25);
            BTN2.TabIndex = 28;
            BTN2.Text = "2";
            BTN2.UseVisualStyleBackColor = true;
            BTN2.Click += BTN2_Click;
            // 
            // BTN1
            // 
            BTN1.Location = new Point(46, 107);
            BTN1.Name = "BTN1";
            BTN1.Size = new Size(23, 25);
            BTN1.TabIndex = 27;
            BTN1.Text = "1";
            BTN1.UseVisualStyleBackColor = true;
            BTN1.Click += BTN1_Click;
            // 
            // BTN_LesKort
            // 
            BTN_LesKort.Location = new Point(46, 37);
            BTN_LesKort.Name = "BTN_LesKort";
            BTN_LesKort.Size = new Size(77, 29);
            BTN_LesKort.TabIndex = 38;
            BTN_LesKort.Text = "Les kort";
            BTN_LesKort.UseVisualStyleBackColor = true;
            BTN_LesKort.Click += BTN_LesKort_Click;
            // 
            // TB_KortInput
            // 
            TB_KortInput.Location = new Point(46, 73);
            TB_KortInput.Name = "TB_KortInput";
            TB_KortInput.Size = new Size(77, 27);
            TB_KortInput.TabIndex = 40;
            TB_KortInput.Visible = false;
            // 
            // BW_SendKvittering
            // 
            BW_SendKvittering.DoWork += BW_SendKvittering_DoWork;
            BW_SendKvittering.RunWorkerCompleted += BW_SendKvittering_RunWorkerCompleted;
            // 
            // Panel_KortLeser
            // 
            Panel_KortLeser.BackColor = SystemColors.WindowFrame;
            Panel_KortLeser.Controls.Add(TB_KortInput);
            Panel_KortLeser.Controls.Add(BTN_LesKort);
            Panel_KortLeser.Controls.Add(BTN0);
            Panel_KortLeser.Controls.Add(BTN9);
            Panel_KortLeser.Controls.Add(BTN8);
            Panel_KortLeser.Controls.Add(BTN7);
            Panel_KortLeser.Controls.Add(BTN6);
            Panel_KortLeser.Controls.Add(BTN5);
            Panel_KortLeser.Controls.Add(BTN4);
            Panel_KortLeser.Controls.Add(BTN3);
            Panel_KortLeser.Controls.Add(BTN2);
            Panel_KortLeser.Controls.Add(BTN1);
            Panel_KortLeser.Location = new Point(14, 16);
            Panel_KortLeser.Margin = new Padding(3, 4, 3, 4);
            Panel_KortLeser.Name = "Panel_KortLeser";
            Panel_KortLeser.Size = new Size(173, 246);
            Panel_KortLeser.TabIndex = 41;
            // 
            // BTN_Åpne
            // 
            BTN_Åpne.Location = new Point(252, 149);
            BTN_Åpne.Margin = new Padding(3, 4, 3, 4);
            BTN_Åpne.Name = "BTN_Åpne";
            BTN_Åpne.Size = new Size(107, 39);
            BTN_Åpne.TabIndex = 45;
            BTN_Åpne.Text = "Åpne";
            BTN_Åpne.UseVisualStyleBackColor = true;
            BTN_Åpne.Click += BTN_Åpne_Click;
            // 
            // BTN_Lukk
            // 
            BTN_Lukk.Location = new Point(252, 196);
            BTN_Lukk.Margin = new Padding(3, 4, 3, 4);
            BTN_Lukk.Name = "BTN_Lukk";
            BTN_Lukk.Size = new Size(107, 39);
            BTN_Lukk.TabIndex = 46;
            BTN_Lukk.Text = "Lukk";
            BTN_Lukk.UseVisualStyleBackColor = true;
            BTN_Lukk.Click += BTN_Lukk_Click;
            // 
            // Label_ID
            // 
            Label_ID.AutoSize = true;
            Label_ID.Location = new Point(314, 44);
            Label_ID.Name = "Label_ID";
            Label_ID.Size = new Size(67, 20);
            Label_ID.TabIndex = 48;
            Label_ID.Text = "\"Dør-ID\"";
            // 
            // iPB_Lock
            // 
            iPB_Lock.BackColor = SystemColors.Control;
            iPB_Lock.ForeColor = SystemColors.ControlText;
            iPB_Lock.IconChar = FontAwesome.Sharp.IconChar.Lock;
            iPB_Lock.IconColor = SystemColors.ControlText;
            iPB_Lock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iPB_Lock.IconSize = 46;
            iPB_Lock.Location = new Point(241, 80);
            iPB_Lock.Margin = new Padding(3, 4, 3, 4);
            iPB_Lock.Name = "iPB_Lock";
            iPB_Lock.Size = new Size(46, 53);
            iPB_Lock.TabIndex = 50;
            iPB_Lock.TabStop = false;
            // 
            // iPB_Unlock
            // 
            iPB_Unlock.BackColor = SystemColors.Control;
            iPB_Unlock.ForeColor = SystemColors.ControlText;
            iPB_Unlock.IconChar = FontAwesome.Sharp.IconChar.LockOpen;
            iPB_Unlock.IconColor = SystemColors.ControlText;
            iPB_Unlock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iPB_Unlock.IconSize = 55;
            iPB_Unlock.Location = new Point(241, 77);
            iPB_Unlock.Margin = new Padding(3, 4, 3, 4);
            iPB_Unlock.Name = "iPB_Unlock";
            iPB_Unlock.Size = new Size(55, 64);
            iPB_Unlock.TabIndex = 51;
            iPB_Unlock.TabStop = false;
            // 
            // iPB_DoorLocked
            // 
            iPB_DoorLocked.BackColor = SystemColors.Control;
            iPB_DoorLocked.ForeColor = SystemColors.ControlText;
            iPB_DoorLocked.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            iPB_DoorLocked.IconColor = SystemColors.ControlText;
            iPB_DoorLocked.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iPB_DoorLocked.IconSize = 57;
            iPB_DoorLocked.Location = new Point(314, 74);
            iPB_DoorLocked.Margin = new Padding(3, 4, 3, 4);
            iPB_DoorLocked.Name = "iPB_DoorLocked";
            iPB_DoorLocked.Size = new Size(57, 67);
            iPB_DoorLocked.TabIndex = 51;
            iPB_DoorLocked.TabStop = false;
            // 
            // iPB_DoorOpen
            // 
            iPB_DoorOpen.BackColor = SystemColors.Control;
            iPB_DoorOpen.ForeColor = SystemColors.ControlText;
            iPB_DoorOpen.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            iPB_DoorOpen.IconColor = SystemColors.ControlText;
            iPB_DoorOpen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iPB_DoorOpen.IconSize = 57;
            iPB_DoorOpen.Location = new Point(314, 74);
            iPB_DoorOpen.Margin = new Padding(3, 4, 3, 4);
            iPB_DoorOpen.Name = "iPB_DoorOpen";
            iPB_DoorOpen.Size = new Size(57, 67);
            iPB_DoorOpen.TabIndex = 52;
            iPB_DoorOpen.TabStop = false;
            // 
            // bwSjekkForData
            // 
            bwSjekkForData.DoWork += bwSjekkForData_DoWork_1;
            bwSjekkForData.RunWorkerCompleted += bwSjekkForData_RunWorkerCompleted_1;
            // 
            // Kortleser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 276);
            Controls.Add(BTN_Lukk);
            Controls.Add(Label_ID);
            Controls.Add(BTN_Åpne);
            Controls.Add(iPB_Unlock);
            Controls.Add(iPB_Lock);
            Controls.Add(iPB_DoorOpen);
            Controls.Add(iPB_DoorLocked);
            Controls.Add(Panel_KortLeser);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Kortleser";
            Text = "Kortleser";
            FormClosing += Kortleser_FormClosing;
            Load += Kortleser_Load;
            Panel_KortLeser.ResumeLayout(false);
            Panel_KortLeser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iPB_Lock).EndInit();
            ((System.ComponentModel.ISupportInitialize)iPB_Unlock).EndInit();
            ((System.ComponentModel.ISupportInitialize)iPB_DoorLocked).EndInit();
            ((System.ComponentModel.ISupportInitialize)iPB_DoorOpen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private System.ComponentModel.BackgroundWorker BW_SendKvittering;
        private Panel Panel_KortLeser;
        private Button BTN_Åpne;
        private Button BTN_Lukk;
        private Label Label_ID;
        private FontAwesome.Sharp.IconPictureBox iPB_Lock;
        private FontAwesome.Sharp.IconPictureBox iPB_Unlock;
        private FontAwesome.Sharp.IconPictureBox iPB_DoorLocked;
        private FontAwesome.Sharp.IconPictureBox iPB_DoorOpen;
        private System.ComponentModel.BackgroundWorker bwSjekkForData;
    }
}