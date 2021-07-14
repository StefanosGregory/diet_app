
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.welcomeMsgLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCloseApp = new System.Windows.Forms.Button();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.moveFormPnl = new System.Windows.Forms.Panel();
            this.ucSettings1 = new DietApp.UcSettings();
            this.ucCalendar1 = new DietApp.UcCalendar();
            this.ucClients1 = new DietApp.UcClients();
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
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 900);
            this.panel1.TabIndex = 0;
            // 
            // PnlNav
            // 
            this.PnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.PnlNav.Location = new System.Drawing.Point(2, 164);
            this.PnlNav.Margin = new System.Windows.Forms.Padding(2);
            this.PnlNav.Name = "PnlNav";
            this.PnlNav.Size = new System.Drawing.Size(2, 74);
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
            this.BtnSettings.Location = new System.Drawing.Point(0, 863);
            this.BtnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(150, 37);
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
            this.BtnCalendar.Location = new System.Drawing.Point(0, 201);
            this.BtnCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCalendar.Name = "BtnCalendar";
            this.BtnCalendar.Size = new System.Drawing.Size(150, 37);
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
            this.BtnClients.Location = new System.Drawing.Point(0, 164);
            this.BtnClients.Margin = new System.Windows.Forms.Padding(2);
            this.BtnClients.Name = "BtnClients";
            this.BtnClients.Size = new System.Drawing.Size(150, 37);
            this.BtnClients.TabIndex = 2;
            this.BtnClients.Text = " Clients     ";
            this.BtnClients.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnClients.UseVisualStyleBackColor = true;
            this.BtnClients.Click += new System.EventHandler(this.BtnClients_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.welcomeMsgLbl);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 164);
            this.panel2.TabIndex = 1;
            // 
            // welcomeMsgLbl
            // 
            this.welcomeMsgLbl.AutoSize = true;
            this.welcomeMsgLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeMsgLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.welcomeMsgLbl.Location = new System.Drawing.Point(25, 127);
            this.welcomeMsgLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.welcomeMsgLbl.Name = "welcomeMsgLbl";
            this.welcomeMsgLbl.Size = new System.Drawing.Size(109, 13);
            this.welcomeMsgLbl.TabIndex = 1;
            this.welcomeMsgLbl.Text = "Welcome message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(26, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Doctor Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DietApp.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(41, 20);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 68);
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
            this.BtnCloseApp.Location = new System.Drawing.Point(1264, 6);
            this.BtnCloseApp.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCloseApp.Name = "BtnCloseApp";
            this.BtnCloseApp.Size = new System.Drawing.Size(34, 29);
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
            this.BtnMinimize.Location = new System.Drawing.Point(1232, 5);
            this.BtnMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(28, 29);
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
            this.moveFormPnl.Location = new System.Drawing.Point(150, 0);
            this.moveFormPnl.Margin = new System.Windows.Forms.Padding(2);
            this.moveFormPnl.Name = "moveFormPnl";
            this.moveFormPnl.Size = new System.Drawing.Size(1722, 7);
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
            this.ucSettings1.Location = new System.Drawing.Point(1358, 306);
            this.ucSettings1.Margin = new System.Windows.Forms.Padding(1);
            this.ucSettings1.Name = "ucSettings1";
            this.ucSettings1.Size = new System.Drawing.Size(210, 98);
            this.ucSettings1.TabIndex = 4;
            this.ucSettings1.Visible = false;
            // 
            // ucCalendar1
            // 
            this.ucCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ucCalendar1.Location = new System.Drawing.Point(1342, 155);
            this.ucCalendar1.Margin = new System.Windows.Forms.Padding(1);
            this.ucCalendar1.Name = "ucCalendar1";
            this.ucCalendar1.Size = new System.Drawing.Size(210, 98);
            this.ucCalendar1.TabIndex = 3;
            this.ucCalendar1.Visible = false;
            // 
            // ucClients1
            // 
            this.ucClients1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ucClients1.ForeColor = System.Drawing.Color.Transparent;
            this.ucClients1.Location = new System.Drawing.Point(150, 5);
            this.ucClients1.Margin = new System.Windows.Forms.Padding(1);
            this.ucClients1.Name = "ucClients1";
            this.ucClients1.Size = new System.Drawing.Size(1110, 745);
            this.ucClients1.TabIndex = 2;
            this.ucClients1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1872, 900);
            this.Controls.Add(this.moveFormPnl);
            this.Controls.Add(this.BtnMinimize);
            this.Controls.Add(this.BtnCloseApp);
            this.Controls.Add(this.ucSettings1);
            this.Controls.Add(this.ucCalendar1);
            this.Controls.Add(this.ucClients1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Button BtnCalendar;
        private System.Windows.Forms.Button BtnClients;
        private System.Windows.Forms.Panel PnlNav;
        private UcClients ucClients1;
        private UcCalendar ucCalendar1;
        private UcSettings ucSettings1;
        private System.Windows.Forms.Button BtnCloseApp;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.Panel moveFormPnl;
    }
}

