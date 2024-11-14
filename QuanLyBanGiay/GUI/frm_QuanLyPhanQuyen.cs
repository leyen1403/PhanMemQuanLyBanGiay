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
    public partial class frm_QuanLyPhanQuyen : Form
    {
        public frm_QuanLyPhanQuyen()
        {
            InitializeComponent();
            this.Load += Frm_QuanLyPhanQuyen_Load;
        }

        private void Frm_QuanLyPhanQuyen_Load(object sender, EventArgs e)
        {
            this.btnThemVaiTro.Click += BtnThemVaiTro_Click;
            this.btnCapNhatVaiTro.Click += BtnCapNhatVaiTro_Click;
            this.dgvVaiTro.SelectionChanged += DgvVaiTro_SelectionChanged;
            this.btnThemQuyen.Click += BtnThemQuyen_Click;
            this.dgvQuyen.SelectionChanged += DgvQuyen_SelectionChanged;
            this.btnLuuQuyen.Click += BtnLuuQuyen_Click;
            this.dgvNhanVien.SelectionChanged += DgvNhanVien_SelectionChanged;
            this.btnLuuNhanVien_VaiTro.Click += BtnLuuNhanVien_VaiTro_Click;
            this.dgvNhanVien_VaiTro.SelectionChanged += DgvNhanVien_VaiTro_SelectionChanged;
            this.dgvVaiTro1.SelectionChanged += DgvVaiTro1_SelectionChanged;
            this.btnLuuVaiTro_Quyen.Click += BtnLuuVaiTro_Quyen_Click;
            this.dgvVaiTro_Quyen.SelectionChanged += DgvVaiTro_Quyen_SelectionChanged;
            loadDanhSachVaiTro(dgvVaiTro);
            loadDanhSachQuyen(dgvQuyen);
            loadDanhSachNhanVien();
            string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            loadDanhSachNhanVien_VaiTro(maNhanVien);
            loadDanhSachVaiTro(dgvVaiTro1);
            string maVaiTro = dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString();
            loadDanhSachVaiTro_Quyen(maVaiTro);
        }

        private void DgvVaiTro_Quyen_SelectionChanged(object sender, EventArgs e)
        {
            txtTenVaiTro1.Text = dgvVaiTro1.CurrentRow.Cells["TenVaiTro"].Value.ToString();
            txtTenQuyen1.Text = dgvVaiTro_Quyen.CurrentRow.Cells["TenQuyen"].Value.ToString();
        }

        private void BtnLuuVaiTro_Quyen_Click(object sender, EventArgs e)
        {
            string maVaiTro = dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString(); 
            string maQuyen = dgvVaiTro_Quyen.CurrentRow.Cells["MaQuyen"].Value.ToString();
            List<string> list = new List<string>();
            foreach (DataGridViewRow row in dgvVaiTro_Quyen.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Chon"].Value))
                {
                    list.Add(row.Cells["MaQuyen"].Value.ToString());
                }
            }
            // Xoá quyền của vai trò có mã maVaiTro
            if (!new VaiTro_QuyenBLL().XoaQuyenRaKhoiVaiTro(maVaiTro))
            {
                MessageBox.Show(Text, "Xóa quyền của vai trò thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Thêm lại quyền vào vai trò
            if (new VaiTro_QuyenBLL().ThemQuyenVaoVaiTro(maVaiTro, list))
            {
                MessageBox.Show("Cập nhật quyền cho vai trò thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSachVaiTro(dgvVaiTro);
                loadDanhSachNhanVien();
                string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                loadDanhSachNhanVien_VaiTro(maNhanVien);
            }
            else
            {
                MessageBox.Show("Cập nhật quyền cho vai trò thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadDanhSachVaiTro_Quyen(string maVaiTro)
        {
            dgvVaiTro_Quyen.DataSource = new QuyenBLL().LayDanhSachQuyen();            
            if (!dgvVaiTro_Quyen.Columns.Contains("Chon"))
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                col.Name = "Chon";
                col.HeaderText = "Chọn";
                dgvVaiTro_Quyen.Columns.Add(col);
            }
            dgvVaiTro_Quyen.Columns["MaQuyen"].HeaderText = "Mã quyền";
            dgvVaiTro_Quyen.Columns["TenQuyen"].HeaderText = "Tên quyền";
            dgvVaiTro_Quyen.Columns["MoTa"].Visible = false;
            List<VaiTro_Quyen> lstVTQ = new VaiTro_QuyenBLL().LayDanhSachVaiTro_Quyen();
            foreach (DataGridViewRow row in dgvVaiTro_Quyen.Rows)
            {
                string maQuyen = row.Cells["MaQuyen"].Value.ToString();
                if (lstVTQ.Any(vqt => vqt.MaVaiTro == maVaiTro && vqt.MaQuyen == maQuyen))
                {
                    row.Cells["Chon"].Value = true;
                }
            }
        }

        private void DgvVaiTro1_SelectionChanged(object sender, EventArgs e)
        {
            string maVaiTro = dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString();
            loadDanhSachVaiTro_Quyen(maVaiTro);
        }

        private void DgvNhanVien_VaiTro_SelectionChanged(object sender, EventArgs e)
        {
            txtTenVaiTro.Text = dgvNhanVien_VaiTro.CurrentRow.Cells["TenVaiTro"].Value.ToString();
        }

        private void BtnLuuNhanVien_VaiTro_Click(object sender, EventArgs e)
        {
            string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            string maVaiTro = dgvNhanVien_VaiTro.CurrentRow.Cells["MaVaiTro"].Value.ToString();
            List<string> list = new List<string>();
            foreach (DataGridViewRow row in dgvNhanVien_VaiTro.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Chon"].Value))
                {
                    list.Add(row.Cells["MaVaiTro"].Value.ToString());
                }
            }
            // Xoá Nhân viên có mã nhân viên tương ứng ra khỏi bảng NhanVien_VaiTro
            if (!new NhanVien_VaiTroBLL().XoaNhanVienKhoiVaiTro(maNhanVien))
            {
                MessageBox.Show(Text, "Xóa nhân viên khỏi vai trò thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Thêm lại nhân viên vào vai trò
            if (new NhanVien_VaiTroBLL().ThemNhanVienVaoVaiTro(maNhanVien, list))
            {
                MessageBox.Show("Cập nhật vai trò cho nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSachNhanVien_VaiTro(maNhanVien);
            }
            else
            {
                MessageBox.Show("Cập nhật vai trò cho nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            loadDanhSachNhanVien_VaiTro(maNhanVien);
            txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
        }

        private void loadDanhSachNhanVien_VaiTro(string maNhanVien)
        {
            dgvNhanVien_VaiTro.DataSource = new VaiTroBLL().LayDanhSachVaiTro();            
            if (!dgvNhanVien_VaiTro.Columns.Contains("Chon"))
            {
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                col.Name = "Chon";
                col.HeaderText = "Chọn";
                dgvNhanVien_VaiTro.Columns.Add(col);
            }
            dgvNhanVien_VaiTro.Columns["MaVaiTro"].HeaderText = "Mã vai trò";
            dgvNhanVien_VaiTro.Columns["TenVaiTro"].HeaderText = "Tên vai trò";
            dgvNhanVien_VaiTro.Columns["MoTa"].Visible = false;
            List<NhanVien_VaiTro> lstNVVT = new NhanVien_VaiTroBLL().LayDanhSachNhanVien_VaiTro();
            foreach (DataGridViewRow row in dgvNhanVien_VaiTro.Rows)
            {
                string maVaiTro = row.Cells["MaVaiTro"].Value.ToString();
                if (lstNVVT.Any(nvvt => nvvt.MaNhanVien == maNhanVien && nvvt.MaVaiTro == maVaiTro))
                {
                    row.Cells["Chon"].Value = true;
                }
            }
        }

        private void loadDanhSachNhanVien()
        {
            dgvNhanVien.DataSource = new NhanVienBLL().LayDanhSachNhanVien();            
            dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns["NgaySinh"].Visible = false;
            dgvNhanVien.Columns["GioiTinh"].Visible = false;
            dgvNhanVien.Columns["SoDienThoai"].Visible = false;
            dgvNhanVien.Columns["Email"].Visible = false;
            dgvNhanVien.Columns["ChucVu"].Visible = false;
            dgvNhanVien.Columns["TaiKhoan"].Visible = false;
            dgvNhanVien.Columns["MatKhau"].Visible = false;
            dgvNhanVien.Columns["HinhAnh"].Visible = false;
            dgvNhanVien.Columns["TrangThaiHoatDong"].Visible = false;
            dgvNhanVien.Columns["NgayTao"].Visible = false;
            dgvNhanVien.Columns["NgayCapNhat"].Visible = false;
            dgvNhanVien.Columns["DiaChi"].Visible = false;

        }

        private void BtnLuuQuyen_Click(object sender, EventArgs e)
        {
            string maQuyen = txtMaQuyen.Text;
            string tenQuyen = txtTenQuyen.Text;
            string moTa = txtMoTaQuyen.Text;
            Quyen quyen = new Quyen()
            {
                MaQuyen = maQuyen,
                TenQuyen = tenQuyen,
                MoTa = moTa
            };
            if (new QuyenBLL().CapNhatQuyen(quyen))
            {
                MessageBox.Show("Cập nhật quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSachQuyen(dgvQuyen);
                loadDanhSachNhanVien();
                string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                loadDanhSachNhanVien_VaiTro(maNhanVien);
                string maVaiTro = dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString();
                loadDanhSachVaiTro_Quyen(maVaiTro);
            }
            else
            {
                MessageBox.Show("Cập nhật quyền thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvQuyen_SelectionChanged(object sender, EventArgs e)
        {
            txtMaQuyen.Text = dgvQuyen.CurrentRow.Cells["MaQuyen"].Value.ToString();
            txtTenQuyen.Text = dgvQuyen.CurrentRow.Cells["TenQuyen"].Value.ToString();
            txtMoTaQuyen.Text = dgvQuyen.CurrentRow.Cells["MoTa"].Value.ToString();
        }

        private void BtnThemQuyen_Click(object sender, EventArgs e)
        {
            frm_ThemQuyen frm = new frm_ThemQuyen();
            frm.Luu += Frm_Luu1;
            frm.ShowDialog();
        }

        private void Frm_Luu1(object sender, EventArgs e)
        {
            List<Quyen> lstQuyen = new QuyenBLL().LayDanhSachQuyen();
            string maQuyen = taoMaQuyen(lstQuyen);
            string tenQuyen = ((frm_ThemQuyen)sender).TenQuyen;
            string moTa = ((frm_ThemQuyen)sender).MoTa;
            Quyen quyen = new Quyen()
            {
                MaQuyen = maQuyen,
                TenQuyen = tenQuyen,
                MoTa = moTa
            };
            if (new QuyenBLL().ThemQuyen(quyen))
            {
                MessageBox.Show("Thêm quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSachNhanVien();
                string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                loadDanhSachNhanVien_VaiTro(maNhanVien);
                string maVaiTro = dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString();
                loadDanhSachVaiTro_Quyen(maVaiTro);
            }
            else
            {
                MessageBox.Show("Thêm quyền thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string taoMaQuyen(List<Quyen> lstQuyen)
        {
            if (lstQuyen.Count == 0)
            {
                return "Q001";
            }
            string maQuyenCuoi = lstQuyen.OrderByDescending(q => q.MaQuyen).FirstOrDefault().MaQuyen;
            string soCuoi = maQuyenCuoi.Substring(1);
            int soMoi = int.Parse(soCuoi) + 1;
            string maQuyenMoi = "Q" + soMoi.ToString().PadLeft(3, '0');
            return maQuyenMoi;
        }

        private void loadDanhSachQuyen(DataGridView dgv)
        {
            dgv.DataSource = new QuyenBLL().LayDanhSachQuyen();
            dgv.Columns["MaQuyen"].HeaderText = "Mã quyền";
            dgv.Columns["TenQuyen"].HeaderText = "Tên quyền";
            dgv.Columns["MoTa"].Visible = false;
        }

        private void DgvVaiTro_SelectionChanged(object sender, EventArgs e)
        {
            txtMaVT.Text = dgvVaiTro.CurrentRow.Cells["MaVaiTro"].Value.ToString();
            txtTenVT.Text = dgvVaiTro.CurrentRow.Cells["TenVaiTro"].Value.ToString();
            txtMoTaVT.Text = dgvVaiTro.CurrentRow.Cells["MoTa"].Value.ToString();
        }

        private void BtnCapNhatVaiTro_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cập nhật vai trò này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maVaiTro = txtMaVT.Text;
                string tenVaiTro = txtTenVT.Text;
                string moTa = txtMoTaVT.Text;
                VaiTro vaiTro = new VaiTro()
                {
                    MaVaiTro = maVaiTro,
                    TenVaiTro = tenVaiTro,
                    MoTa = moTa
                };
                if (new VaiTroBLL().CapNhatVaiTro(vaiTro))
                {
                    MessageBox.Show("Cập nhật vai trò thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDanhSachVaiTro(dgvVaiTro);
                    loadDanhSachNhanVien();
                    string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                    loadDanhSachNhanVien_VaiTro(maNhanVien);
                    string maVaiTroNew = dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString();
                    loadDanhSachVaiTro_Quyen(maVaiTroNew);
                    loadDanhSachVaiTro(dgvVaiTro1);
                }
                else
                {
                    MessageBox.Show("Cập nhật vai trò thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadDanhSachVaiTro(DataGridView dgv)
        {
            dgv.DataSource = new VaiTroBLL().LayDanhSachVaiTro();            
            dgv.Columns["MaVaiTro"].HeaderText = "Mã vai trò";
            dgv.Columns["TenVaiTro"].HeaderText = "Tên vai trò";
            dgv.Columns["MoTa"].Visible = false;
        }

        private void BtnThemVaiTro_Click(object sender, EventArgs e)
        {
            frm_ThemVaiTro frm = new frm_ThemVaiTro();
            frm.Luu += Frm_Luu;
            frm.ShowDialog();

        }

        private void Frm_Luu(object sender, EventArgs e)
        {
            List<VaiTro> lstVaiTro = new VaiTroBLL().LayDanhSachVaiTro();
            string maVaiTro = taoMaVaiTro(lstVaiTro);
            string tenVaiTro = ((frm_ThemVaiTro)sender).TenVaiTro;
            string moTa = ((frm_ThemVaiTro)sender).MoTa;
            VaiTro vaiTro = new VaiTro()
            {
                MaVaiTro = maVaiTro,
                TenVaiTro = tenVaiTro,
                MoTa = moTa
            };
            if (new VaiTroBLL().ThemVaiTro(vaiTro))
            {
                MessageBox.Show("Thêm vai trò thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDanhSachNhanVien();
                loadDanhSachVaiTro(dgvVaiTro);
                string maNhanVien = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                loadDanhSachNhanVien_VaiTro(maNhanVien);
                string maVaiTroNew = dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString();
                loadDanhSachVaiTro_Quyen(maVaiTroNew);
                loadDanhSachVaiTro(dgvVaiTro1);
            }
            else
            {
                MessageBox.Show("Thêm vai trò thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string taoMaVaiTro(List<VaiTro> danhSachVaiTro)
        {
            if (danhSachVaiTro.Count == 0)
            {
                return "VT001";
            }
            string maVaiTroCuoi = danhSachVaiTro.OrderByDescending(vt => vt.MaVaiTro).FirstOrDefault().MaVaiTro;
            string soCuoi = maVaiTroCuoi.Substring(2);
            int soMoi = int.Parse(soCuoi) + 1;
            string maVaiTroMoi = "VT" + soMoi.ToString().PadLeft(3, '0');
            return maVaiTroMoi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            loadDanhSachNhanVien();
            loadDanhSachQuyen(dgvQuyen);
            loadDanhSachVaiTro(dgvVaiTro);
            loadDanhSachNhanVien_VaiTro(dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString());
            loadDanhSachVaiTro(dgvVaiTro1);
            loadDanhSachVaiTro_Quyen(dgvVaiTro1.CurrentRow.Cells["MaVaiTro"].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
