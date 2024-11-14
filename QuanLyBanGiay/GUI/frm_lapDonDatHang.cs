using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frm_lapDonDatHang : Form
    {
        public string MaNhanVien { get; set; }
        string MaDonDatHang;
        public frm_lapDonDatHang()
        {
            InitializeComponent();
            Load += Frm_lapDonDatHang_Load;
        }

        private void Frm_lapDonDatHang_Load(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = new NhanVienBLL().LayNhanVien(MaNhanVien).TenNhanVien;
        }

        private void btnTaoDDH_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận tạo đơn đặt hàng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tạo đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Tạo mã đơn đặt hàng mới
                List<DonDatHang> lstDDH = new DonDatHangBLL().LayDanhSachDonDatHang();
                MaDonDatHang = taoMaDDH(lstDDH);
                DonDatHang ddh = new DonDatHang();
                ddh.MaDonDatHang = MaDonDatHang;

                if (!new DonDatHangBLL().ThemDonDatHang(ddh))
                {
                    MessageBox.Show("Tạo đơn đặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnTaoDDH.Visible = false;

                btnCapNhatDDH.Enabled = true;
                cboNhaCungCap.Enabled = true;
                txtGhiChuDDH.Enabled = true;
                txtTenNCC.Enabled = true;
                txtNguoiDaiDien.Enabled = true;
                txtEmail.Enabled = true;
                txtDiaChi.Enabled = true;
                txtSDT.Enabled = true;
                btnLuuNCC.Enabled = true;
                btnTim.Enabled = true;
                txtTim.Enabled = true;
                cboLoaiSP.Enabled = true;
                btnThemVaoDonDatHang.Enabled = true;
                nudSoLuongYeuCau.Enabled = true;

                // Load dữ liệu comboBox
                cboNhaCungCap.DataSource = new NhaCungCapBLL().LayDanhSachNhaCungCap();
                cboNhaCungCap.DisplayMember = "TenNhaCungCap";
                cboNhaCungCap.ValueMember = "MaNhaCungCap";
                cboNhaCungCap.SelectedIndex = -1;
                cboNhaCungCap.SelectedIndexChanged += CboNhaCungCap_SelectedIndexChanged;

                var loaiSanPhamList = new LoaiSanPhamBLL().layTatCaLoaiSanPham();
                LoaiSanPham loaiSP = new LoaiSanPham();
                loaiSP.MaLoaiSanPham = "TatCa";
                loaiSP.TenLoaiSanPham = "Tất cả";
                loaiSanPhamList.Insert(0, loaiSP);
                cboLoaiSP.DataSource = loaiSanPhamList;
                cboLoaiSP.DisplayMember = "TenLoaiSanPham";
                cboLoaiSP.ValueMember = "MaLoaiSanPham";
                cboLoaiSP.SelectedIndex = -1;
                cboLoaiSP.SelectedIndexChanged += CboLoaiSP_SelectedIndexChanged;

                // Hiển thị danh sách sản phẩm
                loadDGVSanPham();
            }
        }

        private void CboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiSP.SelectedValue.ToString() == "TatCa")
            {
                dgvSanPham.DataSource = new SanPhamBLL().layDanhSachSanPham();
                dinhDangDGVSanPham();
                themCotSoThuTu(dgvSanPham);
            }
            else
            {
                // Hiển thị danh sách sản phẩm theo loại sản phẩm (cboLoaiSP.SelectedValue.ToString()
                dgvSanPham.DataSource = new SanPhamBLL().layDanhSachSanPhamTheoMaLoai(cboLoaiSP.SelectedValue.ToString());
                dinhDangDGVSanPham();
                themCotSoThuTu(dgvSanPham);
            }
        }

        private void CboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtMaNCC.Text = cboNhaCungCap.SelectedValue.ToString();
            txtTenNCC.Text = cboNhaCungCap.Text;
            NhaCungCap ncc = new NhaCungCapBLL().LayDanhSachNhaCungCap().Where(n => n.MaNhaCungCap == txtMaNCC.Text).FirstOrDefault();
            txtNguoiDaiDien.Text = ncc.NguoiDaiDien;
            txtEmail.Text = ncc.Email;
            txtDiaChi.Text = ncc.DiaChi;
            txtSDT.Text = ncc.SoDienThoai;
        }

        private void loadDGVSanPham()
        {
            dgvSanPham.DataSource = new SanPhamBLL().layDanhSachSanPham();
            dinhDangDGVSanPham();
            themCotSoThuTu(dgvSanPham);
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
        }

        private void DgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            txtMaSP.Text = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtTenSP.Text = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
            nudSoLuongToiThieu.Value = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["SoLuongToiThieu"].Value);
            string maSP = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtLoai.Text = new SanPhamBLL().laySanPhamTheoMa(maSP).LoaiSanPham.TenLoaiSanPham;
            txtThuongHieu.Text = new SanPhamBLL().laySanPhamTheoMa(maSP).ThuongHieu.TenThuongHieu;
            txtMau.Text = new SanPhamBLL().laySanPhamTheoMa(maSP).MauSac.TenMauSac;

            // Nếu trong dgvChiTietDDH đã có sản phẩm này thì lấy giá trị của cột "SoLuongYeuCau" để gán cho nudSoLuongYeuCau
            if (dgvChiTietDDH.Rows.Count > 0)
            {
                for (int i = 0; i < dgvChiTietDDH.Rows.Count; i++)
                {
                    if (dgvChiTietDDH.Rows[i].Cells["MaSanPham"].Value.ToString() == txtMaSP.Text)
                    {
                        nudSoLuongYeuCau.Value = Convert.ToInt32(dgvChiTietDDH.Rows[i].Cells["SoLuongYeuCau"].Value);
                        // Ẩn nút thêm
                        btnThemVaoDonDatHang.Visible = false;
                        // Hiện nút xoá, lưu
                        btnXoaChiTietDDH.Visible = true;
                        btnLuuChiTietDDH.Visible = true;
                        return;
                    }
                }
            }
            nudSoLuongYeuCau.Value = 0;
            // Hiện nút thêm
            btnThemVaoDonDatHang.Visible = true;
            // Ẩn nút xoá, lưu
            btnXoaChiTietDDH.Visible = false;
            btnLuuChiTietDDH.Visible = false;
        }

        private void themCotSoThuTu(DataGridView dgvSanPham)
        {
            // Kiểm tra nếu cột "SoThuTu" đã tồn tại thì không thêm nữa
            if (dgvSanPham.Columns["SoThuTu"] == null)
            {
                // Tạo một cột mới để hiển thị số thứ tự
                DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn();
                soThuTuColumn.Name = "SoThuTu";
                soThuTuColumn.HeaderText = "STT";
                soThuTuColumn.Width = 50;
                soThuTuColumn.ReadOnly = true;

                // Thêm cột vào DataGridView
                dgvSanPham.Columns.Insert(0, soThuTuColumn);
            }

            // Gán số thứ tự cho từng hàng
            for (int i = 0; i < dgvSanPham.Rows.Count; i++)
            {
                dgvSanPham.Rows[i].Cells["SoThuTu"].Value = i + 1;
            }
        }

        private void dinhDangDGVSanPham()
        {
            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm"; 
            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns["MaLoaiSanPham"].Visible = false;
            dgvSanPham.Columns["MaThuongHieu"].Visible = false;
            dgvSanPham.Columns["MaMauSac"].Visible = false; 
            dgvSanPham.Columns["MaKichThuoc"].Visible = false; 
            dgvSanPham.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgvSanPham.Columns["GiaBan"].Visible = false;
            dgvSanPham.Columns["DonViTinh"].Visible = false; 
            dgvSanPham.Columns["SoLuong"].HeaderText = "Tồn kho"; 
            dgvSanPham.Columns["SoLuongToiThieu"].HeaderText = "Tối thiểu"; 
            dgvSanPham.Columns["MoTa"].Visible = false; 
            dgvSanPham.Columns["HinhAnh"].Visible = false; 
            dgvSanPham.Columns["TrangThaiHoatDong"].Visible = false;
            dgvSanPham.Columns["NgayTao"].Visible = false; 
            dgvSanPham.Columns["NgayCapNhat"].Visible = false; 
            dgvSanPham.Columns["KichThuoc"].Visible = false; 
            dgvSanPham.Columns["LoaiSanPham"].Visible = false; 
            dgvSanPham.Columns["MauSac"].Visible = false; 
            dgvSanPham.Columns["ThuongHieu"].Visible = false; 
        }

        private string taoMaDDH(List<DonDatHang> lstDDH)
        {
            if(lstDDH.Count == 0)
            {
                return "DDH001";
            }
            else
            {
                int soLuong = lstDDH.Count;
                string maDDH = "DDH" + (soLuong + 1).ToString("000");
                return maDDH;
            }
        }

        private void btnLuuNCC_Click(object sender, EventArgs e)
        {
            // Hiện thông báo xác nhận lưu nhà cung cấp
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                NhaCungCap ncc = new NhaCungCapBLL().LayDanhSachNhaCungCap().Where(n => n.MaNhaCungCap == txtMaNCC.Text).FirstOrDefault();
                ncc.TenNhaCungCap = txtTenNCC.Text;
                ncc.NguoiDaiDien = txtNguoiDaiDien.Text;
                ncc.Email = txtEmail.Text;
                ncc.DiaChi = txtDiaChi.Text;
                ncc.SoDienThoai = txtSDT.Text;
                ncc.TrangThaiHoatDong = true;
                ncc.NgayCapNhat = DateTime.Now;
                if(new NhaCungCapBLL().CapNhatNhaCungCap(ncc))
                {
                    MessageBox.Show("Lưu nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboNhaCungCap.DataSource = new NhaCungCapBLL().LayDanhSachNhaCungCap();
                    cboNhaCungCap.DisplayMember = "TenNhaCungCap";
                    cboNhaCungCap.ValueMember = "MaNhaCungCap";
                }
                else
                {
                    MessageBox.Show("Lưu nhà cung cấp thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCapNhatDDH_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận cập nhật đơn đặt hàng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật đơn đặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Cập nhật thông tin đơn đặt hàng
                DonDatHang ddh = new DonDatHang();
                ddh.MaDonDatHang = MaDonDatHang;
                ddh.MaNhaCungCap = txtMaNCC.Text;
                ddh.MaNhanVien = MaNhanVien;
                ddh.NgayDatHang = DateTime.Now;
                ddh.NgayDuKienGiao = DateTime.Now + new TimeSpan(7, 0, 0, 0);
                ddh.TrangThai = "Chưa xác nhận";
                ddh.GhiChu = txtGhiChuDDH.Text;
                ddh.NgayTao = DateTime.Now;
                if(ddh.MaNhaCungCap == "" || ddh.GhiChu == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (new DonDatHangBLL().CapNhatDonDatHang(ddh))
                {
                    MessageBox.Show("Cập nhật đơn đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật đơn đặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnThemVaoDonDatHang_Click(object sender, EventArgs e)
        {
            ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
            ctddh.MaDonDatHang = MaDonDatHang;
            ctddh.MaSanPham = txtMaSP.Text;
            ctddh.SoLuongYeuCau = Convert.ToInt32(nudSoLuongYeuCau.Value);
            ctddh.SoLuongCungCap = 0;
            ctddh.SoLuongThieu = ctddh.SoLuongYeuCau;
            ctddh.DonGia = new SanPhamBLL().laySanPhamTheoMa(txtMaSP.Text).GiaNhap;
            ctddh.ThanhTien = ctddh.SoLuongYeuCau * ctddh.DonGia;
            if (new ChiTietDonDatHangBLL().ThemChiTietDonDatHang(ctddh))
            {
                MessageBox.Show("Thêm sản phẩm vào đơn đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Hiển thị danh sách chi tiết đơn đặt hàng
                dgvChiTietDDH.DataSource = new ChiTietDonDatHangBLL().LayDanhSachChiTietDonDatHangTheoMaDDH(MaDonDatHang);
                dinhDangDGVChiTietDDH();
                themCotSoThuTu(dgvChiTietDDH);
                // Hiển thị tổng tiền
                txtTongTien.Text = new ChiTietDonDatHangBLL().tinhTongTien(MaDonDatHang).ToString("N0");
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm vào đơn đặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dinhDangDGVChiTietDDH()
        {
            
        }
    }
}
