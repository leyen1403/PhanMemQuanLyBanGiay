namespace GUI
{
    partial class frm_quanLyPhieuKiemKe
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvKiemKe = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietKiemKe = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnXuatWord = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLuuChiTietKiemKe = new System.Windows.Forms.Button();
            this.txtLyDoChenhLech = new System.Windows.Forms.TextBox();
            this.nudChenhLech = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuongThucTe = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuongHeThong = new System.Windows.Forms.NumericUpDown();
            this.lblTenSanPham = new System.Windows.Forms.Label();
            this.lblTenLoai = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTenNVTao = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemKe)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietKiemKe)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChenhLech)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongThucTe)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(1446, 48);
            this.label1.TabIndex = 13;
            this.label1.Text = "QUẢN LÝ PHIẾU KIỂM KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvKiemKe);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 494);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu kiểm kê";
            // 
            // dgvKiemKe
            // 
            this.dgvKiemKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKiemKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKiemKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKiemKe.Location = new System.Drawing.Point(3, 23);
            this.dgvKiemKe.Name = "dgvKiemKe";
            this.dgvKiemKe.ReadOnly = true;
            this.dgvKiemKe.Size = new System.Drawing.Size(643, 468);
            this.dgvKiemKe.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgvChiTietKiemKe);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 551);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(643, 277);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết phiếu kiểm kê";
            // 
            // dgvChiTietKiemKe
            // 
            this.dgvChiTietKiemKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietKiemKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietKiemKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietKiemKe.Location = new System.Drawing.Point(3, 23);
            this.dgvChiTietKiemKe.Name = "dgvChiTietKiemKe";
            this.dgvChiTietKiemKe.ReadOnly = true;
            this.dgvChiTietKiemKe.Size = new System.Drawing.Size(637, 251);
            this.dgvChiTietKiemKe.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.txtGhiChu);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblTenNVTao);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblNgayTao);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblMaPhieu);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(667, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 534);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chi tiết";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnXuatWord);
            this.groupBox4.Controls.Add(this.btnRefresh);
            this.groupBox4.Controls.Add(this.btnLuuChiTietKiemKe);
            this.groupBox4.Controls.Add(this.txtLyDoChenhLech);
            this.groupBox4.Controls.Add(this.nudChenhLech);
            this.groupBox4.Controls.Add(this.nudSoLuongThucTe);
            this.groupBox4.Controls.Add(this.nudSoLuongHeThong);
            this.groupBox4.Controls.Add(this.lblTenSanPham);
            this.groupBox4.Controls.Add(this.lblTenLoai);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(19, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(733, 365);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin sản phẩm";
            // 
            // btnXuatWord
            // 
            this.btnXuatWord.Image = global::GUI.Properties.Resources.icons8_word_32;
            this.btnXuatWord.Location = new System.Drawing.Point(313, 298);
            this.btnXuatWord.Name = "btnXuatWord";
            this.btnXuatWord.Size = new System.Drawing.Size(70, 60);
            this.btnXuatWord.TabIndex = 10;
            this.btnXuatWord.UseVisualStyleBackColor = true;
            this.btnXuatWord.Click += new System.EventHandler(this.btnXuatWord_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::GUI.Properties.Resources.icons8_refresh_32;
            this.btnRefresh.Location = new System.Drawing.Point(237, 298);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 60);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLuuChiTietKiemKe
            // 
            this.btnLuuChiTietKiemKe.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuuChiTietKiemKe.Location = new System.Drawing.Point(161, 298);
            this.btnLuuChiTietKiemKe.Name = "btnLuuChiTietKiemKe";
            this.btnLuuChiTietKiemKe.Size = new System.Drawing.Size(70, 60);
            this.btnLuuChiTietKiemKe.TabIndex = 10;
            this.btnLuuChiTietKiemKe.UseVisualStyleBackColor = true;
            this.btnLuuChiTietKiemKe.Click += new System.EventHandler(this.btnLuuChiTietKiemKe_Click);
            // 
            // txtLyDoChenhLech
            // 
            this.txtLyDoChenhLech.Location = new System.Drawing.Point(161, 179);
            this.txtLyDoChenhLech.Multiline = true;
            this.txtLyDoChenhLech.Name = "txtLyDoChenhLech";
            this.txtLyDoChenhLech.Size = new System.Drawing.Size(545, 113);
            this.txtLyDoChenhLech.TabIndex = 2;
            // 
            // nudChenhLech
            // 
            this.nudChenhLech.Enabled = false;
            this.nudChenhLech.Location = new System.Drawing.Point(633, 117);
            this.nudChenhLech.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudChenhLech.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudChenhLech.Name = "nudChenhLech";
            this.nudChenhLech.Size = new System.Drawing.Size(94, 27);
            this.nudChenhLech.TabIndex = 1;
            // 
            // nudSoLuongThucTe
            // 
            this.nudSoLuongThucTe.Location = new System.Drawing.Point(430, 117);
            this.nudSoLuongThucTe.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSoLuongThucTe.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudSoLuongThucTe.Name = "nudSoLuongThucTe";
            this.nudSoLuongThucTe.Size = new System.Drawing.Size(94, 27);
            this.nudSoLuongThucTe.TabIndex = 1;
            // 
            // nudSoLuongHeThong
            // 
            this.nudSoLuongHeThong.Enabled = false;
            this.nudSoLuongHeThong.Location = new System.Drawing.Point(175, 117);
            this.nudSoLuongHeThong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSoLuongHeThong.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nudSoLuongHeThong.Name = "nudSoLuongHeThong";
            this.nudSoLuongHeThong.Size = new System.Drawing.Size(94, 27);
            this.nudSoLuongHeThong.TabIndex = 1;
            // 
            // lblTenSanPham
            // 
            this.lblTenSanPham.AutoSize = true;
            this.lblTenSanPham.Location = new System.Drawing.Point(141, 35);
            this.lblTenSanPham.Name = "lblTenSanPham";
            this.lblTenSanPham.Size = new System.Drawing.Size(139, 19);
            this.lblTenSanPham.TabIndex = 0;
            this.lblTenSanPham.Text = "Tên sản phẩm abc";
            // 
            // lblTenLoai
            // 
            this.lblTenLoai.AutoSize = true;
            this.lblTenLoai.Location = new System.Drawing.Point(61, 74);
            this.lblTenLoai.Name = "lblTenLoai";
            this.lblTenLoai.Size = new System.Drawing.Size(66, 19);
            this.lblTenLoai.TabIndex = 0;
            this.lblTenLoai.Text = "Tên loại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(530, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Chênh lệch:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(275, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Số lượng thực tế:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(6, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Lý do chênh lệch:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(6, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số lượng hệ thống:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(6, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Loại:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(6, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tên sản phẩm:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Location = new System.Drawing.Point(367, 30);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(394, 105);
            this.txtGhiChu.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ghi chú:";
            // 
            // lblTenNVTao
            // 
            this.lblTenNVTao.AutoSize = true;
            this.lblTenNVTao.Location = new System.Drawing.Point(149, 116);
            this.lblTenNVTao.Name = "lblTenNVTao";
            this.lblTenNVTao.Size = new System.Drawing.Size(107, 19);
            this.lblTenNVTao.TabIndex = 0;
            this.lblTenNVTao.Text = "Lê Thanh Yên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(15, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhân viên tạo:";
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Location = new System.Drawing.Point(109, 74);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(93, 19);
            this.lblNgayTao.TabIndex = 0;
            this.lblNgayTao.Text = "31/12/2020";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày tạo:";
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Location = new System.Drawing.Point(110, 33);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(54, 19);
            this.lblMaPhieu.TabIndex = 0;
            this.lblMaPhieu.Text = "KK001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(15, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã phiếu:";
            // 
            // frm_quanLyPhieuKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1446, 857);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_quanLyPhieuKiemKe";
            this.Text = "frm_quanLyPhieuKiemKe";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemKe)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietKiemKe)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudChenhLech)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongThucTe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongHeThong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvKiemKe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvChiTietKiemKe;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTenSanPham;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblTenNVTao;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.Label lblTenLoai;
        private System.Windows.Forms.NumericUpDown nudSoLuongHeThong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudChenhLech;
        private System.Windows.Forms.NumericUpDown nudSoLuongThucTe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLyDoChenhLech;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLuuChiTietKiemKe;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnXuatWord;
    }
}