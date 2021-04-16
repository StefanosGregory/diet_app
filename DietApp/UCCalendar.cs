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
            
            MonthLbl.Visible = true;

        }

        private void UCCalendar_Load(object sender, EventArgs e)
        {
            FillfDaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            liveTimeLbl.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }



        private void FillfDaysInMonth(int year, int month)
        {
            var first = new DateTime(year, month, 1);
            var days = DateTime.DaysInMonth(year, month);
            var tmp = new DateTime(year, month, 1).AddMonths(-1);
            int previousmonth = Int16.Parse(tmp.ToString("MM"));
            
            switch (first.ToString("dddd"))
            {
                
                case "Monday":
                    dayLblCorrection(1, days, month, year, previousmonth);
                    break;
                case "Thuesday":
                    dayLblCorrection(2, days, month, year, previousmonth);
                    break;
                case "Wednesday":
                    dayLblCorrection(3, days, month, year, previousmonth);
                    break;
                case "Thursday":
                    dayLblCorrection(4, days, month, year, previousmonth);
                    break;
                case "Friday":
                    dayLblCorrection(5, days, month, year, previousmonth);
                    break;
                case "Saturday":
                    dayLblCorrection(6, days, month, year, previousmonth);
                    break;
                case "Sunday":
                    dayLblCorrection(7, days, month, year, previousmonth);
                    break;
                default:
                    MessageBox.Show("error");
                    break;
            }

        }

        private void dayLblCorrection(int index, int days, int month, int year, int previousmonth)
        {
            Label[] lb = { Day1Lbl, Day2Lbl, Day3Lbl, Day4Lbl, Day5Lbl, Day6Lbl, Day7Lbl, Day8Lbl, Day9Lbl, Day10Lbl, Day11Lbl, Day12Lbl, Day13Lbl, Day14Lbl, Day15Lbl, Day16Lbl, Day17Lbl, Day18Lbl, Day19Lbl, Day20Lbl, Day21Lbl, Day22Lbl, Day23Lbl, Day24Lbl, Day25Lbl, Day26Lbl, Day27Lbl, Day28Lbl, Day29Lbl, Day30Lbl, Day31Lbl, Day32Lbl, Day33Lbl, Day34Lbl, Day35Lbl, Day36Lbl, Day37Lbl };

            // Display the current month's day numbers.
            int j = 1;
            int d = index - 1;
            for (; d <= days + index - 2; d++)
            {
                lb[d].Text = j.ToString();
                lb[d].ForeColor = Color.FromArgb(158, 161, 176);
                j++;
            }

            // Display next mont's first visible day numbers.
            j = 1;
            for (; d <= 36; d++)
            {
                lb[d].Text = j.ToString();
                lb[d].ForeColor = Color.FromArgb(104, 104, 104);
                j++;

            }

            // Display previous month's last visible day numbers.
            j = DateTime.DaysInMonth(year, previousmonth);
            for (int i = index - 2; i >= 0; i--)
            {
                lb[i].Text = j.ToString();
                lb[i].ForeColor = Color.FromArgb(104, 104, 104);
                j--;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
