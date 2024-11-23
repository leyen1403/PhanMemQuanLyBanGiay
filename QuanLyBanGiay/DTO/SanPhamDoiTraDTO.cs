using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDoiTraDTO
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SLHD { get; set; }
        public int SLTra { get; set; }
        public decimal GiaBan { get; set; }
        public decimal SoTienHoanLai { get; set; }
        public string TinhTrangSanPham { get; set; }
    }
}
