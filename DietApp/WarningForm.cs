using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;

namespace DietApp
{
    public partial class WarningForm : Form
    {
        private readonly string _cs, _id;


        public WarningForm(string cs, string id)
        {
            InitializeComponent();
            _cs = cs;
            _id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var conn = new NpgsqlConnection(_cs);
                conn.Open();
                var sql = $"DELETE FROM appointments WHERE id= '{_id}';";
                var command = new NpgsqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException)
            {
                Console.WriteLine(@"ERROR!");
            }
            Close();
        }
    }
}
