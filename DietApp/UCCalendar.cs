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
    public partial class UCCalendar : UserControl
    {
        public UCCalendar()
        {
            InitializeComponent();
            timer1.Enabled = true;
            liveTimeLbl.Visible = true;

        }

        private void UCCalendar_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            liveTimeLbl.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
