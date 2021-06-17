using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp
{
    public partial class FoodInfoForm : Form
    {
        public FoodInfoForm(NutritionInfo details)
        {
            InitializeComponent();
            
            FillLabels(details);
        }
        
        private void FillLabels(NutritionInfo details)
        {
            foodname_lbl.Text = details.GetFoodName();
            calories_lbl.Text = details.GetCalories().ToString(CultureInfo.InvariantCulture);
            fat_lbl.Text = details.GetFat().ToString(CultureInfo.InvariantCulture);
            protein_lbl.Text = details.GetProtein().ToString(CultureInfo.InvariantCulture);
            carbohydrates_lbl.Text = details.GetCarbohydrates().ToString(CultureInfo.InvariantCulture);
            carbs_lbl.Text = details.GetCarbs().ToString(CultureInfo.InvariantCulture);
        }
        private void close_btn_click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
