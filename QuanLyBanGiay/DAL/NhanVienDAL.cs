using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public bool CapNhatNhanVien(NhanVien nv)
        {
            try
            {
                NhanVien nvNew = db.NhanViens.Where(n => n.MaNhanVien == nv.MaNhanVien).FirstOrDefault();
                if (nvNew == null)
                {
                    return false;
                }
                else
                {
                    nvNew.TenNhanVien = nv.TenNhanVien;
                    nvNew.NgaySinh = nv.NgaySinh;
                    nvNew.GioiTinh = nv.GioiTinh;
                    nvNew.SoDienThoai = nv.SoDienThoai;
                    nvNew.Email = nv.Email;
                    nvNew.ChucVu = nv.ChucVu;
                    nvNew.TaiKhoan = nv.TaiKhoan;
                    nvNew.MatKhau = nv.MatKhau;
                    nvNew.HinhAnh = nv.HinhAnh;
                    nvNew.TrangThaiHoatDong = nv.TrangThaiHoatDong;
                    nvNew.NgayTao = nv.NgayTao;
                    nvNew.NgayCapNhat = nv.NgayCapNhat;
                    nvNew.DiaChi = nv.DiaChi;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                NhanVien nvNew = db.NhanViens.Where(x=>x.MaNhanVien == nv.MaNhanVien).FirstOrDefault();
                if(nvNew != null)
                {
                    return false;
                }
                else
                {
                    nvNew = new NhanVien();
                    nvNew.MaNhanVien = nv.MaNhanVien;
                    nvNew.TenNhanVien = nv.TenNhanVien;
                    nvNew.NgaySinh = nv.NgaySinh;
                    nvNew.GioiTinh = nv.GioiTinh;
                    nvNew.SoDienThoai = nv.SoDienThoai;
                    nvNew.Email = nv.Email;
                    nvNew.ChucVu = nv.ChucVu;
                    nvNew.TaiKhoan = nv.TaiKhoan;
                    nvNew.MatKhau = nv.MatKhau;
                    nvNew.HinhAnh = nv.HinhAnh;
                    nvNew.TrangThaiHoatDong = nv.TrangThaiHoatDong;
                    nvNew.NgayTao = nv.NgayTao;
                    nvNew.NgayCapNhat = nv.NgayCapNhat;
                    nvNew.DiaChi = nv.DiaChi;
                    db.NhanViens.InsertOnSubmit(nvNew);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
