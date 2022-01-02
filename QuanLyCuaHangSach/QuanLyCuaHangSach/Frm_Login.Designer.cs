namespace QuanLyCuaHangSach
{
    partial class Frm_Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUM = new System.Windows.Forms.Button();
            this.cbSP = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.btnUM);
            this.panel1.Controls.Add(this.cbSP);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.tbxPassword);
            this.panel1.Controls.Add(this.tbxUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(41, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 165);
            this.panel1.TabIndex = 0;
            // 
            // btnUM
            // 
            this.btnUM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUM.BackgroundImage = global::QuanLyCuaHangSach.Properties.Resources.user_manual;
            this.btnUM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUM.Location = new System.Drawing.Point(343, 115);
            this.btnUM.Name = "btnUM";
            this.btnUM.Size = new System.Drawing.Size(70, 40);
            this.btnUM.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnUM, "Xem hướng dẫn sử dụng chương trình");
            this.btnUM.UseVisualStyleBackColor = true;
            this.btnUM.Click += new System.EventHandler(this.btnUM_Click);
            // 
            // cbSP
            // 
            this.cbSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSP.AutoSize = true;
            this.cbSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbSP.Font = new System.Drawing.Font("Roboto Mono", 8.747663F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSP.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cbSP.Location = new System.Drawing.Point(20, 122);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(131, 22);
            this.cbSP.TabIndex = 5;
            this.cbSP.Text = "Hiện mật khẩu";
            this.toolTip1.SetToolTip(this.cbSP, "Check để hiển thị mật khâỉ");
            this.cbSP.UseVisualStyleBackColor = true;
            this.cbSP.CheckedChanged += new System.EventHandler(this.cbSP_CC);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClear.BackColor = System.Drawing.Color.LightCyan;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Roboto Mono", 12.78505F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Lime;
            this.btnClear.Image = global::QuanLyCuaHangSach.Properties.Resources.btnclear;
            this.btnClear.Location = new System.Drawing.Point(159, 114);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 40);
            this.btnClear.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnClear, "Xóa trắng các trường đã nhập");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogin.BackColor = System.Drawing.Color.LightCyan;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Roboto Mono", 12.78505F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin.Image = global::QuanLyCuaHangSach.Properties.Resources.btnlogin;
            this.btnLogin.Location = new System.Drawing.Point(249, 114);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(70, 40);
            this.btnLogin.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnLogin, "Đăng nhập và tài khoản với thông tin phía trên");
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // tbxPassword
            // 
            this.tbxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPassword.BackColor = System.Drawing.Color.MintCream;
            this.tbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.78505F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPassword.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxPassword.Location = new System.Drawing.Point(217, 71);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(202, 29);
            this.tbxPassword.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbxPassword, "Nhập mật khẩu của tài khoản");
            this.tbxPassword.TextChanged += new System.EventHandler(this.tbxPW_TC);
            this.tbxPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_Keyup);
            // 
            // tbxUsername
            // 
            this.tbxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUsername.BackColor = System.Drawing.Color.MintCream;
            this.tbxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.78505F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxUsername.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxUsername.Location = new System.Drawing.Point(217, 30);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(202, 29);
            this.tbxUsername.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tbxUsername, "Nhập tên tài khoản là mã nhân viên (không phân biệt hoa thường)");
            this.tbxUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsername_Keyup);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Bisque;
            this.label2.Font = new System.Drawing.Font("Roboto Mono", 12.78505F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(20, 73);
            this.label2.MaximumSize = new System.Drawing.Size(180, 26);
            this.label2.MinimumSize = new System.Drawing.Size(180, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Bisque;
            this.label1.Font = new System.Drawing.Font("Roboto Mono", 12.78505F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.MaximumSize = new System.Drawing.Size(180, 26);
            this.label1.MinimumSize = new System.Drawing.Size(180, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Dael Calligraphy", 22.8785F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(19, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(485, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "QUẢN LÝ CỬA HÀNG SÁCH";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            this.toolTip1.ToolTipTitle = "Hướng dẫn sử dụng";
            // 
            // Frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(517, 281);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cửa hàng sách";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_Closing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox cbSP;
        private System.Windows.Forms.Button btnUM;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

