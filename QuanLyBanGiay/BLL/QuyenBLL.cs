using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuyenBLL
    {
        private QuyenDAL quyenDAL = new QuyenDAL();
        public QuyenBLL() { }
        public List<Quyen> LayDanhSachQuyen()
        {
            return quyenDAL.LayDanhSachQuyen();
        }
        public bool ThemQuyen(Quyen quyen)
        {
            return quyenDAL.ThemQuyen(quyen);
        }
        public bool CapNhatQuyen(Quyen quyen)
        {
            return quyenDAL.CapNhatQuyen(quyen);
        }
    }
}
