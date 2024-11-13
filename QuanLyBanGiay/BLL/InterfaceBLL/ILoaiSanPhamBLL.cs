using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterfaceBLL
{
    public interface ILoaiSanPhamBLL
    {
        //Lấy tất cả loại sản phẩm
        List<LoaiSanPham> layTatCaLoaiSanPham();
        //lấy loại sản phẩm theo mã
        LoaiSanPham layLoaiSanPhamTheoMa(string maLoaiSanPham);
        //lấy loại sản phẩm theo tên
        LoaiSanPham layLoaiSanPhamTheoTen(string tenLoaiSanPham);
        //lấy loại sản phẩm theo nhiều điều kiện
        List<LoaiSanPham> layLoaiSanPhamTheoDieuKien(string dieuKien);
        //Thêm loại sản phẩm
        bool themLoaiSanPham(LoaiSanPham lsp);
        //Sửa loại sản phẩm
        bool suaLoaiSanPham(LoaiSanPham lsp);
        //Xóa loại sản phẩm
        bool suaLoaiSanPham(string maLoaiSanPham);
    }
}
