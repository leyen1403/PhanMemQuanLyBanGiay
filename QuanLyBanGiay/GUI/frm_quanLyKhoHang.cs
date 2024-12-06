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
    public partial class frm_quanLyKhoHang : Form
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
        List<LoaiSanPham> lstLoaiSanPham=null;

        private bool flagThemSP = false;
        private bool flagSuaSP = false;
        

        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyKhoHang_Load;
        }

        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadThuongHieu();
            LoadLoaiSanPham();
            LoadMauSac();
            LoadKichThuoc();
            LoadThuongHieuAdd();
            LoadLoaiSanPhamAdd();
            LoadMauSacAdd();
            LoadKichThuocAdd();
            hienThiTrangThai();
            InitDataGirdView();
            this.dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
            this.cbo_loaiSanPham.SelectedIndexChanged += Cbo_loaiSanPham_SelectedIndexChanged;
            this.cbo_thuongHieu.SelectedIndexChanged += Cbo_thuongHieu_SelectedIndexChanged;
            this.cbo_mauSac.SelectedIndexChanged += Cbo_mauSac_SelectedIndexChanged;
            this.cbo_kichThuoc.SelectedIndexChanged += Cbo_kichThuoc_SelectedIndexChanged;
            this.btn_timKiem.Click += Btn_timKiem_Click;
            this.btn_timDK.Click += Btn_timDK_Click;
            this.btn_load.Click += Btn_load_Click;
            this.btn_themAnh.Click += Btn_themAnh_Click;
            this.btn_themSanPham.Click += Btn_themSanPham_Click;
            this.btn_xoaSanPham.Click += Btn_xoaSanPham_Click;
            this.btn_suaSanPham.Click += Btn_suaSanPham_Click;
            txt_ngayTao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txt_ngayCapNhat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            PlaceHolder.SetPlaceholder(txt_timSanPham, "Nhập từ khóa tìm kiếm");
            dgv_dsSanPham.ReadOnly = true;
        }

        private void Btn_xoaLuon_Click(object sender, EventArgs e)
        {
            // hỏi trước khi xóa
            try
            {
                //kiểm tra mã sản phẩm có tồn tại không
                string maSanPham = txt_maSanPham.Text;
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không được để trống!");
                    return;
                }
                if (!KiemTraMaSanPham(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại!");
                    return;
                }
                DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }
                bool isSuccess = _sanPhamBLL.xoaSanPham(maSanPham);
                if (isSuccess) {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa sản phẩm. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_suaSanPham_Click(object sender, EventArgs e)
        {
            //kiểm tra cờ sửa sản phẩm
            if(flagSuaSP)
            {
                try
                {
                    //kiểm tra dữ liệu nhập vào
                    string maSanPham = txt_maSanPham.Text;
                    string tenSanPham = txt_tenSanPham.Text;
                    string donViTinh = txt_donViTinh.Text;
                    string giaNhapText = txt_giaNhap.Text;
                    string giaBanText = txt_giaBan.Text;
                    giaNhapText = giaNhapText.Replace(",", "").Replace("₫", "").Trim();
                    giaBanText = giaBanText.Replace(",", "").Replace("₫", "").Trim();
                    int soLuongToiThieu = Convert.ToInt32(txt_soLuongToiThieu.Text);
                    string moTa = txt_moTa.Text;
                    string hinhAnh = txt_duongDan.Text;
                    string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                    string mauSac = cbo_mauSacAdd.SelectedValue.ToString();
                    string kichThuoc = cbo_kichThuocAdd.SelectedValue.ToString();
                    string maThuongHieu = cbo_thuongHieuAdd.SelectedValue.ToString();
                    bool trangThai = cbo_trangThai.SelectedItem.ToString() == "Đang hoạt động" ? true : false;
                    //kiểm gia giá trị nhập vào
                    if (string.IsNullOrEmpty(maSanPham))
                    {
                        MessageBox.Show("Mã sản phẩm không được để trống!");
                        return;
                    }
                    //kiểm tra sản phẩm có tồn tại
                    if (!KiemTraMaSanPham(maSanPham))
                    {
                        MessageBox.Show("Mã sản phẩm không tồn tại!");
                        return;
                    }

                    // sửa sản phẩm
                    SanPham sp = new SanPham
                    {
                        MaSanPham = maSanPham,
                        TenSanPham = tenSanPham,
                        MaLoaiSanPham = maLoai,
                        MaThuongHieu = maThuongHieu,
                        MaMauSac = mauSac,
                        MaKichThuoc = kichThuoc,
                        DonViTinh = donViTinh,
                        SoLuongToiThieu = soLuongToiThieu,
                        GiaNhap = Convert.ToDecimal(giaNhapText),
                        GiaBan = Convert.ToDecimal(giaBanText),
                        MoTa = moTa,
                        HinhAnh = hinhAnh,
                        NgayCapNhat = DateTime.Now,
                        TrangThaiHoatDong = trangThai
                    };
                    bool isSuccess = _sanPhamBLL.suaSanPham(sp);
                    if (isSuccess)
                    {
                        MessageBox.Show("Sửa sản phẩm thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa sản phẩm. Vui lòng thử lại.");
                    }
                    btn_suaSanPham.BackgroundImage = Properties.Resources.icons8_update_32;
                    btn_themSanPham.Enabled = true;
                    btn_xoaSanPham.Enabled = true;
                    flagSuaSP = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                btn_themSanPham.Enabled = false;
                btn_xoaSanPham.Enabled = false;
                btn_suaSanPham.BackgroundImage = Properties.Resources.icons8_save_as_32;
                flagSuaSP = true;
            }
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            //xoá textbox
            txt_maSanPham.Text = string.Empty;
            txt_tenSanPham.Text = string.Empty;
            txt_donViTinh.Text = string.Empty;
            txt_soLuongTon.Text = string.Empty;
            txt_giaNhap.Text = string.Empty;
            txt_giaBan.Text = string.Empty;
            txt_moTa.Text = string.Empty;
            txt_ngayTao.Text = string.Empty;
            txt_ngayCapNhat.Text = string.Empty;
            txt_soLuongToiThieu.Text = string.Empty;
            cbo_trangThai.SelectedIndex = -1;
            txt_duongDan.Text = string.Empty;
            img_sanPham.Image = null;
            cbo_loaiSanPhamAdd.SelectedIndex = -1;
            cbo_thuongHieuAdd.SelectedIndex = -1;
            cbo_mauSacAdd.SelectedIndex = -1;
            cbo_kichThuocAdd.SelectedIndex = -1;
            txt_tenSanPham.Focus();
        }


        private void Btn_luuSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra dữ liệu nhập vào
                string maSanPham = txt_maSanPham.Text;
                string tenSanPham = txt_tenSanPham.Text;
                string donViTinh = txt_donViTinh.Text;
                string giaNhapText = txt_giaNhap.Text;
                string giaBanText = txt_giaBan.Text;
                giaNhapText = giaNhapText.Replace(",", "").Replace("₫", "").Trim();
                giaBanText = giaBanText.Replace(",", "").Replace("₫", "").Trim();
                int soLuongToiThieu = Convert.ToInt32(txt_soLuongToiThieu.Text);
                string moTa = txt_moTa.Text;
                string hinhAnh = txt_duongDan.Text;
                string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                string mauSac = cbo_mauSacAdd.SelectedValue.ToString();
                string kichThuoc = cbo_kichThuocAdd.SelectedValue.ToString();
                string maThuongHieu = cbo_thuongHieuAdd.SelectedValue.ToString();
                //kiểm gia giá trị nhập vào
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không được để trống!");
                    return;
                }
                //kiểm tra sản phẩm có tồn tại
                if (!KiemTraMaSanPham(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại!");
                    return;
                }
                
                // sửa sản phẩm
                SanPham sp = new SanPham
                {
                    MaSanPham = maSanPham,
                    TenSanPham = tenSanPham,
                    MaLoaiSanPham = maLoai,
                    MaThuongHieu = maThuongHieu,
                    MaMauSac = mauSac,
                    MaKichThuoc = kichThuoc,
                    DonViTinh = donViTinh,
                    SoLuong = 0,
                    SoLuongToiThieu = soLuongToiThieu,
                    GiaNhap = Convert.ToDecimal(giaNhapText),
                    GiaBan = Convert.ToDecimal(giaBanText),
                    MoTa = moTa,
                    HinhAnh = hinhAnh,
                    NgayCapNhat = DateTime.Now
                };
                bool isSuccess = _sanPhamBLL.suaSanPham(sp);
                if (isSuccess)
                {
                    MessageBox.Show("Sửa sản phẩm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa sản phẩm. Vui lòng thử lại.");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_khoiPhuc_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra mã sản phẩm có tồn tại không
                string maSanPham = txt_maSanPham.Text;
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không được để trống!");
                    return;
                }
                if (!KiemTraMaSanPham(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại!");
                    return;
                }
                bool isSuccess = _sanPhamBLL.xoaSanPham(maSanPham, true);
                if (isSuccess)
                {
                    MessageBox.Show("Khôi phục sản phẩm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi khôi phục sản phẩm. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_xoaSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra mã sản phẩm có tồn tại không
                string maSanPham = txt_maSanPham.Text;
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không được để trống!");
                    return;
                }
                if (!KiemTraMaSanPham(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại!");
                    return;
                }
                DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.No)
                {
                    return;
                }
                bool isSuccess = _sanPhamBLL.xoaSanPham(maSanPham);
                if (isSuccess)
                {
                    MessageBox.Show("Xóa sản phẩm thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa sản phẩm. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_themSanPham_Click(object sender, EventArgs e)
        {
            if(flagThemSP)
            {
                //kiểm tra dữ liệu nhập vào
                try
                {
                    string maSanPham = TaoMaSanPhamTuDong();
                    string tenSanPham = txt_tenSanPham.Text;
                    string donViTinh = txt_donViTinh.Text;
                    string giaNhapText = txt_giaNhap.Text;
                    string giaBanText = txt_giaBan.Text;
                    giaNhapText = giaNhapText.Replace(",", "").Replace("₫", "").Trim();
                    giaBanText = giaBanText.Replace(",", "").Replace("₫", "").Trim();
                    //kiểm gia giá trị nhập vào
                    if (string.IsNullOrEmpty(maSanPham))
                    {
                        MessageBox.Show("Mã sản phẩm không được để trống!");
                        return;
                    }
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
                    if (cbo_loaiSanPhamAdd.SelectedValue == null || cbo_thuongHieuAdd.SelectedValue == null || cbo_kichThuocAdd.SelectedValue == null || cbo_mauSacAdd.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn Mã Loại, Màu Sắc và Kích Thước.");
                        return;
                    }

                    string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                    string mauSac = cbo_mauSacAdd.SelectedValue.ToString();
                    string kichThuoc = cbo_kichThuocAdd.SelectedValue.ToString();
                    string maThuongHieu = cbo_thuongHieuAdd.SelectedValue.ToString();

                    // Kiểm tra và lấy giá trị của màu sắc từ ComboBox
                    string tenMauSac = cbo_mauSacAdd.SelectedItem != null
                        ? ((DTO.MauSac)cbo_mauSacAdd.SelectedItem).TenMauSac
                        : string.Empty;

                    // Kiểm tra và lấy giá trị của kích thước từ ComboBox
                    string tenKichThuoc = cbo_kichThuocAdd.SelectedItem != null
                        ? ((DTO.KichThuoc)cbo_kichThuocAdd.SelectedItem).TenKichThuoc
                        : string.Empty;

                    //kiểm tra và lấy giá trị của thương hiệu từ combobox
                    string tenThuongHieu = cbo_thuongHieuAdd.SelectedItem != null
                        ? ((DTO.ThuongHieu)cbo_thuongHieuAdd.SelectedItem).TenThuongHieu
                        : string.Empty;
                    //kiểm tra và lấy giá trị của trang thái từ combobox
                    bool trangThai = cbo_trangThai.SelectedItem.ToString() == "Đang hoạt động" ? true : false;

                    string maDaCo = _sanPhamBLL.timKiemMaSanPham(tenSanPham, kichThuoc, mauSac, maThuongHieu, maLoai);
                    if (maDaCo != "")
                    {
                        MessageBox.Show("Đã có sản phẩm này rồi !");
                        return;
                    }

                    SanPham newProduct = new SanPham
                    {
                        MaSanPham = maSanPham,
                        TenSanPham = tenSanPham,
                        MaLoaiSanPham = maLoai,
                        MaThuongHieu = maThuongHieu,
                        MaMauSac = mauSac,
                        MaKichThuoc = kichThuoc,
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

                    bool isSuccess = _sanPhamBLL.themSanPham(newProduct);
                    if (isSuccess)
                    {
                        MessageBox.Show("Sản phẩm đã được thêm thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm sản phẩm. Vui lòng thử lại.");
                    }
                    btn_themSanPham.BackgroundImage = Properties.Resources.icons8_add_32;
                    btn_xoaSanPham.Enabled = true;
                    btn_suaSanPham.Enabled = true;
                    flagThemSP = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                
                //không cho chọn các button khác
                btn_xoaSanPham.Enabled = false;
                btn_suaSanPham.Enabled = false;
                btn_themSanPham.BackgroundImage = Properties.Resources.icons8_save_as_32;
                flagThemSP = true;
                ClearTextBox();
            }


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

        private void Btn_load_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Btn_timDK_Click(object sender, EventArgs e)
        {
            string maLoai = cbo_loaiSanPham.SelectedValue?.ToString() ?? string.Empty;
            string maThuongHieu = cbo_thuongHieu.SelectedValue?.ToString() ?? string.Empty;
            string maMau = cbo_mauSac.SelectedValue?.ToString() ?? string.Empty;
            string maKichThuoc = cbo_kichThuoc.SelectedValue?.ToString() ?? string.Empty;
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = _sanPhamBLL.timKiemSanPham(maLoai, maMau, maKichThuoc, maThuongHieu);
                dgv_dsSanPham.DataSource = lstSanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txt_timSanPham.Text;
            if(string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa cần tìm kiếm");
                return;
            }
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = _sanPhamBLL.laySanPhamTheoDieuKien(tuKhoa);
                dgv_dsSanPham.DataSource = lstSanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Cbo_kichThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maKichThuoc = cbo_kichThuoc.SelectedValue.ToString();
            if (string.IsNullOrEmpty(maKichThuoc))
            {
                return;
            }
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = _sanPhamBLL.layDanhSachSanPhamTheoMaKichThuoc(maKichThuoc);
                dgv_dsSanPham.DataSource = lstSanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Cbo_mauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maMauSac = cbo_mauSac.SelectedValue.ToString();
            if (string.IsNullOrEmpty(maMauSac))
            {
                return;
            }
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = _sanPhamBLL.layDanhSachSanphamTheoMaMau(maMauSac);
                dgv_dsSanPham.DataSource = lstSanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Cbo_thuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kiểm tra có chọn thương hiệu không
            string maThuongHieu = cbo_thuongHieu.SelectedValue.ToString();
            if(string.IsNullOrEmpty(maThuongHieu) )
            {
                return;
            }
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = _sanPhamBLL.layDanhSachSanPhamTheoMaThuongHieu(maThuongHieu);
                dgv_dsSanPham.DataSource=lstSanPham;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Cbo_loaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kiểm tra combobox có chọn hay không
            if(cbo_loaiSanPham == null)
            {
                return;
            }
            string maLoai = cbo_loaiSanPham.SelectedValue.ToString();
            if(string.IsNullOrEmpty(maLoai))
            {
                return;
            }    
            lstSanPham = new List<SanPham>();
            lstSanPham = _sanPhamBLL.layDanhSachSanPhamTheoMaLoai(maLoai);
            dgv_dsSanPham.DataSource = lstSanPham;
        }

        private void Dgv_dsSanPham_SelectionChanged(object sender, EventArgs e)
        {
            //hiện lên textbox
            GetCurrentRowData();
        }

        //viết hàm ở đây
        private void ClearTextBox()
        {
            //xoá textbox
            txt_maSanPham.Text = string.Empty;
            txt_tenSanPham.Text = string.Empty;
            txt_donViTinh.Text = string.Empty;
            txt_soLuongTon.Text = string.Empty;
            txt_giaNhap.Text = string.Empty;
            txt_giaBan.Text = string.Empty;
            txt_moTa.Text = string.Empty;
            txt_ngayTao.Text = string.Empty;
            txt_ngayCapNhat.Text = string.Empty;
            txt_soLuongToiThieu.Text = string.Empty;
            cbo_trangThai.SelectedIndex = -1;
            txt_duongDan.Text = string.Empty;
            img_sanPham.Image = null;
            cbo_loaiSanPhamAdd.SelectedIndex = -1;
            cbo_thuongHieuAdd.SelectedIndex = -1;
            cbo_mauSacAdd.SelectedIndex = -1;
            cbo_kichThuocAdd.SelectedIndex = -1;
            txt_tenSanPham.Focus();
        }
        //load combobox trạng thái
        private void hienThiTrangThai()
        {
            cbo_trangThai.Items.Add("Đang hoạt động");
            cbo_trangThai.Items.Add("Ngừng hoạt động");
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
        private void LoadLoaiSanPham()
        {
            lstLoaiSanPham = new List<LoaiSanPham>();
            lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
            if(lstLoaiSanPham==null)
            {
                return;
            }    
            cbo_loaiSanPham.DataSource=lstLoaiSanPham;
            cbo_loaiSanPham.DisplayMember = "TenLoaiSanPham";
            cbo_loaiSanPham.ValueMember = "MaLoaiSanPham";
        }
        //load dữ liệu lên combobox kích thước và màu sắc
        private void LoadKichThuocAdd()
        {
            lstKichThuoc = new List<KichThuoc>();
            lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
            if (lstKichThuoc == null)
            {
                Console.WriteLine("Không có kích thước nào trong kho hàng");
                return;
            }
            cbo_kichThuocAdd.DataSource = lstKichThuoc;
            cbo_kichThuocAdd.DisplayMember = "TenKichThuoc";
            cbo_kichThuocAdd.ValueMember = "MaKichThuoc";
        }
        private void LoadKichThuoc()
        {
            lstKichThuoc = new List<KichThuoc>();
            lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
            if (lstKichThuoc == null)
            {
                Console.WriteLine("Không có kích thước nào trong kho hàng");
                return;
            }
            lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
            cbo_kichThuoc.DataSource = lstKichThuoc;
            cbo_kichThuoc.DisplayMember = "TenKichThuoc";
            cbo_kichThuoc.ValueMember = "MaKichThuoc";
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
        private void LoadThuongHieu()
        {
            lstThuongHieu = new List<ThuongHieu>();
            lstThuongHieu = _thuongHieuBLL.LayTatCaThuongHieu();
            if (lstThuongHieu == null)
            {
                Console.WriteLine("Không có thương hiệu nào trong kho hàng");
                return;
            }
            cbo_thuongHieu.DataSource = lstThuongHieu;
            cbo_thuongHieu.DisplayMember = "TenThuongHieu";
            cbo_thuongHieu.ValueMember = "MaThuongHieu";
        }
        //load lên combo màu sắc
        private void LoadMauSacAdd()
        {
            lstMauSac = new List<MauSac>();
            lstMauSac = _mauSacBLL.layTatCaMauSac();
            if (lstMauSac == null)
            {
                Console.WriteLine("Không có màu sắc nào trong kho hàng");
                return;
            }
            cbo_mauSacAdd.DataSource = lstMauSac;
            cbo_mauSacAdd.DisplayMember = "TenMauSac";
            cbo_mauSacAdd.ValueMember = "MaMauSac";
        }
        private void LoadMauSac()
        {
            lstMauSac = new List<MauSac>();
            lstMauSac = _mauSacBLL.layTatCaMauSac();
            if (lstMauSac == null)
            {
                MessageBox.Show("Không có màu sắc nào trong kho hàng");
                return;
            }
            cbo_mauSac.DataSource = lstMauSac;
            cbo_mauSac.DisplayMember = "TenMauSac";
            cbo_mauSac.ValueMember = "MaMauSac";
        }
        private void LoadComBoBoxTongHop(string maLoai, string maThuongHieu, string maMau, string maKichThuoc)
        {
            // Kiểm tra và gán giá trị cho ComboBox loại sản phẩm
            if (!string.IsNullOrEmpty(maLoai))
            {
                var loaiSanPham = cbo_loaiSanPhamAdd.Items.Cast<LoaiSanPham>()
                    .FirstOrDefault(item => item.MaLoaiSanPham == maLoai); // Tìm kiếm theo mã loại sản phẩm

                if (loaiSanPham != null)
                {
                    cbo_loaiSanPhamAdd.SelectedItem = loaiSanPham;  // Gán đối tượng vào ComboBox
                }
                else
                {
                    cbo_loaiSanPhamAdd.SelectedIndex = -1;  // Đặt không chọn gì
                    cbo_loaiSanPhamAdd.Text = "Không tìm thấy mã loại sản phẩm";
                }
            }

            // Kiểm tra và gán giá trị cho ComboBox thương hiệu
            if (!string.IsNullOrEmpty(maThuongHieu))
            {
                var thuongHieu = cbo_thuongHieuAdd.Items.Cast<ThuongHieu>()
                    .FirstOrDefault(item => item.MaThuongHieu == maThuongHieu); // Tìm kiếm theo mã thương hiệu

                if (thuongHieu != null)
                {
                    cbo_thuongHieuAdd.SelectedItem = thuongHieu;  // Gán đối tượng vào ComboBox
                }
                else
                {
                    cbo_thuongHieuAdd.SelectedIndex = -1;  // Đặt không chọn gì
                    cbo_thuongHieuAdd.Text = "Không tìm thấy mã thương hiệu";
                }
            }

            // Kiểm tra và gán giá trị cho ComboBox màu sắc
            if (!string.IsNullOrEmpty(maMau))
            {
                var mauSac = cbo_mauSacAdd.Items.Cast<MauSac>()
                    .FirstOrDefault(item => item.MaMauSac == maMau); // Tìm kiếm theo mã màu sắc

                if (mauSac != null)
                {
                    cbo_mauSacAdd.SelectedItem = mauSac;  // Gán đối tượng vào ComboBox
                }
                else
                {
                    cbo_mauSacAdd.SelectedIndex = -1;  // Đặt không chọn gì
                    cbo_mauSacAdd.Text = "Không tìm thấy mã màu sắc";
                }
            }

            // Kiểm tra và gán giá trị cho ComboBox kích thước
            if (!string.IsNullOrEmpty(maKichThuoc))
            {
                var kichThuoc = cbo_kichThuocAdd.Items.Cast<KichThuoc>()
                    .FirstOrDefault(item => item.MaKichThuoc == maKichThuoc); // Tìm kiếm theo mã kích thước

                if (kichThuoc != null)
                {
                    cbo_kichThuocAdd.SelectedItem = kichThuoc;  // Gán đối tượng vào ComboBox
                }
                else
                {
                    cbo_kichThuocAdd.SelectedIndex = -1;  // Đặt không chọn gì
                    cbo_kichThuocAdd.Text = "Không tìm thấy mã kích thước";
                }
            }
        }

        private void GetCurrentRowData()
        {
            try
            {

                if (dgv_dsSanPham.CurrentRow != null)
                {
                    DataGridViewRow currentRow = dgv_dsSanPham.CurrentRow;
                    txt_maSanPham.Text = currentRow.Cells["MaSanPham"].Value.ToString();
                    txt_tenSanPham.Text = currentRow.Cells["TenSanPham"].Value.ToString();
                    txt_donViTinh.Text = currentRow.Cells["DonViTinh"].Value.ToString();
                    txt_soLuongTon.Text = Convert.ToInt32(currentRow.Cells["SoLuong"].Value).ToString();
                    decimal giaNhap = Convert.ToDecimal(currentRow.Cells["GiaNhap"].Value);
                    decimal giaBan = Convert.ToDecimal(currentRow.Cells["GiaBan"].Value);
                    txt_giaNhap.Text = giaNhap.ToString("N0");
                    txt_giaBan.Text = giaBan.ToString("N0");
                    txt_moTa.Text = currentRow.Cells["MoTa"].Value.ToString();
                    txt_ngayTao.Text = Convert.ToDateTime(currentRow.Cells["NgayTao"].Value).ToString("dd/MM/yyyy");
                    txt_ngayCapNhat.Text = Convert.ToDateTime(currentRow.Cells["NgayCapNhat"].Value).ToString("dd/MM/yyyy");
                    txt_soLuongToiThieu.Text = Convert.ToInt32(currentRow.Cells["SoLuongToiThieu"].Value).ToString();
                    string hinhanh = currentRow.Cells["HinhAnh"].Value?.ToString();
                    LoadImageToPictureBox(hinhanh);
                    string maLoai = currentRow.Cells["MaLoaiSanPham"].Value.ToString();
                    string maThuongHieu = currentRow.Cells["MaThuongHieu"].Value.ToString();
                    string maMau = currentRow.Cells["MaMauSac"].Value.ToString();
                    string maKichThuoc = currentRow.Cells["MaKichThuoc"].Value.ToString();
                    LoadComBoBoxTongHop(maLoai,maThuongHieu,maMau,maKichThuoc);
                    if (!string.IsNullOrEmpty(hinhanh))
                    {
                        LoadImageToPictureBox(hinhanh);
                    }
                    else
                    {
                        img_sanPham.Image = null;
                    }

                    string trangThai = currentRow.Cells["TrangThaiHoatDong"].Value?.ToString(); // Sử dụng dấu hỏi (?) để kiểm tra null
                    if (string.IsNullOrEmpty(trangThai))
                    {
                        cbo_trangThai.SelectedIndex = -1;
                    }
                    else
                    {
                        //hiển thị trạng thái
                        cbo_trangThai.SelectedIndex = trangThai == "True" ? 0 : 1;
                    }
                }
                else
                {
                    Console.Write("Không có dòng nào được chọn.");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi khi lấy dữ liệu từ dòng hiện tại: " + ex.Message);
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

        public void LoadData()
        {
            lstSanPham = new List<SanPham>();
            lstSanPham = _sanPhamBLL.layDanhSachSanPham();
            if(lstSanPham ==null)
            {
                MessageBox.Show("Không có sản phẩm nào trong kho hàng");
                return;
            }    
            dgv_dsSanPham.DataSource = lstSanPham;
            foreach (DataGridViewRow row in dgv_dsSanPham.Rows)
            {
                bool trangThai = Convert.ToBoolean(row.Cells["TrangThaiHoatDong"].Value);
                if (!trangThai)
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
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
        public void InitDataGirdView()
        {
            // Thêm tiêu đề cho các cột
            dgv_dsSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgv_dsSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgv_dsSanPham.Columns["SoLuong"].HeaderText = "Số lượng";
            dgv_dsSanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dgv_dsSanPham.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgv_dsSanPham.Columns["MaKichThuoc"].HeaderText = "Mã kích thước";
            dgv_dsSanPham.Columns["MaMauSac"].HeaderText = "Mã màu sắc";
            dgv_dsSanPham.Columns["MaThuongHieu"].HeaderText = "Mã thương hiệu";
            dgv_dsSanPham.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái";
            dgv_dsSanPham.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_dsSanPham.Columns["HinhAnh"].HeaderText = "Hình ảnh";
            dgv_dsSanPham.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgv_dsSanPham.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgv_dsSanPham.Columns["SoLuongToiThieu"].HeaderText = "Số lượng tối thiểu";

            // Hiển thị giá tiền kiểu N0
            dgv_dsSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgv_dsSanPham.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";

            // Ẩn cột
            dgv_dsSanPham.Columns["LoaiSanPham"].Visible = false;
            dgv_dsSanPham.Columns["ThuongHieu"].Visible = false;
            dgv_dsSanPham.Columns["KichThuoc"].Visible = false;
            dgv_dsSanPham.Columns["MauSac"].Visible = false;

            // Định dạng cell và tô màu dòng nếu trạng thái không hoạt động
            dgv_dsSanPham.CellFormatting += (s, e) =>
            {
                if (dgv_dsSanPham.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong" && e.Value != null)
                {
                    // Kiểm tra giá trị có phải là kiểu bool hay không trước khi ép kiểu
                    if (e.Value is bool trangThai)
                    {
                        // Hiển thị "Đang hoạt động" nếu giá trị là true, ngược lại hiển thị "Không hoạt động"
                        e.Value = trangThai ? "Đang hoạt động" : "Không hoạt động";
                        e.FormattingApplied = true;

                        // Nếu trạng thái là "Không hoạt động", tô màu hồng dòng
                        if (!trangThai)
                        {
                            dgv_dsSanPham.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                        }
                        else
                        {
                            dgv_dsSanPham.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // Màu nền bình thường
                        }
                    }
                    else
                    {
                        // Nếu giá trị không phải là kiểu bool, có thể là null hoặc kiểu khác, tô màu nền bình thường
                        dgv_dsSanPham.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                }
            };
            dgv_dsSanPham.RowPostPaint += dgv_RowPostPaint;

        }

    }
}
