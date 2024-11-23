using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TraSanPhamChiTietBLL
    {
        public TraSanPhamChiTietBLL() { }
        TraSanPhamChiTietDAL traSanPhamChiTietDAL = new TraSanPhamChiTietDAL();
        public bool ThemTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            return traSanPhamChiTietDAL.ThemTraSanPhamChiTiet(traSanPhamChiTiet);
        }
        public bool CapNhatTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            return traSanPhamChiTietDAL.CapNhatTraSanPhamChiTiet(traSanPhamChiTiet);
        }
        public bool XoaTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            return traSanPhamChiTietDAL.XoaTraSanPhamChiTiet(traSanPhamChiTiet);
        }

        public List<TraSanPhamChiTiet> LayTraSanPhamChiTietTheoMaTraSanPham(string maTraSanPham)
        {
            return traSanPhamChiTietDAL.LayTraSanPhamChiTiet(maTraSanPham);
        }

        public TraSanPhamChiTiet LayTraSanPhamChiTietTheoMaTraSanPhamVaMaSanPham(string maPhieuHoanTra, string maSanPham)
        {
            return traSanPhamChiTietDAL.LayTraSanPhamChiTietTheoMaTraSanPhamVaMaSanPham(maPhieuHoanTra, maSanPham);
        }

        public bool ThemListTraSanPhamChiTiet(List<TraSanPhamChiTiet> lstTraSanPhamChiTiet)
        {
            return traSanPhamChiTietDAL.ThemListTraSanPhamChiTiet(lstTraSanPhamChiTiet);    
        }
    }
}
