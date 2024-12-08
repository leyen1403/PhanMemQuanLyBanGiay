namespace GUI
{
    partial class frm_themKhachHang
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
            this.cbo_thanhVien = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_diemTichLuy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtp_ngayCapNhat = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtp_ngayTao = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_themKhachHang = new System.Windows.Forms.Button();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cbo_trangThai = new System.Windows.Forms.ComboBox();
            this.cbbGioiTinh = new System.Windows.Forms.ComboBox();
            this.txt_matKhau = new System.Windows.Forms.TextBox();
            this.txt_taiKhoan = new System.Windows.Forms.TextBox();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.txt_tenKhachHang = new System.Windows.Forms.TextBox();
            this.txt_diaChi = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_maKhachHang = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.cbo_thanhVien);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txt_diemTichLuy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.dtp_ngayCapNhat);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtp_ngayTao);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btn_themKhachHang);
            this.groupBox1.Controls.Add(this.dtpNgaySinh);
            this.groupBox1.Controls.Add(this.cbo_trangThai);
            this.groupBox1.Controls.Add(this.cbbGioiTinh);
            this.groupBox1.Controls.Add(this.txt_matKhau);
            this.groupBox1.Controls.Add(this.txt_taiKhoan);
            this.groupBox1.Controls.Add(this.txt_SDT);
            this.groupBox1.Controls.Add(this.txt_tenKhachHang);
            this.groupBox1.Controls.Add(this.txt_diaChi);
            this.groupBox1.Controls.Add(this.txt_email);
            this.groupBox1.Controls.Add(this.txt_maKhachHang);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(38, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1220, 522);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết khách hàng";
            // 
            // cbo_thanhVien
            // 
            this.cbo_thanhVien.FormattingEnabled = true;
            this.cbo_thanhVien.Items.AddRange(new object[] {
            "Đã là thành viên",
            "Chưa là thành viên"});
            this.cbo_thanhVien.Location = new System.Drawing.Point(176, 278);
            this.cbo_thanhVien.Name = "cbo_thanhVien";
            this.cbo_thanhVien.Size = new System.Drawing.Size(254, 27);
            this.cbo_thanhVien.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(38, 282);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 19);
            this.label15.TabIndex = 36;
            this.label15.Text = "Thẻ thành viên";
            // 
            // txt_diemTichLuy
            // 
            this.txt_diemTichLuy.Enabled = false;
            this.txt_diemTichLuy.Location = new System.Drawing.Point(175, 227);
            this.txt_diemTichLuy.Name = "txt_diemTichLuy";
            this.txt_diemTichLuy.Size = new System.Drawing.Size(255, 27);
            this.txt_diemTichLuy.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(42, 230);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 19);
            this.label14.TabIndex = 34;
            this.label14.Text = "Điểm tích luỹ:";
            // 
            // dtp_ngayCapNhat
            // 
            this.dtp_ngayCapNhat.CustomFormat = "dd/MM/yyyy";
            this.dtp_ngayCapNhat.Enabled = false;
            this.dtp_ngayCapNhat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ngayCapNhat.Location = new System.Drawing.Point(464, 178);
            this.dtp_ngayCapNhat.Name = "dtp_ngayCapNhat";
            this.dtp_ngayCapNhat.Size = new System.Drawing.Size(128, 27);
            this.dtp_ngayCapNhat.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(331, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 19);
            this.label8.TabIndex = 32;
            this.label8.Text = "Ngày cập nhật:";
            // 
            // dtp_ngayTao
            // 
            this.dtp_ngayTao.CustomFormat = "dd/MM/yyyy";
            this.dtp_ngayTao.Enabled = false;
            this.dtp_ngayTao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ngayTao.Location = new System.Drawing.Point(178, 179);
            this.dtp_ngayTao.Name = "dtp_ngayTao";
            this.dtp_ngayTao.Size = new System.Drawing.Size(128, 27);
            this.dtp_ngayTao.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(42, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Ngày tạo:";
            // 
            // btn_themKhachHang
            // 
            this.btn_themKhachHang.BackColor = System.Drawing.Color.Navy;
            this.btn_themKhachHang.Image = global::GUI.Properties.Resources.icons8_add_32;
            this.btn_themKhachHang.Location = new System.Drawing.Point(65, 404);
            this.btn_themKhachHang.Name = "btn_themKhachHang";
            this.btn_themKhachHang.Size = new System.Drawing.Size(70, 60);
            this.btn_themKhachHang.TabIndex = 12;
            this.btn_themKhachHang.UseVisualStyleBackColor = false;
            this.btn_themKhachHang.Click += new System.EventHandler(this.btn_themKhachHang_Click);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(464, 130);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(128, 27);
            this.dtpNgaySinh.TabIndex = 3;
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
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.FormattingEnabled = true;
            this.cbbGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbbGioiTinh.Location = new System.Drawing.Point(178, 131);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(128, 27);
            this.cbbGioiTinh.TabIndex = 2;
            // 
            // txt_matKhau
            // 
            this.txt_matKhau.Location = new System.Drawing.Point(774, 281);
            this.txt_matKhau.Name = "txt_matKhau";
            this.txt_matKhau.Size = new System.Drawing.Size(414, 27);
            this.txt_matKhau.TabIndex = 11;
            // 
            // txt_taiKhoan
            // 
            this.txt_taiKhoan.Location = new System.Drawing.Point(774, 227);
            this.txt_taiKhoan.Name = "txt_taiKhoan";
            this.txt_taiKhoan.Size = new System.Drawing.Size(414, 27);
            this.txt_taiKhoan.TabIndex = 5;
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(774, 126);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(414, 27);
            this.txt_SDT.TabIndex = 4;
            // 
            // txt_tenKhachHang
            // 
            this.txt_tenKhachHang.Location = new System.Drawing.Point(178, 83);
            this.txt_tenKhachHang.Name = "txt_tenKhachHang";
            this.txt_tenKhachHang.Size = new System.Drawing.Size(414, 27);
            this.txt_tenKhachHang.TabIndex = 1;
            // 
            // txt_diaChi
            // 
            this.txt_diaChi.AcceptsReturn = true;
            this.txt_diaChi.Location = new System.Drawing.Point(774, 78);
            this.txt_diaChi.Name = "txt_diaChi";
            this.txt_diaChi.Size = new System.Drawing.Size(414, 27);
            this.txt_diaChi.TabIndex = 10;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(774, 38);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(414, 27);
            this.txt_email.TabIndex = 7;
            // 
            // txt_maKhachHang
            // 
            this.txt_maKhachHang.Location = new System.Drawing.Point(178, 35);
            this.txt_maKhachHang.Name = "txt_maKhachHang";
            this.txt_maKhachHang.ReadOnly = true;
            this.txt_maKhachHang.Size = new System.Drawing.Size(414, 27);
            this.txt_maKhachHang.TabIndex = 0;
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(656, 284);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 19);
            this.label12.TabIndex = 27;
            this.label12.Text = "Mật khẩu:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(656, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "Tài khoản:";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(331, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ngày sinh:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(42, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Giới tính:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(42, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Họ và tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(42, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mã khách hàng:";
            // 
            // frm_themKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1325, 625);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_themKhachHang";
            this.Text = "frm_themKhachHang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbo_thanhVien;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_diemTichLuy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dtp_ngayCapNhat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_ngayTao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_themKhachHang;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ComboBox cbo_trangThai;
        private System.Windows.Forms.ComboBox cbbGioiTinh;
        private System.Windows.Forms.TextBox txt_matKhau;
        private System.Windows.Forms.TextBox txt_taiKhoan;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.TextBox txt_tenKhachHang;
        private System.Windows.Forms.TextBox txt_diaChi;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_maKhachHang;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}