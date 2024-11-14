using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietKiemKeBLL
    {
        public ChiTietKiemKeBLL() { }
        ChiTietKiemKeDAL chiTietKiemKeDAL = new ChiTietKiemKeDAL();
        public List<ChiTietKiemKe> LayDanhSachChiTietKiemKe()
        {
            return chiTietKiemKeDAL.LayDanhSachChiTietKiemKe();
        }

        public List<ChiTietKiemKe> LayDanhSachChiTietKiemKe(string maKiemKe)
        {
            return chiTietKiemKeDAL.LayDanhSachChiTietKiemKe().Where(x => x.MaKiemKe == maKiemKe).ToList();
        }

        public bool ThemChiTietKiemKe(ChiTietKiemKe chiTietKiemKe)
        {
            return chiTietKiemKeDAL.ThemChiTietKiemKe(chiTietKiemKe);
        }
        public bool TimSanPhamTrongChiTietKiemKe(string maKiemKe, string maSanPham)
        {
            List<ChiTietKiemKe> lstCTKK = LayDanhSachChiTietKiemKe();
            if(lstCTKK.Where(p => p.MaKiemKe == maKiemKe && p.MaSanPham == maSanPham).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
        public bool XoaChiTietKiemKe(ChiTietKiemKe chiTietKiemKe)
        {
            return chiTietKiemKeDAL.XoaChiTietKiemKe(chiTietKiemKe);
        }

        public bool CapNhatChiTietKiemKe(ChiTietKiemKe chiTietKiemKe)
        {
            return chiTietKiemKeDAL.CapNhatChiTietKiemKe(chiTietKiemKe);
        }
    }
}
