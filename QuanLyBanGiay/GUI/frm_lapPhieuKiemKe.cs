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

namespace GUI
{
    public partial class frm_lapPhieuKiemKe : Form
    {
        private string maKiemKe;

        public string MaNhanVien { get; set; }
        public frm_lapPhieuKiemKe()
        {
            InitializeComponent();
            Load += Frm_lapPhieuKiemKe_Load;
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
            dgvChiTietKiemKe.SelectionChanged += DgvChiTietKiemKe_SelectionChanged;
        }

        private void Frm_lapPhieuKiemKe_Load(object sender, EventArgs e)
        {
            txtTenNhanVien.Text = new NhanVienBLL().LayNhanVien(MaNhanVien).TenNhanVien;
        }

        private void DgvChiTietKiemKe_SelectionChanged(object sender, EventArgs e)
        {
            hienThiThongTinSanPham();
            trangThaiNutThemXoaSua();
            txtLyDoChenhLech.Text = dgvChiTietKiemKe.CurrentRow.Cells["LyDoChenhLech"].Value.ToString();
        }

        private void DgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            hienThiThongTinSanPham();            
            trangThaiNutThemXoaSua();
            txtLyDoChenhLech.Text = "";
        }

        private void hienThiThongTinSanPham()
        {
            txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();            
            nudSoLuongHeThong.Value = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["SoLuong"].Value.ToString());
            nudSoLuongKiemKe.Value = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["SoLuong"].Value.ToString());
            nudSoLuongChenhLech.Value = tinhSoLuongChenhLech(nudSoLuongHeThong.Value, nudSoLuongKiemKe.Value);
            if (nudSoLuongChenhLech.Value == 0)
            {
                nudSoLuongChenhLech.BackColor = Color.White;
            }
            else
            {
                nudSoLuongChenhLech.BackColor = Color.Red;
            }
        }

        private void trangThaiNutThemXoaSua()
        {
            // Nếu sản phẩm này đã có trong dgvChiTietKiemKe thì ẩn nút thêm, hiện nút xoá và nút lưu
            if (kiemTraSanPhamDaCoTrongDgvChiTietKiemKe(txtMaSanPham.Text))
            {
                btnThemSanPhamVaoPhieuKiemKie.Enabled = false;
                btnXoaSanPhamKhoiPhieuKiemKe.Enabled = true;
                btnCapNhatChiTietPhieuKiemKe.Enabled = true;
            }
            else
            {
                btnThemSanPhamVaoPhieuKiemKie.Enabled = true;
                btnXoaSanPhamKhoiPhieuKiemKe.Enabled = false;
                btnCapNhatChiTietPhieuKiemKe.Enabled = false;
            }
        }

        private bool kiemTraSanPhamDaCoTrongDgvChiTietKiemKe(string maSanPham)
        {
            if(new ChiTietKiemKeBLL().TimSanPhamTrongChiTietKiemKe(maKiemKe, maSanPham))
            {
                return true;
            }
            return false;
        }

        private decimal tinhSoLuongChenhLech(decimal heThong, decimal thucTe)
        {
            return thucTe - heThong;
        }

        private void btnTaoPhieuKiemKe_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo "Bạn có chắc chắn muốn tạo phiếu kiểm kê không?"
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu kiểm kê không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // Tạo mã kiểm kê
                List<KiemKe> lstKiemKe = new KiemKeBLL().LayDanhSachKiemKe();
                maKiemKe = taoMaKiemKe(lstKiemKe);
                KiemKe kiemKe = new KiemKe();
                kiemKe.MaKiemKe = maKiemKe;
                kiemKe.NgayKiemKe = DateTime.Now;
                kiemKe.GhiChu = txtGhiChuPhieuKiemKe.Text;
                kiemKe.TrangThai = true;
                kiemKe.NgayTao = DateTime.Now;
                kiemKe.MaNhanVien = MaNhanVien;
                if(new KiemKeBLL().ThemKiemKe(kiemKe) == false)
                {
                    MessageBox.Show("Tạo phiếu kiểm kê thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Tạo phiếu kiểm kê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Ẩn nút tạo
                btnTaoPhieuKiemKe.Visible = false;

                // Hiển thị các control cần thiết
                txtGhiChuPhieuKiemKe.Enabled = true;                
                btnThemSanPhamVaoPhieuKiemKie.Enabled = true;                
                nudSoLuongKiemKe.Enabled = true;
                dgvSanPham.Enabled = true;
                dgvChiTietKiemKe.Enabled = true;
                cboLoaiSanPham.Enabled = true;
                txtTim.Enabled = true;
                btnTim.Enabled = true;
                btnLuuPhieuKiemKe.Enabled = true;
                // Load sản phẩm vào dgvSanPham
                loadDGVSanPham();
            }
        }

        private void loadDGVSanPham()
        {
            dgvSanPham.DataSource = new SanPhamBLL().layDanhSachSanPham();
            themCotSoThuTu(dgvSanPham);
        }

        private void themCotSoThuTu(DataGridView dgvSanPham)
        {
            // Kiểm tra nếu cột "SoThuTu" đã tồn tại thì không thêm nữa
            if (dgvSanPham.Columns["SoThuTu"] == null)
            {
                // Tạo một cột mới để hiển thị số thứ tự
                DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn();
                soThuTuColumn.Name = "SoThuTu";
                soThuTuColumn.HeaderText = "STT";
                soThuTuColumn.Width = 50;
                soThuTuColumn.ReadOnly = true;

                // Thêm cột vào DataGridView
                dgvSanPham.Columns.Insert(0, soThuTuColumn);
            }

            // Gán số thứ tự cho từng hàng
            for (int i = 0; i < dgvSanPham.Rows.Count; i++)
            {
                dgvSanPham.Rows[i].Cells["SoThuTu"].Value = i + 1;
            }
        }


        private string taoMaKiemKe(List<KiemKe> lstKiemKe)
        {
            if(lstKiemKe.Count <= 0)
            {
                return "KK001";
            }
            int soLuong = lstKiemKe.Count;
            string maKiemKe = "KK" + (soLuong + 1).ToString("000");
            return maKiemKe;

        }

        private void btnThemSanPhamVaoPhieuKiemKie_Click(object sender, EventArgs e)
        {
            // Hiện thông báo "Bạn có chắc chắn muốn thêm sản phẩm vào phiếu kiểm kê không?"
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm vào phiếu kiểm kê không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // Kiểm tra số lượng kiểm kê có lớn hơn 0 không
                if (nudSoLuongKiemKe.Value <= 0)
                {
                    MessageBox.Show("Số lượng kiểm kê phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm sản phẩm vào dgvChiTietKiemKe
                ChiTietKiemKe chiTietKiemKe = new ChiTietKiemKe();
                chiTietKiemKe.MaKiemKe = maKiemKe;
                chiTietKiemKe.MaSanPham = txtMaSanPham.Text;
                chiTietKiemKe.SoLuongHeThong = Convert.ToInt32(nudSoLuongHeThong.Value);
                chiTietKiemKe.SoLuongThucTe = Convert.ToInt32(nudSoLuongKiemKe.Value);
                chiTietKiemKe.ChenhLech = Convert.ToInt32(nudSoLuongChenhLech.Value);
                chiTietKiemKe.LyDoChenhLech = txtLyDoChenhLech.Text;
                if (new ChiTietKiemKeBLL().ThemChiTietKiemKe(chiTietKiemKe) == false)
                {
                    MessageBox.Show("Thêm sản phẩm vào phiếu kiểm kê thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Thêm sản phẩm vào phiếu kiểm kê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Load lại dgvChiTietKiemKe
                loadDGVChiTietKiemKe();
            }
        }

        private void loadDGVChiTietKiemKe()
        {
            dgvChiTietKiemKe.DataSource = new ChiTietKiemKeBLL().LayDanhSachChiTietKiemKe(maKiemKe);
            themCotSoThuTu(dgvChiTietKiemKe);
        }

        private void btnXoaSanPhamKhoiPhieuKiemKe_Click(object sender, EventArgs e)
        {
            ChiTietKiemKe ctkk = new ChiTietKiemKe();
            ctkk.MaKiemKe = maKiemKe;
            ctkk.MaSanPham = txtMaSanPham.Text;
            if (new ChiTietKiemKeBLL().XoaChiTietKiemKe(ctkk) == false)
            {
                MessageBox.Show("Xoá sản phẩm khỏi phiếu kiểm kê thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Xoá sản phẩm khỏi phiếu kiểm kê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Load lại dgvChiTietKiemKe
            loadDGVChiTietKiemKe();
        }

        private void btnCapNhatChiTietPhieuKiemKe_Click(object sender, EventArgs e)
        {
            ChiTietKiemKe ctkk = new ChiTietKiemKe();
            ctkk.MaKiemKe = maKiemKe;
            ctkk.MaSanPham = txtMaSanPham.Text;
            ctkk.SoLuongHeThong = Convert.ToInt32(nudSoLuongHeThong.Value);
            ctkk.SoLuongThucTe = Convert.ToInt32(nudSoLuongKiemKe.Value);
            ctkk.ChenhLech = Convert.ToInt32(nudSoLuongChenhLech.Value);
            ctkk.LyDoChenhLech = txtLyDoChenhLech.Text;
            if (new ChiTietKiemKeBLL().CapNhatChiTietKiemKe(ctkk) == false)
            {
                MessageBox.Show("Cập nhật chi tiết phiếu kiểm kê thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Cập nhật chi tiết phiếu kiểm kê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Load lại dgvChiTietKiemKe
            loadDGVChiTietKiemKe();
        }

        private void btnLuuPhieuKiemKe_Click(object sender, EventArgs e)
        {
            KiemKe kiemKe = new KiemKe();
            kiemKe.MaKiemKe = maKiemKe;
            kiemKe.NgayKiemKe = DateTime.Now;
            kiemKe.GhiChu = txtGhiChuPhieuKiemKe.Text;
            kiemKe.MaNhanVien = MaNhanVien;
            // Hiện thông báo "Bạn có chắc chắn muốn lưu phiếu kiểm kê không?"
            if (new KiemKeBLL().CapNhatKiemKe(kiemKe) == false)
            {
                MessageBox.Show("Lưu phiếu kiểm kê thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Lưu phiếu kiểm kê thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }
    }
}
