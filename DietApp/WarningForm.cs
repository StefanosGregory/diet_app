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
    public partial class WarningForm : Form
    {
        string _cs;
        string _id;
        public WarningForm(string cs, string id)
        {
            InitializeComponent();
            _cs = cs;
            _id = id;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void YesBtn_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection(_cs);
            conn.Open();
            string sql = $"DELETE FROM appointments WHERE id= '{_id}';";
            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            this.Close();
            
        }
    }
}
