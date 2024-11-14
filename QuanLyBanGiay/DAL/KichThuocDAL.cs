using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KichThuocDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<KichThuoc> kichThuocs = new List<KichThuoc>();
        public KichThuocDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //viết phương thức lấy tất cả kích thước
        public List<KichThuoc> LayTatCaKichThuoc()
        {
            kichThuocs = new List<KichThuoc>();
            kichThuocs = db.KichThuocs.ToList();
            return kichThuocs;
        }
        //viết phương thức tìm kiếm theo mã kích thước
        public KichThuoc TimKiemTheoMaKichThuoc(string maKichThuoc)
        {
            var kichThuoc = db.KichThuocs.Where(p => p.MaKichThuoc == maKichThuoc).FirstOrDefault();
            return kichThuoc;
        }
        //viết phương thức tìm kiếm theo tên kích thước
        public KichThuoc TimKiemTheoTenKichThuoc(string tenKichThuoc)
        {
            var kichThuoc = db.KichThuocs.Where(p => p.TenKichThuoc == tenKichThuoc).FirstOrDefault();
            return kichThuoc;
        }
        //viết phương thức thêm kích thước
        public bool ThemKichThuoc(KichThuoc kichThuoc)
        {
            try
            {
                db.KichThuocs.InsertOnSubmit(kichThuoc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //viết phương thức sửa kích thước
        public bool SuaKichThuoc(KichThuoc kichThuoc)
        {
            try
            {
                KichThuoc k = db.KichThuocs.Where(p => p.MaKichThuoc == kichThuoc.MaKichThuoc).FirstOrDefault();
                k.TenKichThuoc = kichThuoc.TenKichThuoc;
                k.MoTa = kichThuoc.MoTa;
                k.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //viết phương thức xóa kích thước
        public bool XoaKichThuoc(string maKichThuoc,bool trangThai)
        {
            try
            {
                KichThuoc k = db.KichThuocs.Where(p => p.MaKichThuoc == maKichThuoc).FirstOrDefault();
                k.TrangThaiHoatDong = trangThai;
                k.NgayCapNhat = DateTime.Now;
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
