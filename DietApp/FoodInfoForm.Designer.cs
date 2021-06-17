
namespace DietApp
{
    partial class FoodInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.calories_lbl = new System.Windows.Forms.Label();
            this.calories = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.close_btn = new System.Windows.Forms.Button();
            this.foodname_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fat_lbl = new System.Windows.Forms.Label();
            this.fat = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.protein_lbl = new System.Windows.Forms.Label();
            this.proteins = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.carbohydrates_lbl = new System.Windows.Forms.Label();
            this.carbohydrates = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.carbs_lbl = new System.Windows.Forms.Label();
            this.carbs = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.calories_lbl);
            this.panel4.Controls.Add(this.calories);
            this.panel4.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(13, 42);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(357, 41);
            this.panel4.TabIndex = 8;
            // 
            // calories_lbl
            // 
            this.calories_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.calories_lbl.AutoSize = true;
            this.calories_lbl.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calories_lbl.Location = new System.Drawing.Point(279, 13);
            this.calories_lbl.Name = "calories_lbl";
            this.calories_lbl.Size = new System.Drawing.Size(62, 20);
            this.calories_lbl.TabIndex = 5;
            this.calories_lbl.Text = "calories";
            // 
            // calories
            // 
            this.calories.AutoSize = true;
            this.calories.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.calories.Location = new System.Drawing.Point(8, 13);
            this.calories.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.calories.Name = "calories";
            this.calories.Size = new System.Drawing.Size(76, 18);
            this.calories.TabIndex = 4;
            this.calories.Text = "Calories:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.close_btn);
            this.panel3.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(13, 291);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(357, 61);
            this.panel3.TabIndex = 11;
            // 
            // close_btn
            // 
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.Font = new System.Drawing.Font("Nirmala UI", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.ForeColor = System.Drawing.Color.Tomato;
            this.close_btn.Location = new System.Drawing.Point(125, 10);
            this.close_btn.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(94, 40);
            this.close_btn.TabIndex = 8;
            this.close_btn.Text = "Close";
            this.close_btn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_click);
            // 
            // foodname_lbl
            // 
            this.foodname_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.foodname_lbl.AutoSize = true;
            this.foodname_lbl.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodname_lbl.Location = new System.Drawing.Point(9, 10);
            this.foodname_lbl.Name = "foodname_lbl";
            this.foodname_lbl.Size = new System.Drawing.Size(98, 21);
            this.foodname_lbl.TabIndex = 14;
            this.foodname_lbl.Text = "Food Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.fat_lbl);
            this.panel1.Controls.Add(this.fat);
            this.panel1.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(13, 87);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 41);
            this.panel1.TabIndex = 15;
            // 
            // fat_lbl
            // 
            this.fat_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fat_lbl.AutoSize = true;
            this.fat_lbl.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fat_lbl.Location = new System.Drawing.Point(280, 12);
            this.fat_lbl.Name = "fat_lbl";
            this.fat_lbl.Size = new System.Drawing.Size(29, 20);
            this.fat_lbl.TabIndex = 5;
            this.fat_lbl.Text = "fat";
            this.fat_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fat
            // 
            this.fat.AutoSize = true;
            this.fat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.fat.Location = new System.Drawing.Point(8, 13);
            this.fat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fat.Name = "fat";
            this.fat.Size = new System.Drawing.Size(37, 18);
            this.fat.TabIndex = 4;
            this.fat.Text = "Fat:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.protein_lbl);
            this.panel2.Controls.Add(this.proteins);
            this.panel2.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(13, 132);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 41);
            this.panel2.TabIndex = 16;
            // 
            // protein_lbl
            // 
            this.protein_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.protein_lbl.AutoSize = true;
            this.protein_lbl.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.protein_lbl.Location = new System.Drawing.Point(279, 13);
            this.protein_lbl.Name = "protein_lbl";
            this.protein_lbl.Size = new System.Drawing.Size(60, 20);
            this.protein_lbl.TabIndex = 5;
            this.protein_lbl.Text = "protein";
            // 
            // proteins
            // 
            this.proteins.AutoSize = true;
            this.proteins.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proteins.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.proteins.Location = new System.Drawing.Point(8, 13);
            this.proteins.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.proteins.Name = "proteins";
            this.proteins.Size = new System.Drawing.Size(76, 18);
            this.proteins.TabIndex = 4;
            this.proteins.Text = "Proteins:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.carbohydrates_lbl);
            this.panel5.Controls.Add(this.carbohydrates);
            this.panel5.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(13, 177);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(357, 41);
            this.panel5.TabIndex = 17;
            // 
            // carbohydrates_lbl
            // 
            this.carbohydrates_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.carbohydrates_lbl.AutoSize = true;
            this.carbohydrates_lbl.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carbohydrates_lbl.Location = new System.Drawing.Point(280, 12);
            this.carbohydrates_lbl.Name = "carbohydrates_lbl";
            this.carbohydrates_lbl.Size = new System.Drawing.Size(65, 20);
            this.carbohydrates_lbl.TabIndex = 5;
            this.carbohydrates_lbl.Text = "carbohy";
            this.carbohydrates_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // carbohydrates
            // 
            this.carbohydrates.AutoSize = true;
            this.carbohydrates.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carbohydrates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.carbohydrates.Location = new System.Drawing.Point(8, 13);
            this.carbohydrates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.carbohydrates.Name = "carbohydrates";
            this.carbohydrates.Size = new System.Drawing.Size(123, 18);
            this.carbohydrates.TabIndex = 4;
            this.carbohydrates.Text = "Carbohydrates:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel6.Controls.Add(this.carbs_lbl);
            this.panel6.Controls.Add(this.carbs);
            this.panel6.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(13, 222);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(357, 41);
            this.panel6.TabIndex = 18;
            // 
            // carbs_lbl
            // 
            this.carbs_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.carbs_lbl.AutoSize = true;
            this.carbs_lbl.Font = new System.Drawing.Font("Nirmala UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carbs_lbl.Location = new System.Drawing.Point(280, 12);
            this.carbs_lbl.Name = "carbs_lbl";
            this.carbs_lbl.Size = new System.Drawing.Size(46, 20);
            this.carbs_lbl.TabIndex = 5;
            this.carbs_lbl.Text = "carbs";
            this.carbs_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // carbs
            // 
            this.carbs.AutoSize = true;
            this.carbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carbs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.carbs.Location = new System.Drawing.Point(8, 13);
            this.carbs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.carbs.Name = "carbs";
            this.carbs.Size = new System.Drawing.Size(58, 18);
            this.carbs.TabIndex = 4;
            this.carbs.Text = "Carbs:";
            // 
            // FoodInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(381, 368);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.foodname_lbl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FoodInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FoodInfoForm";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label calories;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label carolies_lbl;
        private System.Windows.Forms.Label foodname_lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label fat_lbl;
        private System.Windows.Forms.Label fat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label proteins;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label carbohydrates_lbl;
        private System.Windows.Forms.Label carbohydrates;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label carbs_lbl;
        private System.Windows.Forms.Label carbs;
        private System.Windows.Forms.Label calories_lbl;
        private System.Windows.Forms.Label protein_lbl;
    }
}