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
        public NhanVien _nhanVien { get; set; }

        public frm_main()
        {
            InitializeComponent();
            this.Load += Frm_main1_Load;
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
