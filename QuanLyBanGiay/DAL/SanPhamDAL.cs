using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DTO;

namespace DAL
{
    public class SanPhamDAL : ISanPhamDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<SanPham> lstSanPham = null;
        public SanPhamDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }

        public List<SanPham> layDanhSachSanPhamKhongTrungTen()
        {
            try
            {
               var layDanhSachSanPhamKhongTrungTen = new List<SanPham>();
                lstSanPham = db.SanPhams.ToList();
                foreach (SanPham sp in lstSanPham)
                {
                    if (layDanhSachSanPhamKhongTrungTen.Contains(sp) == false)
                    {
                        layDanhSachSanPhamKhongTrungTen.Add(sp);
                    }
                }
                return layDanhSachSanPhamKhongTrungTen;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SanPham> laySanPhamKhongTrungTen(string tenSanPham)
        {
            throw new NotImplementedException();
        }

        public List<SanPham> laySanPhamTheoDieuKien(string dieuKien)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.TenSanPham.Contains(dieuKien) || sp.MaSanPham.Contains(dieuKien)).ToList();
                return lstSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SanPham laySanPhamTheoMa(string maSanPham)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.MaSanPham == maSanPham).ToList();
                return lstSanPham[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SanPham> layTatCaSanPham()
        {

            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.ToList();
                return lstSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool suaSanPham(SanPham sp)
        {
            try
            {
                var sanPham = db.SanPhams.Where(s => s.MaSanPham == sp.MaSanPham).SingleOrDefault();
                sanPham.TenSanPham = sp.TenSanPham;
                sanPham.MaLoaiSanPham = sp.MaLoaiSanPham;
                sanPham.MaThuongHieu = sp.MaThuongHieu;
                sanPham.MaMauSac = sp.MaMauSac;
                sanPham.MaKichThuoc = sp.MaKichThuoc;
                sanPham.DonViTinh = sp.DonViTinh;
                sanPham.SoLuongToiThieu = sp.SoLuongToiThieu;
                sanPham.GiaBan = sp.GiaBan;
                sanPham.GiaNhap = sp.GiaNhap;
                sanPham.SoLuong = sp.SoLuong;
                sanPham.MoTa = sp.MoTa;
                sanPham.HinhAnh = sp.HinhAnh;
                sanPham.NgayCapNhat= DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool themSanPham(SanPham sp)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool xoaSanPham(string maSanPham)
        {
            try
            {
                var sanPham = db.SanPhams.Where(s => s.MaSanPham == maSanPham).SingleOrDefault();
                db.SanPhams.DeleteOnSubmit(sanPham);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
