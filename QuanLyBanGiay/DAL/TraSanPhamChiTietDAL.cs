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
                TraSanPhamChiTiet t = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                if (t != null)
                {
                    return false;
                }
                else
                {
                    db.TraSanPhamChiTiets.InsertOnSubmit(traSanPhamChiTiet);
                    db.SubmitChanges();
                    return true;
                }
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
                TraSanPhamChiTiet traSanPhamChiTietUpdate = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                traSanPhamChiTietUpdate.MaHoaDon = traSanPhamChiTiet.MaHoaDon;
                traSanPhamChiTietUpdate.SoLuong = traSanPhamChiTiet.SoLuong;
                traSanPhamChiTietUpdate.TinhTrangSanPham = traSanPhamChiTiet.TinhTrangSanPham;
                traSanPhamChiTietUpdate.SoTienHoanLai = traSanPhamChiTiet.SoTienHoanLai;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            try
            {
                TraSanPhamChiTiet traSanPhamChiTietDelete = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                db.TraSanPhamChiTiets.DeleteOnSubmit(traSanPhamChiTietDelete);
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
    }
}
