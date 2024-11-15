using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietDonDatHangBLL
    {
        public ChiTietDonDatHangBLL() { }
        ChiTietDonDatHangDAL chiTietDonDatHangDAL = new ChiTietDonDatHangDAL();
        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHang()
        {
            return chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHang();
        }
        public bool ThemChiTietDonDatHang(ChiTietDonDatHang ctdh)
        {
            return chiTietDonDatHangDAL.ThemChiTietDonDatHang(ctdh);
        }
        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHangTheoMaDDH(string maDDH)
        {
            return chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH);
        }

        public decimal tinhTongTien(string maDonDatHang)
        {
            List<ChiTietDonDatHang> lstCTDDH = chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDonDatHang);
            decimal tongTien = 0;
            foreach (ChiTietDonDatHang ctddh in lstCTDDH)
            {
                tongTien += ctddh.ThanhTien ?? 0;
            }
            return tongTien;
        }
        
        public bool CapNhatChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            return chiTietDonDatHangDAL.CapNhatChiTietDonDatHang(ctddh);
        }

        public bool XoaChiTietDonDatHang(string maDonDatHang, string maSanPham)
        {
            return chiTietDonDatHangDAL.XoaChiTietDonDatHang(maDonDatHang, maSanPham);
        }
    }
}
