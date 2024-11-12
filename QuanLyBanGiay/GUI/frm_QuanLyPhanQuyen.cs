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
            dgvVaiTro.DataSource = new VaiTroBLL().LayDanhSachVaiTro();
            ThemCotSTT(dgvVaiTro);
        }

        private void DgvVaiTro_SelectionChanged(object sender, EventArgs e)
        {
            txtMaVT.Text = dgvVaiTro.CurrentRow.Cells["MaVaiTro"].Value.ToString();
            txtTenVT.Text = dgvVaiTro.CurrentRow.Cells["TenVaiTro"].Value.ToString();
            txtMoTaVT.Text = dgvVaiTro.CurrentRow.Cells["MoTa"].Value.ToString();
        }

        private void BtnCapNhatVaiTro_Click(object sender, EventArgs e)
        {
            string maVaiTro = dgvVaiTro.CurrentRow.Cells["MaVaiTro"].Value.ToString();
            string tenVaiTro = dgvVaiTro.CurrentRow.Cells["TenVaiTro"].Value.ToString();
            string moTa = dgvVaiTro.CurrentRow.Cells["MoTa"].Value.ToString();
            VaiTro vaiTro = new VaiTro()
            {
                MaVaiTro = maVaiTro,
                TenVaiTro = tenVaiTro,
                MoTa = moTa
            };
            if(new VaiTroBLL().CapNhatVaiTro(vaiTro))
            {
                MessageBox.Show("Cập nhật vai trò thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvVaiTro.DataSource = new VaiTroBLL().LayDanhSachVaiTro();
                ThemCotSTT(dgvVaiTro);
            }
            else
            {
                MessageBox.Show("Cập nhật vai trò thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemCotSTT(DataGridView dgv)
        {
            if (!dgv.Columns.Contains("STT"))
            {
                DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
                sttColumn.Name = "STT";
                sttColumn.HeaderText = "STT";
                sttColumn.Width = 80;
                dgv.Columns.Insert(0, sttColumn);
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
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

    }
}
