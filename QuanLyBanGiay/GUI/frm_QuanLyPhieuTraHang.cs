using BLL;
using DevExpress.Data.Helpers;
using DevExpress.Data.Svg;
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
    public partial class frm_QuanLyPhieuTraHang : Form
    {
        public string MaNhanVien { get; set; }
        public frm_QuanLyPhieuTraHang()
        {
            InitializeComponent();
        }

        private void frm_QuanLyPhieuTraHang_Load(object sender, EventArgs e)
        {
            loadDGVDanhSachPhieuHoanTra();
            SetPlaceholder(txtTim, "Nhập mã hoá đơn, mã trả sản phẩm, mã nhân viên, tên nhân viên, mã khách hàng, tên khách hàng, ngày lập,...");
        }
        private void SetPlaceholder(TextBox txtBox, string placeholderText)
        {
            txtBox.Text = placeholderText;
            txtBox.ForeColor = Color.Gray;

            // Sự kiện khi người dùng click vào TextBox
            txtBox.Enter += (sender, e) =>
            {
                if (txtBox.Text == placeholderText)
                {
                    txtBox.Text = "";
                    txtBox.ForeColor = Color.Black;
                }
            };

            // Sự kiện khi người dùng rời khỏi TextBox
            txtBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBox.Text))
                {
                    txtBox.Text = placeholderText;
                    txtBox.ForeColor = Color.Gray;
                }
            };
        }

        private void loadDGVDanhSachPhieuHoanTra()
        {
            // Lấy danh sách phiếu hoàn trả từ database
            TraSanPhamBLL traSanPhamBLL = new TraSanPhamBLL();
            List<TraSanPham> lstTraSanPham = traSanPhamBLL.LayDanhSachTraSanPham().OrderByDescending(x => x.MaTraSanPham).ToList();
            dgvDanhSachPhieuHoanTra.DataSource = lstTraSanPham;

            // Định dạng hiển thị cho các cột
            dinhDangDGVDanhSachPhieuHoanTra();

            // Kiểm tra nếu có hàng nào được chọn
            if (dgvDanhSachPhieuHoanTra.SelectedRows.Count > 0)
            {
                dgvDanhSachPhieuHoanTra.SelectedRows[0].Selected = true;
            }

            // Đảm bảo rằng số thứ tự được vẽ mỗi khi cập nhật dòng
            dgvDanhSachPhieuHoanTra.RowPostPaint += dgvDanhSachPhieuHoanTra_RowPostPaint;
        }

        private void dgvDanhSachPhieuHoanTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Vẽ số thứ tự vào cột đầu tiên (cột 0)
            using (SolidBrush brush = new SolidBrush(dgvDanhSachPhieuHoanTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowIndex = (e.RowIndex + 1).ToString();
                e.Graphics.DrawString(rowIndex, dgvDanhSachPhieuHoanTra.DefaultCellStyle.Font, brush, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dinhDangDGVDanhSachPhieuHoanTra()
        {
            if (dgvDanhSachPhieuHoanTra.DataSource == null)
            {
                // Thông báo nếu không có dữ liệu
                MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Tạo font đậm cho tiêu đề cột
                Font boldFont = new Font(dgvDanhSachPhieuHoanTra.Font, FontStyle.Bold);

                // Cập nhật tiêu đề cột và làm đậm
                dgvDanhSachPhieuHoanTra.Columns["MaTraSanPham"].HeaderText = "Mã phiếu hoàn trả";
                dgvDanhSachPhieuHoanTra.Columns["MaHoaDon"].HeaderText = "Mã hóa đơn";
                dgvDanhSachPhieuHoanTra.Columns["MaKhachHang"].HeaderText = "Mã khách hàng";
                dgvDanhSachPhieuHoanTra.Columns["MaNhanVien"].HeaderText = "Mã nhân viên"; // Đã chỉnh lại tên cột
                dgvDanhSachPhieuHoanTra.Columns["LyDoTra"].HeaderText = "Lý do trả hàng";
                dgvDanhSachPhieuHoanTra.Columns["NgayTra"].HeaderText = "Ngày trả hàng";
                dgvDanhSachPhieuHoanTra.Columns["TongTienHoanLai"].HeaderText = "Tổng tiền hoàn lại";

                // Áp dụng font đậm cho các tiêu đề cột
                dgvDanhSachPhieuHoanTra.Columns["MaTraSanPham"].HeaderCell.Style.Font = boldFont;
                dgvDanhSachPhieuHoanTra.Columns["MaHoaDon"].HeaderCell.Style.Font = boldFont;
                dgvDanhSachPhieuHoanTra.Columns["MaKhachHang"].HeaderCell.Style.Font = boldFont;
                dgvDanhSachPhieuHoanTra.Columns["MaNhanVien"].HeaderCell.Style.Font = boldFont;
                dgvDanhSachPhieuHoanTra.Columns["LyDoTra"].HeaderCell.Style.Font = boldFont;
                dgvDanhSachPhieuHoanTra.Columns["NgayTra"].HeaderCell.Style.Font = boldFont;
                dgvDanhSachPhieuHoanTra.Columns["TongTienHoanLai"].HeaderCell.Style.Font = boldFont;

                // Định dạng số tiền và ngày tháng
                dgvDanhSachPhieuHoanTra.Columns["NgayTra"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDanhSachPhieuHoanTra.Columns["TongTienHoanLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDanhSachPhieuHoanTra.Columns["TongTienHoanLai"].DefaultCellStyle.Format = "N0";

                // Ẩn các cột không cần thiết
                dgvDanhSachPhieuHoanTra.Columns["HoaDon"].Visible = false;
                dgvDanhSachPhieuHoanTra.Columns["KhachHang"].Visible = false;
                dgvDanhSachPhieuHoanTra.Columns["NhanVien"].Visible = false;
            }
        }

        private void btnTaoPhieuDoiTra_Click(object sender, EventArgs e)
        {
            // Tạo thông báo cảnh báo trước khi tạo phiếu đổi trả
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu đổi trả?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Mở form tạo phiếu đổi trả
                frm_ThemPhieuDoiTra themPhieuDoiTra = new frm_ThemPhieuDoiTra();
                themPhieuDoiTra.MaNhanVien = MaNhanVien;
                themPhieuDoiTra.ShowDialog();
                // Sau khi tạo phiếu đổi trả thành công, cập nhật lại DataGridView
                loadDGVDanhSachPhieuHoanTra();
            }
        }

        private void btnXoaPhieuDoiTra_Click(object sender, EventArgs e)
        {
            // Tạo thông báo cảnh báo trước khi xóa phiếu đổi trả
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu đổi trả?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Lấy mã phiếu đổi trả từ dgvDanhSachPhieuHoanTra
                string maTraSanPham = dgvDanhSachPhieuHoanTra.CurrentRow.Cells["MaTraSanPham"].Value.ToString();
                TraSanPhamChiTietBLL traSanPhamChiTietBLL = new TraSanPhamChiTietBLL();
                List<TraSanPhamChiTiet> lstTraSanPhamChiTiet = traSanPhamChiTietBLL.LayTraSanPhamChiTietTheoMaTraSanPham(maTraSanPham);
                foreach (TraSanPhamChiTiet traSanPhamChiTiet in lstTraSanPhamChiTiet)
                {
                    // Cập nhật số lượng trong kho
                    SanPhamBLL sanPhamBLL = new SanPhamBLL();
                    SanPham sanPham = sanPhamBLL.LaySanPhamTheoMaSanPham(traSanPhamChiTiet.MaSanPham);
                    sanPham.SoLuong += traSanPhamChiTiet.SoLuong;
                    bool capNhatSoLuong = sanPhamBLL.suaSanPham(sanPham);

                    // Xóa chi tiết phiếu đổi trả
                    bool xoaTraSanPhamChiTiet = traSanPhamChiTietBLL.XoaTraSanPhamChiTiet(traSanPhamChiTiet);
                    if (!capNhatSoLuong || !xoaTraSanPhamChiTiet)
                    {
                        // Xóa thất bại
                        MessageBox.Show("Xóa phiếu đổi trả thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                TraSanPhamBLL traSanPhamBLL = new TraSanPhamBLL();
                TraSanPham traSanPham = traSanPhamBLL.LayDanhSachTraSanPhamTheoMaTraSanPham(maTraSanPham);
                bool xoaTraSanPham = traSanPhamBLL.XoaTraSanPham(traSanPham);
                if (xoaTraSanPham)
                {
                    MessageBox.Show("Xóa phiếu đổi trả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDGVDanhSachPhieuHoanTra();
                }
                else
                {
                    MessageBox.Show("Xóa phiếu đổi trả thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvDanhSachPhieuHoanTra_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDanhSachPhieuHoanTra.CurrentRow.Cells["MaTraSanPham"].Value != null)
                {
                    // Lấy mã phiếu hoàn trả từ dgvDanhSachPhieuHoanTra
                    string maTraSanPham = dgvDanhSachPhieuHoanTra.CurrentRow.Cells["MaTraSanPham"].Value.ToString();

                    // Load danh sách sản phẩm hoàn trả
                    loadDGVDanhSachSanPhamHoanTra(maTraSanPham);

                    // Hiển thị thông tin chi tiết phiếu hoàn trả
                    TraSanPhamBLL traSanPhamBLL = new TraSanPhamBLL();
                    TraSanPham traSanPham = traSanPhamBLL.LayDanhSachTraSanPhamTheoMaTraSanPham(maTraSanPham);

                    // Mã phiếu hoàn trả
                    if (traSanPham != null)
                    {
                        lblMaPhieuHoanTra.Text = traSanPham.MaTraSanPham;
                        lblNgayHoanTra.Text = traSanPham.NgayTra?.ToString("dd/MM/yyyy") ?? string.Empty;
                        txtLyDoHoanTra.Text = traSanPham.LyDoTra;
                        lblTongTien.Text = traSanPham.TongTienHoanLai?.ToString("N0") + " VND" ?? string.Empty;
                        lblMaKhachHang.Text = traSanPham.MaKhachHang;
                        lblTenKhachHang.Text = traSanPham.KhachHang.TenKhachHang;
                        lblMaNhanVien.Text = traSanPham.MaNhanVien;
                        lblTenNhanVien.Text = traSanPham.NhanVien.TenNhanVien;
                    }
                    else
                    {
                        return;
                    }
                    lblMaPhieuHoanTra.Text = traSanPham.MaTraSanPham;

                    // Ngày lập phiếu
                    lblNgayHoanTra.Text = traSanPham.NgayTra?.ToString("dd/MM/yyyy") ?? string.Empty;

                    // Lý do hoàn trả
                    txtLyDoHoanTra.Text = traSanPham.LyDoTra;

                    // Tổng tiền hoàn lại
                    lblTongTien.Text = traSanPham.TongTienHoanLai?.ToString("N0") + " VND" ?? string.Empty;

                    // Mã khách hàng
                    lblMaKhachHang.Text = traSanPham.MaKhachHang;

                    // Tên khách hàng
                    lblTenKhachHang.Text = traSanPham.KhachHang.TenKhachHang;

                    // Mã nhân viên
                    lblMaNhanVien.Text = traSanPham.MaNhanVien;

                    // Tên nhân viên
                    lblTenNhanVien.Text = traSanPham.NhanVien.TenNhanVien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void loadDGVDanhSachSanPhamHoanTra(string maTraSanPham)
        {
            // Lấy danh sách sản phẩm hoàn trả từ database
            TraSanPhamChiTietBLL traSanPhamChiTietBLL = new TraSanPhamChiTietBLL();
            List<TraSanPhamChiTiet> lstTraSanPhamChiTiet = traSanPhamChiTietBLL.LayTraSanPhamChiTietTheoMaTraSanPham(maTraSanPham);

            // Tạo 1 biến data gồm các cột cần hiển thị
            var data = from traSanPhamChiTiet in lstTraSanPhamChiTiet
                       select new
                       {
                           traSanPhamChiTiet.MaTraSanPham,
                           traSanPhamChiTiet.MaSanPham,
                           traSanPhamChiTiet.ChiTietHoaDon.SanPham.TenSanPham,
                           traSanPhamChiTiet.MaHoaDon,
                           traSanPhamChiTiet.SoLuong,
                           traSanPhamChiTiet.TinhTrangSanPham,
                           traSanPhamChiTiet.SoTienHoanLai,
                           traSanPhamChiTiet.TraSanPham,
                           traSanPhamChiTiet.ChiTietHoaDon,
                       };

            // Cập nhật lại DataSource của DataGridView
            dgvDanhSachSanPhamHoanTra.DataSource = data.ToList();

            // Định dạng hiển thị cho các cột
            dinhDangDGVDanhSachSanPhamHoanTra();

            // Đảm bảo rằng số thứ tự được vẽ mỗi khi cập nhật dòng
            dgvDanhSachSanPhamHoanTra.RowPostPaint += dgvDanhSachSanPhamHoanTra_RowPostPaint;
        }

        private void dgvDanhSachSanPhamHoanTra_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Vẽ số thứ tự cho mỗi dòng
            using (var b = new SolidBrush(dgvDanhSachSanPhamHoanTra.RowHeadersDefaultCellStyle.ForeColor))
            {
                // Số thứ tự, cộng thêm 1 vì chỉ số dòng bắt đầu từ 0
                string rowNumber = (e.RowIndex + 1).ToString();

                // Vẽ số thứ tự vào phần đầu dòng (RowHeader) của DataGridView
                e.Graphics.DrawString(rowNumber, e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dinhDangDGVDanhSachSanPhamHoanTra()
        {
            if (dgvDanhSachSanPhamHoanTra.DataSource == null)
            {
                // Hiện thông báo không có dữ liệu
                MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvDanhSachSanPhamHoanTra.Columns["MaTraSanPham"].Visible = false;
                dgvDanhSachSanPhamHoanTra.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                dgvDanhSachSanPhamHoanTra.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                dgvDanhSachSanPhamHoanTra.Columns["MaHoaDon"].Visible = false;
                dgvDanhSachSanPhamHoanTra.Columns["SoLuong"].HeaderText = "Số lượng hoàn trả";
                dgvDanhSachSanPhamHoanTra.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDanhSachSanPhamHoanTra.Columns["TinhTrangSanPham"].HeaderText = "Tình trạng sản phẩm";
                dgvDanhSachSanPhamHoanTra.Columns["SoTienHoanLai"].HeaderText = "Số tiền hoàn lại";
                dgvDanhSachSanPhamHoanTra.Columns["SoTienHoanLai"].DefaultCellStyle.Format = "N0";
                dgvDanhSachSanPhamHoanTra.Columns["SoTienHoanLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDanhSachSanPhamHoanTra.Columns["TraSanPham"].Visible = false;
                dgvDanhSachSanPhamHoanTra.Columns["ChiTietHoaDon"].Visible = false;
            }
        }

        private void dgvDanhSachSanPhamHoanTra_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị thông tin chi tiết của sản phẩm hoàn trả từ dataGridView
                if (dgvDanhSachSanPhamHoanTra.CurrentRow != null &&
                    dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["MaTraSanPham"] != null &&
                    dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["MaSanPham"] != null &&
                    dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["MaTraSanPham"].Value != null &&
                    dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["MaSanPham"].Value != null)
                {
                    lblTenSanPham.Text = dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["TenSanPham"].Value.ToString();
                    nudSoLuongHoanTra.Value = Convert.ToDecimal(dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["SoLuong"].Value);
                    txtTinhTrangSanPham.Text = dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["TinhTrangSanPham"].Value.ToString();
                    lblSoTienHoanTra.Text = string.Format("{0:N0} VND", dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["SoTienHoanLai"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvDanhSachPhieuHoanTra_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private bool IsCharacterKey(KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhấn có phải là một chữ cái hoặc số không
            return Char.IsLetterOrDigit(e.KeyChar);
        }
        private void dgvDanhSachPhieuHoanTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu phím nhấn là một ký tự (chữ cái hoặc số)
            if (IsCharacterKey(e))
            {
                // Nếu là phím ký tự, focus vào txtLyDoHoanTra
                if (dgvDanhSachPhieuHoanTra.CurrentCell.ColumnIndex == dgvDanhSachPhieuHoanTra.Columns["LyDoTra"].Index)
                {
                    txtLyDoHoanTra.Focus();
                }
            }
        }

        private void dgvDanhSachSanPhamHoanTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsCharacterKey(e))
            {
                // Nếu là phím ký tự và ô đang chọn là số lượng thì forcus vào nudSoLuong
                if (dgvDanhSachSanPhamHoanTra.CurrentCell.ColumnIndex == dgvDanhSachSanPhamHoanTra.Columns["SoLuong"].Index)
                {
                    nudSoLuongHoanTra.Focus();
                }
                // Nếu ô đang chọn là TinhTrangSanPham thì focus vào txtTinhTrang
                else if (dgvDanhSachSanPhamHoanTra.CurrentCell.ColumnIndex == dgvDanhSachSanPhamHoanTra.Columns["TinhTrangSanPham"].Index)
                {
                    txtTinhTrangSanPham.Focus();
                }
            }
        }

        private void txtLyDoHoanTra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Kiểm tra phím Enter
            {
                // Hỏi người dùng có muốn lưu không
                var result = MessageBox.Show("Bạn có muốn lưu thông tin này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện lưu thông tin
                    LuuThongTin();
                }
            }
        }

        private void LuuThongTin()
        {
            // Lấy vị trí đang chọn của dgvDanhSachPhieuHoanTra
            int rowIndex = dgvDanhSachPhieuHoanTra.CurrentRow.Index;
            // Lấy mã phiếu hoàn trả từ label
            string maPhieuHoanTra = lblMaPhieuHoanTra.Text;
            // Lấy mã sản phẩm từ datagridview
            string maSanPham = dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["MaSanPham"].Value.ToString();
            if (maPhieuHoanTra != null && maSanPham != null)
            {
                // Lấy chi tiết phiếu trả từ database
                TraSanPhamChiTietBLL traSanPhamChiTietBLL = new TraSanPhamChiTietBLL();
                TraSanPhamChiTiet traSanPhamChiTiet = traSanPhamChiTietBLL.LayTraSanPhamChiTietTheoMaTraSanPhamVaMaSanPham(maPhieuHoanTra, maSanPham);

                ChiTietHoaDonBLL chiTietHoaDonBLL = new ChiTietHoaDonBLL();
                ChiTietHoaDon cthd = chiTietHoaDonBLL.LayChiTietHoaDonTheoMaHoaDon(traSanPhamChiTiet.MaHoaDon).Where(x => x.MaSanPham == maSanPham).FirstOrDefault();
                int soLuongHoaDon = cthd.SoLuong ?? 0;

                // Cập nhật số lượng hoàn trả, số tiền hoàn lại, tình trạng sản phẩm của chi tiết hoàn trả
                traSanPhamChiTiet.SoLuong = (int?)nudSoLuongHoanTra.Value;

                if (traSanPhamChiTiet.SoLuong > soLuongHoaDon)
                {
                    MessageBox.Show("Số lượng hoàn trả không được lớn hơn số lượng trong hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Chuyển đổi giá trị từ lblSoTienHoanTra.Text về decimal
                decimal soTienHoanLai = 0;
                if (decimal.TryParse(lblSoTienHoanTra.Text.Replace(" VND", "").Replace(",", ""), out soTienHoanLai))
                {
                    // Thành công, soTienHoanLai có giá trị hợp lệ
                    traSanPhamChiTiet.SoTienHoanLai = soTienHoanLai;
                }
                else
                {
                    // Nếu không thể chuyển đổi, gán giá trị mặc định là 0
                    traSanPhamChiTiet.SoTienHoanLai = 0;
                }
                traSanPhamChiTiet.TinhTrangSanPham = txtTinhTrangSanPham.Text;
                bool capNhatTraHangChiTiet = traSanPhamChiTietBLL.CapNhatTraSanPhamChiTiet(traSanPhamChiTiet);

                TraSanPhamBLL traSanPhamBLL = new TraSanPhamBLL();
                TraSanPham traSanPham = traSanPhamBLL.LayDanhSachTraSanPhamTheoMaTraSanPham(lblMaPhieuHoanTra.Text);

                // Cập nhật lý do hoàn trả, tổng tiền hoàn trả của phiếu hoàn trả
                traSanPham.LyDoTra = txtLyDoHoanTra.Text;
                decimal tongTienHoanLai = 0;
                if (decimal.TryParse(lblTongTien.Text.Replace(" VND", "").Replace(",", ""), out tongTienHoanLai))
                {
                    // Thành công, tongTienHoanLai có giá trị hợp lệ
                    traSanPham.TongTienHoanLai = tongTienHoanLai;
                }
                else
                {
                    // Nếu không thể chuyển đổi, gán giá trị mặc định là 0
                    traSanPham.TongTienHoanLai = 0;
                }
                traSanPham.TongTienHoanLai = tongTienHoanLai;
                bool capNhatTraHang = traSanPhamBLL.CapNhatTraSanPham(traSanPham);

                // Cập nhất số lượng sản phẩm trong kho
                int soLuongHoanTraCu = Convert.ToInt32(dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["SoLuong"].Value);
                int soLuongHoanTraMoi = Convert.ToInt32(nudSoLuongHoanTra.Value);
                int soLuongThayDoi = soLuongHoanTraMoi - soLuongHoanTraCu;
                SanPhamBLL sanPhamBLL = new SanPhamBLL();
                SanPham sanPham = sanPhamBLL.laySanPhamTheoMa(maSanPham);
                sanPham.SoLuong += soLuongThayDoi;
                sanPham.NgayCapNhat = DateTime.Now;
                bool capNhatSanPham = sanPhamBLL.suaSanPham(sanPham);
                if (capNhatTraHangChiTiet && capNhatTraHang && capNhatSanPham)
                {
                    MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDGVDanhSachPhieuHoanTra();
                    // Bỏ chọn dòng sau khi load xong
                    dgvDanhSachPhieuHoanTra.Rows[0].Selected = false;
                    dgvDanhSachPhieuHoanTra.Rows[rowIndex].Selected = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mã phiếu hoàn trả hoặc mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhatPhieuDoiTra_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu thông tin này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện lưu thông tin
                LuuThongTin();
            }
        }

        private void nudSoLuongHoanTra_ValueChanged(object sender, EventArgs e)
        {

            // Lấy số lương hoàn trả trên nudSoLuongHoanTra
            decimal soLuongHoanTra = nudSoLuongHoanTra.Value;

            // Lấy đơn giá từ database
            string maSanPham = dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["MaSanPham"].Value.ToString();
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            SanPham sanPham = sanPhamBLL.laySanPhamTheoMa(maSanPham);
            if (sanPham == null)
            {
                // Giá trị nud không thay đổi
                nudSoLuongHoanTra.Value = Convert.ToDecimal(dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["SoLuong"].Value);
                return;
            }
            decimal donGia = sanPham.GiaBan ?? 0;
            decimal thanhTien = soLuongHoanTra * donGia;
            lblSoTienHoanTra.Text = string.Format("{0:N0} VND", thanhTien);

            // Tổng tiền cũ lấy từ database
            decimal tongTienCu = Convert.ToDecimal(dgvDanhSachPhieuHoanTra.CurrentRow.Cells["TongTienHoanLai"].Value);

            // Tổng tiền mới
            decimal tongTienMoi = tongTienCu - Convert.ToDecimal(dgvDanhSachSanPhamHoanTra.CurrentRow.Cells["SoTienHoanLai"].Value) + thanhTien;

            // Hiển thị tổng tiền và số tiền hoàn trả của sản phẩm ra màn hình
            lblTongTien.Text = string.Format("{0:N0} VND", tongTienMoi);
            lblSoTienHoanTra.Text = string.Format("{0:N0} VND", thanhTien);









        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtTim.Text != "Nhập mã hoá đơn, mã trả sản phẩm, mã nhân viên, tên nhân viên, mã khách hàng, tên khách hàng, ngày lập,..." || txtTim.Text != "")
            {
                string key = txtTim.Text;
                TraSanPhamBLL traSanPhamBLL = new TraSanPhamBLL();
                List<TraSanPham> lstTraSanPham = traSanPhamBLL.LayDanhSachTraSanPham().Where(x => x.MaTraSanPham == key || x.MaHoaDon == key || x.MaNhanVien == key || x.MaKhachHang == key || x.KhachHang.TenKhachHang == key).ToList();
                dgvDanhSachPhieuHoanTra.DataSource = lstTraSanPham;
                dinhDangDGVDanhSachPhieuHoanTra();

            }
            else
            {
                loadDGVDanhSachPhieuHoanTra();
            }
        }
    }
}
