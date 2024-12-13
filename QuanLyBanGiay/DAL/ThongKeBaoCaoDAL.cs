using DTO; // Tham chiếu đến các lớp DTO
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DAL
{
    public class ThongKeBaoCaoDAL
    {
        db_QuanLyBanGiayDataContext db = null;

        public ThongKeBaoCaoDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }

        public List<(int Nam, int Thang, decimal TongDoanhThu, int TongSanPhamBan)> ThongKeDoanhThuTheoThang()
        {
            var result = db.HoaDons
                .Where(hd => hd.NgayTao.HasValue) // Kiểm tra NgayTao không null
                .GroupBy(hd => new { Nam = hd.NgayTao.Value.Year, Thang = hd.NgayTao.Value.Month })
                .Select(g => new
                {
                    g.Key.Nam,
                    g.Key.Thang,
                    TongDoanhThu = g.Sum(hd => hd.TongTien ?? 0), // Tổng doanh thu
                    TongSanPhamBan = g.SelectMany(hd => hd.ChiTietHoaDons) // Liên kết ChiTietHoaDons
                                       .Sum(cthd => cthd.SoLuong ?? 0) // Tổng số sản phẩm bán
                })
                .ToList()
                .Select(r => (r.Nam, r.Thang, r.TongDoanhThu, r.TongSanPhamBan))
                .ToList();

            return result;
        }

        public List<(string LoaiSanPham, decimal TongDoanhThu, int TongSoLuongBan)> ThongKeDoanhThuTheoLoaiSanPham()
        {
            var result = db.ChiTietHoaDons
                .Where(cthd => cthd.SanPham != null && cthd.SanPham.LoaiSanPham != null) // Kiểm tra null
                .GroupBy(cthd => cthd.SanPham.LoaiSanPham.TenLoaiSanPham)
                .Select(g => new
                {
                    LoaiSanPham = g.Key ?? "Chưa xác định", // Đổi tên thành "Chưa xác định" nếu null
                    TongDoanhThu = g.Sum(cthd => (cthd.SanPham.GiaBan ?? 0) * (cthd.SoLuong ?? 0)),
                    TongSoLuongBan = g.Sum(cthd => cthd.SoLuong ?? 0)
                })
                .ToList()
                .Select(r => (r.LoaiSanPham, r.TongDoanhThu, r.TongSoLuongBan))
                .ToList();

            return result;
        }
    }
}
