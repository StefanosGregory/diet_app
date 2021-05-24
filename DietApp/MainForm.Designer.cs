﻿
namespace DietApp
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PnlNav = new System.Windows.Forms.Panel();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.BtnCalendar = new System.Windows.Forms.Button();
            this.BtnClients = new System.Windows.Forms.Button();
            this.BtnDashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.welcomeMsgLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCloseApp = new System.Windows.Forms.Button();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.moveFormPnl = new System.Windows.Forms.Panel();
            this.ucSettings1 = new DietApp.UCSettings();
            this.ucCalendar1 = new DietApp.UcCalendar();
            this.ucClients1 = new DietApp.UCClients();
            this.ucDashboard1 = new DietApp.UCDashboard();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.PnlNav);
            this.panel1.Controls.Add(this.BtnSettings);
            this.panel1.Controls.Add(this.BtnCalendar);
            this.panel1.Controls.Add(this.BtnClients);
            this.panel1.Controls.Add(this.BtnDashboard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 705);
            this.panel1.TabIndex = 0;
            // 
            // PnlNav
            // 
            this.PnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.PnlNav.Location = new System.Drawing.Point(3, 216);
            this.PnlNav.Name = "PnlNav";
            this.PnlNav.Size = new System.Drawing.Size(3, 113);
            this.PnlNav.TabIndex = 1;
            // 
            // BtnSettings
            // 
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSettings.FlatAppearance.BorderSize = 0;
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnSettings.Image = global::DietApp.Properties.Resources.settings;
            this.BtnSettings.Location = new System.Drawing.Point(0, 660);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(200, 45);
            this.BtnSettings.TabIndex = 6;
            this.BtnSettings.Text = "Settings  ";
            this.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // BtnCalendar
            // 
            this.BtnCalendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCalendar.FlatAppearance.BorderSize = 0;
            this.BtnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCalendar.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCalendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnCalendar.Image = global::DietApp.Properties.Resources.calendar;
            this.BtnCalendar.Location = new System.Drawing.Point(0, 292);
            this.BtnCalendar.Name = "BtnCalendar";
            this.BtnCalendar.Size = new System.Drawing.Size(200, 45);
            this.BtnCalendar.TabIndex = 3;
            this.BtnCalendar.Text = "Calendar   ";
            this.BtnCalendar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnCalendar.UseVisualStyleBackColor = true;
            this.BtnCalendar.Click += new System.EventHandler(this.BtnCalendar_Click);
            // 
            // BtnClients
            // 
            this.BtnClients.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnClients.FlatAppearance.BorderSize = 0;
            this.BtnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClients.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnClients.Image = global::DietApp.Properties.Resources.Conact;
            this.BtnClients.Location = new System.Drawing.Point(0, 247);
            this.BtnClients.Name = "BtnClients";
            this.BtnClients.Size = new System.Drawing.Size(200, 45);
            this.BtnClients.TabIndex = 2;
            this.BtnClients.Text = " Clients     ";
            this.BtnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnClients.UseVisualStyleBackColor = true;
            this.BtnClients.Click += new System.EventHandler(this.BtnClients_Click);
            // 
            // BtnDashboard
            // 
            this.BtnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnDashboard.FlatAppearance.BorderSize = 0;
            this.BtnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDashboard.Font = new System.Drawing.Font("Nirmala UI", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnDashboard.Image = global::DietApp.Properties.Resources.home;
            this.BtnDashboard.Location = new System.Drawing.Point(0, 202);
            this.BtnDashboard.Name = "BtnDashboard";
            this.BtnDashboard.Size = new System.Drawing.Size(200, 45);
            this.BtnDashboard.TabIndex = 1;
            this.BtnDashboard.Text = "Dashboard";
            this.BtnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnDashboard.UseVisualStyleBackColor = true;
            this.BtnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.welcomeMsgLbl);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 202);
            this.panel2.TabIndex = 1;
            // 
            // welcomeMsgLbl
            // 
            this.welcomeMsgLbl.AutoSize = true;
            this.welcomeMsgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMsgLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.welcomeMsgLbl.Location = new System.Drawing.Point(33, 156);
            this.welcomeMsgLbl.Name = "welcomeMsgLbl";
            this.welcomeMsgLbl.Size = new System.Drawing.Size(128, 15);
            this.welcomeMsgLbl.TabIndex = 1;
            this.welcomeMsgLbl.Text = "Welcome message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(35, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doctor Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DietApp.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(55, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // BtnCloseApp
            // 
            this.BtnCloseApp.FlatAppearance.BorderSize = 0;
            this.BtnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseApp.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCloseApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnCloseApp.Location = new System.Drawing.Point(1467, 8);
            this.BtnCloseApp.Name = "BtnCloseApp";
            this.BtnCloseApp.Size = new System.Drawing.Size(45, 36);
            this.BtnCloseApp.TabIndex = 7;
            this.BtnCloseApp.Text = "X";
            this.BtnCloseApp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnCloseApp.UseVisualStyleBackColor = true;
            this.BtnCloseApp.Click += new System.EventHandler(this.BtnCloseApp_Click);
            this.BtnCloseApp.MouseEnter += new System.EventHandler(this.BtnCloseApp_MouseEnter);
            this.BtnCloseApp.MouseLeave += new System.EventHandler(this.BtnCloseApp_MouseLeave);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.FlatAppearance.BorderSize = 0;
            this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMinimize.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.BtnMinimize.Location = new System.Drawing.Point(1424, 6);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(37, 36);
            this.BtnMinimize.TabIndex = 8;
            this.BtnMinimize.Text = "__";
            this.BtnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMinimize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnMinimize.UseVisualStyleBackColor = true;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // moveFormPnl
            // 
            this.moveFormPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(249)))));
            this.moveFormPnl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.moveFormPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.moveFormPnl.Location = new System.Drawing.Point(200, 0);
            this.moveFormPnl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moveFormPnl.Name = "moveFormPnl";
            this.moveFormPnl.Size = new System.Drawing.Size(1095, 9);
            this.moveFormPnl.TabIndex = 9;
            this.moveFormPnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveFormPnl_MouseDown);
            this.moveFormPnl.MouseEnter += new System.EventHandler(this.moveFormPnl_MouseEnter);
            this.moveFormPnl.MouseLeave += new System.EventHandler(this.moveFormPnl_MouseLeave);
            this.moveFormPnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveFormPnl_MouseMove);
            this.moveFormPnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveFormPnl_MouseUp);
            // 
            // ucSettings1
            // 
            this.ucSettings1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ucSettings1.Location = new System.Drawing.Point(231, 796);
            this.ucSettings1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucSettings1.Name = "ucSettings1";
            this.ucSettings1.Size = new System.Drawing.Size(249, 118);
            this.ucSettings1.TabIndex = 4;
            this.ucSettings1.Visible = false;
            // 
            // ucCalendar1
            // 
            this.ucCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ucCalendar1.Location = new System.Drawing.Point(200, 312);
            this.ucCalendar1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucCalendar1.Name = "ucCalendar1";
            this.ucCalendar1.Size = new System.Drawing.Size(1312, 1147);
            this.ucCalendar1.TabIndex = 3;
            this.ucCalendar1.Visible = false;
            // 
            // ucClients1
            // 
            this.ucClients1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ucClients1.ForeColor = System.Drawing.Color.Transparent;
            this.ucClients1.Location = new System.Drawing.Point(205, 216);
            this.ucClients1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucClients1.Name = "ucClients1";
            this.ucClients1.Size = new System.Drawing.Size(1256, 900);
            this.ucClients1.TabIndex = 2;
            this.ucClients1.Visible = false;
            // 
            // ucDashboard1
            // 
            this.ucDashboard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ucDashboard1.Location = new System.Drawing.Point(200, 6);
            this.ucDashboard1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ucDashboard1.Name = "ucDashboard1";
            this.ucDashboard1.Size = new System.Drawing.Size(1256, 1248);
            this.ucDashboard1.TabIndex = 1;
            this.ucDashboard1.Load += new System.EventHandler(this.ucDashboard1_Load);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1295, 705);
            this.Controls.Add(this.moveFormPnl);
            this.Controls.Add(this.BtnMinimize);
            this.Controls.Add(this.BtnCloseApp);
            this.Controls.Add(this.ucSettings1);
            this.Controls.Add(this.ucCalendar1);
            this.Controls.Add(this.ucClients1);
            this.Controls.Add(this.ucDashboard1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DietApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label welcomeMsgLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDashboard;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Button BtnCalendar;
        private System.Windows.Forms.Button BtnClients;
        private System.Windows.Forms.Panel PnlNav;
        private UCDashboard ucDashboard1;
        private UCClients ucClients1;
        private UcCalendar ucCalendar1;
        private UCSettings ucSettings1;
        private System.Windows.Forms.Button BtnCloseApp;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.Panel moveFormPnl;
    }
}

