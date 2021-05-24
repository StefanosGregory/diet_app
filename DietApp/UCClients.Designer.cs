
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddClient_btn = new System.Windows.Forms.Button();
            this.EditClient_btn = new System.Windows.Forms.Button();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (37)))), ((int) (((byte) (42)))), ((int) (((byte) (64)))));
            this.panel1.Location = new System.Drawing.Point(43, 116);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 184);
            this.panel1.TabIndex = 3;
            // 
            // AddClient_btn
            // 
            this.AddClient_btn.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (37)))), ((int) (((byte) (42)))), ((int) (((byte) (64)))));
            this.AddClient_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.AddClient_btn.Location = new System.Drawing.Point(388, 103);
            this.AddClient_btn.Margin = new System.Windows.Forms.Padding(2);
            this.AddClient_btn.Name = "AddClient_btn";
            this.AddClient_btn.Size = new System.Drawing.Size(220, 41);
            this.AddClient_btn.TabIndex = 4;
            this.AddClient_btn.Text = "Add new Client";
            this.AddClient_btn.UseVisualStyleBackColor = false;
            this.AddClient_btn.Click += new System.EventHandler(this.AddClient_btn_Click);
            // 
            // EditClient_btn
            // 
            this.EditClient_btn.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (37)))), ((int) (((byte) (42)))), ((int) (((byte) (64)))));
            this.EditClient_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.EditClient_btn.Location = new System.Drawing.Point(388, 188);
            this.EditClient_btn.Margin = new System.Windows.Forms.Padding(2);
            this.EditClient_btn.Name = "EditClient_btn";
            this.EditClient_btn.Size = new System.Drawing.Size(220, 41);
            this.EditClient_btn.TabIndex = 5;
            this.EditClient_btn.Text = "Edit Client";
            this.EditClient_btn.UseVisualStyleBackColor = false;
            this.EditClient_btn.Click += new System.EventHandler(this.EditClient_btn_Click);
            // 
            // UCClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (46)))), ((int) (((byte) (51)))), ((int) (((byte) (73)))));
            this.Controls.Add(this.EditClient_btn);
            this.Controls.Add(this.AddClient_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UCClients";
            this.Size = new System.Drawing.Size(633, 665);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button EditClient_btn;

        private System.Windows.Forms.Button AddClient_btn;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
