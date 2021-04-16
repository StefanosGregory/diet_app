using System;
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
    public partial class MainForm : Form
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

        public MainForm()
        {
            InitializeComponent();
            this.Size = new Size(1300, 900);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0, Width, Height, 25,25));
            PnlNav.Height = BtnDashboard.Height;
            PnlNav.Top = BtnDashboard.Top;
            PnlNav.Left = BtnDashboard.Left;
            BtnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            ucSettings1.Location = ucCalendar1.Location = ucClients1.Location = ucDashboard1.Location;
            BtnCloseApp.Location = new Point(this.Width - BtnCloseApp.Width - 10 , 10);
            BtnMinimize.Location = new Point(BtnCloseApp.Location.X - BtnCloseApp.Size.Width + 5 , 10);
            WelcomeMess();

        }




        private void MainForm_Load(object sender, EventArgs e)
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


        /*
         * _ X Buttons
         * <
         */


        private void BtnCloseApp_MouseEnter(object sender, EventArgs e)
        {
            BtnCloseApp.ForeColor = Color.FromArgb(178, 34, 34);
        }

        private void BtnCloseApp_MouseLeave(object sender, EventArgs e)
        {
            BtnCloseApp.ForeColor = Color.FromArgb(0, 126, 249);
        }

        private void BtnCloseApp_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /*
         * End
         * >
         */


        /*
         * FUNCTIONS
         */
        private void WelcomeMess()
        {
            if (int.Parse(DateTime.Now.ToString("HH")) >= 00 && int.Parse(DateTime.Now.ToString("HH")) < 12)
            {
                welcomeMsgLbl.Text = "Good morning doc!";
            }
            else if (int.Parse(DateTime.Now.ToString("HH")) >= 12 && int.Parse(DateTime.Now.ToString("HH")) < 19)
            {
                welcomeMsgLbl.Text = "Good evening doc!";
            }
            else if (int.Parse(DateTime.Now.ToString("HH")) >= 19 && int.Parse(DateTime.Now.ToString("HH")) <= 23)
            {
                welcomeMsgLbl.Text = "Good night doc!";
            }
        }
    }
}
