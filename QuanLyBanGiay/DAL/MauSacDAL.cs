using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class MauSacDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<MauSac> mauSacs = null;
        public MauSacDAL() {
            db = new db_QuanLyBanGiayDataContext();
        }
        //viết phương thức lấy tất cả màu sắc
        public List<MauSac> layTatCaMauSac()
        {
            try
            {
                mauSacs = new List<MauSac>();
                mauSacs = db.MauSacs.ToList();
                return mauSacs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //viết phương thức tìm kiếm màu sắc theo mã
        public MauSac layMauSacTheoMa(string maMauSac)
        {
            try
            {
                MauSac mauSac = new MauSac();
                mauSac = db.MauSacs.Where(ms => ms.MaMauSac == maMauSac).FirstOrDefault();
                return mauSac;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //viết phương thức tìm kiếm màu sắc theo tên
        public MauSac layMauSacTheoTen(string tenMauSac)
        {
            try
            {
                MauSac mauSac = new MauSac();
                mauSac = db.MauSacs.Where(ms => ms.TenMauSac == tenMauSac).FirstOrDefault();
                return mauSac;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //viết phương thức thêm màu sắc
        public bool themMauSac(MauSac mauSac)
        {
            try
            {
                db.MauSacs.InsertOnSubmit(mauSac);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //viết phương thức xoá màu sắc
        public bool xoaMauSac(string maMauSac,bool trangThai)
        {
            try
            {
                MauSac mauSac = db.MauSacs.Where(ms => ms.MaMauSac == maMauSac).FirstOrDefault();
                mauSac.TrangThaiHoatDong = trangThai;
                mauSac.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //viết phương thứ sửa màu sắc
        public bool suaMauSac(MauSac mauSac)
        {
            try
            {
                MauSac mauSacSua = db.MauSacs.Where(ms => ms.MaMauSac == mauSac.MaMauSac).FirstOrDefault();
                mauSacSua.TenMauSac = mauSac.TenMauSac;
                mauSacSua.MoTa = mauSac.MoTa;
                mauSacSua.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //viết hàm lấy tất cả màu sắc theo tên sản phẩm
        public List<MauSac> layTatCaMauSacTheoTenSanPham(string tenSanPham)
        {
            try
            {
                var mauSacs = (from sp in db.SanPhams 
                               join ms in db.MauSacs on sp.MaMauSac equals ms.MaMauSac
                               where sp.TenSanPham == tenSanPham && sp.TrangThaiHoatDong == true
                               select ms).ToList();

                return mauSacs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách màu sắc: " + ex.Message);
                return null;
            }
        }
    }
}
