namespace UC
{
    partial class ProductItem
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductItem));
            this.label_tenSanPham = new System.Windows.Forms.Label();
            this.anhSanPham = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.anhSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label_tenSanPham
            // 
            this.label_tenSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_tenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenSanPham.ForeColor = System.Drawing.Color.Navy;
            this.label_tenSanPham.Location = new System.Drawing.Point(6, 123);
            this.label_tenSanPham.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_tenSanPham.Name = "label_tenSanPham";
            this.label_tenSanPham.Size = new System.Drawing.Size(138, 43);
            this.label_tenSanPham.TabIndex = 3;
            this.label_tenSanPham.Text = "Tên sản phẩm";
            this.label_tenSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // anhSanPham
            // 
            this.anhSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.anhSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.anhSanPham.Image = ((System.Drawing.Image)(resources.GetObject("anhSanPham.Image")));
            this.anhSanPham.Location = new System.Drawing.Point(16, 15);
            this.anhSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.anhSanPham.Name = "anhSanPham";
            this.anhSanPham.Size = new System.Drawing.Size(115, 106);
            this.anhSanPham.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.anhSanPham.TabIndex = 2;
            this.anhSanPham.TabStop = false;
            // 
            // ProductItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_tenSanPham);
            this.Controls.Add(this.anhSanPham);
            this.Name = "ProductItem";
            this.Size = new System.Drawing.Size(150, 180);
            ((System.ComponentModel.ISupportInitialize)(this.anhSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_tenSanPham;
        private System.Windows.Forms.PictureBox anhSanPham;
    }
}
