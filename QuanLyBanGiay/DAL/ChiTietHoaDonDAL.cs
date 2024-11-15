using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ChiTietHoaDonDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<ChiTietHoaDon> listChiTietHoaDon = null;
        public ChiTietHoaDonDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //viết phương thức thêm vào chi tiết hoá đơn
        public bool ThemChiTietHoaDon(ChiTietHoaDon cthd)
        {
            try
            {
                db.ChiTietHoaDons.InsertOnSubmit(cthd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ChiTietHoaDon> LayChiTietHoaDonTheoMaHoaDon(string maHoaDon)
        {
            try
            {
                listChiTietHoaDon = db.ChiTietHoaDons.Where(n => n.MaHoaDon == maHoaDon).ToList();
                return listChiTietHoaDon;
            }
            catch
            {
                return null;
            }
        }
        //lấy tất cả chi tiết hoá đơn
        public List<ChiTietHoaDon> LayTatCaChiTietHoaDon()
        {
            try
            {
                listChiTietHoaDon = db.ChiTietHoaDons.ToList();
                return listChiTietHoaDon;
            }
            catch
            {
                return null;
            }
        }
        //tìm chi tiết hóa đơn theo mã hoá đơn
        public List<ChiTietHoaDon> TimChiTietHoaDonTheoMaHoaDon(string maHD)
        {
            try
            {
                listChiTietHoaDon = db.ChiTietHoaDons.Where(t => t.MaHoaDon.Contains(maHD)).ToList();
                return listChiTietHoaDon;
            }
            catch
            {
                return null;
            }
        }
    }
}
