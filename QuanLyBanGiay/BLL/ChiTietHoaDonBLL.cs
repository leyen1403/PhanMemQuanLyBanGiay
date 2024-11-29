using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class ChiTietHoaDonBLL
    {
        ChiTietHoaDonDAL _chiTietHoaDonDAL = null;
        public ChiTietHoaDonBLL()
        {
            _chiTietHoaDonDAL = new ChiTietHoaDonDAL();
        }
        public bool ThemChiTietHoaDon(ChiTietHoaDon cthd)
        {
            return _chiTietHoaDonDAL.ThemChiTietHoaDon(cthd);
        }
        public List<ChiTietHoaDon> LayChiTietHoaDonTheoMaHoaDon(string maHoaDon)
        {
            return _chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(maHoaDon);
        }
        public List<ChiTietHoaDon> LayTatCaChiTietHoaDon()
        {
            return _chiTietHoaDonDAL.LayTatCaChiTietHoaDon();
        }
        //tìm chi tiết hóa đơn theo mã hoá đơn
        public List<ChiTietHoaDon> TimChiTietHoaDonTheoMaHoaDon(string maHD)
        {
            return _chiTietHoaDonDAL.TimChiTietHoaDonTheoMaHoaDon(maHD);
        }

        public List<ChiTietHoaDon> LayDanhSachChiTietHoaDonTheoMaHoaDon(string maHoaDon)
        {
            return _chiTietHoaDonDAL.LayDanhSachChiTietHoaDonTheoMaHoaDon(maHoaDon);
        }
    }
}
