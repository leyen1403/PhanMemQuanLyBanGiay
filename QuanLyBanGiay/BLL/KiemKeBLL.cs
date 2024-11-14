using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class KiemKeBLL
    {
        public KiemKeBLL() { }
        KiemKeDAL kiemKeDAL = new KiemKeDAL();
        public List<KiemKe> LayDanhSachKiemKe()
        {
            return kiemKeDAL.LayDanhSachKiemKe();
        }
        public bool ThemKiemKe(KiemKe kiemKe)
        {
            return kiemKeDAL.ThemKiemKe(kiemKe);
        }
        public bool CapNhatKiemKe(KiemKe kiemKe)
        {
            return kiemKeDAL.CapNhatKiemKe(kiemKe);
        }
    }
}
