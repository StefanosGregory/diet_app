using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DietApp
{
    public partial class UCCalendar : UserControl
    {
        private DateTime currentDate;
        private List<FlowLayoutPanel> listFlDay;
        private string cs;

        public UCCalendar()
        {
            InitializeComponent();
            currentDate = DateTime.Today;
            listFlDay = new List<FlowLayoutPanel>();
            cs = $"Host=localhost; Username=postgres; Password=1; Database=dietDB";
        }


        private void UCCalendar_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            liveTimeLbl.Visible = true;
            MonthLbl.Text = DateTime.Now.ToString("MMMM, yyyy");

            MonthLbl.Visible = true;
            GenerateDayPanel(36);
            AddLblToFlDay(GetFirstDayOFMonth(), GetTotalDayes());
        }

        /*
         * GETTERS FIRST DAY AND TOTAL DAYS OF A MANTH
         */
        private int GetFirstDayOFMonth() 
        {
            DateTime first = new DateTime(currentDate.Year, currentDate.Month, 1);
            return (int)(first.DayOfWeek);  
        }

        private int GetTotalDayes()
        {
            return DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
        }
        /*
         */

        private void timer1_Tick(object sender, EventArgs e)
        {
            liveTimeLbl.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        /*
         * GENERATE FL DAY PANELS
         */
        private void GenerateDayPanel(int totalDays)
        {
            flDays.Controls.Clear();
            listFlDay.Clear();

            for (int i = 0; i <= totalDays; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = $"flDay{i}";
                fl.Size = new Size(128, 104);
                fl.BackColor = Color.FromArgb(37, 42, 64);

                flDays.Controls.Add(fl);

                listFlDay.Add(fl);

            }
        }

        /*
         * GENERATE FL DAY LABELS
         */

        private void AddLblToFlDay(int startDay, int totalDays)
        {
            foreach (FlowLayoutPanel fl in listFlDay)
            {
                fl.Controls.Clear();
            }

            for (int i = 1; i <= totalDays; i++)
            {
                Label lbl = new Label();
                lbl.Name = $"lblDay{i}";
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Size = new Size(129, 19);
                lbl.Text = (i + " ").ToString();
                lbl.ForeColor = Color.FromArgb(158, 161, 176);
                listFlDay[(i) + startDay - 1].Controls.Add(lbl);

            }
        }

        /*
         * FILL APPOINTMENTS
         */
        private void AddAppointmentToFlDay(int startDayAtFlnumber)
        {   
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            var sql = $"select appointments.ID, datetime, fullname from appointments RIGHT OUTER JOIN clients ON clients.ID = appointments.clientsid where datetime between '{startDate.ToString("yyyy-MM-dd HH:mm:ss")}' and '{endDate.ToString("yyyy-MM-dd HH:mm:ss")}'";
            DataTable dt = QueryAsDataTable(sql);
            foreach(DataRow row in dt.Rows) 
            {
                DateTime datetime = DateTime.Parse(row["datetime"].ToString());
                LinkLabel link = new LinkLabel();
                link.Name = $"link{(row["ID"])}";
                link.Text = row["fullname"].ToString();
                listFlDay[datetime.Day + (startDayAtFlnumber - 1)].Controls.Add(link);
            }
        }

        private DataTable QueryAsDataTable(String sql) 
        {
            IDbConnection con = new NpgsqlConnection(cs);
            IDbCommand selectCommand = con.CreateCommand();
            selectCommand.CommandText = sql;
            IDbDataAdapter da = new NpgsqlDataAdapter();
            da.SelectCommand = selectCommand;

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds.Tables[0];
            

        }

        /*
         NEXT MONTH BUTTON
         */
        private void BtnNext_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(1);
            DisplayCurrentDate();
        }

        /*
         RELOAD BUTTON
         */
        private void reload_btn_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;
            DisplayCurrentDate();
        }


        /*
         PREVIOUS MONTH BUTTON
         */
        private void BtnBack_Click(object sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);
            DisplayCurrentDate();
        }

        /*
          DISPLAY CURRENT DATE METHOD
         */
        private void DisplayCurrentDate()
        {
            MonthLbl.Text = currentDate.ToString("MMMM, yyyy");
            int firstDayOfMonth = GetFirstDayOFMonth();
            AddLblToFlDay(firstDayOfMonth, GetTotalDayes());
            AddAppointmentToFlDay(firstDayOfMonth);
        }   

        /*
         * Hovers
         */
        private void BtnBack_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(BtnBack, "Previous month");
        }
        private void reload_btn_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(reload_btn, "Current month calendar");
        }
        private void BtnNext_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip(BtnNext, "Next month");
        }

    }
}
