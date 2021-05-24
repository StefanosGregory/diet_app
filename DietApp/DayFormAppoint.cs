using System;
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
        public DayFormAppoint(string date)
        {
            InitializeComponent();
            _appointmentDay = DateTime.Parse(date);
            _cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
            dateLbl.Text = _appointmentDay.ToString("D");
        }

        private void DayFormAppoint_Load(object sender, EventArgs e)
        {
            AddAppointmentToFlDay();
        }

        private void AddAppointmentToFlDay()
        {
            flAppointments.Controls.Clear();
            var sql = $"select appointments.ID, datetime, fullname from appointments RIGHT OUTER JOIN clients ON clients.ID = appointments.clientsid where datetime::date='{_appointmentDay:yyyy-MM-dd}'";
            var dt = QueryAsDataTable(sql);
            var i = 1;
            foreach(DataRow row in dt.Rows) 
            {
                var lbl = new Label
                {
                    Name = $"link{(row["ID"])}",
                    ForeColor = Color.FromArgb(158, 161, 176),
                    AutoSize = false,
                    Font = new Font(Font.Name, 16),
                    Size = new Size(flAppointments.Size.Width - 30, 30),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Text = i + @" | " + DateTime.Parse(row["datetime"].ToString()).ToString("HH:mm") + @" | " + row["fullname"],
                    Padding = Padding.Empty,
                    Margin = new Padding(0, 0, 0, 0)
                };


                var pnl = new Panel
                {
                    Name = $"panel{(row["ID"])}",
                    Size = new Size(flAppointments.Size.Width, 1),
                    BackColor = Color.FromArgb(158, 161, 176),
                    Padding = Padding.Empty,
                    Margin = new Padding(0, 0, 0, 0)
                };

                var img = new PictureBox
                {
                    Name = $"pic{(row["ID"])}",
                    Size = new Size(30, 30),
                    Image = Properties.Resources.delete_blue,
                    Visible = true,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Padding = Padding.Empty,
                    Margin = new Padding(0, 0, 0, 0),
                    Cursor = Cursors.Hand
                    

                };

                if (i % 2 == 0)
                {
                    img.BackColor = lbl.BackColor = Color.FromArgb(46, 51, 73);

                }
                else
                {
                    img.BackColor = lbl.BackColor = Color.FromArgb(37, 42, 64);
                }

                flAppointments.Controls.Add(lbl);
                flAppointments.Controls.Add(img);
                flAppointments.Controls.Add(pnl);
                i += 1;
                img.Click += (sender, eventArgs) => { delete_click(row["ID"].ToString()); };
                img.MouseEnter += (sender, eventArgs) => { delete_MouseEnter(img); };
                img.MouseLeave += (sender, eventArgs) => { delete_MouseLeave(img); };
            }
        }

        private void delete_click(string id)
        {
            var warning = new WarningForm(_cs, id);
            warning.ShowDialog();
            AddAppointmentToFlDay();
        }
        private static void delete_MouseEnter(PictureBox img)
        {
            img.Image = Properties.Resources.delete_red;
        }
        private static void delete_MouseLeave(PictureBox img)
        {
            img.Image = Properties.Resources.delete_blue;
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
