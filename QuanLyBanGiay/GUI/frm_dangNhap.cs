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

namespace GUI
{
    public partial class frm_dangNhap : Form
    {
        public frm_dangNhap()
        {
            InitializeComponent();
            btn_dangnhap.Click += Btn_dangnhap_Click;
        }

        private void Btn_dangnhap_Click(object sender, EventArgs e)
        {
            // Tài khoản < 255 ký tự
            if (txt_tentaikhoan.Text.Length > 255)
            {
                MessageBox.Show("Tài khoản không được quá 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mật khẩu < 255 ký tự
            if (txt_matkhau.Text.Length > 255)
            {
                MessageBox.Show("Mật khẩu không được quá 255 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Tài khoản không được để trống
            if (txt_tentaikhoan.Text == "")
            {
                MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Mật khẩu không được để trống
            if (txt_matkhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra đăng nhập
            BLL.NhanVienBLL nhanVienBLL = new BLL.NhanVienBLL();
            if (nhanVienBLL.KiemTraDangNhap(txt_tentaikhoan.Text, txt_matkhau.Text))
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                NhanVien nv = nhanVienBLL.LayNhanVien(txt_tentaikhoan.Text, txt_matkhau.Text);                
                frm_main frm = new frm_main();
                frm._nhanVien = nv;
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
