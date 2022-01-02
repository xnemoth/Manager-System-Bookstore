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
    public partial class Frm_KH : Form
    {
        public Frm_KH()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable dt;
            DialogResult dlr;
            sql = "SELECT MaKhachHang FROM T03_KhachHang WHERE MaKhachHang='" + tbxMKH.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                dlr = MessageBox.Show("Chưa có dữ liệu khách hàng này, bạn có muốn thêm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    string makh = "KH";
                    sql = "SELECT MaKhachHang FROM T03_KhachHang WHERE MaKhachHang='" + makh + "'";
                    for (int i = 1; Functions.CheckKey(sql); i++)
                    {
                        if (makh.Length > 2)
                            makh = makh.Substring(0, makh.Length - 1) + i;
                        else
                            makh = makh + i;
                        sql = "SELECT MaKhachHang FROM T03_KhachHang WHERE MaKhachHang='" + makh + "'";
                    }
                    if (tbxTKH.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Phải nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxTKH.Focus();
                        return;
                    }
                    sql = "INSERT INTO T03_KhachHang(MaKhachHang,TenKhachHang,SoDienThoai) VALUES(N'" + makh + "', N'" + tbxTKH.Text + "', N'" + tbxSDT.Text + "')";
                    try
                    {
                        Functions.RunSQL(sql);
                        MessageBox.Show("Thêm thành công khách hàng " + tbxTKH.Text + " vào cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "SELECT * FROM T03_KhachHang";
                        dt = Functions.GetDataToTable(sql);
                        dgvKH.DataSource = dt;
                        loadDGVKH();
                    }
                    catch
                    {
                        MessageBox.Show("Thêm dữ liệu khách hàng thất bại!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                string tenkh;
                sql = "SELECT TenKhachHang FROM T03_KhachHang WHERE MaKhachHang='" + tbxMKH.Text + "'";
                tenkh = Functions.GetFieldValues(sql);
                dlr = MessageBox.Show("Bạn có muốn cập nhật thông tin cho khách hàng " + tenkh + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxTKH.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Tên khách hàng không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxTKH.Focus();
                        return;
                    }
                    sql = "UPDATE T03_KhachHang SET TenKhachHang=N'" + tbxTKH.Text + "', SoDienThoai='" + tbxSDT.Text + "' WHERE MaKhachHang='" + tbxMKH.Text + "'";
                    try
                    {
                        Functions.RunSQL(sql);
                        MessageBox.Show("Cập nhật thành công thông tin khách hàng " + tenkh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "SELECT * FROM T03_KhachHang";
                        dt = Functions.GetDataToTable(sql);
                        dgvKH.DataSource = dt;
                        loadDGVKH();
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật thông tin khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable dt;
            sql = "SELECT * FROM T03_KhachHang WHERE 1=1";
             if (tbxMKH.Text.Trim().Length != 0)
                 sql = sql + " AND MaKhachHang LIKE N'%" + tbxMKH.Text + "%'";
            if (tbxTKH.Text.Trim().Length != 0)
                sql = sql + " AND TenKhachHang LIKE N'%" + tbxTKH.Text + "%'";
            if (tbxSDT.Text.Trim().Length != 0)
                sql =sql + " AND SoDienThoai LIKE N'%" + tbxSDT.Text + "%'";
            dt = Functions.GetDataToTable(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + dt.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvKH.DataSource = dt;
            loadDGVKH();
        }

        private void dgvKH_CellCTC(object sender, DataGridViewCellEventArgs e)
        {
            tbxMKH.Text = dgvKH.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            tbxTKH.Text = dgvKH.CurrentRow.Cells["TenKhachHang"].Value.ToString();
            tbxSDT.Text = dgvKH.CurrentRow.Cells["SoDienThoai"].Value.ToString();
        }

        private void dgvKH_CellCTDC(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            string tenkh = dgvKH.CurrentRow.Cells["TenKhachHang"].Value.ToString();
            DialogResult dlr;
            DataTable dt;
            dlr = MessageBox.Show("Bạn có muốn xóa khách hàng " + tenkh + " khỏi cơ sở dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                sql = "SELECT MaKhachHang FROM T08_HDB WHERE MaKhachHang=N'" + dgvKH.CurrentRow.Cells["MaKhachHang"].Value.ToString() + "'";
                dt = Functions.GetDataToTable(sql);
                if (dt.Rows.Count == 0)
                {
                    sql = "DELETE T03_KhachHang WHERE MaKhachHang=N'" + dgvKH.CurrentRow.Cells["MaKhachHang"].Value.ToString() + "'";
                    try
                    {
                        Functions.RunSQL(sql);
                        MessageBox.Show("Xóa thành công khách hàng " + tenkh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sql = "SELECT * FROM T03_KhachHang";
                        dt = Functions.GetDataToTable(sql);
                        dgvKH.DataSource = dt;
                        loadDGVKH();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Không thể xóa, còn dữ liệu hóa đơn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadDGVKH()
        {
            dgvKH.Columns[0].HeaderText = "Mã khách hàng";
            dgvKH.Columns[0].Width = 150;
            dgvKH.Columns[1].HeaderText = "Tên khách hàng";
            dgvKH.Columns[1].Width = 307;
            dgvKH.Columns[2].HeaderText = "Số điện thoại khách hàng";
            dgvKH.Columns[2].Width = 330;
            dgvKH.AllowUserToAddRows = false;
            dgvKH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void tbxMKH_TC(object sender, EventArgs e)
        {
            if (tbxMKH.Text == "")
            {
                tbxTKH.Text = "";
                tbxSDT.Text = "";
            }
        }
    }
}
