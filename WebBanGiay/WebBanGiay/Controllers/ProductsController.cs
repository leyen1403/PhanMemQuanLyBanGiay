using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Models;
using WebBanGiay.Services;

public class ProductsController : Controller
{
    private readonly SanPhamService _sanPhamService;
    private readonly ThuongHieuService _thuongHieuService;
    public ProductsController(SanPhamService sanPhamService)
    {
        _sanPhamService = sanPhamService;
    }
    public IActionResult Detail(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("Product ID is missing.");
        }

        // Lấy thông tin sản phẩm từ service
        var product = _sanPhamService.GetSanPhamById(id);
        if (product == null)
        {
            return NotFound($"Product with ID {id} was not found.");
        }

        // Lấy danh sách kích thước theo tên sản phẩm
        var kichThuocs = _sanPhamService.GetKichThuocTheoTenSanPhamAsync(product.TenSanPham).Result ?? new List<KichThuoc>();

        // Tạo ViewModel
        var viewModel = new SanPhamDetailViewModel
        {
            SanPham = product,
            KichThuocs = kichThuocs
        };

        return View(viewModel);
    }

    public async Task<IActionResult> GetKichThuoc(string tenSanPham)
    {
        // Gọi service để lấy danh sách kích thước theo tên sản phẩm
        var products = await _sanPhamService.GetKichThuocTheoTenSanPhamAsync(tenSanPham);

        // Kiểm tra kết quả trả về
        if (products == null || !products.Any())
        {
            return NotFound($"No products found for the name '{tenSanPham}'.");
        }

        // Trả về view với danh sách kích thước
        return View(products);
    }



    public async Task<IActionResult> Index(string SortColumn = "Id", string IconClass = "fa-sort-asc", int page = 1)
    {
        // Lấy dữ liệu sản phẩm từ dịch vụ
        var products = await _sanPhamService.GetAllSanPhamsAsync();

        // Thực hiện sắp xếp
        switch (SortColumn.ToLower())
        {
            case "id":
                products = IconClass == "fa-sort-asc" ? products.OrderBy(p => p.MaSanPham).ToList() : products.OrderByDescending(p => p.MaSanPham).ToList();
                break;
            case "name":
                products = IconClass == "fa-sort-asc" ? products.OrderBy(p => p.TenSanPham).ToList() : products.OrderByDescending(p => p.TenSanPham).ToList();
                break;
            case "price":
                products = IconClass == "fa-sort-asc" ? products.OrderBy(p => p.GiaBan).ToList() : products.OrderByDescending(p => p.GiaBan).ToList();
                break;
            default:
                break;
        }

        // Truyền dữ liệu vào View
        ViewBag.SortColumn = SortColumn;
        ViewBag.IconClass = IconClass;
        ViewBag.Page = page;

        // Tính toán số lượng trang
        int pageSize = 12;  // Số sản phẩm mỗi trang
        int totalProducts = products.Count();
        ViewBag.NoOfPages = (int)Math.Ceiling((double)totalProducts / pageSize);

        // Trả lại một phần của sản phẩm (có phân trang)
        var pagedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return View("Index", pagedProducts);  // Trả về view "Index" trong thư mục Products
    }
}
