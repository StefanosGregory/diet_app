using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public partial class SearchClient : Form
    {
        private const string Cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";
        
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
            results_pnl.Width = 1000;
            results_pnl.Height = 500;
            if (!IsValidEmail(email_txt.Text) && email_txt.Text != "") return;
            const string sql = "SELECT * FROM clients WHERE fullname = @fullname OR email = @email;";

            using (var cmd = new NpgsqlConnection(Cs).CreateCommand())
            {
                try
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("@fullname", NpgsqlDbType.Char).Value = fullname_txt.Text;
                    /*cmd.Parameters.Add("@telephone", NpgsqlDbType.Bigint).Value = long.Parse(telephone_txt.Text);*/
                    cmd.Parameters.Add("@email", NpgsqlDbType.Char).Value = email_txt.Text;

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
                            Size = new Size(results_pnl.Size.Width - 30, 30),
                            ForeColor = Color.FromArgb(158, 161, 176),
                            AutoSize = true,
                            Font = new Font(Font.Name, 16),
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
                            Location = new Point(results_pnl.Width - 50, 30 * i),
                            Padding = Padding.Empty,
                            Margin = new Padding(0, 0, 0, 0),
                            Cursor = Cursors.Hand,
                            Visible = true
                        };
                        
                        results_pnl.Controls.Add(lbl);
                        results_pnl.Controls.Add(btn);
                        btn.Click += (o, args) => { edit_btn_click(row["id"].ToString()); };

                        i++;
                    }
                    // Code to find all clients satisfying the conditions and add edit button next to it to edit it. 

                    // Close current panel and open result panel.
                    // At result panel have to add labels like DayFormAppoint.
                    results_pnl.Location = new Point(0, 0);
                    Width = results_pnl.Width + 20;
                    results_pnl.Visible = true;
                    SearchClient_pnl.Visible = false;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static void edit_btn_click(string id)
        {
            //
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