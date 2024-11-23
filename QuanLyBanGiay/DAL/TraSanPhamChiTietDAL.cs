using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class TraSanPhamChiTietDAL
    {
        public TraSanPhamChiTietDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public bool ThemTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            try
            {
                db.TraSanPhamChiTiets.InsertOnSubmit(traSanPhamChiTiet);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhatTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            try
            {
                TraSanPhamChiTiet tspctNew = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                if (tspctNew == null)
                {
                    return false;
                }
                tspctNew.SoLuong = traSanPhamChiTiet.SoLuong;
                tspctNew.SoTienHoanLai = traSanPhamChiTiet.SoTienHoanLai;
                tspctNew.TinhTrangSanPham = traSanPhamChiTiet.TinhTrangSanPham;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            try
            {
                TraSanPhamChiTiet tspct = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                if (tspct == null)
                {
                    return false;
                }
                db.TraSanPhamChiTiets.DeleteOnSubmit(tspct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<TraSanPhamChiTiet> LayTraSanPhamChiTiet()
        {
            return db.TraSanPhamChiTiets.ToList();
        }
        public List<TraSanPhamChiTiet> LayTraSanPhamChiTiet(string maTraSanPham)
        {
            return LayTraSanPhamChiTiet().Where(p => p.MaTraSanPham == maTraSanPham).ToList();
        }

        public TraSanPhamChiTiet LayTraSanPhamChiTietTheoMaTraSanPhamVaMaSanPham(string maPhieuHoanTra, string maSanPham)
        {
            return db.TraSanPhamChiTiets.FirstOrDefault(p => p.MaTraSanPham == maPhieuHoanTra && p.MaSanPham == maSanPham);
        }

        public bool ThemListTraSanPhamChiTiet(List<TraSanPhamChiTiet> lstTraSanPhamChiTiet)
        {
            try
            {
                db.TraSanPhamChiTiets.InsertAllOnSubmit(lstTraSanPhamChiTiet);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
