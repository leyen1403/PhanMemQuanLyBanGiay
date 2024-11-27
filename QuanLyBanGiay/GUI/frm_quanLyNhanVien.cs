using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frm_quanLyNhanVien : Form
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        VaiTroBLL vaiTroBLL = new VaiTroBLL();
        public frm_quanLyNhanVien()
        {
            InitializeComponent();
            Load += Frm_quanLyNhanVien_Load;
            dgvNhanVien.DataBindingComplete += dgvDonDatHang_DataBindingComplete;
            dgvNhanVien.SelectionChanged += dgvDonDatHang_SelectionChanged;
            cbbVaiTro.SelectedIndexChanged += cbbVaiTro_SelectedIndexChanged;
            dgvNhanVien.CellFormatting += dgvNhanVien_CellFormatting;

        }

        /// <summary>
        /// Hiển thị danh sách nhân viên dựa trên vai trò được chọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            string maVaiTro = cbbVaiTro.SelectedValue.ToString();
            if (maVaiTro == "TatCa")
            {
                loadDGVNhanVien();
            }
            else
            {
                lstNhanVien = nhanVienBLL.LayNhanVienTheoVaiTro(maVaiTro);
                dgvNhanVien.DataSource = lstNhanVien;
                DinhDangDGVNhanVien();
            }
        }

        /// <summary>
        /// Hiển thị thông tin nhân viên khi chọn từ danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDonDatHang_SelectionChanged(object sender, EventArgs e)
        {
            string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            NhanVien nhanVien = nhanVienBLL.LayNhanVien(maNhanVien);
            if (nhanVien != null)
            {
                txtMaNhanVien.Text = nhanVien.MaNhanVien;
                txtTenNhanVien.Text = nhanVien.TenNhanVien;
                dtpNgaySinh.Value = nhanVien.NgaySinh ?? DateTime.Now;
                if (nhanVien.GioiTinh == "Nam")
                {
                    cbbGioiTinh.SelectedItem = "Nam";
                }
                else
                {
                    cbbGioiTinh.SelectedItem = "Nữ";
                }
                txtSoDienThoai.Text = nhanVien.SoDienThoai;
                txtEmail.Text = nhanVien.Email;
                txtDiaChi.Text = nhanVien.DiaChi;
                txtChucVu.Text = nhanVien.ChucVu;
                txtTaiKhoan.Text = nhanVien.TaiKhoan;
                txtMatKhau.Text = nhanVien.MatKhau;
                if (nhanVien.TrangThaiHoatDong == true)
                {
                    cbbTrangThai.SelectedItem = "Đang làm việc";
                }
                else
                {
                    cbbTrangThai.SelectedItem = "Đã nghỉ làm";
                }
                dtpNgayVaoLam.Value = nhanVien.NgayTao ?? DateTime.Now;
                string urlHinhAnh = nhanVien.HinhAnh;
                string url = Application.StartupPath + "\\Resources\\";
                try
                {
                    // Kiểm tra nếu đường dẫn không null
                    if (!string.IsNullOrEmpty(urlHinhAnh))
                    {
                        string fullPath = url + urlHinhAnh;

                        // Kiểm tra nếu file tồn tại
                        if (File.Exists(fullPath))
                        {
                            picHinhAnh.Image = Image.FromFile(fullPath);
                        }
                        else
                        {
                            // Nếu file không tồn tại, sử dụng ảnh mặc định
                            picHinhAnh.Image = Image.FromFile(url + "icons8-user-100.png");
                        }
                    }
                    else
                    {
                        // Nếu không có đường dẫn, sử dụng ảnh mặc định
                        picHinhAnh.Image = Image.FromFile(url + "icons8-user-100.png");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý khi xảy ra lỗi đọc file
                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    picHinhAnh.Image = Image.FromFile(url + "icons8-user-100.png");
                }

            }
        }

        /// <summary>
        /// Load dữ liệu khi mở form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_quanLyNhanVien_Load(object sender, EventArgs e)
        {
            AddPlaceholder(txtTim, "Nhập mã, tên, số điện thoại, email...");
            loadDGVNhanVien();
            loadComboBoxVaiTro();
        }

        /// <summary>
        /// Load dữ liệu vào ComboBox VaiTro
        /// </summary>
        private void loadComboBoxVaiTro()
        {
            List<VaiTro> lstVaiTro = new List<VaiTro>();
            lstVaiTro = vaiTroBLL.LayDanhSachVaiTro();
            lstVaiTro.Insert(0, new VaiTro { MaVaiTro = "TatCa", TenVaiTro = "Tất cả" });
            cbbVaiTro.DataSource = lstVaiTro;
            cbbVaiTro.DisplayMember = "TenVaiTro";
            cbbVaiTro.ValueMember = "MaVaiTro";
        }

        /// <summary>
        /// Load dữ liệu vào DataGridView NhanVien
        /// </summary>
        private void loadDGVNhanVien()
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            if (txtTim.Text == "Nhập mã, tên, số điện thoại, email...")
            {
                lstNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            }
            else
            {
                lstNhanVien = nhanVienBLL
                    .LayDanhSachNhanVien()
                    .Where(p => p.TenNhanVien.ToLower().Contains(txtTim.Text.ToLower()) || p.MaNhanVien.ToLower().Contains(txtTim.Text.ToLower()) || p.SoDienThoai.ToLower().Contains(txtTim.Text.ToLower()) || p.Email.ToLower().Contains(txtTim.Text.ToLower()))
                    .ToList();
            }
            dgvNhanVien.DataSource = lstNhanVien;
            DinhDangDGVNhanVien();
            ThemCotSTT(dgvNhanVien);
        }

        /// <summary>
        /// Định dạng DataGridView NhanVien
        /// </summary>
        private void DinhDangDGVNhanVien()
        {
            dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns["Email"].HeaderText = "Email";
            dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức vụ";
            dgvNhanVien.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            dgvNhanVien.Columns["MatKhau"].Visible = false;
            dgvNhanVien.Columns["HinhAnh"].Visible = false;
            dgvNhanVien.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái hoạt động";
            dgvNhanVien.Columns["TrangThaiHoatDong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center align
            dgvNhanVien.Columns["TrangThaiHoatDong"].Width = 120; // Adjust column width
            dgvNhanVien.Columns["NgayTao"].HeaderText = "Ngày vào làm";
            dgvNhanVien.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgvNhanVien.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
        }

        /// <summary>
        /// Định dạng cột TrangThaiHoatDong trong DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra cột cần định dạng
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong")
            {
                // Lấy giá trị của ô
                bool trangThai = Convert.ToBoolean(e.Value);
                e.Value = trangThai ? "Đang làm việc" : "Đã nghỉ làm"; // Hiển thị trạng thái
                e.FormattingApplied = true;
            }
            // Only format the "TrangThaiHoatDong" column
            if (dgvNhanVien.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong" && e.Value != null)
            {
                // Check if the status is "Đang làm việc" or "Đã nghỉ làm"
                if (e.Value.ToString() == "Đang làm việc")
                {
                    e.CellStyle.BackColor = Color.Green; // Green for "Đang làm việc"
                    e.CellStyle.ForeColor = Color.White; // White text color
                }
                else if (e.Value.ToString() == "Đã nghỉ làm")
                {
                    e.CellStyle.BackColor = Color.Red; // Red for "Đã nghỉ làm"
                    e.CellStyle.ForeColor = Color.White; // White text color
                }
            }
        }

        /// <summary>
        /// Thêm cột STT vào DataGridView
        /// </summary>
        /// <param name="dgv"></param>
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

        /// <summary>
        /// Cập nhật số thứ tự cho từng dòng trong DataGridView
        /// </summary>
        /// <param name="dgv"></param>
        private void CapNhatSTT(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
        }

        // Sử dụng sự kiện để đảm bảo STT luôn được cập nhật
        private void dgvDonDatHang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ThemCotSTT(sender as DataGridView);
        }

        /// <summary>
        /// Tìm kiếm nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTim_Click(object sender, EventArgs e)
        {
            loadDGVNhanVien();
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
        /// Xử lý sự kiện cập nhật thông tin nhân viên khi nhấn nút cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Thông báo xác nhận trước khi cập nhật
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                capNhatNhanVien();
            }
        }

        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        private void capNhatNhanVien()
        {
            string maNhanVien = txtMaNhanVien.Text;
            NhanVien nv = nhanVienBLL.LayNhanVien(maNhanVien);

            nv.TenNhanVien = txtTenNhanVien.Text;
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.GioiTinh = cbbGioiTinh.SelectedItem.ToString();
            nv.SoDienThoai = txtSoDienThoai.Text;
            nv.Email = txtEmail.Text;
            nv.ChucVu = txtChucVu.Text;
            nv.TaiKhoan = txtTaiKhoan.Text;
            nv.MatKhau = txtMatKhau.Text;
            nv.TrangThaiHoatDong = cbbTrangThai.SelectedItem.ToString() == "Đang làm việc" ? true : false;
            nv.NgayTao = dtpNgayVaoLam.Value;
            nv.NgayCapNhat = DateTime.Now;
            nv.DiaChi = txtDiaChi.Text;

            if (nhanVienBLL.CapNhatNhanVien(nv))
            {
                MessageBox.Show("Cập nhật nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDGVNhanVien();
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút đổi hình ảnh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoiHinhAnh_Click(object sender, EventArgs e)
        {
            // Lấy mã nhân viên hiện tại
            string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            NhanVien nhanVien = nhanVienBLL.LayNhanVien(maNhanVien);

            // Tạo đối tượng OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileExtension = Path.GetExtension(filePath);
                    string newFileName = maNhanVien + fileExtension;
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newFileName);
                    Console.WriteLine($"StartupPath: {Application.StartupPath}");
                    Console.WriteLine($"New File Name: {newFileName}");

                    // Create Resources directory if it doesn't exist
                    string resourceDir = Path.Combine(Application.StartupPath, "Resources");
                    if (!Directory.Exists(resourceDir))
                    {
                        Directory.CreateDirectory(resourceDir);
                    }

                    // Kiểm tra và xóa hình cũ
                    string oldImagePath = nhanVien.HinhAnh != null ? Path.Combine(resourceDir, nhanVien.HinhAnh) : null;
                    if (oldImagePath != null && File.Exists(oldImagePath))
                    {
                        try
                        {
                            picHinhAnh.Image?.Dispose();  // Giải phóng tài nguyên hình ảnh cũ
                            File.Delete(oldImagePath);  // Xóa hình ảnh cũ
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"Lỗi khi xóa hình ảnh cũ: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }


                    // Sao chép tệp hình ảnh vào thư mục Resources
                    File.Copy(filePath, resourcePath, true);

                    // Cập nhật tên file vào cơ sở dữ liệu
                    nhanVien.HinhAnh = newFileName;
                    nhanVienBLL.CapNhatNhanVien(nhanVien);

                    // Hiển thị ảnh mới trong PictureBox
                    picHinhAnh.Image = Image.FromFile(resourcePath);
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện tạo nhân viên mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoNhanVien_Click(object sender, EventArgs e)
        {
            frm_ThemNhanVien frm = new frm_ThemNhanVien();
            frm.ShowDialog();
            frm.Tao += Frm_Tao;
        }

        /// <summary>
        /// Xử lý sự kiện khi tạo nhân viên mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Tao(object sender, EventArgs e)
        {
            loadDGVNhanVien();
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút làm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            lstNhanVien = new NhanVienBLL().LayDanhSachNhanVien();
            dgvNhanVien.DataSource = lstNhanVien;
            DinhDangDGVNhanVien();
            ThemCotSTT(dgvNhanVien);
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút enter trong TextBox tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn AcceptButton xử lý Enter
                loadDGVNhanVien();         // Thực hiện hành động mong muốn
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút xoá nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Hiện thông báo xác nhận xoá
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá nhân viên này không", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maNhanVien = "";
                maNhanVien = txtMaNhanVien.Text;
                NhanVienBLL nhanVienBLL = new NhanVienBLL();
                NhanVien nv = nhanVienBLL.LayNhanVien(maNhanVien);
                if (nv != null)
                {
                    bool xoaNhanVien = nhanVienBLL.XoaNhanVien(nv);
                    if(xoaNhanVien)
                    {
                        MessageBox.Show("Xoá nhân viên thành công");
                        loadDGVNhanVien();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình xoá");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên");
                }
            }
        }

        private void frm_quanLyNhanVien_Load_1(object sender, EventArgs e)
        {
            loadDGVNhanVien();
        }
    }
}
