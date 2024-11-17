using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHangDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<KhachHang> _lstKhachHang = null;
        public KhachHangDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //thêm 1 khách hàng mới
        public bool ThemKhachHang(KhachHang kh)
        {
            try
            {
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //tìm kiếm khách hàng theo mã khách hàng hoặc tên hoặc số điện thoại
        public List<KhachHang> TimKiemKhachHang(string key)
        {
            _lstKhachHang = new List<KhachHang>();
            _lstKhachHang = db.KhachHangs.Where(t => t.MaKhachHang.Contains(key) || t.TenKhachHang.Contains(key) || t.SoDienThoai.Contains(key)).ToList();
            return _lstKhachHang;
        }
        //lấy ra tất cả khách hàng
        public List<KhachHang> LayTatCaKhachHang()
        {
            try
            {
                _lstKhachHang = new List<KhachHang>();
                _lstKhachHang = db.KhachHangs.ToList();
                return _lstKhachHang;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //lấy khách hàng theo nhiều điều keienj
        public KhachHang LayKhachHangTheoDieuKien(string maKH, string tenKhachHang, string SDT)
        {
            try
            {
                var query = db.KhachHangs.AsQueryable(); // Khởi tạo truy vấn với đối tượng KhachHang

                // Kiểm tra các điều kiện và thêm vào truy vấn nếu điều kiện không null
                if (!string.IsNullOrEmpty(maKH))
                {
                    query = query.Where(kh => kh.MaKhachHang == maKH);
                }

                if (!string.IsNullOrEmpty(tenKhachHang))
                {
                    query = query.Where(kh => kh.TenKhachHang.Contains(tenKhachHang));
                }

                if (!string.IsNullOrEmpty(SDT))
                {
                    query = query.Where(kh => kh.SoDienThoai.Contains(SDT));
                }

                // Thực hiện truy vấn và trả về kết quả đầu tiên (nếu có)
                return query.FirstOrDefault(); // Trả về khách hàng đầu tiên thỏa mãn điều kiện
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Lỗi khi lấy khách hàng: {ex.Message}");
                return null;
            }
        }
        public bool AddDiemCongTichLuy(string maKhachHang, decimal diemCong)
        {
            try
            {
                // Kiểm tra xem khách hàng có tồn tại hay không
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang == null)
                {
                    Console.WriteLine("Khách hàng không tồn tại.");
                    return false; // Trả về false nếu khách hàng không tồn tại
                }

                // Cập nhật điểm tích lũy mới
                khachHang.DiemTichLuy = (khachHang.DiemTichLuy ?? 0) + diemCong;

                // Lưu lại thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();

                Console.WriteLine($"Thêm {diemCong} điểm cộng cho khách hàng {maKhachHang}. Điểm tích lũy hiện tại: {khachHang.DiemTichLuy}");
                return true; // Trả về true nếu việc thêm điểm thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false; // Trả về false nếu có lỗi
            }
        }

        // sửa thông tin khách hàng
        public bool SuathongtinKhachHang(KhachHang kh)
        {
            try
            {
                KhachHang khachHang = db.KhachHangs.FirstOrDefault(t => t.MaKhachHang == kh.MaKhachHang);
                khachHang.TenKhachHang = kh.TenKhachHang;
                khachHang.SoDienThoai = kh.SoDienThoai;
                khachHang.DiaChi = kh.DiaChi;
                khachHang.Email = kh.Email;
                khachHang.GioiTinh = kh.GioiTinh;
                khachHang.NgaySinh = kh.NgaySinh;
                khachHang.TrangThaiHoatDong = kh.TrangThaiHoatDong;
                khachHang.ThanhVien = kh.ThanhVien;
                khachHang.TaiKhoan = kh.TaiKhoan;
                khachHang.MatKhau = kh.MatKhau;
                khachHang.NgayCapNhat = kh.NgayCapNhat;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
