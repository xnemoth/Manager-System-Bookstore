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
    public partial class Frm_Book : Form
    {
        public Frm_Book()
        {
            InitializeComponent();
        }


        private void btab1_Enter(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaLoai FROM T06_TheLoai", cbxLS, "MaLoai", "MaLoai");
            cbxLS.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaLoai,TheLoai FROM T06_TheLoai", cbxLS2, "MaLoai", "TheLoai");
            cbxLS2.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNXB,TenNXB FROM T05_NXB", cbxNXB, "MaNXB", "TenNXB");
            cbxNXB.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaTacGia,TenTacGia FROM T04_TacGia", cbxTG, "MaTacGia", "TenTacGia");
            cbxTG.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaGian,ViTri FROM T07_Gian", cbxVT, "MaGian", "ViTri");
            cbxVT.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaSach,TenSach FROM T01_Sach", cbxTenSach, "MaSach", "TenSach");
            cbxTenSach.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaGian FROM T07_Gian", cbxMaGian, "MaGian", "MaGian");
            cbxMaGian.SelectedIndex = -1;
        }

        private void btab2_Enter(object sender, EventArgs e)
        {
            LoadDGVTG();
            Functions.FillCombo("SELECT MaTacGia, TenTacGia FROM T04_TacGia", cbxMTG, "TenTacGia", "MaTacGia");
            cbxMTG.SelectedIndex = -1;
        }

        private void btab3_Enter(object sender, EventArgs e)
        {
            loadDGVNXB();
            Functions.FillCombo("SELECT MaNXB, TenNXB FROM T05_NXB", cbxMaNXB, "MaNXB", "MaNXB");
            cbxMaNXB.SelectedIndex = -1;
        }

        private void FrmBook_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sql, key = "";
            sql = "SELECT TheLoai FROM T06_TheLoai WHERE TheLoai=N'" + tbxCSLS.Text + "'";
            if (Functions.CheckKey(sql))
                MessageBox.Show("Đã có nhóm sách này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (tbxCSLS.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên nhóm sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxCSLS.Focus();
                    return;
                }
                key = Functions.createKeyList(tbxCSLS.Text);
                key = key.ToUpper();
                sql = "SELECT MaLoai FROM T06_TheLoai WHERE MaLoai=N'" + key + "'";
                for (int i = 1; Functions.CheckKey(sql); i++)
                {
                    key = Functions.createKeyList(tbxCSLS.Text) + i;
                    key = key.ToUpper();
                    sql = "SELECT MaLoai FROM T06_TheLoai WHERE MaLoai=N'" + key + "'";
                }
                try
                {
                    sql = "INSERT INTO T06_TheLoai(MaLoai,TheLoai) VALUES (N'" + key.Trim() + "',N'" + tbxCSLS.Text + "')";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Đã thêm nhóm sách " + tbxCSLS.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Functions.FillCombo("SELECT MaLoai,TheLoai FROM T06_TheLoai", cbxLS, "MaLoai", "MaLoai");
            cbxLS.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaLoai,TheLoai FROM T06_TheLoai", cbxLS2, "MaLoai", "TheLoai");
            cbxLS2.SelectedIndex = -1;
        }

        private void cbxLS_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxLS.Text == "")
                tbxCSLS.Text = "";
            else
            {
                str = "SELECT TheLoai FROM T06_TheLoai WHERE MaLoai= N'" + cbxLS.SelectedValue + "'";
                tbxCSLS.Text = Functions.GetFieldValues(str);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaLoai FROM T06_TheLoai WHERE MaLoai=N'" + cbxLS.SelectedValue + "'";
            if (!Functions.CheckKey(sql))
            {
                MessageBox.Show("Chưa có nhóm sách này để chỉnh sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (tbxCSLS.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Tên nhóm sách không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxCSLS.Focus();
                    return;
                }
                DialogResult dlr = MessageBox.Show("Bạn có muốn cập nhật nhóm sách " + tbxCSLS.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    sql = "UPDATE T06_TheLoai SET TheLoai=N'" + tbxCSLS.Text + "' WHERE MaLoai=N'" + cbxLS.SelectedValue + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Cập nhật thành công nhóm sách " + tbxCSLS.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Functions.FillCombo("SELECT MaLoai,TheLoai FROM T06_TheLoai", cbxLS, "MaLoai", "MaLoai");
            cbxLS.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaLoai,TheLoai FROM T06_TheLoai", cbxLS2, "MaLoai", "TheLoai");
            cbxLS2.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable tempd;
            if (cbxLS.Text.Trim().Length == 0)
            {
                tbxCSLS.Text = "";
                return;
            }
            sql = "SELECT MaSach FROM T01_Sach WHERE MaLoai=N'" + cbxLS.SelectedValue + "'";
            tempd = Functions.GetDataToTable(sql);
            if (tempd.Rows.Count == 0)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa nhóm sách " + tbxCSLS.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    sql = "DELETE T06_TheLoai WHERE MaLoai=N'" + cbxLS.SelectedValue + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Xóa thành công nhóm sách " + tbxCSLS.Text, "THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Không thể xóa nhóm sách vẫn còn sách lưu hành, vui lòng cập nhật lại danh mục sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Functions.FillCombo("SELECT MaLoai,TheLoai FROM T06_TheLoai", cbxLS, "MaLoai", "MaLoai");
            cbxLS.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaLoai,TheLoai FROM T06_TheLoai", cbxLS2, "MaLoai", "TheLoai");
            cbxLS2.SelectedIndex = -1;
        }

        private void cbxTS_TextChanged(object sender, EventArgs e)
        {
            if (cbxTenSach.Text == "")
            {
                tbxMS.Text = "";
                cbxLS2.SelectedIndex = -1;
                cbxNXB.SelectedIndex = -1;
                cbxVT.SelectedIndex = -1;
                cbxTG.SelectedIndex = -1;
                tbxGNY.Text = "";
                tbxNXB.Text = "";
                tbxSL.Text = "";
            }
            else
            {
                string str = "SELECT MaSach FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                tbxMS.Text = Functions.GetFieldValues(str);
                str = "SELECT MaLoai FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                cbxLS2.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT NamXuatBan FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                tbxNXB.Text = Functions.GetFieldValues(str);
                str = "SELECT MaNXB FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                cbxNXB.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT MaTacGia FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                cbxTG.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT GiaNiemYet FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                tbxGNY.Text = Functions.GetFieldValues(str);
                str = "SELECT MaGian FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                cbxVT.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT SoLuong FROM T01_Sach WHERE MaSach=N'" + cbxTenSach.SelectedValue + "'";
                tbxSL.Text = Functions.GetFieldValues(str);
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaSach FROM T01_Sach WHERE MaSach=N'" + tbxMS.Text + "'";
            if (!Functions.CheckKey(sql))
                MessageBox.Show("Không có thông tin sách này, vui lòng xem lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn cập nhật thông tin cho quyển " + cbxTenSach.Text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (cbxTenSach.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Tên sách không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxTenSach.Focus();
                        return;
                    }
                    if (cbxLS2.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Sách phải thuộc một thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxLS2.Focus();
                        return;
                    }
                    if (cbxTG.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Sách phải có tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxTG.Focus();
                        return;
                    }
                    if (cbxNXB.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Sách phải có nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxNXB.Focus();
                        return;
                    }
                    if (cbxVT.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn vị trí của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxVT.Focus();
                        return;
                    }
                    if (tbxNXB.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Sách phải có năm xuất bản và năm xuất bản phải hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxNXB.Focus();
                        return;
                    }
                    if (tbxSL.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Sách phải có số lượng lớn hơn hoặc bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxSL.Focus();
                        return;
                    }
                    if (tbxGNY.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Sách phải có giá niêm yết hơn hoặc bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxGNY.Focus();
                        return;
                    }
                    sql = "UPDATE T01_Sach SET TenSach=N'" + cbxTenSach.Text + "', MaLoai='" + cbxLS2.SelectedValue + "', MaTacGia='" + cbxTG.SelectedValue
                        + "', MaNXB='" + cbxNXB.SelectedValue + "', NamXuatBan='" + tbxNXB.Text + "', MaGian='" + cbxVT.SelectedValue
                        + "', GiaNiemYet='" + tbxGNY.Text + "', SoLuong='" + tbxSL.Text + "' WHERE MaSach=N'" + cbxTenSach.SelectedValue +"'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Cập nhật thành công sách " + cbxTenSach.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            cbxTenSach.SelectedIndex = -1;
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbxMS.Text.Trim().Length == 0)
            {
                cbxTenSach.Text = "";
                cbxTG.Text = "";
                cbxLS2.Text = "";
                cbxNXB.Text = "";
                cbxVT.Text = "";
                tbxSL.Text = "";
                tbxNXB.Text = "";
                tbxGNY.Text = "";
                return;
            }
            DialogResult dlr = MessageBox.Show("Bạn có muốn xóa quyển " + cbxTenSach.Text + " khỏi kho", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                sql = "SELECT MaSach FROM T09_CTHDB WHERE MaSach=N'" + tbxMS.Text + "'";
                DataTable dt;
                dt = Functions.GetDataToTable(sql);
                if (dt.Rows.Count == 0)
                {
                    sql = "DELETE T01_Sach WHERE MaSach=N'" + tbxMS.Text + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Đã xóa thành công sách " + cbxTenSach.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể xóa, còn lưu giữ hóa đơn của sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
             }
            Functions.FillCombo("SELECT MaSach,TenSach FROM T01_Sach", cbxTenSach, "MaSach", "TenSach");
            cbxTenSach.SelectedIndex = -1;
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            string sql, key = "";
            sql = "SELECT MaSach FROM T01_Sach WHERE MaSach='" + tbxMS.Text + "'";
            if (Functions.CheckKey(sql))
                MessageBox.Show("Đã có sách này trong kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (cbxTenSach.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxTenSach.Focus();
                    return;
                }
                if (cbxLS2.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn thể loại của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxLS2.Focus();
                    return;
                }
                if (cbxTG.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn tác giả của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxTG.Focus();
                    return;
                }
                if (cbxNXB.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn nhà xuất bản của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxNXB.Focus();
                    return;
                }
                if (cbxVT.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn vị trí của sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxVT.Focus();
                    return;
                }
                if ((tbxNXB.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Bạn phải nhập năm xuất bản của sách và năm xuất bản phải hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxNXB.Focus();
                    return;
                }
                if ((tbxSL.Text.Trim().Length == 0))
                {
                    MessageBox.Show("Bạn phải nhập số lượng của sách trong kho và số lượng phải lớn hơn hoặc bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxSL.Focus();
                    return;
                }
                if (tbxGNY.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Sách phải có giá niêm yết lớn hơn hoặc bằng 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tbxGNY.Focus();
                    return;
                }
                key = Functions.createKeyList(cbxTenSach.Text);
                key = key.ToUpper();
                sql = "SELECT MaSach FROM T01_Sach WHERE MaSach='" + key.Trim() + "'";
                for (int i = 1; Functions.CheckKey(sql); i++)
                {
                    key = Functions.createKeyList(cbxTenSach.Text) + i;
                    key = key.ToUpper();
                    sql = "SELECT MaSach FROM T01_Sach WHERE MaSach='" + key.Trim() + "'";
                }
                sql = "INSERT INTO T01_Sach(MaSach, TenSach, MaLoai, MaTacGia, MaNXB, NamXuatBan, MaGian, GiaNiemYet, SoLuong) VALUES (N'"
                    + key.Trim() + "', N'" + cbxTenSach.Text + "', N'" + cbxLS2.SelectedValue + "', N'" + cbxTG.SelectedValue + "', N'"
                    + cbxNXB.SelectedValue + "', N'" + tbxNXB.Text + "', N'" + cbxVT.SelectedValue + "', '" + tbxGNY.Text + "', '" + tbxSL.Text + "')";
                Functions.RunSQL(sql);
                MessageBox.Show("Đã thêm thành công quyển " + cbxTenSach.Text + " vào kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Functions.FillCombo("SELECT MaSach,TenSach FROM T01_Sach", cbxTenSach, "MaSach", "TenSach");
            cbxTenSach.SelectedIndex = -1;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void LoadDGVTG()
        {
            DataTable dt;
            string sql = "SELECT * FROM T04_TacGia";
            dt = Functions.GetDataToTable(sql);
            dgvTG.DataSource = dt;
            dgvTG.Columns[0].HeaderText = "Mã tác giả";
            dgvTG.Columns[1].HeaderText = "Tên tác giả";
            dgvTG.Columns[2].HeaderText = "Địa chỉ";
            dgvTG.Columns[3].HeaderText = "Số điện thoại";
            dgvTG.Columns[0].Width = 100;
            dgvTG.Columns[1].Width = 200;
            dgvTG.Columns[2].Width = 238;
            dgvTG.Columns[3].Width = 200;
            dgvTG.AllowUserToAddRows = false;
            dgvTG.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void cbxMTG_TextChange(object sender, EventArgs e)
        {
            if (cbxMTG.Text == "")
            {
                tbxTTG.Text = "";
                tbxDC.Text = "";
                tbxSDT.Text = "";
            }
            else
            {
                string str = "SELECT TenTacGia FROM T04_TacGia WHERE MaTacGia=N'" + cbxMTG.Text + "'";
                tbxTTG.Text = Functions.GetFieldValues(str);
                str = "SELECT DiaChi FROM T04_TacGia WHERE MaTacGia=N'" + cbxMTG.Text + "'";
                tbxDC.Text = Functions.GetFieldValues(str);
                str = "SELECT SoDienThoai FROM T04_TacGia WHERE MaTacGia=N'" + cbxMTG.Text + "'";
                tbxSDT.Text = Functions.GetFieldValues(str);
            }
        }

        private void dgvTG_CellCTC(object sender, DataGridViewCellEventArgs e)
        {
            cbxMTG.Text = dgvTG.CurrentRow.Cells["MaTacGia"].Value.ToString();
            string dc = dgvTG.CurrentRow.Cells["DiaChi"].Value.ToString();
            tbxDC.Text = dc;
            tbxSDT.Text = dgvTG.CurrentRow.Cells["SoDienThoai"].Value.ToString();
        }

        private void btnSaveTG_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaTacGia FROM T04_TacGia WHERE MaTacGia=N'" + cbxMTG.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                DialogResult dlr = MessageBox.Show("Không có thông tin tác giả này, bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxTTG.Text == "")
                    {
                        MessageBox.Show("Phải nhập tên của tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTTG.Focus();
                        return;
                    }
                    else
                    {
                        string key = "";
                        key = Functions.createKeyList(tbxTTG.Text);
                        key = key.ToUpper();
                        sql = "SELECT MaTacGia FROM T04_TacGia WHERE MaTacGia=N'" + key + "'";
                        for (int i = 1; Functions.CheckKey(sql); i++)
                        {
                            key = Functions.createKeyList(tbxTTG.Text) + i;
                            key = key.ToUpper();
                            sql = "SELECT MaTacGIa FROM T04_TacGia WHERE MaTacGia=N'" + key + "'";
                        }
                        sql = "INSERT INTO T04_TacGia(MaTacGia,TenTacGia,DiaChi,SoDienThoai) VALUES (N'" + key.Trim() + "',N'" + tbxTTG.Text + "', N'"
                            + tbxDC.Text + "', N'" + tbxSDT.Text + "')";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã thêm nhóm tác giả " + tbxTTG.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn cập nhật thông tin cho tác giả " + cbxMTG.SelectedValue, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxTTG.Text == "")
                    {
                        MessageBox.Show("Phải nhập tên của tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTTG.Focus();
                        return;
                    }
                    sql = "UPDATE T04_TacGia SET TenTacGia=N'" + tbxTTG.Text.ToString() + "', DiaChi='" + tbxDC.Text + "', SoDienThoai='" + tbxSDT.Text + "' WHERE MaTacGia=N'" + cbxMTG.Text + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Cập nhật thành công thông tin tác giả " + cbxMTG.SelectedValue, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Functions.FillCombo("SELECT MaTacGia, TenTacGia FROM T04_TacGia", cbxMTG, "TenTacGia", "MaTacGia");
            cbxMTG.SelectedIndex = -1;
            LoadDGVTG();
        }

        private void dgvTG_doubleClick(object sender, EventArgs e)
        {
            string mtg, sql = "";
            mtg = dgvTG.CurrentRow.Cells["MaTacGia"].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa tác giả " + mtg + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "SELECT MaTacGia FROM T01_Sach WHERE MaTacGia='" + mtg + "'";
                DataTable td = Functions.GetDataToTable(sql);
                if (td.Rows.Count == 0)
                {
                    try
                    {
                        sql = "DELETE T04_TacGia WHERE MaTacGia= N'" + mtg + "'";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Xóa thành công tác giả " + mtg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                else
                    MessageBox.Show("Không thể xóa, vẫn còn sách của tác giả trong kho, vui lòng cập nhật lại danh mục sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadDGVTG();
        }

        private void cbxMaNXB_TC(object sender, EventArgs e)
        {
            if (cbxMaNXB.Text == "")
            {
                tbxTenNXB.Text = "";
                tbxDCNXB.Text = "";
                tbxSDTNXB.Text = "";
            }
            else
            {
                string str = "SELECT TenNXB FROM T05_NXB WHERE MaNXB='" + cbxMaNXB.SelectedValue + "'";
                tbxTenNXB.Text = Functions.GetFieldValues(str);
                str = "SELECT DiaChi FROM T05_NXB WHERE MaNXB=N'" + cbxMaNXB.SelectedValue + "'";
                tbxDCNXB.Text = Functions.GetFieldValues(str);
                str = "SELECT SoDienThoai FROM T05_NXB WHERE MaNXb=N'" + cbxMaNXB.SelectedValue + "'";
                tbxSDTNXB.Text = Functions.GetFieldValues(str);
            }
        }

        private void loadDGVNXB()
        {
            DataTable dt;
            string sql = "SELECT * FROM T05_NXB";
            dt = Functions.GetDataToTable(sql);
            dgvNXB.DataSource = dt;
            dgvNXB.Columns[0].HeaderText = "Mã nhà xuất bản";
            dgvNXB.Columns[1].HeaderText = "Tên nhà xuất bản";
            dgvNXB.Columns[2].HeaderText = "Địa chỉ";
            dgvNXB.Columns[3].HeaderText = "Số điện thoại";
            dgvNXB.Columns[0].Width = 100;
            dgvNXB.Columns[1].Width = 200;
            dgvNXB.Columns[2].Width = 238;
            dgvNXB.Columns[3].Width = 200;
            dgvNXB.AllowUserToAddRows = false;
            dgvNXB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnSaveNXB_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaNXB FROM T05_NXB WHERE MaNXB=N'" + cbxMaNXB.SelectedValue + "'";
            if (!Functions.CheckKey(sql))
            {
                DialogResult dlr = MessageBox.Show("Không có thông tin nhà xuất bản này, bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxTenNXB.Text == "")
                    {
                        MessageBox.Show("Phải nhập tên của nhà xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTenNXB.Focus();
                        return;
                    }
                    if (tbxDCNXB.Text == "")
                    {
                        MessageBox.Show("Phải nhập địa chỉ của nhà xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxDCNXB.Focus();
                        return;
                    }
                    if (tbxSDTNXB.Text == "")
                    {
                        MessageBox.Show("Phải nhập số điện thoại của nhà xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSDTNXB.Focus();
                        return;
                    }
                        string key = "";
                        key = Functions.createKeyList(tbxTenNXB.Text);
                        key = key.ToUpper();
                        sql = "SELECT MaNXB FROM T05_NXB WHERE MaNXB=N'" + key + "'";
                        for (int i = 1; Functions.CheckKey(sql); i++)
                        {
                            key = Functions.createKeyList(tbxTenNXB.Text) + i;
                            key = key.ToUpper();
                            sql = "SELECT MaNXB FROM T05_NXB WHERE MaNXB=N'" + key + "'";
                        }
                        sql = "INSERT INTO T05_NXB(MaNXB,TenNXB,DiaChi,SoDienThoai) VALUES (N'" + key.Trim() + "',N'" + tbxTenNXB.Text + "', N'"
                    + tbxDCNXB.Text + "', N'" + tbxSDTNXB.Text + "')";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã thêm nhà xuất bản đối tác " + tbxTenNXB.Text + " vào hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn cập nhật thông tin cho nhà xuất bản " + cbxMaNXB.SelectedValue, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxTenNXB.Text == "")
                    {
                        MessageBox.Show("Tên của nhà xuất bản không được trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxTenNXB.Focus();
                        return;
                    }
                    else if (tbxDCNXB.Text == "")
                    {
                        MessageBox.Show("Nhà xuất bản đối tác phải có địa chỉ giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxDCNXB.Focus();
                        return;
                    }
                    else if (tbxSDTNXB.Text == "")
                    {
                        MessageBox.Show("Nhà xuất bản đối tác phải có phương thức liên lạc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxSDTNXB.Focus();
                        return;
                    }
                    else
                    {
                        sql = "UPDATE T05_NXB SET TenNXB=N'" + tbxTenNXB.Text.ToString() + "', DiaChi='" + tbxDCNXB.Text + "', SoDienThoai='" + tbxSDTNXB.Text + "' WHERE MaNXB=N'" + cbxMaNXB.SelectedValue + "'";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Cập nhật thành công thông tin đối tác " + cbxMaNXB.SelectedValue, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    }
            }
            Functions.FillCombo("SELECT MaNXB, TenNXB FROM T05_NXB", cbxMaNXB, "MaNXB", "MaNXB");
            cbxMaNXB.SelectedIndex = -1;
            loadDGVNXB();
        }

        private void dgvNXB_CellCTC(object sender, DataGridViewCellEventArgs e)
        {
            cbxMaNXB.Text = dgvNXB.CurrentRow.Cells["MaNXB"].Value.ToString();
            string dc = dgvNXB.CurrentRow.Cells["DiaChi"].Value.ToString();
            tbxDCNXB.Text = dc;
            tbxSDTNXB.Text = dgvNXB.CurrentRow.Cells["SoDienThoai"].Value.ToString();
        }

        private void dgvNXB_CellCTDC(object sender, DataGridViewCellEventArgs e)
        {
            string mnxb, sql = "";
            mnxb = dgvNXB.CurrentRow.Cells["MaNXB"].Value.ToString();
            if (MessageBox.Show("Bạn có muốn xóa đối tác " + mnxb + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    DataTable td;
                    sql = "SELECT MaNXB FROM T01_Sach WHERE MaNXB='" + mnxb + "'";
                    td = Functions.GetDataToTable(sql);
                    if (td.Rows.Count == 0)
                    {
                    sql = "DELETE T05_NXB WHERE MaNXB= N'" + mnxb + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Xóa thành công đối tác xuất bản " + mnxb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                MessageBox.Show("Không thể xóa, vẫn còn sách thuộc nhà xuất bản, vui lòng cập nhật lại danh mục sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
            loadDGVNXB();
        }

        private void btnXoaGian_Click(object sender, EventArgs e)
        {
            string sql;
            DataTable tempdt;
            if (cbxMaGian.Text.Trim().Length == 0)
            {
                tbxVTL.Text = "";
                return;
            }
            sql = "SELECT MaGian FROM T01_Sach WHERE MaGian=N'" + cbxMaGian.SelectedValue + "'";
            tempdt = Functions.GetDataToTable(sql);
            if (tempdt.Rows.Count == 0)
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn xóa gian sách này khỏi kho " + cbxMaGian.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    try
                    {
                        sql = "DELETE T07_Gian WHERE MaGian=N'" + cbxMaGian.SelectedValue + "'";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Xóa thành công gian sách " + tbxVTL.Text, "THông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi khi xóa gian", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                 }
            }
            else
                MessageBox.Show("Không thể xóa gian lưu trữ sách, vẫn còn sách lưu trữ, vui lòng cập nhật lại danh mục sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Functions.FillCombo("SELECT MaGian FROM T07_Gian", cbxMaGian, "MaGian", "MaGian");
            cbxMaGian.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaGian,ViTri FROM T07_Gian", cbxVT, "MaGian", "ViTri");
            cbxVT.SelectedIndex = -1;
        }

        private void cbxMaGian_TC(object sender, EventArgs e)
        {
            if (cbxMaGian.Text == "")
            {
                tbxVTL.Text = "";
            }
            else
            {
                string str = "SELECT ViTri FROM T07_Gian WHERE MaGian='" + cbxMaGian.SelectedValue + "'";
                tbxVTL.Text = Functions.GetFieldValues(str);
            }
        }

        private void btnLuuGian_Click(object sender, EventArgs e)
        {
            string sql;
            string key = "";
            sql = "SELECT MaGian FROM T07_Gian WHERE MaGian=N'" + cbxMaGian.SelectedValue + "'";
            if (!Functions.CheckKey(sql))
            {
                DialogResult dlr = MessageBox.Show("Không có gian lưu trữ sách này, bạn có muốn thêm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (tbxVTL.Text == "")
                    {
                        MessageBox.Show("Phải nhập vị trí cụ thể của kho lưu trữ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbxVTL.Focus();
                        return;
                    }
                    key = tbxVTL.Text.Substring(0, 1);
                    sql = "SELECT MaGian FROM T07_Gian WHERE MaGian=N'" + key + "'";
                    for (int i = 1; Functions.CheckKey(sql); i++)
                    {
                        key = tbxVTL.Text.Substring(0, 1) + i;
                        sql = "SELECT MaNXB FROM T05_NXB WHERE MaNXB=N'" + key + "'";
                    }
                        sql = "INSERT INTO T07_Gian(MaGian,ViTri) VALUES (N'" + key.Trim() + "',N'" + tbxVTL.Text + "')";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã thêm kho lưu trữ " + tbxVTL.Text + " vào hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Bạn có muốn cập nhật thông tin cho gian lưu trữ " + tbxVTL.Text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    
                    sql = "UPDATE T07_Gian SET ViTri=N'" + tbxVTL.Text.ToString() + "' WHERE MaGian=N'" + cbxMaGian.SelectedValue + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Cập nhật thành công thông tinkho lưu trữ " + tbxVTL.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Functions.FillCombo("SELECT MaGian FROM T07_Gian", cbxMaGian, "MaGian", "MaGian");
            cbxMaGian.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaGian,ViTri FROM T07_Gian", cbxVT, "MaGian", "ViTri");
            cbxVT.SelectedIndex = -1;
        }

    }
}
