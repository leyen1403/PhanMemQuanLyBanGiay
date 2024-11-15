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
    }
}
