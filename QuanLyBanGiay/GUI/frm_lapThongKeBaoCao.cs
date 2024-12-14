using Accord.Math;
using BLL;
using DTO;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class frm_lapThongKeBaoCao : Form
    {
        //DataGridView dgvThongKe = new DataGridView();
        HoaDonBLL hoaDonBanHangBLL = new HoaDonBLL();
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();

        public frm_lapThongKeBaoCao()
        {
            InitializeComponent();
            AddButtonPaintEvent();
            AddButtonPaintEventRecursive(this);
            this.Load += Frm_lapThongKeBaoCao_Load;
            this.btnXemDoanhThu.Click += BtnXemDoanhThu_Click;
            this.btnChuyen.Click += BtnChuyen_Click;

            tabCrlDoanhThu.Selected += TabCrlDoanhThu_Selected;
            this.btnXuatDoanhThu.Click += BtnXuatDoanhThu_Click;
            dtgvThongKe.BackgroundColor = Color.White;
        }

        private void BtnXuatDoanhThu_Click(object sender, EventArgs e)
        {
            string maNV = cbbNhanVien.SelectedValue.ToString();
            DateTime starDate = dtpNgayBD.Value;
            DateTime endDate = dtpNgayKT.Value;

            List<PhieuBaoCao> dsPBC = hoaDonBanHangBLL.LayPhieuBaoCaoTheoKhoangThoiGian(starDate, endDate);

            if (dsPBC.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu và ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string templatePath = Path.Combine(Application.StartupPath, "PhieuBaoCao.xlsx");
            if (!File.Exists(templatePath))
            {
                MessageBox.Show("File template không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Dictionary<string, string> replacer = new Dictionary<string, string>
            {
                {"%NgayBatDau", starDate.ToString("dd/MM/yyyy")},
                {"%NgayKetThuc", endDate.ToString("dd/MM/yyyy")},
                {"%NgayThangNam", "Ngày " + DateTime.Now.ToString("dd/MM/yyyy")}
            };

            NhanVien nv = nhanVienBLL.LayNhanVienTheoMa(maNV);
            replacer.Add("%MaNV", maNV);
            replacer.Add("%TenNhanVien", nv.MaNhanVien);
            replacer.Add("%DiaChi", nv.DiaChi);
            replacer.Add("%SDT", nv.SoDienThoai);

            decimal tongTien = dsPBC.Sum(item => item.THANHTIEN);
            replacer.Add("%TongTien", String.Format("{0:0,0} VNĐ", tongTien));

            byte[] templateBytes = File.ReadAllBytes(templatePath);
            using (MemoryStream stream = new MemoryStream(templateBytes))
            {
                using (ExcelEngine engine = new ExcelEngine())
                {
                    IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
                    IWorksheet workSheet = workBook.Worksheets[0];

                    foreach (var repl in replacer)
                    {
                        Replace(workSheet, repl.Key, repl.Value);
                    }

                    ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();
                    markProcessor.AddVariable("PhieuBaoCao", dsPBC);
                    markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

                    using (SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files (*.xlsx)|*.xlsx",
                        Title = "Chọn nơi lưu tệp",
                        FileName = $"PhieuBaoCao_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    })
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                workBook.SaveAs(saveFileDialog.FileName);
                                MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                System.Diagnostics.Process.Start(new ProcessStartInfo
                                {
                                    FileName = saveFileDialog.FileName,
                                    UseShellExecute = true
                                });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Lỗi khi lưu file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void Replace(IWorksheet workSheet, string p1, string p2)
        {
            workSheet.Replace(p1, p2);
        }


        private void TabCrlDoanhThu_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabSoLuongTon)
            {
                try
                {

                    DataTable dt = sanPhamBLL.GetSanPhamTonKho();
                    dataGridView2.DataSource = dt;
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (e.TabPage == tabSPBanChay)
            {
                try
                {

                    DataTable dt = sanPhamBLL.GetSanPhamBanChayDataTable();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnChuyen_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            LoadDataAndChart();
        }

        private void BtnXemDoanhThu_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            DateTime starDate = dtpNgayBD.Value;
            DateTime endDate = dtpNgayKT.Value;
            dtgvThongKe.DataSource = null;
            try
            {

                DataTable dt = hoaDonBanHangBLL.GetTongTienTheoNgayDataTable(starDate, endDate);
                dtgvThongKe.DataSource = dt;

                dtgvThongKe.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void LoadDataAndChart()
        {
            DataTable dataTable = (DataTable)dtgvThongKe.DataSource;

            DrawChart(dataTable);
        }
        private void DrawChart(DataTable dataTable)
        {

            chart1.Series.Clear();

            Series series = new Series
            {
                Name = "Tổng tiền",
                Color = System.Drawing.Color.ForestGreen,
                ChartType = SeriesChartType.Column
            };

            foreach (DataRow row in dataTable.Rows)
            {
                series.Points.AddXY(row["Ngày"], row["Tổng Tiền"]);
            }

            chart1.Series.Add(series);

            chart1.ChartAreas[0].AxisX.Title = "Ngày";
            chart1.ChartAreas[0].AxisY.Title = "Tổng tiền";

            chart1.Titles.Clear();
            chart1.Titles.Add("Biểu Đồ Dữ Liệu Thu Nhập");
        }


        private void loadCbbNhanVien()
        {
            try
            {
                List<NhanVien> dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();
                if (dsNhanVien != null && dsNhanVien.Count > 0)
                {
                    cbbNhanVien.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbbNhanVien.DataSource = dsNhanVien;
                    cbbNhanVien.ValueMember = "MaNhanVien";
                    cbbNhanVien.DisplayMember = "HoTen";
                }
                else
                {
                    MessageBox.Show("Không có nhân viên nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách dịch vụ.");
            }
        }



        private void Frm_lapThongKeBaoCao_Load(object sender, EventArgs e)
        {
            loadCbbNhanVien();
            dtgvThongKe.ReadOnly = true;
            DataTable dt = hoaDonBanHangBLL.GetTongTienTheoNgayDataTable();
            dtgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgvThongKe.DefaultCellStyle.Font = new Font("Arial", 12);
            dtgvThongKe.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            dtgvThongKe.MultiSelect = false;
            dtgvThongKe.AllowUserToAddRows = false;
            dtgvThongKe.DataSource = dt;
            dtgvThongKe.Refresh();
            dtgvThongKe.BackgroundColor = Color.White;
        }
        private void AddButtonPaintEvent()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Paint += CustomButton_Paint; // Gán sự kiện Paint cho mỗi nút
                }
            }
        }
        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Pen pen = new Pen(Color.Navy, 1); // Màu sắc và độ dày viền
            e.Graphics.DrawRectangle(pen, 0, 0, btn.Width - 1, btn.Height - 1);
        }

        private void AddButtonPaintEventRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button)
                {
                    button.Paint += CustomButton_Paint;
                    button.MouseEnter += Button_MouseEnter;  // Thêm sự kiện hover vào nút
                    button.MouseLeave += Button_MouseLeave; // Thêm sự kiện rời chuột khỏi nút
                }
                else if (control.HasChildren)
                {
                    AddButtonPaintEventRecursive(control); // Đệ quy vào các container con
                }
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = SystemColors.Control; // Đặt lại màu nền mặc định khi rời chuột
            btn.ForeColor = Color.Black; // Đặt lại màu chữ mặc định nếu cần
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Navy; // Đổi màu nền khi chuột vào
            btn.ForeColor = Color.White; // Đổi màu chữ nếu cần
        }
        private void tabDanhThu_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
