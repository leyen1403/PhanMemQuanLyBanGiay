using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL _hoaDonDAL = null;
        public HoaDonBLL()
        {
            _hoaDonDAL = new HoaDonDAL();
        }
        public bool ThemHoaDon(HoaDon hd)
        {
            return _hoaDonDAL.ThemHoaDon(hd);
        }
        public List<HoaDon> LayTatCaHoaDon()
        {
            return _hoaDonDAL.LayTatCaHoaDon();
        }
        public List<HoaDon> TimHoaDonTheoMaHoaDon(string maHD)
        {
            return _hoaDonDAL.TimHoaDonTheoMaHoaDon(maHD);
        }
        public List<HoaDon> TimHoaDonTheoMaNhanVien(string maNV)
        {
            return _hoaDonDAL.TimHoaDonTheoMaNhanVien(maNV);
        }
        public List<HoaDon> TimHoaDonTheoKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            return _hoaDonDAL.TimHoaDonTheoKhoangThoiGian(tuNgay, denNgay);
        }
        public List<HoaDon> TimHoaDonTheoMaKhachHang(string maKH)
        {
            return _hoaDonDAL.TimHoaDonTheoMaKhachHang(maKH);
        }
        public List<HoaDon> TimHoaDonTheoTenKhachHangHoacSDT(string key)
        {
            return _hoaDonDAL.TimHoaDonTheoTenKhachHangHoacSDT(key);
        }
        public bool SuaHoaDon(HoaDon hd)
        {
            return _hoaDonDAL.SuaHoaDon(hd);
        }
        public List<HoaDon> TimKiemHoaDonTheoTenNhanVien(string key)
        {
            return _hoaDonDAL.TimHoaDonTheoTenNhanVien(key);
        }
    }
}
