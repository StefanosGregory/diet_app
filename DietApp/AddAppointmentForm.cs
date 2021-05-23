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
    public partial class AddAppointmentForm : Form
    {

        private readonly string _cs;

        public AddAppointmentForm(string cs)
        {
            InitializeComponent();
            _cs = cs;
            fillCustomeCombo();
        }

        private void fillCustomeCombo()
        {
            try
            {
                var con = new NpgsqlConnection(_cs);
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select fullname from clients", con);
                NpgsqlDataReader Sdr;
                Sdr = cmd.ExecuteReader();
                while (Sdr.Read())
                {
                    for (int i = 0; i < Sdr.FieldCount; i++)
                    {
                        CustomerCBox.Items.Add(Sdr.GetString(i));

                    }
                }
                Sdr.Close();
                con.Close();
            }catch (Exception e)
            {
                MessageBox.Show("Error");
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            int customer = CustomerCBox.SelectedIndex + 1;
            string date = datePicker.Value.ToString("yyyy-MM-dd");
            string time = timeCombo.Text.ToString();
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
                MessageBox.Show("Error");
            }
            this.Close();
        }
    }
}
