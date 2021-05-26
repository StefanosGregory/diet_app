
namespace DietApp
{
    partial class UcClients
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.search_txt = new System.Windows.Forms.TextBox();
            this.searchType_cb = new System.Windows.Forms.ComboBox();
            this.clear_btn = new DietApp.RoundButtons();
            this.Search_btn = new DietApp.RoundButtons();
            this.AddClient_btn = new DietApp.RoundButtons();
            this.showClients_pnl = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize) (this.showClients_pnl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (158)))), ((int) (((byte) (161)))), ((int) (((byte) (176)))));
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clients";
            // 
            // search_txt
            // 
            this.search_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.search_txt.Location = new System.Drawing.Point(455, 101);
            this.search_txt.Name = "search_txt";
            this.search_txt.Size = new System.Drawing.Size(125, 23);
            this.search_txt.TabIndex = 9;
            // 
            // searchType_cb
            // 
            this.searchType_cb.DisplayMember = "Name";
            this.searchType_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchType_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.searchType_cb.FormattingEnabled = true;
            this.searchType_cb.Items.AddRange(new object[] {"Name", "Telephone", "Email"});
            this.searchType_cb.Location = new System.Drawing.Point(375, 101);
            this.searchType_cb.Name = "searchType_cb";
            this.searchType_cb.Size = new System.Drawing.Size(74, 21);
            this.searchType_cb.TabIndex = 10;
            this.searchType_cb.ValueMember = "Name";
            // 
            // clear_btn
            // 
            this.clear_btn.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (86)))), ((int) (((byte) (76)))), ((int) (((byte) (77)))));
            this.clear_btn.ButtonColor = System.Drawing.Color.FromArgb(((int) (((byte) (86)))), ((int) (((byte) (76)))), ((int) (((byte) (77)))));
            this.clear_btn.FlatAppearance.BorderSize = 0;
            this.clear_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.clear_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.clear_btn.Location = new System.Drawing.Point(681, 101);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (124)))), ((int) (((byte) (10)))), ((int) (((byte) (2)))));
            this.clear_btn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int) (((byte) (124)))), ((int) (((byte) (10)))), ((int) (((byte) (2)))));
            this.clear_btn.OnHoverTextColor = System.Drawing.Color.White;
            this.clear_btn.Size = new System.Drawing.Size(89, 23);
            this.clear_btn.TabIndex = 8;
            this.clear_btn.Text = "Clear";
            this.clear_btn.TextColor = System.Drawing.Color.White;
            this.clear_btn.UseVisualStyleBackColor = true;
            // 
            // Search_btn
            // 
            this.Search_btn.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (197)))), ((int) (((byte) (198)))), ((int) (((byte) (208)))));
            this.Search_btn.ButtonColor = System.Drawing.Color.FromArgb(((int) (((byte) (197)))), ((int) (((byte) (198)))), ((int) (((byte) (208)))));
            this.Search_btn.FlatAppearance.BorderSize = 0;
            this.Search_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.Search_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.Search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Search_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.Search_btn.ForeColor = System.Drawing.Color.White;
            this.Search_btn.Location = new System.Drawing.Point(586, 101);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (101)))), ((int) (((byte) (89)))), ((int) (((byte) (103)))));
            this.Search_btn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int) (((byte) (101)))), ((int) (((byte) (89)))), ((int) (((byte) (103)))));
            this.Search_btn.OnHoverTextColor = System.Drawing.Color.White;
            this.Search_btn.Size = new System.Drawing.Size(89, 23);
            this.Search_btn.TabIndex = 7;
            this.Search_btn.Text = "Search";
            this.Search_btn.TextColor = System.Drawing.Color.White;
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
            // 
            // AddClient_btn
            // 
            this.AddClient_btn.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (15)))), ((int) (((byte) (82)))), ((int) (((byte) (186)))));
            this.AddClient_btn.ButtonColor = System.Drawing.Color.FromArgb(((int) (((byte) (15)))), ((int) (((byte) (82)))), ((int) (((byte) (186)))));
            this.AddClient_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.AddClient_btn.FlatAppearance.BorderSize = 0;
            this.AddClient_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.AddClient_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.AddClient_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddClient_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.AddClient_btn.ForeColor = System.Drawing.Color.White;
            this.AddClient_btn.Location = new System.Drawing.Point(33, 101);
            this.AddClient_btn.Name = "AddClient_btn";
            this.AddClient_btn.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (128)))), ((int) (((byte) (255)))));
            this.AddClient_btn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (128)))), ((int) (((byte) (255)))));
            this.AddClient_btn.OnHoverTextColor = System.Drawing.Color.White;
            this.AddClient_btn.Size = new System.Drawing.Size(118, 23);
            this.AddClient_btn.TabIndex = 0;
            this.AddClient_btn.Text = "Add New";
            this.AddClient_btn.TextColor = System.Drawing.Color.White;
            this.AddClient_btn.UseVisualStyleBackColor = true;
            this.AddClient_btn.Click += new System.EventHandler(this.AddClient_btn_Click);
            // 
            // showClients_pnl
            // 
            this.showClients_pnl.AllowUserToAddRows = false;
            this.showClients_pnl.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (126)))), ((int) (((byte) (249)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (126)))), ((int) (((byte) (249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.showClients_pnl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.showClients_pnl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.showClients_pnl.BackgroundColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.showClients_pnl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.showClients_pnl.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.showClients_pnl.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (128)))), ((int) (((byte) (255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (15)))), ((int) (((byte) (82)))), ((int) (((byte) (186)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (15)))), ((int) (((byte) (82)))), ((int) (((byte) (186)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (128)))), ((int) (((byte) (255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.showClients_pnl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.showClients_pnl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (126)))), ((int) (((byte) (249)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.showClients_pnl.DefaultCellStyle = dataGridViewCellStyle3;
            this.showClients_pnl.EnableHeadersVisualStyles = false;
            this.showClients_pnl.GridColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.showClients_pnl.Location = new System.Drawing.Point(33, 156);
            this.showClients_pnl.Name = "showClients_pnl";
            this.showClients_pnl.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (126)))), ((int) (((byte) (249)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (126)))), ((int) (((byte) (249)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.showClients_pnl.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.showClients_pnl.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.showClients_pnl.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            this.showClients_pnl.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.showClients_pnl.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (126)))), ((int) (((byte) (249)))));
            this.showClients_pnl.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (126)))), ((int) (((byte) (249)))));
            this.showClients_pnl.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (20)))), ((int) (((byte) (30)))), ((int) (((byte) (54)))));
            this.showClients_pnl.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.showClients_pnl.Size = new System.Drawing.Size(898, 453);
            this.showClients_pnl.TabIndex = 11;
            this.showClients_pnl.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.showClients_pnl_CellValueChanged);
            // 
            // UcClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.Controls.Add(this.showClients_pnl);
            this.Controls.Add(this.searchType_cb);
            this.Controls.Add(this.search_txt);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.Search_btn);
            this.Controls.Add(this.AddClient_btn);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcClients";
            this.Size = new System.Drawing.Size(1067, 665);
            this.Load += new System.EventHandler(this.UcClients_Load);
            ((System.ComponentModel.ISupportInitialize) (this.showClients_pnl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button EditClient_btn;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private RoundButtons AddClient_btn;
        private DietApp.RoundButtons Search_btn;
        private DietApp.RoundButtons clear_btn;
        private System.Windows.Forms.TextBox search_txt;
        private System.Windows.Forms.ComboBox searchType_cb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView showClients_pnl;
    }
}
