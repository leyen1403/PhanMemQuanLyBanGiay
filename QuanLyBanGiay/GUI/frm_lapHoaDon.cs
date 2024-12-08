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
        NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        public string MaNhanVien { get; set; }
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

        private string _MaHoaDon = string.Empty;
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
            this.dgvCart.SelectionChanged += DgvCart_SelectionChanged;
            this.btn_addCart.Click += Btn_addCart_Click;
            this.btn_Clear.Click += Btn_Clear_Click;
            this.btn_suaSL.Click += Btn_suaSL_Click;
            this.btn_timKhachHang.Click += Btn_timKhachHang_Click;
            this.btn_luuHoaDon.Click += Btn_luuHoaDon_Click;
            this.btn_timSanPham.Click += Btn_timSanPham_Click;
            this.btn_inHoaDon.Click += Btn_inHoaDon_Click;
            loadCboLoaiSanPham();
            loadCboThuongHieu();
            LoadSanPhamPaged();
            LoadComboBoxThanhToan();
            LoadComboBoxGioiTinh();
            txt_soLuong.Minimum = 1;
            txt_soLuong.Maximum = 100;
            txt_soLuong.Value = 1;
            InitializeDataGridView();
            PlaceHolder.SetPlaceholder(txt_tenSanPham, "Nhập thông tin sản phẩm");
            // nhập số lượng không lớn hơn số lượng tồn
            txt_SL.Minimum = 1;
            txt_SL.Maximum = 100;
            //su kien khi nhập vào ô số lượng không lớn hơn số lượng tồn
            txt_soLuong.TextChanged += Txt_soLuong_TextChanged;
            txt_soLuong.KeyPress += Txt_soLuong_KeyPress;
            LoadComboBoxKhachHang();
            cbo_khachHang.SelectedIndexChanged += Cbo_khachHang_SelectedIndexChanged;
            btn_themKhachHang.Click += Btn_themKhachHang_Click;
            btn_themKhachHang.Enabled = false;

            //xoá 1 sản phẩm trong giỏ hàng
            dgvCart.CellContentClick += DgvCart_CellContentClick;
        }

        private void Btn_themKhachHang_Click(object sender, EventArgs e)
        {
            // mở form thêm khách hàng
            frm_themKhachHang frm = new frm_themKhachHang();
            frm.ShowDialog();
            btn_themKhachHang.Enabled = false;
            cbo_khachHang.SelectedItem = "Khách hàng thành viên";
            //lấy thông tin khách hàng vừa thêm vào các textbox
        }

        private void Cbo_khachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy thông tin khách hàng từ ComboBox
            if (cbo_khachHang.SelectedItem != null)
            {
                //lấy giá trị của item được chọn
                string loaiKhachHang = cbo_khachHang.SelectedItem.ToString();
                if (loaiKhachHang == "Khách hàng thành viên")
                {
                    //hiện thông tin khách hàng thành viên
                    txt_diemDung.Enabled = true;
                    chkSuDungDiemTichLuy.Enabled = true;
                    // xoá hết thông tin khách hàng cũ
                    txt_maKhachHang.Text = string.Empty;
                    txt_tenKhachHang.Text = string.Empty;
                    txt_soDienThoai.Text = string.Empty;
                    txt_diaChi.Text = string.Empty;
                    txt_diemTichLuy.Text = string.Empty;
                    txt_diemDung.Text = string.Empty;
                    btn_themKhachHang.Enabled = false;

                }
                else if (loaiKhachHang == "Khách hàng vãng lai")
                {
                    //lấy khách hàng 001 gán vào các textbox
                    txt_maKhachHang.Text = "KH001";
                    txt_tenKhachHang.Text = "Khách hàng vãng lai";
                    txt_soDienThoai.Text = "0123456789";
                    txt_diaChi.Text = "Địa chỉ";
                    txt_diemTichLuy.Text = "0";
                    txt_diemDung.Text = "0";
                    txt_diemDung.Enabled = false;
                    chkSuDungDiemTichLuy.Enabled = false;
                    btn_themKhachHang.Enabled = false;
                }
                else
                {
                    txt_maKhachHang.Text = string.Empty;
                    txt_tenKhachHang.Text = string.Empty;
                    txt_soDienThoai.Text = string.Empty;
                    txt_diaChi.Text = string.Empty;
                    txt_diemTichLuy.Text = string.Empty;
                    txt_diemDung.Text = string.Empty;
                    btn_themKhachHang.Enabled = true;
                    txt_diemDung.Enabled = true;
                    chkSuDungDiemTichLuy.Enabled = true;
                    btn_themKhachHang.Enabled = true;
                }
            }
        }

        private void Txt_soLuong_TextChanged(object sender, EventArgs e)
        {
            int soLuong;
            if (!int.TryParse(txt_soLuong.Text, out soLuong))
            {
                MessageBox.Show("Vui lòng nhập một số hợp lệ.");
                txt_soLuong.Value = 1;
                return;
            }

            if (soLuong > 100)
            {
                txt_soLuong.Value = 1;
            }
            else if (soLuong < 0)
            {
                txt_soLuong.Value = 1;
            }
            else if (soLuong > txt_soLuongTon.Value)
            {
                MessageBox.Show("Số lượng sản phẩm không được lớn hơn số lượng tồn");
                txt_soLuong.Value = txt_soLuongTon.Value;
            }
        }

        private void Txt_soLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu không phải là số hoặc phím Backspace thì không cho nhập
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Btn_inHoaDon_Click(object sender, EventArgs e)
        {
            XuatHoaDon();
        }

        private void Btn_timSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                string maloai = string.Empty ;
                string maThuongHieu = string.Empty;
                string tenSanPham = txt_tenSanPham.Text;
                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm.");
                    return;
                }
                // Cập nhật lại trang hiện tại về 1 khi thay đổi loại sản phẩm
                currentPage = 1;
                List<SanPham> pagedSanPhamList = _sanPhamBLL.GetSanPhamsPaged(currentPage, pageSize, maloai, maThuongHieu, tenSanPham, out totalRecords);
                loadSanPham(pagedSanPhamList);
                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Btn_luuHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra giỏ hàng
            if (dgvCart.Rows.Count == 0 || dgvCart.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                MessageBox.Show("Giỏ hàng không có sản phẩm. Vui lòng thêm sản phẩm vào giỏ hàng trước khi lưu hóa đơn.");
                return;
            }

            // Lấy thông tin khách hàng từ các TextBox
            string maKhachHang = txt_maKhachHang.Text;
            string tenKhachHang = txt_tenKhachHang.Text;
            string sdt = txt_soDienThoai.Text;
            string diaChi = txt_diaChi.Text;
            decimal diemTichLuy = 0;
            string gioiTinh = cbo_gioiTinh.SelectedItem.ToString();
            // Tính tổng tiền và điểm tích lũy
            decimal tongTien = CalculateTotalAmount();
            diemTichLuy = CalculateDiemTichLuy(tongTien);

            int tongSl = CalculateTotalProducts();
            if (tongTien <= 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ.");
                return;
            }

            // Kiểm tra thông tin khách hàng
            if (string.IsNullOrEmpty(maKhachHang) && string.IsNullOrEmpty(tenKhachHang) && string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn thông tin khách hàng.");
                return;
            }

            // Lấy khách hàng từ cơ sở dữ liệu
            KhachHang kh = _khachHangBLL.LayKhachHangTheoDieuKien(maKhachHang, tenKhachHang, sdt);
            if (kh == null)
            {
                string maKhachHangMoi = taoMaKhachHang();
                // Thêm khách hàng mới vào cơ sở dữ liệu nếu chưa có
                KhachHang khachHangMoi = new KhachHang
                {
                    MaKhachHang = maKhachHangMoi,
                    TenKhachHang = tenKhachHang,
                    SoDienThoai = sdt,
                    DiaChi = diaChi,
                    DiemTichLuy = diemTichLuy, // Chỉnh sửa lại để gán điểm tích lũy đúng
                    ThanhVien = false, // Mặc định khách hàng mới không phải là thành viên
                    GioiTinh = gioiTinh,
                    NgayTao = DateTime.Now,
                    NgayCapNhat = DateTime.Now,
                    TrangThaiHoatDong = true
                };


                bool isAdded = _khachHangBLL.ThemKhachHang(khachHangMoi);

                if (!isAdded)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng mới.");
                    return;
                }

                kh = khachHangMoi;
            }
            string ghiChu = txt_ghiChu.Text;
            string hinhThucThanhToan = cbo_phuongThucTT.SelectedItem.ToString();
            if(string.IsNullOrEmpty(hinhThucThanhToan))
            {
                MessageBox.Show("Vui lòng chọn hình thức thanh toán.");
                return;
            }
            // Kiểm tra và sử dụng điểm tích lũy (nếu khách hàng là thành viên)
            decimal diemSuDung = 0; // Gán giá trị mặc định
            if (decimal.TryParse(txt_diemDung.Text, out diemSuDung))
            {
                // Chuyển thành công, diemSuDung sẽ chứa giá trị nhập vào
            }

            if (chkSuDungDiemTichLuy.Checked)
            {
                if (kh.ThanhVien == false) // Kiểm tra nếu khách hàng là thành viên mới có thể sử dụng điểm tích lũy
                {
                    MessageBox.Show("Chỉ khách hàng thành viên mới có thể sử dụng điểm tích lũy.");
                    return; // Dừng lại nếu khách hàng không phải là thành viên
                }
                if (diemSuDung > 0)
                {
                    // Đảm bảo điểm tích lũy sử dụng không vượt quá số điểm tích lũy của khách hàng
                    diemSuDung = (kh.DiemTichLuy ?? 0) >= diemSuDung ? diemSuDung : (kh.DiemTichLuy ?? 0);
                    tongTien -= diemSuDung; // Trừ điểm tích lũy từ tổng tiền
                    txt_tongTien.Text = tongTien.ToString("0.##"); // Cập nhật tổng tiền
                }
            }

            // Kiểm tra và lưu hóa đơn
            try
            {
                HoaDon hoaDon = new HoaDon
                {
                    MaHoaDon = taoMaHoaDon(), // Tạo mã hóa đơn mới
                    NgayTao = DateTime.Now, // Thời gian lập hóa đơn
                    MaKhachHang = kh.MaKhachHang, // Mã khách hàng (có giá trị hợp lệ?)
                    MaNhanVien = MaNhanVien, // Mã nhân viên (có giá trị hợp lệ?)
                    GhiChu = ghiChu, // Ghi chú
                    PhuongThucThanhToan = hinhThucThanhToan, // Hình thức thanh toán
                    TongTien = tongTien, // Tổng tiền
                    DiemTichLuySuDung = (int?)Convert.ToInt32(diemSuDung)  // Convert diemSuDung to int before casting to int?
                };

                bool themDiemCong = _khachHangBLL.AddDiemCongTichLuy(kh.MaKhachHang, diemTichLuy);

                if (!themDiemCong)
                {
                    Console.WriteLine("Thêm điểm cộng thất bại");
                }

                // Kiểm tra các giá trị trước khi thêm vào cơ sở dữ liệu
                if (hoaDon.MaKhachHang == null || hoaDon.MaNhanVien == null)
                {
                    MessageBox.Show("Thông tin khách hàng hoặc nhân viên không hợp lệ.");
                    return;
                }

                // Tiến hành thêm hóa đơn vào cơ sở dữ liệu
                bool isHoaDonAdded = _hoaDonBLL.ThemHoaDon(hoaDon);
                if (!isHoaDonAdded)
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu hóa đơn.");
                    return;
                }

                // Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string maCTHDBH = taoCTHD();
                        var chiTietHoaDon = new ChiTietHoaDon
                        {
                            MaHoaDon = hoaDon.MaHoaDon, // Chỉnh lại tên trường mã hóa đơn
                            MaSanPham = row.Cells["MaSP"].Value.ToString(),
                            SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                            DonGia = Convert.ToDecimal(row.Cells["Gia"].Value),
                            ThanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value),
                        };

                        Console.WriteLine($"Adding ChiTietHoaDon: {chiTietHoaDon.MaSanPham}, Quantity: {chiTietHoaDon.SoLuong}, TotalPrice: {chiTietHoaDon.ThanhTien}");
                        _chiTietHoaDonBLL.ThemChiTietHoaDon(chiTietHoaDon);
                    }
                }

                MessageBox.Show("Hóa đơn đã được lưu thành công!");
                dgvCart.Rows.Clear();
                clearAll();
                _MaHoaDon = hoaDon.MaHoaDon;
                btn_inHoaDon.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Có lỗi xảy ra khi lưu hóa đơn: {ex.Message}");
            }
        }

        private void Btn_timKhachHang_Click(object sender, EventArgs e)
        {
            string maKhachHang = txt_maKhachHang.Text;
            string tenKhachHang = txt_tenKhachHang.Text;
            string sdt = txt_soDienThoai.Text;
            if (string.IsNullOrEmpty(maKhachHang) && string.IsNullOrEmpty(tenKhachHang) && string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một trong các thông tin: Mã khách hàng, Tên khách hàng hoặc Số điện thoại.");
                return;
            }
            KhachHang kh = _khachHangBLL.LayKhachHangTheoDieuKien(maKhachHang, tenKhachHang, sdt);

            if (kh != null)
            {
                txt_maKhachHang.Text = kh.MaKhachHang;
                txt_tenKhachHang.Text = kh.TenKhachHang;
                txt_soDienThoai.Text = kh.SoDienThoai;
                txt_diaChi.Text = kh.DiaChi;
                cbo_gioiTinh.SelectedItem = kh.GioiTinh;
                if (kh.DiemTichLuy.HasValue)
                {
                    txt_diemTichLuy.Text = kh.DiemTichLuy.Value.ToString("0.##");
                }
                else
                {
                    txt_diemTichLuy.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
            }
        }

        private void DgvCart_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow != null && dgvCart.CurrentRow.Cells["SoLuong"].Value != null)
            {
                txt_SL.Value = Convert.ToInt16(dgvCart.CurrentRow.Cells["SoLuong"].Value);
            }
        }

        private void Btn_suaSL_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu có dòng được chọn trong DataGridView
                if (dgvCart.CurrentRow != null)
                {
                    // Lấy số lượng mới từ txt_SL
                    int soLuongMoi = (int)txt_SL.Value;

                    // Lấy mã sản phẩm và giá bán từ DataGridView
                    string maSanPham = dgvCart.CurrentRow.Cells["MaSP"].Value?.ToString();
                    if (string.IsNullOrEmpty(maSanPham))
                    {
                        MessageBox.Show("Mã sản phẩm không hợp lệ.");
                        return;
                    }

                    // Kiểm tra giá bán hợp lệ
                    if (dgvCart.CurrentRow.Cells["Gia"].Value == null ||
                        !decimal.TryParse(dgvCart.CurrentRow.Cells["Gia"].Value.ToString(), out decimal giaBan))
                    {
                        MessageBox.Show("Giá bán không hợp lệ.");
                        return;
                    }

                    // Cập nhật lại số lượng trong DataGridView
                    dgvCart.CurrentRow.Cells["SoLuong"].Value = soLuongMoi;

                    // Tính lại ThanhTien
                    decimal thanhTienMoi = giaBan * soLuongMoi;
                    dgvCart.CurrentRow.Cells["ThanhTien"].Value = thanhTienMoi;

                    // Cập nhật tổng số lượng và tổng tiền (nếu có)
                    txt_tongTien.Text = CalculateTotalAmount().ToString("N0");
                    txt_TongSL.Text = CalculateTotalProducts().ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm trong giỏ hàng.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            clearAll();
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
                string tenSanPham = string.Empty;
                // Cập nhật lại trang hiện tại về 1 khi thay đổi loại sản phẩm
                currentPage = 1;
                List<SanPham> pagedSanPhamList = _sanPhamBLL.GetSanPhamsPaged(currentPage, pageSize,maloai,maThuongHieu,tenSanPham, out totalRecords);
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
                string tenSanPham=string.Empty;
                string maThuongHieu = cbo_thuongHieu.SelectedValue.ToString();
                if (string.IsNullOrEmpty(maThuongHieu))
                {
                    Console.WriteLine("Vui lòng chọn thương hiệu");
                    return;
                }
                // Cập nhật lại trang hiện tại về 1 khi thay đổi loại sản phẩm
                currentPage = 1;
                List<SanPham> pagedSanPhamList = _sanPhamBLL.GetSanPhamsPaged(currentPage, pageSize, maloai, maThuongHieu,tenSanPham, out totalRecords);
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
        private void DgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào cột Xóa (cột có tên là "Xoa")
            if (e.ColumnIndex == dgvCart.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                // Xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Xóa sản phẩm tại dòng hiện tại
                    dgvCart.Rows.RemoveAt(e.RowIndex);
                }
                string tongTien = CalculateTotalAmount().ToString();
                txt_tongTien.Text = tongTien;
                txt_TongSL.Text = CalculateTotalProducts().ToString();
            }
        }
        private void dgvCart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["SoLuong"].Index) // Kiểm tra nếu người dùng đang chỉnh sửa cột "Số Lượng"
            {
                string inputValue = dgvCart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!int.TryParse(inputValue, out int soLuong) || soLuong < 1 || soLuong > 100)
                {
                    e.Cancel = true;
                }
                string tongTien = CalculateTotalAmount().ToString();
                txt_tongTien.Text = tongTien;
                txt_TongSL.Text = CalculateTotalProducts().ToString();
            }
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["SoLuong"].Index)
            {
                // Lấy số lượng và giá bán
                var row = dgvCart.Rows[e.RowIndex];
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal giaBan = Convert.ToDecimal(row.Cells["Gia"].Value);

                decimal thanhTien = giaBan * soLuong;
                row.Cells["ThanhTien"].Value = thanhTien;
            }

            txt_tongTien.Text = CalculateTotalAmount().ToString("N0");
            txt_TongSL.Text = CalculateTotalProducts().ToString();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào cột Xóa (cột có tên là "Xoa")
            if (e.ColumnIndex == dgvCart.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                // Xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Xóa sản phẩm tại dòng hiện tại
                    dgvCart.Rows.RemoveAt(e.RowIndex);
                }
                string tongTien = CalculateTotalAmount().ToString();
                txt_tongTien.Text = tongTien;
                txt_TongSL.Text = CalculateTotalProducts().ToString();
            }
        }
        //hàm
        //load combobox khachHang
        private void LoadComboBoxKhachHang()
        {
            cbo_khachHang.Items.Add("Khách hàng thành viên");
            cbo_khachHang.Items.Add("Khách đăng kí thành viên mới");
            cbo_khachHang.Items.Add("Khách hàng vãng lai");
            cbo_khachHang.SelectedIndex = 0;
        }
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
                        string maHoaDon = _MaHoaDon;
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
        private void LoadComboBoxGioiTinh()
        {
            var gioiTinh = new List<string>
            {
                "Nam",
                "Nữ"
            };
            // Nạp danh sách vào ComboBox
            cbo_gioiTinh.DataSource = gioiTinh;
        }
        private void LoadComboBoxThanhToan()
        {
            // Danh sách các phương thức thanh toán
            var phuongThucThanhToan = new List<string>
            {
                "Tiền mặt",
                "Thẻ tín dụng",
                "Chuyển khoản"
            };
            // Nạp danh sách vào ComboBox
            cbo_phuongThucTT.DataSource = phuongThucThanhToan;
        }

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
                    //MessageBox.Show("Mã sản phẩm không hợp lệ. Vui lòng kiểm tra lại thông tin sản phẩm.");
                    return;
                }
                decimal? giaSanPham = _sanPhamBLL.layGiaBanTheoMaSanPham(maSanPham);
                int soLuongTon = _sanPhamBLL.LaySanPhamTheoMaSanPham(maSanPham).SoLuong ?? 0;
                if (giaSanPham.HasValue)
                {
                    txt_giaBan.Text = giaSanPham.Value.ToString("N0"); // "N0" sẽ định dạng giá theo kiểu số, không có phần thập phân
                }
                else
                {
                    txt_giaBan.Text = "Giá không có sẵn"; // Nếu không tìm thấy giá, hiển thị thông báo
                }
                txt_soLuongTon.Text = soLuongTon.ToString();

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
            txt_SL.Value = 1;
            chkSuDungDiemTichLuy.Checked = false;
            cbo_phuongThucTT.SelectedIndex = 0;
            cbo_gioiTinh.SelectedIndex = 0;
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
            // chỉnh chiều cao của hàng
            dgvCart.RowTemplate.Height = 40;
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
            string tenSanPham = string.Empty;
            List<SanPham> pagedSanPhamList = _sanPhamBLL.GetSanPhamsPaged(currentPage, pageSize,maloai,maThuongHieu,tenSanPham, out totalRecords);
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
