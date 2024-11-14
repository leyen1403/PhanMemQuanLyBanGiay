using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL sanPhamDAL = null;
        public SanPhamBLL()
        {
            sanPhamDAL = new SanPhamDAL();
        }
        public List<SanPham> layDanhSachSanPhamKhongTrungTen()
        {
            return sanPhamDAL.layDanhSachSanPhamKhongTrungTen();
        }

        public List<SanPham> laySanPhamTheoDieuKien(string dieuKien)
        {
            return sanPhamDAL.laySanPhamTheoDieuKien(dieuKien);
        }

        public List<SanPham> layDanhSachSanPham()
        {
            return sanPhamDAL.layTatCaSanPham();
        }

        public SanPham laySanPhamTheoMa(string maSanPham)
        {
            return sanPhamDAL.laySanPhamTheoMa(maSanPham);
        }
        public bool themSanPham(SanPham sp)
        {
            return sanPhamDAL.themSanPham(sp);
        }
        public bool suaSanPham(SanPham sp)
        {
            return sanPhamDAL.suaSanPham(sp);
        }
        public bool xoaSanPham(string maSanPham,bool trangThai)
        {
            return sanPhamDAL.xoaSanPham(maSanPham,trangThai);
        }

        public string timKiemMaSanPham(string tenSanPham,string maKichThuoc,string maSac)
        {
            return sanPhamDAL.timKiemMaSanPham(tenSanPham,maKichThuoc,maSac);
        }

    }
}
