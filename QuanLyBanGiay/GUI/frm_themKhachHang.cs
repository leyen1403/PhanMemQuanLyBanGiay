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
using BLL;
using DTO;

namespace GUI
{
    public partial class frm_themKhachHang : Form
    {
        private KhachHangBLL _khachHangBLL = new KhachHangBLL();
        private List<KhachHang> _lstKhachHang = new List<KhachHang>();
        public frm_themKhachHang()
        {
            InitializeComponent();
            txt_maKhachHang.Text = TaoMaKhachHangTuDong();
            cbo_thanhVien.SelectedIndex = 0;
            cbo_trangThai.SelectedIndex = 0;
            cbbGioiTinh.SelectedIndex = 0;
        }

        private void btn_themKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra thông tin nhập vào
                if (string.IsNullOrEmpty(txt_tenKhachHang.Text))
                {
                    MessageBox.Show("Tên khách hàng không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_tenKhachHang.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_SDT.Text))
                {
                    MessageBox.Show("Số điện thoại không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SDT.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_diaChi.Text))
                {
                    MessageBox.Show("Địa chỉ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_diaChi.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txt_email.Text))
                {
                    MessageBox.Show("Email không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_email.Focus();
                    return;
                }
                //giới tính
                if (cbbGioiTinh.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbGioiTinh.Focus();
                    return;
                }
                // nếu thẻ thành viên được chọn là chưa là thành viên thì điểm tích lũy phải bằng 0 và ẩn tài khoản và mật khẩu
                if (cbo_thanhVien.SelectedIndex == 1)
                {
                    txt_diemTichLuy.Text = "0";
                    txt_taiKhoan.Text = "";
                    txt_matKhau.Text = "";
                    txt_taiKhoan.Enabled = false;
                    txt_matKhau.Enabled = false;
                }
                //nếu thẻ thành viên được chọn là đã là thành viên thì điểm tích lũy phải lớn hơn 0 và hiện tài khoản và mật khẩu
                else
                {
                    txt_taiKhoan.Enabled = true;
                    txt_matKhau.Enabled = true;
                    if (string.IsNullOrEmpty(txt_taiKhoan.Text))
                    {
                        MessageBox.Show("Tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_taiKhoan.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txt_matKhau.Text))
                    {
                        MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_matKhau.Focus();
                        return;
                    }
                }
                //thêm khách hàng
                KhachHang kh = new KhachHang
                {
                    MaKhachHang = TaoMaKhachHangTuDong(),
                    TenKhachHang = txt_tenKhachHang.Text,
                    SoDienThoai = txt_SDT.Text,
                    DiaChi = txt_diaChi.Text,
                    DiemTichLuy = 0,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cbbGioiTinh.Text,
                    Email = txt_email.Text,
                    TaiKhoan = txt_taiKhoan.Text,
                    MatKhau = txt_matKhau.Text,
                    HinhAnh = "",
                    NgayTao = dtp_ngayTao.Value,
                    NgayCapNhat = dtp_ngayCapNhat.Value,
                    ThanhVien = cbo_thanhVien.SelectedIndex == 0 ? true : false,
                    TrangThaiHoatDong = cbo_trangThai.SelectedIndex == 0 ? true : false
                };
                if (_khachHangBLL.ThemKhachHang(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        private string TaoMaKhachHangTuDong()
        {

            string maKhachHang = "";
            _lstKhachHang = new List<KhachHang>();
            _lstKhachHang = _khachHangBLL.LayTatCaKhachHang();
            if (_lstKhachHang == null || _lstKhachHang.Count == 0)
            {
                maKhachHang = "KH001";
            }
            else
            {
                KhachHang kh = _lstKhachHang[_lstKhachHang.Count - 1];
                string maKhachHangCuoi = kh.MaKhachHang;
                string so = maKhachHangCuoi.Substring(2);
                int soMoi = int.Parse(so) + 1;
                maKhachHang = "KH" + soMoi.ToString("D3");
            }

            return maKhachHang;
        }
    }
}
