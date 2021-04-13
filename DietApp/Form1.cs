﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DietApp
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nweightEllipse
            );

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1200, 800);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0, Width, Height, 25,25));
            PnlNav.Height = BtnDashboard.Height;
            PnlNav.Top = BtnDashboard.Top;
            PnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            ucSettings1.Location = ucCalendar1.Location = ucClients1.Location = ucDashboard1.Location;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /*
         * CLick Event Buttons
         * <
         */
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnDashboard.Height;
            PnlNav.Top = BtnDashboard.Top;
            PnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            ucDashboard1.Visible = true;
            BtnCalendar.BackColor = BtnSettings.BackColor = BtnClients.BackColor = Color.FromArgb(20, 30, 54);
            ucSettings1.Visible = ucClients1.Visible = ucCalendar1.Visible = false;

        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnClients.Height;
            PnlNav.Top = BtnClients.Top;
            PnlNav.Left = BtnClients.Left;
            BtnClients.BackColor = Color.FromArgb(46, 51, 73);
            ucClients1.Visible = true;
            BtnCalendar.BackColor = BtnSettings.BackColor = BtnDashboard.BackColor = Color.FromArgb(20, 30, 54);
            ucSettings1.Visible = ucCalendar1.Visible = ucDashboard1.Visible = false;

        }

        private void BtnCalendar_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnCalendar.Height;
            PnlNav.Top = BtnCalendar.Top;
            PnlNav.Left = BtnCalendar.Left;
            BtnCalendar.BackColor = Color.FromArgb(46, 51, 73);
            ucCalendar1.Visible = true;
            BtnDashboard.BackColor = BtnSettings.BackColor = BtnClients.BackColor = Color.FromArgb(20, 30, 54);
            ucSettings1.Visible = ucClients1.Visible = ucDashboard1.Visible = false;
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            PnlNav.Height = BtnSettings.Height;
            PnlNav.Top = BtnSettings.Top;
            PnlNav.Left = BtnSettings.Left;
            BtnSettings.BackColor = Color.FromArgb(46, 51, 73);
            ucSettings1.Visible = true;
            BtnCalendar.BackColor = BtnDashboard.BackColor = BtnClients.BackColor = Color.FromArgb(20, 30, 54);
            ucClients1.Visible = ucCalendar1.Visible = ucClients1.Visible = false;
        }
        /*
         * End
         * >
         */
        
    }
}