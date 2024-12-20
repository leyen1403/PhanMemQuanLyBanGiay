﻿using DTO;
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
using DevExpress.Data.Svg;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;

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
            FormClosing += Frm_lapDonDatHang_FormClosing;
        }

        /// <summary>
        /// Xử lý sự kiện khi form đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_lapDonDatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DonDatHang d = new DonDatHangBLL().LayDanhSachDonDatHang().Where(x => x.MaDonDatHang == MaDonDatHang).FirstOrDefault();
            DonDatHangBLL bll = new DonDatHangBLL();
            if(bll.XoaDonDatHang(d))
            {
                MessageBox.Show("Xoá đơn đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_lapDonDatHang_Load(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = new NhanVienBLL().LayNhanVien(MaNhanVien).TenNhanVien;
            AddPlaceholder(txtTim, "Nhập mã hoặc tên sản phẩm");
        }

        /// <summary>
        /// Thêm placeholder cho TextBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="placeholderText"></param>
        private void AddPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            // Xử lý sự kiện khi TextBox nhận hoặc mất focus
            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = string.Empty;
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào Button "Tạo đơn đặt hàng"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ddh.GhiChu = txtGhiChuDDH.Text;
                ddh.TrangThai = "Chưa xác nhận";
                ddh.MaNhanVien = MaNhanVien;
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

        /// <summary>
        /// Xử lý sự kiện khi chọn loại sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Xử lý sự kiện khi chọn nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedValue != null)
            {
                txtMaNCC.Text = cboNhaCungCap.SelectedValue.ToString();
                txtTenNCC.Text = cboNhaCungCap.Text;
                NhaCungCap ncc = new NhaCungCapBLL().LayDanhSachNhaCungCap().Where(n => n.MaNhaCungCap == txtMaNCC.Text).FirstOrDefault();
                if (ncc != null)
                {
                    txtNguoiDaiDien.Text = ncc.NguoiDaiDien;
                    txtEmail.Text = ncc.Email;
                    txtDiaChi.Text = ncc.DiaChi;
                    txtSDT.Text = ncc.SoDienThoai;
                }
            }
        }

        /// <summary>
        /// Load dữ liệu cho DataGridView "dgvSanPham"
        /// </summary>
        private void loadDGVSanPham()
        {
            dgvSanPham.DataSource = new SanPhamBLL().layDanhSachSanPham();
            dinhDangDGVSanPham();
            themCotSoThuTu(dgvSanPham);
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn sản phẩm trong DataGridView "dgvSanPham"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Thêm cột "SoThuTu" vào DataGridView
        /// </summary>
        /// <param name="dgvSanPham"></param>
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

        /// <summary>
        /// Định dạng DataGridView "dgvSanPham"
        /// </summary>
        private void dinhDangDGVSanPham()
        {
            dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm"; 

            dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";

            dgvSanPham.Columns["MaLoaiSanPham"].Visible = false;

            dgvSanPham.Columns["MaThuongHieu"].Visible = false;

            dgvSanPham.Columns["MaMauSac"].Visible = false; 

            dgvSanPham.Columns["MaKichThuoc"].Visible = false; 

            dgvSanPham.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgvSanPham.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            dgvSanPham.Columns["GiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSanPham.Columns["GiaBan"].Visible = false;

            dgvSanPham.Columns["DonViTinh"].Visible = false; 

            dgvSanPham.Columns["SoLuong"].HeaderText = "Tồn kho"; 
            dgvSanPham.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSanPham.Columns["SoLuongToiThieu"].HeaderText = "Tối thiểu"; 
            dgvSanPham.Columns["SoLuongToiThieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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

        /// <summary>
        /// Tạo mã đơn đặt hàng
        /// </summary>
        /// <param name="lstDDH"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Xử lý sự kiện khi click vào Button "Lưu nhà cung cấp"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Xử lý sự kiện khi click vào Button "Cập nhật"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Xử lý sự kiện khi click vào Button "Tìm"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTim_Click(object sender, EventArgs e)
        {
            if(txtTim.Text == "Nhập mã hoặc tên sản phẩm" || txtTim.Text == "")
            {
                loadDGVSanPham();
            }
            else
            {
                string key = txtTim.Text;
                SanPhamBLL sanPhamBLL = new SanPhamBLL();
                List<SanPham> lstSP = sanPhamBLL.layDanhSachSanPham().Where(sp => sp.MaSanPham.Contains(key) || sp.TenSanPham.Contains(key)).ToList();
                dgvSanPham.DataSource = lstSP;
                dinhDangDGVSanPham();
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào Button "Thêm vào đơn đặt hàng"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemVaoDonDatHang_Click(object sender, EventArgs e)
        {
            if(cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
            ctddh.MaDonDatHang = MaDonDatHang;
            ctddh.MaSanPham = txtMaSP.Text;
            ctddh.SoLuongYeuCau = Convert.ToInt32(nudSoLuongYeuCau.Value);
            ctddh.SoLuongCungCap = 0;
            ctddh.SoLuongThieu = ctddh.SoLuongYeuCau;
            ctddh.DonGia = new SanPhamBLL().laySanPhamTheoMa(dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString()).GiaNhap;
            ctddh.ThanhTien = ctddh.SoLuongYeuCau * ctddh.DonGia;
            if (new ChiTietDonDatHangBLL().ThemChiTietDonDatHang(ctddh))
            {
                MessageBox.Show("Thêm sản phẩm vào đơn đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Hiển thị danh sách chi tiết đơn đặt hàng
                dgvChiTietDDH.DataSource = new ChiTietDonDatHangBLL().LayDanhSachChiTietDonDatHangTheoMaDDH(MaDonDatHang);
                dinhDangDGVChiTietDDH();
                themCotSoThuTu(dgvChiTietDDH);
                dgvChiTietDDH.SelectionChanged += DgvChiTietDDH_SelectionChanged;
                // Hiển thị tổng tiền
                txtTongTien.Text = new ChiTietDonDatHangBLL().tinhTongTien(MaDonDatHang).ToString("N0");
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm vào đơn đặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sử lý sự kiện khi chọn 1 dòng trong DataGridView "dgvChiTietDDH"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvChiTietDDH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChiTietDDH.CurrentRow != null && dgvChiTietDDH.CurrentRow.Cells["MaSanPham"] != null)
            {
                // Hiển thị thông tin chi tiết sản phẩm
                txtMaSP.Text = dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value?.ToString();
                var sanPham = new SanPhamBLL().laySanPhamTheoMa(txtMaSP.Text);
                if (sanPham != null)
                {
                    txtTenSP.Text = sanPham.TenSanPham;
                    nudSoLuongToiThieu.Value = Convert.ToInt32(sanPham.SoLuongToiThieu);
                    txtLoai.Text = sanPham.LoaiSanPham?.TenLoaiSanPham;
                    txtThuongHieu.Text = sanPham.ThuongHieu?.TenThuongHieu;
                    txtMau.Text = sanPham.MauSac?.TenMauSac;
                    nudSoLuongYeuCau.Value = Convert.ToInt32(dgvChiTietDDH.CurrentRow.Cells["SoLuongYeuCau"].Value);
                }

                // Ẩn nút thêm
                btnThemVaoDonDatHang.Visible = false;

                // Hiện nút lưu và xoá
                btnXoaChiTietDDH.Visible = true;
                btnLuuChiTietDDH.Visible = true;
            }
        }

        /// <summary>
        /// Định dạng DataGridView "dgvChiTietDDH"
        /// </summary>
        private void dinhDangDGVChiTietDDH()
        {
            dgvChiTietDDH.Columns["MaDonDatHang"].Visible = false;
            dgvChiTietDDH.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvChiTietDDH.Columns["SoLuongYeuCau"].HeaderText = "Số lượng yêu cầu";
            dgvChiTietDDH.Columns["SoLuongYeuCau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTietDDH.Columns["SoLuongCungCap"].HeaderText = "Số lượng cung cấp";
            dgvChiTietDDH.Columns["SoLuongCungCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTietDDH.Columns["SoLuongThieu"].Visible = false;
            dgvChiTietDDH.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTietDDH.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTietDDH.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietDDH.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTietDDH.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTietDDH.Columns["ThanhTien"].HeaderText = "Thành tiền";

            dgvChiTietDDH.Columns["DonDatHang"].Visible = false;
            dgvChiTietDDH.Columns["SanPham"].Visible = false;
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào Button "Lưu chi tiết đơn đặt hàng"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLuuChiTietDDH_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            ChiTietDonDatHang ctddh = new ChiTietDonDatHang()
            {
                MaDonDatHang = this.MaDonDatHang,
                MaSanPham = maSP,
                SoLuongYeuCau = Convert.ToInt32(nudSoLuongYeuCau.Value),
                SoLuongCungCap = 0,
                SoLuongThieu = Convert.ToInt32(nudSoLuongYeuCau.Value),
                DonGia = new SanPhamBLL().laySanPhamTheoMa(maSP).GiaNhap,
                ThanhTien = Convert.ToInt32(nudSoLuongYeuCau.Value) * new SanPhamBLL().laySanPhamTheoMa(maSP).GiaNhap
            };
            if(new ChiTietDonDatHangBLL().CapNhatChiTietDonDatHang(ctddh))
            {
                MessageBox.Show("Cập nhật chi tiết đơn đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Hiển thị danh sách chi tiết đơn đặt hàng
                dgvChiTietDDH.DataSource = new ChiTietDonDatHangBLL().LayDanhSachChiTietDonDatHangTheoMaDDH(MaDonDatHang);
                dinhDangDGVChiTietDDH();
                themCotSoThuTu(dgvChiTietDDH);
                // Hiển thị tổng tiền
                txtTongTien.Text = new ChiTietDonDatHangBLL().tinhTongTien(MaDonDatHang).ToString("N0");
            }
            else
            {
                MessageBox.Show("Cập nhật chi tiết đơn đặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi click vào Button "Xoá chi tiết đơn đặt hàng"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaChiTietDDH_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            SanPham sp = new SanPhamBLL().laySanPhamTheoMa(maSP);
            if (sp != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm " + sp.TenSanPham + " khỏi đơn đặt hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (new ChiTietDonDatHangBLL().XoaChiTietDonDatHang(MaDonDatHang, maSP))
                    {
                        MessageBox.Show("Xoá sản phẩm khỏi đơn đặt hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Hiển thị danh sách chi tiết đơn đặt hàng
                        dgvChiTietDDH.DataSource = new ChiTietDonDatHangBLL().LayDanhSachChiTietDonDatHangTheoMaDDH(MaDonDatHang);
                        dinhDangDGVChiTietDDH();
                        themCotSoThuTu(dgvChiTietDDH);
                        // Hiển thị tổng tiền
                        txtTongTien.Text = new ChiTietDonDatHangBLL().tinhTongTien(MaDonDatHang).ToString("N0");
                    }
                    else
                    {
                        MessageBox.Show("Xoá sản phẩm khỏi đơn đặt hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cboLoaiSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboNhaCungCap_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtGhiChuDDH_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn phím sẽ hiển thị danh sách gợi ý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboNhaCungCap_KeyUp(object sender, KeyEventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (cbo != null && cbo.DataSource != null)
            {
                string searchText = cbo.Text.ToLower();
                var dataSource = new NhaCungCapBLL().LayDanhSachNhaCungCap()
                    .Where(ncc => ncc.TenNhaCungCap.ToLower().Contains(searchText))
                    .ToList();

                cbo.DataSource = null;
                cbo.DataSource = dataSource;
                cbo.DisplayMember = "TenNhaCungCap";
                cbo.ValueMember = "MaNhaCungCap";
                cbo.DroppedDown = true; // Hiển thị danh sách gợi ý
                cbo.Text = searchText; // Giữ lại từ khóa người dùng đã nhập
                cbo.SelectionStart = searchText.Length; // Đặt con trỏ ở cuối
                cbo.SelectionLength = 0; // Không chọn thêm ký tự
            }
        }
    }
}
