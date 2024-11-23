using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DoanhThuTheoThangHoacTuan
    {
        public int Nam { get; set; }
        public int Thang { get; set; }
        public int Tuan { get; set; }
        public decimal TongDoanhThu { get; set; }
        public int SoLuongHoaDon { get; set; }
        public int TongSoLuongSanPham { get; set; }  // Thêm thuộc tính này

        public List<LoaiSanPhamThongKe> LoaiSanPhamThongKes { get; set; }

        public class LoaiSanPhamThongKe
        {
            public string LoaiSanPham { get; set; }
            public int SoLuongBanRa { get; set; }
            public double TyLePhanTram { get; set; }  // Thêm trường này
        }
    }
}

