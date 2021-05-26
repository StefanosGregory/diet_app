using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public partial class UcClients : UserControl
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        private readonly NpgsqlConnection _conn;
        public UcClients()
        {
            InitializeComponent();


            _conn = new NpgsqlConnection(Cs);
            _conn.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = _conn;
            cmd.CommandText = "SELECT * FROM CLIENTS;";
            var dr = cmd.ExecuteReader();
            if (!dr.HasRows) return;
            var dt = new DataTable();
            dt.Load(dr);
            showClients_pnl.DataSource = dt;
            
            _conn.Dispose();
            _conn.Close();
        }

        private void UcClients_Load(object sender, EventArgs e)
        {
            searchType_cb.SelectedIndex = 0;
        }

        private void AddClient_btn_Click(object sender, EventArgs e)
        {
            new AddClients().Show();
        }

        private void EditClient_btn_Click(object sender, EventArgs e)
        {
            // Code to open edit form.
            new SearchClient().Show();
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            // 1) Get search type ( name, phone, email )
            var type = searchType_cb.SelectedItem;

            /* 2) Get search text input
             * 2a) If type == email check for valid.
             */
            var input = search_txt.Text;
            if (type.Equals("Email") && !IsValidEmail(search_txt.Text)) MessageBox.Show(@"Invalid email.");

            // 3) sql select command. Results in showClients_pnl
            
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void showClients_pnl_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Update client.
            if (showClients_pnl.CurrentRow == null) return;
            _conn.Open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.CommandText = "UPDATE clients SET ";
            }
        }
    }
}
