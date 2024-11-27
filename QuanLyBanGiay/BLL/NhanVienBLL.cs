using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NhanVienBLL
    {
        public NhanVienBLL() { }
        NhanVienDAL _nhanVienDAL = new NhanVienDAL();
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            return _nhanVienDAL.KiemTraDangNhap(tenDangNhap, matKhau);
        }
        public NhanVien LayNhanVien(string tenDangNhap, string matKhau)
        {
            return _nhanVienDAL.LayNhanVien(tenDangNhap, matKhau);
        }
        public NhanVien LayNhanVien(string maNhanVien)
        {
            return _nhanVienDAL.LayNhanVien(maNhanVien);
        }
        public List<NhanVien> LayDanhSachNhanVien()
        {
            return _nhanVienDAL.LayDanhSachNhanVien();
        }
        public bool CapNhatNhanVien(NhanVien nv)
        {
            return _nhanVienDAL.CapNhatNhanVien(nv);
        }
        public List<NhanVien> LayNhanVienTheoVaiTro(string maVaiTro)
        {
            List<NhanVien> lstNhanVien = _nhanVienDAL.LayDanhSachNhanVien();
            List<NhanVien> lstNhanVienTheoVaiTro = new List<NhanVien>();
            NhanVien_VaiTroBLL nhanVien_VaiTroBLL = new NhanVien_VaiTroBLL();
            List<NhanVien_VaiTro> lstNhanVien_VaiTro = nhanVien_VaiTroBLL.LayDanhSachNhanVien_VaiTro();
            foreach (NhanVien nv in lstNhanVien)
            {
                foreach (NhanVien_VaiTro nvt in lstNhanVien_VaiTro)
                {
                    if (nv.MaNhanVien == nvt.MaNhanVien && nvt.MaVaiTro == maVaiTro)
                    {
                        lstNhanVienTheoVaiTro.Add(nv);
                        break;
                    }
                }
            }
            return lstNhanVienTheoVaiTro;
        }
        public bool ThemNhanVien(NhanVien nv)
        {
            return _nhanVienDAL.ThemNhanVien(nv);
        }

        public NhanVien LayNhanVienTheoMa(string maNhanVien)
        {
            return LayNhanVien(maNhanVien);
        }

        public bool XoaNhanVien(NhanVien nv)
        {
            return _nhanVienDAL.XoaNhanVien(nv) ;
        }
    }
}
