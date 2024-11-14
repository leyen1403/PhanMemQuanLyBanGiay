using BLL;
using DevExpress.XtraBars;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private DichVuPhanQuyenBLL _phanQuyenBLL = new DichVuPhanQuyenBLL();
        public NhanVien _nhanVien { get; set; }

        private frm_dangNhap _frmDangNhap;

        public frm_main(frm_dangNhap frmDangNhap)
        {
            InitializeComponent();
            _frmDangNhap = frmDangNhap;
            this.Load += Frm_main1_Load;
            this.FormClosed += Frm_main_FormClosed;
        }

        private void Frm_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmDangNhap.Visible = true;
        }

        // đăng kí sự kiện trọng này
        private void Frm_main1_Load(object sender, EventArgs e)
        {
            pnMain.Height = this.ClientSize.Height;
            pnMain.Width = this.ClientSize.Width - pnLeft.Width;
            this.MaximizeBox = false;
            this.btn_LapDonDatHang.Click += Btn_LapDonDatHang_Click;
            this.btn_LapHoaDon.Click += Btn_LapHoaDon_Click;
            this.btn_LapPhieuKiemKe.Click += Btn_LapPhieuKiemKe_Click;
            this.btn_LapThongKeBaoCao.Click += Btn_LapThongKeBaoCao_Click;
            this.btn_Loai.Click += Btn_Loai_Click;
            this.btn_DonDatHang.Click += Btn_DonDatHang_Click;
            this.btn_HoaDon.Click += Btn_HoaDon_Click;
            this.btn_KhachHang.Click += Btn_KhachHang_Click;
            this.btn_Kho.Click += Btn_Kho_Click;
            this.btn_NhaCC.Click += Btn_NhaCC_Click;
            this.btn_NhanVien.Click += Btn_NhanVien_Click;
            this.btnQuanLyPhieuKiemKe.Click += BtnQuanLyPhieuKiemKe_Click;
            this.btn_dangXuat.ItemClick += Btn_dangXuat_ItemClick;
            this.btn_Thoat.ItemClick += Btn_Thoat_ItemClick;
            label_tenNV.Caption = _nhanVien.TenNhanVien.ToString();
            PhanQuyen();
        }

        private void Btn_Thoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Hiển thị form đăng nhập
            frm_dangNhap frm = new frm_dangNhap();
            frm.Show();
            this.Close();
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            // Hiển thị form đăng nhập
            frm_dangNhap frm = new frm_dangNhap();
            frm.Show();
            this.Close();
        }

        private void Btn_dangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Hiển thị form đăng nhập
            frm_dangNhap frm = new frm_dangNhap();
            frm.Show();
            this.Close();
        }

        private void PhanQuyen()
        {
            // Lấy danh sách quyền của nhân viên
            List<string> danhSachQuyen = _phanQuyenBLL.LayDanhSachQuyen(_nhanVien.MaNhanVien);

            // Kiểm tra và ẩn/hiện nút dựa trên quyền
            btn_LapDonDatHang.Visible = danhSachQuyen.Contains("Xem màn hình bán hàng");
            btn_LapHoaDon.Visible = danhSachQuyen.Contains("Xem màn hình bán hàng");
            btn_LapPhieuKiemKe.Visible = danhSachQuyen.Contains("Lập phiếu kiểm kê");
            btn_LapThongKeBaoCao.Visible = danhSachQuyen.Contains("Xem màn hình báo cáo");
            btn_Loai.Visible = danhSachQuyen.Contains("Quản lý loại sản phẩm");
            btn_DonDatHang.Visible = danhSachQuyen.Contains("Quản lý đơn đặt hàng");
            btn_HoaDon.Visible = danhSachQuyen.Contains("Quản lý hóa đơn");
            btn_KhachHang.Visible = danhSachQuyen.Contains("Quản lý khách hàng");
            btn_Kho.Visible = danhSachQuyen.Contains("Xem màn hình quản lý kho");
            btn_NhaCC.Visible = danhSachQuyen.Contains("Quản lý nhà cung cấp");
            btn_NhanVien.Visible = danhSachQuyen.Contains("Quản lý nhân viên");
            btnQuanLyPhieuKiemKe.Visible = danhSachQuyen.Contains("Quản lý phiếu kiểm kê");
            accordionControlElement4.Visible = danhSachQuyen.Contains("Quản lý phân quyền");
        }
        private void BtnQuanLyPhieuKiemKe_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapPhieuKiemKe());
        }

        private void Btn_NhanVien_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhanVien());
        }

        private void Btn_NhaCC_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhaCungCap());
        }

        private void Btn_Kho_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyKhoHang());
        }

        private void Btn_KhachHang_Click(object sender, EventArgs e)
        {

            loadForm(new frm_quanLyKhachHang());
        }

        private void Btn_HoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyHoaDon());
        }

        private void Btn_DonDatHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyDonDatHang());
        }

        private void Btn_Loai_Click(object sender, EventArgs e)
        {

            loadForm(new frm_quanLyChungLoai());
        }

        private void Btn_LapThongKeBaoCao_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapThongKeBaoCao());
        }

        private void Btn_LapPhieuKiemKe_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapPhieuKiemKe());
        }

        private void Btn_LapHoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapHoaDon());
        }

        private void Btn_LapDonDatHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapDonDatHang());
        }

        void loadForm(Form form)
        {
            this.Text = form.Text;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Height = pnMain.Height;
            form.Width = pnMain.Width;
            pnMain.Controls.Add(form);
            pnMain.Tag = form;
            form.BringToFront();
            form.Show();

        }

        private void btn_LapHoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapHoaDon());
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            loadForm(new frm_QuanLyPhanQuyen());
        }
    }
}
