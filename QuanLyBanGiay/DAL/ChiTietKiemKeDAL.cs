using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietKiemKeDAL
    {
        public ChiTietKiemKeDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public List<ChiTietKiemKe> LayDanhSachChiTietKiemKe()
        {
            return db.ChiTietKiemKes.ToList();
        }
        public bool ThemChiTietKiemKe(ChiTietKiemKe chiTietKiemKe)
        {
            try
            {
                ChiTietKiemKe chiTietKiemKe1 = db.ChiTietKiemKes.Where(p => p.MaKiemKe == chiTietKiemKe.MaKiemKe && p.MaSanPham == chiTietKiemKe.MaSanPham).FirstOrDefault();
                if (chiTietKiemKe1 != null) { return false; }
                SanPham spNew = db.SanPhams.Where(p => p.MaSanPham == chiTietKiemKe.MaSanPham).FirstOrDefault();
                if (spNew != null)
                {
                    spNew.SoLuong = chiTietKiemKe.SoLuongThucTe;
                    spNew.NgayCapNhat = DateTime.Now;
                }
                db.ChiTietKiemKes.InsertOnSubmit(chiTietKiemKe);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool XoaChiTietKiemKe(ChiTietKiemKe chiTietKiemKe)
        {
            try
            {
                ChiTietKiemKe chiTietKiemKe1 = db.ChiTietKiemKes.Where(p => p.MaKiemKe == chiTietKiemKe.MaKiemKe && p.MaSanPham == chiTietKiemKe.MaSanPham).FirstOrDefault();
                if (chiTietKiemKe1 == null) { return false; }
                db.ChiTietKiemKes.DeleteOnSubmit(chiTietKiemKe1);
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool CapNhatChiTietKiemKe(ChiTietKiemKe chiTietKiemKe)
        {
            try
            {
                ChiTietKiemKe ctkkNew = db.ChiTietKiemKes.Where(p => p.MaKiemKe == chiTietKiemKe.MaKiemKe && p.MaSanPham == chiTietKiemKe.MaSanPham).FirstOrDefault();
                if (ctkkNew == null) { return false; }
                ctkkNew.SoLuongHeThong = chiTietKiemKe.SoLuongHeThong;
                ctkkNew.SoLuongThucTe = chiTietKiemKe.SoLuongThucTe;
                ctkkNew.ChenhLech = chiTietKiemKe.ChenhLech;
                ctkkNew.LyDoChenhLech = chiTietKiemKe.LyDoChenhLech;

                SanPham spNew = db.SanPhams.Where(p => p.MaSanPham == chiTietKiemKe.MaSanPham).FirstOrDefault();
                if (spNew != null)
                {
                    spNew.SoLuong = chiTietKiemKe.SoLuongThucTe;
                    spNew.NgayCapNhat = DateTime.Now;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
