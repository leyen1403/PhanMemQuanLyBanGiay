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
                string trangThai = dgvDonDatHang.CurrentRow.Cells["TrangThai"].Value.ToString();
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


        }
    }
}

