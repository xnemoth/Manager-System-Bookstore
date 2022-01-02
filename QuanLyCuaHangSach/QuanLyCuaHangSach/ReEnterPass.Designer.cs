namespace QuanLyCuaHangSach
{
    partial class ReEnterPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReEnterPass));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxrepass = new System.Windows.Forms.TextBox();
            this.btnrepass = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu:";
            // 
            // tbxrepass
            // 
            this.tbxrepass.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxrepass.Location = new System.Drawing.Point(107, 28);
            this.tbxrepass.Margin = new System.Windows.Forms.Padding(4);
            this.tbxrepass.Name = "tbxrepass";
            this.tbxrepass.Size = new System.Drawing.Size(221, 25);
            this.tbxrepass.TabIndex = 1;
            this.tbxrepass.UseSystemPasswordChar = true;
            this.tbxrepass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbxrepass_KeyUp);
            // 
            // btnrepass
            // 
            this.btnrepass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnrepass.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnrepass.Location = new System.Drawing.Point(122, 74);
            this.btnrepass.Margin = new System.Windows.Forms.Padding(4);
            this.btnrepass.Name = "btnrepass";
            this.btnrepass.Size = new System.Drawing.Size(100, 32);
            this.btnrepass.TabIndex = 2;
            this.btnrepass.Text = "Xác nhận";
            this.btnrepass.UseVisualStyleBackColor = true;
            this.btnrepass.Click += new System.EventHandler(this.btnrepass_Click);
            // 
            // ReEnterPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(341, 119);
            this.Controls.Add(this.btnrepass);
            this.Controls.Add(this.tbxrepass);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Font = new System.Drawing.Font("Roboto Mono", 8.747663F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReEnterPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vui lòng nhập lại mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxrepass;
        private System.Windows.Forms.Button btnrepass;
    }
}