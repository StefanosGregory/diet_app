using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public partial class SearchClient : Form
    {
        private const string _cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        
        public SearchClient()
        {
            InitializeComponent();
            Size = SearchClient_pnl.Size;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchClient_btn_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(email_txt.Text) || email_txt.Text == "")
            {
                var sql = "SELECT * FROM clients WHERE fullname = @fullname OR age =  @age OR telephone = @telephone OR email = @email;";

                using (var conn = new NpgsqlConnection(_cs))
                {
                    try
                    {
                        conn.Open();

                        using (var cmd = new NpgsqlCommand(sql, conn))
                        {
                            cmd.Parameters.Add("@fullname", NpgsqlDbType.Char).Value = fullname_txt;
                            cmd.Parameters.Add("@age", NpgsqlDbType.Integer).Value = short.Parse(age_txt.Text);
                            cmd.Parameters.Add("@telephone", NpgsqlDbType.Bigint).Value =
                                long.Parse(telephone_txt.Text);

                            // Code to find all clients satisfying the conditions and add edit button next to it to edit it. 
                            
                            // Close current panel and open result panel.
                            // At result panel have to add labels like DayFormAppoint.
                            results_pnl.Visible = true;
                            SearchClient_pnl.Visible = false;
                            Size = SearchClient_pnl.Size;

                        }
                        
                        conn.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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
    }
}