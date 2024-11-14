using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LoaiSanPhamBLL
    {
        LoaiSanPhamDAL _loaiSanPhamDAL = new LoaiSanPhamDAL();
        public List<LoaiSanPham> layLoaiSanPhamTheoDieuKien(string dieuKien)
        {
            return _loaiSanPhamDAL.layLoaiSanPhamTheoDieuKien(dieuKien);
        }
        public List<LoaiSanPham> layTatCaLoaiSanPham()
        {
            return _loaiSanPhamDAL.layTatCaLoaiSanPham();
        }
        public LoaiSanPham layLoaiSanPhamTheoMa(string maLoaiSanPham)
        {
            return _loaiSanPhamDAL.layLoaiSanPhamTheoMa(maLoaiSanPham);
        }
        public LoaiSanPham layLoaiSanPhamTheoTen(string tenLoaiSanPham)
        {
            return _loaiSanPhamDAL.layLoaiSanPhamTheoTen(tenLoaiSanPham);
        }
        public bool themLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            return _loaiSanPhamDAL.themLoaiSanPham(loaiSanPham);
        }
        public bool xoaLoaiSanPham(string maLoaiSanPham,bool trangThai)
        {
            return _loaiSanPhamDAL.suaLoaiSanPham(maLoaiSanPham,trangThai);
        }
        public bool suaLoaiSanPham(LoaiSanPham loaiSanPham)
        {
            return _loaiSanPhamDAL.suaLoaiSanPham(loaiSanPham);
        }
    }
}
