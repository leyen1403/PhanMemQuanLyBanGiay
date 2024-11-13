using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.Interface;
using DAL;

namespace BLL
{
    public class LoaiSanPhamBLL : ILoaiSanPhamDAL
    {
        LoaiSanPhamDAL _loaiSanPhamDAL = null;
        public LoaiSanPhamBLL()
        {
            _loaiSanPhamDAL = new LoaiSanPhamDAL();
        }
        public List<LoaiSanPham> layLoaiSanPhamTheoDieuKien(string dieuKien)
        {
            //kiểm tra điều kiện
            if (dieuKien == null)
            {
                return null;
            }
            //gọi hàm lấy loại sản phẩm theo điều kiện từ DAL
            return _loaiSanPhamDAL.layLoaiSanPhamTheoDieuKien(dieuKien);
        }

        public LoaiSanPham layLoaiSanPhamTheoMa(string maLoaiSanPham)
        {
            //kiểm tra mã loại sản phẩm
            if (maLoaiSanPham == null)
            {
                return null;
            }
            //gọi hàm lấy loại sản phẩm theo mã từ DAL
            return _loaiSanPhamDAL.layLoaiSanPhamTheoMa(maLoaiSanPham);
        }

        public LoaiSanPham layLoaiSanPhamTheoTen(string tenLoaiSanPham)
        {
            //kiểm tra tên loại sản phẩm
            if (tenLoaiSanPham == null)
            {
                return null;
            }
            //gọi hàm lấy loại sản phẩm theo tên từ DAL
            return _loaiSanPhamDAL.layLoaiSanPhamTheoTen(tenLoaiSanPham);
        }

        public List<LoaiSanPham> layTatCaLoaiSanPham()
        {
           return _loaiSanPhamDAL.layTatCaLoaiSanPham();
        }

        public bool suaLoaiSanPham(LoaiSanPham lsp)
        {
            //kiểm tra loại sản phẩm
            if (lsp == null)
            {
                return false;
            }
            //gọi hàm sửa loại sản phẩm từ DAL
            return _loaiSanPhamDAL.suaLoaiSanPham(lsp);
        }

        public bool suaLoaiSanPham(string maLoaiSanPham)
        {
            //kiểm tra mã loại sản phẩm
            if (maLoaiSanPham == null)
            {
                return false;
            }
            //gọi hàm sửa loại sản phẩm từ DAL
            return _loaiSanPhamDAL.suaLoaiSanPham(maLoaiSanPham);
        }

        public bool themLoaiSanPham(LoaiSanPham lsp)
        {
            //kiểm tra loại sản phẩm
            if (lsp == null)
            {
                return false;
            }
            //gọi hàm thêm loại sản phẩm từ DAL
            return _loaiSanPhamDAL.themLoaiSanPham(lsp);
        }
    }
}
