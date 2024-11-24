using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class frm_quanLyDonDatHang : Form
    {
        public string MaNhanVien { get; set; }
        public frm_quanLyDonDatHang()
        {
            InitializeComponent();
            Load += Frm_quanLyDonDatHang_Load;
            dgvChiTietDDH.SelectionChanged += DgvChiTietDDH_SelectionChanged;
            dgvDonDatHang.SelectionChanged += DgvDonDatHang_SelectionChanged;
            cbbLuaChonHienThi.SelectedIndexChanged += CbbLuaChonHienThi_SelectedIndexChanged;
            dgvChiTietDDH.RowPrePaint += DgvChiTietDDH_RowPrePaint;
            dgvDonDatHang.RowPrePaint += dgvDonDatHang_RowPrePaint;
        }

        private void dgvDonDatHang_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvDonDatHang.Rows[e.RowIndex];
            if (row.Cells["TrangThai"].Value is string trangThai)
            {
                switch (trangThai)
                {
                    case "Chưa xác nhận":
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                    case "Đã xác nhận":
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case "Đang giao hàng":
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                        break;
                    case "Đã giao hàng":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Hoàn thành":
                        row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.White;
                        break;
                }
            }
        }


        private void DgvChiTietDDH_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvChiTietDDH.Rows[e.RowIndex];
            if (row.Cells["SoLuongThieu"].Value is int soLuongThieu)
            {
                if (soLuongThieu > 0)
                {
                    // Dòng có chênh lệch
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    // Dòng đủ số lượng
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }


        private void CbbLuaChonHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLuaChonHienThi.SelectedValue == null)
            {
                return;
            }

            string luaChon = cbbLuaChonHienThi.SelectedValue.ToString();
            switch (luaChon)
            {
                case "TatCa":
                    cbbNhanVien.Enabled = false;
                    cbbTrangThai.Enabled = false;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbNhaCungCap.Enabled = false;
                    break;
                case "NhanVien":
                    cbbNhanVien.Enabled = true;
                    cbbTrangThai.Enabled = false;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbNhaCungCap.Enabled = false;
                    break;
                case "Ngay":
                    cbbNhanVien.Enabled = false;
                    cbbTrangThai.Enabled = false;
                    dtpTuNgay.Enabled = true;
                    dtpDenNgay.Enabled = true;
                    cbbNhaCungCap.Enabled = false;
                    break;
                case "NCC":
                    cbbNhanVien.Enabled = false;
                    cbbTrangThai.Enabled = false;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbNhaCungCap.Enabled = true;
                    break;
                case "TrangThai":
                    cbbNhanVien.Enabled = false;
                    cbbTrangThai.Enabled = true;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbNhaCungCap.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void Frm_quanLyDonDatHang_Load(object sender, EventArgs e)
        {
            TaoDanhSachTrangThai(cbbTrangThai);
            cbbTrangThai.SelectedIndex = 0;
            HienThiDanhSachNhanVien(cbbNhanVien);
            cbbNhanVien.SelectedIndex = 0;
            HienThiDanhSachNCC(cbbNhaCungCap);
            cbbNhaCungCap.SelectedIndex = 0;
            TaoDanhSachLuaChonHienThi(cbbLuaChonHienThi);
        }

        // Tạo danh sách lựa chọn hiển thị
        private void TaoDanhSachLuaChonHienThi(ComboBox cbbLuaChonHienThi)
        {
            List<LoaiSanPham> lstTrangThai = new List<LoaiSanPham>()
            {
                new LoaiSanPham{MaLoaiSanPham = "TatCa", TenLoaiSanPham = "Tất cả"},
                new LoaiSanPham{MaLoaiSanPham = "NhanVien", TenLoaiSanPham = "Tìm theo nhân viên"},
                new LoaiSanPham{MaLoaiSanPham = "Ngay", TenLoaiSanPham = "Tìm theo ngày"},
                new LoaiSanPham{MaLoaiSanPham = "NCC", TenLoaiSanPham = "Tìm theo nhà cung cấp"},
                new LoaiSanPham{MaLoaiSanPham = "TrangThai", TenLoaiSanPham = "Trạng thái"},
            };
            cbbLuaChonHienThi.DataSource = lstTrangThai;
            cbbLuaChonHienThi.DisplayMember = "TenLoaiSanPham";
            cbbLuaChonHienThi.ValueMember = "MaLoaiSanPham";
        }

        // Thêm dữ liệu Nhà cung cấp vào combobox
        private void HienThiDanhSachNCC(ComboBox cbbNhanVien)
        {
            List<NhaCungCap> lstNCC = new List<NhaCungCap>();
            NhaCungCapBLL nhaCungCapBLL = new NhaCungCapBLL();
            lstNCC = nhaCungCapBLL.LayDanhSachNhaCungCap();
            cbbNhanVien.DataSource = lstNCC;
            cbbNhanVien.DisplayMember = "TenNhaCungCap";
            cbbNhanVien.ValueMember = "MaNhaCungCap";
        }

        // Thêm dữ liệu nhân viên vào combobox
        private void HienThiDanhSachNhanVien(ComboBox comboBox)
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            lstNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            comboBox.DataSource = lstNhanVien;
            comboBox.DisplayMember = "TenNhanVien";
            comboBox.ValueMember = "MaNhanVien";
        }

        // Load DataGridView đơn đặt hàng
        private void LoadDGVDonDatHang()
        {
            DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
            dgvDonDatHang.DataSource = donDatHangBLL.LayDanhSachDonDatHang();
            DinhDangDGVDonDatHang();
            ThemCotSTT(dgvDonDatHang);
        }

        // Sự kiện khi chọn 1 dòng trong DataGridView đơn đặt hàng
        private void DgvDonDatHang_SelectionChanged(object sender, EventArgs e)
        {
            LoaDGVChiTietDDH();
        }

        // Load DataGridView chi tiết đơn đặt hàng
        private void LoaDGVChiTietDDH()
        {
            ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();
            if (dgvDonDatHang.CurrentRow.Cells["MaDonDatHang"].Value != null)
            {
                string maDonDatHang = dgvDonDatHang.CurrentRow.Cells["MaDonDatHang"].Value.ToString(); // Lấy mã đơn đặt hàng
                dgvChiTietDDH.DataSource = chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDonDatHang); // Load dữ liệu
                ThemCotSTT(dgvChiTietDDH); // Thêm cột STT
                DinhDangDGVChiTietDDH(); // Định dạng DataGridView
            }
        }

        // Sự kiện khi chọn 1 dòng trong DataGridView chi tiết đơn đặt hàng
        private void DgvChiTietDDH_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có dòng nào được chọn
            if (dgvChiTietDDH.SelectedCells.Count == 0)
            {
                return; // Thoát nếu không có dòng nào được chọn
            }
            if (dgvDonDatHang.CurrentRow?.Cells["MaDonDatHang"]?.Value == null)
            {
                return;
            }
            if (dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value != null)
            {
                string maSanPham = dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value.ToString(); // Lấy mã sản phẩm
                string maDDH = dgvChiTietDDH.CurrentRow.Cells["MaDonDatHang"].Value.ToString(); // Lấy mã đơn đặt hàng
                SanPhamBLL sanPhamBLL = new SanPhamBLL();
                ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();
                DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
                if (sanPhamBLL.laySanPhamTheoMa(maSanPham) == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH) == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết đơn đặt hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Trạng thái đơn đặt hàng
                TaoDanhSachTrangThai(cbbTrangThaiCTDDH);
                if (dgvDonDatHang.CurrentRow?.Cells["TrangThai"]?.Value != null)
                {
                    string trangThai = dgvDonDatHang.CurrentRow.Cells["TrangThai"].Value.ToString();
                    cbbTrangThaiCTDDH.SelectedValue = trangThai;
                }
                else
                {
                    // Handle the case where the value is null
                    MessageBox.Show("Trạng thái không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Tên sản phẩm
                string tenSanPham = "Lỗi";
                tenSanPham = sanPhamBLL.laySanPhamTheoMa(maSanPham).TenSanPham;
                txtTenSP.Text = tenSanPham;
                // Loại sản phẩm
                string loaiSanPham = "Lỗi";
                loaiSanPham = sanPhamBLL.laySanPhamTheoMa(maSanPham).LoaiSanPham.TenLoaiSanPham;
                txtTenLoai.Text = loaiSanPham;
                // Kích thước
                string kichThuoc = "Lỗi";
                kichThuoc = sanPhamBLL.laySanPhamTheoMa(maSanPham).KichThuoc.TenKichThuoc;
                txtKichThuoc.Text = kichThuoc;
                // Màu sắc
                string mauSac = "Lỗi";
                mauSac = sanPhamBLL.laySanPhamTheoMa(maSanPham).MauSac.TenMauSac;
                txtMau.Text = mauSac;
                // Số lượng yêu cầu
                int soLuongYC = 0;
                soLuongYC = (int)chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH).Where(x => x.MaDonDatHang == maDDH && x.MaSanPham == maSanPham).FirstOrDefault().SoLuongYeuCau;
                nudSLYeuCau.Value = soLuongYC;
                // Sô lượng cung cấp
                int soLuongCC = 0;
                soLuongCC = (int)chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH).Where(x => x.MaDonDatHang == maDDH && x.MaSanPham == maSanPham).FirstOrDefault().SoLuongCungCap;
                nudSLCungCap.Value = soLuongCC;
                // Số lượng thiếu
                int soLuongThieu = 0;
                soLuongThieu = (int)chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH).Where(x => x.MaDonDatHang == maDDH && x.MaSanPham == maSanPham).FirstOrDefault().SoLuongThieu;
                txtSoLuongThieu.Text = soLuongThieu.ToString();
                // Đơn giá
                decimal donGia = 0;
                donGia = (decimal)chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH).Where(x => x.MaDonDatHang == maDDH && x.MaSanPham == maSanPham).FirstOrDefault().DonGia;
                txtDonGia.Text = donGia.ToString("N0");
                // Thành tiền
                decimal thanhTien = 0;
                thanhTien = (decimal)chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH).Where(x => x.MaDonDatHang == maDDH && x.MaSanPham == maSanPham).FirstOrDefault().ThanhTien;
                txtThanhTien.Text = thanhTien.ToString("N0");
                // Tổng tiền đã thanh toán
                decimal tongTien = 0;
                tongTien = chiTietDonDatHangBLL.TinhTongTienDaThanhToan(maDDH);
                txtTongTien.Text = tongTien.ToString("N0");
                // Còn nợ
                decimal conNo = 0;
                conNo = chiTietDonDatHangBLL.TinhTienConNo(maDDH);
                txtConNo.Text = conNo.ToString("N0");
            }
        }

        // Load trạng thái của chi tiết đơn đặt hàng
        private void LoadTrangThaiChiTietDonDatHang(string trangThai)
        {
            // Kiểm tra xem ComboBox đã có nguồn dữ liệu chưa
            if (cbbTrangThaiCTDDH.DataSource == null)
            {
                MessageBox.Show("Dữ liệu nguồn của ComboBox chưa được tải.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Đặt giá trị được chọn trong ComboBox tương ứng với trạng thái
                cbbTrangThaiCTDDH.SelectedValue = trangThai;

                // Kiểm tra xem trạng thái có tồn tại trong danh sách không
                if (cbbTrangThaiCTDDH.SelectedValue == null)
                {
                    MessageBox.Show($"Không tìm thấy trạng thái: {trangThai} trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Tạo danh sách trạng thái đơn đạt hàng
        private void TaoDanhSachTrangThai(ComboBox comboBox)
        {
            List<LoaiSanPham> lstTrangThai = new List<LoaiSanPham>()
            {
                new LoaiSanPham { MaLoaiSanPham = "Chưa xác nhận", TenLoaiSanPham = "Chưa xác nhận" },
                new LoaiSanPham { MaLoaiSanPham = "Đã xác nhận", TenLoaiSanPham = "Đã xác nhận" },
                new LoaiSanPham { MaLoaiSanPham = "Đang giao hàng", TenLoaiSanPham = "Đang giao hàng" },
                new LoaiSanPham { MaLoaiSanPham = "Đã giao hàng", TenLoaiSanPham = "Đã giao hàng" },
                new LoaiSanPham { MaLoaiSanPham = "Hoàn thành", TenLoaiSanPham = "Hoàn thành" }
            };
            comboBox.DataSource = lstTrangThai;
            comboBox.DisplayMember = "TenLoaiSanPham";
            comboBox.ValueMember = "MaLoaiSanPham";
        }


        // Định dạng các cột của chi tiết đơn đặt hàng
        private void DinhDangDGVChiTietDDH()
        {
            dgvChiTietDDH.Columns["MaDonDatHang"].Visible = false;
            dgvChiTietDDH.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvChiTietDDH.Columns["SoLuongYeuCau"].HeaderText = "Yêu cầu";
            dgvChiTietDDH.Columns["SoLuongCungCap"].HeaderText = "Cung cấp";
            dgvChiTietDDH.Columns["SoLuongThieu"].HeaderText = "Thiếu";
            dgvChiTietDDH.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTietDDH.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietDDH.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvChiTietDDH.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTietDDH.Columns["DonDatHang"].Visible = false;
            dgvChiTietDDH.Columns["SanPham"].Visible = false;
        }

        // Thêm cột số thứ tự cho DataGridView
        private void ThemCotSTT(DataGridView dgvDonDatHang)
        {
            // Kiểm tra xem cột STT đã tồn tại chưa
            if (!dgvDonDatHang.Columns.Contains("STT"))
            {
                // Thêm cột STT
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    Width = 50,
                    ReadOnly = true
                };
                dgvDonDatHang.Columns.Insert(0, sttColumn); // Chèn vào vị trí đầu tiên
            }

            // Gán giá trị cho cột STT
            for (int i = 0; i < dgvDonDatHang.Rows.Count; i++)
            {
                dgvDonDatHang.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
        }


        // Định dạng các cột của đơn dặt hàng
        private void DinhDangDGVDonDatHang()
        {
            dgvDonDatHang.Columns["MaDonDatHang"].HeaderText = "Mã đơn đặt hàng";
            dgvDonDatHang.Columns["MaNhaCungCap"].Visible = false;
            dgvDonDatHang.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvDonDatHang.Columns["NgayDatHang"].HeaderText = "Ngày đặt hàng";
            dgvDonDatHang.Columns["NgayDuKienGiao"].Visible = false;
            dgvDonDatHang.Columns["TrangThai"].Visible = false;
            dgvDonDatHang.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvDonDatHang.Columns["NgayTao"].Visible = false;
            dgvDonDatHang.Columns["NhaCungCap"].Visible = false;
            dgvDonDatHang.Columns["NhanVien"].Visible = false;
            dgvDonDatHang.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvDonDatHang.Columns["TongTien"].DefaultCellStyle.Format = "N0";
        }

        // Xử lý sự kiện tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            if (cbbLuaChonHienThi.SelectedValue == null)
            {
                return;
            }

            string luaChon = cbbLuaChonHienThi.SelectedValue.ToString();
            DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
            var danhSachDonDatHang = donDatHangBLL.LayDanhSachDonDatHang();

            // Lọc dữ liệu dựa trên lựa chọn
            switch (luaChon)
            {
                case "TatCa":
                    break; // Không cần lọc, giữ danh sách gốc
                case "NhanVien":
                    danhSachDonDatHang = danhSachDonDatHang
                        .Where(x => x.MaNhanVien == cbbNhanVien.SelectedValue?.ToString())
                        .ToList();
                    break;
                case "Ngay":
                    danhSachDonDatHang = danhSachDonDatHang
                        .Where(x => x.NgayTao.HasValue
                                 && x.NgayTao.Value >= dtpTuNgay.Value
                                 && x.NgayTao.Value <= dtpDenNgay.Value)
                        .ToList();
                    break;
                case "NCC":
                    danhSachDonDatHang = danhSachDonDatHang
                        .Where(x => x.MaNhaCungCap == cbbNhaCungCap.SelectedValue?.ToString())
                        .ToList();
                    break;
                case "TrangThai":
                    danhSachDonDatHang = danhSachDonDatHang
                        .Where(x => x.TrangThai == cbbTrangThai.SelectedValue.ToString())
                        .ToList();
                    break;
                default:
                    break;
            }

            // Gán dữ liệu vào DataGridView
            dgvDonDatHang.DataSource = danhSachDonDatHang;

            // Gọi các phương thức định dạng chung
            DinhDangDGVDonDatHang();
            ThemCotSTT(dgvDonDatHang);

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dgvDonDatHang.CurrentRow?.Cells["MaDonDatHang"]?.Value == null)
            {
                MessageBox.Show("Không có dòng nào trong danh sách đơn đặt hàng được chọn");
                return;
            }
            if (nudSLCungCap.Value > nudSLYeuCau.Value)
            {
                MessageBox.Show("Số lượng cung cấp phải nhỏ hơn hoặc bằng số lượng yêu cầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // txtDonGia không dúng định dạng số
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SanPham sp = new SanPham();
            string maSP = dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value.ToString();
            sp = new SanPhamBLL().laySanPhamTheoMa(maSP);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int soLuongCu = (int)dgvChiTietDDH.CurrentRow.Cells["SoLuongCungCap"].Value;
            int soLuongMoi = (int)nudSLCungCap.Value;
            if (soLuongMoi < soLuongCu)
            {
                MessageBox.Show("Số lượng cung cấp phải lớn hơn hoặc bằng số lượng cung cấp hiện tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Cập nhật số lượng sản phẩm
            sp.SoLuong = sp.SoLuong + (soLuongMoi - soLuongCu);
            donGia = decimal.Parse(txtDonGia.Text);
            sp.GiaNhap = donGia;
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            // Cập nhật sản phẩm
            if (sanPhamBLL.suaSanPham(sp))
            {
                ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
                ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();
                string maDDH = dgvChiTietDDH.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
                ctddh.MaDonDatHang = maDDH;
                ctddh.MaSanPham = maSP;
                ctddh = chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH).Where(x => x.MaDonDatHang == maDDH && x.MaSanPham == maSP).FirstOrDefault();
                ctddh.SoLuongYeuCau = (int)nudSLYeuCau.Value;
                ctddh.SoLuongCungCap = (int)nudSLCungCap.Value;
                ctddh.SoLuongThieu = (int)nudSLYeuCau.Value - (int)nudSLCungCap.Value;
                ctddh.DonGia = decimal.Parse(txtDonGia.Text);
                ctddh.ThanhTien = ctddh.SoLuongCungCap * ctddh.DonGia;
                // Cập nhật chi tiết đơn đặt hàng
                if (chiTietDonDatHangBLL.CapNhatChiTietDonDatHang(ctddh))
                {
                    DonDatHang ddh = new DonDatHang();
                    DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
                    ddh = donDatHangBLL.LayDanhSachDonDatHang().Where(x => x.MaDonDatHang == maDDH).FirstOrDefault();
                    ddh.TrangThai = cbbTrangThaiCTDDH.SelectedValue.ToString();
                    decimal tongTien = chiTietDonDatHangBLL.TinhTongTienDaThanhToan(maDDH);
                    ddh.TongTien = tongTien;
                    // Cập nhật đơn đặt hàng
                    if (donDatHangBLL.CapNhatDonDatHang(ddh))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoaDGVChiTietDDH();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đơn đặt hàng thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết đơn đặt hàng thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xuất file Word?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dgvDonDatHang.CurrentRow == null)
                {
                    MessageBox.Show("Không có dòng nào được chọn trong danh sách đơn đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Word Documents (*.docx)|*.docx",
                    FileName = "Báo cáo đơn đặt hàng " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".docx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Mở tài liệu Word mẫu sẵn
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        string url = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                        var document = wordApp.Documents.Open(url + @"\Resources\BaoCaoDonDatHang.docx");

                        // Thay thế các thông tin trong tài liệu Word
                        // Mã đơn đặt hàng
                        string maDDH = dgvDonDatHang.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
                        document.Bookmarks["MaDonDatHang"].Range.Text = maDDH;
                        // Ngày đặt hàng
                        DateTime ngayDatHang = DateTime.Parse(dgvDonDatHang.CurrentRow.Cells["NgayDatHang"].Value.ToString());
                        document.Bookmarks["NgayDatHang"].Range.Text = ngayDatHang.ToString("dd/MM/yyyy");
                        // Ngày giao hàng
                        DateTime ngayGiaoHang = DateTime.Now;
                        document.Bookmarks["NgayGiao"].Range.Text = ngayGiaoHang.ToString("dd/MM/yyyy HH:mm");
                        // Nhà cung cấp
                        string maNhaCungCap = dgvDonDatHang.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
                        string tenNhaCungCap = new NhaCungCapBLL().LayDanhSachNhaCungCap().Where(x => x.MaNhaCungCap == maNhaCungCap).FirstOrDefault().TenNhaCungCap;
                        document.Bookmarks["NhaCungCap"].Range.Text = tenNhaCungCap;
                        // Nhân viên
                        string maNhanVien = dgvDonDatHang.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                        string tenNhanVien = new NhanVienBLL().LayDanhSachNhanVien().Where(x => x.MaNhanVien == maNhanVien).FirstOrDefault().TenNhanVien;
                        document.Bookmarks["NhanVienTaoDon"].Range.Text = tenNhanVien;
                        // Trạng thái
                        string trangThai = dgvDonDatHang.CurrentRow.Cells["TrangThai"].Value.ToString();
                        document.Bookmarks["TrangThai"].Range.Text = trangThai;
                        // Tổng số lượng yêu cầu
                        int tongSoLuongYeuCau = 0;
                        foreach (DataGridViewRow row in dgvChiTietDDH.Rows)
                        {
                            tongSoLuongYeuCau += (int)row.Cells["SoLuongYeuCau"].Value;
                        }
                        document.Bookmarks["TongSoLuongYeuCau"].Range.Text = tongSoLuongYeuCau.ToString();
                        // Tổng số lượng cung cấp
                        int tongSoLuongCungCap = 0;
                        foreach (DataGridViewRow row in dgvChiTietDDH.Rows)
                        {
                            tongSoLuongCungCap += (int)row.Cells["SoLuongCungCap"].Value;
                        }
                        document.Bookmarks["TongSoLuongCungCap"].Range.Text = tongSoLuongCungCap.ToString();
                        // Tổng tiền
                        decimal tongTien = 0;
                        foreach (DataGridViewRow row in dgvChiTietDDH.Rows)
                        {
                            tongTien += (decimal)row.Cells["ThanhTien"].Value;
                        }
                        document.Bookmarks["TongTien"].Range.Text = tongTien.ToString("N0");
                        // Ghi chú
                        string ghiChu = dgvDonDatHang.CurrentRow.Cells["GhiChu"].Value.ToString();
                        document.Bookmarks["GhiChu"].Range.Text = ghiChu;

                        // Lấy bảng đầu tiên trong tài liệu (giả sử bảng đã được định dạng sẵn)
                        var table = document.Tables[1];

                        var lstChiTietDDH = from ctddh in new ChiTietDonDatHangBLL().LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH)
                                            select new
                                            {
                                                ctddh.MaSanPham,
                                                ctddh.SanPham.TenSanPham,
                                                ctddh.SoLuongYeuCau,
                                                ctddh.SoLuongCungCap,
                                                ctddh.SoLuongThieu,
                                                ctddh.DonGia,
                                                ctddh.ThanhTien
                                            };
                        DataGridView temp = new DataGridView();
                        temp.DataSource = lstChiTietDDH.ToList();
                        this.Controls.Add(temp);
                        // Thêm các dòng từ temp vào bảng
                        for (int i = 0; i < temp.Rows.Count; i++)
                        {
                            var newRow = table.Rows.Add();  // Thêm dòng mới vào bảng

                            // Chèn dữ liệu từ DataGridView vào các ô của bảng
                            newRow.Cells[1].Range.Text = (i + 1).ToString();
                            newRow.Cells[2].Range.Text = temp.Rows[i].Cells["MaSanPham"].Value.ToString();
                            newRow.Cells[3].Range.Text = temp.Rows[i].Cells["TenSanPham"].Value.ToString();
                            newRow.Cells[4].Range.Text = temp.Rows[i].Cells["SoLuongYeuCau"].Value.ToString();
                            newRow.Cells[5].Range.Text = temp.Rows[i].Cells["SoLuongCungCap"].Value.ToString();
                            newRow.Cells[6].Range.Text = temp.Rows[i].Cells["SoLuongThieu"].Value.ToString();
                            newRow.Cells[7].Range.Text = Convert.ToDecimal(temp.Rows[i].Cells["DonGia"].Value).ToString("N0");
                            newRow.Cells[8].Range.Text = Convert.ToDecimal(temp.Rows[i].Cells["ThanhTien"].Value).ToString("N0");
                        }                        

                        // Lưu tài liệu sau khi thêm dữ liệu
                        document.SaveAs2(saveFileDialog.FileName);
                        document.Close();
                        wordApp.Quit();
                        this.Controls.Remove(temp);
                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

