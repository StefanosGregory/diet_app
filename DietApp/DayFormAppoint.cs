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
    public partial class DayFormAppoint : Form
    {
        DateTime startDate, endDate;
        private string cs;
        private List<Label> listFlDay;
        public DayFormAppoint(DateTime sD, DateTime eD)
        {
            InitializeComponent();
            startDate = sD;
            endDate = eD;
            cs = $"Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        }

        private void DayFormAppoint_Load(object sender, EventArgs e)
        {
            AddAppointmentToFlDay();
        }
        private void AddAppointmentToFlDay()
        {   
            var sql = $"select appointments.ID, datetime, fullname from appointments RIGHT OUTER JOIN clients ON clients.ID = appointments.clientsid where datetime between '{startDate.ToString("yyyy-MM-dd HH:mm:ss")}' and '{endDate.ToString("yyyy-MM-dd HH:mm:ss")}'";
            DataTable dt = QueryAsDataTable(sql);
            int i = 1;
            foreach(DataRow row in dt.Rows) 
            {
                DateTime datetime = DateTime.Parse(row["datetime"].ToString());
                Label lbl = new Label();
                lbl.Name = $"link{(row["ID"])}";
                lbl.ForeColor = Color.FromArgb(158, 161, 176);
                lbl.AutoSize = false;
                lbl.Size = new Size(100, 150);
                lbl.TextAlign = ContentAlignment.MiddleLeft;
                lbl.Text = i.ToString() + ") " + row["datetime"].ToString() + " " +row["fullname"].ToString();
                flAppointments.Controls.Add(lbl);
                i += 1;
        }

        }

        private void flAppointments_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
