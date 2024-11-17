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
using System.IO;

namespace GUI
{
    public partial class frm_quanLyKhachHang : Form
    {
        KhachHangBLL _khachHangBLL = new KhachHangBLL();
        List<KhachHang> _lstKhachHang = new List<KhachHang>();
        public frm_quanLyKhachHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyKhachHang_Load;
        }

        private void Frm_quanLyKhachHang_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            dtp_ngayCapNhat.Enabled = false;
            dtp_ngayTao.Enabled = false;
            dgv_khachHang.ReadOnly = true;
            txt_diemTichLuy.Enabled = false;
            cbo_trangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_thanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_timThanhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadDanhSachKhachHang();
            dgv_khachHang.SelectionChanged += Dgv_khachHang_SelectionChanged;
            this.btn_themKhachHang.Click += Btn_themKhachHang_Click;
            btnClear.Click += BtnClear_Click;
            btn_CapNhat.Click += Btn_CapNhat_Click;
            cbo_thanhVien.SelectedIndexChanged += Cbo_thanhVien_SelectedIndexChanged;
            btnTim.Click += BtnTim_Click;
            cbo_timThanhVien.SelectedIndexChanged += Cbo_timThanhVien_SelectedIndexChanged;
            dgv_khachHang.CellFormatting += Dgv_khachHang_CellFormatting;
        }

        private void Dgv_khachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra cột cần định dạng
            if (dgv_khachHang.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong")
            {
                bool trangThai = Convert.ToBoolean(e.Value);
                e.Value = trangThai ? "Đang làm việc" : "Đã nghỉ làm"; // Hiển thị trạng thái
                e.FormattingApplied = true;
            }
            if (dgv_khachHang.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong" && e.Value != null)
            {
                if (e.Value.ToString() == "Đang hoạt động")
                {
                    e.CellStyle.BackColor = Color.Green; // Green for "Đang làm việc"
                    e.CellStyle.ForeColor = Color.White; // White text color
                }
                else if (e.Value.ToString() == "Ngừng hoạt động")
                {
                    e.CellStyle.BackColor = Color.Red; // Red for "Đã nghỉ làm"
                    e.CellStyle.ForeColor = Color.White; // White text color
                }
            }
        }

        private void Cbo_timThanhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra thẻ thành viên được chọn
                if (cbo_timThanhVien.SelectedIndex == 0)
                {
                    _lstKhachHang = new List<KhachHang>();
                    _lstKhachHang = _khachHangBLL.LayTatCaKhachHang();
                    if (_lstKhachHang != null && _lstKhachHang.Count > 0)
                    {
                        dgv_khachHang.DataSource = _lstKhachHang;
                    }
                }
                else if (cbo_timThanhVien.SelectedIndex == 1)
                {
                    _lstKhachHang = new List<KhachHang>();
                    _lstKhachHang = _khachHangBLL.LayTatCaKhachHang().Where(t => t.ThanhVien == true).ToList();
                    if (_lstKhachHang != null && _lstKhachHang.Count > 0)
                    {
                        dgv_khachHang.DataSource = _lstKhachHang;
                    }
                }
                else
                {
                    _lstKhachHang = new List<KhachHang>();
                    _lstKhachHang = _khachHangBLL.LayTatCaKhachHang().Where(t => t.ThanhVien == false).ToList();
                    if (_lstKhachHang != null && _lstKhachHang.Count > 0)
                    {
                        dgv_khachHang.DataSource = _lstKhachHang;
                    }
                }
            }
            catch { }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra từ khoá nhập
                if (string.IsNullOrEmpty(txtTim.Text))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTim.Focus();
                    return;
                }
                //tìm kiếm khách hàng
                _lstKhachHang = new List<KhachHang>();
                _lstKhachHang = _khachHangBLL.TimKiemKhachHang(txtTim.Text);
                if (_lstKhachHang != null && _lstKhachHang.Count > 0)
                {
                    dgv_khachHang.DataSource = _lstKhachHang;
                    ThemCotSTT(dgv_khachHang);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void Cbo_thanhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // nếu thẻ thành viên được chọn là chưa là thành viên thì điểm tích lũy phải bằng 0 và ẩn tài khoản và mật khẩu
            if (cbo_thanhVien.SelectedIndex == 1)
            {
                txt_diemTichLuy.Text = "0";
                txt_taiKhoan.Text = "";
                txt_matKhau.Text = "";
                txt_taiKhoan.Enabled = false;
                txt_matKhau.Enabled = false;
            }
            //nếu thẻ thành viên được chọn là đã là thành viên thì điểm tích lũy phải lớn hơn 0 và hiện tài khoản và mật khẩu
            else
            {
                txt_taiKhoan.Enabled = true;
                txt_matKhau.Enabled = true;
            }
        }

        private void Btn_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra thông tin nhập vào
                //kiểm tra mã khách hàng 
                if (string.IsNullOrEmpty(txt_maKhachHang.Text))
                {
                    MessageBox.Show("Mã khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_maKhachHang.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_tenKhachHang.Text))
                {
                    MessageBox.Show("Tên khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_tenKhachHang.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_SDT.Text))
                {
                    MessageBox.Show("Số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SDT.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_diaChi.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_diaChi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_email.Text))
                {
                    MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                    return;
                }
                //giới tính
                if (cbbGioiTinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbGioiTinh.Focus();
                    return;
                }
                // nếu thẻ thành viên được chọn là chưa là thành viên thì điểm tích lũy phải bằng 0 và ẩn tài khoản và mật khẩu
                if (cbo_thanhVien.SelectedIndex == 1)
                {
                    txt_diemTichLuy.Text = "0";
                    txt_taiKhoan.Text = "";
                    txt_matKhau.Text = "";
                    txt_taiKhoan.Enabled = false;
                    txt_matKhau.Enabled = false;
                }
                //nếu thẻ thành viên được chọn là đã là thành viên thì điểm tích lũy phải lớn hơn 0 và hiện tài khoản và mật khẩu
                else
                {
                    txt_taiKhoan.Enabled = true;
                    txt_matKhau.Enabled = true;
                    if (string.IsNullOrEmpty(txt_taiKhoan.Text))
                    {
                        MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_taiKhoan.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_matKhau.Text))
                    {
                        MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_matKhau.Focus();
                        return;
                    }
                }
                //cập nhật thông tin khách hàng
                KhachHang kh = new KhachHang
                {
                    MaKhachHang = txt_maKhachHang.Text,
                    TenKhachHang = txt_tenKhachHang.Text,
                    SoDienThoai = txt_SDT.Text,
                    DiaChi = txt_diaChi.Text,
                    DiemTichLuy = decimal.Parse(txt_diemTichLuy.Text),
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cbbGioiTinh.Text,
                    Email = txt_email.Text,
                    TaiKhoan = txt_taiKhoan.Text,
                    MatKhau = txt_matKhau.Text,
                    HinhAnh = "",
                    NgayTao = dtp_ngayTao.Value,
                    NgayCapNhat = dtp_ngayCapNhat.Value,
                    ThanhVien = cbo_thanhVien.SelectedIndex == 0 ? true : false,
                    TrangThaiHoatDong = cbo_trangThai.SelectedIndex == 0 ? true : false
                };
                if (_khachHangBLL.SuaThongTinKhachHang(kh))
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { 
                Console.WriteLine("Lỗi khi cập nhật thông tin khách hàng");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //xoá thông tin trên các textbox
            txt_maKhachHang.Text = "";
            txt_tenKhachHang.Text = "";
            txt_SDT.Text = "";
            txt_diaChi.Text = "";
            txt_diemTichLuy.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            cbbGioiTinh.SelectedIndex = -1;
            txt_email.Text = "";
            txt_taiKhoan.Text = "";
            txt_matKhau.Text = "";
            hinhanh.Image = null;
            dtp_ngayTao.Value = DateTime.Now;
            dtp_ngayCapNhat.Value = DateTime.Now;
            cbo_thanhVien.SelectedIndex = -1;
            cbo_trangThai.SelectedIndex = -1;
            txt_tenKhachHang.Focus();
        }

        private void Btn_themKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra thông tin nhập vào
                if (string.IsNullOrEmpty(txt_tenKhachHang.Text))
                {
                    MessageBox.Show("Tên khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_tenKhachHang.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_SDT.Text))
                {
                    MessageBox.Show("Số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SDT.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_diaChi.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_diaChi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_email.Text))
                {
                    MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                    return;
                }
                //giới tính
                if(cbbGioiTinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbGioiTinh.Focus();
                    return;
                }
                // nếu thẻ thành viên được chọn là chưa là thành viên thì điểm tích lũy phải bằng 0 và ẩn tài khoản và mật khẩu
                if (cbo_thanhVien.SelectedIndex == 1)
                {
                    txt_diemTichLuy.Text = "0";
                    txt_taiKhoan.Text = "";
                    txt_matKhau.Text = "";
                    txt_taiKhoan.Enabled = false;
                    txt_matKhau.Enabled = false;
                }
                //nếu thẻ thành viên được chọn là đã là thành viên thì điểm tích lũy phải lớn hơn 0 và hiện tài khoản và mật khẩu
                else
                {
                    txt_taiKhoan.Enabled = true;
                    txt_matKhau.Enabled = true;
                    if (string.IsNullOrEmpty(txt_taiKhoan.Text))
                    {
                        MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_taiKhoan.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_matKhau.Text))
                    {
                        MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_matKhau.Focus();
                        return;
                    }
                }
                //thêm khách hàng
                KhachHang kh = new KhachHang
                {
                    MaKhachHang = TaoMaKhachHangTuDong(),
                    TenKhachHang = txt_tenKhachHang.Text,
                    SoDienThoai = txt_SDT.Text,
                    DiaChi = txt_diaChi.Text,
                    DiemTichLuy = 0,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cbbGioiTinh.Text,
                    Email = txt_email.Text,
                    TaiKhoan = txt_taiKhoan.Text,
                    MatKhau = txt_matKhau.Text,
                    HinhAnh = "",
                    NgayTao = dtp_ngayTao.Value,
                    NgayCapNhat = dtp_ngayCapNhat.Value,
                    ThanhVien = cbo_thanhVien.SelectedIndex == 0 ? true : false,
                    TrangThaiHoatDong = cbo_trangThai.SelectedIndex == 0 ? true : false
                };
                if (_khachHangBLL.ThemKhachHang(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void Dgv_khachHang_SelectionChanged(object sender, EventArgs e)
        {
            HienThiThongTinChiTietKhachHang();
        }

        //các hàm xử lý

        //Hàm thêm cột STT vào DataGridView
        private void ThemCotSTT(DataGridView dgv)
        {
            // Kiểm tra nếu chưa có cột STT, thêm cột mới
            if (!dgv.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    Width = 50,
                    ReadOnly = true,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgv.Columns.Insert(0, sttColumn); // Chèn vào cột đầu tiên
            }

            // Gán số thứ tự cho từng dòng
            CapNhatSTT(dgv);
        }

        // Hàm cập nhật giá trị STT
        private void CapNhatSTT(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
        }

        //Viết hàm tạo mã khách hàng tự động
        private string TaoMaKhachHangTuDong()
        {

            string maKhachHang = "";
            _lstKhachHang = new List<KhachHang>();
            _lstKhachHang = _khachHangBLL.LayTatCaKhachHang();
            if (_lstKhachHang == null || _lstKhachHang.Count == 0)
            {
                maKhachHang = "KH001";
            }
            else
            {
                KhachHang kh = _lstKhachHang[_lstKhachHang.Count - 1];
                string maKhachHangCuoi = kh.MaKhachHang;
                string so = maKhachHangCuoi.Substring(2);
                int soMoi = int.Parse(so) + 1;
                maKhachHang = "KH" + soMoi.ToString("D3");
            }

            return maKhachHang;
        }
        //viết hàm load ảnh lên pictureBox
        private void LoadImageToPictureBox(string imageName)
        {
            try
            {
                // Đường dẫn đến ảnh trong thư mục Resources
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Kiểm tra nếu file ảnh tồn tại, hiển thị ảnh vào PictureBox
                if (File.Exists(resourcePath))
                {
                    hinhanh.Image = Image.FromFile(resourcePath);
                    hinhanh.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chọn để ảnh phù hợp với PictureBox
                }
                else
                {
                    hinhanh.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //viết hàm hiển thị thông tin chi tiết khách hàng lên textbox
        private void HienThiThongTinChiTietKhachHang()
        {
            //curentrow khi chọn
            if (dgv_khachHang.CurrentRow != null)
            {
                string maKhachHang = dgv_khachHang.CurrentRow.Cells["MaKhachHang"].Value.ToString();
                KhachHang khachHang = _khachHangBLL.LayKhachHangTheoDieuKien(maKhachHang, "", "");
                if (khachHang != null)
                {
                    txt_maKhachHang.Text = khachHang.MaKhachHang;
                    txt_tenKhachHang.Text = khachHang.TenKhachHang;
                    txt_SDT.Text = khachHang.SoDienThoai;
                    txt_diaChi.Text = khachHang.DiaChi;
                    txt_diemTichLuy.Text = khachHang.DiemTichLuy.ToString();
                    dtpNgaySinh.Value = khachHang.NgaySinh ?? DateTime.Now;
                    cbbGioiTinh.Text = khachHang.GioiTinh;
                    txt_email.Text = khachHang.Email;
                    txt_taiKhoan.Text = khachHang.TaiKhoan;
                    txt_matKhau.Text = khachHang.MatKhau;
                    string hinhAnh = khachHang.HinhAnh;
                    LoadImageToPictureBox(hinhAnh);
                    dtp_ngayTao.Value = (DateTime)khachHang.NgayTao;
                    dtp_ngayCapNhat.Value = (DateTime)khachHang.NgayCapNhat;
                    if (khachHang.ThanhVien == true)
                    {
                        cbo_thanhVien.Text = "Đã là thành viên";
                    }
                    else
                    {
                        cbo_thanhVien.Text = "Chưa là thành viên";
                    }
                    if(khachHang.TrangThaiHoatDong == true)
                    {
                        cbo_trangThai.Text = "Đang hoạt động";
                    }
                    else
                    {
                        cbo_trangThai.Text = "Ngưng hoạt động";
                    }
                }
            }
        }
        //khởi tạo dataGirdView
        private void InitDataGridView()
        {
            dgv_khachHang.ReadOnly = true;
            //đổi tên titel
            if (dgv_khachHang.Columns["MaKhachHang"] != null)
                dgv_khachHang.Columns["MaKhachHang"].HeaderText = "Mã khách hàng";

            if (dgv_khachHang.Columns["TenKhachHang"] != null)
                dgv_khachHang.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";

            if (dgv_khachHang.Columns["SDT"] != null)
                dgv_khachHang.Columns["SDT"].HeaderText = "Số điện thoại";

            if (dgv_khachHang.Columns["DiaChi"] != null)
                dgv_khachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";

            if (dgv_khachHang.Columns["DiemCongTichLuy"] != null)
            {
                dgv_khachHang.Columns["DiemCongTichLuy"].HeaderText = "Điểm cộng tích lũy";
                dgv_khachHang.Columns["DiemCongTichLuy"].DefaultCellStyle.Format = "N0";
                dgv_khachHang.Columns["DiemCongTichLuy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgv_khachHang.Columns["NgaySinh"] != null)
            {
                dgv_khachHang.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgv_khachHang.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgv_khachHang.Columns["GioiTinh"] != null)
            {
                dgv_khachHang.Columns["GioiTinh"].HeaderText = "Giới tính";
                dgv_khachHang.Columns["GioiTinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgv_khachHang.Columns["Email"] != null)
            {
                dgv_khachHang.Columns["Email"].HeaderText = "Email";
                dgv_khachHang.Columns["Email"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgv_khachHang.Columns["TrangThai"] != null)
            {
                dgv_khachHang.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgv_khachHang.Columns["TrangThai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgv_khachHang.Columns["TaiKhoan"] != null)
                dgv_khachHang.Columns["TaiKhoan"].HeaderText = "Tài khoản";

            if (dgv_khachHang.Columns["MatKhau"] != null)
                dgv_khachHang.Columns["MatKhau"].HeaderText = "Mật khẩu";

            if (dgv_khachHang.Columns["HinhAnh"] != null)
            {
                dgv_khachHang.Columns["HinhAnh"].HeaderText = "Hình ảnh";
                dgv_khachHang.Columns["HinhAnh"].Visible = false;
            }

            if (dgv_khachHang.Columns["NgayTao"] != null)
            {
                dgv_khachHang.Columns["NgayTao"].HeaderText = "Ngày tạo";
                dgv_khachHang.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgv_khachHang.Columns["NgayCapNhat"] != null)
            {
                dgv_khachHang.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
                dgv_khachHang.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgv_khachHang.Columns["ThanhVien"] != null)
                dgv_khachHang.Columns["ThanhVien"].HeaderText = "Thành viên";
            dgv_khachHang.RowPostPaint += dgv_RowPostPaint;
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();

            System.Drawing.Font rowFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            var leftFormat = new System.Drawing.StringFormat()
            {
                Alignment = System.Drawing.StringAlignment.Near, // Căn trái
                LineAlignment = System.Drawing.StringAlignment.Center // Giữa theo chiều dọc
            };

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.Columns[0].Width, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, rowFont, System.Drawing.SystemBrushes.ControlText, headerBounds, leftFormat);
        }
        //Load danh sách khách hàng
        private void LoadDanhSachKhachHang()
        {
            try
            {
                _lstKhachHang = new List<KhachHang>();
                _lstKhachHang = _khachHangBLL.LayTatCaKhachHang();
                if(_lstKhachHang!= null && _lstKhachHang.Count > 0)
                {
                    dgv_khachHang.DataSource = _lstKhachHang;
                }
               
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
