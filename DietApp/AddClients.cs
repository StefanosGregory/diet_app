using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp
{
    public partial class AddClients : Form
    {
        public AddClients()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            if (fullname.Text == "" || comboBox1.SelectedItem == null || age.Text == "" || height.Text == "" || telephone.Text == "" || email.Text == "" || alergies.Text == "" || healthprob.Text == "")
            {

                MessageBox.Show("You must fill all the fields.");
               
            }
            else
            {
                IsValidEmail(email.Text);
                if (age.Text.All(char.IsDigit) && height.Text.All(char.IsDigit) && telephone.Text.All(char.IsDigit))
                {
                    MessageBox.Show("OK!");
                }
                else
                {
                    MessageBox.Show("Error, age,height,telephone must be numeric");
                }
               


            }
        }
       
        void IsValidEmail(string email)

        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                MessageBox.Show("Wrong type of mail");
            }
        }

        private void AddClients_Load(object sender, EventArgs e)
        {

        }

        private void fullname_TextChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}
