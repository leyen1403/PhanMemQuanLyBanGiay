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

namespace GUI
{
    public partial class frm_quanLyChungLoai : Form
    {
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();
        MauSacBLL _mauSacBLL = new MauSacBLL();
        KichThuocBLL _kichThuocBLL = new KichThuocBLL();
        ThuongHieuBLL _thuongHieuBLL = new ThuongHieuBLL();
        List<LoaiSanPham> _lstLoaiSanPham = null; 
        List<MauSac> _lstMauSac = null;
        List<KichThuoc> _lstKichThuoc = null;
        List<ThuongHieu> _lstThuongHieu = null;
        public frm_quanLyChungLoai()
        {
            InitializeComponent();
            this.Load += frm_quanLyChungLoai_Load;
        }

        private void frm_quanLyChungLoai_Load(object sender, EventArgs e)
        {
            _lstLoaiSanPham = new List<LoaiSanPham>();
            _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
            LoadData(_lstLoaiSanPham);
            LoadDataMauSac();
            LoadDataKichThuoc();
            LoadDataThuongHieu();
            this.dgv_dsLoaiSanPham.SelectionChanged += Dgv_dsLoaiSanPham_SelectionChanged;
            this.btn_timKiem.Click += Btn_timKiem_Click;
            this.btn_themLoaiSanPham.Click += Btn_themLoaiSanPham_Click;
            this.btn_xoaLoaiSanPham.Click += Btn_xoaLoaiSanPham_Click;
            this.btn_suaLoaiSanPham.Click += Btn_suaLoaiSanPham_Click;
            this.btn_clear.Click += Btn_clear_Click;
            this.btn_khoiPhuc.Click += Btn_khoiPhuc_Click;
            this.dgv_dsMauSac.SelectionChanged += Dgv_dsMauSac_SelectionChanged;
            this.btn_themMauSac.Click += Btn_themMauSac_Click;
            this.btn_xoaMauSac.Click += Btn_xoaMauSac_Click;
            this.btn_suaMauSac.Click += Btn_suaMauSac_Click;
            this.btn_khoiPhucMS.Click += Btn_khoiPhucMS_Click;
            this.btn_clearMS.Click += Btn_clearMS_Click;
            this.dgv_dsKichThuoc.SelectionChanged += Dgv_dsKichThuoc_SelectionChanged;
            this.btn_themKichThuoc.Click += Btn_themKichThuoc_Click;
            this.btn_xoaKichThuoc.Click += Btn_xoaKichThuoc_Click;
            this.btn_khoiPhucKT.Click += Btn_khoiPhucKT_Click;
            this.btn_suaKichThuoc.Click += Btn_suaKichThuoc_Click;
            this.btn_clearKT.Click += Btn_clearKT_Click;
            this.dgv_thuongHieu.SelectionChanged += Dgv_thuongHieu_SelectionChanged;
            this.btn_timThuongHieu.Click += Btn_timThuongHieu_Click;
            this.btn_themThuongHieu.Click += Btn_themThuongHieu_Click;
            this.btn_xoaThuongHieu.Click += Btn_xoaThuongHieu_Click;
            this.btn_khoiPhucThuongHieu.Click += Btn_khoiPhucThuongHieu_Click;
            this.btn_suaThuongHieu.Click += Btn_suaThuongHieu_Click;
            this.btn_clearTH.Click += Btn_clearTH_Click;
            this.btn_load.Click += Btn_load_Click;
        }

        private void Btn_load_Click(object sender, EventArgs e)
        {
            _lstLoaiSanPham = new List<LoaiSanPham>();
            _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
            LoadData(_lstLoaiSanPham);
            LoadDataMauSac();
            LoadDataKichThuoc();
            LoadDataThuongHieu();
        }

        private void Btn_clearTH_Click(object sender, EventArgs e)
        {
            //xoá hết textbox
            txt_maThuongHieu.Text = "";
            txt_tenThuongHieu.Text = "";
            txt_moTaThuongHieu.Text = "";
            txt_trangThaiTH.Text = "";
            txt_ngayTaoTH.Text = "";
            txt_ngayCapNhatThuongHieu.Text = "";
            txt_tenThuongHieu.Focus();
        }

        private void Btn_suaThuongHieu_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maThuongHieu = txt_maThuongHieu.Text;
            if (string.IsNullOrEmpty(maThuongHieu))
            {
                MessageBox.Show("Chọn thương hiệu cần sửa");
                return;
            }
            //kiểm tra thương hiệu có tồn tại không
            ThuongHieu thuongHieu = _thuongHieuBLL.TimKiemTheoMaThuongHieu(maThuongHieu);
            if (thuongHieu == null)
            {
                MessageBox.Show("Thương hiệu không tồn tại");
                return;
            }
            //kiểm tra tên thương hiệu có trùng không
            string tenThuongHieu = txt_tenThuongHieu.Text;
            if (string.IsNullOrEmpty(tenThuongHieu))
            {
                MessageBox.Show("Tên thương hiệu không được để trống");
                return;
            }
            ThuongHieu thuongHieu1 = _thuongHieuBLL.TimKiemTheoTenThuongHieu(tenThuongHieu);
            if (thuongHieu1 != null && thuongHieu1.MaThuongHieu != maThuongHieu)
            {
                MessageBox.Show("Tên thương hiệu đã tồn tại");
                return;
            }
            //sửa thương hiệu
            string moTa = txt_moTaThuongHieu.Text;
            thuongHieu.TenThuongHieu = tenThuongHieu;
            thuongHieu.MoTa = moTa;
            thuongHieu.NgayCapNhat = DateTime.Now;
            bool kq = _thuongHieuBLL.SuaThuongHieu(thuongHieu);
            if (kq)
            {
                MessageBox.Show("Sửa thương hiệu thành công");
                LoadDataThuongHieu();
            }
            else
            {
                MessageBox.Show("Sửa thương hiệu thất bại");
            }
        }

        private void Btn_khoiPhucThuongHieu_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maThuongHieu = txt_maThuongHieu.Text;
            if (string.IsNullOrEmpty(maThuongHieu))
            {
                MessageBox.Show("Chọn thương hiệu cần khôi phục");
                return;
            }
            //kiểm tra thương hiệu có tồn tại không
            ThuongHieu thuongHieu = _thuongHieuBLL.TimKiemTheoMaThuongHieu(maThuongHieu);
            if (thuongHieu == null)
            {
                MessageBox.Show("Thương hiệu không tồn tại");
                return;
            }
            //khôi phục thương hiệu
            bool kq = _thuongHieuBLL.XoaThuongHieu(maThuongHieu, true);
            if (kq)
            {
                MessageBox.Show("Khôi phục thương hiệu thành công");
                LoadDataThuongHieu();
            }
            else
            {
                MessageBox.Show("Khôi phục thương hiệu thất bại");
            }
        }

        private void Btn_xoaThuongHieu_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maThuongHieu = txt_maThuongHieu.Text;
            if (string.IsNullOrEmpty(maThuongHieu))
            {
                MessageBox.Show("Chọn thương hiệu cần xóa");
                return;
            }
            //kiểm tra thương hiệu có tồn tại không
            ThuongHieu thuongHieu = _thuongHieuBLL.TimKiemTheoMaThuongHieu(maThuongHieu);
            if (thuongHieu == null)
            {
                MessageBox.Show("Thương hiệu không tồn tại");
                return;
            }
            //xóa thương hiệu
            bool kq = _thuongHieuBLL.XoaThuongHieu(maThuongHieu, false);
            if (kq)
            {
                MessageBox.Show("Xóa thương hiệu thành công");
                LoadDataThuongHieu();
            }
            else
            {
                MessageBox.Show("Xóa thương hiệu thất bại");
            }

        }

        private void Btn_themThuongHieu_Click(object sender, EventArgs e)
        {
            //kiểm tra điều kiện
            string tenThuongHieu = txt_tenThuongHieu.Text;
            if (string.IsNullOrEmpty(tenThuongHieu))
            {
                MessageBox.Show("Tên thương hiệu không được để trống");
                return;
            }
            //kiểm tra thương hiệu có trùng không
            ThuongHieu thuongHieu = _thuongHieuBLL.TimKiemTheoTenThuongHieu(tenThuongHieu);
            if (thuongHieu != null)
            {
                MessageBox.Show("Tên thương hiệu đã tồn tại");
                return;
            }
            //tạo mã thương hiệu tự động
            string maThuongHieu = taoMaThuongHieuTuDong();
            string moTa = txt_moTaThuongHieu.Text;
            //thêm thương hiệu
            ThuongHieu thuongHieu1 = new ThuongHieu();
            thuongHieu1.MaThuongHieu = maThuongHieu;
            thuongHieu1.TenThuongHieu = tenThuongHieu;
            thuongHieu1.MoTa = moTa;
            thuongHieu1.TrangThaiHoatDong = true;
            thuongHieu1.NgayTao = DateTime.Now;
            thuongHieu1.NgayCapNhat = DateTime.Now;
            bool kq = _thuongHieuBLL.ThemThuongHieu(thuongHieu1);
            if (kq)
            {
                MessageBox.Show("Thêm thương hiệu thành công");
                LoadDataThuongHieu();
            }
            else
            {
                MessageBox.Show("Thêm thương hiệu thất bại");
            }
        }

        private void Btn_timThuongHieu_Click(object sender, EventArgs e)
        {
            //tìm kiếm thương hiệu theo tên
            string tenThuongHieu = txt_timKiemThuongHieu.Text;
            if (string.IsNullOrEmpty(tenThuongHieu))
            {
                MessageBox.Show("Nhập tên thương hiệu cần tìm");
                return;
            }
            // hiển thị lên datagridview
            _lstThuongHieu = new List<ThuongHieu>();
            _lstThuongHieu = _thuongHieuBLL.TimTheoDieuKien(tenThuongHieu);
            if (_lstThuongHieu == null || _lstThuongHieu.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            dgv_thuongHieu.DataSource = _lstThuongHieu;
            //đặt tiêu đề cho các cột
            dgv_thuongHieu.Columns["MaThuongHieu"].HeaderText = "Mã thương hiệu";
            dgv_thuongHieu.Columns["TenThuongHieu"].HeaderText = "Tên thương hiệu";
            dgv_thuongHieu.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_thuongHieu.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái";
            dgv_thuongHieu.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgv_thuongHieu.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgv_thuongHieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_thuongHieu.CellFormatting -= dgv_thuongHieu_CellFormatting;
            dgv_thuongHieu.CellFormatting += dgv_thuongHieu_CellFormatting;


        }

        private void Dgv_thuongHieu_SelectionChanged(object sender, EventArgs e)
        {
            //hiển thị dữ liệu lên textbox
            if (dgv_thuongHieu.CurrentRow != null)
            {
                DataGridViewRow row = dgv_thuongHieu.CurrentRow;
                txt_maThuongHieu.Text = row.Cells["MaThuongHieu"].Value?.ToString();
                txt_tenThuongHieu.Text = row.Cells["TenThuongHieu"].Value?.ToString();
                txt_moTaThuongHieu.Text = row.Cells["MoTa"].Value?.ToString();
                var trangThai = row.Cells["TrangThaiHoatDong"].Value?.ToString();
                txt_trangThaiTH.Text = trangThai == "True" ? "Hoạt động" : "Không hoạt động";
                txt_ngayTaoTH.Text = row.Cells["NgayTao"].Value?.ToString();
                txt_ngayCapNhatThuongHieu.Text = row.Cells["NgayCapNhat"].Value?.ToString();
            }
        }

        private void Btn_clearKT_Click(object sender, EventArgs e)
        {
            //xoá hết textbox
            txt_maKichThuoc.Text = "";
            txt_tenKichThuoc.Text = "";
            txt_moTaKichThuoc.Text = "";
            txt_trangThaiKT.Text = "";
            txt_ngayTaoKT.Text = "";
            txt_ngayCapNhatKT.Text = "";
            txt_tenKichThuoc.Focus();
        }

        private void Btn_suaKichThuoc_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maKichThuoc = txt_maKichThuoc.Text;
            if(string.IsNullOrEmpty(maKichThuoc))
            {
                MessageBox.Show("Chọn kích thước cần sửa");
                return;
            }
            //kiểm tra kích thước có tồn tại không
            KichThuoc kichThuoc = _kichThuocBLL.TimKiemTheoMaKichThuoc(maKichThuoc);
            if (kichThuoc == null)
            {
                MessageBox.Show("Kích thước không tồn tại");
                return;
            }
            //kiểm tra tên kích thước có trùng không
            string tenKichThuoc = txt_tenKichThuoc.Text;
            if (string.IsNullOrEmpty(tenKichThuoc))
            {
                MessageBox.Show("Tên kích thước không được để trống");
                return;
            }
            KichThuoc kichThuoc1 = _kichThuocBLL.TimKiemTheoTenKichThuoc(tenKichThuoc);
            if (kichThuoc1 != null && kichThuoc1.MaKichThuoc != maKichThuoc)
            {
                MessageBox.Show("Tên kích thước đã tồn tại");
                return;
            }
            //sửa kích thước
            string moTa = txt_moTaKichThuoc.Text;
            kichThuoc.TenKichThuoc = tenKichThuoc;
            kichThuoc.MoTa = moTa;
            kichThuoc.NgayCapNhat = DateTime.Now;
            bool kq = _kichThuocBLL.SuaKichThuoc(kichThuoc);
            if (kq)
            {
                MessageBox.Show("Sửa kích thước thành công");
                _lstKichThuoc = new List<KichThuoc>();
                _lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
                LoadDataKichThuoc();
            }
            else
            {
                MessageBox.Show("Sửa kích thước thất bại");
            }
        }

        private void Btn_khoiPhucKT_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maKichThuoc = txt_maKichThuoc.Text;
            if (string.IsNullOrEmpty(maKichThuoc))
            {
                MessageBox.Show("Chọn kích thước cần khôi phục");
                return;
            }
            //kiểm tra kích thước có tồn tại không
            KichThuoc kichThuoc = _kichThuocBLL.TimKiemTheoMaKichThuoc(maKichThuoc);
            if (kichThuoc == null)
            {
                MessageBox.Show("Kích thước không tồn tại");
                return;
            }
            //khôi phục kích thước
            bool kq = _kichThuocBLL.XoaKichThuoc(maKichThuoc, true);
            if (kq)
            {
                MessageBox.Show("Khôi phục kích thước thành công");
                _lstKichThuoc = new List<KichThuoc>();
                _lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
                LoadDataKichThuoc();
            }
            else
            {
                MessageBox.Show("Khôi phục kích thước thất bại");
            }
        }

        private void Btn_xoaKichThuoc_Click(object sender, EventArgs e)
        {
           //kiểm tra dữ liệu nhập vào 
           string maKichThuoc = txt_maKichThuoc.Text;
            if (string.IsNullOrEmpty(maKichThuoc))
            {
                MessageBox.Show("Chọn kích thước cần xóa");
                return;
            }
            //kiểm tra kích thước có tồn tại không
            KichThuoc kichThuoc = _kichThuocBLL.TimKiemTheoMaKichThuoc(maKichThuoc);
            if (kichThuoc == null)
            {
                MessageBox.Show("Kích thước không tồn tại");
                return;
            }
            //xóa kích thước
            bool kq = _kichThuocBLL.XoaKichThuoc(maKichThuoc, false);
            if (kq)
            {
                MessageBox.Show("Xóa kích thước thành công");
                _lstKichThuoc = new List<KichThuoc>();
                _lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
                LoadDataKichThuoc();
            }
            else
            {
                MessageBox.Show("Xóa kích thước thất bại");
            }
        }

        private void Btn_themKichThuoc_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string tenKichThuoc = txt_tenKichThuoc.Text;
            if (string.IsNullOrEmpty(tenKichThuoc))
            {
                MessageBox.Show("Tên kích thước không được để trống");
                return;
            }
            //kiểm tra kích thước có trùng không
            KichThuoc kichThuoc = _kichThuocBLL.TimKiemTheoTenKichThuoc(tenKichThuoc);
            if (kichThuoc != null)
            {
                MessageBox.Show("Tên kích thước đã tồn tại");
                return;
            }
            //tạo mã kích thước tự động
            string maKichThuoc = taoMaKichThuocTuDong();
            string moTa = txt_moTaKichThuoc.Text;
            //thêm kích thước
            KichThuoc kichThuoc1 = new KichThuoc();
            kichThuoc1.MaKichThuoc = maKichThuoc;
            kichThuoc1.TenKichThuoc = tenKichThuoc;
            kichThuoc1.MoTa = moTa;
            kichThuoc1.TrangThaiHoatDong = true;
            kichThuoc1.NgayTao = DateTime.Now;
            kichThuoc1.NgayCapNhat = DateTime.Now;
            bool kq = _kichThuocBLL.ThemKichThuoc(kichThuoc1);
            if (kq)
            {
                MessageBox.Show("Thêm kích thước thành công");
                _lstKichThuoc = new List<KichThuoc>();
                _lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
                LoadDataKichThuoc();
            }
            else
            {
                MessageBox.Show("Thêm kích thước thất bại");
            }
        }

        private void Dgv_dsKichThuoc_SelectionChanged(object sender, EventArgs e)
        {
            //hiển thị dữ liệu lên textbox
            if (dgv_dsKichThuoc.CurrentRow != null)
            {
                DataGridViewRow row = dgv_dsKichThuoc.CurrentRow;
                txt_maKichThuoc.Text = row.Cells["MaKichThuoc"].Value?.ToString();
                txt_tenKichThuoc.Text = row.Cells["TenKichThuoc"].Value?.ToString();
                txt_moTaKichThuoc.Text = row.Cells["MoTa"].Value?.ToString();
                var trangThai = row.Cells["TrangThaiHoatDong"].Value?.ToString();
                txt_trangThaiKT.Text = trangThai == "True" ? "Hoạt động" : "Không hoạt động";
                txt_ngayTaoKT.Text = row.Cells["NgayTao"].Value?.ToString();
                txt_ngayCapNhatKT.Text = row.Cells["NgayCapNhat"].Value?.ToString();
            }
        }

        private void Btn_clearMS_Click(object sender, EventArgs e)
        {
            //xoá hết textbox
            txt_maMauSac.Text = "";
            txt_tenMauSac.Text = "";
            txt_moTaMauSac.Text = "";
            txt_trangThaiMauSac.Text = "";
            txt_ngayTaoMS.Text = "";
            txt_ngayCapNhatMS.Text = "";
            txt_tenMauSac.Focus();
        }

        private void Btn_khoiPhucMS_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maMau = txt_maMauSac.Text;
            if (string.IsNullOrEmpty(maMau) )
            {
                MessageBox.Show("Chọn màu sắc cần khôi phục");
                return;
            }
            //kiểm tra màu sắc có tồn tại không
            MauSac mauSac = _mauSacBLL.layMauSacTheoMa(maMau);
            if (mauSac == null)
            {
                MessageBox.Show("Màu sắc không tồn tại");
                return;
            }
            //khôi phục màu sắc
            bool kq = _mauSacBLL.xoaMauSac(maMau, true);
            if (kq)
            {
                MessageBox.Show("Khôi phục màu sắc thành công");
                _lstMauSac = new List<MauSac>();
                _lstMauSac = _mauSacBLL.layTatCaMauSac();
                LoadDataMauSac();
            }
            else
            {
                MessageBox.Show("Khôi phục màu sắc thất bại");
            }
        }

        private void Btn_xoaMauSac_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maMau = txt_maMauSac.Text;
            if (string.IsNullOrEmpty(maMau))
            {
                MessageBox.Show("Chọn màu sắc cần xóa");
                return;
            }
            //kiểm tra màu sắc có tồn tại không
            MauSac mauSac = _mauSacBLL.layMauSacTheoMa(maMau);
            if (mauSac == null)
            {
                MessageBox.Show("Màu sắc không tồn tại");
                return;
            }
            //xóa màu sắc
            bool kq = _mauSacBLL.xoaMauSac(maMau, false);
            if (kq)
            {
                MessageBox.Show("Xóa màu sắc thành công");
                _lstMauSac = new List<MauSac>();
                _lstMauSac = _mauSacBLL.layTatCaMauSac();
                LoadDataMauSac();
            }
            else
            {
                MessageBox.Show("Xóa màu sắc thất bại");
            }
        }

        private void Btn_suaMauSac_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maMau = txt_maMauSac.Text;
            if (string.IsNullOrEmpty(maMau))
            {
                MessageBox.Show("Chọn màu sắc cần sửa");
                return;
            }
            //kiểm tra màu sắc có tồn tại không
            MauSac mauSac = _mauSacBLL.layMauSacTheoMa(maMau);
            if (mauSac == null)
            {
                MessageBox.Show("Màu sắc không tồn tại");
                return;
            }
            //kiểm tra tên màu sắc có trùng không
            string tenMau = txt_tenMauSac.Text;
            if (string.IsNullOrEmpty(tenMau))
            {
                MessageBox.Show("Tên màu không được để trống");
                return;
            }
            MauSac mauSac1 = _mauSacBLL.layMauSacTheoTen(tenMau);
            if (mauSac1 != null && mauSac1.MaMauSac != maMau)
            {
                MessageBox.Show("Tên màu đã tồn tại");
                return;
            }
            //sửa màu sắc
            string moTa = txt_moTaMauSac.Text;
            mauSac.TenMauSac = tenMau;
            mauSac.MoTa = moTa;
            mauSac.NgayCapNhat = DateTime.Now;
            bool kq = _mauSacBLL.suaMauSac(mauSac);
            if (kq)
            {
                MessageBox.Show("Sửa màu sắc thành công");
                _lstMauSac = new List<MauSac>();
                _lstMauSac = _mauSacBLL.layTatCaMauSac();
                LoadDataMauSac();
            }
            else
            {
                MessageBox.Show("Sửa màu sắc thất bại");
            }
        }

        private void Dgv_dsMauSac_SelectionChanged(object sender, EventArgs e)
        {
            //hiển thị dữ liệu lên textbox
            if (dgv_dsMauSac.CurrentRow != null)
            {
                DataGridViewRow row = dgv_dsMauSac.CurrentRow;
                txt_maMauSac.Text = row.Cells["MaMauSac"].Value?.ToString();
                txt_tenMauSac.Text = row.Cells["TenMauSac"].Value?.ToString();
                txt_moTaMauSac.Text = row.Cells["MoTa"].Value?.ToString();
                var trangThai = row.Cells["TrangThaiHoatDong"].Value?.ToString();
                txt_trangThaiMauSac.Text = trangThai == "True" ? "Hoạt động" : "Không hoạt động";
                txt_ngayTaoMS.Text = row.Cells["NgayTao"].Value?.ToString();
                txt_ngayCapNhatMS.Text = row.Cells["NgayCapNhat"].Value?.ToString();
            }
        }

        private void Btn_themMauSac_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string tenMau = txt_tenMauSac.Text;
            if (string.IsNullOrEmpty(tenMau))
            {
                MessageBox.Show("Tên màu không được để trống");
                return;
            }
            //kiểm tra màu sắc có trùng không
            MauSac mauSac = _mauSacBLL.layMauSacTheoTen(tenMau);
            if (mauSac != null)
            {
                MessageBox.Show("Tên màu đã tồn tại");
                return;
            }
            //tạo mã màu tự động
            string maMau = taoMaMauSacTuDong();
            string moTa = txt_moTaMauSac.Text;
            //thêm màu sắc
            MauSac mauSac1 = new MauSac();
            mauSac1.MaMauSac = maMau;
            mauSac1.TenMauSac = tenMau;
            mauSac1.MoTa = moTa;
            mauSac1.TrangThaiHoatDong = true;
            mauSac1.NgayTao = DateTime.Now;
            mauSac1.NgayCapNhat = DateTime.Now;
            bool kq = _mauSacBLL.themMauSac(mauSac1);
            if (kq)
            {
                MessageBox.Show("Thêm màu sắc thành công");
                _lstMauSac = new List<MauSac>();
                _lstMauSac = _mauSacBLL.layTatCaMauSac();
                LoadDataMauSac();
            }
            else
            {
                MessageBox.Show("Thêm màu sắc thất bại");
            }
        }

        private void Btn_khoiPhuc_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maLoai = txt_maLoai.Text;
            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Chọn loại sản phẩm cần khôi phục");
                return;
            }
            //kiểm tra loại sản phẩm có tồn tại không
            LoaiSanPham loaiSanPham = _loaiSanPhamBLL.layLoaiSanPhamTheoMa(maLoai);
            if (loaiSanPham == null)
            {
                MessageBox.Show("Loại sản phẩm không tồn tại");
                return;
            }
            //xóa loại sản phẩm
            bool kq = _loaiSanPhamBLL.xoaLoaiSanPham(maLoai,true);
            if (kq)
            {
                MessageBox.Show("khôi phục loại sản phẩm thành công");
                _lstLoaiSanPham = new List<LoaiSanPham>();
                _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
                LoadData(_lstLoaiSanPham);
            }
            else
            {
                MessageBox.Show("phoi phục loại sản phẩm thất bại");
            }
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            //xoá dữ liệu trên textbox
            txt_maLoai.Text = "";
            txt_tenLoai.Text = "";
            txt_moTa.Text = "";
            txt_trangThai.Text = "";
            txt_ngayTao.Text = "";
            txt_ngayCapNhat.Text = "";
            txt_tenLoai.Focus();
        }

        private void Btn_suaLoaiSanPham_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu đầu vào
            string maLoai = txt_maLoai.Text;
            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Chọn loại sản phẩm cần sửa");
                return;
            }
            //kiểm tra loại sản phẩm có tồn tại không
            LoaiSanPham loaiSanPham = _loaiSanPhamBLL.layLoaiSanPhamTheoMa(maLoai);
            if (loaiSanPham == null)
            {
                MessageBox.Show("Loại sản phẩm không tồn tại");
                return;
            }
            //kiểm tra tên loại sản phẩm có trùng không
            string tenLoai = txt_tenLoai.Text;
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Tên loại không được để trống");
                return;
            }
            LoaiSanPham loaiSanPham1 = _loaiSanPhamBLL.layLoaiSanPhamTheoTen(tenLoai);
            if (loaiSanPham1 != null && loaiSanPham1.MaLoaiSanPham != maLoai)
            {
                MessageBox.Show("Tên loại đã tồn tại");
                return;
            }
            //sửa loại sản phẩm
            string moTa = txt_moTa.Text;
            loaiSanPham.TenLoaiSanPham = tenLoai;
            loaiSanPham.MoTa = moTa;
            loaiSanPham.NgayCapNhat = DateTime.Now;
            bool kq = _loaiSanPhamBLL.suaLoaiSanPham(loaiSanPham);
            if (kq)
            {
                MessageBox.Show("Sửa loại sản phẩm thành công");
                _lstLoaiSanPham = new List<LoaiSanPham>();
                _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
                LoadData(_lstLoaiSanPham);
            }
            else
            {
                MessageBox.Show("Sửa loại sản phẩm thất bại");
            }

        }

        private void Btn_xoaLoaiSanPham_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string maLoai = txt_maLoai.Text;
            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Chọn loại sản phẩm cần xóa");
                return;
            }
            //kiểm tra loại sản phẩm có tồn tại không
            LoaiSanPham loaiSanPham = _loaiSanPhamBLL.layLoaiSanPhamTheoMa(maLoai);
            if (loaiSanPham == null)
            {
                MessageBox.Show("Loại sản phẩm không tồn tại");
                return;
            }
            //xóa loại sản phẩm
            bool kq = _loaiSanPhamBLL.xoaLoaiSanPham(maLoai,false);
            if (kq)
            {
                MessageBox.Show("Xóa loại sản phẩm thành công");
                _lstLoaiSanPham = new List<LoaiSanPham>();
                _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
                LoadData(_lstLoaiSanPham);
            }
            else
            {
                MessageBox.Show("Xóa loại sản phẩm thất bại");
            }
        }

        private void Btn_themLoaiSanPham_Click(object sender, EventArgs e)
        {
            //kiểm tra dữ liệu nhập vào
            string tenLoai = txt_tenLoai.Text;
            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Tên loại không được để trống");
                return;
            }
            //kiểm tra trùng tên loại
            LoaiSanPham loaiSanPham1 = _loaiSanPhamBLL.layLoaiSanPhamTheoTen(tenLoai);
            if (loaiSanPham1 != null)
            {
                MessageBox.Show("Tên loại đã tồn tại");
                return;
            }
            //tạo mã loại tự động
            string maLoai = taoMaLoaiTuDong();
            string moTa = txt_moTa.Text;
            //thêm loại sản phẩm
            LoaiSanPham loaiSanPham = new LoaiSanPham();
            loaiSanPham.MaLoaiSanPham =maLoai;
            loaiSanPham.TenLoaiSanPham = tenLoai;
            loaiSanPham.MoTa = moTa;
            loaiSanPham.TrangThaiHoatDong =true;
            loaiSanPham.NgayTao = DateTime.Now;
            loaiSanPham.NgayCapNhat = DateTime.Now;
            bool kq = _loaiSanPhamBLL.themLoaiSanPham(loaiSanPham);
            if (kq)
            {
                MessageBox.Show("Thêm loại sản phẩm thành công");
                _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
                LoadData(_lstLoaiSanPham);
            }
            else
            {
                MessageBox.Show("Thêm loại sản phẩm thất bại");
            }
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            //viết phương thức tìm kiếm theo nhiều điều kiện
            string dieuKien = txt_timKiem.Text;
            _lstLoaiSanPham = _loaiSanPhamBLL.layLoaiSanPhamTheoDieuKien(dieuKien);
            if (_lstLoaiSanPham == null || _lstLoaiSanPham.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            LoadData(_lstLoaiSanPham);
        }

        private void Dgv_dsLoaiSanPham_SelectionChanged(object sender, EventArgs e)
        {
            //chọn vào 1 dòng hiển thị lên textbox
            if (dgv_dsLoaiSanPham.CurrentRow != null)
            {
                DataGridViewRow row = dgv_dsLoaiSanPham.CurrentRow;
                txt_maLoai.Text = row.Cells["MaLoaiSanPham"].Value?.ToString();
                txt_tenLoai.Text = row.Cells["TenLoaiSanPham"].Value?.ToString();
                txt_moTa.Text = row.Cells["MoTa"].Value?.ToString();
                var trangThai = row.Cells["TrangThaiHoatDong"].Value?.ToString();
                txt_trangThai.Text = trangThai == "True" ? "Hoạt động" : "Không hoạt động";
                txt_ngayTao.Text = row.Cells["NgayTao"].Value?.ToString();
                txt_ngayCapNhat.Text = row.Cells["NgayCapNhat"].Value?.ToString();
            }
        }
        //viêt hàm ở dưới 
        //viết phương thức tạo mã thương hiệu tự động
        private string taoMaThuongHieuTuDong()
        {
            string maThuongHieu = "";
            _lstThuongHieu = new List<ThuongHieu>();
            _lstThuongHieu = _thuongHieuBLL.LayTatCaThuongHieu();
            if (_lstThuongHieu == null || _lstThuongHieu.Count == 0)
            {
                maThuongHieu = "TH001";
            }
            else
            {
                ThuongHieu th = _lstThuongHieu[_lstThuongHieu.Count - 1];
                string maThuongHieuCuoi = th.MaThuongHieu;
                string so = maThuongHieuCuoi.Substring(2);
                int soMoi = int.Parse(so) + 1;
                maThuongHieu = "TH" + soMoi.ToString("D3");
            }
            return maThuongHieu;
        }
        //viết phương thức load dữ liệu thương hiệu
        private void LoadDataThuongHieu()
        {
            _lstThuongHieu = new List<ThuongHieu>();
            _lstThuongHieu = _thuongHieuBLL.LayTatCaThuongHieu();
            if (_lstThuongHieu == null || _lstThuongHieu.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            dgv_thuongHieu.DataSource = _lstThuongHieu;
            //đặt tiêu đề cho các cột
            dgv_thuongHieu.Columns["MaThuongHieu"].HeaderText = "Mã thương hiệu";
            dgv_thuongHieu.Columns["TenThuongHieu"].HeaderText = "Tên thương hiệu";
            dgv_thuongHieu.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_thuongHieu.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái";
            dgv_thuongHieu.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgv_thuongHieu.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgv_thuongHieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_thuongHieu.CellFormatting -= dgv_thuongHieu_CellFormatting;
            dgv_thuongHieu.CellFormatting += dgv_thuongHieu_CellFormatting;

        }

        private void dgv_thuongHieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgv_thuongHieu.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái";
            if (dgv_thuongHieu.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong" && e.Value != null)
            {
                e.Value = e.Value.ToString() == "True" ? "Hoạt động" : "Không hoạt động";
                e.FormattingApplied = true;
            }
        }

        //viết phương thức tạo mã tự động
        private string taoMaKichThuocTuDong()
        {
            string maKichThuoc = "";
            _lstKichThuoc = new List<KichThuoc>();
            _lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
            if (_lstKichThuoc == null || _lstKichThuoc.Count == 0)
            {
                maKichThuoc = "KT001";
            }
            else
            {
                KichThuoc kt = _lstKichThuoc[_lstKichThuoc.Count - 1];
                string maKichThuocCuoi = kt.MaKichThuoc;
                string so = maKichThuocCuoi.Substring(2);
                int soMoi = int.Parse(so) + 1;
                maKichThuoc = "KT" + soMoi.ToString("D3");
            }
           return maKichThuoc;
        }
        //viết hàm load kích thước
        public void LoadDataKichThuoc()
        {
            _lstKichThuoc = new List<KichThuoc>();
            _lstKichThuoc = _kichThuocBLL.LayTatCaKichThuoc();
            if (_lstKichThuoc == null || _lstKichThuoc.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            dgv_dsKichThuoc.DataSource = _lstKichThuoc;
            dgv_dsKichThuoc.Columns["MaKichThuoc"].HeaderText = "Mã kích thước";
            dgv_dsKichThuoc.Columns["TenKichThuoc"].HeaderText = "Tên kích thước";
            dgv_dsKichThuoc.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_dsKichThuoc.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái";
            dgv_dsKichThuoc.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgv_dsKichThuoc.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgv_dsKichThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_dsKichThuoc.CellFormatting -= dgv_dsKichThuoc_CellFormatting;
            dgv_dsKichThuoc.CellFormatting += dgv_dsKichThuoc_CellFormatting;
        }

        private void dgv_dsKichThuoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra và định dạng cột "TrangThaiHoatDong"
            if (dgv_dsKichThuoc.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong" && e.Value != null)
            {
                e.Value = e.Value.ToString() == "True" ? "Hoạt động" : "Không hoạt động";
                e.FormattingApplied = true;
            }
        }

        //viết hàm tạo mã màu sắc tự động
        private string taoMaMauSacTuDong()
        {
            string maMau = "";
            _lstMauSac = new List<MauSac>();
            _lstMauSac = _mauSacBLL.layTatCaMauSac();
            if (_lstMauSac == null || _lstMauSac.Count == 0)
            {
                maMau = "MS001";
            }
            else
            {
                MauSac ms = _lstMauSac[_lstMauSac.Count - 1];
                string maMauCuoi = ms.MaMauSac;
                string so = maMauCuoi.Substring(2);
                int soMoi = int.Parse(so) + 1;
                maMau = "MS" + soMoi.ToString("D3");
            }

            return maMau;
        }
        private void LoadDataMauSac()
        {
            // Khởi tạo danh sách màu sắc
            _lstMauSac = _mauSacBLL.layTatCaMauSac();
            if (_lstMauSac == null || _lstMauSac.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }

            // Đặt DataSource trước khi thiết lập các cột
            dgv_dsMauSac.DataSource = _lstMauSac;

            // Đặt tiêu đề cho các cột
            dgv_dsMauSac.Columns["MaMauSac"].HeaderText = "Mã màu sắc";
            dgv_dsMauSac.Columns["TenMauSac"].HeaderText = "Tên màu sắc";
            dgv_dsMauSac.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_dsMauSac.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái";
            dgv_dsMauSac.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgv_dsMauSac.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";

            // Thiết lập chế độ tự động điều chỉnh cột
            dgv_dsMauSac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đảm bảo sự kiện CellFormatting không được thêm nhiều lần
            dgv_dsMauSac.CellFormatting -= dgv_dsMauSac_CellFormatting;
            dgv_dsMauSac.CellFormatting += dgv_dsMauSac_CellFormatting;
        }

        private void dgv_dsMauSac_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra và định dạng cột "TrangThaiHoatDong"
            if (dgv_dsMauSac.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong" && e.Value != null)
            {
                e.Value = e.Value.ToString() == "True" ? "Hoạt động" : "Không hoạt động";
                e.FormattingApplied = true;
            }
        }
        //viết phương thức tạo mã loại tự động
        private string taoMaLoaiTuDong()
        {
            string maLoai = "";
            _lstLoaiSanPham = new List<LoaiSanPham>();
            _lstLoaiSanPham = _loaiSanPhamBLL.layTatCaLoaiSanPham();
            if (_lstLoaiSanPham == null || _lstLoaiSanPham.Count == 0)
            {
                maLoai = "LSP001";
            }
            else
            {
                LoaiSanPham lsp = _lstLoaiSanPham[_lstLoaiSanPham.Count - 1];
                string maLoaiCuoi = lsp.MaLoaiSanPham;
                string so = maLoaiCuoi.Substring(3); 
                int soMoi = int.Parse(so) + 1;
                maLoai = "LSP" + soMoi.ToString("D3");
            }

            return maLoai;
        }
        //viết phương thức load dữ liệu
        private void LoadData(List<LoaiSanPham> ds)
        {
            _lstLoaiSanPham = ds;
            if (_lstLoaiSanPham == null || _lstLoaiSanPham.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            dgv_dsLoaiSanPham.DataSource = _lstLoaiSanPham;

            // Đặt tiêu đề cho các cột
            dgv_dsLoaiSanPham.Columns["MaLoaiSanPham"].HeaderText = "Mã loại ";
            dgv_dsLoaiSanPham.Columns["TenLoaiSanPham"].HeaderText = "Tên loại ";
            dgv_dsLoaiSanPham.Columns["MoTa"].HeaderText = "Mô tả";
            dgv_dsLoaiSanPham.Columns["TrangThaiHoatDong"].HeaderText = "Trạng thái";
            dgv_dsLoaiSanPham.Columns["NgayTao"].HeaderText = "Ngày tạo";
            dgv_dsLoaiSanPham.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";

            // Tự động điều chỉnh kích thước các cột
            dgv_dsLoaiSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Xóa bỏ sự kiện CellFormatting cũ (nếu đã tồn tại)
            dgv_dsLoaiSanPham.CellFormatting -= dgv_dsLoaiSanPham_CellFormatting;
            // Gán sự kiện CellFormatting mới
            dgv_dsLoaiSanPham.CellFormatting += dgv_dsLoaiSanPham_CellFormatting;
        }
        // Định nghĩa hàm CellFormatting để gán cho sự kiện
        private void dgv_dsLoaiSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_dsLoaiSanPham.Columns[e.ColumnIndex].Name == "TrangThaiHoatDong" && e.Value != null)
            {
                e.Value = e.Value.ToString() == "True" ? "Hoạt động" : "Không hoạt động";
                e.FormattingApplied = true;
            }
        }
    }
}
