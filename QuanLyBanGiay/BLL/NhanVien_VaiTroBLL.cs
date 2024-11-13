using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVien_VaiTroBLL
    {
        public NhanVien_VaiTroBLL() { }
        NhanVien_VaiTroDAL nhanVien_VaiTroDAL = new NhanVien_VaiTroDAL();
        public bool XoaNhanVienKhoiVaiTro(string maNhanVien)
        {
            return nhanVien_VaiTroDAL.XoaNhanVienKhoiVaiTro(maNhanVien);
        }
        public bool ThemNhanVienVaoVaiTro(string maNhanVien, string maVaiTro)
        {
            return nhanVien_VaiTroDAL.ThemNhanVienVaoVaiTro(maNhanVien, maVaiTro);
        }
        public bool ThemNhanVienVaoVaiTro(string maNhanVien, List<string> maVaiTro)
        {
            foreach(string item in maVaiTro)
            {
                NhanVien_VaiTro nhanVien_VaiTro = new NhanVien_VaiTro();
                nhanVien_VaiTro.MaNhanVien = maNhanVien;
                nhanVien_VaiTro.MaVaiTro = item;
                if(!ThemNhanVienVaoVaiTro(nhanVien_VaiTro.MaNhanVien, nhanVien_VaiTro.MaVaiTro))
                {
                    return false;
                }
            }
            return true;
        }
        public List<NhanVien_VaiTro> LayDanhSachNhanVien_VaiTro()
        {
            return nhanVien_VaiTroDAL.LayDanhSachNhanVien_VaiTro();
        }
    }
}
