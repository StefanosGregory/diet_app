using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp
{
    public partial class UCCalendar : UserControl
    {
        public UCCalendar()
        {
            InitializeComponent();
            timer1.Enabled = true;
            liveTimeLbl.Visible = true;
            MonthLbl.Text = DateTime.Now.ToString("MMMM, yyyy");
            FillfDaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            MonthLbl.Visible = true;

        }

        private void UCCalendar_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            liveTimeLbl.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }



        private void FillfDaysInMonth(int year, int month)
        {
            var first = new DateTime(year, month, 1);
            var last = first.AddMonths(1).AddDays(-1);
            var days = DateTime.DaysInMonth(year, month);
            //Label[] lb = {Day1Lbl}

        }

    }
}
