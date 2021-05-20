using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace DietApp
{
    public partial class UcCalendar : UserControl
    {
        private DateTime _currentDate;
        private readonly List<FlowLayoutPanel> _listFlDay;
        private readonly string _cs;

        public UcCalendar()
        {
            InitializeComponent();
            _currentDate = DateTime.Today;
            _listFlDay = new List<FlowLayoutPanel>();
            _cs = $"Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        }


        private void UCCalendar_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            liveTimeLbl.Visible = true;
            MonthLbl.Text = DateTime.Now.ToString("MMMM, yyyy");

            MonthLbl.Visible = true;
            GenerateDayPanel(36);
            AddLblToFlDay(GetFirstDayOfMonth(), GetTotalDays());
            DisplayCurrentDate();
        }

        /*
         * GETTERS FIRST DAY AND TOTAL DAYS OF A MONTH
         */
        private int GetFirstDayOfMonth() 
        {
            var first = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            return (int) first.DayOfWeek;  
        }

        private int GetTotalDays()
        {
            return DateTime.DaysInMonth(_currentDate.Year, _currentDate.Month);
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
            _listFlDay.Clear();

            for (var i = 0; i <= totalDays; i++)
            {
                var fl = new FlowLayoutPanel
                {
                    Name = $"flDay{i}", 
                    Size = new Size(128, 104), 
                    BackColor = Color.FromArgb(37, 42, 64)
                };
                flDays.Controls.Add(fl);
                _listFlDay.Add(fl);
            }
        }

        /*
         * GENERATE FL DAY LABELS
         */

        private void AddLblToFlDay(int startDay, int totalDays)
        {
            foreach (var fl in _listFlDay)
            {
                fl.Controls.Clear();
            }

            for (var i = 1; i <= totalDays; i++)
            {
                var lbl = new Label
                {
                    Name = $"lblDay{i}",
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleRight,
                    Size = new Size(129, 19),
                    Text = i + @" ",
                    ForeColor = Color.FromArgb(158, 161, 176)
                };
                _listFlDay[(i) + startDay - 1].Controls.Add(lbl);

            }
        }

        /*
         * FILL APPOINTMENTS
         */
        private void AddAppointmentToFlDay(int startDayAtFlNumber)
        {   
            var startDate = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            var sql = $"select count(id), cast(datetime as date) as date from appointments where datetime between '{startDate:yyyy-MM-dd HH:mm:ss}' and '{endDate:yyyy-MM-dd HH:mm:ss}' group by date";
            var dt = QueryAsDataTable(sql);
            foreach (DataRow row in dt.Rows)
            {
                if (int.Parse(row["count"].ToString()) == 0) continue;
                var link = new LinkLabel
                {
                    Name = row["date"].ToString(),
                    Text = row["count"] + @" appointments.",
                    LinkColor = Color.FromArgb(158, 161, 176),
                    Size = new Size(128, 104 / 2),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                var datetime = DateTime.Parse(row["date"].ToString());
                _listFlDay[datetime.Day + startDayAtFlNumber - 1].Controls.Add(link);
                link.Click += (sender, eventArgs) => { link_click(link.Name); };
            }
        }
        private void link_click(string date)
        {
            new DayFormAppoint(date, this).Show();
        }

        private DataTable QueryAsDataTable(string sql) 
        {
            IDbCommand selectCommand = new NpgsqlConnection(_cs).CreateCommand();
            selectCommand.CommandText = sql;
            IDbDataAdapter da = new NpgsqlDataAdapter();
            da.SelectCommand = selectCommand;

            var ds = new DataSet();

            da.Fill(ds);

            return ds.Tables[0];
        }

        /*
         NEXT MONTH BUTTON
         */
        private void BtnNext_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(1);
            DisplayCurrentDate();
        }

        /*
         RELOAD BUTTON
         */
        private void reload_btn_Click(object sender, EventArgs e)
        {
            _currentDate = DateTime.Today;
            DisplayCurrentDate();
        }


        /*
         PREVIOUS MONTH BUTTON
         */
        private void BtnBack_Click(object sender, EventArgs e)
        {
            _currentDate = _currentDate.AddMonths(-1);
            DisplayCurrentDate();
        }

        /*
          DISPLAY CURRENT DATE METHOD
         */
        public void DisplayCurrentDate()
        {
            MonthLbl.Text = _currentDate.ToString("MMMM, yyyy");
            var firstDayOfMonth = GetFirstDayOfMonth();
            AddLblToFlDay(firstDayOfMonth, GetTotalDays());
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
