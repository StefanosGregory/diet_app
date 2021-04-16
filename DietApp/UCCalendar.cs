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
            var last = first.AddMonths(1).AddDays(-1);
            var days = DateTime.DaysInMonth(year, month);
            

            //first = first.ToString("dddd");
            switch (first.ToString("dddd"))
            {
                case "Sunday":
                    dayLblCorrection(1, days);
                    break;
                case "Monday":
                    dayLblCorrection(2, days);
                    break;
                case "Thuesday":
                    dayLblCorrection(3, days);
                    break;
                case "Wednesday":
                    dayLblCorrection(4, days);
                    break;
                case "Thursday":
                    dayLblCorrection(6, days);
                    break;
                case "Friday":
                    dayLblCorrection(6, days);
                    break;
                case "Saturday":
                    dayLblCorrection(7, days);
                    break;
                default:
                    MessageBox.Show("error");
                    break;
            }

        }

        private void dayLblCorrection(int index, int days)
        {
            Console.WriteLine("days: " + days.ToString() + " index: " + index.ToString());
            Label[] lb = { Day1Lbl, Day2Lbl, Day3Lbl, Day4Lbl, Day5Lbl, Day6Lbl, Day7Lbl, Day8Lbl, Day9Lbl, Day10Lbl, Day11Lbl, Day12Lbl, Day13Lbl, Day14Lbl, Day15Lbl, Day16Lbl, Day17Lbl, Day18Lbl, Day19Lbl, Day20Lbl, Day21Lbl, Day22Lbl, Day23Lbl, Day24Lbl, Day25Lbl, Day26Lbl, Day27Lbl, Day28Lbl, Day29Lbl, Day30Lbl, Day31Lbl, Day32Lbl, Day33Lbl, Day34Lbl, Day35Lbl };
            int j = 1;
            //Console.WriteLine(lb[-1].ToString());
            // for 
            for (int i = index - 1; i <= days + index - 1; i++)
            {
                lb[i].Text = j.ToString();

                j++;
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
