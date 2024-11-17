using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TraSanPhamDAL
    {
        public TraSanPhamDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public bool ThemTraSanPham(TraSanPham traSanPham)
        {
            try
            {
                db.TraSanPhams.InsertOnSubmit(traSanPham);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CapNhatTraSanPham(TraSanPham traSanPham)
        {
            try
            {
                TraSanPham traSanPhamUpdate = db.TraSanPhams.Where(p => p.MaTraSanPham == traSanPham.MaTraSanPham).FirstOrDefault();
                traSanPhamUpdate.MaHoaDon = traSanPham.MaHoaDon;
                traSanPhamUpdate.MaKhachHang = traSanPham.MaKhachHang;
                traSanPhamUpdate.MaNhanVien = traSanPham.MaNhanVien;
                traSanPhamUpdate.LyDoTra = traSanPham.LyDoTra;
                traSanPhamUpdate.NgayTra = traSanPham.NgayTra;
                traSanPhamUpdate.TongTienHoanLai = traSanPham.TongTienHoanLai;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TraSanPham> LayDanhSachTraSanPham()
        {
            return db.TraSanPhams.ToList();
        }
    }
}
