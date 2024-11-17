using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyNhaCungCap : Form
    {
        NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();
        List<NhaCungCap> _lstNhaCungCap = null;
        public frm_quanLyNhaCungCap()
        {
            InitializeComponent();
            this.Load += Frm_quanLyNhaCungCap_Load;
        }

        private void Frm_quanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhaCungCap();
            InitTitleDgv();
            dgv_nhaCC.SelectionChanged += Dgv_nhaCC_SelectionChanged;
            btn_themNCC.Click += Btn_themNCC_Click;
            btn_CapNhat.Click += Btn_CapNhat_Click;
            btnClear.Click += BtnClear_Click;
            dtp_ngayCapNhat.Enabled = false;
            dtp_ngayTao.Enabled = false;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            XoaTextBox();
        }

        private void Btn_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra dữ liệu nhập vào
                //kiểm tra mã nhà cung cấp có tồn tại không
                if (txt_maNCC.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp cần cập nhật");
                    return;
                }
                NhaCungCap ncc = _nhaCungCapBLL.LayNhaCungCap(txt_maNCC.Text);
                if (ncc == null)
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại");
                    return;
                }
                if (txt_tenNCC.Text == string.Empty || txt_diaChi.Text == string.Empty || txt_tenDaiDien.Text == string.Empty || txt_email.Text == string.Empty || txt_SDT.Text == string.Empty || cbo_trangThai.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                ncc.TenNhaCungCap = txt_tenNCC.Text;
                ncc.DiaChi = txt_diaChi.Text;
                ncc.NguoiDaiDien = txt_tenDaiDien.Text;
                ncc.Email = txt_email.Text;
                ncc.SoDienThoai = txt_SDT.Text;
                if (cbo_trangThai.Text == "Đang hoạt động")
                {
                    ncc.TrangThaiHoatDong = true;
                }
                else
                {
                    ncc.TrangThaiHoatDong = false;
                }
                ncc.NgayCapNhat = DateTime.Now;
                if (_nhaCungCapBLL.CapNhatNhaCungCap(ncc))
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công");
                    LoadDanhSachNhaCungCap();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thất bại");
                }
            }
            catch
            {

            }
        }

        private void Btn_themNCC_Click(object sender, EventArgs e)
        {
            try
            {
                //kiểm tra dữ liệu nhập vào
                if (txt_tenNCC.Text == string.Empty || txt_diaChi.Text == string.Empty || txt_tenDaiDien.Text == string.Empty || txt_email.Text == string.Empty || txt_SDT.Text == string.Empty || cbo_trangThai.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                //kiểm tra tên nhà cung cấp đã tồn tại chưa
                if (_nhaCungCapBLL.KiemTraTenNhaCungCap(txt_tenNCC.Text))
                {
                    MessageBox.Show("Tên nhà cung cấp đã tồn tại");
                    return;
                }
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNhaCungCap = TaoMaNCC();
                ncc.TenNhaCungCap = txt_tenNCC.Text;
                ncc.DiaChi = txt_diaChi.Text;
                ncc.NguoiDaiDien = txt_tenDaiDien.Text;
                ncc.Email = txt_email.Text;
                ncc.SoDienThoai = txt_SDT.Text;
                if (cbo_trangThai.Text == "Đang hoạt động")
                {
                    ncc.TrangThaiHoatDong = true;
                }
                else
                {
                    ncc.TrangThaiHoatDong = false;
                }
                ncc.NgayTao = DateTime.Now;
                ncc.NgayCapNhat = DateTime.Now;
                if (_nhaCungCapBLL.ThemNhaCungCap(ncc))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công");
                    LoadDanhSachNhaCungCap();
                    XoaTextBox();
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại");
                }
            }
            catch
            {
                Console.WriteLine("Lỗi kết nối cơ sở dữ liệu");
            }
        }

        private void Dgv_nhaCC_SelectionChanged(object sender, EventArgs e)
        {
            HienThiThongTinChiTietNhaCungCap();
        }

        //viết hàm xử lý
        //viết hàm tạo maNCC tự động dựa theo tổng nhà cung cấp tăng dần
        private string TaoMaNCC()
        {
            try
            {
                _lstNhaCungCap = _nhaCungCapBLL.LayDanhSachNhaCungCap();

                if (_lstNhaCungCap == null || _lstNhaCungCap.Count == 0)
                {
                    return "NCC001";
                }

                string maNCCCuoi = _lstNhaCungCap
                    .OrderByDescending(ncc => ncc.MaNhaCungCap)
                    .FirstOrDefault()?.MaNhaCungCap;

                if (string.IsNullOrEmpty(maNCCCuoi) || maNCCCuoi.Length <= 3 || !int.TryParse(maNCCCuoi.Substring(3), out int soCuoi))
                {
                    return "NCC001"; // Trường hợp mã không hợp lệ, bắt đầu lại
                }

                int soMoi = soCuoi + 1;
                return $"NCC{soMoi:D3}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo mã NCC: {ex.Message}");
                return "NCC001"; // Trả về mã mặc định nếu gặp lỗi
            }
        }

        // viết hàm xoá textbox
        private void XoaTextBox()
        {
            txt_maNCC.Text = string.Empty;
            txt_tenNCC.Text = string.Empty;
            txt_diaChi.Text = string.Empty;
            txt_tenDaiDien.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_SDT.Text = string.Empty;
            cbo_trangThai.Text = string.Empty;
            dtp_ngayTao.Value = DateTime.Now;
            dtp_ngayCapNhat.Value = DateTime.Now;
            txt_tenNCC.Focus();
        }
        //hiển thị thông tin chi tiết của nhà cung cấp
        private void HienThiThongTinChiTietNhaCungCap()
        {
            if (dgv_nhaCC.CurrentRow != null)
            {
                string maNhaCungCap = dgv_nhaCC.CurrentRow.Cells[0].Value.ToString();
                NhaCungCap ncc = _nhaCungCapBLL.LayNhaCungCap(maNhaCungCap);
                if (ncc != null)
                {
                    txt_maNCC.Text = ncc.MaNhaCungCap;
                    txt_tenNCC.Text = ncc.TenNhaCungCap;
                    txt_diaChi.Text = ncc.DiaChi;
                    txt_tenDaiDien.Text = ncc.NguoiDaiDien;
                    txt_email.Text = ncc.Email;
                    txt_SDT.Text = ncc.SoDienThoai;
                    if (ncc.TrangThaiHoatDong == true)
                    {
                        cbo_trangThai.Text = "Đang hoạt động";
                    }
                    else
                    {
                        cbo_trangThai.Text = "Ngừng hoạt động";
                    }
                    dtp_ngayTao.Value = (DateTime)ncc.NgayTao;
                    dtp_ngayCapNhat.Value = (DateTime)ncc.NgayCapNhat;
                }
            }
        }
        //khởi tạo title cho data grid view
        private void InitTitleDgv()
        {
            dgv_nhaCC.ReadOnly = true;
            dgv_nhaCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgv_nhaCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgv_nhaCC.Columns[2].HeaderText = "Địa chỉ";
            dgv_nhaCC.Columns[3].HeaderText = "Người đại diện";
            dgv_nhaCC.Columns[4].HeaderText = "Email";
            dgv_nhaCC.Columns[5].HeaderText = "Số điện thoại";
            dgv_nhaCC.Columns[6].HeaderText = "Trạng thái hoạt động";
            dgv_nhaCC.Columns[7].HeaderText = "Ngày Tạo";
            dgv_nhaCC.Columns[8].HeaderText = "Ngày cập nhật";
            //dàn đều cho các cột
            for (int i = 0; i < dgv_nhaCC.Columns.Count; i++)
            {
                dgv_nhaCC.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgv_nhaCC.RowPostPaint += dgv_RowPostPaint;
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
        //viết hàm load danh sách nhà cung cấp
        private void LoadDanhSachNhaCungCap()
        {
            try
            {
                _lstNhaCungCap = new List<NhaCungCap>();
                _lstNhaCungCap = _nhaCungCapBLL.LayDanhSachNhaCungCap();
                if (_lstNhaCungCap != null)
                {
                    dgv_nhaCC.DataSource = _lstNhaCungCap;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nào");
                }
            }
            catch
            {
                Console.WriteLine("Lỗi kết nối cơ sở dữ liệu");
            }
        }

    }
}
