using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_ThemNhanVien : Form
    {
        public event EventHandler Tao;
        public frm_ThemNhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSoDienThoai.Text;
            if (soDienThoai.Length != 10 || !soDienThoai.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại phải có 10 chữ số");
                return;
            }
            string hoVaTen = txtHoVaTen.Text;
            DateTime ngaySinh = dtpNgaySinh.Value;
            string gioiTinh = "";
            if (rbtnNam.Checked)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "Nữ";
            }
            string diaChi = txtDiaChi.Text;
            string chucVu = txtChucVu.Text;
            if(chucVu == "")
            {
                MessageBox.Show("Chức vụ không được để trống");
                return;
            }
            string email = txtEmail.Text;    
            if(email == "")
            {
                MessageBox.Show("Email không được để trống");
                return;
            }
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ");
                return;
            }
            string taiKhoan = txtTaiKhoan.Text;
            if (taiKhoan == "")
            {
                MessageBox.Show("Tài khoản không được để trống");
                return;
            }
            string matKhau = txtMatKhau.Text;
            if (matKhau == "")
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }
            List<NhanVien> lstNhanVien = new List<NhanVien>();
            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            // Tài khoản đã tồn tại
            NhanVien nv = nhanVienBLL.LayDanhSachNhanVien().Where(x=>x.TaiKhoan == taiKhoan).FirstOrDefault();
            if(nv != null)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }
            // Số điện thoại đã tồn tại
            nv = nhanVienBLL.LayDanhSachNhanVien().Where(x => x.SoDienThoai == soDienThoai).FirstOrDefault();
            if (nv != null)
            {
                MessageBox.Show("Số điện thoại đã tồn tại");
                return;
            }
            // Email đã tồn tại
            nv = nhanVienBLL.LayDanhSachNhanVien().Where(x => x.Email == email).FirstOrDefault();
            if (nv != null)
            {
                MessageBox.Show("Email thoại đã tồn tại");
                return;
            }
            string maNhanVien = taoMaNhanVien();
            nv = new NhanVien();
            nv.MaNhanVien = maNhanVien;
            nv.TenNhanVien = hoVaTen;
            nv.NgaySinh = ngaySinh;
            nv.GioiTinh = gioiTinh;
            nv.SoDienThoai = soDienThoai;
            nv.Email = email;
            nv.ChucVu = chucVu;
            nv.TaiKhoan = taiKhoan;
            nv.MatKhau = matKhau;
            nv.HinhAnh = "icons8-user-100.png";
            nv.TrangThaiHoatDong = true;
            nv.NgayTao = DateTime.Now;
            nv.NgayCapNhat = DateTime.Now;
            nv.DiaChi = diaChi;
            if (nhanVienBLL.ThemNhanVien(nv))
            {
                MessageBox.Show("Thêm nhân viên thành công");
                Tao?.Invoke(sender, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại. Vui lòng kiểm tra lại thông tin hoặc hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string taoMaNhanVien()
        {
            List<NhanVien> lstNhanVien = new NhanVienBLL().LayDanhSachNhanVien();
            if(lstNhanVien.Count == 0)
            {
                return "NV001";
            }
            else
            {
                string maNhanVienCuoi = lstNhanVien.OrderByDescending(x => x.MaNhanVien).FirstOrDefault().MaNhanVien;
                string soCuoi = maNhanVienCuoi.Substring(2);
                int soMoi = int.Parse(soCuoi) + 1;
                string maNhanVienMoi = "NV"+soMoi.ToString().PadLeft(3,'0');
                return maNhanVienMoi;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
