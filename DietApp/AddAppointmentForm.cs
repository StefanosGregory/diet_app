using System;
using System.Windows.Forms;
using Npgsql;

namespace DietApp
{
    public partial class AddAppointmentForm : Form
    {

        private readonly string _cs;

        public AddAppointmentForm(string cs)
        {
            InitializeComponent();
            _cs = cs;
            FillCustomCombo();
        }

        private void FillCustomCombo()
        {
            try
            {
                var con = new NpgsqlConnection(_cs);
                con.Open();
                var cmd = new NpgsqlCommand("select fullname from clients order by id;", con);
                var sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    for (var i = 0; i < sdr.FieldCount; i++)
                    {
                        CustomerCBox.Items.Add(sdr.GetString(i));

                    }
                }
                sdr.Close();
                con.Close();
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var customer = CustomerCBox.SelectedIndex + 1;
            var date = datePicker.Value.ToString("yyyy-MM-dd");
            var time = timeCombo.Text;
            try
            {
                var conn = new NpgsqlConnection(_cs);
                conn.Open();
                var sql = $"insert into appointments values (Default, '{customer}', '{date + " " + time}')";
                var command = new NpgsqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }
    }
}
