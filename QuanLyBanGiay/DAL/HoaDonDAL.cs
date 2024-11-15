using System;
using System.Collections.Generic;
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
    }
}
