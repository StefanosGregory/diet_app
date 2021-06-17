using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public partial class WarningForm : Form
    {
        private readonly string _cs;
        private readonly int _id;
        
        public WarningForm(string cs, string id)
        {
            InitializeComponent();
            _cs = cs;
            _id = short.Parse(id);
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
                var command = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "DELETE FROM appointments WHERE id = @id;"
                };
                command.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;
                if (command.ExecuteNonQuery() > 0)
                {
                    // Reset sequence.
                    const string resetseq = "ALTER SEQUENCE appointments_id_seq RESTART;";
                    new NpgsqlCommand(resetseq, conn).ExecuteNonQuery();
                    const string updateseq = "UPDATE appointments SET id = DEFAULT;";
                    new NpgsqlCommand(updateseq, conn).ExecuteNonQuery();
                }
                
                conn.Dispose();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(@"You cannot delete this entry.");
            }
            Close();
        }
    }
}
