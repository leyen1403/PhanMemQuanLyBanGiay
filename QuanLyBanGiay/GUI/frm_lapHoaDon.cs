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
using UC;
using System.IO;
using DevExpress.XtraEditors.Mask.Design;

namespace GUI
{
    public partial class frm_lapHoaDon : Form
    {
        ProductItem productSelected = null;
        SanPhamBLL _sanPhamBLL= new SanPhamBLL();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();
        KichThuocBLL _kichThuocBLL = new KichThuocBLL();
        MauSacBLL _mauSacBLL = new MauSacBLL();
        ThuongHieuBLL _thuongHieuBLL = new ThuongHieuBLL();
        HoaDonBLL _hoaDonBLL = new HoaDonBLL();
        ChiTietHoaDonBLL _chiTietHoaDonBLL = new ChiTietHoaDonBLL();
        KhachHangBLL _khachHangBLL = new KhachHangBLL();

        NhanVien _nhanVien { get; set; }
        List<SanPham> _lstSanPham = null;
        List<LoaiSanPham> _lstLoaiSanPham = null;
        List<KichThuoc> _lstKichThuoc = null;
        List<MauSac> _lstMauSac = null;
        List<ThuongHieu> _lstThuongHieu = null;
        List<HoaDon> _lstHoaDon = null;
        List<ChiTietHoaDon> _lstChiTietHoaDon = null;
        List<KhachHang> _lstKhachHang = null;
        // Biến phân trang
        int currentPage = 1;
        int pageSize = 15;
        int totalRecords;
        public frm_lapHoaDon()
        {
            InitializeComponent();
        }
        private void frm_lapHoaDon_Load(object sender, EventArgs e)
        {
            this.btn_troLai.Click += Btn_troLai_Click;
            this.btn_keTiep.Click += Btn_keTiep_Click;
            this.btn_trangDau.Click += Btn_trangDau_Click;
            this.btn_trangCuoi.Click += Btn_trangCuoi_Click;
            this.btn_load.Click += Btn_load_Click;
            this.cbo_thuongHieu.SelectedIndexChanged += Cbo_thuongHieu_SelectedIndexChanged;
            this.cbo_loai.SelectedIndexChanged += Cbo_loai_SelectedIndexChanged;
            this.cbo_mauSac.SelectedIndexChanged += Cbo_mauSac_SelectedIndexChanged;
            this.cbo_kichThuoc.SelectedIndexChanged += Cbo_kichThuoc_SelectedIndexChanged;
            this.btn_addCart.Click += Btn_addCart_Click;
            loadCboLoaiSanPham();
            loadCboThuongHieu();
            LoadSanPhamPaged();
            txt_soLuong.Minimum = 1;
            txt_soLuong.Maximum = 100;
            txt_soLuong.Value = 1;
            InitializeDataGridView();
        }

        private void Cbo_kichThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductPrice();
        }

        private void Btn_addCart_Click(object sender, EventArgs e)
        {
            if (cbo_mauSac.SelectedItem != null && cbo_kichThuoc.SelectedItem != null)
            {
                string tenSanPham = productSelected?.TenSanPham; // Sử dụng null conditional để tránh lỗi NullReferenceException
                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Sản phẩm chưa được chọn.");
                    return;
                }

                string tenMauSac = cbo_mauSac.SelectedItem != null ? ((DTO.MauSac)cbo_mauSac.SelectedItem).TenMauSac : string.Empty;
                string kichThuoc =cbo_kichThuoc.SelectedItem != null ? ((DTO.KichThuoc)cbo_kichThuoc.SelectedItem).TenKichThuoc : string.Empty;
                string tenLoai = !string.IsNullOrEmpty(txt_loaiSanPham.Text) ? txt_loaiSanPham.Text : string.Empty;
                string tenThuongHieu = !string.IsNullOrEmpty(txt_thuongHieu.Text) ? txt_thuongHieu.Text : string.Empty;

                string maSanPham = _sanPhamBLL?.layMaSanPhamTheoTen(tenSanPham, tenThuongHieu, tenMauSac, kichThuoc);
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ. Vui lòng kiểm tra lại thông tin sản phẩm.");
                    return;
                }

                int soLuong = (int)txt_soLuong.Value;
                if (soLuong <= 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng sản phẩm lớn hơn 0.");
                    return;
                }

                var sanPham = _sanPhamBLL?.laySanPhamTheoMaMoi(maSanPham) ; // Ép kiểu về SanPhamChiTiet
                if (sanPham != null)
                {
                    string _tenSanPham = sanPham.TenSanPham;
                    string tenMau = sanPham.MauSac;
                    string tenKichThuoc = sanPham.KichThuoc;
                    decimal giaBan = sanPham.GiaBan;
                    decimal thanhTien = giaBan * soLuong;
                    bool sanPhamDaCo = false;

                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        // Kiểm tra sản phẩm đã tồn tại trong giỏ hàng hay chưa
                        if (row.Cells["MaSP"].Value?.ToString() == maSanPham &&
                            row.Cells["MauSac"].Value?.ToString() == tenMau &&
                            row.Cells["KichThuoc"].Value?.ToString() == tenKichThuoc)
                        {
                            int currentQuantity = (int)row.Cells["SoLuong"].Value;
                            row.Cells["SoLuong"].Value = currentQuantity + soLuong;
                            row.Cells["ThanhTien"].Value = giaBan * (currentQuantity + soLuong);
                            sanPhamDaCo = true;
                            break;
                        }
                    }

                    // Nếu sản phẩm chưa có trong giỏ hàng, thêm mới
                    if (!sanPhamDaCo)
                    {
                        dgvCart.Rows.Add(maSanPham, _tenSanPham, tenMau, tenKichThuoc, soLuong, giaBan, thanhTien);
                    }

                    // Cập nhật tổng tiền và tổng số lượng sản phẩm trong giỏ hàng
                    txt_tongTien.Text = CalculateTotalAmount().ToString("N0");
                    txt_TongSL.Text = CalculateTotalProducts().ToString();
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tìm thấy.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn màu sắc và kích thước sản phẩm.");
            }
        }

        private void Cbo_mauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tenLoai = txt_loaiSanPham.Text != null ? txt_loaiSanPham.Text: string.Empty;
                string tenThuongHieu = txt_thuongHieu.Text != null ? txt_thuongHieu.Text: string.Empty;
                string tenMauSac = cbo_mauSac.SelectedItem != null ? ((DTO.MauSac)cbo_mauSac.SelectedItem).TenMauSac : string.Empty;
                if (string.IsNullOrEmpty(tenLoai) || string.IsNullOrEmpty(tenThuongHieu) || string.IsNullOrEmpty(tenMauSac))
                {
                    Console.WriteLine("Vui lòng chọn đủ thông tin");
                    return;
                }
                _lstKichThuoc = _kichThuocBLL.LayKichThuocTheoThuongHieuLoaiSanPhamMauSac(tenThuongHieu, tenLoai, tenMauSac);
                cbo_kichThuoc.DataSource = _lstKichThuoc;
                cbo_kichThuoc.DisplayMember = "TenKichThuoc";
                cbo_kichThuoc.ValueMember = "MaKichThuoc";
                LoadProductPrice();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_load_Click(object sender, EventArgs e)
        {
            LoadSanPhamPaged();
        }

        private void Cbo_loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string maloai = cbo_loai.SelectedValue.ToString();
                if(string.IsNullOrEmpty(maloai))
                {
                    Console.WriteLine("Vui lòng chọn loại");
                    return;
                }    
                string maThuongHieu= string.Empty;
                // Cập nhật lại trang hiện tại về 1 khi thay đổi loại sản phẩm
                currentPage = 1;
                List<SanPham> pagedSanPhamList = _sanPhamBLL.GetSanPhamsPaged(currentPage, pageSize,maloai,maThuongHieu, out totalRecords);
                loadSanPham(pagedSanPhamList);
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Cbo_thuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                string maloai =string.Empty;
                string maThuongHieu = cbo_thuongHieu.SelectedValue.ToString();
                if (string.IsNullOrEmpty(maThuongHieu))
                {
                    Console.WriteLine("Vui lòng chọn thương hiệu");
                    return;
                }
                // Cập nhật lại trang hiện tại về 1 khi thay đổi loại sản phẩm
                currentPage = 1;
                List<SanPham> pagedSanPhamList = _sanPhamBLL.GetSanPhamsPaged(currentPage, pageSize, maloai, maThuongHieu, out totalRecords);
                loadSanPham(pagedSanPhamList);
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_trangCuoi_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage = totalPages;
                LoadSanPhamPaged();
            }
        }

        private void Btn_trangDau_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadSanPhamPaged();
            }
        }

        private void Btn_keTiep_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadSanPhamPaged();
            }
        }

        private void Btn_troLai_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadSanPhamPaged();
            }
        }

        //hàm
        private void LoadProductPrice()
        {
            if (cbo_mauSac.SelectedItem != null && cbo_kichThuoc.SelectedItem != null)
            {
                string tenSanPham = productSelected?.TenSanPham; // Sử dụng null conditional để tránh lỗi NullReferenceException
                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Sản phẩm chưa được chọn.");
                    return;
                }

                string tenMauSac = cbo_mauSac.SelectedItem != null ? ((DTO.MauSac)cbo_mauSac.SelectedItem).TenMauSac : string.Empty;
                string kichThuoc = cbo_kichThuoc.SelectedItem != null ? ((DTO.KichThuoc)cbo_kichThuoc.SelectedItem).TenKichThuoc : string.Empty;
                string tenLoai = !string.IsNullOrEmpty(txt_loaiSanPham.Text) ? txt_loaiSanPham.Text : string.Empty;
                string tenThuongHieu = !string.IsNullOrEmpty(txt_thuongHieu.Text) ? txt_thuongHieu.Text : string.Empty;

                string maSanPham = _sanPhamBLL?.layMaSanPhamTheoTen(tenSanPham, tenThuongHieu, tenMauSac, kichThuoc);
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ. Vui lòng kiểm tra lại thông tin sản phẩm.");
                    return;
                }
                decimal? giaSanPham = _sanPhamBLL.layGiaBanTheoMaSanPham(maSanPham);
                if (giaSanPham.HasValue)
                {
                    txt_giaBan.Text = giaSanPham.Value.ToString("N0"); // "N0" sẽ định dạng giá theo kiểu số, không có phần thập phân
                }
                else
                {
                    txt_giaBan.Text = "Giá không có sẵn"; // Nếu không tìm thấy giá, hiển thị thông báo
                }

            }
            else
            {
               txt_giaBan.Clear();
            }
           
        }
        private void clearAll()
        {
            txt_maKhachHang.Text = "";
            txt_tenKhachHang.Text = "";
            txt_soDienThoai.Text = "";
            txt_diaChi.Text = "";
            txt_diemDung.Text = "";
            txt_diemTichLuy.Text = "";
            txt_soLuong.Text = "";
            txt_tongTien.Text = "";
            txt_TongSL.Text = "";
        }
        private decimal CalculateDiemTichLuy(decimal totalAmount)
        {
            decimal diemTichLuy = totalAmount * 0.05m;

            return diemTichLuy;
        }
        private int CalculateTotalProducts()
        {
            int totalProducts = 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    int quantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    totalProducts += quantity;
                }
            }

            return totalProducts;
        }
        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value ?? 0);
                    totalAmount += thanhTien;
                }
            }

            return totalAmount;
        }
        private string taoMaKhachHang()
        {
            string maKhachHang = "";
            int soLuongKH = _khachHangBLL.LayTatCaKhachHang().Count;
            if (soLuongKH == 0)
            {
                maKhachHang = "KH001";
            }
            else
            {
                maKhachHang = "KH" + (soLuongKH + 1).ToString("000");
            }
            return maKhachHang;
        }
        private string taoCTHD()
        {
            string maCTHD = "";
            int soLuongCTHD = _chiTietHoaDonBLL.LayTatCaChiTietHoaDon().Count;
            if (soLuongCTHD == 0)
            {
                maCTHD = "CTHD001";
            }
            else
            {
                maCTHD = "CTHD" + (soLuongCTHD + 1).ToString("000");
            }
            return maCTHD;
        }
        private string taoMaHoaDon()
        {
            string maHoaDon = "";

            if (_hoaDonBLL == null)
            {
                throw new InvalidOperationException("_hoaDonBanHangBLL is not initialized.");
            }

            var hoaDonList = _hoaDonBLL.LayTatCaHoaDon();
            if (hoaDonList == null)
            {
                throw new InvalidOperationException("GetAllHoaDonBanHang returned null.");
            }

            int soLuongHD = hoaDonList.Count;

            if (soLuongHD == 0)
            {
                maHoaDon = "HD001";
            }
            else
            {
                maHoaDon = "HD" + (soLuongHD + 1).ToString("000");
            }

            return maHoaDon;
        }
        private void InitializeDataGridView()
        {
            // Xóa cột cũ nếu có
            dgvCart.Columns.Clear();

            // Thêm các cột vào DataGridView
            dgvCart.Columns.Add("MaSP", "Mã Sản Phẩm");
            dgvCart.Columns.Add("TenSanPham", "Tên Sản Phẩm");
            dgvCart.Columns.Add("MauSac", "Màu Sắc");
            dgvCart.Columns.Add("KichThuoc", "Size");

            // Cột Số Lượng
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.Name = "SoLuong";
            colSoLuong.HeaderText = "SL";  // Tiêu đề cột
            colSoLuong.ValueType = typeof(int);  // Kiểu dữ liệu số nguyên
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải cho số lượng
            dgvCart.Columns.Add(colSoLuong);

            // Cột Giá
            dgvCart.Columns.Add("Gia", "Giá");

            // Cột Thành Tiền
            dgvCart.Columns.Add("ThanhTien", "Thành Tiền");

            // Cột Xóa (với hình ảnh)
            DataGridViewImageColumn btnXoa = new DataGridViewImageColumn();
            btnXoa.Name = "Xoa";
            btnXoa.HeaderText = "Xóa";
            btnXoa.Image = Properties.Resources.icons8_delete_35;  // Đảm bảo hình ảnh đã được thêm vào Resources
            btnXoa.ImageLayout = DataGridViewImageCellLayout.Zoom;  // Hình ảnh sẽ thu nhỏ vừa vặn với ô
            dgvCart.Columns.Add(btnXoa);

            // Đặt thuộc tính ReadOnly cho các cột không muốn chỉnh sửa
            dgvCart.Columns["MaSP"].ReadOnly = true;
            dgvCart.Columns["TenSanPham"].ReadOnly = true;
            dgvCart.Columns["MauSac"].ReadOnly = true;
            dgvCart.Columns["KichThuoc"].ReadOnly = true;
            dgvCart.Columns["Gia"].ReadOnly = true;
            dgvCart.Columns["ThanhTien"].ReadOnly = true;

            // Đặt chiều rộng của các cột đã có
            dgvCart.Columns["MaSP"].Width = 70;  // Đặt chiều rộng cột Mã Sản Phẩm là 70
            dgvCart.Columns["SoLuong"].Width = 30;  // Đặt chiều rộng cột Số Lượng là 30
            dgvCart.Columns["KichThuoc"].Width = 50;  // Đặt chiều rộng cột Kích Thước là 50

            // Đặt lại kiểu font cho tiêu đề cột
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            dgvCart.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Cập nhật lại bảng
            dgvCart.Refresh();

            // Thêm chức năng tự động thay đổi kích thước cột
            dgvCart.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvCart.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Ngăn không cho tạo thêm cột mới
            dgvCart.AllowUserToAddRows = false;
        }
        //hàm load thương hiệu loại sản phẩm, danh sách màu sắc ,danh sách kích thước
        private void loadThuocTinhSanPham(string tenSP)
        {
            try
            {
                // Lấy thông tin loại sản phẩm
                LoaiSanPham loaiSanPham = _loaiSanPhamBLL.layLoaiTheoTenSanPham(tenSP);
                if (loaiSanPham != null)
                {
                    txt_loaiSanPham.Text = loaiSanPham.TenLoaiSanPham;  // Hiển thị tên loại sản phẩm
                }

                // Lấy thông tin thương hiệu
                ThuongHieu thuongHieu = _thuongHieuBLL.layThuongHieuTheoTenSanPham(tenSP);
                if (thuongHieu != null)
                {
                    txt_thuongHieu.Text = thuongHieu.TenThuongHieu;  // Hiển thị tên thương hiệu
                }

                // Lấy danh sách màu sắc
                _lstMauSac = _mauSacBLL.layTatCaMauSacTheoTenSanPham(tenSP);
                if (_lstMauSac != null && _lstMauSac.Count > 0)
                {
                    cbo_mauSac.DataSource = _lstMauSac;
                    cbo_mauSac.DisplayMember = "TenMauSac";  // Hiển thị tên màu sắc
                    cbo_mauSac.ValueMember = "MaMauSac";     // Lưu giá trị của mã màu sắc
                }
                //lấy danh sách kích thươc
                _lstKichThuoc = _kichThuocBLL.LayTatCaKichThuocTheoTenSanPham(tenSP);
                if (_lstKichThuoc != null && _lstKichThuoc.Count > 0)
                {
                    cbo_kichThuoc.DataSource = _lstKichThuoc;
                    cbo_kichThuoc.DisplayMember = "TenKichThuoc";  // Hiển thị tên kích thước
                    cbo_kichThuoc.ValueMember = "MaKichThuoc";     // Lưu giá trị của mã kích thước
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //load combobox thương hiệu
        private void loadCboThuongHieu()
        {
            try
            {
                _lstThuongHieu = new List<ThuongHieu>();
                _lstThuongHieu = _thuongHieuBLL.LayTatCaThuongHieu();
                cbo_thuongHieu.DataSource = _lstThuongHieu;
                cbo_thuongHieu.ValueMember = "MaThuongHieu";
                cbo_thuongHieu.DisplayMember = "TenThuongHieu";
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        //load combobox loai sản phẩm
        private void loadCboLoaiSanPham()
        {
            try
            {
                _lstLoaiSanPham = new List<LoaiSanPham>();
                _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
                cbo_loai.DataSource = _lstLoaiSanPham;
                cbo_loai.DisplayMember = "TenLoaiSanPham";
                cbo_loai.ValueMember = "MaLoaiSanPham";
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        private void UpdatePaginationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            btn_troLai.Enabled = currentPage > 1;
            btn_keTiep.Enabled = currentPage < totalPages;
            btn_trangDau.Enabled = currentPage > 1;
            btn_trangCuoi.Enabled = currentPage < totalPages;
        }
        // Hàm tải sản phẩm theo phân trang
        private void LoadSanPhamPaged()
        {
            string maloai = string.Empty;
            string maThuongHieu= string.Empty;
            List<SanPham> pagedSanPhamList = _sanPhamBLL.GetSanPhamsPaged(currentPage, pageSize,maloai,maThuongHieu, out totalRecords);
            loadSanPham(pagedSanPhamList);
            UpdatePaginationButtons();
        }

        private void LoadImageToPictureBox(string imageName, PictureBox pictureBox)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                if (File.Exists(resourcePath))
                {
                    pictureBox.Image = Image.FromFile(resourcePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Điều chỉnh ảnh để vừa vặn trong PictureBox
                }
                else
                {
                    pictureBox.Image = null; // Thay thế với ảnh mặc định của bạn
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void loadSanPham(List<SanPham> ListSanPham)
        {
            dsSanPham.Controls.Clear();  // Xóa tất cả các điều khiển cũ
            int controlWidth = 165;
            int controlHeight = 170;
            int spacing = 15;
            int panelWidth = dsSanPham.ClientSize.Width;
            int currentX = 10; // Vị trí X bắt đầu
            int currentY = 10; // Vị trí Y bắt đầu

            foreach (var sp in ListSanPham)
            {
                ProductItem myControl = new ProductItem();
                myControl.TenSanPham = sp.TenSanPham;  // Gán tên sản phẩm vào Label
                myControl.BamChuot += MyControl_BamChuot;
                myControl.Click += MyControl_Click;
                myControl.MouseEnter += MyControl_MouseEnter;
                myControl.MouseLeave += MyControl_MouseLeave;
                myControl.Size = new Size(controlWidth, controlHeight);
                myControl.Location = new Point(currentX, currentY);
                PictureBox anhSanPham = myControl.Controls.Find("anhSanPham", true).FirstOrDefault() as PictureBox;
                if (anhSanPham != null)
                {
                    LoadImageToPictureBox(sp.HinhAnh, anhSanPham);  // Thay thế sp.HinhAnh với đường dẫn hình ảnh
                }

                dsSanPham.Controls.Add(myControl);
                currentX += controlWidth + spacing;
                if (currentX + controlWidth > panelWidth)
                {
                    currentX = 10;
                    currentY += controlHeight + spacing;
                }
            }

            dsSanPham.AutoScrollMinSize = new Size(0, currentY + controlHeight + spacing);
        }
        private void MyControl_BamChuot(object sender, EventArgs e)
        {
            var clickItem = sender as ProductItem;
            if (clickItem != null)
            {
                if (productSelected != null && productSelected != clickItem)
                {
                    productSelected.IsSelected = false; // Bỏ chọn sản phẩm đã chọn
                }
                productSelected = clickItem;
                productSelected.IsSelected = true; // Đánh dấu sản phẩm hiện tại là được chọn
                string tensp = productSelected.TenSanPham;
                loadThuocTinhSanPham(tensp);
                LoadProductPrice();
            }
        }

        private void MyControl_MouseLeave(object sender, EventArgs e)
        {
            var hoverItem = sender as ProductItem;
            if (hoverItem != null && !hoverItem.IsSelected) // Chỉ thay đổi màu nếu không được chọn
            {
                hoverItem.BackColor = Color.White;
            }
        }

        private void MyControl_MouseEnter(object sender, EventArgs e)
        {
            var hoverItem = sender as ProductItem;
            if (hoverItem != null && !hoverItem.IsSelected) // Chỉ thay đổi màu nếu không được chọn
            {
                hoverItem.BackColor = Color.LightCyan;
            }
        }

        private void MyControl_Click(object sender, EventArgs e)
        {
            var clickItem = sender as ProductItem;
            if (clickItem != null)
            {
                if (productSelected != null && productSelected != clickItem)
                {
                    productSelected.IsSelected = false; // Bỏ chọn sản phẩm đã chọn
                }
                productSelected = clickItem;
                productSelected.IsSelected = true; // Đánh dấu sản phẩm hiện tại là được chọn
                string tensp = productSelected.TenSanPham;
                loadThuocTinhSanPham(tensp);
                LoadProductPrice();

            }
        }


    }
}
