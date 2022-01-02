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
    public partial class Frm_Main : Form
    {
        DataTable tbS;
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void LoadDGV()
        {
            dgv1.Columns[0].HeaderText = "Mã sách";
            dgv1.Columns[1].HeaderText = "Tên sách";
            dgv1.Columns[2].HeaderText = "Thể loại";
            dgv1.Columns[3].HeaderText = "Tác giả";
            dgv1.Columns[4].HeaderText = "Nhà xuất bản";
            dgv1.Columns[5].HeaderText = "Năm xuất bản";
            dgv1.Columns[6].HeaderText = "Vị trí";
            dgv1.Columns[7].HeaderText = "Giá niêm yết";
            dgv1.Columns[8].HeaderText = "Số lượng";
            dgv1.Columns[0].Width = 50;
            dgv1.Columns[1].Width = 140;
            dgv1.Columns[2].Width = 140;
            dgv1.Columns[3].Width = 150;
            dgv1.Columns[4].Width = 190;
            dgv1.Columns[5].Width = 80;
            dgv1.Columns[6].Width = 170;
            dgv1.Columns[7].Width = 90;
            dgv1.Columns[8].Width = 50;
            dgv1.AllowUserToAddRows = false;
            dgv1.EditMode = DataGridViewEditMode.EditProgrammatically;
            tbxTS.Text = "";
            tbxNXB.Text = "";
            Functions.FillCombo("SELECT MaLoai, TheLoai FROM T06_TheLoai", cbxTL, "MaLoai", "TheLoai");
            cbxTL.SelectedIndex = -1;
            Functions.FillCombo("SELECT TenNXB, MaNXB FROM T05_NXB", cbxNXB, "MaNXB", "TenNXB");
            cbxNXB.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaTacGia,TenTacGia FROM T04_TacGia", cbxTG, "MaTacGia", "TenTacGia");
            cbxTG.SelectedIndex = -1;
            cbxNXB.SelectedIndex = -1;
            cbxTG.SelectedIndex = -1;
            cbxTL.SelectedIndex = -1;
        }

        private void Frmain_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Đã đăng xuất khỏi tài khoản " + Frm_Login.ID + " !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Frmain_Load(object sender, EventArgs e)
        {
            String wellcom = "";
            if (Frm_Login.Permission == 1)
                wellcom = ", bạn được thao tác tất cả các chức năng với mức quyền 1 - admin! Chúc bạn một ngày tốt lành!";
            else
                wellcom = ", bạn bị giới hạn chức năng với mức quyền " + Frm_Login.Permission + "! Chúc bạn một ngày tốt lành!";
            hello.Text = "Xin chào " + Frm_Login.ID + wellcom;
            if (Frm_Login.Permission == 2)
            {
                tab2.Dispose();
                tab3.Dispose();
            }
            Functions.FillCombo("SELECT MaLoai, TheLoai FROM T06_TheLoai", cbxTL, "MaLoai", "TheLoai");
             cbxTL.SelectedIndex = -1;
            Functions.FillCombo("SELECT TenNXB, MaNXB FROM T05_NXB", cbxNXB, "MaNXB", "TenNXB");
            cbxNXB.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaTacGia,TenTacGia FROM T04_TacGia", cbxTG, "MaTacGia", "TenTacGia");
            cbxTG.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaHDB FROM T08_HDB", cbxMHDB, "MaHDB", "MaHDB");
            loadFormHDB();
            cbxMHDB.SelectedIndex = -1;
            cbxMKH.SelectedIndex = -1;
            cbxMNV.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaHDN FROM T10_HDN", cbxMHDN, "MaHDN", "MaHDN");
            loadFormHDN();
            cbxMHDN.SelectedIndex = -1;
            cbxMNXB.SelectedIndex = -1;
            cbxMNVN.SelectedIndex = -1;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaSach, TenSach, TheLoai, TenTacGia, TenNXB, NamXuatBan, ViTri, GiaNiemYet, SoLuong FROM T01_Sach AS a, T04_TacGia AS b, T05_NXB AS c, T06_TheLoai AS d, T07_Gian AS e WHERE a.MaTacGia=b.MaTacGia AND a.MaNXB=c.MaNXB AND a.MaLoai=d.MaLoai AND a.MaGian=e.MaGian";
            if ((tbxTS.Text == "") && (cbxTG.Text == "") && (cbxTL.Text == "" ) && (cbxNXB.Text == "") && (tbxNXB.Text == ""))
            {
                sql = sql + "";
            }
            if (tbxTS.Text != "")
            {
                sql = sql + " AND a.TenSach LIKE N'%" + tbxTS.Text + "%'";
            }
            if (cbxNXB.Text != "")
            {
                sql = sql + " AND c.MaNXB LIKE '%" + cbxNXB.SelectedValue + "%'";
            }
            if (tbxNXB.Text != "")
            {
                sql = sql + " AND a.NamXuatBan LIKE N'%" + tbxNXB.Text + "%'";
            }
            if (cbxTL.Text != "")
            {
                sql = sql + " AND d.MaLoai LIKE '%" + cbxTL.SelectedValue + "%'";
            }
            if (cbxTG.Text != "")
            {
                sql = sql + " AND b.MaTacGia LIKE '%" + cbxTG.SelectedValue + "%'";
            }
            tbS = Functions.GetDataToTable(sql);
            if (tbS.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tbS.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv1.DataSource = tbS;
            LoadDGV();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            if (Frm_Login.Permission == 1)
            {
                Frm_Book frmBook = new Frm_Book();
                frmBook.ShowDialog();
            }
            else
                MessageBox.Show("Không cho phép thao tác chức năng này với quyền hiện tại, vui lòng thực hiện với quyền admin (level 1) hoặc thao tác chức năng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            if (Frm_Login.Permission == 1)
            {
                Frm_KH frmKH = new Frm_KH();
                frmKH.ShowDialog();
            }
            else
                MessageBox.Show("Không cho phép thao tác chức năng này với quyền hiện tại, vui lòng thực hiện với quyền admin (level 1) hoặc thao tác chức năng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Frmain_Closed(object sender, FormClosedEventArgs e)
        {
            Functions.Disconnect();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            Frm_Employee frmNV = new Frm_Employee();
            frmNV.ShowDialog();
        }
        // tab HDB
        private void cbxMNVTK_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMNVTK.Text == "")
                tbxTNVTK.Text = "";
            else
            {
                str = "SELECT TenNhanVien FROM T02_NhanVien WHERE MaNhanVien= N'" + cbxMNVTK.SelectedValue + "'";
                tbxTNVTK.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMNV_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMNV.Text == "")
                tbxTNV.Text = "";
            else
            {
                str = "SELECT TenNhanVien FROM T02_NhanVien WHERE MaNhanVien= N'" + cbxMNV.SelectedValue + "'";
                tbxTNV.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMKHTK_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMKHTK.Text == "")
                tbxTKHTK.Text = "";
            else
            {
                str = "SELECT TenKhachHang FROM T03_KhachHang WHERE MaKhachHang= N'" + cbxMKHTK.SelectedValue + "'";
                tbxTKHTK.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMKH_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMKH.Text == "")
                tbxTKH.Text = "";
            else
            {
                str = "SELECT TenKhachHang FROM T03_KhachHang WHERE MaKhachHang= N'" + cbxMKH.SelectedValue + "'";
                tbxTKH.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMSTK_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMSTK.Text == "")
                tbxTSTK.Text = "";
            else
            {
                str = "SELECT TenSach FROM T01_Sach WHERE MaSach= N'" + cbxMSTK.SelectedValue + "'";
                tbxTSTK.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMSB_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMSB.Text == "")
            {
                tbxTSB.Text = "";
                tbxSLB.Text = "";
            }
            else
            {
                tbxSLB.Text = "";
                str = "SELECT TenSach FROM T01_Sach WHERE MaSach= N'" + cbxMSB.SelectedValue + "'";
                tbxTSB.Text = Functions.GetFieldValues(str);
            }
        }

        private void btnSaveBan_Click(object sender, EventArgs e)
        {
            string sql, key = "";
            DialogResult dlr;
            sql = "SELECT MaHDB FROM T08_HDB WHERE MaHDB=N'" + cbxMHDB.Text + "'";
            if (Functions.CheckKey(sql))
            {
                string updateNB;
                sql = "SELECT NgayBan FROM T08_HDB WHERE MaHDB='" + cbxMHDB.SelectedValue + "'";
                updateNB = Functions.GetFieldValues(sql);
                if (DPNB.Value.ToString("dd/MM/yyyy") != updateNB)
                {
                    dlr = MessageBox.Show("Bạn có muốn cập nhật ngày bán cho hóa đơn của khách hàng " + cbxMKH.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        if (DPNB.Value > DateTime.Now)
                        {
                            MessageBox.Show("Không được bán cho tương lai ^_^", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DPNB.Focus();
                            return;
                        }
                        string ngayupd = DPNB.Value.ToString("MM/dd/yyyy");
                        sql = "UPDATE T08_HDB SET NgayBan='" + ngayupd + "' WHERE MaHDB=N'" + cbxMHDB.SelectedValue + "'";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Cập nhật thành công");
                    }
                }
                if ((cbxMSB.Text != "") && (tbxSLB.Text != ""))
                {
                    int slc;
                    slc = Convert.ToInt32(Functions.GetFieldValues("SELECT SoLuong FROM T01_Sach WHERE MaSach = N'" + cbxMSB.SelectedValue + "'"));
                    if (Convert.ToInt32(tbxSLB.Text) > slc)
                    {
                        MessageBox.Show("Số lượng sách " + tbxTSB.Text + " trong kho chỉ còn " + slc , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxSLB.Text = "";
                        tbxSLB.Focus();
                        return;
                    }
                    else
                    {
                        dlr = MessageBox.Show("Thêm sách " + tbxTSB.Text + " khách hàng " + tbxTKH.Text + " đã mua vào hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlr == DialogResult.Yes)
                        {
                            sql = "SELECT MaHDB,MaSach FROM T09_CTHDB WHERE MaHDB=N'" + cbxMHDB.SelectedValue + "' AND MaSach=N'" + cbxMSB.SelectedValue + "'";
                            DataTable dt = Functions.GetDataToTable(sql);
                            if (dt.Rows.Count == 0)
                            {
                                sql = "INSERT INTO T09_CTHDB(MaHDB,MaSach,SoLuongBan,GiaBan) VALUES(N'" + cbxMHDB.SelectedValue + "',N'" + cbxMSB.SelectedValue + "'," +
                                    tbxSLB.Text + "," + tbxGiaBan.Text + ")";
                                Functions.RunSQL(sql);
                                MessageBox.Show("Cập nhật thành công cho hóa đơn của khách hàng " + tbxTKH.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                sql = "SELECT TongTien FROM T08_HDB WHERE MaHDB='" + cbxMHDB.SelectedValue + "'";
                                int tongcu = Convert.ToInt32(Functions.GetFieldValues(sql));
                                int tongmoi = tongcu + Convert.ToInt32(tbxTongTienBan.Text);
                                sql = "UPDATE T08_HDB SET TongTien=" + tongmoi + " WHERE MaHDB='" + cbxMHDB.SelectedValue + "'";
                                Functions.RunSQL(sql);
                                slc = slc - Convert.ToInt32(tbxSLB.Text);
                                sql = "UPDATE T01_Sach SET SoLuong=" + slc + " WHERE MaSach='" + cbxMSB.SelectedValue + "'";
                                Functions.RunSQL(sql);
                            }
                            else
                                MessageBox.Show("Đã có loại mặt hàng này trong hóa đơn của khách hàng " + tbxTKH.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    tbxSLB.Text = "";
                }
            }
            else
            {
                dlr = MessageBox.Show("Bạn có muốn thêm hóa đơn mới cho khách hàng " + cbxMKH.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (cbxMKH.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn khách hàng mua sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxMKH.Focus();
                        return;
                    }
                    if (cbxMNV.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn nhân viên bán hàng tại quầy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxMNV.Focus();
                        return;
                    }
                    key = Functions.CreateKeyHD("HDB");
                    try
                    {
                        if (DPNB.Value > DateTime.Now)
                        {
                            MessageBox.Show("Không được bán cho tương lai ^_^", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            DPNB.Focus();
                            return;
                        }
                        string nb = DPNB.Value.ToString("MM/dd/yyyy");
                        sql = "INSERT INTO T08_HDB(MaHDB,MaNhanVien,MaKhachHang,NgayBan,TongTien) VALUES (N'" + key + "',N'" + cbxMNV.Text + "',N'" +
                            cbxMKH.Text + "','" + nb + "'," + 0 + ")";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã thêm hóa đơn bán sách cho khách hàng " + cbxMKH.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Functions.FillCombo("SELECT MaHDB FROM T08_HDB", cbxMHDB, "MaHDB", "MaHDB");
                cbxMHDB.SelectedIndex = -1;
                cbxMKH.SelectedIndex = -1;
                cbxMNV.SelectedIndex = -1;
            }
            loadFormHDB();
            loadDGVHDB();
        }

        private void cbxMHDB_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMHDB.Text == "")
            {
                cbxMSB.Enabled = false;
                cbxMKH.SelectedIndex = -1;
                cbxMNV.SelectedIndex = -1;
                cbxMSB.SelectedIndex = -1;
                DPNB.Value = DateTime.Now;
            }
            else
            {
                cbxMSB.Enabled = true;
                str = "SELECT MaNhanVien FROM T08_HDB WHERE MaHDB='" + cbxMHDB.Text + "'";
                cbxMNV.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT MaKhachHang FROM T08_HDB WHERE MaHDB='" + cbxMHDB.Text + "'";
                cbxMKH.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT NgayBan FROM T08_HDB WHERE MaHDB='" + cbxMHDB.Text + "'";
                DPNB.Text = Functions.GetFieldValues(str);
                str = "SELECT TongTien FROM T08_HDB WHERE MaHDB='" + cbxMHDB.SelectedValue + "'";
                tbxTongTienBan.Text = Functions.GetFieldValues(str);
                loadDGVHDB();
            }
        }

        private void loadDGVHDB()
        {
            DataTable dt;
            string sql = "SELECT b.MaSach,TenSach,SoLuongBan,GiaBan FROM T09_CTHDB AS a,T01_Sach AS b WHERE MaHDB='" + cbxMHDB.Text +"' AND b.MaSach=a.MaSach";
            dt = Functions.GetDataToTable(sql);
            dgvHDB.DataSource = dt;
            dgvHDB.Columns[0].HeaderText = "Mã sách";
            dgvHDB.Columns[1].HeaderText = "Tên sách";
            dgvHDB.Columns[2].HeaderText = "Số lượng bán";
            dgvHDB.Columns[3].HeaderText = "Giá bán";
            dgvHDB.Columns[0].Width = 200;
            dgvHDB.Columns[1].Width = 350;
            dgvHDB.Columns[2].Width = 200;
            dgvHDB.Columns[3].Width = 240;
            dgvHDB.AllowUserToAddRows = false;
            dgvHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
            
        }

        private void tbxSLB_TC(object sender, EventArgs e)
        {
            if ((tbxSLB.Text != "") && (cbxMSB.Text != ""))
            {
                int gia, sl = Convert.ToInt32(tbxSLB.Text);
                string sql = "SELECT GiaNiemYet FROM T01_Sach WHERE MaSach=N'" + cbxMSB.Text + "'";
                gia = Convert.ToInt32(Functions.GetFieldValues(sql));
                if (sl < 5)
                {
                    tbxGiaBan.Text = Convert.ToString(gia);
                    tbxTongTienBan.Text = Convert.ToString(sl * gia);
                }
                else if (sl >= 5 && sl < 10)
                {
                    gia = gia * 9 / 10;
                    tbxGiaBan.Text = Convert.ToString(gia);
                    tbxTongTienBan.Text = Convert.ToString(sl * gia);
                }
                else
                {
                    gia = gia * 8 / 10;
                    tbxGiaBan.Text = Convert.ToString(gia);
                    tbxTongTienBan.Text = Convert.ToString(sl * gia);
                }
            }
            else
            {
                tbxGiaBan.Text = "";
                tbxTongTienBan.Text = "";
            }
        }

        private void tbxSLB_KP(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void loadFormHDB()
        {
            Functions.FillCombo("SELECT MaKhachHang FROM T03_KhachHang", cbxMKH, "MaKhachHang", "MaKhachHang");
            Functions.FillCombo("SELECT MaSach FROM T01_Sach", cbxMSB, "MaSach", "MaSach");
            cbxMSB.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaSach FROM T01_Sach", cbxMSTK, "MaSach", "MaSach");
            cbxMSTK.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien FROM T02_NhanVien", cbxMNVTK, "MaNhanVien", "MaNhanVien");
            cbxMNVTK.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaKhachHang FROM T03_KhachHang", cbxMKHTK, "MaKhachHang", "MaKhachHang");
            cbxMKHTK.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien FROM T02_NhanVien", cbxMNV, "MaNhanVien", "MaNhanVien");
        }

        private void btnDelHDB_Click(object sender, EventArgs e)
        {
            string sql;
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn có muốn xóa hóa đơn này khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                sql = "DELETE T09_CTHDB WHERE MaHDB=N'" + cbxMHDB.SelectedValue + "'";
                Functions.RunSQL(sql);
                sql = "DELETE T08_HDB WHERE MaHDB=N'" + cbxMHDB.SelectedValue + "'";
                Functions.RunSQL(sql);
                MessageBox.Show("Xóa thành công hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadFormHDB();
                Functions.FillCombo("SELECT MaHDB FROM T08_HDB", cbxMHDB, "MaHDB", "MaHDB");
                cbxMHDB.SelectedIndex = -1;
                loadDGVHDB();
            }
        }

        private void dgvHDB_CellCTDC(object sender, DataGridViewCellEventArgs e)
        {
            if (cbxMHDB.Text != "")
            {
                string tsb = dgvHDB.CurrentRow.Cells["TenSach"].Value.ToString();
                DialogResult dlr = MessageBox.Show("Bạn có muốn hoàn trả sách " + tsb + " của khách hàng " + tbxTKH.Text + " về hệ thống lưu trữ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    string slt = dgvHDB.CurrentRow.Cells["SoLuongBan"].Value.ToString();
                    string msb = dgvHDB.CurrentRow.Cells["MaSach"].Value.ToString();
                    string sql = "SELECT SoLuong FROM T01_Sach WHERE MaSach=N'" + msb + "'";
                    int slupd = Convert.ToInt32(Functions.GetFieldValues(sql));
                    slupd = slupd + Convert.ToInt32(slt);
                    sql = "UPDATE T01_Sach SET SoLuong=" + slupd + " WHERE MaSach=N'" + msb + "'";
                    Functions.RunSQL(sql);
                    sql = "DELETE T09_CTHDB WHERE MaHDB=N'" + cbxMHDB.SelectedValue + "' AND MaSach=N'" + msb + "'";
                    Functions.RunSQL(sql);
                    int giatru = Convert.ToInt32(dgvHDB.CurrentRow.Cells["GiaBan"].Value);
                    giatru = giatru * Convert.ToInt32(slt);
                    sql = "SELECT TongTien FROM T08_HDB WHERE MaHDB=N'" + cbxMHDB.SelectedValue + "'";
                    int giacu = Convert.ToInt32(Functions.GetFieldValues(sql));
                    giacu = giacu - giatru;
                    sql = "UPDATE T08_HDB SET TongTien=" + giacu + " WHERE MaHDB=N'" + cbxMHDB.SelectedValue + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Đã hoàn tác sách " + tsb + " của khách hàng " + tbxTKH.Text + " về kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDGVHDB();
                    loadFormHDB();
                }
            }
        }

        private void btnTKHDB_Click(object sender, EventArgs e)
        {
            cbxMHDB.SelectedIndex = -1;
            string sql;
            DataTable dt;
            sql = "SELECT DISTINCT a.MaHDB, a.MaNhanVien,a.MaKhachHang,a.NgayBan,a.TongTien FROM T08_HDB AS a, T09_CTHDB AS b WHERE a.MaHDB=b.MaHDB AND NgayBan >='" + dpTKfrom.Value.ToString("MM/dd/yyyy") +
                "' AND NgayBan <= '" + dpTKto.Value.ToString("MM/dd/yyyy") + "'";
            if (cbxMNVTK.Text != "")
            {
                sql = sql + " AND MaNhanVien=N'" + cbxMNVTK.SelectedValue + "'";
            }
            if (cbxMKHTK.Text != "")
            {
                sql = sql + " AND MaKhachHang=N'" + cbxMKHTK.SelectedValue + "'";
            }
            if (cbxMSTK.Text != "")
            {
                sql = sql + " AND b.MaSach=N'" + cbxMSTK.SelectedValue + "'";
            }
            dt = Functions.GetDataToTable(sql);
            dgvHDB.DataSource = dt;
            loadDGVTKHDB();
            DialogResult dlr = MessageBox.Show("Bạn có muốn xuất báo cáo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if ((dgvHDB.Rows.Count == 0) || (dgvHDB.Columns.Count == 0))
                {
                    MessageBox.Show("Chưa có dữ liệu in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int prtt = 0;
                string ptstk;
                foreach (DataGridViewRow dr in dgvHDB.Rows)
                {
                    prtt = prtt + Convert.ToInt32(dr.Cells[4].Value);
                }
                if (tbxTSTK.Text == "")
                {
                    ptstk = "Tất cả";
                }
                else
                {
                    ptstk = tbxTSTK.Text;
                }
                ExportEHDB ex = new ExportEHDB();
                ex.ExportRP1(dt, "Hoa Don", Frm_Login.ID, dpTKfrom.Value.ToString("dd/MM/yyyy"), dpTKto.Value.ToString("dd/MM/yyyy"), ptstk, prtt);
            }
            }

        private void loadDGVTKHDB()
        {
            dgvHDB.Columns[0].HeaderText = "Mã hóa đơn bán";
            dgvHDB.Columns[1].HeaderText = "Mã nhân viên bán";
            dgvHDB.Columns[2].HeaderText = "Mã khách hàng mua";
            dgvHDB.Columns[3].HeaderText = "Ngày bán";
            dgvHDB.Columns[4].HeaderText = "Tổng tiền hóa đơn";
            dgvHDB.Columns[0].Width = 170;
            dgvHDB.Columns[1].Width = 170;
            dgvHDB.Columns[2].Width = 150;
            dgvHDB.Columns[3].Width = 250;
            dgvHDB.Columns[4].Width = 250;
            dgvHDB.AllowUserToAddRows = false;
            dgvHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnSX_Click(object sender, EventArgs e)
        {
            cbxMHDB.SelectedIndex = -1;
            string sql;
            DataTable dt;
            sql = "SELECT DISTINCT b.MaSach,b.MaHDB,a.NgayBan,b.SoLuongBan,b.GiaBan FROM T08_HDB AS a, T09_CTHDB AS b WHERE a.MaHDB=b.MaHDB AND NgayBan >='" + dpTKfrom.Value.ToString("MM/dd/yyyy") +
                "' AND NgayBan <= '" + dpTKto.Value.ToString("MM/dd/yyyy") + "'";
            if (cbxMNVTK.Text != "")
            {
                sql = sql + " AND MaNhanVien=N'" + cbxMNVTK.SelectedValue + "'";
            }
            if (cbxMKHTK.Text != "")
            {
                sql = sql + " AND MaKhachHang=N'" + cbxMKHTK.SelectedValue + "'";
            }
            if (cbxMSTK.Text != "")
            {
                sql = sql + " AND b.MaSach=N'" + cbxMSTK.SelectedValue + "'";
            }
            dt = Functions.GetDataToTable(sql);
            dgvHDB.DataSource = dt;
            loadDGVTKSX();
            DialogResult dlr = MessageBox.Show("Bạn có muốn xuất báo cáo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if ((dgvHDB.Rows.Count == 0) || (dgvHDB.Columns.Count == 0))
                {
                    MessageBox.Show("Chưa có dữ liệu in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int prtt = 0;
                string ptstk, pnvx;
                foreach (DataGridViewRow dr in dgvHDB.Rows)
                {
                    int slb = Convert.ToInt32(dr.Cells[3].Value);
                    int gb = Convert.ToInt32(dr.Cells[4].Value);
                    prtt = prtt + (slb * gb);
                }
                if (tbxTSTK.Text == "")
                {
                    ptstk = "Tất cả";
                }
                else
                {
                    ptstk = tbxTSTK.Text;
                }
                if (tbxTNVTK.Text == "")
                {
                    pnvx = "Tất cả";
                }
                else
                {
                    pnvx = tbxTNVTK.Text;
                }
                ExportEHDB ex = new ExportEHDB();
                ex.ExportRP2(dt, "Hoa Don", Frm_Login.ID, pnvx,dpTKfrom.Value.ToString("dd/MM/yyyy"),dpTKto.Value.ToString("dd/MM/yyyy"),ptstk,prtt);
            }
        }

        private void loadDGVTKSX()
        {
            dgvHDB.Columns[0].HeaderText = "Mã sách bán";
            dgvHDB.Columns[1].HeaderText = "Mã hóa đơn bán";
            dgvHDB.Columns[2].HeaderText = "Ngày bán";
            dgvHDB.Columns[3].HeaderText = "Số lượng bán";
            dgvHDB.Columns[4].HeaderText = "Giá bán";
            dgvHDB.Columns[0].Width = 180;
            dgvHDB.Columns[1].Width = 200;
            dgvHDB.Columns[2].Width = 200;
            dgvHDB.Columns[3].Width = 150;
            dgvHDB.Columns[4].Width = 250;
            dgvHDB.AllowUserToAddRows = false;
            dgvHDB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if ((dgvHDB.Rows.Count == 0) || (dgvHDB.Columns.Count == 0) || (cbxMHDB.Text == ""))
            {
                MessageBox.Show("Chưa có dữ liệu in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int[,] intt = new int[dgvHDB.Rows.Count,1];
            int vsl,vdg;
            int i;
            foreach (DataGridViewRow dr in dgvHDB.Rows)
            {
                i = dr.Index;
                vsl = Convert.ToInt32(dr.Cells[2].Value);
                vdg = Convert.ToInt32(dr.Cells[3].Value);
                intt[i,0] = vsl * vdg;
            }
            ExportEHDB ex = new ExportEHDB();
            DataTable dt = (DataTable) dgvHDB.DataSource;
            ex.ExportHDB(dt, "Hoa Don", cbxMHDB.Text, Frm_Login.ID, DPNB.Value.ToString("dd/MM/yyyy"), Convert.ToInt32(tbxTongTienBan.Text), intt);
        }
        // tab HDN
        private void cbxHDN_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMHDN.Text == "")
            {
                cbxMSN.Enabled = false;
                cbxMNXB.SelectedIndex = -1;
                cbxMNVN.SelectedIndex = -1;
                cbxMSN.SelectedIndex = -1;
                dpNNHDN.Value = DateTime.Now;
            }
            else
            {
                cbxMSN.Enabled = true;
                str = "SELECT MaNhanVien FROM T10_HDN WHERE MaHDN='" + cbxMHDN.Text + "'";
                cbxMNVN.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT MaNXB FROM T10_HDN WHERE MaHDN='" + cbxMHDN.Text + "'";
                cbxMNXB.SelectedValue = Functions.GetFieldValues(str);
                str = "SELECT NgayNhap FROM T10_HDN WHERE MaHDN='" + cbxMHDN.Text + "'";
                dpNNHDN.Text = Functions.GetFieldValues(str);
                str = "SELECT TongTien FROM T10_HDN WHERE MaHDN='" + cbxMHDN.SelectedValue + "'";
                tbxTTN.Text = Functions.GetFieldValues(str);
                loadDGVHDN();
            }
        }

        private void loadDGVHDN()
        {
            DataTable dt;
            string sql = "SELECT b.MaSach,TenSach,SoLuongNhap,GiaNhap FROM T11_CTHDN AS a,T01_Sach AS b WHERE MaHDN='" + cbxMHDN.Text + "' AND b.MaSach=a.MaSach";
            dt = Functions.GetDataToTable(sql);
            dgvHDN.DataSource = dt;
            dgvHDN.Columns[0].HeaderText = "Mã sách";
            dgvHDN.Columns[1].HeaderText = "Tên sách";
            dgvHDN.Columns[2].HeaderText = "Số lượng nhập";
            dgvHDN.Columns[3].HeaderText = "Giá nhập vào";
            dgvHDN.Columns[0].Width = 200;
            dgvHDN.Columns[1].Width = 350;
            dgvHDN.Columns[2].Width = 200;
            dgvHDN.Columns[3].Width = 240;
            dgvHDN.AllowUserToAddRows = false;
            dgvHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void cbxMNVNTK_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMNVNTK.Text == "")
                tbxTNVNTK.Text = "";
            else
            {
                str = "SELECT TenNhanVien FROM T02_NhanVien WHERE MaNhanVien= N'" + cbxMNVNTK.SelectedValue + "'";
                tbxTNVNTK.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMNVN_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMNVN.Text == "")
                tbxTNVN.Text = "";
            else
            {
                str = "SELECT TenNhanVien FROM T02_NhanVien WHERE MaNhanVien= N'" + cbxMNVN.SelectedValue + "'";
                tbxTNVN.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMNXBTK_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMNXBTK.Text == "")
                tbxTNXBTK.Text = "";
            else
            {
                str = "SELECT TenNXB FROM T05_NXB WHERE MaNXB= N'" + cbxMNXBTK.SelectedValue + "'";
                tbxTNXBTK.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMNXB_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMNXB.Text == "")
                tbxTNXB.Text = "";
            else
            {
                str = "SELECT TenNXB FROM T05_NXB WHERE MaNXB= N'" + cbxMNXB.SelectedValue + "'";
                tbxTNXB.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMSNTK_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMSNTK.Text == "")
                tbxTSNTK.Text = "";
            else
            {
                str = "SELECT TenSach FROM T01_Sach WHERE MaSach= N'" + cbxMSNTK.SelectedValue + "'";
                tbxTSNTK.Text = Functions.GetFieldValues(str);
            }
        }

        private void cbxMSN_TC(object sender, EventArgs e)
        {
            string str;
            if (cbxMSN.Text == "")
            {
                tbxTSN.Text = "";
                tbxSLN.Text = "";
                tbxGN.Text = "";
            }
            else
            {
                tbxSLN.Text = "";
                tbxGN.Text = "";
                str = "SELECT TenSach FROM T01_Sach WHERE MaSach= N'" + cbxMSN.SelectedValue + "'";
                tbxTSN.Text = Functions.GetFieldValues(str);
            }
        }

        private void btnSaveHDN_Click(object sender, EventArgs e)
        {
            string sql, key = "";
            DialogResult dlr;
            sql = "SELECT MaHDN FROM T10_HDN WHERE MaHDN=N'" + cbxMHDN.Text + "'";
            if (Functions.CheckKey(sql))
            {
                string updateNN;
                sql = "SELECT NgayNhap FROM T10_HDN WHERE MaHDN='" + cbxMHDN.SelectedValue + "'";
                updateNN = Functions.GetFieldValues(sql);
                if (dpNNHDN.Value.ToString("dd/MM/yyyy") != updateNN)
                {
                    dlr = MessageBox.Show("Bạn có muốn cập nhật ngày nhập cho hóa đơn nhập sách từ " + cbxMNXB.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        if (dpNNHDN.Value > DateTime.Now)
                        {
                            MessageBox.Show("Ngày nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dpNNHDN.Focus();
                            return;
                        }
                        string ngayupd = dpNNHDN.Value.ToString("MM/dd/yyyy");
                        sql = "UPDATE T10_HDN SET NgayNhap='" + ngayupd + "' WHERE MaHDN=N'" + cbxMHDN.SelectedValue + "'";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Cập nhật thành công");
                    }
                }
                if ((cbxMSN.Text != "") && (tbxSLN.Text != "") && (tbxGN.Text != ""))
                {
                    dlr = MessageBox.Show("Thêm sách " + tbxTSN.Text + " đã nhập từ NXB " + tbxTNXB.Text + " đã mua vào hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        sql = "SELECT MaHDN,MaSach FROM T11_CTHDN WHERE MaHDN=N'" + cbxMHDN.SelectedValue + "' AND MaSach=N'" + cbxMSN.SelectedValue + "'";
                        DataTable dt = Functions.GetDataToTable(sql);
                        if (dt.Rows.Count == 0)
                        {
                            sql = "INSERT INTO T11_CTHDN(MaHDN,MaSach,SoLuongNhap,GiaNhap) VALUES(N'" + cbxMHDN.SelectedValue + "',N'" + cbxMSN.SelectedValue + "'," +
                                 tbxSLN.Text + "," + tbxGN.Text + ")";
                            Functions.RunSQL(sql);
                            MessageBox.Show("Cập nhật thành công cho hóa đơn nhập từ nhà xuất bản " + tbxTNXB.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sql = "SELECT TongTien FROM T10_HDN WHERE MaHDN='" + cbxMHDN.SelectedValue + "'";
                            int tongcu = Convert.ToInt32(Functions.GetFieldValues(sql));
                            int tongmoi = tongcu + Convert.ToInt32(tbxTTN.Text);
                            sql = "UPDATE T10_HDN SET TongTien=" + tongmoi + " WHERE MaHDN='" + cbxMHDN.SelectedValue + "'";
                            Functions.RunSQL(sql);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi, đã có nhóm này trong hóa đơn!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    tbxSLB.Text = "";
                }
            }
            else
            {
                dlr = MessageBox.Show("Bạn có muốn thêm hóa đơn mới của sách nhập từ NXB " + tbxTNXB.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    if (cbxMNXB.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn nhà xuất bản hợp tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxMNXB.Focus();
                        return;
                    }
                    if (cbxMNVN.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn phải chọn nhân viên phụ trách lô nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbxMNVN.Focus();
                        return;
                    }
                    key = Functions.CreateKeyHD("HDN");
                    try
                    {
                        if (dpNNHDN.Value > DateTime.Now)
                        {
                            MessageBox.Show("Ngày nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dpNNHDN.Focus();
                            return;
                        }
                        string nb = dpNNHDN.Value.ToString("MM/dd/yyyy");
                        sql = "INSERT INTO T10_HDN(MaHDN,MaNhanVien,MaNXB,NgayNhap,TongTien) VALUES (N'" + key + "',N'" + cbxMNVN.Text + "',N'" +
                            cbxMNXB.Text + "','" + nb + "'," + 0 + ")";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đã ghi nhận hóa đơn nhập từ nhà xuất bản " + cbxMKH.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Đã xảy ra lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Functions.FillCombo("SELECT MaHDN FROM T10_HDN", cbxMHDN, "MaHDN", "MaHDN");
                cbxMHDN.SelectedIndex = -1;
                cbxMNXB.SelectedIndex = -1;
                cbxMNVN.SelectedIndex = -1;
            }
            loadFormHDN();
            loadDGVHDN();
        }

        private void loadFormHDN()
        {
            Functions.FillCombo("SELECT MaNXB FROM T05_NXB", cbxMNXB, "MaNXB", "MaNXB");
            Functions.FillCombo("SELECT MaSach FROM T01_Sach", cbxMSN, "MaSach", "MaSach");
            cbxMSN.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaSach FROM T01_Sach", cbxMSNTK, "MaSach", "MaSach");
            cbxMSNTK.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien FROM T02_NhanVien", cbxMNVNTK, "MaNhanVien", "MaNhanVien");
            cbxMNVNTK.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNXB FROM T05_NXB", cbxMNXBTK, "MaNXB", "MaNXB");
            cbxMNXBTK.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNhanVien FROM T02_NhanVien", cbxMNVN, "MaNhanVien", "MaNhanVien");
        }

        private void tbxSLN_TC(object sender, EventArgs e)
        {
            if ((tbxSLN.Text == "") || (tbxGN.Text == ""))
            {
                tbxTTN.Text = "";
            }
            else
            {
                tbxTTN.Text = Convert.ToString(Convert.ToInt32(tbxSLN.Text) * Convert.ToInt32(tbxGN.Text));
            }
        }

        private void tbxGN_TC(object sender, EventArgs e)
        {
            if ((tbxSLN.Text == "") || (tbxGN.Text == ""))
            {
                tbxTTN.Text = "";
            }
            else
            {
                tbxTTN.Text = Convert.ToString(Convert.ToInt32(tbxSLN.Text) * Convert.ToInt32(tbxGN.Text));
            }
        }

        private void btnDelHDN_Click(object sender, EventArgs e)
        {
            string sql;
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn có muốn xóa hóa đơn này khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                sql = "DELETE T11_CTHDN WHERE MaHDN=N'" + cbxMHDN.SelectedValue + "'";
                Functions.RunSQL(sql);
                sql = "DELETE T10_HDN WHERE MaHDN=N'" + cbxMHDN.SelectedValue + "'";
                Functions.RunSQL(sql);
                MessageBox.Show("Xóa thành công hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadFormHDN();
                Functions.FillCombo("SELECT MaHDN FROM T10_HDN", cbxMHDN, "MaHDN", "MaHDN");
                cbxMHDN.SelectedIndex = -1;
                loadDGVHDN();
            }
        }

        private void dgvHDN_CellCTDC(object sender, DataGridViewCellEventArgs e)
        {
            if (cbxMHDN.Text != "")
            {
                string tsn = dgvHDN.CurrentRow.Cells["TenSach"].Value.ToString();
                DialogResult dlr = MessageBox.Show("Bạn có muốn loại trừ sách " + tsn + " khỏi hóa đơn nhập từ nhà xuất bản " + tbxTNXB.Text + " trong đợt này khỏi hệ thống lưu trữ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    string slt = dgvHDN.CurrentRow.Cells["SoLuongNhap"].Value.ToString();
                    string msn = dgvHDN.CurrentRow.Cells["MaSach"].Value.ToString();
                    string sql = "DELETE T11_CTHDN WHERE MaHDN=N'" + cbxMHDN.SelectedValue + "' AND MaSach=N'" + msn + "'";
                    Functions.RunSQL(sql);
                    int giatru = Convert.ToInt32(dgvHDN.CurrentRow.Cells["GiaNhap"].Value);
                    giatru = giatru * Convert.ToInt32(slt);
                    sql = "SELECT TongTien FROM T10_HDN WHERE MaHDN=N'" + cbxMHDN.SelectedValue + "'";
                    int giacu = Convert.ToInt32(Functions.GetFieldValues(sql));
                    giacu = giacu - giatru;
                    sql = "UPDATE T10_HDN SET TongTien=" + giacu + " WHERE MaHDN=N'" + cbxMHDN.SelectedValue + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Đã hoàn tác sách " + tsn + " nhập từ nhà xuất bản " + tbxTNXB.Text + " !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDGVHDN();
                    loadFormHDN();
                }
            }
        }

        private void btnTKHDN_Click(object sender, EventArgs e)
        {
            cbxMHDN.SelectedIndex = -1;
            string sql;
            DataTable dt;
            sql = "SELECT DISTINCT a.MaHDN, a.MaNhanVien,a.MaNXB,a.NgayNhap,a.TongTien FROM T10_HDN AS a, T11_CTHDN AS b WHERE a.MaHDN=b.MaHDN AND NgayNhap >='" + dpNNfrom.Value.ToString("MM/dd/yyyy") +
                "' AND NgayNhap <= '" + dpNNto.Value.ToString("MM/dd/yyyy") + "'";
            if (cbxMNVNTK.Text != "")
            {
                sql = sql + " AND MaNhanVien=N'" + cbxMNVNTK.SelectedValue + "'";
            }
            if (cbxMNXBTK.Text != "")
            {
                sql = sql + " AND MaNXB=N'" + cbxMNXBTK.SelectedValue + "'";
            }
            if (cbxMSNTK.Text != "")
            {
                sql = sql + " AND b.MaSach=N'" + cbxMSNTK.SelectedValue + "'";
            }
            dt = Functions.GetDataToTable(sql);
            dgvHDN.DataSource = dt;
            loadDGVTKHDN();
            DialogResult dlr = MessageBox.Show("Bạn có muốn xuất báo cáo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if ((dgvHDN.Rows.Count == 0) || (dgvHDN.Columns.Count == 0))
                {
                    MessageBox.Show("Chưa có dữ liệu in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int prttn = 0;
                string ptsntk;
                foreach (DataGridViewRow dr in dgvHDN.Rows)
                {
                    prttn = prttn + Convert.ToInt32(dr.Cells[4].Value);
                }
                if (tbxTSNTK.Text == "")
                {
                    ptsntk = "Tất cả";
                }
                else
                {
                    ptsntk = tbxTSNTK.Text;
                }
                ExportEHDN ex = new ExportEHDN();
                ex.ExportRP1(dt, "Hoa Don", Frm_Login.ID, dpNNfrom.Value.ToString("dd/MM/yyyy"), dpNNto.Value.ToString("dd/MM/yyyy"), ptsntk, prttn);
            }
        }

        private void loadDGVTKHDN()
        {
            dgvHDN.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dgvHDN.Columns[1].HeaderText = "Mã nhân viên phụ trách";
            dgvHDN.Columns[2].HeaderText = "Mã nhà xuất bản cung ứng";
            dgvHDN.Columns[3].HeaderText = "Ngày nhập";
            dgvHDN.Columns[4].HeaderText = "Tổng tiền hóa đơn";
            dgvHDN.Columns[0].Width = 150;
            dgvHDN.Columns[1].Width = 190;
            dgvHDN.Columns[2].Width = 200;
            dgvHDN.Columns[3].Width = 200;
            dgvHDN.Columns[4].Width = 250;
            dgvHDN.AllowUserToAddRows = false;
            dgvHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTKCTHDN_Click(object sender, EventArgs e)
        {
            cbxMHDB.SelectedIndex = -1;
            string sql;
            DataTable dt;
            sql = "SELECT DISTINCT b.MaSach,b.MaHDN,a.NgayNhap,b.SoLuongNhap,b.GiaNhap FROM T10_HDN AS a, T11_CTHDN AS b WHERE a.MaHDN=b.MaHDN AND NgayNhap >='" + dpNNfrom.Value.ToString("MM/dd/yyyy") +
                "' AND NgayNhap <= '" + dpNNto.Value.ToString("MM/dd/yyyy") + "'";
            if (cbxMNVNTK.Text != "")
            {
                sql = sql + " AND MaNhanVien=N'" + cbxMNVNTK.SelectedValue + "'";
            }
            if (cbxMNXBTK.Text != "")
            {
                sql = sql + " AND MaNXB=N'" + cbxMNXBTK.SelectedValue + "'";
            }
            if (cbxMSNTK.Text != "")
            {
                sql = sql + " AND b.MaSach=N'" + cbxMSNTK.SelectedValue + "'";
            }
            dt = Functions.GetDataToTable(sql);
            dgvHDN.DataSource = dt;
            loadDGVTKCTHDN();
            DialogResult dlr = MessageBox.Show("Bạn có muốn xuất báo cáo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                if ((dgvHDN.Rows.Count == 0) || (dgvHDN.Columns.Count == 0))
                {
                    MessageBox.Show("Chưa có dữ liệu in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int prttn = 0;
                string ptsntk, pnvn;
                foreach (DataGridViewRow dr in dgvHDN.Rows)
                {
                    int sln = Convert.ToInt32(dr.Cells[3].Value);
                    int gn = Convert.ToInt32(dr.Cells[4].Value);
                    prttn = prttn + (sln * gn);
                }
                if (tbxTSNTK.Text == "")
                {
                    ptsntk = "Tất cả";
                }
                else
                {
                    ptsntk = tbxTSNTK.Text;
                }
                if (tbxTNVNTK.Text == "")
                {
                    pnvn = "Tất cả";
                }
                else
                {
                    pnvn = tbxTNVNTK.Text;
                }
                ExportEHDN ex = new ExportEHDN();
                ex.ExportRP2(dt, "Hoa Don", Frm_Login.ID, pnvn, dpNNfrom.Value.ToString("dd/MM/yyyy"), dpNNto.Value.ToString("dd/MM/yyyy"), ptsntk, prttn);
            }
        }

        private void loadDGVTKCTHDN()
        {
            dgvHDN.Columns[0].HeaderText = "Mã sách nhập vào";
            dgvHDN.Columns[1].HeaderText = "Mã hóa đơn nhập";
            dgvHDN.Columns[2].HeaderText = "Ngày nhập";
            dgvHDN.Columns[3].HeaderText = "Số lượng nhập";
            dgvHDN.Columns[4].HeaderText = "Giá nhập vào";
            dgvHDN.Columns[0].Width = 180;
            dgvHDN.Columns[1].Width = 200;
            dgvHDN.Columns[2].Width = 200;
            dgvHDN.Columns[3].Width = 150;
            dgvHDN.Columns[4].Width = 250;
            dgvHDN.AllowUserToAddRows = false;
            dgvHDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnPrintHDN_Click(object sender, EventArgs e)
        {
            if ((dgvHDN.Rows.Count == 0) || (dgvHDN.Columns.Count == 0) || (cbxMHDN.Text == ""))
            {
                MessageBox.Show("Chưa có dữ liệu in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int[,] inttn = new int[dgvHDN.Rows.Count, 1];
            int vsl, vdg;
            int i;
            foreach (DataGridViewRow dr in dgvHDN.Rows)
            {
                i = dr.Index;
                vsl = Convert.ToInt32(dr.Cells[2].Value);
                vdg = Convert.ToInt32(dr.Cells[3].Value);
                inttn[i, 0] = vsl * vdg;
            }
            string tnxbn = tbxTNXB.Text;
            string nvpt = tbxTNVN.Text;
            ExportEHDN ex = new ExportEHDN();
            DataTable dt = (DataTable)dgvHDN.DataSource;
            ex.ExportHDN(dt, "Hoa Don", cbxMHDN.Text, Frm_Login.ID, nvpt, dpNNHDN.Value.ToString("dd/MM/yyyy"), tnxbn, Convert.ToInt32(tbxTTN.Text),inttn);
        }

        private void btnlogout_Cllick(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Đăng xuất khỏi tải khoản " + Frm_Login.ID + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnUM_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = "C:\\Users\\CNC\\Documents\\Visual Studio 2010\\Projects\\QuanLyCuaHangSach\\QuanLyCuaHangSach\\Resource\\NDNL.docx";
            prc.Start();
        }
    }
}
