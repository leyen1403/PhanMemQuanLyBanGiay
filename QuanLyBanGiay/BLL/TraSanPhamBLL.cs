using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class TraSanPhamBLL
    {
        public TraSanPhamBLL() { }
        TraSanPhamDAL traSanPhamDAL = new TraSanPhamDAL();
        public bool ThemTraSanPham(TraSanPham traSanPham)
        {
            return traSanPhamDAL.ThemTraSanPham(traSanPham);
        }
        public bool CapNhatTraSanPham(TraSanPham traSanPham)
        {
            return traSanPhamDAL.CapNhatTraSanPham(traSanPham);
        }
        public List<TraSanPham> LayDanhSachTraSanPham()
        {
            return traSanPhamDAL.LayDanhSachTraSanPham();
        }
    }
}
