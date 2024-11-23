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
using System.Data.Linq;

namespace GUI
{
    public partial class frm_ThemPhieuDoiTra : Form
    {
        public string MaNhanVien { get; set; }
        public frm_ThemPhieuDoiTra()
        {
            InitializeComponent();
        }

        private void frm_ThemPhieuDoiTra_Load(object sender, EventArgs e)
        {

            string maPhieu = taoMaPhieu();
            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            NhanVien nhanVien = nhanVienBLL.LayNhanVienTheoMa(MaNhanVien);
            MaNhanVien = nhanVien.MaNhanVien;
            lblMaPhieu.Text = maPhieu;
            lblMaNhanVien.Text = nhanVien.MaNhanVien;
            lblTenNhanVien.Text = nhanVien.TenNhanVien;
            lblNgayLap.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private string taoMaPhieu()
        {
            TraSanPhamBLL traSanPhamBLL = new TraSanPhamBLL();
            TraSanPham traSanPham = traSanPhamBLL.LayTraSanPhamCuoiCung();
            if (traSanPham == null)
            {
                return "TSP001";
            }
            else
            {
                int so = int.Parse(traSanPham.MaTraSanPham.Substring(3)) + 1;
                if (so < 10)
                {
                    return "TSP00" + so;
                }
                else if (so < 100)
                {
                    return "TSP0" + so;
                }
                else if (so < 1000)
                {
                    return "TSP" + so;
                }
            }
            return "";
        }

        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtTimHoaDon.Text;
            timSanPhamTheoMaHoaDon(maHoaDon);
        }

        private void timSanPhamTheoMaHoaDon(string maHoaDon)
        {
            HoaDonBLL hoaDonBLL = new HoaDonBLL();
            HoaDon hoaDon = hoaDonBLL.TimHoaDonTheoMaHoaDon(maHoaDon).FirstOrDefault();
            if (hoaDon == null)
            {
                MessageBox.Show("Không tìm thấy hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lblMaKhachHang.Text = hoaDon.MaKhachHang;
            lblTenKhachHang.Text = hoaDon.KhachHang.TenKhachHang;
            var data = layDanhSachSanPham(hoaDon.MaHoaDon);
            dgvSanPhamTrongHoaDon.DataSource = data;
            dinhDangDGVSanPhamTrongHoaDon();
        }

        private List<SanPhamDoiTraDTO> layDanhSachSanPham(string maHoaDon)
        {
            ChiTietHoaDonBLL chiTietHoaDonBLL = new ChiTietHoaDonBLL();
            List<ChiTietHoaDon> lstChiTietHoaDon = chiTietHoaDonBLL.LayDanhSachChiTietHoaDonTheoMaHoaDon(maHoaDon);

            // Chuyển đổi dữ liệu từ ChiTietHoaDon sang SanPhamDoiTraDTO
            var data = (from cthd in lstChiTietHoaDon
                        select new SanPhamDoiTraDTO
                        {
                            MaSanPham = cthd.MaSanPham,
                            TenSanPham = cthd.SanPham.TenSanPham,
                            SLHD = cthd.SoLuong ?? 0,
                            SLTra = 0, // Ban đầu số lượng đổi trả là 0
                            GiaBan = cthd.DonGia ?? 0, // Giá bán từ hóa đơn
                            SoTienHoanLai = 0, // Ban đầu là 0
                            TinhTrangSanPham = string.Empty // Ban đầu để trống
                        }).ToList();
            return data.ToList();
        }

        private void dinhDangDGVSanPhamTrongHoaDon()
        {
            dgvSanPhamTrongHoaDon.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvSanPhamTrongHoaDon.Columns["MaSanPham"].ReadOnly = true;

            dgvSanPhamTrongHoaDon.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSanPhamTrongHoaDon.Columns["TenSanPham"].ReadOnly = true;

            dgvSanPhamTrongHoaDon.Columns["SLHD"].HeaderText = "Số lượng hóa đơn";
            dgvSanPhamTrongHoaDon.Columns["SLHD"].ReadOnly = true;
            dgvSanPhamTrongHoaDon.Columns["SLHD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSanPhamTrongHoaDon.Columns["SLTra"].HeaderText = "Số lượng trả";
            dgvSanPhamTrongHoaDon.Columns["SLTra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSanPhamTrongHoaDon.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvSanPhamTrongHoaDon.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvSanPhamTrongHoaDon.Columns["GiaBan"].ReadOnly = true;
            dgvSanPhamTrongHoaDon.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSanPhamTrongHoaDon.Columns["SoTienHoanLai"].HeaderText = "Số tiền hoàn lại";
            dgvSanPhamTrongHoaDon.Columns["SoTienHoanLai"].DefaultCellStyle.Format = "N0";
            dgvSanPhamTrongHoaDon.Columns["SoTienHoanLai"].ReadOnly = true;
            dgvSanPhamTrongHoaDon.Columns["SoTienHoanLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSanPhamTrongHoaDon.Columns["TinhTrangSanPham"].HeaderText = "Tình trạng sản phẩm";

        }

        private void txtTimHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string maHoaDon = txtTimHoaDon.Text.Trim();
                if (!string.IsNullOrEmpty(maHoaDon))
                {
                    // Gọi hàm tìm kiếm sản phẩm theo mã hóa đơn
                    timSanPhamTheoMaHoaDon(maHoaDon);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Ngăn chặn xử lý phím Enter mặc định
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dgvSanPhamTrongHoaDon_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox textBox = e.Control as TextBox;
            if (textBox != null)
            {
                // Hủy đăng ký sự kiện cũ để tránh lỗi lặp
                textBox.KeyPress -= TextBox_KeyPress_ChiNhapSo;

                // Kiểm tra nếu đang chỉnh sửa cột "SLTra"
                if (dgvSanPhamTrongHoaDon.CurrentCell.ColumnIndex == dgvSanPhamTrongHoaDon.Columns["SLTra"].Index)
                {
                    // Chỉ cho phép nhập số
                    textBox.KeyPress += TextBox_KeyPress_ChiNhapSo;
                }
            }
        }

        private void TextBox_KeyPress_ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số (0-9) và phím Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }
        }

        private void dgvSanPhamTrongHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy chỉ số hàng và cột
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex < 0 || columnIndex < 0) return; // Bỏ qua nếu không phải ô dữ liệu

            // Tên cột đang chỉnh sửa
            string columnName = dgvSanPhamTrongHoaDon.Columns[columnIndex].Name;

            // Kiểm tra cột "SLTra"
            if (columnName == "SLTra")
            {
                // Lấy giá trị trong cột SLTra
                int slTra = 0;
                int slHd = 0; // Số lượng trong hóa đơn
                decimal giaBan = 0; // Giá bán

                // Kiểm tra và xử lý giá trị số lượng trả
                var cellSLTra = dgvSanPhamTrongHoaDon.Rows[rowIndex].Cells["SLTra"];
                if (cellSLTra.Value == null || !int.TryParse(cellSLTra.Value.ToString(), out slTra))
                {
                    slTra = 0;
                    cellSLTra.Value = 0; // Gán mặc định 0 nếu giá trị không hợp lệ
                }

                // Lấy giá trị số lượng hóa đơn
                var cellSLHD = dgvSanPhamTrongHoaDon.Rows[rowIndex].Cells["SLHD"];
                if (cellSLHD.Value != null) int.TryParse(cellSLHD.Value.ToString(), out slHd);

                // Kiểm tra số lượng trả có lớn hơn số lượng trong hóa đơn
                if (slTra > slHd)
                {
                    MessageBox.Show("Số lượng trả không được lớn hơn số lượng trong hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cellSLTra.Value = 0; // Gán lại giá trị mặc định là 0
                    return;
                }

                // Lấy giá trị giá bán
                var cellGiaBan = dgvSanPhamTrongHoaDon.Rows[rowIndex].Cells["GiaBan"];
                if (cellGiaBan.Value != null) decimal.TryParse(cellGiaBan.Value.ToString(), out giaBan);

                // Tính toán số tiền hoàn lại và cập nhật
                decimal soTienHoanLai = slTra * giaBan;
                dgvSanPhamTrongHoaDon.Rows[rowIndex].Cells["SoTienHoanLai"].Value = soTienHoanLai;
            }

            // Kiểm tra cột "TinhTrangSanPham"
            if (columnName == "TinhTrangSanPham")
            {
                var cellTinhTrang = dgvSanPhamTrongHoaDon.Rows[rowIndex].Cells["TinhTrangSanPham"];
                if (cellTinhTrang.Value == null || string.IsNullOrWhiteSpace(cellTinhTrang.Value.ToString()))
                {
                    cellTinhTrang.Value = string.Empty; // Gán giá trị mặc định là chuỗi rỗng
                }
            }

            // Cập nhật lblTongTien bằng tổng cột SoTienHoanLai
            UpdateTongTien();
        }

        private void UpdateTongTien()
        {
            decimal tongTien = 0;

            // Lặp qua tất cả các hàng trong DataGridView
            foreach (DataGridViewRow row in dgvSanPhamTrongHoaDon.Rows)
            {
                // Kiểm tra giá trị trong cột SoTienHoanLai
                if (row.Cells["SoTienHoanLai"].Value != null && decimal.TryParse(row.Cells["SoTienHoanLai"].Value.ToString(), out decimal soTienHoanLai))
                {
                    tongTien += soTienHoanLai; // Cộng dồn vào tổng
                }
            }

            // Cập nhật lblTongTien
            lblTongTien.Text = tongTien.ToString("N0"); // Hiển thị dưới dạng tiền tệ (hoặc thay đổi định dạng nếu cần)
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi lưu
            DialogResult result = MessageBox.Show("Xác nhận lưu phiếu đổi trả?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Kiểm tra các trường dữ liệu bắt buộc
                if (string.IsNullOrWhiteSpace(txtTimHoaDon.Text) ||
                    string.IsNullOrWhiteSpace(lblMaKhachHang.Text) ||
                    string.IsNullOrWhiteSpace(txtLyDoTra.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giá trị tổng tiền hoàn lại
                decimal tongTienHoanLai = 0;
                if (!decimal.TryParse(lblTongTien.Text, out tongTienHoanLai) || tongTienHoanLai <= 0)
                {
                    MessageBox.Show("Tổng tiền hoàn lại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng TraSanPham
                TraSanPhamBLL traSanPhamBLL = new TraSanPhamBLL();
                TraSanPhamChiTietBLL traSanPhamChiTietBLL = new TraSanPhamChiTietBLL();
                List<TraSanPhamChiTiet> lstTraSanPhamChiTiet = new List<TraSanPhamChiTiet>();

                foreach (DataGridViewRow row in dgvSanPhamTrongHoaDon.Rows)
                {
                    // Lấy giá trị số lượng trả (SLTra) và tình trạng sản phẩm từ cột trong DataGridView
                    int slTra = 0;
                    string tinhTrang = row.Cells["TinhTrangSanPham"].Value != null ? row.Cells["TinhTrangSanPham"].Value.ToString() : string.Empty;

                    if (row.Cells["SLTra"].Value != null && int.TryParse(row.Cells["SLTra"].Value.ToString(), out slTra) && slTra > 0)
                    {
                        // Tạo đối tượng TraSanPhamChiTiet
                        TraSanPhamChiTiet chiTiet = new TraSanPhamChiTiet
                        {
                            MaTraSanPham = lblMaPhieu.Text,
                            MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                            MaHoaDon = txtTimHoaDon.Text,
                            SoLuong = slTra,
                            TinhTrangSanPham = tinhTrang, // Gán giá trị Tình trạng sản phẩm
                            SoTienHoanLai = slTra * decimal.Parse(row.Cells["GiaBan"].Value.ToString()) // Tính số tiền hoàn lại
                        };

                        // Thêm chi tiết vào danh sách
                        lstTraSanPhamChiTiet.Add(chiTiet);
                    }
                }

                TraSanPham traSanPham = new TraSanPham
                {
                    MaTraSanPham = lblMaPhieu.Text,
                    MaHoaDon = txtTimHoaDon.Text,
                    MaKhachHang = lblMaKhachHang.Text,
                    MaNhanVien = lblMaNhanVien.Text,
                    LyDoTra = txtLyDoTra.Text,
                    NgayTra = DateTime.Now,
                    TongTienHoanLai = tongTienHoanLai,
                };

                // Thực hiện thêm phiếu đổi trả
                bool themTraSanPham = traSanPhamBLL.ThemTraSanPham(traSanPham);
                bool themTraSanPhamChiTiet = traSanPhamChiTietBLL.ThemListTraSanPhamChiTiet(lstTraSanPhamChiTiet);
                if (themTraSanPham && themTraSanPhamChiTiet)
                {
                    MessageBox.Show("Thêm phiếu đổi trả thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng cửa sổ sau khi thêm thành công
                }
                else
                {
                    MessageBox.Show("Thêm phiếu đổi trả thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận trước khi hủy
            DialogResult result = MessageBox.Show("Xác nhận hủy phiếu đổi trả?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng cửa sổ
            }
        }

        private void dgvSanPhamTrongHoaDon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu là cột "SLTra" (Số lượng trả)
            if (dgvSanPhamTrongHoaDon.Columns[e.ColumnIndex].Name == "SLTra")
            {
                // Kiểm tra giá trị của SLTra
                if (e.Value != null)
                {
                    int slTra = 0;
                    if (int.TryParse(e.Value.ToString(), out slTra) && slTra > 0)
                    {
                        // Tô màu dòng nếu SLTra > 0
                        dgvSanPhamTrongHoaDon.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen; // Màu nền của dòng
                    }
                    else
                    {
                        // Đặt lại màu nền mặc định
                        dgvSanPhamTrongHoaDon.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvSanPhamTrongHoaDon.DefaultCellStyle.BackColor;
                    }
                }
            }
        }

    }
}
