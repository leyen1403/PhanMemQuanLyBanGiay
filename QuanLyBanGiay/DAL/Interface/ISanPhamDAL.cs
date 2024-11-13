using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Interface
{
    public interface ISanPhamDAL
    {

        //Lấy sản phẩm không trùng tên
        List<SanPham> laySanPhamKhongTrungTen(string tenSanPham);

        //Lấy danh sách sản phẩm không trùng tên
        List<SanPham> layDanhSachSanPhamKhongTrungTen();

        // Lấy toàn bộ dữ liệu
        List<SanPham> layTatCaSanPham();

        //Lấy một sản phẩm theo mã
        SanPham laySanPhamTheoMa(string maSanPham);

        //Lấy sản phẩm theo nhiều điều kiện
        List<SanPham> laySanPhamTheoDieuKien(string dieuKien);

        //Thêm một sản phẩm
        bool themSanPham(SanPham sp);

        //Sửa thông tin sản phẩm
        bool suaSanPham(SanPham sp);

        //Xóa sản phẩm
        bool xoaSanPham(string maSanPham);
    }
}