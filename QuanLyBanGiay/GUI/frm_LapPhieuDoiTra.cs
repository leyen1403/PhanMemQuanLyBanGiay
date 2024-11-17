using BLL;
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

namespace GUI
{
    public partial class frm_LapPhieuDoiTra : Form
    {
        public string MaNhanVien { get; set; }
        public string LyDoDoiTra { get; set; }
        private string MaTraSanPham { get; set; }

        HoaDonBLL hoaDonBLL = new HoaDonBLL();
        KhachHangBLL khachHangBLL = new KhachHangBLL();
        ChiTietHoaDonBLL chiTietHoaDonBLL = new ChiTietHoaDonBLL();
        TraSanPhamBLL traSanPhamBll = new TraSanPhamBLL();
        TraSanPhamChiTietBLL traSanPhamChiTietBLL = new TraSanPhamChiTietBLL();
        HoaDon _HoaDon = new HoaDon();
        KhachHang _KhachHang = new KhachHang();
        List<ChiTietHoaDon> _ListChiTietHoaDon = new List<ChiTietHoaDon>();
        TraSanPham traSanPham = new TraSanPham();

        public frm_LapPhieuDoiTra()
        {
            InitializeComponent();
        }

        private void frm_LapPhieuDoiTra_Load(object sender, EventArgs e)
        {
            AddPlaceholder(txtMaHD, "Nhập mã hóa đơn");
        }

        // Thêm placeholder cho TextBox
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            traSanPham.MaTraSanPham = null;
            string maHD;
            if (txtMaHD.Text == "Nhập mã hóa đơn" || txtMaHD.Text == "")
            {
                maHD = "";
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần tìm!");
            }
            else
            {
                maHD = txtMaHD.Text;
                // Xử lý tìm hóa đơn
                HoaDon hd = new HoaDon();
                hd = hoaDonBLL.TimHoaDonTheoMaHoaDon(maHD).FirstOrDefault();
                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn!");
                }
                else
                {
                    // Gán cho biến toàn cục
                    _HoaDon = hd;
                    _ListChiTietHoaDon = chiTietHoaDonBLL.LayChiTietHoaDonTheoMaHoaDon(maHD);
                    // Hiển thị ngày lập hóa đơn
                    if (_HoaDon.NgayTao != null)
                    {
                        dtpNgayTao.Value = (DateTime)_HoaDon.NgayTao;
                    }
                    else
                    {
                        dtpNgayTao.Value = DateTime.Now;
                    }
                    // Hiển thị người lập hóa đơn
                    if (_HoaDon.NhanVien.TenNhanVien != null)
                    {
                        txtTenNhanVien.Text = _HoaDon.NhanVien.TenNhanVien;
                    }
                    else
                    {
                        txtTenNhanVien.Text = "";
                    }
                    // Hiển thị sản phẩm đã mua
                    var dataDGVChiTietHD = from cthd in _ListChiTietHoaDon
                                           select new
                                           {
                                               cthd.MaHoaDon,
                                               cthd.MaSanPham,
                                               cthd.SanPham.TenSanPham,
                                               cthd.SoLuong,
                                               cthd.DonGia,
                                               cthd.ThanhTien
                                           };
                    if (_ListChiTietHoaDon != null && _ListChiTietHoaDon.Any())
                    {
                        dgvChiTietDDH.DataSource = dataDGVChiTietHD.ToList();
                        DinhDangDGVChiTietDH();
                    }
                    else
                    {
                        MessageBox.Show("Không có chi tiết hóa đơn.");
                        dgvChiTietDDH.DataSource = null;
                    }
                }
            }
        }

        private void DinhDangDGVChiTietDH()
        {
            if (dgvChiTietDDH != null)
            {
                themCotSoThuTu(dgvChiTietDDH);
                dgvChiTietDDH.Columns["MaHoaDon"].Visible = false;
                dgvChiTietDDH.Columns["MaSanPham"].Visible = false;
                dgvChiTietDDH.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                dgvChiTietDDH.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvChiTietDDH.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvChiTietDDH.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                dgvChiTietDDH.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTietDDH.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
            else
            {
                MessageBox.Show("DataGridView chưa có dữ liệu");
            }
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

        private void dgvChiTietDDH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChiTietDDH.Columns.Contains("MaSanPham"))
            {
                if (dgvChiTietDDH.CurrentRow != null)
                {
                    string maSanPham = dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value?.ToString();
                    if (maSanPham != null)
                    {
                        ChiTietHoaDon cthd = new ChiTietHoaDon();
                        cthd = chiTietHoaDonBLL
                            .TimChiTietHoaDonTheoMaHoaDon(_HoaDon.MaHoaDon)
                            .Where(x => x.MaSanPham == maSanPham)
                            .FirstOrDefault();
                        if (cthd != null)
                        {
                            // Hiển thị chi tiết sản phẩm trong hoá đơn
                            txtMaSanPham.Text = cthd.MaSanPham;
                            txtSize.Text = cthd.SanPham.KichThuoc.TenKichThuoc;
                            txtMau.Text = cthd.SanPham.MauSac.TenMauSac;
                            txtThuongHieu.Text = cthd.SanPham.ThuongHieu.TenThuongHieu;
                            txtLoai.Text = cthd.SanPham.LoaiSanPham.TenLoaiSanPham;
                            txtTenSanPham.Text = cthd.SanPham.TenSanPham;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã sản phẩm");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không thấy giá trị của chi tiết hoá đơn này");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Cột mã sản phẩm không tồn tại");
                return;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSanPham, maHoaDon, tinhTrangSanPham;
            int soLuongHoanTra, soLuongDaMua;
            decimal soTienHoanLai;
            if (!string.IsNullOrEmpty(txtMaSanPham.Text))
            {
                maSanPham = txtMaSanPham.Text;
                maHoaDon = _HoaDon.MaHoaDon;
                soLuongHoanTra = (int)nudSoLuong.Value;
                if(soLuongHoanTra <=0)
                {
                    MessageBox.Show("Số lượng hoàn trả phải lớn hơn 0");
                    return;
                }
                soLuongDaMua = (int)_HoaDon.ChiTietHoaDons.FirstOrDefault(x => x.MaSanPham == maSanPham).SoLuong;
                if (soLuongHoanTra <= soLuongDaMua)
                {
                    tinhTrangSanPham = txtTinhTrangSanPham.Text;
                    decimal soLuong, donGia;
                    soLuong = soLuongHoanTra;
                    donGia = (decimal)_HoaDon.ChiTietHoaDons.FirstOrDefault(x => x.MaSanPham == maSanPham).DonGia;
                    soTienHoanLai = soLuong * donGia * 0.9m;
                    if(traSanPham.MaTraSanPham == null)
                    {
                        // Tạo mã trả sản phẩm
                        string maTraSanPham = taoMaTraSanPham();
                        traSanPham.MaTraSanPham = maTraSanPham;
                        traSanPham.MaHoaDon = maHoaDon;
                        traSanPham.MaNhanVien = MaNhanVien;
                        traSanPham.MaKhachHang = _HoaDon.MaKhachHang;
                        if(LyDoDoiTra != null)
                        {
                            traSanPham.LyDoTra = LyDoDoiTra;
                        }
                        else
                        {
                            traSanPham.LyDoTra = "Đổi trả";
                        }
                        traSanPham.NgayTra = dtpNgayTao.Value;
                        traSanPham.TongTienHoanLai = 0;
                        if (traSanPhamBll.ThemTraSanPham(traSanPham))
                        {
                            MaTraSanPham = maTraSanPham;
                            TraSanPhamChiTiet traSanPhamChiTiet = new TraSanPhamChiTiet();
                            traSanPhamChiTiet.MaTraSanPham = maTraSanPham;
                            traSanPhamChiTiet.MaSanPham = maSanPham;
                            traSanPhamChiTiet.MaHoaDon = maHoaDon;
                            traSanPhamChiTiet.SoLuong = (int)soLuong;
                            traSanPhamChiTiet.TinhTrangSanPham = tinhTrangSanPham;
                            traSanPhamChiTiet.SoTienHoanLai = soTienHoanLai;
                            if (traSanPhamChiTietBLL.ThemTraSanPhamChiTiet(traSanPhamChiTiet))
                            {
                                MessageBox.Show("Thêm trả sản phẩm thành công");
                                loadDGVTraSanPhamChiTiet();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Thêm trả sản phẩm thất bại");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thêm trả sản phẩm thất bại");
                            return;
                        }
                    }
                    else
                    {
                        TraSanPhamChiTiet traSanPhamChiTiet = new TraSanPhamChiTiet();
                        traSanPhamChiTiet.MaTraSanPham = MaTraSanPham;
                        traSanPhamChiTiet.MaSanPham = maSanPham;
                        traSanPhamChiTiet.MaHoaDon = maHoaDon;
                        traSanPhamChiTiet.SoLuong = (int)soLuong;
                        traSanPhamChiTiet.TinhTrangSanPham = tinhTrangSanPham;
                        traSanPhamChiTiet.SoTienHoanLai = soTienHoanLai;
                        if (traSanPhamChiTietBLL.ThemTraSanPhamChiTiet(traSanPhamChiTiet))
                        {
                            MessageBox.Show("Thêm trả sản phẩm thành công");
                            loadDGVTraSanPhamChiTiet();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Thêm trả sản phẩm thất bại");
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Số lượng hoàn trả không được lớn hơn số lượng đã mua");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mã sản phẩm không tồn tại");
                return;
            }
        }

        private void loadDGVTraSanPhamChiTiet()
        {
            string maTraSanPham = MaTraSanPham;
            var data = from tspct in traSanPhamChiTietBLL.LayTraSanPhamChiTietTheoMaTraSanPham(maTraSanPham)
                       select new
                       {
                           tspct.ChiTietHoaDon.SanPham.TenSanPham,
                           tspct.MaHoaDon,
                           tspct.SoLuong,
                           tspct.TinhTrangSanPham,
                           tspct.SoTienHoanLai
                       };
            dgvTraSanPhamChiTiet.DataSource = data.ToList();
        }

        private string taoMaTraSanPham()
        {
            List<TraSanPham> lstTSP = new TraSanPhamBLL().LayDanhSachTraSanPham();
            if (lstTSP.Count == 0)
            {
                return "TSP001";
            }
            else
            {
                string maTraSanPhamCuoi = lstTSP.OrderByDescending(x => x.MaTraSanPham).FirstOrDefault().MaTraSanPham;
                string soCuoi = maTraSanPhamCuoi.Substring(3);
                int soMoi = int.Parse(soCuoi) + 1;
                string maTraSanPhamMoi = "TSP" + soMoi.ToString().PadLeft(3, '0');
                return maTraSanPhamMoi;
            }
        }
    }
}
