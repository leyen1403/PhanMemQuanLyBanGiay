using BLL;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
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
            label_tenNV.Caption = _nhanVien.TenNhanVien.ToString();
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            List<string> danhSachQuyen = _phanQuyenBLL.LayDanhSachQuyen(_nhanVien.MaNhanVien);

            // Lặp qua tất cả các control trong form
            foreach (AccordionControlElement control in accordionControl1.Elements)
            {
                foreach (AccordionControlElement element in control.Elements)
                {
                    if (element.Tag != null)
                    {
                        List<string> requiredPermissions = element.Tag.ToString().Split(',').ToList();
                        if (requiredPermissions.Any(permission => danhSachQuyen.Contains(permission)))
                        {
                            element.Visible = true;
                            element.Enabled = true;
                        }
                        else
                        {
                            element.Visible = false;
                            element.Enabled = false;
                        }
                    }
                }
            }
        }

        private void BtnQuanLyPhieuKiemKe_Click(object sender, EventArgs e)
        {

        }
        private void Btn_LapThongKeBaoCao_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapThongKeBaoCao());
        }
     

        void loadForm(Form form)
        {
            // Đóng hoặc xóa form hiện hành nếu có
            if (pnMain.Controls.Count > 0)
            {
                Form currentForm = pnMain.Controls[0] as Form;
                if (currentForm != null)
                {
                    currentForm.Close(); // Đóng form hiện tại
                    pnMain.Controls.Remove(currentForm); // Loại bỏ form khỏi panel
                }
            }

            // Hiển thị form mới
            this.Text = form.Text;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnMain.Controls.Add(form); // Thêm form vào panel
            pnMain.Tag = form;
            form.BringToFront(); // Đưa form mới lên phía trước
            form.Show(); // Hiển thị form
        }


        private void btn_LapHoaDon_Click(object sender, EventArgs e)
        {
           frm_lapHoaDon frm_LapHoaDon = new frm_lapHoaDon();
            frm_LapHoaDon.MaNhanVien = _nhanVien.MaNhanVien;
            loadForm(frm_LapHoaDon);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            loadForm(new frm_QuanLyPhanQuyen());
        }

        private void btn_LapPhieuKiemKe_Click(object sender, EventArgs e)
        {
            frm_lapPhieuKiemKe lapPhieuKiemKe = new frm_lapPhieuKiemKe();
            lapPhieuKiemKe.MaNhanVien = _nhanVien.MaNhanVien;
            loadForm(lapPhieuKiemKe);
        }

        private void btnQuanLyPhieuKiemKe_Click_1(object sender, EventArgs e)
        {
            frm_quanLyPhieuKiemKe quanLyPhieuKiemKe = new frm_quanLyPhieuKiemKe();
            quanLyPhieuKiemKe.MaNhanVien = _nhanVien.MaNhanVien;
            loadForm(quanLyPhieuKiemKe);
        }

        private void btn_LapHoaDon_Click_1(object sender, EventArgs e)
        {
            frm_lapHoaDon frm_LapHoaDon = new frm_lapHoaDon();
            frm_LapHoaDon.MaNhanVien = _nhanVien.MaNhanVien;
            loadForm(frm_LapHoaDon);
        }

        private void btn_LapThongKeBaoCao_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_lapThongKeBaoCao());
        }

        private void btn_LapDonDatHang_Click_1(object sender, EventArgs e)
        {
            frm_lapDonDatHang lapDonDatHang = new frm_lapDonDatHang();
            lapDonDatHang.MaNhanVien = _nhanVien.MaNhanVien;
            loadForm(lapDonDatHang);
        }

        private void btn_LapPhieuDoiTra_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_HoaDon_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyHoaDon());
        }

        private void btn_DonDatHang_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyDonDatHang());
        }

        private void btn_DoiTra_Click(object sender, EventArgs e)
        {
            loadForm(new frm_QuanLyPhieuTraHang() { MaNhanVien = _nhanVien.MaNhanVien});
        }

        private void btn_NhaCC_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhaCungCap());
        }

        private void btn_KhachHang_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyKhachHang());
        }

        private void btn_Kho_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyKhoHang());
        }

        private void btn_NhanVien_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhanVien());
        }

        private void btn_HoanTra_Click(object sender, EventArgs e)
        {

        }

        private void btn_Loai_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyChungLoai());
        }

        private void btn_phanTich_Click(object sender, EventArgs e)
        {
            loadForm(new PhanTich());
        }
    }
}
