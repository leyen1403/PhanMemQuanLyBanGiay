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
        public List<(int Nam, int Thang, decimal TongDoanhThu, int TongSanPhamBan)> ThongKeDoanhThuTheoThang(DateTime startDate)
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
    }
}
