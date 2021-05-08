using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;

namespace DietApp
{
    public partial class DayFormAppoint : Form
    {
        private readonly DateTime _appointmentDay;
        private readonly string _cs;
        private List<Label> _listFlDay;
        public DayFormAppoint(string test)
        {
            InitializeComponent();
            _appointmentDay = DateTime.Parse(test);
            _cs = $"Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        }

        private void DayFormAppoint_Load(object sender, EventArgs e)
        {
            AddAppointmentToFlDay();
        }
        private void AddAppointmentToFlDay()
        {   
            var sql = $"select appointments.ID, datetime, fullname from appointments RIGHT OUTER JOIN clients ON clients.ID = appointments.clientsid where datetime::date='{_appointmentDay:yyyy-MM-dd}'";
            var dt = QueryAsDataTable(sql);
            var i = 1;
            foreach(DataRow row in dt.Rows) 
            {
                //var datetime = DateTime.Parse(row["datetime"].ToString());
                var lbl = new Label
                {
                    Name = $"link{(row["ID"])}",
                    ForeColor = Color.FromArgb(158, 161, 176),
                    AutoSize = false,
                    Size = new Size(100, 150),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = i + @") " + row["datetime"] + @" " + row["fullname"]
                };
                flAppointments.Controls.Add(lbl);
                i += 1;
            }
        }

        private void flAppointments_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
