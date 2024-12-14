using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Để làm việc với biểu đồ
using Accord.MachineLearning;                         // Để thực hiện K-Means
using Accord.Statistics.Filters;
using DTO;
using BLL;
using static DevExpress.Data.Helpers.SyncHelper.ZombieContextsDetector;

namespace GUI
{
    public partial class PhanTich : Form
    {
        KhachHangBLL _khachHangBLL = new KhachHangBLL();
        private KMeans _kmeansModel;
        private List<int> _selectedAttributes; // Lưu trữ các thuộc tính đã chọn
        private double[,] _trainingData; // Dữ liệu đã chuẩn hóa

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

           customerList=_khachHangBLL.GetCustomerSummaries();

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
            TrainKMeans(data, k, distanceMethod);
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

        private void PhanTich_Load(object sender, EventArgs e)
        {

        }
        private void TrainKMeans(double[,] normalizedData, int k, string distanceMethod)
        {
            double[][] jaggedData = ConvertToJaggedArray(normalizedData);

            switch (distanceMethod)
            {
                case "Manhattan":
                    _kmeansModel = new KMeans(k, Accord.Math.Distance.Manhattan);
                    break;
                case "Cosine":
                    _kmeansModel = new KMeans(k, Accord.Math.Distance.Cosine);
                    break;
                case "Euclidean":
                default:
                    _kmeansModel = new KMeans(k, Accord.Math.Distance.Euclidean);
                    break;
            }

            // Huấn luyện mô hình
            _kmeansModel.Learn(jaggedData);

            // Lưu trữ dữ liệu đã huấn luyện
            _trainingData = normalizedData;
        }

        private int PredictCluster(Customer newCustomer)
        {
            if (_kmeansModel == null || _trainingData == null || _selectedAttributes == null)
            {
                MessageBox.Show("Vui lòng thực hiện phân tích trước khi dự đoán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            // Lấy dữ liệu của khách hàng mới dựa trên các thuộc tính đã chọn
            double[] newData = new double[_selectedAttributes.Count];
            if (_selectedAttributes.Contains(0)) newData[_selectedAttributes.IndexOf(0)] = newCustomer.Age;
            if (_selectedAttributes.Contains(1)) newData[_selectedAttributes.IndexOf(1)] = newCustomer.LoyaltyPoints;
            if (_selectedAttributes.Contains(2)) newData[_selectedAttributes.IndexOf(2)] = newCustomer.Spending;
            if (_selectedAttributes.Contains(3)) newData[_selectedAttributes.IndexOf(3)] = newCustomer.ProductsPurchased;

            // Chuẩn hóa dữ liệu mới
            double[,] newNormalizedData = NormalizeData(new double[,] { { newData[0], newData[1], newData[2], newData[3] } });

            // Dự đoán cụm
            int[] predictedCluster = _kmeansModel.Clusters.Decide(ConvertToJaggedArray(newNormalizedData));
            return predictedCluster[0];
        }


        private void btn_xem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_kmeansModel == null)
                {
                    MessageBox.Show("Vui lòng thực hiện phân tích K-Means trước khi dự đoán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin từ các ô nhập liệu
                double age = chkAge.Checked ? double.Parse(txt_tuoi.Text) : 0;
                double loyaltyPoints = chkLoyaltyPoints.Checked ? double.Parse(txt_diem.Text) : 0;
                double spending = chkSpending.Checked ? double.Parse(txt_SoTien.Text) : 0;
                double productsPurchased = chkProductsPurchased.Checked ? double.Parse(txt_SL.Text) : 0;

                // Xây dựng mảng dữ liệu đầu vào
                List<int> selectedAttributes = new List<int>();
                if (chkAge.Checked) selectedAttributes.Add(0);
                if (chkLoyaltyPoints.Checked) selectedAttributes.Add(1);
                if (chkSpending.Checked) selectedAttributes.Add(2);
                if (chkProductsPurchased.Checked) selectedAttributes.Add(3);

                // Kiểm tra nếu không có thuộc tính nào được chọn
                if (selectedAttributes.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một thuộc tính để dự đoán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double[] inputData = new double[selectedAttributes.Count];
                if (selectedAttributes.Contains(0)) inputData[selectedAttributes.IndexOf(0)] = age;
                if (selectedAttributes.Contains(1)) inputData[selectedAttributes.IndexOf(1)] = loyaltyPoints;
                if (selectedAttributes.Contains(2)) inputData[selectedAttributes.IndexOf(2)] = spending;
                if (selectedAttributes.Contains(3)) inputData[selectedAttributes.IndexOf(3)] = productsPurchased;

                // Chuẩn hóa dữ liệu
                double[,] singleInputData = new double[1, selectedAttributes.Count];
                for (int i = 0; i < selectedAttributes.Count; i++)
                {
                    singleInputData[0, i] = inputData[i];
                }
                double[,] normalizedData = NormalizeData(singleInputData);

                // Thực hiện dự đoán
                double[][] jaggedData = ConvertToJaggedArray(normalizedData);
                int predictedCluster = _kmeansModel.Clusters.Decide(jaggedData)[0];

                MessageBox.Show($"Khách hàng thuộc cụm: {predictedCluster + 1}", "Kết quả dự đoán", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình dự đoán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //xoá dữ liệu trong các ô nhập liệu
            txt_tuoi.Text = "";
            txt_diem.Text = "";
            txt_SoTien.Text = "";
            txt_SL.Text = "";
        }
    }
}
