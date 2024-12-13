using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBanGiay.Models;
using WebBanGiay.Services;

namespace WebBanGiay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SanPhamService _sanPhamService;

        public HomeController(ILogger<HomeController> logger, SanPhamService sanPhamService)
        {
            _logger = logger;
            _sanPhamService = sanPhamService;
        }

        // Trang chủ, lấy tất cả sản phẩm
        public async Task<IActionResult> Index()
        {
            // Lấy tất cả sản phẩm từ dịch vụ
            var sanPhams = await _sanPhamService.GetAllSanPhamsAsync();
            return View(sanPhams);  // Truyền dữ liệu vào View
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
