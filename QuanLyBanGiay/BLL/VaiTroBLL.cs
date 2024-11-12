using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class VaiTroBLL
    {
        public VaiTroBLL() { }
        VaiTroDAL _vaiTroDAL = new VaiTroDAL();
        public List<VaiTro> LayDanhSachVaiTro()
        {
            return _vaiTroDAL.LayDanhSachVaiTro();
        }
        public bool ThemVaiTro(VaiTro vt)
        {
            return _vaiTroDAL.ThemVaiTro(vt);
        }
        public bool CapNhatVaiTro(VaiTro vaiTro)
        {
            return _vaiTroDAL.CapNhatVaiTro(vaiTro);
        }
    }
}
