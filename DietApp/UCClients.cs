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
    public partial class UcClients : UserControl
    {
        public UcClients()
        {
            InitializeComponent();
        }

        private void AddClient_btn_Click(object sender, EventArgs e)
        {
            new AddClients().Show();
        }

        private void EditClient_btn_Click(object sender, EventArgs e)
        {
            // Code to open edit form.
        }
    }
}
