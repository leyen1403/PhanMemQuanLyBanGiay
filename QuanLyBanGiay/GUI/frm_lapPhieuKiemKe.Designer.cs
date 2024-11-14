namespace GUI
{
    partial class frm_lapPhieuKiemKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnTaoPhieuKiemKe = new System.Windows.Forms.Button();
            this.btnLuuPhieuKiemKe = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGhiChuPhieuKiemKe = new System.Windows.Forms.TextBox();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietKiemKe = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudSoLuongChenhLech = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuongKiemKe = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuongHeThong = new System.Windows.Forms.NumericUpDown();
            this.btnXoaSanPhamKhoiPhieuKiemKe = new System.Windows.Forms.Button();
            this.btnThemSanPhamVaoPhieuKiemKie = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.cboLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnCapNhatChiTietPhieuKiemKe = new System.Windows.Forms.Button();
            this.txtLyDoChenhLech = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietKiemKe)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongChenhLech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongKiemKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongHeThong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1364, 48);
            this.label1.TabIndex = 8;
            this.label1.Text = "LẬP PHIỂU KIỂM KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTaoPhieuKiemKe
            // 
            this.btnTaoPhieuKiemKe.Image = global::GUI.Properties.Resources.icons8_add_32;
            this.btnTaoPhieuKiemKe.Location = new System.Drawing.Point(6, 19);
            this.btnTaoPhieuKiemKe.Name = "btnTaoPhieuKiemKe";
            this.btnTaoPhieuKiemKe.Size = new System.Drawing.Size(70, 60);
            this.btnTaoPhieuKiemKe.TabIndex = 9;
            this.btnTaoPhieuKiemKe.UseVisualStyleBackColor = true;
            this.btnTaoPhieuKiemKe.Click += new System.EventHandler(this.btnTaoPhieuKiemKe_Click);
            // 
            // btnLuuPhieuKiemKe
            // 
            this.btnLuuPhieuKiemKe.Enabled = false;
            this.btnLuuPhieuKiemKe.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuuPhieuKiemKe.Location = new System.Drawing.Point(6, 85);
            this.btnLuuPhieuKiemKe.Name = "btnLuuPhieuKiemKe";
            this.btnLuuPhieuKiemKe.Size = new System.Drawing.Size(70, 60);
            this.btnLuuPhieuKiemKe.TabIndex = 9;
            this.btnLuuPhieuKiemKe.UseVisualStyleBackColor = true;
            this.btnLuuPhieuKiemKe.Click += new System.EventHandler(this.btnLuuPhieuKiemKe_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGhiChuPhieuKiemKe);
            this.groupBox1.Controls.Add(this.txtTenNhanVien);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnTaoPhieuKiemKe);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnLuuPhieuKiemKe);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 218);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // txtGhiChuPhieuKiemKe
            // 
            this.txtGhiChuPhieuKiemKe.Location = new System.Drawing.Point(204, 103);
            this.txtGhiChuPhieuKiemKe.Multiline = true;
            this.txtGhiChuPhieuKiemKe.Name = "txtGhiChuPhieuKiemKe";
            this.txtGhiChuPhieuKiemKe.Size = new System.Drawing.Size(283, 108);
            this.txtGhiChuPhieuKiemKe.TabIndex = 11;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Enabled = false;
            this.txtTenNhanVien.Location = new System.Drawing.Point(204, 37);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(283, 27);
            this.txtTenNhanVien.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ghi chú:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tên nhân viên:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Image = global::GUI.Properties.Resources.icons8_refresh_32;
            this.btnRefresh.Location = new System.Drawing.Point(6, 151);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 60);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSanPham);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 341);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 550);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm của cửa hàng";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSanPham.Enabled = false;
            this.dgvSanPham.Location = new System.Drawing.Point(3, 23);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.Size = new System.Drawing.Size(713, 524);
            this.dgvSanPham.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvChiTietKiemKe);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(734, 341);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(618, 550);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sản phẩm trong phiếu kiểm kê";
            // 
            // dgvChiTietKiemKe
            // 
            this.dgvChiTietKiemKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietKiemKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietKiemKe.Enabled = false;
            this.dgvChiTietKiemKe.Location = new System.Drawing.Point(3, 23);
            this.dgvChiTietKiemKe.Name = "dgvChiTietKiemKe";
            this.dgvChiTietKiemKe.Size = new System.Drawing.Size(612, 524);
            this.dgvChiTietKiemKe.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLyDoChenhLech);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.nudSoLuongChenhLech);
            this.groupBox4.Controls.Add(this.nudSoLuongKiemKe);
            this.groupBox4.Controls.Add(this.nudSoLuongHeThong);
            this.groupBox4.Controls.Add(this.btnCapNhatChiTietPhieuKiemKe);
            this.groupBox4.Controls.Add(this.btnXoaSanPhamKhoiPhieuKiemKe);
            this.groupBox4.Controls.Add(this.btnThemSanPhamVaoPhieuKiemKie);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtTenSanPham);
            this.groupBox4.Controls.Add(this.txtMaSanPham);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(536, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(816, 218);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin sản phẩm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(511, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Số lượng chênh lệch:";
            // 
            // nudSoLuongChenhLech
            // 
            this.nudSoLuongChenhLech.Enabled = false;
            this.nudSoLuongChenhLech.Location = new System.Drawing.Point(690, 118);
            this.nudSoLuongChenhLech.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuongChenhLech.Name = "nudSoLuongChenhLech";
            this.nudSoLuongChenhLech.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuongChenhLech.TabIndex = 12;
            // 
            // nudSoLuongKiemKe
            // 
            this.nudSoLuongKiemKe.Enabled = false;
            this.nudSoLuongKiemKe.Location = new System.Drawing.Point(690, 78);
            this.nudSoLuongKiemKe.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuongKiemKe.Name = "nudSoLuongKiemKe";
            this.nudSoLuongKiemKe.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuongKiemKe.TabIndex = 12;
            // 
            // nudSoLuongHeThong
            // 
            this.nudSoLuongHeThong.Enabled = false;
            this.nudSoLuongHeThong.Location = new System.Drawing.Point(690, 38);
            this.nudSoLuongHeThong.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSoLuongHeThong.Name = "nudSoLuongHeThong";
            this.nudSoLuongHeThong.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuongHeThong.TabIndex = 12;
            // 
            // btnXoaSanPhamKhoiPhieuKiemKe
            // 
            this.btnXoaSanPhamKhoiPhieuKiemKe.Enabled = false;
            this.btnXoaSanPhamKhoiPhieuKiemKe.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaSanPhamKhoiPhieuKiemKe.Location = new System.Drawing.Point(593, 161);
            this.btnXoaSanPhamKhoiPhieuKiemKe.Name = "btnXoaSanPhamKhoiPhieuKiemKe";
            this.btnXoaSanPhamKhoiPhieuKiemKe.Size = new System.Drawing.Size(52, 50);
            this.btnXoaSanPhamKhoiPhieuKiemKe.TabIndex = 9;
            this.btnXoaSanPhamKhoiPhieuKiemKe.UseVisualStyleBackColor = true;
            this.btnXoaSanPhamKhoiPhieuKiemKe.Click += new System.EventHandler(this.btnXoaSanPhamKhoiPhieuKiemKe_Click);
            // 
            // btnThemSanPhamVaoPhieuKiemKie
            // 
            this.btnThemSanPhamVaoPhieuKiemKie.Enabled = false;
            this.btnThemSanPhamVaoPhieuKiemKie.Image = global::GUI.Properties.Resources.icons8_add_32;
            this.btnThemSanPhamVaoPhieuKiemKie.Location = new System.Drawing.Point(517, 161);
            this.btnThemSanPhamVaoPhieuKiemKie.Name = "btnThemSanPhamVaoPhieuKiemKie";
            this.btnThemSanPhamVaoPhieuKiemKie.Size = new System.Drawing.Size(52, 50);
            this.btnThemSanPhamVaoPhieuKiemKie.TabIndex = 9;
            this.btnThemSanPhamVaoPhieuKiemKie.UseVisualStyleBackColor = true;
            this.btnThemSanPhamVaoPhieuKiemKie.Click += new System.EventHandler(this.btnThemSanPhamVaoPhieuKiemKie_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(511, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Số lượng kiểm kê:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số lượng hệ thống:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tên sản phẩm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mã sản phẩm:";
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Enabled = false;
            this.txtTenSanPham.Location = new System.Drawing.Point(159, 81);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(346, 27);
            this.txtTenSanPham.TabIndex = 11;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Enabled = false;
            this.txtMaSanPham.Location = new System.Drawing.Point(159, 37);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(346, 27);
            this.txtMaSanPham.TabIndex = 11;
            // 
            // cboLoaiSanPham
            // 
            this.cboLoaiSanPham.Enabled = false;
            this.cboLoaiSanPham.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiSanPham.FormattingEnabled = true;
            this.cboLoaiSanPham.Location = new System.Drawing.Point(12, 293);
            this.cboLoaiSanPham.Name = "cboLoaiSanPham";
            this.cboLoaiSanPham.Size = new System.Drawing.Size(304, 27);
            this.cboLoaiSanPham.TabIndex = 13;
            // 
            // txtTim
            // 
            this.txtTim.Enabled = false;
            this.txtTim.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(322, 293);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(304, 27);
            this.txtTim.TabIndex = 14;
            // 
            // btnTim
            // 
            this.btnTim.Enabled = false;
            this.btnTim.Image = global::GUI.Properties.Resources.icons8_find_35;
            this.btnTim.Location = new System.Drawing.Point(632, 275);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(70, 60);
            this.btnTim.TabIndex = 9;
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // btnCapNhatChiTietPhieuKiemKe
            // 
            this.btnCapNhatChiTietPhieuKiemKe.Enabled = false;
            this.btnCapNhatChiTietPhieuKiemKe.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnCapNhatChiTietPhieuKiemKe.Location = new System.Drawing.Point(669, 161);
            this.btnCapNhatChiTietPhieuKiemKe.Name = "btnCapNhatChiTietPhieuKiemKe";
            this.btnCapNhatChiTietPhieuKiemKe.Size = new System.Drawing.Size(52, 50);
            this.btnCapNhatChiTietPhieuKiemKe.TabIndex = 9;
            this.btnCapNhatChiTietPhieuKiemKe.UseVisualStyleBackColor = true;
            this.btnCapNhatChiTietPhieuKiemKe.Click += new System.EventHandler(this.btnCapNhatChiTietPhieuKiemKe_Click);
            // 
            // txtLyDoChenhLech
            // 
            this.txtLyDoChenhLech.Location = new System.Drawing.Point(159, 118);
            this.txtLyDoChenhLech.Multiline = true;
            this.txtLyDoChenhLech.Name = "txtLyDoChenhLech";
            this.txtLyDoChenhLech.Size = new System.Drawing.Size(346, 93);
            this.txtLyDoChenhLech.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "Lý do chênh lệch";
            // 
            // frm_lapPhieuKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 903);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cboLoaiSanPham);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_lapPhieuKiemKe";
            this.Text = "frm_lapPhieuKiemKe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietKiemKe)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongChenhLech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongKiemKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongHeThong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTaoPhieuKiemKe;
        private System.Windows.Forms.Button btnLuuPhieuKiemKe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtGhiChuPhieuKiemKe;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvChiTietKiemKe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudSoLuongChenhLech;
        private System.Windows.Forms.NumericUpDown nudSoLuongKiemKe;
        private System.Windows.Forms.NumericUpDown nudSoLuongHeThong;
        private System.Windows.Forms.Button btnThemSanPhamVaoPhieuKiemKie;
        private System.Windows.Forms.ComboBox cboLoaiSanPham;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnXoaSanPhamKhoiPhieuKiemKe;
        private System.Windows.Forms.Button btnCapNhatChiTietPhieuKiemKe;
        private System.Windows.Forms.TextBox txtLyDoChenhLech;
        private System.Windows.Forms.Label label9;
    }
}