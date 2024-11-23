namespace GUI
{
    partial class frm_lapThongKeBaoCao
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_xem = new System.Windows.Forms.Button();
            this.dtp_ngayKT = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_ngayBD = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxThongKe = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart_doanhThu = new DevExpress.XtraCharts.ChartControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart_soLuong = new DevExpress.XtraCharts.ChartControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_doanhThu = new System.Windows.Forms.Label();
            this.txt_SoLuong = new System.Windows.Forms.Label();
            this.chkWeek = new System.Windows.Forms.RadioButton();
            this.chkMonth = new System.Windows.Forms.RadioButton();
            this.chkYear = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_doanhThu)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_soLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(1240, 48);
            this.label1.TabIndex = 15;
            this.label1.Text = "LẬP THỐNG KÊ BÁO CÁO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.chkYear);
            this.groupControl1.Controls.Add(this.chkMonth);
            this.groupControl1.Controls.Add(this.chkWeek);
            this.groupControl1.Controls.Add(this.btn_xem);
            this.groupControl1.Controls.Add(this.dtp_ngayKT);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.dtp_ngayBD);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.comboBoxThongKe);
            this.groupControl1.Location = new System.Drawing.Point(12, 70);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(614, 210);
            this.groupControl1.TabIndex = 16;
            this.groupControl1.Text = "Chọn phương thức thống kê";
            // 
            // btn_xem
            // 
            this.btn_xem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xem.ForeColor = System.Drawing.Color.Navy;
            this.btn_xem.Location = new System.Drawing.Point(457, 159);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(126, 32);
            this.btn_xem.TabIndex = 7;
            this.btn_xem.Text = "Xem thống kê";
            this.btn_xem.UseVisualStyleBackColor = true;
            // 
            // dtp_ngayKT
            // 
            this.dtp_ngayKT.Location = new System.Drawing.Point(252, 117);
            this.dtp_ngayKT.Name = "dtp_ngayKT";
            this.dtp_ngayKT.Size = new System.Drawing.Size(343, 21);
            this.dtp_ngayKT.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(12, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 19);
            this.label5.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Chọn ngày kết thúc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chọn ngày bắt đầu";
            // 
            // dtp_ngayBD
            // 
            this.dtp_ngayBD.Location = new System.Drawing.Point(252, 76);
            this.dtp_ngayBD.Name = "dtp_ngayBD";
            this.dtp_ngayBD.Size = new System.Drawing.Size(343, 21);
            this.dtp_ngayBD.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn phương thức thống kê";
            // 
            // comboBoxThongKe
            // 
            this.comboBoxThongKe.FormattingEnabled = true;
            this.comboBoxThongKe.Location = new System.Drawing.Point(252, 37);
            this.comboBoxThongKe.Name = "comboBoxThongKe";
            this.comboBoxThongKe.Size = new System.Drawing.Size(343, 21);
            this.comboBoxThongKe.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart_doanhThu);
            this.panel1.Location = new System.Drawing.Point(13, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 525);
            this.panel1.TabIndex = 19;
            // 
            // chart_doanhThu
            // 
            this.chart_doanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_doanhThu.Location = new System.Drawing.Point(3, 3);
            this.chart_doanhThu.Name = "chart_doanhThu";
            this.chart_doanhThu.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chart_doanhThu.Size = new System.Drawing.Size(787, 519);
            this.chart_doanhThu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.chart_soLuong);
            this.panel2.Location = new System.Drawing.Point(812, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 525);
            this.panel2.TabIndex = 20;
            // 
            // chart_soLuong
            // 
            this.chart_soLuong.Location = new System.Drawing.Point(3, 3);
            this.chart_soLuong.Name = "chart_soLuong";
            this.chart_soLuong.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chart_soLuong.Size = new System.Drawing.Size(397, 519);
            this.chart_soLuong.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Navy;
            this.groupBox1.Controls.Add(this.txt_doanhThu);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(650, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 210);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng doanh thu";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Navy;
            this.groupBox2.Controls.Add(this.txt_SoLuong);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(914, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 210);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tổng số lượng";
            // 
            // txt_doanhThu
            // 
            this.txt_doanhThu.AutoSize = true;
            this.txt_doanhThu.BackColor = System.Drawing.Color.Navy;
            this.txt_doanhThu.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_doanhThu.ForeColor = System.Drawing.Color.AliceBlue;
            this.txt_doanhThu.Location = new System.Drawing.Point(65, 78);
            this.txt_doanhThu.Name = "txt_doanhThu";
            this.txt_doanhThu.Size = new System.Drawing.Size(118, 25);
            this.txt_doanhThu.TabIndex = 8;
            this.txt_doanhThu.Text = "doanh thu";
            // 
            // txt_SoLuong
            // 
            this.txt_SoLuong.AutoSize = true;
            this.txt_SoLuong.BackColor = System.Drawing.Color.Navy;
            this.txt_SoLuong.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SoLuong.ForeColor = System.Drawing.Color.AliceBlue;
            this.txt_SoLuong.Location = new System.Drawing.Point(76, 78);
            this.txt_SoLuong.Name = "txt_SoLuong";
            this.txt_SoLuong.Size = new System.Drawing.Size(102, 25);
            this.txt_SoLuong.TabIndex = 9;
            this.txt_SoLuong.Text = "số lượng";
            // 
            // chkWeek
            // 
            this.chkWeek.AutoSize = true;
            this.chkWeek.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWeek.ForeColor = System.Drawing.Color.Navy;
            this.chkWeek.Location = new System.Drawing.Point(80, 160);
            this.chkWeek.Name = "chkWeek";
            this.chkWeek.Size = new System.Drawing.Size(62, 22);
            this.chkWeek.TabIndex = 8;
            this.chkWeek.TabStop = true;
            this.chkWeek.Text = "Tuần";
            this.chkWeek.UseVisualStyleBackColor = true;
            // 
            // chkMonth
            // 
            this.chkMonth.AutoSize = true;
            this.chkMonth.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMonth.ForeColor = System.Drawing.Color.Navy;
            this.chkMonth.Location = new System.Drawing.Point(190, 160);
            this.chkMonth.Name = "chkMonth";
            this.chkMonth.Size = new System.Drawing.Size(71, 22);
            this.chkMonth.TabIndex = 9;
            this.chkMonth.TabStop = true;
            this.chkMonth.Text = "Tháng";
            this.chkMonth.UseVisualStyleBackColor = true;
            // 
            // chkYear
            // 
            this.chkYear.AutoSize = true;
            this.chkYear.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkYear.ForeColor = System.Drawing.Color.Navy;
            this.chkYear.Location = new System.Drawing.Point(316, 160);
            this.chkYear.Name = "chkYear";
            this.chkYear.Size = new System.Drawing.Size(57, 22);
            this.chkYear.TabIndex = 10;
            this.chkYear.TabStop = true;
            this.chkYear.Text = "năm";
            this.chkYear.UseVisualStyleBackColor = true;
            // 
            // frm_lapThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 857);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.label1);
            this.Name = "frm_lapThongKeBaoCao";
            this.Text = "frm_lapThongKeBaoCao";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_doanhThu)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_soLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraCharts.ChartControl chart_doanhThu;
        private DevExpress.XtraCharts.ChartControl chart_soLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_ngayBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxThongKe;
        private System.Windows.Forms.Button btn_xem;
        private System.Windows.Forms.DateTimePicker dtp_ngayKT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txt_doanhThu;
        private System.Windows.Forms.Label txt_SoLuong;
        private System.Windows.Forms.RadioButton chkYear;
        private System.Windows.Forms.RadioButton chkMonth;
        private System.Windows.Forms.RadioButton chkWeek;
    }
}