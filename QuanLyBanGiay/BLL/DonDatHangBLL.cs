using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DonDatHangBLL
    {
        public DonDatHangBLL() { }
        DonDatHangDAL donDatHangDAL = new DonDatHangDAL();
        ChiTietDonDatHangDAL chiTietDonDatHangDAL = new ChiTietDonDatHangDAL();
        public List<DonDatHang> LayDanhSachDonDatHang()
        {
            return donDatHangDAL.LayDanhSachDonDatHang();
        }
        public bool CapNhatDonDatHang(DonDatHang ddh)
        {
            return donDatHangDAL.CapNhatDonDatHang(ddh);
        }
        public bool ThemDonDatHang(DonDatHang ddh)
        {
            return donDatHangDAL.ThemDonDatHang(ddh);
        }
        public bool XoaDonDatHang(DonDatHang ddh)
        {
            return donDatHangDAL.XoaDonDatHang(ddh);
        }
        public decimal TinhTongTienDonDatHang(string maDonDatHang)
        {
            List<ChiTietDonDatHang> lstCTDDH = chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDonDatHang);
            decimal tongTien = 0;
            foreach (ChiTietDonDatHang ctddh in lstCTDDH)
            {
                tongTien += ctddh.ThanhTien ?? 0;
            }
            return tongTien;
        }
    }
}
