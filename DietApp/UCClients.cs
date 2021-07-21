using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using Label = System.Windows.Forms.Label;

namespace DietApp
{
    public partial class UcClients : UserControl
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        private int _id, _height, _clienthistoryid;
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
            ClientCard_pnl.Visible = info_pnl.Visible = history_pnl.Visible = diet_pnl.Visible = false;
            ClientCard_pnl.Location = new Point(3, 80);
            ClientCard_pnl.Size = new Size(1110, 800);
            
            /*--- info_pnl ---*/
            info_pnl.Size = new Size(1110, 745);
            info_pnl.Location = new Point(0, 55);
            /* disable edit for cb, txts. */
            info_fullname_txt.ReadOnly = info_age_txt.ReadOnly = info_allergies_txt.ReadOnly = info_tel_txt.ReadOnly = info_email_txt.ReadOnly = info_healthprobs_txt.ReadOnly = true;
            info_sex_cb.Enabled = false;
            /* set location save,close btn */
            info_save_btn.Location = info_edit_btn.Location;
            info_cancel_btn.Location = info_close_btn.Location;

            /*--- history_pnl ---*/
            history_pnl.Size = new Size(1110, 745);
            history_pnl.Location = new Point(0, 55);
            history_editEntry_btn.Location = history_saveEntry_btn.Location = history_addEntry_btn.Location;
            history_clear_btn.Location = history_close_btn.Location;
            history_addEntry_btn.Size = history_clear_btn.Size = history_close_btn.Size = history_editEntry_btn.Size = history_saveEntry_btn.Size = history_showgraph_btn.Size = info_edit_btn.Size;
            
            /*--- diet_pnl ---*/
            diet_pnl.Size = new Size(1110, 745);
            diet_pnl.Location = new Point(0, 55);
            diet_diettype_cb.SelectedIndex = diet_type_cb.SelectedIndex = 0;
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
                CommandText = "SELECT id, fullname, height, sex, tel, email FROM CLIENTS ORDER BY id ASC;"
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
        private void history_checkUnfocus_Leave(object sender, EventArgs e)
        {
            if (history_weight_txt.Text.Equals("") && history_fatperc_txt.Text.Equals("") &&
                history_musclemass_txt.Text.Equals("") && history_visceralfat_txt.Text.Equals("") &&
                history_waterperc_txt.Text.Equals("")) return;
            
            history_close_btn.Visible = false;
            history_clear_btn.Visible = true;
            if (!history_weight_txt.Text.All(char.IsDigit) || history_weight_txt.Text.Length == 0) return;
            var kg = short.Parse(history_weight_txt.Text);
            var tmp = (double)_height / 100;
            var sqrHeight = Math.Pow(tmp, 2);
            var bmi = Math.Ceiling(kg / sqrHeight);
            history_bmi_txt.Text =  bmi.ToString();
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

                AddClient_pnl.Visible = false;
                clients_lbl.Text = @"Client Info";
                ShowAll_pnl.Visible = true;
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
            ClientCard_pnl.Visible = info_pnl.Visible = PnlNav_Info.Visible = true;
            ShowAll_pnl.Visible = AddClient_pnl.Visible = PnlNav_Diet.Visible = PnlNav_History.Visible = false;
            
            // Reset controls of info_pnl, history_pnl, diet_pnl.
            history_bmi_txt.Text = "";
            history_date_cb.Items.Clear();
            diet_date_cb.Items.Clear();
            history_pnl.Visible = diet_plan_pnl.Visible = diet_pnl.Visible = false;
            diet_gendiet_btn.Enabled = true;

            // Set back color of info_navBar_pnl, history_navBar_pnl and diet_navBar_pnl.
            info_navBar_pnl.BackColor = Color.FromArgb(46, 51, 73);
            info_lbl.ForeColor = Color.FromArgb(15, 82, 186);
            history_navBar_pnl.BackColor = diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            history_lbl.ForeColor = diet_lbl.ForeColor = Color.FromArgb(0, 126, 249);
            
            
            var tmp = showClients_pnl.CurrentCell.RowIndex;
            _height = short.Parse(showClients_pnl.Rows[tmp].Cells["height"].Value.ToString());
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

                var reader = cmd.ExecuteReader();
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

                conn = new NpgsqlConnection(Cs);
                conn.Open();
                cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT datetime FROM appointments WHERE clientsid = @id;"
                };
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    history_date_cb.Items.Add(reader[0].ToString());
                    diet_date_cb.Items.Add(reader[0].ToString());
                }

                history_date_cb.SelectedIndex = diet_date_cb.SelectedIndex = history_date_cb.Items.Count -1;
                conn.Dispose();
                conn.Close();
            }catch (SqlException ex)
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
            var sql = type switch
            {
                "Name" => "SELECT id, fullname, sex, tel, email FROM clients WHERE fullname ~*@input ORDER BY id ASC",
                "Telephone" => "SELECT id, fullname, sex, tel, email FROM clients WHERE tel = @input ORDER BY id ASC;",
                "Email" => "SELECT id, fullname, sex, tel, email FROM clients WHERE email = @input ORDER BY id ASC;",
                _ => "SELECT id, fullname, sex, tel, email FROM clients ORDER BY id ASC;"
            };

            SearchWhere(sql, input, type);
        }
        private void SearchWhere(string sql, string input, string type)
        {
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
         * "Hover" methods on insert client form.
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
            info_pnl.Visible = PnlNav_Info.Visible = true;
            history_pnl.Visible = diet_pnl.Visible = PnlNav_Diet.Visible = PnlNav_History.Visible = false;
            
            info_navBar_pnl.BackColor = Color.FromArgb(46, 51, 73);
            info_lbl.ForeColor = Color.FromArgb(15, 82, 186);
            history_navBar_pnl.BackColor = diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            history_lbl.ForeColor = diet_lbl.ForeColor = Color.FromArgb(0, 126, 249);
        }
        private void info_lbl_MouseEnter(object sender, EventArgs e)
        {
            if (info_pnl.Visible)
            {
                info_lbl.Cursor = Cursors.Default;
                return;
            }
            info_navBar_pnl.BackColor = Color.FromArgb(37, 42, 64);
            info_lbl.ForeColor = Color.FromArgb(0, 126, 249);
        }
        private void info_lbl_MouseLeave(object sender, EventArgs e)
        {
            if (info_pnl.Visible) return;
            info_lbl.Cursor = Cursors.Hand;
            info_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            info_lbl.ForeColor = Color.FromArgb(0, 126, 249);
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
            ClientCard_pnl.Visible = history_pnl.Visible = diet_pnl.Visible = history_editEntry_btn.Visible = history_saveEntry_btn.Visible = history_showgraph_btn.Visible = false;
            ShowAll_pnl.Visible = info_pnl.Visible = history_addEntry_btn.Visible = history_close_btn.Visible = true;
            history_date_cb.Items.Clear();

            // Reset colors and panels and client_lbl text
            info_navBar_pnl.BackColor = history_navBar_pnl.BackColor = diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            info_lbl.ForeColor = history_lbl.ForeColor = diet_lbl.ForeColor = Color.FromArgb(0, 126, 249);
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
        
        
        /*
         * history_pnl methods.
         */
        private void history_lbl_Click(object sender, EventArgs e)
        {
            // Setting visibility to true for history_pnl and false for info_pnl and diet_pnl.
            history_pnl.Visible = PnlNav_History.Visible = true;
            info_pnl.Visible = diet_pnl.Visible = PnlNav_Diet.Visible = PnlNav_Info.Visible = false;
            
            history_navBar_pnl.BackColor = Color.FromArgb(46, 51, 73);
            history_lbl.ForeColor = Color.FromArgb(15, 82, 186);
            info_navBar_pnl.BackColor = diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            info_pnl.ForeColor = diet_pnl.ForeColor = Color.FromArgb(0, 126, 249);
        }
        private void history_lbl_MouseEnter(object sender, EventArgs e)
        {
            if (history_pnl.Visible)
            {
                history_lbl.Cursor = Cursors.Default;
                return;
            }
            history_navBar_pnl.BackColor = Color.FromArgb(37, 42, 64);
            history_lbl.ForeColor = Color.FromArgb(0, 126, 249);
        }
        private void history_lbl_MouseLeave(object sender, EventArgs e)
        {
            if (history_pnl.Visible) return;
            history_lbl.Cursor = Cursors.Hand;
            history_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            history_lbl.ForeColor = Color.FromArgb(0, 126, 249);
        }
        private void history_date_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText = "SELECT * FROM clientshistory WHERE datetime = @datetime;"
                };

                cmd.Parameters.Add("@datetime", NpgsqlDbType.Timestamp).Value = DateTime.Parse(history_date_cb.Text);
                
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    history_entry_lbl.Text = @"Previous Entry";
                    while (reader.Read())
                    {
                        _clienthistoryid = short.Parse(reader[0].ToString());
                        history_weight_txt.Text = reader[3].ToString();
                        history_fatperc_txt.Text = reader[4].ToString();
                        history_musclemass_txt.Text = reader[5].ToString();
                        history_bmi_txt.Text = reader[6].ToString();
                        history_visceralfat_txt.Text = reader[7].ToString();
                        history_waterperc_txt.Text = reader[8].ToString();
                    }
                    
                    history_addEntry_btn.Enabled = history_weight_txt.Enabled = history_fatperc_txt.Enabled = history_musclemass_txt.Enabled = history_waterperc_txt.Enabled = history_visceralfat_txt.Enabled = history_saveEntry_btn.Visible = false;
                    history_editEntry_btn.Visible = history_close_btn.Visible = true;
                }
                else
                {
                    history_entry_lbl.Text = @"New Entry";
                    history_addEntry_btn.Enabled = history_weight_txt.Enabled = history_fatperc_txt.Enabled = history_musclemass_txt.Enabled = history_waterperc_txt.Enabled = history_visceralfat_txt.Enabled = true; 
                    history_weight_txt.Text = history_fatperc_txt.Text = history_musclemass_txt.Text = history_waterperc_txt.Text = history_visceralfat_txt.Text = "";
                }

                conn.Dispose();
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void history_close_btn_Click(object sender, EventArgs e)
        {
            // Close ClientCard_pnl and open ShowAll_pnl
            ClientCard_pnl.Visible = history_pnl.Visible = diet_pnl.Visible = history_editEntry_btn.Visible = history_saveEntry_btn.Visible = history_showgraph_btn.Visible = false;
            ShowAll_pnl.Visible = info_pnl.Visible = history_addEntry_btn.Visible = history_close_btn.Visible = true;
            history_date_cb.Items.Clear();

            // Reset colors and panels and client_lbl text
            info_navBar_pnl.BackColor = history_navBar_pnl.BackColor = diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            info_lbl.ForeColor = history_lbl.ForeColor = diet_lbl.ForeColor = Color.FromArgb(0, 126, 249);
            info_pnl.Visible = false;
            history_entry_lbl.Text = @"New Entry";
            clients_lbl.Text = @"Clients";
        }
        private void history_clear_btn_Click(object sender, EventArgs e)
        {
            history_weight_txt.Text = history_fatperc_txt.Text = history_musclemass_txt.Text = history_visceralfat_txt.Text = history_waterperc_txt.Text = history_bmi_txt.Text = "";

            history_clear_btn.Visible = false;
            history_close_btn.Visible = true;
        }
        private void history_addEntry_btn_Click(object sender, EventArgs e)
        {
            if (history_weight_txt.Text.Equals("") || history_fatperc_txt.Text.Equals("") || history_musclemass_txt.Text.Equals("") || history_visceralfat_txt.Text.Equals("") || history_waterperc_txt.Text.Equals("")) MessageBox.Show(@"You must fill all textbox!");
            else
            {
                if (history_weight_txt.Text.All(char.IsDigit) && history_bmi_txt.Text.All(char.IsDigit) && history_fatperc_txt.Text.All(char.IsDigit) && history_musclemass_txt.Text.All(char.IsDigit) && history_visceralfat_txt.Text.All(char.IsDigit) && history_waterperc_txt.Text.All(char.IsDigit)) history_addEntry();
            }
        }
        private void history_addEntry()
        {
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand()
                {
                    Connection = conn,
                    CommandText =
                        "INSERT INTO clientshistory VALUES(default, @id, @datetime, @kg, @fatperc, @musclemass, @bmi, @visceralfat, @waterperc);"
                };
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;
                cmd.Parameters.Add("@datetime", NpgsqlDbType.Timestamp).Value = DateTime.Parse(history_date_cb.Text);
                cmd.Parameters.Add("@kg", NpgsqlDbType.Integer).Value = short.Parse(history_weight_txt.Text);
                cmd.Parameters.Add("@fatperc", NpgsqlDbType.Integer).Value = short.Parse(history_fatperc_txt.Text);
                cmd.Parameters.Add("@musclemass", NpgsqlDbType.Integer).Value = short.Parse(history_musclemass_txt.Text);
                cmd.Parameters.Add("@bmi", NpgsqlDbType.Integer).Value = short.Parse(history_bmi_txt.Text);
                cmd.Parameters.Add("@visceralfat", NpgsqlDbType.Integer).Value =
                    short.Parse(history_visceralfat_txt.Text);
                cmd.Parameters.Add("@waterperc", NpgsqlDbType.Integer).Value = short.Parse(history_waterperc_txt.Text);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(@"Entry added successfully!");
                    history_close_btn.Visible = history_editEntry_btn.Visible = true;
                    history_clear_btn.Visible = history_addEntry_btn.Visible = false;
                    history_weight_txt.Enabled = history_fatperc_txt.Enabled = history_musclemass_txt.Enabled = history_waterperc_txt.Enabled = history_visceralfat_txt.Enabled = false;

                    var tmpConn = new NpgsqlConnection(Cs);
                    tmpConn.Open();

                    var tmpCmd = new NpgsqlCommand
                    {
                        Connection = tmpConn,
                        CommandText = "SELECT id FROM clientshistory WHERE datetime = @datetime and clientsid = @id;"
                    };
                    tmpCmd.Parameters.Add("@datetime", NpgsqlDbType.Timestamp).Value =
                        DateTime.Parse(history_date_cb.Text);
                    tmpCmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;

                    var reader = tmpCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        _clienthistoryid = short.Parse(reader[0].ToString());
                    }
                    tmpConn.Dispose();
                    tmpConn.Close();
                }
                
                
                conn.Dispose();
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void history_editEntry_btn_Click(object sender, EventArgs e)
        {
            history_clear_btn.Visible = history_editEntry_btn.Visible = false;
            history_close_btn.Visible = history_saveEntry_btn.Visible = true;
            history_weight_txt.Enabled = history_fatperc_txt.Enabled = history_musclemass_txt.Enabled = history_waterperc_txt.Enabled = history_visceralfat_txt.Enabled = true;
        }
        private void history_saveEntry_btn_Click(object sender, EventArgs e)
        {
            if (history_weight_txt.Text.Equals("") || history_fatperc_txt.Text.Equals("") || history_musclemass_txt.Text.Equals("") || history_visceralfat_txt.Text.Equals("") || history_waterperc_txt.Text.Equals("")) MessageBox.Show(@"You must fill all textbox!");
            else
            {
                if (history_weight_txt.Text.All(char.IsDigit) && history_bmi_txt.Text.All(char.IsDigit) && history_fatperc_txt.Text.All(char.IsDigit) && history_musclemass_txt.Text.All(char.IsDigit) && history_visceralfat_txt.Text.All(char.IsDigit) && history_waterperc_txt.Text.All(char.IsDigit)) history_updateEntry();
            }
        }
        private void history_updateEntry()
        {
            try
            {
                var conn = new NpgsqlConnection(Cs);
                conn.Open();

                var cmd = new NpgsqlCommand
                {
                    Connection = conn,
                    CommandText =
                        "UPDATE clientshistory SET kg = @kg, fatperc = @fatperc, musclemass = @musclemass, bmi = @bmi, visceralfat = @visceralfat, waterperc = @waterperc WHERE clientsid = @id;"
                };
                cmd.Parameters.Add("@kg", NpgsqlDbType.Integer).Value = short.Parse(history_weight_txt.Text);
                cmd.Parameters.Add("@fatperc", NpgsqlDbType.Integer).Value = short.Parse(history_fatperc_txt.Text);
                cmd.Parameters.Add("@musclemass", NpgsqlDbType.Integer).Value =
                    short.Parse(history_musclemass_txt.Text);
                cmd.Parameters.Add("@bmi", NpgsqlDbType.Integer).Value = short.Parse(history_bmi_txt.Text);
                cmd.Parameters.Add("@visceralfat", NpgsqlDbType.Integer).Value =
                    short.Parse(history_visceralfat_txt.Text);
                cmd.Parameters.Add("@waterperc", NpgsqlDbType.Integer).Value = short.Parse(history_waterperc_txt.Text);
                cmd.Parameters.Add("@id", NpgsqlDbType.Integer).Value = _id;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show(@"Entry updated successfully!");
                    history_addEntry_btn.Visible = true;
                    history_addEntry_btn.Enabled = history_saveEntry_btn.Visible = false;
                }
                else
                {
                    MessageBox.Show(@"Something went wrong!");
                }
                
                conn.Dispose();
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /*
         * diet_pnl methods.
         */
        private void diet_lbl_Click(object sender, EventArgs e)
        {
            diet_pnl.Visible = PnlNav_Diet.Visible = true;
            info_pnl.Visible = history_pnl.Visible = PnlNav_History.Visible = PnlNav_Info.Visible = false;

            diet_navBar_pnl.BackColor = Color.FromArgb(46, 51, 73);
            diet_lbl.ForeColor = Color.FromArgb(15, 82, 186);
            history_navBar_pnl.BackColor = info_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            history_lbl.ForeColor = info_lbl.ForeColor = Color.FromArgb(0, 126, 249);
            
            // Change data of clientshistoryid in case of measures did not exist while creating new diet plan.
            
            diet_date_cb_SelectedIndexChanged(null, null);
        }
        private void diet_lbl_MouseEnter(object sender, EventArgs e)
        {
            if (diet_pnl.Visible)
            {
                diet_lbl.Cursor = Cursors.Default;
                return;
            }
            diet_navBar_pnl.BackColor = Color.FromArgb(37, 42, 64);
            diet_lbl.ForeColor = Color.FromArgb(0, 126, 249);
        }
        private void diet_lbl_MouseLeave(object sender, EventArgs e)
        {
            if (diet_pnl.Visible) return;
            diet_lbl.Cursor = Cursors.Hand;
            diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            diet_lbl.ForeColor = Color.FromArgb(0, 126, 249);
        }
        private void diet_gendiet_btn_Click(object sender, EventArgs e)
        {
            /*
             * If diet_date.cb, diet_diettype_cb and diet_type_cb are empty return.
             * Create new diet plan.
             * Display diet plan.
             */
            if (diet_date_cb.Text.Equals("") || diet_diettype_cb.Text.Equals("") || diet_type_cb.Text.Equals("")) return;
            var diet = new GenerationOfDiet(diet_type_cb.Text, diet_diettype_cb.Text, DateTime.Parse(diet_date_cb.Text), _id, _clienthistoryid);
            
            if (diet.GetClientType() == null && diet.GetDietType() == null) return;
            DisplayDiet(diet.GetDays());
            diet_gendiet_btn.Enabled = false;
            diet_plan_pnl.Visible = true;
        }
        private void diet_close_btn_Click(object sender, EventArgs e)
        {
            // Close ClientCard_pnl and open ShowAll_pnl
            ClientCard_pnl.Visible = info_pnl.Visible = history_pnl.Visible = diet_pnl.Visible = history_editEntry_btn.Visible = history_saveEntry_btn.Visible = history_showgraph_btn.Visible = diet_plan_pnl.Visible = false;
            ShowAll_pnl.Visible = info_pnl.Visible = history_addEntry_btn.Visible = history_close_btn.Visible = true;
            history_date_cb.Items.Clear();
            diet_date_cb.Items.Clear();

            // Reset colors and panels and client_lbl text
            info_navBar_pnl.BackColor = history_navBar_pnl.BackColor = diet_navBar_pnl.BackColor = Color.FromArgb(20, 30, 54);
            info_lbl.ForeColor = history_lbl.ForeColor = diet_lbl.ForeColor = Color.FromArgb(0, 126, 249);
            history_entry_lbl.Text = @"New Entry";
            clients_lbl.Text = @"Clients";
        }
        private void diet_date_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * If selected date is already registered in db display entry on diet_plan_pnl.
             * We need to display diet_type_cb and diet_diettype_cb of old diet plan.
             * If diet+plan_pnl.Visible is false then SelectedIndexChanged wont be executed.
             * If returned value of _clientType and _dietType are null that means no data is stored for this date.
             * diet_type_cb and diet_diettype_cb must be disabled.
             * Calling DisplayDiet method to display diet plan.
             */
            if (!diet_pnl.Visible) return;
            diet_gendiet_btn.Enabled = diet_type_cb.Enabled = diet_diettype_cb.Enabled = true;
            var showOld = new GenerationOfDiet(_id, _clienthistoryid, DateTime.Parse(diet_date_cb.Text));
            if (diet_date_cb.SelectedIndex == diet_date_cb.Items.Count - 1 && showOld.GetClientType() == null && showOld.GetDietType() == null) return;
            if (showOld.GetClientType() == null || showOld.GetDietType() == null)
            {
                diet_plan_pnl.Visible = false;
                MessageBox.Show(@"No diet found for the selected date.");
                return;
            }
            diet_diettype_cb.Enabled = diet_type_cb.Enabled = diet_gendiet_btn.Enabled = false;
            diet_diettype_cb.Text = showOld.GetDietType();
            diet_type_cb.Text = showOld.GetClientType();
            DisplayDiet(showOld.GetDays());
            diet_plan_pnl.Visible = true;
        }
        private void DisplayDiet(IEnumerable<List<NutritionInfo>> days) 
        {
            /*
             * Reset controls of diet_plan_pnl.
             * Display old or new generated diet.
             * For display old and new diet plan,
             * both methods must give as a parameter a list of list of NutritionInfo type.
             */
            diet_plan_pnl.Visible = false;
            for (var row = 1; row < diet_plan_pnl.RowCount; row++)
            {
                for (var col = 1; col < diet_plan_pnl.ColumnCount; col++)
                {
                    // Reset diet_plan_pnl.
                    diet_plan_pnl.Controls.Remove(diet_plan_pnl.GetControlFromPosition(col, row));
                }
            }
            var column = 1;
            foreach (var day in days)
            {
                var row = 1;
                foreach (var details in day)
                {
                    var lbl = new Label
                    {
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Text = row == 7
                            ? details.GetTotalCalories().ToString(CultureInfo.InvariantCulture)
                            : details.GetFoodName()
                    };
                    if (row != 7)
                    {
                        lbl.Cursor = Cursors.Hand;
                        lbl.Click += (sender, args) => { new FoodInfoForm(details).Show(); };
                    }
                    diet_plan_pnl.Controls.Add(lbl, column, row);
                    row++;
                }
                column++;
            }
        }
    }
}
