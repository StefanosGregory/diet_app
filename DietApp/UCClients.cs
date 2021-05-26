using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public partial class UcClients : UserControl
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        public UcClients()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void UcClients_Load(object sender, EventArgs e)
        {
            searchType_cb.SelectedIndex = 0;

            // Set ShowAll_pnl settings.
            ShowAll_pnl.Size = new Size(1000, 570);
            ShowAll_pnl.Location = new Point(3, 80);
            ShowAll_pnl.Visible = true;

            // Set AddClient_pnl settings.
            AddClient_pnl.Size = new Size(410, 630);
            AddClient_pnl.Location = new Point(3, 80);
            AddClient_pnl.Visible = false;
        }

        private void FillDataGrid()
        {
            var conn = new NpgsqlConnection(Cs);
            conn.Open();
            var cmd = new NpgsqlCommand
            {
                Connection = conn,
                CommandText = "SELECT * FROM CLIENTS;"
            };
            
            var dr = cmd.ExecuteReader();
            if (!dr.HasRows) return;
            var dt = new DataTable();
            dt.Load(dr);
            showClients_pnl.DataSource = dt;
            showClients_pnl.Columns[0].ReadOnly = true;
            
            conn.Dispose();
            conn.Close();
        }
        
        private void AddClient_btn_Click(object sender, EventArgs e)
        {
            //new AddClients().Show();
            ShowAll_pnl.Visible = false;

            AddClient_pnl.Visible = true;
            clients_lbl.Text = @"Add new client";
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
            var clientRow = showClients_pnl.CurrentRow;

            if (clientRow.Cells["fullname"].Value.ToString() == "" || clientRow.Cells["sex"].Value.ToString() == "" || clientRow.Cells["age"].Value.ToString() == "" || clientRow.Cells["height"].Value.ToString() == "" || clientRow.Cells["tel"].Value.ToString() == "" || clientRow.Cells["email"].Value.ToString() == "" || clientRow.Cells["alergies"].Value.ToString() == "" || clientRow.Cells["healthprobs"].Value.ToString() == "") MessageBox.Show(@"You must fill all the fields.");
            else
            {
                if (clientRow.Cells["age"].Value.ToString().All(char.IsDigit) && clientRow.Cells["height"].Value.ToString().All(char.IsDigit) && clientRow.Cells["tel"].Value.ToString().All(char.IsDigit) && IsValidEmail(email_txt.Text)) UpdateClient(clientRow);
                else
                {
                    MessageBox.Show(!IsValidEmail(email_txt.Text)
                        ? @"Not valid email."
                        : @"Error age, height, telephone must be integers.");
                }
            }
            
        }

        private void UpdateClient(DataGridViewRow clientRow)
        {
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();
                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText =
                        "UPDATE clients SET fullname = @fullname, sex = @sex, age = @age, height = @height, tel = @telephone, email = @email, alergies = @allergies, healthprobs = @healthprobs WHERE id = @id;"
                };

                cmd.Parameters.Add("@fullname", NpgsqlDbType.Char).Value = clientRow.Cells["fullname"].Value.ToString();
                cmd.Parameters.Add("@sex", NpgsqlDbType.Char).Value = clientRow.Cells["sex"].Value.ToString();
                cmd.Parameters.Add("@age", NpgsqlDbType.Integer).Value = short.Parse(clientRow.Cells["age"].Value.ToString());
                cmd.Parameters.Add("@height", NpgsqlDbType.Integer).Value = short.Parse(clientRow.Cells["height"].Value.ToString());
                cmd.Parameters.Add("@telephone", NpgsqlDbType.Bigint).Value = long.Parse(clientRow.Cells["tel"].Value.ToString());
                cmd.Parameters.Add("@email", NpgsqlDbType.Char).Value = clientRow.Cells["email"].Value.ToString();
                cmd.Parameters.Add("@allergies", NpgsqlDbType.Char).Value = clientRow.Cells["alergies"].Value.ToString();
                cmd.Parameters.Add("@healthprobs", NpgsqlDbType.Char).Value = clientRow.Cells["healthprobs"].Value.ToString();
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = short.Parse(clientRow.Cells["id"].Value.ToString());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    FillDataGrid();
                    MessageBox.Show(@"Client info updated successfully!");
                }
                else MessageBox.Show(@"Something went wrong!");

                conn.Dispose();
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            ShowAll_pnl.Visible = true;
            AddClient_pnl.Visible = false;
            clients_lbl.Text = @"Clients";
        }

        private void AddToDb()
        {
            const string sql = "insert into clients values (default, @fullname, @sex, @age, @height, @tel, @email, @alergies, @healthprobs)";

            var conn = new NpgsqlConnection(Cs);
            try
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@fullname", NpgsqlDbType.Char).Value = fullname_txt.Text;
                    cmd.Parameters.Add("@sex", NpgsqlDbType.Char).Value = sex_cb.Text;
                    cmd.Parameters.Add("@age", NpgsqlDbType.Integer).Value = short.Parse(age_txt.Text);
                    cmd.Parameters.Add("@height", NpgsqlDbType.Integer).Value = short.Parse(height_txt.Text);
                    cmd.Parameters.Add("@tel", NpgsqlDbType.Bigint).Value = long.Parse(telephone_txt.Text);
                    cmd.Parameters.Add("@email", NpgsqlDbType.Char).Value = email_txt.Text;
                    cmd.Parameters.Add("@alergies", NpgsqlDbType.Char).Value = allergies_txt.Text;
                    cmd.Parameters.Add("@healthprobs", NpgsqlDbType.Char).Value = healthprob_txt.Text;

                    MessageBox.Show(cmd.ExecuteNonQuery() > 0
                        ? @"Client added successfully!"
                        : @"Something went wrong!");
                }
                
                conn.Dispose();
                conn.Close();
                    
                FillDataGrid();
                    
                AddClient_pnl.Visible = false;
                clients_lbl.Text = @"Clients";
                ShowAll_pnl.Visible = true;
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            if (fullname_txt.Text == "" || sex_cb.SelectedItem == null || age_txt.Text == "" || height_txt.Text == "" || telephone_txt.Text == "" || email_txt.Text == "" || allergies_txt.Text == "" || healthprob_txt.Text == "") MessageBox.Show(@"You must fill all the fields.");
            else
            {
                if (age_txt.Text.All(char.IsDigit) && height_txt.Text.All(char.IsDigit) && telephone_txt.Text.All(char.IsDigit) && IsValidEmail(email_txt.Text)) AddToDb();
                else
                {
                    MessageBox.Show(!IsValidEmail(email_txt.Text)
                        ? @"Not valid email."
                        : @"Error age, height, telephone must be integers.");
                }
            }
        }

        private void telephone_txt_MouseClick(object sender, MouseEventArgs e)
        {
            telephone_txt.Clear();
        }

        private void telephone_txt_MouseLeave(object sender, EventArgs e)
        {
            if (telephone_txt.Text == "") telephone_txt.Text = @"69********";
        }

        private void email_txt_MouseClick(object sender, MouseEventArgs e)
        {
            email_txt.Clear();
        }

        private void email_txt_MouseLeave(object sender, EventArgs e)
        {
            if (email_txt.Text == "") email_txt.Text = @"example@example.com";
        }

        private void showClients_pnl_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var clientRow = showClients_pnl.CurrentRow;
            if (clientRow != null && clientRow.Cells["id"].Value == null) return;
            if (MessageBox.Show(@"Are you sure you want to delete the selected client?", @"Warning",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "DELETE FROM clients WHERE id = @id;"
                };
                if (clientRow != null)
                    cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value =
                        short.Parse(clientRow.Cells["id"].Value.ToString());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(@"Client deleted successfully!");

                    // Reset sequence.
                    new NpgsqlCommand("ALTER SEQUENCE appointments_id_seq RESTART;", conn).ExecuteNonQuery();
                    new NpgsqlCommand("UPDATE appointments SET id = DEFAULT;", conn).ExecuteNonQuery();
                }
                else MessageBox.Show(@"Something went wrong! Please try again later.");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            search_txt.Clear();
            searchType_cb.SelectedIndex = 0;
        }
        
        private void Search_btn_Click(object sender, EventArgs e)
        {
            // 1) Get search type ( name, phone, email )
            var type = searchType_cb.SelectedItem.ToString();

            /* 2) Get search text input
             * 2a) If type == email check for valid.
             * 2b) telephone check validation
             */
            var input = search_txt.Text;
            switch (type)
            {
                case "Email" when !IsValidEmail(search_txt.Text):
                    MessageBox.Show(@"Invalid email.");
                    return;
                case "Telephone" when !input.All(char.IsDigit):
                    MessageBox.Show(@"Invalid phone number.");
                    return;
            }

            // 3) sql select command. Results in showClients_pnl
            if (input.Equals("")) return;
            var sql = "";
            switch (type)
            {
                case "Name":
                    sql = "SELECT * FROM clients WHERE fullname LIKE @input;";
                    break;
                case "Telephone": 
                    sql = "SELECT * FROM clients WHERE tel = @input;";
                    break;
                case "Email":
                    sql = "SELECT * FROM clients WHERE email = @input;";
                    break;
                default:
                    sql = "SELECT * FROM clients;";
                    break;
            };
                
            SearchWhere(sql, input, type);
        }

        private void SearchWhere(string sql, string input, string type)
        {
            MessageBox.Show(sql);
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = sql
                };

                if (type != "Telephone") cmd.Parameters.Add("@input", NpgsqlDbType.Char).Value = input;
                else cmd.Parameters.Add("@input", NpgsqlDbType.Bigint).Value = long.Parse(input);

                
                var dr = cmd.ExecuteReader();
                if (!dr.HasRows)
                {
                    MessageBox.Show(@"No results found.");
                    return;
                }
                var dt = new DataTable();
                dt.Load(dr);
                showClients_pnl.DataSource = dt;
                showClients_pnl.Columns[0].ReadOnly = true;

                conn.Dispose();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
