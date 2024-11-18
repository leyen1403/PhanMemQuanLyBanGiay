using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Để làm việc với biểu đồ
using Accord.MachineLearning;                         // Để thực hiện K-Means
using Accord.Statistics.Filters;
using DTO;

namespace GUI
{
    public partial class PhanTich : Form
    {
        public PhanTich()
        {
            InitializeComponent();
            cmbDistanceMethod.SelectedIndex = 0; // Mặc định phương pháp khoảng cách là Euclidean
            dataGridViewData.DataSource = GetCustomerData();
        }

        // Lấy dữ liệu khách hàng dưới dạng List<Customer>
        private List<Customer> GetCustomerData()
        {
            List<Customer> customerList = new List<Customer>();

            // Tạo dữ liệu cố định cho từng khách hàng
            customerList.Add(new Customer("Khách hàng 1", 25, 100, 500000, 5));
            customerList.Add(new Customer("Khách hàng 2", 30, 150, 1000000, 10));
            customerList.Add(new Customer("Khách hàng 3", 35, 200, 1200000, 12));
            customerList.Add(new Customer("Khách hàng 4", 40, 250, 800000, 8));
            customerList.Add(new Customer("Khách hàng 5", 45, 80, 300000, 3));
            customerList.Add(new Customer("Khách hàng 6", 50, 120, 600000, 7));
            customerList.Add(new Customer("Khách hàng 7", 55, 180, 1400000, 15));
            customerList.Add(new Customer("Khách hàng 8", 60, 220, 900000, 9));
            customerList.Add(new Customer("Khách hàng 9", 28, 160, 1100000, 11));
            customerList.Add(new Customer("Khách hàng 10", 33, 200, 1500000, 16));
            customerList.Add(new Customer("Khách hàng 11", 38, 140, 950000, 10));
            customerList.Add(new Customer("Khách hàng 12", 42, 210, 1300000, 14));
            customerList.Add(new Customer("Khách hàng 13", 27, 170, 1050000, 9));
            customerList.Add(new Customer("Khách hàng 14", 50, 250, 800000, 7));
            customerList.Add(new Customer("Khách hàng 15", 45, 110, 700000, 6));
            customerList.Add(new Customer("Khách hàng 16", 53, 230, 1250000, 13));
            customerList.Add(new Customer("Khách hàng 17", 29, 90, 400000, 4));
            customerList.Add(new Customer("Khách hàng 18", 34, 160, 600000, 8));
            customerList.Add(new Customer("Khách hàng 19", 31, 140, 800000, 7));
            customerList.Add(new Customer("Khách hàng 20", 36, 180, 1000000, 10));

            return customerList;
        }

        // Chuyển đổi mảng 2 chiều thành mảng jagged
        private double[][] ConvertToJaggedArray(double[,] data)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);
            double[][] jaggedArray = new double[rows][];
            for (int i = 0; i < rows; i++)
            {
                jaggedArray[i] = new double[cols];
                for (int j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = data[i, j];
                }
            }
            return jaggedArray;
        }

        // Chuẩn hóa dữ liệu
        private double[,] NormalizeData(double[,] data)
        {
            double[][] jaggedData = ConvertToJaggedArray(data);

            // Khởi tạo bộ chuẩn hóa cho dữ liệu
            var normalizer = new Accord.Statistics.Filters.Normalization();

            // Detect kiểu dữ liệu (tính toán min-max hoặc z-score nếu cần)
            normalizer.Detect(jaggedData);

            // Chuẩn hóa dữ liệu
            double[][] normalizedData = normalizer.Apply(jaggedData);

            // Chuyển đổi lại mảng jagged thành mảng 2 chiều
            int rows = normalizedData.Length;
            int cols = normalizedData[0].Length;
            double[,] result = new double[rows, cols];

            // Điền lại mảng 2 chiều sau khi chuẩn hóa
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = normalizedData[i][j];
                }
            }

            return result;
        }

        // Thực hiện K-Means với phương pháp khoảng cách tuỳ chọn
        private int[] PerformKMeans(double[,] data, int k, string distanceMethod)
        {
            double[][] jaggedData = ConvertToJaggedArray(data);
            KMeans kmeans;

            // Chọn phương pháp khoảng cách
            switch (distanceMethod)
            {
                case "Manhattan":
                    kmeans = new KMeans(k, Accord.Math.Distance.Manhattan);
                    break;
                case "Cosine":
                    kmeans = new KMeans(k, Accord.Math.Distance.Cosine);
                    break;
                case "Euclidean":
                default:
                    kmeans = new KMeans(k, Accord.Math.Distance.Euclidean);
                    break;
            }

            var clusters = kmeans.Learn(jaggedData);
            return clusters.Decide(jaggedData);
        }

        private void DisplayClustersChart(int[] clusters, double[,] data)
        {
            chartPhanTich.Series.Clear();
            chartPhanTich.ChartAreas.Clear();
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartArea.AxisX.Title = "X";
            chartArea.AxisY.Title = "Y";
            chartPhanTich.ChartAreas.Add(chartArea);
            // Kiểm tra nếu tiêu đề đã tồn tại rồi, không thêm tiêu đề mới
            if (chartPhanTich.Titles.Count == 0)
            {
                Title chartTitle = new Title("Phân tích Dữ liệu Khách Hàng", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.Black);
                chartPhanTich.Titles.Add(chartTitle);
            }

            int numberOfClusters = clusters.Max() + 1;

            // Tạo các chuỗi cho biểu đồ
            for (int i = 0; i < numberOfClusters; i++)
            {
                Series series = new Series($"Cụm {i + 1}")
                {
                    ChartType = SeriesChartType.Point,
                    MarkerStyle = MarkerStyle.Circle,
                    MarkerSize = 8,
                    ChartArea = "ChartArea1"
                };
                chartPhanTich.Series.Add(series);
            }

            // Thêm dữ liệu vào biểu đồ
            for (int i = 0; i < clusters.Length; i++)
            {
                int cluster = clusters[i];
                double xValue = data[i, 0];  // Assuming the first column as x-axis (Age or selected attribute)
                double yValue = data[i, 1];  // Assuming the second column as y-axis (Loyalty Points or selected attribute)

                chartPhanTich.Series[cluster].Points.AddXY(xValue, yValue);
            }
        }

        private void DisplayRawData(double[,] data, int[] clusters, List<int> selectedAttributes)
        {
            dataGridViewData.DataSource = null;
            if (data.GetLength(0) != clusters.Length)
            {
                MessageBox.Show("Số lượng khách hàng và số cụm không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dữ liệu khách hàng thực tế
            List<Customer> customerList = GetCustomerData();

            dataGridViewData.Rows.Clear();
            dataGridViewData.Columns.Clear();

            // Thêm các cột cần thiết vào DataGridView
            dataGridViewData.Columns.Add("Name", "Tên");
            if (chkAge.Checked) dataGridViewData.Columns.Add("Age", "Độ tuổi");
            if (chkLoyaltyPoints.Checked) dataGridViewData.Columns.Add("Points", "Điểm tích lũy");
            if (chkSpending.Checked) dataGridViewData.Columns.Add("Spending", "Tổng tiền mua hàng");
            if (chkProductsPurchased.Checked) dataGridViewData.Columns.Add("PurchaseQuantity", "Số lượng mua hàng");
            dataGridViewData.Columns.Add("Cluster", "Cụm");

            // Hiển thị dữ liệu vào DataGridView
            for (int i = 0; i < data.GetLength(0); i++)
            {
                List<object> row = new List<object>();
                row.Add(customerList[i].Name);  // Lấy tên khách hàng từ dữ liệu
                                                // Thêm các thuộc tính đã chọn vào dòng
                if (chkAge.Checked) row.Add(data[i, selectedAttributes.IndexOf(0)]);
                if (chkLoyaltyPoints.Checked) row.Add(data[i, selectedAttributes.IndexOf(1)]);
                if (chkSpending.Checked) row.Add(data[i, selectedAttributes.IndexOf(2)]);
                if (chkProductsPurchased.Checked) row.Add(data[i, selectedAttributes.IndexOf(3)]);
                row.Add(clusters[i] + 1);  // Thêm thông tin cụm vào dòng
                dataGridViewData.Rows.Add(row.ToArray());
            }
        }

        private void btnPhanTich_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giá trị của k
                int k;
                if (!int.TryParse(txt_soCum.Text, out k) || k <= 0)
                {
                    MessageBox.Show("Vui lòng nhập giá trị k hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy dữ liệu khách hàng
                List<Customer> customerList = GetCustomerData();

                // Lấy dữ liệu đã chọn để phân tích
                List<int> selectedAttributes = new List<int>();
                if (chkAge.Checked) selectedAttributes.Add(0);
                if (chkLoyaltyPoints.Checked) selectedAttributes.Add(1);
                if (chkSpending.Checked) selectedAttributes.Add(2);
                if (chkProductsPurchased.Checked) selectedAttributes.Add(3);

                // Kiểm tra nếu không có thuộc tính nào được chọn
                if (selectedAttributes.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thuộc tính để phân tích.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy dữ liệu và chuẩn hóa
                double[,] data = new double[customerList.Count, selectedAttributes.Count];
                for (int i = 0; i < customerList.Count; i++)
                {
                    if (selectedAttributes.Contains(0)) data[i, selectedAttributes.IndexOf(0)] = customerList[i].Age;
                    if (selectedAttributes.Contains(1)) data[i, selectedAttributes.IndexOf(1)] = customerList[i].LoyaltyPoints;
                    if (selectedAttributes.Contains(2)) data[i, selectedAttributes.IndexOf(2)] = customerList[i].Spending;
                    if (selectedAttributes.Contains(3)) data[i, selectedAttributes.IndexOf(3)] = customerList[i].ProductsPurchased;
                }

                // Chuẩn hóa dữ liệu
                double[,] normalizedData = NormalizeData(data);

                // Thực hiện K-Means
                string distanceMethod = cmbDistanceMethod.SelectedItem.ToString();
                int[] clusters = PerformKMeans(normalizedData, k, distanceMethod);

                // Hiển thị kết quả
                DisplayClustersChart(clusters, data);
                DisplayRawData(data, clusters, selectedAttributes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình phân tích: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
