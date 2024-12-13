using Microsoft.AspNetCore.Mvc;
using WebBanGiay.Models;
using Newtonsoft.Json;

namespace WebBanGiay.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Thêm sản phẩm vào giỏ hàng
        public IActionResult AddToCart(string productId, int quantity)
        {
            // Lấy sản phẩm từ cơ sở dữ liệu dựa trên productId
            var product = _context.SanPhams.FirstOrDefault(p => p.MaSanPham == productId);

            if (product == null)
            {
                // Nếu sản phẩm không tồn tại, trả về lỗi NotFound
                return NotFound();
            }

            // Lấy giỏ hàng từ session (nếu có)
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            ShoppingCart cart;

            if (cartJson != null)
            {
                // Nếu giỏ hàng đã có trong session, deserializes giỏ hàng từ JSON
                cart = JsonConvert.DeserializeObject<ShoppingCart>(cartJson);
            }
            else
            {
                // Nếu không có giỏ hàng trong session, khởi tạo giỏ hàng mới
                cart = new ShoppingCart();
            }

            // Thêm sản phẩm vào giỏ hàng
            cart.AddToCart(product, quantity);

            // Lưu giỏ hàng đã cập nhật vào session
            HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(cart));

            // Chuyển hướng về trang giỏ hàng sau khi thêm sản phẩm
            return RedirectToAction("ViewCart");
        }

        // Xem giỏ hàng
        public IActionResult ViewCart()
        {
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            if (cartJson != null)
            {
                var cart = JsonConvert.DeserializeObject<ShoppingCart>(cartJson);
                return View(cart);
            }
            return View(new ShoppingCart());
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public IActionResult RemoveFromCart(string productId)
        {
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            if (cartJson != null)
            {
                var cart = JsonConvert.DeserializeObject<ShoppingCart>(cartJson);
                cart.RemoveFromCart(productId);
                HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(cart));
            }
            return RedirectToAction("ViewCart");
        }

        // Cập nhật số lượng sản phẩm trong giỏ hàng
        [HttpPost]
        public IActionResult UpdateQuantity(string productId, int quantity)
        {
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            if (cartJson != null)
            {
                var cart = JsonConvert.DeserializeObject<ShoppingCart>(cartJson);
                cart.UpdateQuantity(productId, quantity); // Cập nhật số lượng
                HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(cart));
            }
            return RedirectToAction("ViewCart");
        }
        // Thêm thông tin thanh toán vào cơ sở dữ liệu
        [HttpPost]
        public IActionResult ProcessPayment(string fullName, string address, string phone, string paymentMethod)
        {
            // Lấy giỏ hàng từ session
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            if (cartJson == null)
            {
                return RedirectToAction("ViewCart");
            }

            var cart = JsonConvert.DeserializeObject<ShoppingCart>(cartJson);

            // Tạo mã khách hàng tự động
            string maKhachHang = GenerateCustomerId();

            // Tạo khách hàng mới
            var newCustomer = new KhachHang
            {
                MaKhachHang = maKhachHang,
                TenKhachHang = fullName,
                SoDienThoai = phone,
                DiaChi = address,
                Email="default@gmail.com",
                NgayTao = DateOnly.FromDateTime(DateTime.Now),
                NgayCapNhat = DateOnly.FromDateTime(DateTime.Now),
                NgaySinh = DateOnly.FromDateTime(DateTime.Now), // Thêm ngày sinh của khách hàng
                GioiTinh = "nam",                // Hoặc "Nữ", lấy từ form hoặc thông tin của người dùng
                DiemTichLuy = 0,                 // Giá trị điểm tích lũy ban đầu là 0
                TaiKhoan = "taikhoan123",        // Tạo tài khoản hoặc lấy từ form
                MatKhau = "matkhau123",          // Mật khẩu (lưu ý bảo mật)
                HinhAnh = "user_default.jpg",    // Hình ảnh mặc định hoặc lấy từ form
                TrangThaiHoatDong = true,        // Khách hàng hoạt động hay không, có thể lấy từ form
                ThanhVien = false,               // Trạng thái thành viên, có thể lấy từ form
            };

            _context.KhachHangs.Add(newCustomer);
            _context.SaveChanges();

            // Tạo hóa đơn mới
            var hoaDon = new HoaDon
            {
                MaHoaDon = GenerateMaHD(),
                MaKhachHang = maKhachHang,
                TongTien = cart.TotalPrice(),
                PhuongThucThanhToan = paymentMethod,
                NgayTao = DateOnly.FromDateTime(DateTime.Now),
                MaNhanVien = "NV001",
                DiemTichLuySuDung = 0,
                GhiChu="Mua hàng qua website",
                TrangThai = "Chờ xác nhận"
            };

            _context.HoaDons.Add(hoaDon);
            _context.SaveChanges();

            // Lưu chi tiết hóa đơn
            foreach (var item in cart.Items)
            {
                var chiTietHoaDon = new ChiTietHoaDon
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    MaSanPham = item.Product.MaSanPham,
                    SoLuong = item.Quantity,
                    DonGia = item.Product.GiaBan ?? 0,
                    ThanhTien = item.Quantity * (item.Product.GiaBan ?? 0)
                };
                _context.ChiTietHoaDons.Add(chiTietHoaDon);
            }

            _context.SaveChanges();

            // Xóa giỏ hàng khỏi session sau khi thanh toán
            HttpContext.Session.Remove("ShoppingCart");

            // Chuyển hướng đến trang thông báo thành công
            return RedirectToAction("PaymentSuccess");
        }

        // Phương thức thanh toán và lưu thông tin vào database
        public IActionResult Checkout()
        {
            // Lấy giỏ hàng từ session
            var cartJson = HttpContext.Session.GetString("ShoppingCart");
            if (cartJson == null)
            {
                return RedirectToAction("ViewCart");  // Nếu không có giỏ hàng, chuyển về trang giỏ hàng
            }

            var cart = JsonConvert.DeserializeObject<ShoppingCart>(cartJson);

            // Tính tổng tiền và chuyển vào ViewBag để hiển thị
            ViewBag.TotalPrice = cart.TotalPrice();

            // Trả về View với giỏ hàng
            return View(cart);
        }

        // Phương thức tạo mã khách hàng tự động
        private string GenerateCustomerId()
        {
            // Đếm số lượng khách hàng hiện tại trong cơ sở dữ liệu
            var customerCount = _context.KhachHangs.Count();

            // Mã khách hàng sẽ được tạo ra dựa trên số lượng khách hàng hiện tại + 1
            int nextId = customerCount + 1;

            // Trả về mã khách hàng theo định dạng "KH" + số thứ tự với 3 chữ số, ví dụ KH001, KH002, ...
            return "KH" + nextId.ToString("D3");
        }
        private string GenerateMaHD()
        {
            // Đếm số lượng khách hàng hiện tại trong cơ sở dữ liệu
            var customerCount = _context.HoaDons.Count();

            // Mã khách hàng sẽ được tạo ra dựa trên số lượng khách hàng hiện tại + 1
            int nextId = customerCount + 1;

            // Trả về mã khách hàng theo định dạng "KH" + số thứ tự với 3 chữ số, ví dụ KH001, KH002, ...
            return "HD" + nextId.ToString("D3");
        }



        // Trang thông báo thanh toán thành công
        public IActionResult PaymentSuccess()
        {
            return View();
        }

    }
}
