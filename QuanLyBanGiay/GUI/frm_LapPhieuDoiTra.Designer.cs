namespace GUI
{
    partial class frm_LapPhieuDoiTra
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgayTao = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietDDH = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoTienHoanLai = new System.Windows.Forms.TextBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.txtMau = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtLoai = new System.Windows.Forms.TextBox();
            this.txtTinhTrangSanPham = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.txtThuongHieu = new System.Windows.Forms.TextBox();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvTraSanPhamChiTiet = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDDH)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraSanPhamChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgayTao);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.txtTenNhanVien);
            this.groupBox1.Controls.Add(this.txtMaHD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(618, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tim thông tin hoá đơn";
            // 
            // dtpNgayTao
            // 
            this.dtpNgayTao.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayTao.Enabled = false;
            this.dtpNgayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayTao.Location = new System.Drawing.Point(203, 130);
            this.dtpNgayTao.Name = "dtpNgayTao";
            this.dtpNgayTao.Size = new System.Drawing.Size(295, 27);
            this.dtpNgayTao.TabIndex = 3;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(504, 54);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(82, 27);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Enabled = false;
            this.txtTenNhanVien.Location = new System.Drawing.Point(203, 208);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(295, 27);
            this.txtTenNhanVien.TabIndex = 1;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(203, 54);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(295, 27);
            this.txtMaHD.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Người lập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ngày lập hoá đơn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hoá đơn:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvChiTietDDH);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 622);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Các mặt hàng đã mua";
            // 
            // dgvChiTietDDH
            // 
            this.dgvChiTietDDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvChiTietDDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietDDH.Location = new System.Drawing.Point(3, 23);
            this.dgvChiTietDDH.Name = "dgvChiTietDDH";
            this.dgvChiTietDDH.Size = new System.Drawing.Size(612, 596);
            this.dgvChiTietDDH.TabIndex = 0;
            this.dgvChiTietDDH.SelectionChanged += new System.EventHandler(this.dgvChiTietDDH_SelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.Controls.Add(this.txtSoTienHoanLai);
            this.groupBox3.Controls.Add(this.nudSoLuong);
            this.groupBox3.Controls.Add(this.txtMau);
            this.groupBox3.Controls.Add(this.txtSize);
            this.groupBox3.Controls.Add(this.txtLoai);
            this.groupBox3.Controls.Add(this.txtTinhTrangSanPham);
            this.groupBox3.Controls.Add(this.txtTenSanPham);
            this.groupBox3.Controls.Add(this.txtThuongHieu);
            this.groupBox3.Controls.Add(this.txtMaSanPham);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(636, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(843, 541);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết sản phẩm";
            // 
            // btnLuu
            // 
            this.btnLuu.AutoSize = true;
            this.btnLuu.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuu.Location = new System.Drawing.Point(476, 468);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(41, 41);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AutoSize = true;
            this.btnXoa.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoa.Location = new System.Drawing.Point(399, 469);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(41, 41);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.AutoSize = true;
            this.btnThem.Image = global::GUI.Properties.Resources.icons8_add_32;
            this.btnThem.Location = new System.Drawing.Point(325, 469);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(38, 38);
            this.btnThem.TabIndex = 4;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoTienHoanLai
            // 
            this.txtSoTienHoanLai.Location = new System.Drawing.Point(178, 416);
            this.txtSoTienHoanLai.Name = "txtSoTienHoanLai";
            this.txtSoTienHoanLai.Size = new System.Drawing.Size(651, 27);
            this.txtSoTienHoanLai.TabIndex = 3;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(201, 341);
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(120, 27);
            this.nudSoLuong.TabIndex = 2;
            // 
            // txtMau
            // 
            this.txtMau.Location = new System.Drawing.Point(651, 36);
            this.txtMau.Name = "txtMau";
            this.txtMau.Size = new System.Drawing.Size(183, 27);
            this.txtMau.TabIndex = 1;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(407, 36);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(183, 27);
            this.txtSize.TabIndex = 1;
            // 
            // txtLoai
            // 
            this.txtLoai.Location = new System.Drawing.Point(549, 112);
            this.txtLoai.Name = "txtLoai";
            this.txtLoai.Size = new System.Drawing.Size(280, 27);
            this.txtLoai.TabIndex = 1;
            // 
            // txtTinhTrangSanPham
            // 
            this.txtTinhTrangSanPham.Location = new System.Drawing.Point(224, 264);
            this.txtTinhTrangSanPham.Multiline = true;
            this.txtTinhTrangSanPham.Name = "txtTinhTrangSanPham";
            this.txtTinhTrangSanPham.Size = new System.Drawing.Size(610, 71);
            this.txtTinhTrangSanPham.TabIndex = 1;
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Location = new System.Drawing.Point(170, 188);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(667, 27);
            this.txtTenSanPham.TabIndex = 1;
            // 
            // txtThuongHieu
            // 
            this.txtThuongHieu.Location = new System.Drawing.Point(158, 112);
            this.txtThuongHieu.Name = "txtThuongHieu";
            this.txtThuongHieu.Size = new System.Drawing.Size(330, 27);
            this.txtThuongHieu.TabIndex = 1;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Location = new System.Drawing.Point(163, 36);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(183, 27);
            this.txtMaSanPham.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(352, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(596, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Màu:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tình trạng sản phẩm:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(35, 419);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Số tiền hoàn lại:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(35, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Số lượng hoàn trả:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thương hiệu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(494, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Loại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Tên sản phẩm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã sản phẩm:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvTraSanPhamChiTiet);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(636, 559);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(843, 375);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách sản phẩm hoàn trả";
            // 
            // dgvTraSanPhamChiTiet
            // 
            this.dgvTraSanPhamChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTraSanPhamChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTraSanPhamChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTraSanPhamChiTiet.Location = new System.Drawing.Point(3, 23);
            this.dgvTraSanPhamChiTiet.Name = "dgvTraSanPhamChiTiet";
            this.dgvTraSanPhamChiTiet.Size = new System.Drawing.Size(837, 349);
            this.dgvTraSanPhamChiTiet.TabIndex = 0;
            this.dgvTraSanPhamChiTiet.SelectionChanged += new System.EventHandler(this.dgvTraSanPhamChiTiet_SelectionChanged);
            // 
            // frm_LapPhieuDoiTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 1015);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_LapPhieuDoiTra";
            this.Text = "frm_LapPhieuDoiTra";
            this.Load += new System.EventHandler(this.frm_LapPhieuDoiTra_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDDH)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTraSanPhamChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNgayTao;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvChiTietDDH;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvTraSanPhamChiTiet;
        private System.Windows.Forms.TextBox txtMau;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtThuongHieu;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSoTienHoanLai;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.TextBox txtLoai;
        private System.Windows.Forms.TextBox txtTinhTrangSanPham;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
    }
}