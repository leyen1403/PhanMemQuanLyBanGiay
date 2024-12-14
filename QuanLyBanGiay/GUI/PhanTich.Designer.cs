namespace GUI
{
    partial class PhanTich
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartPhanTich = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.btnPhanTich = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDistanceMethod = new System.Windows.Forms.ComboBox();
            this.txt_soCum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkProductsPurchased = new System.Windows.Forms.CheckBox();
            this.chkSpending = new System.Windows.Forms.CheckBox();
            this.chkLoyaltyPoints = new System.Windows.Forms.CheckBox();
            this.chkAge = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_khachHang = new System.Windows.Forms.TextBox();
            this.txt_tuoi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SoTien = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_SL = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_diem = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_xem = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhanTich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soCum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartPhanTich
            // 
            this.chartPhanTich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartPhanTich.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPhanTich.Legends.Add(legend1);
            this.chartPhanTich.Location = new System.Drawing.Point(32, 85);
            this.chartPhanTich.Name = "chartPhanTich";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPhanTich.Series.Add(series1);
            this.chartPhanTich.Size = new System.Drawing.Size(748, 708);
            this.chartPhanTich.TabIndex = 0;
            this.chartPhanTich.Text = "chart1";
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(837, 215);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.Size = new System.Drawing.Size(641, 387);
            this.dataGridViewData.TabIndex = 1;
            // 
            // btnPhanTich
            // 
            this.btnPhanTich.Location = new System.Drawing.Point(396, 78);
            this.btnPhanTich.Name = "btnPhanTich";
            this.btnPhanTich.Size = new System.Drawing.Size(99, 40);
            this.btnPhanTich.TabIndex = 2;
            this.btnPhanTich.Text = "Phân tích";
            this.btnPhanTich.UseVisualStyleBackColor = true;
            this.btnPhanTich.Click += new System.EventHandler(this.btnPhanTich_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbDistanceMethod);
            this.groupBox1.Controls.Add(this.txt_soCum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkProductsPurchased);
            this.groupBox1.Controls.Add(this.chkSpending);
            this.groupBox1.Controls.Add(this.chkLoyaltyPoints);
            this.groupBox1.Controls.Add(this.chkAge);
            this.groupBox1.Controls.Add(this.btnPhanTich);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(837, 608);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(641, 185);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn phân loại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Chọn tính khoảng cách";
            // 
            // cmbDistanceMethod
            // 
            this.cmbDistanceMethod.FormattingEnabled = true;
            this.cmbDistanceMethod.Items.AddRange(new object[] {
            "Euclidean",
            "Manhattan",
            "Cosine"});
            this.cmbDistanceMethod.Location = new System.Drawing.Point(250, 107);
            this.cmbDistanceMethod.Name = "cmbDistanceMethod";
            this.cmbDistanceMethod.Size = new System.Drawing.Size(121, 28);
            this.cmbDistanceMethod.TabIndex = 10;
            // 
            // txt_soCum
            // 
            this.txt_soCum.Location = new System.Drawing.Point(250, 68);
            this.txt_soCum.Name = "txt_soCum";
            this.txt_soCum.Size = new System.Drawing.Size(120, 26);
            this.txt_soCum.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số lượng cụm";
            // 
            // chkProductsPurchased
            // 
            this.chkProductsPurchased.AutoSize = true;
            this.chkProductsPurchased.Location = new System.Drawing.Point(396, 33);
            this.chkProductsPurchased.Name = "chkProductsPurchased";
            this.chkProductsPurchased.Size = new System.Drawing.Size(200, 24);
            this.chkProductsPurchased.TabIndex = 6;
            this.chkProductsPurchased.Text = "Số lượng sản phẩm mua";
            this.chkProductsPurchased.UseVisualStyleBackColor = true;
            // 
            // chkSpending
            // 
            this.chkSpending.AutoSize = true;
            this.chkSpending.Location = new System.Drawing.Point(286, 33);
            this.chkSpending.Name = "chkSpending";
            this.chkSpending.Size = new System.Drawing.Size(102, 24);
            this.chkSpending.TabIndex = 5;
            this.chkSpending.Text = "Số tiền chi";
            this.chkSpending.UseVisualStyleBackColor = true;
            // 
            // chkLoyaltyPoints
            // 
            this.chkLoyaltyPoints.AutoSize = true;
            this.chkLoyaltyPoints.Location = new System.Drawing.Point(149, 33);
            this.chkLoyaltyPoints.Name = "chkLoyaltyPoints";
            this.chkLoyaltyPoints.Size = new System.Drawing.Size(117, 24);
            this.chkLoyaltyPoints.TabIndex = 4;
            this.chkLoyaltyPoints.Text = "Điểm tích luỹ";
            this.chkLoyaltyPoints.UseVisualStyleBackColor = true;
            // 
            // chkAge
            // 
            this.chkAge.AutoSize = true;
            this.chkAge.Location = new System.Drawing.Point(74, 33);
            this.chkAge.Name = "chkAge";
            this.chkAge.Size = new System.Drawing.Size(58, 24);
            this.chkAge.TabIndex = 3;
            this.chkAge.Text = "Tuổi";
            this.chkAge.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MidnightBlue;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1478, 48);
            this.label3.TabIndex = 6;
            this.label3.Text = "TẠO PHIẾU ĐỔI TRẢ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.btn_clear);
            this.groupBox2.Controls.Add(this.txt_diem);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btn_xem);
            this.groupBox2.Controls.Add(this.txt_SL);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_SoTien);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txt_tuoi);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_khachHang);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(837, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 139);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên khách hàng";
            // 
            // txt_khachHang
            // 
            this.txt_khachHang.Location = new System.Drawing.Point(149, 20);
            this.txt_khachHang.Name = "txt_khachHang";
            this.txt_khachHang.Size = new System.Drawing.Size(145, 26);
            this.txt_khachHang.TabIndex = 1;
            // 
            // txt_tuoi
            // 
            this.txt_tuoi.Location = new System.Drawing.Point(149, 61);
            this.txt_tuoi.Name = "txt_tuoi";
            this.txt_tuoi.Size = new System.Drawing.Size(145, 26);
            this.txt_tuoi.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tuổi";
            // 
            // txt_SoTien
            // 
            this.txt_SoTien.Location = new System.Drawing.Point(401, 20);
            this.txt_SoTien.Name = "txt_SoTien";
            this.txt_SoTien.Size = new System.Drawing.Size(145, 26);
            this.txt_SoTien.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(312, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Số tiền chi";
            // 
            // txt_SL
            // 
            this.txt_SL.Location = new System.Drawing.Point(401, 58);
            this.txt_SL.Name = "txt_SL";
            this.txt_SL.Size = new System.Drawing.Size(145, 26);
            this.txt_SL.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "SL";
            // 
            // txt_diem
            // 
            this.txt_diem.Location = new System.Drawing.Point(149, 98);
            this.txt_diem.Name = "txt_diem";
            this.txt_diem.Size = new System.Drawing.Size(145, 26);
            this.txt_diem.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Điểm ";
            // 
            // btn_xem
            // 
            this.btn_xem.Location = new System.Drawing.Point(552, 26);
            this.btn_xem.Name = "btn_xem";
            this.btn_xem.Size = new System.Drawing.Size(77, 40);
            this.btn_xem.TabIndex = 12;
            this.btn_xem.Text = "Xem";
            this.btn_xem.UseVisualStyleBackColor = true;
            this.btn_xem.Click += new System.EventHandler(this.btn_xem_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(552, 72);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(77, 40);
            this.btn_clear.TabIndex = 15;
            this.btn_clear.Text = "clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // PhanTich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 884);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.chartPhanTich);
            this.Name = "PhanTich";
            this.Text = "PhanTich";
            this.Load += new System.EventHandler(this.PhanTich_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPhanTich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soCum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPhanTich;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Button btnPhanTich;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown txt_soCum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkProductsPurchased;
        private System.Windows.Forms.CheckBox chkSpending;
        private System.Windows.Forms.CheckBox chkLoyaltyPoints;
        private System.Windows.Forms.CheckBox chkAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDistanceMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_SL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SoTien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_tuoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_khachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_diem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_xem;
    }
}