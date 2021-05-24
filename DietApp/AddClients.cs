using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace DietApp
{
    public partial class AddClients : Form
    {
        private readonly string _cs = "Host=localhost; Username=diet; Password=dietapp2021; Database=dietdb";

        public AddClients()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            if (fullname.Text == "" || sex.SelectedItem == null || age.Text == "" || height.Text == "" || telephone.Text == "" || email.Text == "" || alergies.Text == "" || healthprob.Text == "")
            {

                MessageBox.Show(@"You must fill all the fields.");
               
            }
            else
            {
                
                if (age.Text.All(char.IsDigit) && height.Text.All(char.IsDigit) && telephone.Text.All(char.IsDigit) && IsValidEmail(email.Text)) AddToDb();
                else
                {
                    MessageBox.Show(!IsValidEmail(email.Text)
                        ? @"Not valid email."
                        : @"Error age, height, telephone must be integers.");
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

        private void AddClients_Load(object sender, EventArgs e)
        {

        }

        private void telephone_MouseDown(object sender, MouseEventArgs e)
        {
            telephone.Clear();
        }

        private void email_MouseDown(object sender, MouseEventArgs e)
        {
            email.Clear();
        }

        private void telephone_MouseLeave(object sender, EventArgs e)
        {
            if (telephone.Text == "") telephone.Text = @"69********";
        }

        private void email_MouseLeave(object sender, EventArgs e)
        {
            if (email.Text == "") email.Text = @"example@example.com";
        }

        private void AddToDb()
        {
            const string sql = "insert into clients values (default, @fullname, @sex, @age, @height, @tel, @email, @alergies, @healthprobs)";
            
            using (var conn = new NpgsqlConnection(_cs))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@fullname", NpgsqlDbType.Char).Value = fullname.Text;
                        cmd.Parameters.Add("@sex", NpgsqlDbType.Char).Value = sex.Text;
                        cmd.Parameters.Add("@age", NpgsqlDbType.Integer).Value = short.Parse(age.Text);
                        cmd.Parameters.Add("@height", NpgsqlDbType.Integer).Value = short.Parse(height.Text);
                        cmd.Parameters.Add("@tel", NpgsqlDbType.Integer).Value = long.Parse(telephone.Text);
                        cmd.Parameters.Add("@email", NpgsqlDbType.Char).Value = email.Text;
                        cmd.Parameters.Add("@alergies", NpgsqlDbType.Char).Value = alergies.Text;
                        cmd.Parameters.Add("@healthprobs", NpgsqlDbType.Char).Value = healthprob.Text;

                        MessageBox.Show(cmd.ExecuteNonQuery() > 0
                            ? @"Client added successfully!"
                            : @"Something went wrong!");
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
