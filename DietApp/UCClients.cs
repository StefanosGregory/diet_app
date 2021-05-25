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
using NpgsqlTypes;

namespace DietApp
{
    public partial class UcClients : UserControl
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        public UcClients()
        {
            InitializeComponent();
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
            

            using (var cmd = new NpgsqlConnection(Cs).CreateCommand())
            {
                var sql = "";
                switch (type)
                {
                    case "Name":
                        sql = "SELECT * FROM clients WHERE fullname = @input;";
                        cmd.CommandText = sql;
                        cmd.Parameters.Add("@input", NpgsqlDbType.Char).Value = input;
                        break;
                    case "Telephone":
                        sql = "SELECT * FROM clients WHERE tel = @telephone;";
                        cmd.CommandText = sql;
                        cmd.Parameters.Add("@telephone", NpgsqlDbType.Bigint).Value = long.Parse(input);
                        break;
                    case "Email":
                        sql = "SELECT * FROM clients WHERE email = @email;";
                        cmd.CommandText = sql;
                        cmd.Parameters.Add("@email", NpgsqlDbType.Char).Value = input;
                        break;
                    default:
                        MessageBox.Show(@"You must select the input type from the dropbox menu!");
                        break;
                }

                try
                {
                    IDbDataAdapter da = new NpgsqlDataAdapter();
                    da.SelectCommand = cmd;
                    var ds = new DataSet();
                    da.Fill(ds);
                    var dt = ds.Tables[0];
                    var i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        var lbl = new Label
                        {
                            Name = $"link{(row["ID"])}",
                            Size = new Size(showClients_pnl.Size.Width - 30, 30),
                            ForeColor = Color.FromArgb(158, 161, 176),
                            AutoSize = true,
                            Font = new Font(Font.Name, 11),
                            TextAlign = ContentAlignment.MiddleLeft,
                            Text = (i + 1 ) + @" | " + row["fullname"] + @" | " + row["sex"] + @" | " + row["age"] + @" | " + row["height"] + @" | " + row["tel"] + @" | " + row["email"] + @" | " + row["alergies"] + @" | " + row["healthprobs"],
                            Padding = Padding.Empty,
                            Margin = new Padding(0, 0, 0, 0)
                        };

                        var btn = new Button
                        {
                            Text = @"Edit",
                            ForeColor = Color.FromArgb(158, 161, 176),
                            Font = new Font(Font.Name, 16),
                            //Size = new Size(50, 30),
                            AutoSize = true,
                            Location = new Point(showClients_pnl.Width - 50, 30 * i),
                            Padding = Padding.Empty,
                            Margin = new Padding(0, 0, 0, 0),
                            Cursor = Cursors.Hand,
                            Visible = true
                        };
                        
                        showClients_pnl.Controls.Add(lbl);
                        showClients_pnl.Controls.Add(btn);
                        //btn.Click += (o, args) => { edit_btn_click(row["id"].ToString()); };

                        i++;
                    }
                }
                catch (NpgsqlException exception)
                {
                    MessageBox.Show(exception.Message);
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
