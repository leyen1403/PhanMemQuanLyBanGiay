using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienDAL
    {
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public NhanVienDAL() { }
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                NhanVien nv = db.NhanViens.Where(n => n.TaiKhoan == tenDangNhap && n.MatKhau == matKhau).FirstOrDefault();
                if (nv == null || nv.TrangThaiHoatDong == false)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public NhanVien LayNhanVien(string tenDangNhap, string matKhau)
        {
            try
            {
                NhanVien nv = db.NhanViens.Where(n => n.TaiKhoan == tenDangNhap && n.MatKhau == matKhau).FirstOrDefault();
                return nv;
            }
            catch
            {
                return null;
            }
        }
        public NhanVien LayNhanVien(string maNhanVien)
        {
            return db.NhanViens.Where(n => n.MaNhanVien == maNhanVien).FirstOrDefault();
        }
        public List<NhanVien> LayDanhSachNhanVien()
        {
            return db.NhanViens.ToList();
        }
    }
}
