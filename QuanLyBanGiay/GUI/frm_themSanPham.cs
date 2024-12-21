using BLL;
using DTO;
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

namespace GUI
{
    public partial class frm_themSanPham : Form
    {
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        ThuongHieuBLL _thuongHieuBLL = new ThuongHieuBLL();
        KichThuocBLL _kichThuocBLL = new KichThuocBLL();
        MauSacBLL _mauSacBLL = new MauSacBLL();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();

        List<SanPham> lstSanPham = null;
        List<ThuongHieu> lstThuongHieu = null;
        List<KichThuoc> lstKichThuoc = null;
        List<MauSac> lstMauSac = null;
        List<LoaiSanPham> lstLoaiSanPham = null;

        private DataTable dtBangTam;

        public frm_themSanPham()
        {
            InitializeComponent();
            this.Load += Frm_themSanPham_Load;
        }

        private void Frm_themSanPham_Load(object sender, EventArgs e)
        {
            hienThiTrangThai();
            //LoadKichThuoc();
            LoadMauSac();
            LoadLoaiSanPhamAdd();
            LoadThuongHieu();
            btn_themSanPham.Click += Btn_themSanPham_Click;
            btn_themAnh.Click += Btn_themAnh_Click;
            txt_maSanPham.Text = TaoMaSanPhamTuDong();
        }

        private void Btn_themSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtBangTam == null || dtBangTam.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn màu sắc và kích thước cho sản phẩm.");
                    return;
                }
                string tenSanPham = txt_tenSanPham.Text;
                string donViTinh = txt_donViTinh.Text;
                string giaNhapText = txt_giaNhap.Text;
                string giaBanText = txt_giaBan.Text;
                giaNhapText = giaNhapText.Replace(",", "").Replace("₫", "").Trim();
                giaBanText = giaBanText.Replace(",", "").Replace("₫", "").Trim();

                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Tên sản phẩm không được để trống!");
                    return;
                }
                if (string.IsNullOrEmpty(donViTinh))
                {
                    MessageBox.Show("Đơn vị tính không được để trống!");
                    return;
                }
                if (!decimal.TryParse(giaNhapText, out decimal giaNhap))
                {
                    MessageBox.Show("Giá nhập không hợp lệ!");
                    return;
                }
                if (!decimal.TryParse(giaBanText, out decimal giaBan))
                {
                    MessageBox.Show("Giá bán không hợp lệ!");
                    return;
                }

                int soLuongToiThieu = 10;
                if (!string.IsNullOrEmpty(txt_soLuongToiThieu.Text))
                {
                    if (!int.TryParse(txt_soLuongToiThieu.Text, out soLuongToiThieu))
                    {
                        MessageBox.Show("Số lượng tối thiểu không hợp lệ!");
                        return;
                    }
                }
                string moTa = txt_moTa.Text;
                if (string.IsNullOrEmpty(moTa))
                {
                    MessageBox.Show("Chưa nhập mô tả sản phẩm!");
                    return;
                }
                string hinhAnh = txt_duongDan.Text;
                if (string.IsNullOrEmpty(hinhAnh))
                {
                    MessageBox.Show("Chưa chọn hình ảnh sản phẩm!");
                    return;
                }

                // Kiểm tra combobox và lấy giá trị của các combobox
                if (cbo_loaiSanPhamAdd.SelectedValue == null || cbo_thuongHieuAdd.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Mã Loại, Màu Sắc và Kích Thước.");
                    return;
                }

                string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                string maThuongHieu = cbo_thuongHieuAdd.SelectedValue.ToString();
                string tenThuongHieu = cbo_thuongHieuAdd.SelectedItem != null
                    ? ((DTO.ThuongHieu)cbo_thuongHieuAdd.SelectedItem).TenThuongHieu
                    : string.Empty;
                bool trangThai = cbo_trangThai.SelectedItem.ToString() == "Đang hoạt động" ? true : false;

                // Kiểm tra nếu sản phẩm đã tồn tại
                //string maDaCo = _sanPhamBLL.timKiemMaSanPham(tenSanPham);
                //if (maDaCo != "")
                //{
                //    MessageBox.Show("Đã có sản phẩm này rồi !");
                //    return;
                //}



                // Biến kiểm tra xem tất cả các sản phẩm có được thêm thành công hay không
                bool isAllSuccess = true;

                // Lấy các giá trị màu sắc và kích thước đã chọn từ bảng
                foreach (DataRow row in dtBangTam.Rows)
                {
                    // Tạo đối tượng mới cho sản phẩm
                    SanPham newProduct = new SanPham
                    {
                        MaSanPham = TaoMaSanPhamTuDong(),
                        TenSanPham = tenSanPham,
                        MaLoaiSanPham = maLoai,
                        MaThuongHieu = maThuongHieu,
                        DonViTinh = donViTinh,
                        SoLuong = 0,
                        SoLuongToiThieu = soLuongToiThieu,
                        GiaNhap = giaNhap,
                        GiaBan = giaBan,
                        MoTa = moTa,
                        HinhAnh = hinhAnh,
                        TrangThaiHoatDong = trangThai,
                        NgayTao = DateTime.Now,
                        NgayCapNhat = DateTime.Now,
                    };

                    string maKichThuoc = row["MaKichThuoc"].ToString();
                    string tenKichThuoc = row["TenKichThuoc"].ToString();
                    string maMauSac = row["MaMauSac"].ToString();

                    // Thêm màu sắc và kích thước vào sản phẩm
                    newProduct.MaKichThuoc = maKichThuoc;
                    newProduct.MaMauSac = maMauSac;

                    // Thực hiện các logic khác (ví dụ: lưu vào database, gọi hàm lưu...)
                    bool isSuccess = _sanPhamBLL.themSanPham(newProduct);

                    if (!isSuccess)
                    {
                        // Nếu có lỗi khi thêm sản phẩm, set isAllSuccess thành false
                        isAllSuccess = false;
                    }
                }

                // Xuất thông báo thành công hoặc thất bại sau khi vòng lặp kết thúc
                if (isAllSuccess)
                {
                    MessageBox.Show("Tất cả sản phẩm đã được thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm một hoặc nhiều sản phẩm. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void InitializeDataTable()
        {
            dtBangTam = new DataTable();
            dtBangTam.Columns.Add("MauSacId", typeof(int));      // ID màu sắc
            dtBangTam.Columns.Add("KichThuocId", typeof(int));   // ID kích thước
            dtBangTam.Columns.Add("TenKichThuoc", typeof(string)); // Tên kích thước
        }
        private void Btn_themAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string newImageName = $"{txt_maSanPham.Text}_{Path.GetFileName(selectedImagePath)}";
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);
                    if (File.Exists(resourcePath))
                    {
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }

                    txt_duongDan.Text = newImageName;
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        LoadImageToPictureBox(newImageName);
                    }
                }
            }
        }
        private bool SaveImageToResources(string imagePath, string imageName)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                string directoryPath = Path.GetDirectoryName(resourcePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.Copy(imagePath, resourcePath, true);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void LoadImageToPictureBox(string imageName)
        {
            try
            {
                // Đường dẫn đến ảnh trong thư mục Resources
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Kiểm tra nếu file ảnh tồn tại, hiển thị ảnh vào PictureBox
                if (File.Exists(resourcePath))
                {
                    img_sanPham.Image = Image.FromFile(resourcePath);
                    img_sanPham.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chọn để ảnh phù hợp với PictureBox
                }
                else
                {
                    img_sanPham.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadThuongHieu()
        {
            lstThuongHieu = new List<ThuongHieu>();
            lstThuongHieu = _thuongHieuBLL.LayTatCaThuongHieu();
            if (lstThuongHieu == null)
            {
                Console.WriteLine("Không có thương hiệu nào trong kho hàng");
                return;
            }
            cbo_thuongHieuAdd.DataSource = lstThuongHieu;
            cbo_thuongHieuAdd.DisplayMember = "TenThuongHieu";
            cbo_thuongHieuAdd.ValueMember = "MaThuongHieu";
            cbo_thuongHieuAdd.SelectedIndex = 0;
        }
        //load combobox trạng thái
        private void hienThiTrangThai()
        {
            cbo_trangThai.Items.Add("Đang hoạt động");
            cbo_trangThai.Items.Add("Ngừng hoạt động");
            cbo_trangThai.SelectedIndex = 0;
        }
        //viết hàm kiểm tra tên sản phẩm đã tồn tại chưa
        private bool KiemTraTenSanPham(string tenSanPham)
        {
            try
            {
                var sp = _sanPhamBLL.timKiemSanPhamTheoTen(tenSanPham);
                if (sp != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        //viết hàm kiểm tra mã sản phẩm đã tồn tại chưa
        private bool KiemTraMaSanPham(string maSanPham)
        {
            try
            {
                SanPham sp = _sanPhamBLL.laySanPhamTheoMa(maSanPham);
                if (sp != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        //tạo mã sản phẩm tự động
        private string TaoMaSanPhamTuDong()
        {
            string maSanPham = string.Empty;
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = _sanPhamBLL.layDanhSachSanPham();
                if (lstSanPham == null)
                {
                    return "SP001";
                }
                int count = lstSanPham.Count;
                count++;
                if (count < 10)
                {
                    maSanPham = "SP00" + count;
                }
                else if (count < 100)
                {
                    maSanPham = "SP0" + count;
                }
                else
                {
                    maSanPham = "SP" + count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return maSanPham;
        }
        //load loại sản phẩm
        private void LoadLoaiSanPhamAdd()
        {
            lstLoaiSanPham = new List<LoaiSanPham>();
            lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
            if (lstLoaiSanPham == null)
            {
                return;
            }
            cbo_loaiSanPhamAdd.DataSource = lstLoaiSanPham;
            cbo_loaiSanPhamAdd.DisplayMember = "TenLoaiSanPham";
            cbo_loaiSanPhamAdd.ValueMember = "MaLoaiSanPham";
        }
        //load dữ liệu lên combobox thương hiệu
        private void LoadThuongHieuAdd()
        {
            lstThuongHieu = new List<ThuongHieu>();
            lstThuongHieu = _thuongHieuBLL.LayTatCaThuongHieu();
            if (lstThuongHieu == null)
            {
                Console.WriteLine("Không có thương hiệu nào trong kho hàng");
                return;
            }
            cbo_thuongHieuAdd.DataSource = lstThuongHieu;
            cbo_thuongHieuAdd.DisplayMember = "TenThuongHieu";
            cbo_thuongHieuAdd.ValueMember = "MaThuongHieu";
        }
        private void LoadMauSac()
        {
            // Khởi tạo danh sách màu sắc
            lstMauSac = _mauSacBLL.layTatCaMauSac();

            // Gán danh sách vào DataGridView
            dgvMauSac.DataSource = null;
            dgvMauSac.DataSource = lstMauSac;

            // Đặt tiêu đề cho các cột
            dgvMauSac.Columns["MaMauSac"].HeaderText = "Mã màu sắc";
            dgvMauSac.Columns["TenMauSac"].HeaderText = "Tên màu sắc";
            dgvMauSac.Columns["MoTa"].HeaderText = "Mô tả";

            // Ẩn các cột không cần hiển thị
            dgvMauSac.Columns["NgayTao"].Visible = false;
            dgvMauSac.Columns["NgayCapNhat"].Visible = false;
            dgvMauSac.Columns["TrangThaiHoatDong"].Visible = false;

            // Thiết lập chế độ tự động điều chỉnh cột
            dgvMauSac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Thêm cột CheckBox "Chọn" nếu chưa có
            if (!dgvMauSac.Columns.Contains("Chon"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "Chon",
                    HeaderText = "Chọn",
                    Width = 50
                };
                dgvMauSac.Columns.Add(checkBoxColumn);
            }
        }

        private void dgvMauSac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvMauSac.Columns["Chon"].Index && e.RowIndex >= 0)
            {
                // Bỏ chọn tất cả các dòng khác
                foreach (DataGridViewRow row in dgvMauSac.Rows)
                {
                    if (row.Index != e.RowIndex)
                    {
                        DataGridViewCheckBoxCell cell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                        cell.Value = false;
                    }
                }

                // Đổi trạng thái của ô hiện tại
                DataGridViewCheckBoxCell currentCell = dgvMauSac.Rows[e.RowIndex].Cells["Chon"] as DataGridViewCheckBoxCell;
                currentCell.Value = !(currentCell.Value != null && (bool)currentCell.Value);

                // Kiểm tra giá trị của cột MaMauSac
                if (dgvMauSac.Rows[e.RowIndex].Cells["MaMauSac"]?.Value is string mauSacId && !string.IsNullOrEmpty(mauSacId))
                {
                    LoadKichThuoc(mauSacId);
                }
                else
                {
                    MessageBox.Show("Giá trị trong cột MaMauSac không hợp lệ hoặc bị thiếu.");
                }
            }
        }

        private void LoadKichThuoc(string mauSacId)
        {
            // Lấy danh sách kích thước
            lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
            dgvKichThuoc.DataSource = null;
            dgvKichThuoc.DataSource = lstKichThuoc;

            // Đặt tiêu đề cho các cột
            dgvKichThuoc.Columns["MaKichThuoc"].HeaderText = "Mã kích thước";
            dgvKichThuoc.Columns["TenKichThuoc"].HeaderText = "Tên kích thước";
            dgvKichThuoc.Columns["MoTa"].HeaderText = "Mô tả";

            // Ẩn các cột không cần thiết
            dgvKichThuoc.Columns["NgayTao"].Visible = false;
            dgvKichThuoc.Columns["NgayCapNhat"].Visible = false;
            dgvKichThuoc.Columns["TrangThaiHoatDong"].Visible = false;

            // Thêm cột CheckBox "Chọn" nếu chưa có
            if (!dgvKichThuoc.Columns.Contains("Chon"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "Chon",
                    HeaderText = "Chọn",
                    Width = 50,
                    TrueValue = true,
                    FalseValue = false
                };

                // Đảm bảo rằng cột "Chon" được thêm vào cuối cùng
                dgvKichThuoc.Columns.Add(checkBoxColumn);
                checkBoxColumn.DisplayIndex = dgvKichThuoc.Columns.Count - 1; // Đưa cột "Chon" ra cuối
            }


            // Đánh dấu các kích thước đã chọn
            foreach (DataGridViewRow row in dgvKichThuoc.Rows)
            {
                string maKichThuoc = row.Cells["MaKichThuoc"].Value.ToString();
                if (dtBangTam != null)
                {
                    bool isChecked = dtBangTam.AsEnumerable()
                        .Any(r => r["MaMauSac"].ToString() == mauSacId && r["MaKichThuoc"].ToString() == maKichThuoc);
                    row.Cells["Chon"].Value = isChecked;
                }
                else
                {
                    // Handle the case when dtBangTam is null
                    Console.Write("dtBangTam is not initialized.");
                }

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string mauSacId = null; // Initialize mauSacId to null
            foreach (DataGridViewRow row in dgvMauSac.Rows)
            {
                bool isChecked = row.Cells["Chon"].Value != null && (bool)row.Cells["Chon"].Value;
                if (isChecked)
                {
                    mauSacId = row.Cells["MaMauSac"].Value.ToString();
                    break; // Exit the loop once mauSacId is assigned
                }
            }

            if (dtBangTam == null) // Ensure dtBangTam is initialized
            {
                dtBangTam = new DataTable();
                dtBangTam.Columns.Add("MaMauSac", typeof(string));
                dtBangTam.Columns.Add("MaKichThuoc", typeof(string));
                dtBangTam.Columns.Add("TenKichThuoc", typeof(string));
            }

            if (mauSacId != null) // Check if mauSacId has been assigned
            {
                var filteredRows = dtBangTam.AsEnumerable()
                    .Where(row => row["MaMauSac"].ToString() != mauSacId);

                if (filteredRows.Any()) // Check if there are any rows to copy
                {
                    dtBangTam = filteredRows.CopyToDataTable();
                }
                else
                {
                    dtBangTam.Clear(); // Clear dtBangTam if no rows match the condition
                }

                // Lưu các kích thước được chọn
                foreach (DataGridViewRow row in dgvKichThuoc.Rows)
                {
                    bool isChecked = row.Cells["Chon"].Value != null && (bool)row.Cells["Chon"].Value;
                    if (isChecked)
                    {
                        string maKichThuoc = row.Cells["MaKichThuoc"].Value.ToString();
                        string tenKichThuoc = row.Cells["TenKichThuoc"].Value.ToString();
                        dtBangTam.Rows.Add(mauSacId, maKichThuoc, tenKichThuoc);
                    }
                }

                MessageBox.Show("Đã lưu thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một màu sắc để lưu thông tin.");
            }
        }

        private void dgvMauSac_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMauSac.SelectedRows.Count > 0)
            {
                string mauSacId = dgvMauSac.SelectedRows[0].Cells["MaMauSac"].Value.ToString();
                LoadKichThuoc(mauSacId);
            }
        }


    }
}
