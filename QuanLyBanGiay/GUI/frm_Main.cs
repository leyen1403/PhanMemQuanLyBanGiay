using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frm_Main()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            btn_LapHoaDon.Click += Btn_LapHoaDon_Click;
        }

        private void Btn_LapHoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapHoaDon(), "Lập hoá đơn");
        }
        void loadForm(Form form,string titleLabel)
        {
            this.Text = form.Text;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            mainPanel.Tag = form;
            // Thiết lập tiêu đề của form vào label
            label_tenForm.Text = titleLabel;
            form.BringToFront();
            form.Show();
            
        }
        public void LoadFormIntoPanel(Form form, Panel targetPanel, string titleLabel)
        {
            // Đảm bảo chỉ có một form được đổ vào panel
            if (targetPanel.Controls.Count > 0)
            {
                targetPanel.Controls.Clear();
            }

            // Đặt các thuộc tính cho form con
            form.TopLevel = false; // Đảm bảo form này không phải là form cấp cao nhất
            form.FormBorderStyle = FormBorderStyle.None; // Bỏ viền form
            form.Dock = DockStyle.Fill; // Đổ đầy form vào panel

            // Thêm form vào panel và hiển thị form
            targetPanel.Controls.Add(form);
            form.Show();

          
        }


    }
}
