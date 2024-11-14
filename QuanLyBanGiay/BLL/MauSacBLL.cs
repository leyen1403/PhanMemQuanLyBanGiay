using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class MauSacBLL
    {
        MauSacDAL _mauSacDAL = null;
        public MauSacBLL()
        {
            _mauSacDAL = new MauSacDAL();
        }
        public List<MauSac> layTatCaMauSac()
        {
            return _mauSacDAL.layTatCaMauSac();
        }
        public MauSac layMauSacTheoMa(string maMauSac)
        {
            return _mauSacDAL.layMauSacTheoMa(maMauSac);
        }
        public MauSac layMauSacTheoTen(string tenMauSac)
        {
            return _mauSacDAL.layMauSacTheoTen(tenMauSac);
        }
        public bool themMauSac(MauSac mauSac)
        {
            return _mauSacDAL.themMauSac(mauSac);
        }
        public bool xoaMauSac(string maMauSac, bool trangThai)
        {
            return _mauSacDAL.xoaMauSac(maMauSac, trangThai);
        }
        public bool suaMauSac(MauSac mauSac)
        {
            return _mauSacDAL.suaMauSac(mauSac);
        }
        public List<MauSac> layTatCaMauSacTheoTenSanPham(string tenSanPham)

        {
            return _mauSacDAL.layTatCaMauSacTheoTenSanPham(tenSanPham);
        }
    }
}
