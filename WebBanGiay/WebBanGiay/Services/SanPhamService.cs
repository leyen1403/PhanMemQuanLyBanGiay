using WebBanGiay.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebBanGiay.Services
{
    public class SanPhamService
    {
        private readonly ApplicationDbContext _context;

        public SanPhamService(ApplicationDbContext context)
        {
            _context = context;
        }
        // Lấy chi tiết sản phẩm theo ID
        public SanPham GetSanPhamById(string id)
        {
            return _context.SanPhams.FirstOrDefault(p => p.MaSanPham == id);
        }
        // Hàm lấy tất cả sản phẩm đang hoạt động
        public async Task<List<SanPham>> GetAllSanPhamsAsync()
        {
            return await _context.SanPhams
                                 .Where(sp => sp.TrangThaiHoatDong == true)
                                 .GroupBy(sp => sp.TenSanPham)  // Nhóm theo tên sản phẩm
                                 .Select(group => group.First())  // Chọn sản phẩm đầu tiên trong mỗi nhóm
                                 .ToListAsync();
        }
        // Tìm kiếm sản phẩm theo tên
        public async Task<List<SanPham>> SearchByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await GetAllSanPhamsAsync();
            }

            return await _context.SanPhams
                                 .Where(p => p.TenSanPham.Contains(name) && p.TrangThaiHoatDong == true)
                                 .ToListAsync();
        }

        // Tìm kiếm sản phẩm theo giá
        public async Task<List<SanPham>> SearchByPriceAsync(decimal? minPrice, decimal? maxPrice)
        {
            if (minPrice == null && maxPrice == null)
            {
                return await GetAllSanPhamsAsync();
            }

            return await _context.SanPhams
                                 .Where(p => (minPrice == null || p.GiaBan >= minPrice) &&
                                             (maxPrice == null || p.GiaBan <= maxPrice) &&
                                             p.TrangThaiHoatDong == true)
                                 .ToListAsync();
        }

        // Tìm kiếm sản phẩm theo thương hiệu
        public async Task<List<SanPham>> SearchByBrandAsync(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                return await GetAllSanPhamsAsync();
            }

            return await _context.SanPhams
                                 .Where(p => p.MaThuongHieu.Contains(brand) && p.TrangThaiHoatDong == true)
                                 .ToListAsync();
        }
    }
}
