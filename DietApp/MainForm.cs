using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DietApp
{
    public partial class MainForm : Form
    {
        private bool _draggable;
        private int _mouseX, _mouseY;

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
            Size = new Size(1300, 900);
            Region = Region.FromHrgn(CreateRoundRectRgn(0,0, Width, Height, 25,25));
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
            // Code to be written
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
                welcomeMsgLbl.Text = @"Good morning doc!";
            }
            else if (int.Parse(DateTime.Now.ToString("HH")) >= 12 && int.Parse(DateTime.Now.ToString("HH")) < 19)
            {
                welcomeMsgLbl.Text = @"Good evening doc!";
            }
            else if (int.Parse(DateTime.Now.ToString("HH")) >= 19 && int.Parse(DateTime.Now.ToString("HH")) <= 23)
            {
                welcomeMsgLbl.Text = @"Good night doc!";
            }
        }

        private void moveFormPnl_MouseEnter(object sender, EventArgs e)
        {
            moveFormPnl.BackColor = Color.FromArgb(158, 161, 176);
        }

        private void moveFormPnl_MouseLeave(object sender, EventArgs e)
        {
            moveFormPnl.BackColor = Color.FromArgb(0, 106, 249);
        }

        private void moveFormPnl_MouseDown(object sender, MouseEventArgs e)
        {
            _draggable = true;
            _mouseX = Cursor.Position.X - this.Left;
            _mouseY = Cursor.Position.Y - this.Top;
        }

        private void moveFormPnl_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_draggable) return;
            Top = Cursor.Position.Y - _mouseY;
            Left = Cursor.Position.X - _mouseX;
        }

        private void moveFormPnl_MouseUp(object sender, MouseEventArgs e)
        {
            _draggable = false;
        }
    }
}
