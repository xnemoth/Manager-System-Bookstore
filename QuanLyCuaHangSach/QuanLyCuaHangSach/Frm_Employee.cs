using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class Frm_Employee : Form
    {
        ReEnterPass repass = new ReEnterPass();
        public Frm_Employee()
        {
            InitializeComponent();
        }

        private void btnFindNV_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable dt;
            sql = "SELECT * FROM T02_NhanVien WHERE 1=1";
            if (tbxMNV.Text != "")
            {
                sql = sql + " AND MaNhanVien LIKE N'%" + tbxMNV.Text + "%'";
            }
            if (tbxSDTNV.Text != "")
                sql = sql + " AND SoDienThoai='" + tbxSDTNV.Text + "'";
            if (tbxTNV.Text != "")
                sql = sql + " AND TenNhanVien LIKE N'%" + tbxTNV.Text + "%'";
            if (cbxP.Text != "")
                sql = sql + " AND Quyen=" + cbxP.SelectedValue;
            dt = Functions.GetDataToTable(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + dt.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvNV.DataSource = dt;
            loadDGVNV();
        }

        private void btnRSP_Click(object sender, EventArgs e)
        {
            string sql;
            DialogResult dlr;
            if (Frm_Login.Permission == 1)
            {
                if (tbxMNV.Text.Length == 0)
                    MessageBox.Show("Cần chọn nhân viên muốn reset password!");
                else
                {
                    sql = "SELECT TenNhanVien FROM T02_NhanVien WHERE MaNhanVien='" + tbxMNV.Text + "'";
                    dlr = MessageBox.Show("Bạn có muốn thay đổi mật khẩu cho nhân viên " + Functions.GetFieldValues(sql), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        sql = "UPDATE T02_NhanVien SET Password='" + tbxMK.Text.Trim().ToString() + "' WHERE MaNhanVien='" + tbxMNV.Text + "'";
                        try
                        {
                            Functions.RunSQL(sql);
                            MessageBox.Show("Cập nhật mật khẩu cho nhân viên " + tbxMNV.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sql = "SELECT * FROM T02_NhanVien";
                            DataTable dt = Functions.GetDataToTable(sql);
                            dgvNV.DataSource = dt;
                            if (tbxMNV.Text == Frm_Login.ma)
                                repass.pass = tbxMK.Text;
                        }
                        catch
                        {
                            MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                dlr = MessageBox.Show("Bạn có muốn thay đổi mật khẩu cho tài khoản không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    sql = "UPDATE T02_NhanVien SET Password='" + tbxMK.Text.Trim().ToString() + "' WHERE MaNhanVien='" + Frm_Login.ma + "'";
                    try
                    {
                        Functions.RunSQL(sql);
                        MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "SELECT * FROM T02_NhanVien WHERE MaNhanVien=N'" + Frm_Login.ma + "'";
                        DataTable dt = Functions.GetDataToTable(sql);
                        dgvNV.DataSource = dt;
                        repass.pass = tbxMK.Text;
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSaveNV_Click(object sender, EventArgs e)
        {
            string sql;
            DialogResult dlr;
            sql = "SELECT MaNhanVien FROM T02_NhanVien WHERE MaNhanVien='" + tbxMNV.Text + "'";
            if (Functions.GetFieldValues(sql) != "")
            {
                dlr = MessageBox.Show("Bạn có muốn cập nhật thông tin (trừ mật khẩu) cho nhân viên " + tbxMNV.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxTNV.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Tên nhân viên không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTNV.Focus();
                        return;
                    }
                    if (tbxSDTNV.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Số điện thoại liên lạc của nhân viên không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSDTNV.Focus();
                        return;
                    }
                    if (cbxP.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Tài khoản của nhân viên cần có phân quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbxP.Focus();
                        return;
                    }
                    sql = "UPDATE T02_NhanVien SET TenNhanVien=N'" + tbxTNV.Text + "', SoDienThoai='" + tbxSDTNV.Text
                        + "', Quyen='" + cbxP.SelectedValue + "' WHERE MaNhanVien='" + tbxMNV.Text + "'";
                    try
                    {
                        Functions.RunSQL(sql);
                        MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "SELECT * FROM T02_NhanVien";
                        DataTable dt = Functions.GetDataToTable(sql);
                        dgvNV.DataSource = dt;
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật thất bại!");
                    }
                }
            }
            else
            {
                dlr = MessageBox.Show("Bạn có muốn thêm nhân viên làm việc vào cửa hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxTNV.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập tên nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTNV.Focus();
                        return;
                    }
                    if (tbxSDTNV.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập số điện thoại liên lạc của nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSDTNV.Focus();
                        return;
                    }
                    if (tbxMK.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Nhân viên phải có tài khoản làm việc với mật khẩu nhất định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxMK.Focus();
                        return;
                    }
                    if (cbxP.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Cần phân quyền cho tài khoản của nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbxP.Focus();
                        return;
                    }
                    string autom;
                    autom = Functions.createKeyList(tbxTNV.Text);
                    autom = autom.ToUpper();
                    sql = "SELECT MaNhanVien FROM T02_NhanVien WHERE MaNhanVien='" + autom.Trim() + "'";
                    for (int i = 1; Functions.CheckKey(sql); i++)
                    {
                        if (autom.Length > 2)
                            autom = autom.Substring(0, autom.Length - 1) + i;
                        else
                            autom = autom + i;
                        sql = "SELECT MaNhanVien FROM T02_NhanVien WHERE MaNhanVien='" + autom.Trim() + "'";
                    }
                    sql = "INSERT INTO T02_NhanVien(MaNhanVien,TenNhanVien,SoDienThoai,Password,Quyen) Values('" + autom + "',N'" + tbxTNV.Text
                        + "','" + tbxSDTNV.Text + "','" + tbxMK.Text.Trim() + "'," + cbxP.SelectedValue + ")";
                    try
                    {
                        Functions.RunSQL(sql);
                        MessageBox.Show("Thêm thành công nhân viên " + tbxTNV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "SELECT * FROM T02_NhanVien";
                        DataTable dt = Functions.GetDataToTable(sql);
                        dgvNV.DataSource = dt;
                    }
                    catch
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
            }
        }

        private void dgvNV_CellCTC(object sender, DataGridViewCellEventArgs e)
        {
            tbxMNV.Text = dgvNV.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            tbxTNV.Text = dgvNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            tbxSDTNV.Text = dgvNV.CurrentRow.Cells["SoDienThoai"].Value.ToString();
            cbxP.SelectedValue = dgvNV.CurrentRow.Cells["Quyen"].Value;
            if (repass.pass == curentpass())
            {
                tbxMK.Text = dgvNV.CurrentRow.Cells["Password"].Value.ToString();
            }
            else
            {
                btnRSP.Enabled = false;
                tbxMK.Text = "*******";
            }
        }

        private void dgvNV_CellCTDC(object sender, DataGridViewCellEventArgs e)
        {
            if ((Frm_Login.Permission == 1) && (Frm_Login.ma != dgvNV.CurrentRow.Cells["MaNhanVien"].Value.ToString()))
            {
                string sql, ten;
                ten = dgvNV.CurrentRow.Cells["TenNhanVien"].Value.ToString();
                string manv = dgvNV.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa nhân viên " + ten + " khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    sql = "SELECT MaNhanVien FROM T08_HDB WHERE MaNhanVien=N'" + manv + "'";
                    DataTable dt = Functions.GetDataToTable(sql);
                    if (dt.Rows.Count == 0)
                    {
                        sql = "DELETE T02_NhanVien WHERE MaNhanVien='" + dgvNV.CurrentRow.Cells["MaNhanVien"].Value.ToString() + "'";
                        try
                        {
                            Functions.RunSQL(sql);
                            MessageBox.Show("Đã xóa nhân viên " + ten + " khỏi hệ thống?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sql = "SELECT * FROM T02_NhanVien";
                            dt = Functions.GetDataToTable(sql);
                            dgvNV.DataSource = dt;
                        }
                        catch
                        {
                            MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Không thể xóa, còn lưu giữ hóa đơn của nhân viên!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Không thể thao tác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmNV_load(object sender, EventArgs e)
        {
            repass.ShowDialog();
            if (repass.pass != curentpass())
            {
                MessageBox.Show("Password does not match!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRSP.Visible = false;
                btnSaveNV.Visible = false;
                btnTimNV.Visible = false;
            }
            else
                MessageBox.Show("Password match!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Frm_Login.Permission > 1)
            {
                btnSaveNV.Enabled = false;
                btnTimNV.Enabled = false;
                string sql = "SELECT * FROM T02_NhanVien WHERE MaNhanVien=N'" + Frm_Login.ma + "'";
                DataTable dt = Functions.GetDataToTable(sql);
                dgvNV.DataSource = dt;
                loadDGVNV();
            }
            else if ((Frm_Login.Permission == 1) && (repass.pass != curentpass()))
                this.Close();
            Functions.FillCombo("SELECT DISTINCT Quyen FROM T02_NhanVien", cbxP, "Quyen", "Quyen");
            cbxP.SelectedIndex = -1;
        }

        private void loadDGVNV()
        {
            dgvNV.Columns[0].HeaderText = "Mã nhân viên";
            dgvNV.Columns[1].HeaderText = "Tên nhân viên";
            dgvNV.Columns[2].HeaderText = "Số điện thoại";
            dgvNV.Columns[3].Visible = false;
            dgvNV.Columns[4].HeaderText = "Quyền hệ thống";
            dgvNV.Columns[0].Width = 150;
            dgvNV.Columns[1].Width = 300;
            dgvNV.Columns[2].Width = 250;
            dgvNV.Columns[3].Width = 120;
            dgvNV.AllowUserToAddRows = false;
            dgvNV.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private string curentpass()
        {
            string cpass, sql;
            sql = "SELECT Password FROM T02_NhanVien WHERE MaNhanVien='" + Frm_Login.ma + "'";
            cpass = Functions.GetFieldValues(sql);
            return cpass;
        }

        private void tbxMNV_TextChanged(object sender, EventArgs e)
        {
            if (tbxMNV.Text.Length == 0)
            {
                tbxSDTNV.Text = "";
                tbxTNV.Text = "";
                tbxMK.Text = "";
                cbxP.SelectedIndex = -1;
            }
        }
    }
}
