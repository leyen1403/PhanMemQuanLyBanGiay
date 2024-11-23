using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Windows.Forms.DataVisualization.Charting;
using DevExpress.XtraCharts;
using DevExpress.Charts.Native;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices.ComTypes;

namespace GUI
{
    public partial class frm_lapThongKeBaoCao : Form
    {
        ThongKeBaoCaoBLL _thongKeBaoCaoBLL = new ThongKeBaoCaoBLL();


        public frm_lapThongKeBaoCao()
        {
            InitializeComponent();
            comboBoxThongKe.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadThongKeOptions();
            comboBoxThongKe.SelectedIndexChanged += ComboBoxThongKe_SelectedIndexChanged;
            this.btn_xem.Click += Btn_xem_Click;

        }

        private void Btn_xem_Click(object sender, EventArgs e)
        {
            string selectedOption = comboBoxThongKe.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Doanh Thu Theo Khoảng Thời Gian":
                    bool isWeekChecked = chkWeek.Checked;
                    bool isMonthChecked = chkMonth.Checked;
                    bool isYearChecked = chkYear.Checked;

                    // Lấy dữ liệu từ datetimepicker
                    DateTime startDate = dtp_ngayBD.Value;
                    DateTime endDate = dtp_ngayKT.Value;

                    // Kiểm tra từng checkbox và gọi hàm thống kê tương ứng
                    if (isWeekChecked)
                    {
                        // Thống kê doanh thu theo tuần
                        LoadDoanhThuLenBieuDo(startDate, endDate, ThongKeLoai.TheoTuan);  // Gọi hàm thống kê theo tuần
                        LoadSoLuongBanRaLenBieuDoTron(startDate, endDate, ThongKeLoai.TheoTuan);  // Gọi hàm thống kê số lượng bán ra (biểu đồ tròn
                    }
                    else if (isMonthChecked)
                    {
                        // Thống kê doanh thu theo tháng
                        LoadDoanhThuLenBieuDo(startDate, endDate, ThongKeLoai.TheoThang);  // Gọi hàm thống kê theo tháng
                        LoadSoLuongBanRaLenBieuDoTron(startDate, endDate, ThongKeLoai.TheoThang);  // Gọi hàm thống kê số lượng bán ra (biểu đồ tròn)
                    }
                    else if (isYearChecked)
                    {
                        // Thống kê doanh thu theo năm
                        LoadDoanhThuLenBieuDo(startDate, endDate, ThongKeLoai.TheoNam);  // Gọi hàm thống kê theo năm
                        LoadSoLuongBanRaLenBieuDoTron(startDate, endDate, ThongKeLoai.TheoNam);  // Gọi hàm thống kê số lượng bán ra (biểu đồ tròn)
                    }
                    break;
                case "Doanh Thu Theo Loại Sản Phẩm":
                    InitializeChartsLoai();
                    break;
                case "Doanh Thu Theo Nhân Viên theo thời gian":
                    
                    break;
                default:
                    break;
            }
        }

        private void ComboBoxThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBoxThongKe.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Doanh Thu Theo Tháng":
                    dtp_ngayKT.Enabled = false;
                    break;
                case "Doanh Thu Theo Năm":
                    dtp_ngayKT.Enabled = false;
                    break;
                case "Doanh Thu Theo Khoảng Thời Gian":
                    dtp_ngayKT.Enabled = true;
                    break;
                case "Doanh Thu Theo Loại Sản Phẩm":
                    dtp_ngayKT.Enabled = false;
                    dtp_ngayBD.Enabled = false;
                    break;
                case "Doanh Thu Theo Nhân Viên theo thời gian":
                    dtp_ngayKT.Enabled = true;
                    dtp_ngayBD.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        //viết hàm xử lý 
        private void LoadThongKeOptions()
        {
            comboBoxThongKe.Items.Add("Doanh Thu Theo Khoảng Thời Gian");
            comboBoxThongKe.Items.Add("Doanh Thu Theo Loại Sản Phẩm");
            comboBoxThongKe.Items.Add("Doanh Thu Theo Nhân Viên theo thời gian");
            comboBoxThongKe.SelectedIndex = 0; // Chọn mặc định là "Doanh Thu Theo Tháng"
        }

        // Phương thức lấy doanh thu theo tháng, tuần hoặc năm
        public List<DoanhThuTheoThangHoacTuan> DoanhThuTheoThangHoacTuan(DateTime startDate, DateTime endDate, ThongKeLoai thongKeLoai)
        {
            var result = new List<DoanhThuTheoThangHoacTuan>();

            result = _thongKeBaoCaoBLL.DoanhThuTheoThangHoacTuan(startDate, endDate, thongKeLoai);

            return result;  // Trả về danh sách dữ liệu
        }

        // Phương thức vẽ biểu đồ doanh thu theo thời gian (tuần, tháng, năm)
        private void LoadDoanhThuLenBieuDo(DateTime startDate, DateTime endDate, ThongKeLoai thongKeLoai)
        {
            // Lấy dữ liệu thống kê
            List<DoanhThuTheoThangHoacTuan> doanhThuList = DoanhThuTheoThangHoacTuan(startDate, endDate, thongKeLoai);

            // Xóa các series cũ trên biểu đồ
            chart_doanhThu.Series.Clear();

            // Tạo mới một series cho biểu đồ
            DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series("Doanh Thu", DevExpress.XtraCharts.ViewType.Bar);
            series.DataSource = doanhThuList;

            // Cấu hình các trục X và Y
            series.ArgumentDataMember = GetArgumentDataMember(thongKeLoai);
            switch (thongKeLoai)
            {
                case ThongKeLoai.TheoThang:
                    series.ArgumentDataMember = "Thang";  // Theo tháng
                    break;
                case ThongKeLoai.TheoTuan:
                    series.ArgumentDataMember = "Tuan";    // Theo tuần
                    break;
                case ThongKeLoai.TheoNam:
                    series.ArgumentDataMember = "Nam";    // Theo năm
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(thongKeLoai), thongKeLoai, null);
            }
            series.ValueDataMembers.AddRange(new string[] { "TongDoanhThu" });

            // Thêm series vào biểu đồ
            chart_doanhThu.Series.Add(series);

            // Cấu hình tiêu đề trục X và Y
            ((XYDiagram)chart_doanhThu.Diagram).AxisX.Title.Text = thongKeLoai.ToString();
            ((XYDiagram)chart_doanhThu.Diagram).AxisY.Title.Text = "Doanh Thu (VND)";
            chart_doanhThu.Refresh();
        }

        // Phương thức vẽ biểu đồ tròn cho số lượng bán ra
        private void LoadSoLuongBanRaLenBieuDoTron(DateTime startDate, DateTime endDate, ThongKeLoai thongKeLoai)
        {
            // Lấy dữ liệu thống kê
            List<DoanhThuTheoThangHoacTuan> doanhThuList = DoanhThuTheoThangHoacTuan(startDate, endDate, thongKeLoai);

            // Xóa các series cũ trên biểu đồ
            chart_soLuong.Series.Clear();

            // Tạo mới một series biểu đồ tròn
            DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series("Số Lượng Bán Ra", DevExpress.XtraCharts.ViewType.Pie);
            var allSales = doanhThuList.SelectMany(dt => dt.LoaiSanPhamThongKes).ToList();  // Lấy tất cả dữ liệu số lượng bán ra của các sản phẩm

            // Tính tổng số lượng bán ra của tất cả các sản phẩm
            int totalSales = allSales.Sum(s => s.SoLuongBanRa);

            // Cập nhật nguồn dữ liệu cho biểu đồ tròn
            series.DataSource = allSales;

            // Cấu hình các thành phần trong biểu đồ tròn
            series.ArgumentDataMember = "LoaiSanPham";  // Tên sản phẩm
            series.ValueDataMembers.AddRange(new string[] { "SoLuongBanRa" });  // Số lượng bán ra của sản phẩm

            // Thêm series vào biểu đồ
            chart_soLuong.Series.Add(series);

            // Tùy chỉnh nhãn hiển thị trong biểu đồ tròn
            PieSeriesLabel pieLabel = series.Label as PieSeriesLabel;
            if (pieLabel != null)
            {
                pieLabel.Visible = true;
                pieLabel.TextPattern = "{A}: {V} ({VP:0.00}%)";  // {A}: Tên sản phẩm, {V}: Số lượng bán ra, {VP:0.00}%: Tỷ lệ phần trăm bán ra
            }

            // Tùy chỉnh View của Pie Chart (biểu đồ tròn)
            PieSeriesView pieView = series.View as PieSeriesView;
            if (pieView != null)
            {
                pieView.ExplodeMode = DevExpress.XtraCharts.PieExplodeMode.All;
                pieView.ExplodedDistancePercentage = 20;  // Hiệu ứng nổ cho từng phần tử
            }

            // Tính tỷ lệ phần trăm cho mỗi sản phẩm và cập nhật
            foreach (var item in allSales)
            {
                double percentage = (double)item.SoLuongBanRa / totalSales * 100;
                item.TyLePhanTram = percentage;  // Lưu tỷ lệ phần trăm vào đối tượng (nếu cần lưu lại giá trị này)
            }

            // Làm mới biểu đồ
            chart_soLuong.Refresh();
        }

        // Hàm khởi tạo các biểu đồ
        private void InitializeChartsLoai()
        {
            InitializeChartDoanhThu();
            InitializeChartSoLuong();
        }

        private void InitializeChartSoLuong()
        {
            // Lấy dữ liệu doanh thu theo loại sản phẩm từ BLL
            var doanhThuTheoLoaiSanPham = _thongKeBaoCaoBLL.ThongKeDoanhThuTheoLoaiSanPham();

            // Tính tổng doanh thu và tổng số lượng
            decimal tongDoanhThu = 0;
            int tongSoLuong = 0;

            // Thiết lập biểu đồ tròn
            chart_soLuong.Series.Clear();

            // Tạo Series mới cho biểu đồ tròn
            var series = new DevExpress.XtraCharts.Series("Số Lượng Sản Phẩm", DevExpress.XtraCharts.ViewType.Pie);

            // Thêm dữ liệu vào biểu đồ và tính tổng doanh thu, số lượng
            foreach (var item in doanhThuTheoLoaiSanPham)
            {
                series.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.LoaiSanPham, item.TongSoLuongBan)); // X: Loại sản phẩm, Y: Số lượng bán

                // Cộng dồn tổng doanh thu và số lượng
                tongDoanhThu += item.TongDoanhThu;
                tongSoLuong += item.TongSoLuongBan;
            }

            // Đặt View cho Series (PieSeriesView)
            DevExpress.XtraCharts.PieSeriesView pieView = new DevExpress.XtraCharts.PieSeriesView();
            series.View = pieView;

            // Thiết lập nhãn cho từng phần tử trong biểu đồ
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True; // Hiển thị nhãn
            series.Label.TextPattern = "{A}: {V:#,##0} ({VP:p0})"; // {A}: tên loại sản phẩm, {V}: số lượng bán, {VP:p0}: tỷ lệ phần trăm

            // Thêm series vào chart
            chart_soLuong.Series.Add(series);

            // Thiết lập tiêu đề cho biểu đồ
            chart_soLuong.Titles.Clear(); // Xóa các tiêu đề cũ
            chart_soLuong.Titles.Add(new DevExpress.XtraCharts.ChartTitle() { Text = "Số Lượng Sản Phẩm Đã Bán" });

            // Hiển thị tổng doanh thu và tổng số lượng lên các TextBox
            txt_doanhThu.Text = tongDoanhThu.ToString("#,##0") + " VNĐ";  // Hiển thị tổng doanh thu với định dạng tiền tệ
            txt_SoLuong.Text = tongSoLuong.ToString("#,##0");  // Hiển thị tổng số lượng
        }

        private void InitializeChartDoanhThu()
        {
            var doanhThuTheoLoaiSanPham = _thongKeBaoCaoBLL.ThongKeDoanhThuTheoLoaiSanPham();
            chart_doanhThu.Series.Clear();
            DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series("Doanh Thu", DevExpress.XtraCharts.ViewType.Bar);
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            foreach (var item in doanhThuTheoLoaiSanPham)
            {
                series.Points.Add(new DevExpress.XtraCharts.SeriesPoint(item.LoaiSanPham, item.TongDoanhThu)); // X: Loại sản phẩm, Y: Doanh thu

            }
            DevExpress.XtraCharts.SideBySideBarSeriesView barView = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            series.View = barView;
            chart_doanhThu.Series.Add(series);
            chart_doanhThu.Titles.Clear(); // Xóa các tiêu đề cũ
            chart_doanhThu.Titles.Add(new DevExpress.XtraCharts.ChartTitle() { Text = "Doanh Thu Theo Loại Sản Phẩm" });
        }

        private string GetArgumentDataMember(ThongKeLoai thongKeLoai)
        {
            switch (thongKeLoai)
            {
                case ThongKeLoai.TheoThang:
                    return "Thang";  // Theo tháng
                case ThongKeLoai.TheoTuan:
                    return "Tuan";    // Theo tuần
                case ThongKeLoai.TheoNam:
                    return "Nam";     // Theo năm
                default:
                    throw new ArgumentOutOfRangeException(nameof(thongKeLoai), thongKeLoai, null);
            }
        }
    }
}
