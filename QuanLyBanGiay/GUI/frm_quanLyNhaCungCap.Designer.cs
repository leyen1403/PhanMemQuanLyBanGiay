namespace GUI
{
    partial class frm_quanLyNhaCungCap
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_nhaCC = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_maNCC = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_diaChi = new System.Windows.Forms.TextBox();
            this.txt_tenDaiDien = new System.Windows.Forms.TextBox();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.cbo_trangThai = new System.Windows.Forms.ComboBox();
            this.btn_themNCC = new System.Windows.Forms.Button();
            this.btnDoiHinhAnh = new System.Windows.Forms.Button();
            this.btn_CapNhat = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_ngayTao = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_ngayCapNhat = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_tenNCC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhaCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgv_nhaCC);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(22, 515);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1457, 424);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhà cung cấp";
            // 
            // dgv_nhaCC
            // 
            this.dgv_nhaCC.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_nhaCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_nhaCC.Location = new System.Drawing.Point(6, 26);
            this.dgv_nhaCC.Name = "dgv_nhaCC";
            this.dgv_nhaCC.Size = new System.Drawing.Size(1200, 315);
            this.dgv_nhaCC.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Navy;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(1240, 48);
            this.label13.TabIndex = 44;
            this.label13.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.Navy;
            this.btnTim.Image = global::GUI.Properties.Resources.icons8_find_35;
            this.btnTim.Location = new System.Drawing.Point(544, 453);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(70, 52);
            this.btnTim.TabIndex = 42;
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(25, 464);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(513, 33);
            this.txtTim.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mã nhà cung cấp :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(42, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Họ và tên người đại diện:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(656, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Số điện thoại:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(656, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(656, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 19);
            this.label9.TabIndex = 25;
            this.label9.Text = "Trạng thái:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(656, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "Địa chỉ:";
            // 
            // txt_maNCC
            // 
            this.txt_maNCC.Location = new System.Drawing.Point(266, 35);
            this.txt_maNCC.Name = "txt_maNCC";
            this.txt_maNCC.ReadOnly = true;
            this.txt_maNCC.Size = new System.Drawing.Size(341, 27);
            this.txt_maNCC.TabIndex = 0;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(774, 38);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(414, 27);
            this.txt_email.TabIndex = 7;
            // 
            // txt_diaChi
            // 
            this.txt_diaChi.AcceptsReturn = true;
            this.txt_diaChi.Location = new System.Drawing.Point(774, 78);
            this.txt_diaChi.Name = "txt_diaChi";
            this.txt_diaChi.Size = new System.Drawing.Size(414, 27);
            this.txt_diaChi.TabIndex = 10;
            // 
            // txt_tenDaiDien
            // 
            this.txt_tenDaiDien.Location = new System.Drawing.Point(266, 126);
            this.txt_tenDaiDien.Name = "txt_tenDaiDien";
            this.txt_tenDaiDien.Size = new System.Drawing.Size(341, 27);
            this.txt_tenDaiDien.TabIndex = 1;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(774, 126);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(414, 27);
            this.txt_SDT.TabIndex = 4;
            // 
            // cbo_trangThai
            // 
            this.cbo_trangThai.FormattingEnabled = true;
            this.cbo_trangThai.Items.AddRange(new object[] {
            "Đang hoạt động",
            "Ngưng hoạt động"});
            this.cbo_trangThai.Location = new System.Drawing.Point(774, 182);
            this.cbo_trangThai.Name = "cbo_trangThai";
            this.cbo_trangThai.Size = new System.Drawing.Size(414, 27);
            this.cbo_trangThai.TabIndex = 9;
            // 
            // btn_themNCC
            // 
            this.btn_themNCC.BackColor = System.Drawing.Color.Navy;
            this.btn_themNCC.Image = global::GUI.Properties.Resources.icons8_add_32;
            this.btn_themNCC.Location = new System.Drawing.Point(555, 285);
            this.btn_themNCC.Name = "btn_themNCC";
            this.btn_themNCC.Size = new System.Drawing.Size(70, 60);
            this.btn_themNCC.TabIndex = 12;
            this.btn_themNCC.UseVisualStyleBackColor = false;
            this.btn_themNCC.Click += new System.EventHandler(this.Btn_themNCC_Click);
            // 
            // btnDoiHinhAnh
            // 
            this.btnDoiHinhAnh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoiHinhAnh.Image = global::GUI.Properties.Resources.icons8_update_32;
            this.btnDoiHinhAnh.Location = new System.Drawing.Point(1314, 260);
            this.btnDoiHinhAnh.Name = "btnDoiHinhAnh";
            this.btnDoiHinhAnh.Size = new System.Drawing.Size(70, 60);
            this.btnDoiHinhAnh.TabIndex = 15;
            this.btnDoiHinhAnh.UseVisualStyleBackColor = true;
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.BackColor = System.Drawing.Color.Navy;
            this.btn_CapNhat.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btn_CapNhat.Location = new System.Drawing.Point(687, 285);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(70, 60);
            this.btn_CapNhat.TabIndex = 13;
            this.btn_CapNhat.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Navy;
            this.btnClear.Image = global::GUI.Properties.Resources.icons8_clear_32;
            this.btnClear.Location = new System.Drawing.Point(819, 285);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 60);
            this.btnClear.TabIndex = 14;
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picHinhAnh.Location = new System.Drawing.Point(1247, 30);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(204, 224);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHinhAnh.TabIndex = 11;
            this.picHinhAnh.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(42, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Ngày tạo:";
            // 
            // dtp_ngayTao
            // 
            this.dtp_ngayTao.CustomFormat = "dd/MM/yyyy";
            this.dtp_ngayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ngayTao.Location = new System.Drawing.Point(266, 180);
            this.dtp_ngayTao.Name = "dtp_ngayTao";
            this.dtp_ngayTao.Size = new System.Drawing.Size(203, 27);
            this.dtp_ngayTao.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(42, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 19);
            this.label8.TabIndex = 32;
            this.label8.Text = "Ngày cập nhật:";
            // 
            // dtp_ngayCapNhat
            // 
            this.dtp_ngayCapNhat.CustomFormat = "dd/MM/yyyy";
            this.dtp_ngayCapNhat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ngayCapNhat.Location = new System.Drawing.Point(266, 228);
            this.dtp_ngayCapNhat.Name = "dtp_ngayCapNhat";
            this.dtp_ngayCapNhat.Size = new System.Drawing.Size(203, 27);
            this.dtp_ngayCapNhat.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.txt_tenNCC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtp_ngayCapNhat);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtp_ngayTao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.picHinhAnh);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btn_CapNhat);
            this.groupBox1.Controls.Add(this.btnDoiHinhAnh);
            this.groupBox1.Controls.Add(this.btn_themNCC);
            this.groupBox1.Controls.Add(this.cbo_trangThai);
            this.groupBox1.Controls.Add(this.txt_SDT);
            this.groupBox1.Controls.Add(this.txt_tenDaiDien);
            this.groupBox1.Controls.Add(this.txt_diaChi);
            this.groupBox1.Controls.Add(this.txt_email);
            this.groupBox1.Controls.Add(this.txt_maNCC);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1457, 376);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết nhà cung cấp";
            // 
            // txt_tenNCC
            // 
            this.txt_tenNCC.Location = new System.Drawing.Point(266, 81);
            this.txt_tenNCC.Name = "txt_tenNCC";
            this.txt_tenNCC.Size = new System.Drawing.Size(341, 27);
            this.txt_tenNCC.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(42, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tên nhà cung cấp :";
            // 
            // frm_quanLyNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1240, 857);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox2);
            this.Name = "frm_quanLyNhaCungCap";
            this.Text = "frm_quanLyNhaCungCap";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_nhaCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_maNCC;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_diaChi;
        private System.Windows.Forms.TextBox txt_tenDaiDien;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.ComboBox cbo_trangThai;
        private System.Windows.Forms.Button btn_themNCC;
        private System.Windows.Forms.Button btnDoiHinhAnh;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_ngayTao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_ngayCapNhat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_tenNCC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_nhaCC;
    }
}