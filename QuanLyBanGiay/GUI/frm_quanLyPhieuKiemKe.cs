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
    public partial class frm_quanLyPhieuKiemKe : Form
    {
        public string MaNhanVien { get; set; }
        public frm_quanLyPhieuKiemKe()
        {
            InitializeComponent();
            loadDGVKiemKe();
            Load += Frm_quanLyPhieuKiemKe_Load;
            dgvKiemKe.SelectionChanged += DgvKiemKe_SelectionChanged;
            dgvChiTietKiemKe.SelectionChanged += DgvChiTietKiemKe_SelectionChanged;
            nudSoLuongThucTe.ValueChanged += NudSoLuongThucTe_ValueChanged;
            dgvChiTietKiemKe.RowPrePaint += DgvChiTietKiemKe_RowPrePaint;
        }

        private void DgvChiTietKiemKe_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Lấy dòng hiện tại
            var row = dgvChiTietKiemKe.Rows[e.RowIndex];

            // Kiểm tra cột "ChenhLech" xem có giá trị khác 0 hay không
            if (row.Cells["ChenhLech"].Value != null && Convert.ToInt32(row.Cells["ChenhLech"].Value) != 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightCoral; // Tô màu nền đỏ nhạt
                row.DefaultCellStyle.ForeColor = Color.White;      // Tô chữ màu trắng
            }
            else
            {
                // Nếu không có chênh lệch, đặt màu mặc định
                row.DefaultCellStyle.BackColor = dgvChiTietKiemKe.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvChiTietKiemKe.DefaultCellStyle.ForeColor;
            }
        }

        private void NudSoLuongThucTe_ValueChanged(object sender, EventArgs e)
        {
            nudChenhLech.Value = -nudSoLuongThucTe.Value + nudSoLuongHeThong.Value;
        }

        private void DgvChiTietKiemKe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChiTietKiemKe.Rows.Count > 0)
            {
                loadThongTinSanPham(dgvChiTietKiemKe.CurrentRow.Cells["MaSanPham"].Value.ToString());
            }
            else
            {

            }
        }

        private void loadThongTinSanPham(string maSP)
        {
            lblTenSanPham.Text = dgvChiTietKiemKe.CurrentRow.Cells["TenSanPham"].Value.ToString();
            lblTenLoai.Text = dgvChiTietKiemKe.CurrentRow.Cells["TenLoaiSanPham"].Value.ToString();
            nudSoLuongHeThong.Value = Convert.ToInt32(dgvChiTietKiemKe.CurrentRow.Cells["SoLuongHeThong"].Value);
            nudSoLuongThucTe.Value = Convert.ToInt32(dgvChiTietKiemKe.CurrentRow.Cells["SoLuongThucTe"].Value);
            nudChenhLech.Value = Convert.ToInt32(dgvChiTietKiemKe.CurrentRow.Cells["ChenhLech"].Value);
            txtLyDoChenhLech.Text = dgvChiTietKiemKe.CurrentRow.Cells["LyDoChenhLech"].Value.ToString();
        }

        private void DgvKiemKe_SelectionChanged(object sender, EventArgs e)
        {
            loadDGVChiTietKiemKe(dgvKiemKe.CurrentRow.Cells["MaKiemKe"].Value.ToString());
            lblMaPhieu.Text = dgvKiemKe.CurrentRow.Cells["MaKiemKe"].Value.ToString();
            lblNgayTao.Text = Convert.ToDateTime(dgvKiemKe.CurrentRow.Cells["NgayTao"].Value).ToString("dd/MM/yyyy");
            lblTenNVTao.Text = dgvKiemKe.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            txtGhiChu.Text = dgvKiemKe.CurrentRow.Cells["GhiChu"].Value.ToString();
        }

        private void Frm_quanLyPhieuKiemKe_Load(object sender, EventArgs e)
        {
        }

        private void loadDGVKiemKe()
        {
            var lstKiemKe = from kk in new KiemKeBLL().LayDanhSachKiemKe()
                            orderby kk.NgayTao descending
                            select new
                            {
                                kk.MaKiemKe,
                                kk.NgayKiemKe,
                                kk.MaNhanVien,
                                kk.NhanVien.TenNhanVien,
                                kk.GhiChu,
                                kk.TrangThai,
                                kk.NgayTao
                            };
            dgvKiemKe.DataSource = lstKiemKe.ToList();
            if (dgvKiemKe.Columns["SoThuTu"] == null)
            {
                DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn
                {
                    Name = "SoThuTu",
                    HeaderText = "STT",
                    Width = 50,
                    ReadOnly = true
                };

                dgvKiemKe.Columns.Insert(0, soThuTuColumn);
            }
            dgvKiemKe.DataBindingComplete += dgvKiemKe_DataBindingComplete;
            dgvKiemKe.Columns["MaKiemKe"].HeaderText = "Mã kiểm kê";
            dgvKiemKe.Columns["NgayKiemKe"].HeaderText = "Ngày kiểm kê";
            dgvKiemKe.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvKiemKe.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            dgvKiemKe.Columns["GhiChu"].Visible = false;
            dgvKiemKe.Columns["TrangThai"].Visible = false;
            dgvKiemKe.Columns["NgayTao"].Visible = false;
        }

        private void dgvKiemKe_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvKiemKe.Rows.Count; i++)
            {
                dgvKiemKe.Rows[i].Cells["SoThuTu"].Value = i + 1;
            }
        }

        private void loadDGVChiTietKiemKe(string maKiemKe)
        {
            var lstChiTietKiemKe = from ctkk in new ChiTietKiemKeBLL().LayDanhSachChiTietKiemKe(maKiemKe)
                                   select new
                                   {
                                       ctkk.MaSanPham,
                                       ctkk.SanPham.TenSanPham,
                                       ctkk.SoLuongHeThong,
                                       ctkk.SoLuongThucTe,
                                       ctkk.ChenhLech,
                                       ctkk.LyDoChenhLech,
                                       ctkk.SanPham.LoaiSanPham.TenLoaiSanPham,
                                   };
            dgvChiTietKiemKe.DataSource = lstChiTietKiemKe.ToList();
            if (dgvChiTietKiemKe.Columns["SoThuTu"] == null)
            {
                DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn
                {
                    Name = "SoThuTu",
                    HeaderText = "STT",
                    Width = 50,
                    ReadOnly = true
                };

                dgvChiTietKiemKe.Columns.Insert(0, soThuTuColumn);
            }
            dgvChiTietKiemKe.DataBindingComplete += dgvChiTietKiemKe_DataBindingComplete;
            dgvChiTietKiemKe.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvChiTietKiemKe.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvChiTietKiemKe.Columns["SoLuongHeThong"].Visible = false;
            dgvChiTietKiemKe.Columns["SoLuongThucTe"].Visible = false;
            dgvChiTietKiemKe.Columns["ChenhLech"].HeaderText = "Chênh lệch";
            dgvChiTietKiemKe.Columns["LyDoChenhLech"].Visible = false;
            dgvChiTietKiemKe.Columns["TenLoaiSanPham"].Visible = false;



        }

        private void dgvChiTietKiemKe_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvChiTietKiemKe.Rows)
            {
                row.Cells["SoThuTu"].Value = row.Index + 1;
            }
        }

        private void btnLuuChiTietKiemKe_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu thông tin kiểm kê?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                // Lấy thông tin chi tiết kiểm kê
                ChiTietKiemKe chiTietKiemKe = new ChiTietKiemKe
                {
                    MaKiemKe = lblMaPhieu.Text,
                    MaSanPham = dgvChiTietKiemKe.CurrentRow.Cells["MaSanPham"].Value.ToString(),
                    SoLuongHeThong = Convert.ToInt32(nudSoLuongHeThong.Value),
                    SoLuongThucTe = Convert.ToInt32(nudSoLuongThucTe.Value),
                    ChenhLech = Convert.ToInt32(nudChenhLech.Value),
                    LyDoChenhLech = txtLyDoChenhLech.Text,
                };

                KiemKe kiemKe = new KiemKe
                {
                    MaKiemKe = lblMaPhieu.Text,
                    MaNhanVien = this.MaNhanVien,
                    GhiChu = txtGhiChu.Text,
                    NgayKiemKe = DateTime.Now
                };
                // Cập nhật thông tin chi tiết kiểm kê và kiểm kê
                if (new ChiTietKiemKeBLL().CapNhatChiTietKiemKe(chiTietKiemKe) && new KiemKeBLL().CapNhatKiemKe(kiemKe))
                {
                    MessageBox.Show("Cập nhật thông tin kiểm kê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    loadDGVChiTietKiemKe(lblMaPhieu.Text);
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin kiểm kê thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDGVKiemKe();
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xuất file Word?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Word Documents (*.docx)|*.docx",
                    FileName = "Báo cáo ngày " + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".docx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Mở tài liệu Word mẫu sẵn
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        string url = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                        var document = wordApp.Documents.Open(url + @"\Resources\BaoCaoKiemKe.docx");

                        // Thay thế các thông tin trong tài liệu Word
                        document.Bookmarks["NgayTao"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        document.Bookmarks["TenNhanVien"].Range.Text = lblTenNVTao.Text;
                        document.Bookmarks["GhiChu"].Range.Text = txtGhiChu.Text;

                        // Lấy bảng đầu tiên trong tài liệu (giả sử bảng đã được định dạng sẵn)
                        var table = document.Tables[1];

                        // Thêm các dòng từ dgvChiTietKiemKe vào bảng
                        for (int i = 0; i < dgvChiTietKiemKe.Rows.Count; i++)
                        {
                            var newRow = table.Rows.Add();  // Thêm dòng mới vào bảng

                            // Chèn dữ liệu từ DataGridView vào các ô của bảng
                            newRow.Cells[1].Range.Text = (i + 1).ToString();
                            newRow.Cells[2].Range.Text = dgvChiTietKiemKe.Rows[i].Cells["TenSanPham"].Value.ToString();
                            newRow.Cells[3].Range.Text = dgvChiTietKiemKe.Rows[i].Cells["SoLuongHethong"].Value.ToString();
                            newRow.Cells[4].Range.Text = dgvChiTietKiemKe.Rows[i].Cells["SoLuongThucte"].Value.ToString();
                            newRow.Cells[5].Range.Text = dgvChiTietKiemKe.Rows[i].Cells["Chenhlech"].Value.ToString();
                            newRow.Cells[6].Range.Text = dgvChiTietKiemKe.Rows[i].Cells["LydoChenhlech"].Value.ToString();
                        }

                        // Lưu tài liệu sau khi thêm dữ liệu
                        document.SaveAs2(saveFileDialog.FileName);
                        document.Close();
                        wordApp.Quit();

                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
