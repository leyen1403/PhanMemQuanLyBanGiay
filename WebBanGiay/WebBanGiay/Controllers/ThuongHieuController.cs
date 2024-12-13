using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Services;

namespace WebBanGiay.Controllers
{
    public class ThuongHieuController : Controller
    {
        private readonly ThuongHieuService _thuongHieuService;

        public ThuongHieuController(ThuongHieuService thuongHieuService)
        {
            _thuongHieuService = thuongHieuService;
        }

        public IActionResult Index()
        {
            var brands = _thuongHieuService.GetAllBrands();
            return View(brands);
        }

        public IActionResult Detail(string id)
        {
            var brand = _thuongHieuService.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
    }
}
