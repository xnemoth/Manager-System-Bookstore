namespace QuanLyCuaHangSach
{
    partial class Frm_Employee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Employee));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxTNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxMNV = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTimNV = new System.Windows.Forms.Button();
            this.btnSaveNV = new System.Windows.Forms.Button();
            this.btnRSP = new System.Windows.Forms.Button();
            this.tbxMK = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSDTNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.TT3 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.Controls.Add(this.tbxTNV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbxMNV);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbxP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnTimNV);
            this.panel1.Controls.Add(this.btnSaveNV);
            this.panel1.Controls.Add(this.btnRSP);
            this.panel1.Controls.Add(this.tbxMK);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbxSDTNV);
            this.panel1.Controls.Add(this.label2);
            this.panel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 151);
            this.panel1.TabIndex = 0;
            this.TT3.SetToolTip(this.panel1, "Để xóa nhân viên khỏi hệ thống, double click vào ô thông tin\r\ncủa nhân viên đó tr" +
        "ong dữ liệu phía dưới.");
            // 
            // tbxTNV
            // 
            this.tbxTNV.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxTNV.Location = new System.Drawing.Point(383, 10);
            this.tbxTNV.Margin = new System.Windows.Forms.Padding(4);
            this.tbxTNV.Name = "tbxTNV";
            this.tbxTNV.Size = new System.Drawing.Size(215, 25);
            this.tbxTNV.TabIndex = 19;
            this.TT3.SetToolTip(this.tbxTNV, resources.GetString("tbxTNV.ToolTip"));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tên nhân viên:";
            // 
            // tbxMNV
            // 
            this.tbxMNV.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxMNV.Location = new System.Drawing.Point(117, 10);
            this.tbxMNV.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMNV.Name = "tbxMNV";
            this.tbxMNV.Size = new System.Drawing.Size(141, 25);
            this.tbxMNV.TabIndex = 17;
            this.TT3.SetToolTip(this.tbxMNV, resources.GetString("tbxMNV.ToolTip"));
            this.tbxMNV.TextChanged += new System.EventHandler(this.tbxMNV_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "Mã nhân viên:";
            // 
            // cbxP
            // 
            this.cbxP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxP.ForeColor = System.Drawing.Color.RoyalBlue;
            this.cbxP.FormattingEnabled = true;
            this.cbxP.Location = new System.Drawing.Point(731, 10);
            this.cbxP.Margin = new System.Windows.Forms.Padding(4);
            this.cbxP.Name = "cbxP";
            this.cbxP.Size = new System.Drawing.Size(85, 26);
            this.cbxP.TabIndex = 15;
            this.TT3.SetToolTip(this.cbxP, resources.GetString("cbxP.ToolTip"));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(600, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Quyền hệ thống:";
            // 
            // btnTimNV
            // 
            this.btnTimNV.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTimNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimNV.Image = global::QuanLyCuaHangSach.Properties.Resources.search21;
            this.btnTimNV.Location = new System.Drawing.Point(599, 90);
            this.btnTimNV.Name = "btnTimNV";
            this.btnTimNV.Size = new System.Drawing.Size(58, 49);
            this.btnTimNV.TabIndex = 13;
            this.TT3.SetToolTip(this.btnTimNV, "Tìm kiếm nhân viên theo mã/ tên/ quyền/ số điện thoại.\r\nNếu không nhập bất cứ trư" +
        "ờng tìm kiếm nào sẽ cho danh sách tất cả nhân viên. Chức năng chỉ \r\ndùng cho tài" +
        " khoản quyền level 1.");
            this.btnTimNV.UseVisualStyleBackColor = false;
            this.btnTimNV.Click += new System.EventHandler(this.btnFindNV_Click);
            // 
            // btnSaveNV
            // 
            this.btnSaveNV.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSaveNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveNV.Image = global::QuanLyCuaHangSach.Properties.Resources.save;
            this.btnSaveNV.Location = new System.Drawing.Point(170, 90);
            this.btnSaveNV.Name = "btnSaveNV";
            this.btnSaveNV.Size = new System.Drawing.Size(58, 49);
            this.btnSaveNV.TabIndex = 10;
            this.TT3.SetToolTip(this.btnSaveNV, "Lưu/ cập nhật thông tin, nếu là nhân viên đã có với mã nhân viên\r\nphía trên, thôn" +
        "g tin các trường sẽ được câp nhật (trừ mật khẩu) nhân viên mới. Các thông tin cầ" +
        "n\r\nnhập đầy đủ.");
            this.btnSaveNV.UseVisualStyleBackColor = false;
            this.btnSaveNV.Click += new System.EventHandler(this.btnSaveNV_Click);
            // 
            // btnRSP
            // 
            this.btnRSP.BackColor = System.Drawing.Color.Aquamarine;
            this.btnRSP.BackgroundImage = global::QuanLyCuaHangSach.Properties.Resources.password_reset;
            this.btnRSP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRSP.Location = new System.Drawing.Point(380, 90);
            this.btnRSP.Name = "btnRSP";
            this.btnRSP.Size = new System.Drawing.Size(58, 49);
            this.btnRSP.TabIndex = 9;
            this.TT3.SetToolTip(this.btnRSP, "Cập nhật mật khẩu cho tài khoản. với quyền admin sẽ có thể thay đổi mật khẩu trên" +
        "\r\n tất cả tài khoản, với quyền thấp hơn sẽ không thể cập nhật cho các tài khoản " +
        "khác.");
            this.btnRSP.UseVisualStyleBackColor = false;
            this.btnRSP.Click += new System.EventHandler(this.btnRSP_Click);
            // 
            // tbxMK
            // 
            this.tbxMK.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxMK.Location = new System.Drawing.Point(612, 54);
            this.tbxMK.Margin = new System.Windows.Forms.Padding(4);
            this.tbxMK.Name = "tbxMK";
            this.tbxMK.Size = new System.Drawing.Size(204, 25);
            this.tbxMK.TabIndex = 5;
            this.TT3.SetToolTip(this.tbxMK, resources.GetString("tbxMK.ToolTip"));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu tài khoản:";
            // 
            // tbxSDTNV
            // 
            this.tbxSDTNV.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxSDTNV.Location = new System.Drawing.Point(127, 53);
            this.tbxSDTNV.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSDTNV.Name = "tbxSDTNV";
            this.tbxSDTNV.Size = new System.Drawing.Size(295, 25);
            this.tbxSDTNV.TabIndex = 3;
            this.TT3.SetToolTip(this.tbxSDTNV, "Số điện thoại nhân viên, chỉ thao tác khi cần thêm/ sửa/ tìm kiếm\r\nnhân viên (tất" +
        " cả chỉ thao tác trên quyền admin).");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvNV);
            this.panel2.Location = new System.Drawing.Point(1, 154);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 311);
            this.panel2.TabIndex = 1;
            // 
            // dgvNV
            // 
            this.dgvNV.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvNV.Location = new System.Drawing.Point(4, 4);
            this.dgvNV.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.Size = new System.Drawing.Size(820, 304);
            this.dgvNV.TabIndex = 0;
            this.dgvNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNV_CellCTC);
            this.dgvNV.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNV_CellCTDC);
            // 
            // TT3
            // 
            this.TT3.AutomaticDelay = 300;
            this.TT3.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TT3.ToolTipTitle = "Hướng dẫn sử dụng";
            // 
            // Frm_Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(830, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Font = new System.Drawing.Font("Roboto Mono", 8.747663F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhân sự";
            this.Load += new System.EventHandler(this.FrmNV_load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.TextBox tbxMK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSDTNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveNV;
        private System.Windows.Forms.Button btnRSP;
        private System.Windows.Forms.Button btnTimNV;
        private System.Windows.Forms.ComboBox cbxP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMNV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxTNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip TT3;
    }
}