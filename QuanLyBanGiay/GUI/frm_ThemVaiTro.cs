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
    public partial class frm_ThemVaiTro : Form
    {
        public string TenVaiTro { get; set; }
        public string MoTa { get; set; }
        public event EventHandler Luu;
        public frm_ThemVaiTro()
        {
            InitializeComponent();
            this.btnLuu.Click += BtnLuu_Click;
            this.btnDong.Click += BtnDong_Click;
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (txtTenVaiTro.Text == "")
            {
                MessageBox.Show("Tên vai trò không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMoTa.Text == "")
            {
                MessageBox.Show("Mô tả không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm vai trò này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                this.TenVaiTro = txtTenVaiTro.Text;
                this.MoTa = txtMoTa.Text;
                Luu?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}
