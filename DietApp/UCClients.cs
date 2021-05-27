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
        private int _id;
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

            // Set ClientCard_pnl and info_pnl, history_pnl and diet_pnl settings.
            ClientCard_pnl.Visible = info_pnl.Visible = false;
            ClientCard_pnl.Location = new Point(3, 80);
            ClientCard_pnl.Size = new Size(930, 655);
            /*--- info panel ---*/
            info_pnl.Size = new Size(930, 600);
            //disable edit for cb, txts.
            info_fullname_txt.ReadOnly = info_age_txt.ReadOnly = info_allergies_txt.ReadOnly = info_tel_txt.ReadOnly = info_email_txt.ReadOnly = info_healthprobs_txt.ReadOnly = true;
            info_sex_cb.Enabled = false;
            // set location save,close btn
            info_save_btn.Location = info_edit_btn.Location;
            info_cancel_btn.Location = info_close_btn.Location;
        }
        
        /*
         * General methods.
         */
        private void FillDataGrid()
        {
            var conn = new NpgsqlConnection(Cs);
            conn.Open();
            var cmd = new NpgsqlCommand
            {
                Connection = conn,
                CommandText = "SELECT id, fullname, sex, tel, email FROM CLIENTS ORDER BY id ASC;"
            };

            var dr = cmd.ExecuteReader();
            if (!dr.HasRows) return;
            var dt = new DataTable();
            dt.Load(dr);
            showClients_pnl.DataSource = dt;
            foreach (DataGridViewBand band in showClients_pnl.Columns)
            {
                band.ReadOnly = true;
            }

            conn.Dispose();
            conn.Close();
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
        
        /*
         * AddClient_pnl methods.
         */
        
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

                ShowAll_pnl.Visible = AddClient_pnl.Visible = false;
                clients_lbl.Text = @"Client Info";
                ClientCard_pnl.Visible = true;
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

        /*
         * ShowAll_pnl methods. 
         */
        private void AddClient_btn_Click(object sender, EventArgs e)
        {
            //new AddClients().Show();
            ShowAll_pnl.Visible = false;

            AddClient_pnl.Visible = true;
            clients_lbl.Text = @"Add new client";
        }
        private void showClients_pnl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clients_lbl.Text = @"Client Info";
            ClientCard_pnl.Visible = info_pnl.Visible = true;
            ShowAll_pnl.Visible = AddClient_pnl.Visible = false;

            // Set back color of info_navBar_pnl
            info_navBar_pnl.BackColor = Color.FromArgb(46, 51, 73);
            
            var tmp = showClients_pnl.CurrentCell.RowIndex;
            _id = short.Parse(showClients_pnl.Rows[tmp].Cells["id"].Value.ToString());
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();
                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT * FROM clients WHERE id = @id;"
                };
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;

                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    info_fullname_txt.Text = reader[1].ToString();
                    info_sex_cb.Text = reader[2].ToString();
                    info_age_txt.Text = reader[3].ToString();
                    info_height_txt.Text = reader[4].ToString();
                    info_tel_txt.Text = reader[5].ToString();
                    info_email_txt.Text = reader[6].ToString();
                    info_allergies_txt.Text = reader[7].ToString();
                    info_healthprobs_txt.Text = reader[8].ToString();
                }

                conn.Dispose();
                conn.Close();
            }catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                    sql = "SELECT id, fullname, sex, tel, email FROM clients WHERE fullname LIKE @input; ORDER BY id ASC";
                    break;
                case "Telephone": 
                    sql = "SELECT id, fullname, sex, tel, email FROM clients WHERE tel = @input ORDER BY id ASC;";
                    break;
                case "Email":
                    sql = "SELECT id, fullname, sex, tel, email FROM clients WHERE email = @input ORDER BY id ASC;";
                    break;
                default:
                    sql = "SELECT id, fullname, sex, tel, email FROM clients;";
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
        

        /*
         * "Hover" methods on instert client form.
         */
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
        
        /*
         * info_pnl methods.
         */
        private void info_lbl_Click(object sender, EventArgs e)
        {
            info_pnl.Visible = true;
            //history_pnl.Visible = diet_pnl.Visible = false;
            info_navBar_pnl.BackColor = Color.FromArgb(46, 51, 73);
        }
        private void info_edit_btn_Click(object sender, EventArgs e)
        {
            // Enable edit for info_txts
            info_fullname_txt.ReadOnly = info_age_txt.ReadOnly = info_allergies_txt.ReadOnly = info_tel_txt.ReadOnly = info_email_txt.ReadOnly = info_healthprobs_txt.ReadOnly = false;
            info_sex_cb.Enabled = true;

            // Change visibility of info_edit_btn and info_close_btn buttons to false and true for info_save_btn and info_cancel_btn.
            info_edit_btn.Visible = info_close_btn.Visible = false;

            info_save_btn.Visible = info_cancel_btn.Visible = true;
        }
        private void info_save_btn_Click(object sender, EventArgs e)
        {
            if (info_fullname_txt.Text == "" || info_age_txt.Text == "" || info_allergies_txt.Text == "" || info_sex_cb.Text == "" || info_tel_txt.Text == "" || info_email_txt.Text == "" || info_height_txt.Text == "" || info_healthprobs_txt.Text == "") MessageBox.Show(@"You must fill all the fields.");
            else
            {
                if (info_age_txt.Text.All(char.IsDigit) && info_height_txt.Text.All(char.IsDigit) && info_tel_txt.Text.All(char.IsDigit) && IsValidEmail(email_txt.Text)) UpdateClient();
                else
                {
                    MessageBox.Show(!IsValidEmail(info_email_txt.Text)
                        ? @"Not valid email."
                        : @"Error age, height, telephone must be integers.");
                }
            }
        }
        private void UpdateClient()
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

                cmd.Parameters.Add("@fullname", NpgsqlDbType.Char).Value = info_fullname_txt.Text;
                cmd.Parameters.Add("@sex", NpgsqlDbType.Char).Value = info_sex_cb.Text;
                cmd.Parameters.Add("@age", NpgsqlDbType.Integer).Value = short.Parse(info_age_txt.Text);
                cmd.Parameters.Add("@height", NpgsqlDbType.Integer).Value = short.Parse(info_height_txt.Text);
                cmd.Parameters.Add("@telephone", NpgsqlDbType.Bigint).Value = long.Parse(info_tel_txt.Text);
                cmd.Parameters.Add("@email", NpgsqlDbType.Char).Value = info_email_txt.Text;
                cmd.Parameters.Add("@allergies", NpgsqlDbType.Char).Value = info_allergies_txt.Text;
                cmd.Parameters.Add("@healthprobs", NpgsqlDbType.Char).Value = info_healthprobs_txt.Text;
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    FillDataGrid();
                    MessageBox.Show(@"Client info updated successfully!");
                }
                else MessageBox.Show(@"Something went wrong!");
                
                // Disable edit for info_txts
                info_fullname_txt.ReadOnly = info_age_txt.ReadOnly = info_allergies_txt.ReadOnly = info_tel_txt.ReadOnly = info_email_txt.ReadOnly = info_healthprobs_txt.ReadOnly = true;
                info_sex_cb.Enabled = false ;

                // Change visibility of info_edit_btn and info_close_btn buttons to true and false for info_save_btn and info_cancel_btn.
                info_edit_btn.Visible = info_close_btn.Visible = true;
                info_save_btn.Visible = info_cancel_btn.Visible = false;
                
                conn.Dispose();
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void info_close_btn_Click(object sender, EventArgs e)
        {
            // Close ClientCard_pnl and open ShowAll_pnl
            ClientCard_pnl.Visible = false;
            ShowAll_pnl.Visible = true;

            // Reset colors and panels and client_lbl text
            info_navBar_pnl.BackColor = history_navBar_pnl.BackColor = diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            info_pnl.Visible = false;
            clients_lbl.Text = @"Clients";
        }
        private void info_cancel_btn_Click(object sender, EventArgs e)
        {
            // Disable edit for info_txts
            info_fullname_txt.ReadOnly = info_age_txt.ReadOnly = info_allergies_txt.ReadOnly = info_tel_txt.ReadOnly = info_email_txt.ReadOnly = info_healthprobs_txt.ReadOnly = true;
            info_sex_cb.Enabled = false ;

            // Change visibility of info_edit_btn and info_close_btn buttons to true and false for info_save_btn and info_cancel_btn.
            info_edit_btn.Visible = info_close_btn.Visible = true;
            info_save_btn.Visible = info_cancel_btn.Visible = false;
        }
    }
}
