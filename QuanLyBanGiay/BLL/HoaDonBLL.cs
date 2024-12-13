using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;
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
        public HoaDon TimHoaDonByMaHoaDon(string maHoaDon)
        {
            return _hoaDonDAL.LayTatCaHoaDon().Where(t => t.MaHoaDon == maHoaDon).FirstOrDefault();
        }
        public bool CapNhatDonHang(string maHD, string DonHang)
        {
            return _hoaDonDAL.CapNhatDonHang(maHD, DonHang);
        }
        //Nam viết thêm 
        public DataTable GetTongTienTheoNgayDataTable(DateTime startDate, DateTime endDate)
        {
            return _hoaDonDAL.GetTongTienTheoNgayDataTable(startDate, endDate);
        }

        public DataTable GetTongTienTheoNgayDataTable()
        {
            return _hoaDonDAL.GetTongTienTheoNgayDataTable();
        }

        public List<PhieuBaoCao> LayPhieuBaoCaoTheoKhoangThoiGian(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return _hoaDonDAL.LayPhieuBaoCaoTheoKhoangThoiGian(ngayBatDau, ngayKetThuc);
        }


    }
}
