﻿using System;
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
using DevExpress.XtraLayout.Filtering.Templates;
using System.IO;

namespace GUI
{
    public partial class frm_quanLyHoaDon : Form
    {
        HoaDonBLL _hoaDonBLL = new HoaDonBLL();
        ChiTietHoaDonBLL _chiTietHoaDonBLL = new ChiTietHoaDonBLL();
        KhachHangBLL _khachHangBLL = new KhachHangBLL();
        NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        List<HoaDon> _lstHoaDon = null;
        List<ChiTietHoaDon> _lstChiTietHoaDon = null;
        List<SanPham> _lstSanPham = null;
        List<KhachHang> _lstKhachHang = null;
        List<NhanVien> _lstNhanVien = null;

        public frm_quanLyHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_quanLyHoaDon_Load;
        }

        private void Frm_quanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
            LoadChiTietHoaDon();
            loadComBoBoxChucNang();
            loadComBoBoxTrangThaiDonHang();
            cbbLuaChonHienThi.SelectedIndexChanged += CbbLuaChonHienThi_SelectedIndexChanged;
            dgv_dsHoaDon.SelectionChanged += Dgv_dsHoaDon_SelectionChanged;
            dgv_dsCTHD.SelectionChanged += Dgv_dsCTHD_SelectionChanged;
            this.btnTim.Click += BtnTim_Click;
            this.btn_inHoaDon.Click += Btn_inHoaDon_Click;
            PlaceHolder.SetPlaceholder(txt_timKiem, "Nhập thông tin tìm kiếm:");
            dgv_dsCTHD.ReadOnly = true;
            dgv_dsHoaDon.ReadOnly = true;

        }
        private void loadComBoBoxTrangThaiDonHang()
        {
            cbo_trangThaiDon.Items.Clear();
            cbo_trangThaiDon.Items.Add("Đã nhận hàng");
            cbo_trangThaiDon.Items.Add("Đang giao hàng");
            cbo_trangThaiDon.Items.Add("Chờ xác nhận");
            cbo_trangThaiDon.Items.Add("Chờ lấy hàng");
            cbo_trangThaiDon.Items.Add("Đã hủy");
            cbo_trangThaiDon.SelectedIndex = 0;
        }

        private void Dgv_dsCTHD_SelectionChanged(object sender, EventArgs e)
        {
            // Lấy hàng được chọn hiện tại
            DataGridViewRow row = dgv_dsCTHD.CurrentRow;

            if (row != null && row.Cells["MaHoaDon"].Value != DBNull.Value)
            {
                // Gán giá trị cho các TextBox, tránh NullReferenceException
                txt_maHD.Text = row.Cells["MaHoaDon"].Value != DBNull.Value ? row.Cells["MaHoaDon"].Value.ToString() : string.Empty;
                txt_maSanPham.Text = row.Cells["MaSanPham"].Value != DBNull.Value ? row.Cells["MaSanPham"].Value.ToString() : string.Empty;
                txt_soLuong.Text = row.Cells["SoLuong"].Value != DBNull.Value ? row.Cells["SoLuong"].Value.ToString() : string.Empty;
                txt_donGia.Text = row.Cells["DonGia"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["DonGia"].Value).ToString("N0") : string.Empty;
                txt_thanhTien.Text = row.Cells["ThanhTien"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["ThanhTien"].Value).ToString("N0") : string.Empty;
            }
            else
            {
                // Xóa dữ liệu trong TextBox nếu không có dòng nào được chọn
                txt_maHD.Clear();
                txt_maSanPham.Clear();
                txt_soLuong.Clear();
                txt_donGia.Clear();
                txt_thanhTien.Clear();
            }
        }

        private void Btn_inHoaDon_Click(object sender, EventArgs e)
        {
            XuatHoaDon();
        }

        private void Dgv_dsHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            // Lấy hàng được chọn hiện tại
            DataGridViewRow row = dgv_dsHoaDon.CurrentRow;

            if (row != null && row.Cells["MaHoaDon"].Value != DBNull.Value)
            {
                // Kiểm tra và gán giá trị cho các TextBox, tránh NullReferenceException
                txt_maHDBH.Text = row.Cells["MaHoaDon"].Value != DBNull.Value ? row.Cells["MaHoaDon"].Value.ToString() : string.Empty;
                txt_maKhachHang.Text = row.Cells["MaKhachHang"].Value != DBNull.Value ? row.Cells["MaKhachHang"].Value.ToString() : string.Empty;
                txt_maNhanVien.Text = row.Cells["MaNhanVien"].Value != DBNull.Value ? row.Cells["MaNhanVien"].Value.ToString() : string.Empty;
                txt_tongTien.Text = row.Cells["TongTien"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["TongTien"].Value).ToString("N0") : string.Empty;
                txt_ghiChu.Text = row.Cells["GhiChu"].Value != DBNull.Value ? row.Cells["GhiChu"].Value.ToString() : string.Empty;
                txt_diemTichLuy.Text = row.Cells["DiemTichLuySuDung"].Value != DBNull.Value ? row.Cells["DiemTichLuySuDung"].Value.ToString() : string.Empty;
                cbo_trangThaiDon.Text = row.Cells["TrangThai"].Value != DBNull.Value ? row.Cells["TrangThai"].Value.ToString() : string.Empty;
                // Lấy mã hóa đơn và hiển thị chi tiết hóa đơn
                string maHoaDon = row.Cells["MaHoaDon"].Value.ToString();
                _lstChiTietHoaDon = _chiTietHoaDonBLL.LayChiTietHoaDonTheoMaHoaDon(maHoaDon);
                dgv_dsCTHD.DataSource = _lstChiTietHoaDon;
            }
            else
            {
                // Xử lý khi không có hàng nào được chọn, xóa dữ liệu TextBox
                txt_maHDBH.Clear();
                txt_maKhachHang.Clear();
                txt_maNhanVien.Clear();
                txt_tongTien.Clear();
                txt_ghiChu.Clear();
                txt_diemTichLuy.Clear();
                dgv_dsCTHD.DataSource = null; // Clear data source of chi tiết hóa đơn
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            // Xử lý khi người dùng chọn chức năng tìm kiếm
            switch (cbbLuaChonHienThi.SelectedIndex)
            {
                case 0: // Tìm kiếm theo Mã Nhân Viên
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            LoadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBLL.TimHoaDonTheoMaNhanVien(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 1: // Tìm kiếm theo Khoảng Thời Gian
                    try
                    {
                        DateTime tuNgay = dtpTuNgay.Value;
                        DateTime denNgay = dtpDenNgay.Value;
                        if (tuNgay > denNgay)
                        {
                            MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc");
                            return;
                        }
                        _lstHoaDon = _hoaDonBLL.TimHoaDonTheoKhoangThoiGian(tuNgay, denNgay);
                        dgv_dsHoaDon.DataSource = _lstHoaDon;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 2: // Tìm kiếm theo Mã Khách Hàng
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            LoadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBLL.TimHoaDonTheoMaKhachHang(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 3: // Tìm kiếm theo Mã Hóa Đơn
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            LoadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBLL.TimHoaDonTheoMaHoaDon(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 4: // Tìm kiếm theo Tên Khách Hàng
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            LoadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBLL.TimHoaDonTheoTenKhachHangHoacSDT(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 5: // Tìm kiếm theo Tên Nhân Viên
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            LoadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBLL.TimKiemHoaDonTheoTenNhanVien(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 6:
                    try
                    {
                        LoadHoaDon();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    txt_timKiem.Text = "Nhập giá trị tìm kiếm:";
                    break;
            }
        }

        private void CbbLuaChonHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lấy giá trị của combobox
            int index = cbbLuaChonHienThi.SelectedIndex;
            if (index >= 0)
            {
                switch (index)
                {
                    case 0:
                        txt_timKiem.Enabled = true;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;
                        break;
                    case 1:
                        txt_timKiem.Enabled = false;
                        dtpTuNgay.Enabled = true;
                        dtpDenNgay.Enabled = true;
                        break;
                    case 2:
                        txt_timKiem.Enabled = true;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;
                        break;
                    case 3:
                        txt_timKiem.Enabled = true;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;
                        break;
                    case 4:
                        txt_timKiem.Enabled = true;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;
                        break;
                    case 5:
                        txt_timKiem.Enabled = true;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;
                        break;
                    case 6:
                        txt_timKiem.Enabled = false;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;
                        break;
                    case 7:
                        txt_timKiem.Enabled = false;
                        dtpTuNgay.Enabled = false;
                        dtpDenNgay.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //viết hàm ở dưới
        //Xuất hoá đơn ra word
        private void XuatHoaDon()
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xuất file Word?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Word Documents (*.docx)|*.docx",
                    FileName = "Hoa-Don-(" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ").docx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Mở tài liệu Word mẫu sẵn
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        string url = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                        var document = wordApp.Documents.Open(url + @"\Resources\hoa-don-ban-hang-file-word.docx");
                        string maHoaDon = txt_maHDBH.Text;
                        HoaDon hd = _hoaDonBLL.TimHoaDonTheoMaHoaDon(maHoaDon).FirstOrDefault();
                        if (hd == null)
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        KhachHang kh = _khachHangBLL.LayKhachHangTheoDieuKien(hd.MaKhachHang, string.Empty, string.Empty);
                        NhanVien nv = _nhanVienBLL.LayNhanVien(hd.MaNhanVien);
                        if (kh == null || nv == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin khách hàng hoặc nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string tenNhanVien = nv.TenNhanVien;
                        string tenKhachHang = kh.TenKhachHang;
                        string DiaChi = kh.DiaChi;
                        string soDienThoai = kh.SoDienThoai;

                        // Thay thế các thông tin trong tài liệu Word
                        document.Bookmarks["NgayLap"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        document.Bookmarks["TenNhanVien"].Range.Text = tenNhanVien;
                        document.Bookmarks["MaHoaDonBanHang"].Range.Text = maHoaDon;
                        document.Bookmarks["TenKhachHang"].Range.Text = tenKhachHang;
                        document.Bookmarks["DiaChi"].Range.Text = DiaChi;
                        document.Bookmarks["SDT"].Range.Text = soDienThoai;

                        // Lấy bảng đầu tiên trong tài liệu (giả sử bảng đã được định dạng sẵn)
                        var table = document.Tables[1];

                        var lstCTHD = from cthd in new ChiTietHoaDonBLL().LayTatCaChiTietHoaDon().Where(x => x.MaHoaDon == maHoaDon)
                                      select new
                                      {
                                          cthd.SanPham.TenSanPham,
                                          cthd.SoLuong,
                                          cthd.DonGia,
                                          cthd.ThanhTien
                                      };

                        DataGridView dgvTemp = new DataGridView();
                        dgvTemp.Name = "dgvTemp";
                        dgvTemp.DataSource = lstCTHD.ToList();
                        this.Controls.Add(dgvTemp);
                        for (int i = 0; i < dgvTemp.Rows.Count; i++)
                        {
                            var newRow = table.Rows.Add();
                            newRow.Cells[1].Range.Text = (i + 1).ToString();
                            newRow.Cells[2].Range.Text = dgvTemp.Rows[i].Cells["TenSanPham"].Value.ToString();
                            newRow.Cells[3].Range.Text = dgvTemp.Rows[i].Cells["SoLuong"].Value.ToString();
                            newRow.Cells[4].Range.Text = Convert.ToDecimal(dgvTemp.Rows[i].Cells["DonGia"].Value).ToString("N0") + " VNĐ";
                            newRow.Cells[5].Range.Text = Convert.ToDecimal(dgvTemp.Rows[i].Cells["ThanhTien"].Value).ToString("N0") + " VNĐ";
                        }
                        var tongTien = (decimal)lstCTHD.Sum(x => x.ThanhTien);
                        document.Bookmarks["TongTien"].Range.Text = tongTien.ToString("N0") + " VNĐ";
                        // Lưu tài liệu sau khi thêm dữ liệu
                        document.SaveAs2(saveFileDialog.FileName);
                        document.Close();
                        wordApp.Quit();
                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Controls.Remove(dgvTemp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void loadComBoBoxChucNang()
        {
            cbbLuaChonHienThi.Items.Clear();
            // Thêm các chức năng tìm kiếm vào ComboBox
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Mã Nhân Viên");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Khoảng Thời Gian");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Mã Khách Hàng");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Mã Hóa Đơn");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Tên Khách Hàng");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Tên Nhân Viên");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm tất cả");
            // Đặt mặc định cho ComboBox
            cbbLuaChonHienThi.SelectedIndex = 0;
        }
        // khởi tạo dữ liệu tiêu đề cho datagridview
        private void IniDataGirdViewCTHD()
        {
            //set tiêu đề
            if (dgv_dsCTHD != null)
            {
                // Sửa tên cột đã có
                dgv_dsCTHD.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dgv_dsCTHD.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                dgv_dsCTHD.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgv_dsCTHD.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgv_dsCTHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                //căn chỉnh độ rộng cột tự động
                dgv_dsCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_dsCTHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                // Đặt lại định dạng cột "DonGia" và "ThanhTien" cho số tiền
                dgv_dsCTHD.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ
                dgv_dsCTHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ

                // Đặt cột "SoLuong" chỉ nhận giá trị số nguyên
                dgv_dsCTHD.Columns["SoLuong"].ValueType = typeof(int);

                //ẩn cột không cần thiết
                dgv_dsCTHD.Columns["HoaDon"].Visible = false;
                dgv_dsCTHD.Columns["SanPham"].Visible = false;
            }

        }
        private void IniDataGirdViewHoaDon()
        {
            if (dgv_dsHoaDon != null)
            {
                // sét tiêu đề
                dgv_dsHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dgv_dsHoaDon.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                dgv_dsHoaDon.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgv_dsHoaDon.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                dgv_dsHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgv_dsHoaDon.Columns["GhiChu"].HeaderText = "Ghi Chú";
                dgv_dsHoaDon.Columns["DiemTichLuySuDung"].HeaderText = "Sử dụng điểm";
                dgv_dsHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương Thức Thanh Toán";
                dgv_dsHoaDon.Columns["TrangThai"].HeaderText = "Trạng Thái Đơn Hàng";
                //căn chỉnh độ rộng cột
                // Thiết lập chế độ tự động dàn đều cột và đồng thời điều chỉnh chiều cao của hàng
                dgv_dsHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_dsHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                //in đậm tiêu đề
                dgv_dsHoaDon.Columns[0].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                dgv_dsHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";  // Định dạng tiền tệ

                //ẩn cột không cần thiết
                dgv_dsHoaDon.Columns["KhachHang"].Visible = false;
                dgv_dsHoaDon.Columns["NhanVien"].Visible = false;
            }

        }
        private void LoadHoaDon()
        {
            try
            {
                _lstHoaDon = new List<HoaDon>();
                _lstHoaDon = _hoaDonBLL.LayTatCaHoaDon();
                dgv_dsHoaDon.DataSource = _lstHoaDon;
                IniDataGirdViewHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadChiTietHoaDon()
        {
            try
            {
                _lstChiTietHoaDon = new List<ChiTietHoaDon>();
                _lstChiTietHoaDon = _chiTietHoaDonBLL.LayTatCaChiTietHoaDon();
                dgv_dsCTHD.DataSource = _lstChiTietHoaDon;
                IniDataGirdViewCTHD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_luuHoaDon_Click(object sender, EventArgs e)
        {
            //cập nhật trạng thái đơn hàng
            try
            {
                //lấy mã hoá đơn từ textbox và combobox
                string maHoaDon = txt_maHDBH.Text;
                string trangThaiDonHang = cbo_trangThaiDon.Text;
                //kiểm tra mã hoá đơn và trạng thái đơn hàng
                if (string.IsNullOrEmpty(maHoaDon) || string.IsNullOrEmpty(trangThaiDonHang))
                {
                    MessageBox.Show("Mã hoá đơn và trạng thái đơn hàng không được để trống");
                    return;
                }
                //cập nhật trạng thái đơn hàng

                if (_hoaDonBLL.CapNhatDonHang(maHoaDon, trangThaiDonHang))
                {
                    MessageBox.Show("Đã cập nhật trạng thái đơn hàng");
                    LoadHoaDon();
                    btn_luuHoaDon.BackColor = Color.Navy;
                }
                if (trangThaiDonHang == "Chờ lấy hàng")
                {
                    //cập nhật điểm tích lũy
                    HoaDon hd = _hoaDonBLL.TimHoaDonTheoMaHoaDon(maHoaDon).FirstOrDefault();
                    if (hd == null)
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    KhachHang kh = _khachHangBLL.LayKhachHangTheoDieuKien(hd.MaKhachHang, string.Empty, string.Empty);
                    if (kh == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    decimal diemTichLuy = kh.DiemTichLuy ?? 0;
                    decimal diemTichLuySuDung = hd.DiemTichLuySuDung ?? 0;
                    decimal diemTichLuyMoi = diemTichLuy - diemTichLuySuDung;
                    if (diemTichLuyMoi < 0)
                    {
                        //MessageBox.Show("Không đủ điểm tích lũy để sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (_khachHangBLL.AddDiemCongTichLuy(hd.MaKhachHang, diemTichLuyMoi))
                    {
                        //MessageBox.Show("Cập nhật điểm tích lũy thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật điểm tích lũy thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var lstCTHD = _chiTietHoaDonBLL.LayChiTietHoaDonTheoMaHoaDon(maHoaDon);
                    UpdateProductStock(lstCTHD);
                }

            }
            catch
            {
                MessageBox.Show("Cập nhật trạng thái đơn hàng thất bại");

            }
        }
              //hàm
        private void UpdateProductStock(List<ChiTietHoaDon> chiTietHoaDonList)
        {
            try
            {
                // Lặp qua từng sản phẩm trong danh sách chi tiết hóa đơn
                foreach (var chiTiet in chiTietHoaDonList)
                {
                    string maSanPham = chiTiet.MaSanPham;
                    int soLuongBan = chiTiet.SoLuong ?? 0;

                    // Lấy thông tin sản phẩm từ cơ sở dữ liệu
                    var sanPham = _sanPhamBLL.LaySanPhamTheoMa(maSanPham);

                    if (sanPham != null)
                    {
                        // Trừ số lượng bán từ số lượng tồn
                        sanPham.SoLuong -= soLuongBan;

                        // Kiểm tra nếu số lượng tồn âm (cảnh báo)
                        if (sanPham.SoLuong < 0)
                        {
                            MessageBox.Show($"Sản phẩm {sanPham.TenSanPham} không đủ hàng trong kho.");
                            sanPham.SoLuong = 0; // Đảm bảo không để số lượng tồn âm
                        }

                        // Cập nhật sản phẩm vào cơ sở dữ liệu
                        _sanPhamBLL.suaSanPham(sanPham);
                    }
                    else
                    {
                        MessageBox.Show($"Sản phẩm với mã {maSanPham} không tồn tại.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật tồn kho: {ex.Message}");
                //MessageBox.Show($"Có lỗi xảy ra khi cập nhật tồn kho: {ex.Message}");
            }
        }
    }
}
