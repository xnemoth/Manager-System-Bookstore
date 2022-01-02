namespace QuanLyCuaHangSach
{
    partial class Frm_KH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_KH));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbxTKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TT4 = new System.Windows.Forms.ToolTip(this.components);
            this.Paneldgv = new System.Windows.Forms.Panel();
            this.dgvKH = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.Paneldgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Bisque;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.tbxTKH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbxSDT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxMKH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu khách hàng";
            this.TT4.SetToolTip(this.groupBox1, "Để xóa khách hàng double click vào ô dữ liệu khách hàng\r\nphía dưới.");
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Plum;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Image = global::QuanLyCuaHangSach.Properties.Resources.search2;
            this.btnSearch.Location = new System.Drawing.Point(677, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(65, 60);
            this.btnSearch.TabIndex = 9;
            this.TT4.SetToolTip(this.btnSearch, "Tìm khách hàng theo mã/ tên/ số điện thoại. Nếu không nhập bất cứ\r\nđiều kiện tìm " +
        "kiếm nào thì sẽ cho về danh sách tất cả khách hàng của cửa hàng.\r\n");
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Plum;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = global::QuanLyCuaHangSach.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(573, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 60);
            this.btnSave.TabIndex = 8;
            this.TT4.SetToolTip(this.btnSave, resources.GetString("btnSave.ToolTip"));
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbxTKH
            // 
            this.tbxTKH.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxTKH.Location = new System.Drawing.Point(137, 73);
            this.tbxTKH.Name = "tbxTKH";
            this.tbxTKH.Size = new System.Drawing.Size(391, 25);
            this.tbxTKH.TabIndex = 7;
            this.TT4.SetToolTip(this.tbxTKH, "Tên kháchh hàng, trường này cần nhập khi muốn tìm kiếm hoặc thêm\r\nkhách hàng mới." +
        "");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên khách hàng:";
            // 
            // tbxSDT
            // 
            this.tbxSDT.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxSDT.Location = new System.Drawing.Point(349, 30);
            this.tbxSDT.Name = "tbxSDT";
            this.tbxSDT.Size = new System.Drawing.Size(179, 25);
            this.tbxSDT.TabIndex = 5;
            this.TT4.SetToolTip(this.tbxSDT, "Số điện thoại liên lạc của khách hàng (nếu có), trường này\r\ncần nhập khi muốn tìm" +
        " khách hàng theo số điện thoại hay muốn\r\n cập nhật thông tin số điện thoại khách" +
        " hàng.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số điện thoại:";
            // 
            // tbxMKH
            // 
            this.tbxMKH.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tbxMKH.Location = new System.Drawing.Point(129, 31);
            this.tbxMKH.Name = "tbxMKH";
            this.tbxMKH.Size = new System.Drawing.Size(94, 25);
            this.tbxMKH.TabIndex = 1;
            this.TT4.SetToolTip(this.tbxMKH, "Mã khách hàng trong hệ thống, được tự động tạo khi thêm\r\n dữ liệu khách hàng, trư" +
        "ờng này chỉ cần thao tác khi muốn tìm\r\nkiếm khách hàng theo mã.");
            this.tbxMKH.TextChanged += new System.EventHandler(this.tbxMKH_TC);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng:";
            // 
            // TT4
            // 
            this.TT4.AutomaticDelay = 300;
            this.TT4.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TT4.ToolTipTitle = "Hướng dẫn sử dụng";
            // 
            // Paneldgv
            // 
            this.Paneldgv.Controls.Add(this.dgvKH);
            this.Paneldgv.Location = new System.Drawing.Point(6, 128);
            this.Paneldgv.Name = "Paneldgv";
            this.Paneldgv.Size = new System.Drawing.Size(787, 325);
            this.Paneldgv.TabIndex = 1;
            // 
            // dgvKH
            // 
            this.dgvKH.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvKH.Location = new System.Drawing.Point(0, 0);
            this.dgvKH.Name = "dgvKH";
            this.dgvKH.Size = new System.Drawing.Size(787, 325);
            this.dgvKH.TabIndex = 0;
            this.dgvKH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKH_CellCTC);
            this.dgvKH.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKH_CellCTDC);
            // 
            // Frm_KH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(799, 458);
            this.Controls.Add(this.Paneldgv);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Font = new System.Drawing.Font("Roboto Mono", 8.747663F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(815, 500);
            this.MinimumSize = new System.Drawing.Size(815, 500);
            this.Name = "Frm_KH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dữ liệu khách hàng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Paneldgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxSDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxTKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip TT4;
        private System.Windows.Forms.Panel Paneldgv;
        private System.Windows.Forms.DataGridView dgvKH;
    }
}