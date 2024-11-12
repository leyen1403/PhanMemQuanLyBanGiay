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
    }
}
