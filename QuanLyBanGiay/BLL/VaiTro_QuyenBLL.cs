using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class VaiTro_QuyenBLL
    {
        public VaiTro_QuyenBLL() { }
        public List<VaiTro_Quyen> LayDanhSachVaiTro_Quyen()
        {
            return new VaiTro_QuyenDAL().LayDanhSachVaiTro_Quyen();
        }
        public bool XoaQuyenRaKhoiVaiTro(string maVaiTro)
        {
            return new VaiTro_QuyenDAL().XoaQuyenRaKhoiVaiTro(maVaiTro);
        }
        public bool ThemQuyenVaoVaiTro(string maVaiTro, string maQuyen)
        {
            return new VaiTro_QuyenDAL().ThemQuyenVaoVaiTro(maVaiTro, maQuyen);
        }
        public bool ThemQuyenVaoVaiTro(string maVaiTro, List<string> maQuyen)
        {
            try
            {
                foreach (string item in maQuyen)
                {
                    if (!ThemQuyenVaoVaiTro(maVaiTro, item))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
