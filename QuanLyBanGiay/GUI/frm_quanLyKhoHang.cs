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

        List<SanPham> lstSanPham = null;
        List<ThuongHieu> lstThuongHieu = null;
        List<KichThuoc> lstKichThuoc = null;
        List<MauSac> lstMauSac = null;

        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyKhoHang_Load;
        }

        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {
            LoadData();
            this.dgv_dsSanPham.SelectionChanged += Dgv_dsSanPham_SelectionChanged;
        }

        private void Dgv_dsSanPham_SelectionChanged(object sender, EventArgs e)
        {
            //hiện lên textbox
            GetCurrentRowData();
        }


        //phương thức viết ở đây
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
                    txt_soLuongTon.Text = Convert.ToInt32(currentRow.Cells["SoLuongTon"].Value).ToString();
                    decimal giaNhap = Convert.ToDecimal(currentRow.Cells["GiaNhap"].Value);
                    decimal giaBan = Convert.ToDecimal(currentRow.Cells["GiaBan"].Value);
                    txt_giaNhap.Text = giaNhap.ToString("N0");
                    txt_giaBan.Text = giaBan.ToString("N0");
                    txt_moTa.Text = currentRow.Cells["MoTa"].Value.ToString();
                    txt_ngayTao.Text = Convert.ToDateTime(currentRow.Cells["NgayTao"].Value).ToString("dd/MM/yyyy");
                    txt_ngayCapNhat.Text = Convert.ToDateTime(currentRow.Cells["NgayCapNhat"].Value).ToString("dd/MM/yyyy");
                    txt_soLuongToiThieu.Text = Convert.ToInt32(currentRow.Cells["SoLuongToiThieu"].Value).ToString();
                    txt_duongDan.Text = currentRow.Cells["HinhAnh"].Value?.ToString();
                    string hinhanh = currentRow.Cells["HinhAnh"].Value?.ToString();
                    //LoadKichThuocAndMauSac(txt_maSanPham.Text = currentRow.Cells["MaSanPham"].Value.ToString());
                    if (!string.IsNullOrEmpty(hinhanh))
                    {
                        LoadImageToPictureBox(hinhanh);
                    }
                    else
                    {
                        img_sanPham.Image = null;
                    }

                    string trangThai = currentRow.Cells["TrangThai"].Value?.ToString(); // Sử dụng dấu hỏi (?) để kiểm tra null
                    if (string.IsNullOrEmpty(trangThai))
                    {
                        txt_trangThai.Text = "Không xác định"; // Hoặc giá trị mặc định khi null
                    }
                    else
                    {
                        txt_trangThai.Text = trangThai == "True" ? "Hoạt động" : "Không hoạt động";
                    }
                }
                else
                {
                    Console.Write("Không có dòng nào được chọn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ dòng hiện tại: " + ex.Message);
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
            //thêm tiêu đề cho các cột
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

            //hiển thị giá tiền kiểu N0
            dgv_dsSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgv_dsSanPham.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";

            //ẩn cột
            dgv_dsSanPham.Columns["LoaiSanPham"].Visible = false;
            dgv_dsSanPham.Columns["ThuongHieu"].Visible = false;
            dgv_dsSanPham.Columns["KichThuoc"].Visible = false;
            dgv_dsSanPham.Columns["MauSac"].Visible = false;

        }
    }
}
