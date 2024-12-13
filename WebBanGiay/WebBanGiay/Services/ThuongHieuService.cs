using System.Collections.Generic;
using System.Linq;
using WebBanGiay.Models;

namespace WebBanGiay.Services
{
    public class ThuongHieuService
    {
        private readonly ApplicationDbContext _context;

        public ThuongHieuService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả thương hiệu
        public List<ThuongHieu> GetAllBrands()
        {
            return _context.ThuongHieus.ToList();
        }

        // Lấy thương hiệu theo ID
        public ThuongHieu? GetBrandById(string id)
        {
            return _context.ThuongHieus.FirstOrDefault(b => b.MaThuongHieu == id);
        }
    }
}
