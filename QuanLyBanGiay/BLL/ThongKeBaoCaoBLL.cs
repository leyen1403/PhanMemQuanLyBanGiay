using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ThongKeBaoCaoBLL
    {
        private readonly ThongKeBaoCaoDAL _thongKeBaoCaoDAL;

        public ThongKeBaoCaoBLL()
        {
            _thongKeBaoCaoDAL = new ThongKeBaoCaoDAL();
        }

        /// <summary>
        /// Thống kê doanh thu theo tháng.
        /// </summary>
        public List<(int Nam, int Thang, decimal TongDoanhThu)> ThongKeDoanhThuTheoThang()
        {
            try
            {
                return _thongKeBaoCaoDAL.ThongKeDoanhThuTheoThang();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tại BLL (có thể log hoặc ném ngoại lệ lên)
                throw new Exception("Lỗi khi thống kê doanh thu theo tháng: " + ex.Message);
            }
        }

        /// <summary>
        /// Thống kê doanh thu theo năm.
        /// </summary>
        public List<(int Nam, decimal TongDoanhThu)> ThongKeDoanhThuTheoNam()
        {
            try
            {
                return _thongKeBaoCaoDAL.ThongKeDoanhThuTheoNam();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tại BLL
                throw new Exception("Lỗi khi thống kê doanh thu theo năm: " + ex.Message);
            }
        }

        /// <summary>
        /// Thống kê doanh thu trong khoảng thời gian.
        /// </summary>
        public decimal ThongKeDoanhThuTheoKhoangThoiGian(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                {
                    throw new ArgumentException("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                }

                return _thongKeBaoCaoDAL.ThongKeDoanhThuTheoKhoangThoiGian(startDate, endDate);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tại BLL
                throw new Exception("Lỗi khi thống kê doanh thu theo khoảng thời gian: " + ex.Message);
            }
        }

        /// <summary>
        /// Thống kê doanh thu theo loại sản phẩm.
        /// </summary>
        public List<(string LoaiSanPham, decimal TongDoanhThu, int TongSoLuongBan)> ThongKeDoanhThuTheoLoaiSanPham()
        {
            try
            {
                return _thongKeBaoCaoDAL.ThongKeDoanhThuTheoLoaiSanPham();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tại BLL
                throw new Exception("Lỗi khi thống kê doanh thu theo loại sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Thống kê doanh thu theo nhân viên trong khoảng thời gian.
        /// </summary>
        public List<(string TenNhanVien, decimal TongDoanhThu)> ThongKeDoanhThuTheoNhanVien(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                {
                    throw new ArgumentException("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                }

                return _thongKeBaoCaoDAL.ThongKeDoanhThuTheoNhanVien(startDate, endDate);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi tại BLL
                throw new Exception("Lỗi khi thống kê doanh thu theo nhân viên: " + ex.Message);
            }
        }
        public List<DoanhThuTheoThangHoacTuan> DoanhThuTheoThangHoacTuan(DateTime startDate, DateTime endDate, ThongKeLoai thongKeLoai)
        {
            return _thongKeBaoCaoDAL.DoanhThuTheoThangHoacTuan(startDate, endDate, thongKeLoai);
        }
    }
}
