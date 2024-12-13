using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class HoaDonDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<HoaDon> listHoaDon = new List<HoaDon>();
        public HoaDonDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //viết phương thức thêm vào hoá đơn
        public bool ThemHoaDon(HoaDon hd)
        {
            try
            {
                db.HoaDons.InsertOnSubmit(hd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //viết phương thức lấy ra tất cả hoá đơn
        public List<HoaDon> LayTatCaHoaDon()
        {
            try
            {
                listHoaDon = db.HoaDons.ToList();
                return listHoaDon;
            }
            catch
            {
                return null;
            }
        }

        //viết phương thức tìm hoá đơn theo mã hoá đơn
        public List<HoaDon> TimHoaDonTheoMaHoaDon(string maHD)
        {
            try
            {
                listHoaDon = db.HoaDons.Where(t => t.MaHoaDon.Contains(maHD)).ToList();
                return listHoaDon;
            }
            catch
            {
                return null;
            }
        }
        //viết phương thức tìm hoá đơn theo mã nhân viên 
        public List<HoaDon> TimHoaDonTheoMaNhanVien(string maNV)
        {
            try
            {
                listHoaDon = db.HoaDons.Where(t => t.MaNhanVien.Contains(maNV)).ToList();
                return listHoaDon;
            }
            catch
            {
                return null;
            }
        }

        //viết phương thức tìm hoá đơn theo mã khách hàng
        public List<HoaDon> TimHoaDonTheoMaKhachHang(string maKH)
        {
            try
            {
                listHoaDon = db.HoaDons.Where(t => t.MaKhachHang.Contains(maKH)).ToList();
                return listHoaDon;
            }
            catch
            {
                return null;
            }
        }
        // viết phương thức tìm hoá đơn theo khoảng thời gian
        public List<HoaDon> TimHoaDonTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                listHoaDon = db.HoaDons.Where(t => t.NgayTao >= tuNgay && t.NgayTao <= denNgay).ToList();
                return listHoaDon;
            }
            catch
            {
                return null;
            }
        }
        //viết phương thức sửa hoá đơn
        public bool SuaHoaDon(HoaDon hd)
        {
            try
            {
                HoaDon hoaDon = db.HoaDons.Single(t => t.MaHoaDon == hd.MaHoaDon);
                hoaDon.MaKhachHang = hd.MaKhachHang;
                hoaDon.MaNhanVien = hd.MaNhanVien;
                hoaDon.NgayTao = hd.NgayTao;
                hoaDon.TongTien = hd.TongTien;
                hoaDon.GhiChu = hd.GhiChu;
                hoaDon.DiemTichLuySuDung = hd.DiemTichLuySuDung;
                hoaDon.PhuongThucThanhToan = hd.PhuongThucThanhToan;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // viết phương thức tìm hoá đơn theo tên khách hàng hoặc số điện thoại
        public List<HoaDon> TimHoaDonTheoTenKhachHangHoacSDT(string key)
        {
            try
            {
                // Thực hiện join bảng KhachHang và tìm kiếm
                var listHoaDon = db.HoaDons
                    .Where(hd => hd.KhachHang.TenKhachHang.Contains(key)
                              || hd.KhachHang.SoDienThoai.Contains(key))
                    .ToList();

                return listHoaDon;
            }
            catch
            {
                return null; // Trả về null nếu xảy ra lỗi
            }
        }
        public List<HoaDon> TimHoaDonTheoTenNhanVien(string key)
        {
            try
            {
                // Thực hiện join bảng NhanVien và tìm kiếm
                var listHoaDon = db.HoaDons
                    .Where(hd => hd.NhanVien.TenNhanVien.Contains(key))
                    .ToList();

                return listHoaDon;
            }
            catch
            {
                return null; // Trả về null nếu xảy ra lỗi
            }
        }
        //cập nhật trạng thái đơn hàng
        public bool CapNhatDonHang(string maHD, string DonHang)
        {
            try
            {
                var donHang = db.HoaDons.FirstOrDefault(hd => hd.MaHoaDon == maHD);
                if (donHang == null)
                {
                    Console.WriteLine("Không tìm thấy hóa đơn để cập nhật.");
                    return false;
                }
                donHang.TrangThai = DonHang;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                return false;

            }
        }
        public DataTable GetTongTienTheoNgayDataTable()
        {
            // Lấy dữ liệu nhóm theo ngày
            var tongTienTheoNgay = db.HoaDons
                .Where(hd => hd.NgayTao.HasValue) // Chỉ lấy các hóa đơn có NgayLap
                .GroupBy(hd => hd.NgayTao.Value.Date) // Nhóm theo ngày
                .Select(g => new
                {
                    Ngay = g.Key,
                    TongTien = g.Sum(hd => hd.TongTien)
                }).ToList();

            // Tạo DataTable để trả về
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày", typeof(DateTime));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            // Thêm dữ liệu vào DataTable
            foreach (var item in tongTienTheoNgay)
            {
                dataTable.Rows.Add(item.Ngay, item.TongTien);
            }

            return dataTable;
        }

        public DataTable GetTongTienTheoNgayDataTable(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            // Lấy dữ liệu nhóm theo ngày
            var tongTienTheoNgay = db.HoaDons
                .Where(hd => hd.NgayTao.HasValue && // Lọc các hóa đơn có NgayLap
                             hd.NgayTao.Value >= ngayBatDau &&
                             hd.NgayTao.Value <= ngayKetThuc)
                .GroupBy(hd => hd.NgayTao.Value.Date) // Nhóm theo ngày
                .Select(g => new
                {
                    Ngay = g.Key,
                    TongTien = g.Sum(hd => hd.TongTien)
                }).ToList();

            // Tạo DataTable để trả về
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày", typeof(DateTime));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            foreach (var item in tongTienTheoNgay)
            {
                dataTable.Rows.Add(item.Ngay, item.TongTien);
            }

            return dataTable;
        }


        public List<PhieuBaoCao> LayPhieuBaoCaoTheoKhoangThoiGian(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            // Lọc các hóa đơn bán hàng trong khoảng thời gian từ ngày bắt đầu đến ngày kết thúc
            var donHangs = db.HoaDons
                .Where(dh => dh.NgayTao.HasValue
                             && dh.NgayTao.Value >= ngayBatDau.Date
                             && dh.NgayTao.Value < ngayKetThuc.Date.AddDays(1)) // so sánh ngày kết thúc với 23:59:59
                .ToList();

            Console.WriteLine($"Số hóa đơn bán hàng trong khoảng thời gian: {donHangs.Count}");  // Thêm log kiểm tra

            List<PhieuBaoCao> danhSachPhieuBaoCao = new List<PhieuBaoCao>();
            int i = 1;

            foreach (var donHang in donHangs)
            {
                // Lọc chi tiết đơn hàng cho từng hóa đơn
                var chiTietDonHangs = db.ChiTietHoaDons
                    .Where(ct => ct.MaHoaDon == donHang.MaHoaDon)
                    .ToList();

                Console.WriteLine($"Số chi tiết đơn hàng trong hóa đơn {donHang.MaHoaDon}: {chiTietDonHangs.Count}");

                foreach (var chiTiet in chiTietDonHangs)
                {
                    // Lấy thông tin sản phẩm
                    var sanPham = db.SanPhams
                        .FirstOrDefault(sp => sp.MaSanPham == chiTiet.MaSanPham);

                    if (sanPham != null)
                    {
                        // Tính thành tiền
                        decimal thanhTien = (chiTiet.SoLuong ?? 0) * (sanPham.GiaBan ?? 0);

                        // Tạo báo cáo
                        PhieuBaoCao pbc = new PhieuBaoCao
                        {
                            STT = i.ToString(),
                            MASANPHAM = sanPham.MaSanPham,
                            TENSANPHAM = sanPham.TenSanPham,
                            SOLUONG = chiTiet.SoLuong ?? 0,
                            DONGIA = sanPham.GiaBan ?? 0,
                            THANHTIEN = thanhTien,
                            NGAY = donHang.NgayTao ?? DateTime.MinValue
                        };

                        danhSachPhieuBaoCao.Add(pbc);
                        i++;
                    }
                }
            }

            Console.WriteLine($"Số phiếu báo cáo: {danhSachPhieuBaoCao.Count}");

            return danhSachPhieuBaoCao;
        }


    }
}
