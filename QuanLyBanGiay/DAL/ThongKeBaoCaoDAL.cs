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

        public List<(int Nam, int Thang, decimal TongDoanhThu)> ThongKeDoanhThuTheoThang()
        {
            var result = db.HoaDons
                .Where(hd => hd.NgayTao.HasValue)  // Kiểm tra NgayTao có giá trị
                .GroupBy(hd => new { Nam = hd.NgayTao.Value.Year, Thang = hd.NgayTao.Value.Month })
                .Select(g => new
                {
                    g.Key.Nam,
                    g.Key.Thang,
                    TongDoanhThu = g.Sum(hd => hd.TongTien ?? 0)  // Xử lý giá trị null
                })
                .ToList()
                .Select(r => (r.Nam, r.Thang, r.TongDoanhThu))
                .ToList();

            return result;
        }

        public List<(int Nam, decimal TongDoanhThu)> ThongKeDoanhThuTheoNam()
        {
            var result = db.HoaDons
                .Where(hd => hd.NgayTao.HasValue)  // Kiểm tra NgayTao có giá trị
                .GroupBy(hd => hd.NgayTao.Value.Year)
                .Select(g => new
                {
                    Nam = g.Key,
                    TongDoanhThu = g.Sum(hd => hd.TongTien ?? 0)  // Xử lý giá trị null
                })
                .ToList()
                .Select(r => (r.Nam, r.TongDoanhThu))
                .ToList();

            return result;
        }

        public decimal ThongKeDoanhThuTheoKhoangThoiGian(DateTime startDate, DateTime endDate)
        {
            var result = db.HoaDons
                .Where(hd => hd.NgayTao >= startDate && hd.NgayTao <= endDate && hd.TongTien.HasValue)
                .Sum(hd => hd.TongTien ?? 0);  // Xử lý giá trị null

            return result;
        }

        public List<(string LoaiSanPham, decimal TongDoanhThu, int TongSoLuongBan)> ThongKeDoanhThuTheoLoaiSanPham()
        {
            var result = db.ChiTietHoaDons
                .GroupBy(cthd => cthd.SanPham.LoaiSanPham.TenLoaiSanPham)
                .Select(g => new
                {
                    LoaiSanPham = g.Key,
                    TongDoanhThu = g.Sum(cthd => cthd.SanPham.GiaBan * cthd.SoLuong) ?? 0,
                    TongSoLuongBan = g.Sum(cthd => cthd.SoLuong) ?? 0
                })
                .ToList()
                .Select(r => (r.LoaiSanPham, r.TongDoanhThu, r.TongSoLuongBan))
                .ToList();

            return result;
        }

        public List<(string TenNhanVien, decimal TongDoanhThu)> ThongKeDoanhThuTheoNhanVien(DateTime startDate, DateTime endDate)
        {
            var result = db.HoaDons
                .Where(hd => hd.NgayTao >= startDate && hd.NgayTao <= endDate && hd.TongTien.HasValue)  // Lọc theo khoảng thời gian và kiểm tra TongTien
                .GroupBy(hd => hd.NhanVien.TenNhanVien ?? "Chưa xác định")  // Kiểm tra TenNhanVien có giá trị
                .Select(g => new
                {
                    TenNhanVien = g.Key,
                    TongDoanhThu = g.Sum(hd => hd.TongTien ?? 0)
                })
                .ToList()
                .Select(r => (r.TenNhanVien, r.TongDoanhThu))
                .ToList();

            return result;
        }
        public List<DoanhThuTheoThangHoacTuan> DoanhThuTheoThangHoacTuan(DateTime startDate, DateTime endDate, ThongKeLoai thongKeLoai)
        {
            var result = new List<DoanhThuTheoThangHoacTuan>();

            // Truy vấn cơ sở dữ liệu
            var query = db.HoaDons
                .Where(hd => hd.NgayTao >= startDate && hd.NgayTao <= endDate && hd.TongTien.HasValue);

            if (thongKeLoai == ThongKeLoai.TheoThang)
            {
                // Thống kê theo tháng
                result = query
                    .GroupBy(hd => new { hd.NgayTao.Value.Year, hd.NgayTao.Value.Month })
                    .Select(g => new DoanhThuTheoThangHoacTuan
                    {
                        Nam = g.Key.Year,
                        Thang = g.Key.Month,
                        TongDoanhThu = g.Sum(hd => hd.TongTien ?? 0),
                        SoLuongHoaDon = g.Count(),
                        TongSoLuongSanPham = g.Sum(hd => hd.ChiTietHoaDons.Sum(hdct => hdct.SoLuong ?? 0)),
                        LoaiSanPhamThongKes = g.SelectMany(hd => hd.ChiTietHoaDons)
                                               .GroupBy(hdct => db.SanPhams
                                                                 .Where(sp => sp.MaSanPham == hdct.MaSanPham)
                                                                 .Select(sp => sp.MaLoaiSanPham)
                                                                 .FirstOrDefault())
                                               .Select(gr => new DoanhThuTheoThangHoacTuan.LoaiSanPhamThongKe
                                               {
                                                   LoaiSanPham = gr.Key,
                                                   SoLuongBanRa = gr.Sum(hdct => hdct.SoLuong ?? 0)
                                               }).ToList()
                    })
                    .ToList();
            }
            else if (thongKeLoai == ThongKeLoai.TheoTuan)
            {
                // Thống kê theo tuần
                result = query
                    .GroupBy(hd => new
                    {
                        Week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(hd.NgayTao.Value, CalendarWeekRule.FirstDay, DayOfWeek.Monday),
                        hd.NgayTao.Value.Year
                    })
                    .Select(g => new DoanhThuTheoThangHoacTuan
                    {
                        Nam = g.Key.Year,
                        Tuan = g.Key.Week,
                        TongDoanhThu = g.Sum(hd => hd.TongTien ?? 0),
                        SoLuongHoaDon = g.Count(),
                        TongSoLuongSanPham = g.Sum(hd => hd.ChiTietHoaDons.Sum(hdct => hdct.SoLuong ?? 0)),
                        LoaiSanPhamThongKes = g.SelectMany(hd => hd.ChiTietHoaDons)
                                               .GroupBy(hdct => db.SanPhams
                                                                 .Where(sp => sp.MaSanPham == hdct.MaSanPham)
                                                                 .Select(sp => sp.MaLoaiSanPham)
                                                                 .FirstOrDefault())
                                               .Select(gr => new DoanhThuTheoThangHoacTuan.LoaiSanPhamThongKe
                                               {
                                                   LoaiSanPham = gr.Key,
                                                   SoLuongBanRa = gr.Sum(hdct => hdct.SoLuong ?? 0)
                                               }).ToList()
                    })
                    .ToList();
            }
            else if (thongKeLoai == ThongKeLoai.TheoNam)
            {
                // Thống kê theo năm
                result = query
                    .GroupBy(hd => hd.NgayTao.Value.Year)
                    .Select(g => new DoanhThuTheoThangHoacTuan
                    {
                        Nam = g.Key,
                        TongDoanhThu = g.Sum(hd => hd.TongTien ?? 0),
                        SoLuongHoaDon = g.Count(),
                        TongSoLuongSanPham = g.Sum(hd => hd.ChiTietHoaDons.Sum(hdct => hdct.SoLuong ?? 0)),
                        LoaiSanPhamThongKes = g.SelectMany(hd => hd.ChiTietHoaDons)
                                               .GroupBy(hdct => db.SanPhams
                                                                 .Where(sp => sp.MaSanPham == hdct.MaSanPham)
                                                                 .Select(sp => sp.MaLoaiSanPham)
                                                                 .FirstOrDefault())
                                               .Select(gr => new DoanhThuTheoThangHoacTuan.LoaiSanPhamThongKe
                                               {
                                                   LoaiSanPham = gr.Key,
                                                   SoLuongBanRa = gr.Sum(hdct => hdct.SoLuong ?? 0)
                                               }).ToList()
                    })
                    .ToList();
            }

            return result;
        }
    }
}
