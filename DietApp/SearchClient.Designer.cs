using System.ComponentModel;

namespace DietApp
{
    partial class SearchClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.SearchClient_pnl = new System.Windows.Forms.Panel();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.searchClient_btn = new System.Windows.Forms.Button();
            this.email_txt = new System.Windows.Forms.TextBox();
            this.telephone_txt = new System.Windows.Forms.TextBox();
            this.fullname_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.results_pnl = new System.Windows.Forms.Panel();
            this.SearchClient_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchClient_pnl
            // 
            this.SearchClient_pnl.Controls.Add(this.cancel_btn);
            this.SearchClient_pnl.Controls.Add(this.searchClient_btn);
            this.SearchClient_pnl.Controls.Add(this.email_txt);
            this.SearchClient_pnl.Controls.Add(this.telephone_txt);
            this.SearchClient_pnl.Controls.Add(this.fullname_txt);
            this.SearchClient_pnl.Controls.Add(this.label5);
            this.SearchClient_pnl.Controls.Add(this.label4);
            this.SearchClient_pnl.Controls.Add(this.label2);
            this.SearchClient_pnl.Controls.Add(this.label1);
            this.SearchClient_pnl.Location = new System.Drawing.Point(0, 0);
            this.SearchClient_pnl.Name = "SearchClient_pnl";
            this.SearchClient_pnl.Size = new System.Drawing.Size(304, 231);
            this.SearchClient_pnl.TabIndex = 0;
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(154, 162);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(100, 33);
            this.cancel_btn.TabIndex = 10;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // searchClient_btn
            // 
            this.searchClient_btn.Location = new System.Drawing.Point(48, 162);
            this.searchClient_btn.Name = "searchClient_btn";
            this.searchClient_btn.Size = new System.Drawing.Size(100, 33);
            this.searchClient_btn.TabIndex = 9;
            this.searchClient_btn.Text = "Search";
            this.searchClient_btn.UseVisualStyleBackColor = true;
            this.searchClient_btn.Click += new System.EventHandler(this.searchClient_btn_Click);
            // 
            // email_txt
            // 
            this.email_txt.Location = new System.Drawing.Point(154, 99);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(100, 20);
            this.email_txt.TabIndex = 8;
            // 
            // telephone_txt
            // 
            this.telephone_txt.Location = new System.Drawing.Point(154, 76);
            this.telephone_txt.Name = "telephone_txt";
            this.telephone_txt.Size = new System.Drawing.Size(100, 20);
            this.telephone_txt.TabIndex = 7;
            // 
            // fullname_txt
            // 
            this.fullname_txt.Location = new System.Drawing.Point(154, 53);
            this.fullname_txt.Name = "fullname_txt";
            this.fullname_txt.Size = new System.Drawing.Size(100, 20);
            this.fullname_txt.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(48, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(48, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telephone:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(48, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Full Name:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(54, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find Client";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // results_pnl
            // 
            this.results_pnl.Location = new System.Drawing.Point(0, 237);
            this.results_pnl.Name = "results_pnl";
            this.results_pnl.Size = new System.Drawing.Size(304, 414);
            this.results_pnl.TabIndex = 1;
            this.results_pnl.Visible = false;
            // 
            // SearchClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 663);
            this.Controls.Add(this.results_pnl);
            this.Controls.Add(this.SearchClient_pnl);
            this.Name = "SearchClient";
            this.Text = "SearchClient";
            this.SearchClient_pnl.ResumeLayout(false);
            this.SearchClient_pnl.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel SearchClient_pnl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fullname_txt;
        private System.Windows.Forms.TextBox telephone_txt;
        private System.Windows.Forms.TextBox email_txt;
        private System.Windows.Forms.Button searchClient_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Panel results_pnl;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}