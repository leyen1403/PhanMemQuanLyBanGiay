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
            this.chkAge = new System.Windows.Forms.CheckBox();
            this.chkLoyaltyPoints = new System.Windows.Forms.CheckBox();
            this.chkSpending = new System.Windows.Forms.CheckBox();
            this.chkProductsPurchased = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_soCum = new System.Windows.Forms.NumericUpDown();
            this.cmbDistanceMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPhanTich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soCum)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPhanTich
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPhanTich.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPhanTich.Legends.Add(legend1);
            this.chartPhanTich.Location = new System.Drawing.Point(37, 60);
            this.chartPhanTich.Name = "chartPhanTich";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPhanTich.Series.Add(series1);
            this.chartPhanTich.Size = new System.Drawing.Size(399, 380);
            this.chartPhanTich.TabIndex = 0;
            this.chartPhanTich.Text = "chart1";
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(489, 60);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.Size = new System.Drawing.Size(543, 387);
            this.dataGridViewData.TabIndex = 1;
            // 
            // btnPhanTich
            // 
            this.btnPhanTich.Location = new System.Drawing.Point(402, 111);
            this.btnPhanTich.Name = "btnPhanTich";
            this.btnPhanTich.Size = new System.Drawing.Size(75, 23);
            this.btnPhanTich.TabIndex = 2;
            this.btnPhanTich.Text = "Phân tích";
            this.btnPhanTich.UseVisualStyleBackColor = true;
            this.btnPhanTich.Click += new System.EventHandler(this.btnPhanTich_Click);
            // 
            // groupBox1
            // 
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
            this.groupBox1.Location = new System.Drawing.Point(489, 482);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 140);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn phân loại";
            // 
            // chkAge
            // 
            this.chkAge.AutoSize = true;
            this.chkAge.Location = new System.Drawing.Point(74, 33);
            this.chkAge.Name = "chkAge";
            this.chkAge.Size = new System.Drawing.Size(47, 17);
            this.chkAge.TabIndex = 3;
            this.chkAge.Text = "Tuổi";
            this.chkAge.UseVisualStyleBackColor = true;
            // 
            // chkLoyaltyPoints
            // 
            this.chkLoyaltyPoints.AutoSize = true;
            this.chkLoyaltyPoints.Location = new System.Drawing.Point(180, 33);
            this.chkLoyaltyPoints.Name = "chkLoyaltyPoints";
            this.chkLoyaltyPoints.Size = new System.Drawing.Size(88, 17);
            this.chkLoyaltyPoints.TabIndex = 4;
            this.chkLoyaltyPoints.Text = "Điểm tích luỹ";
            this.chkLoyaltyPoints.UseVisualStyleBackColor = true;
            // 
            // chkSpending
            // 
            this.chkSpending.AutoSize = true;
            this.chkSpending.Location = new System.Drawing.Point(286, 33);
            this.chkSpending.Name = "chkSpending";
            this.chkSpending.Size = new System.Drawing.Size(76, 17);
            this.chkSpending.TabIndex = 5;
            this.chkSpending.Text = "Số tiền chi";
            this.chkSpending.UseVisualStyleBackColor = true;
            // 
            // chkProductsPurchased
            // 
            this.chkProductsPurchased.AutoSize = true;
            this.chkProductsPurchased.Location = new System.Drawing.Point(396, 33);
            this.chkProductsPurchased.Name = "chkProductsPurchased";
            this.chkProductsPurchased.Size = new System.Drawing.Size(140, 17);
            this.chkProductsPurchased.TabIndex = 6;
            this.chkProductsPurchased.Text = "Số lượng sản phẩm mua";
            this.chkProductsPurchased.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số lượng cụm";
            // 
            // txt_soCum
            // 
            this.txt_soCum.Location = new System.Drawing.Point(196, 68);
            this.txt_soCum.Name = "txt_soCum";
            this.txt_soCum.Size = new System.Drawing.Size(120, 20);
            this.txt_soCum.TabIndex = 9;
            // 
            // cmbDistanceMethod
            // 
            this.cmbDistanceMethod.FormattingEnabled = true;
            this.cmbDistanceMethod.Items.AddRange(new object[] {
            "Euclidean",
            "Manhattan",
            "Cosine"});
            this.cmbDistanceMethod.Location = new System.Drawing.Point(196, 95);
            this.cmbDistanceMethod.Name = "cmbDistanceMethod";
            this.cmbDistanceMethod.Size = new System.Drawing.Size(121, 21);
            this.cmbDistanceMethod.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Chọn tính khoảng cách";
            // 
            // PhanTich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 674);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.chartPhanTich);
            this.Name = "PhanTich";
            this.Text = "PhanTich";
            ((System.ComponentModel.ISupportInitialize)(this.chartPhanTich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soCum)).EndInit();
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
    }
}