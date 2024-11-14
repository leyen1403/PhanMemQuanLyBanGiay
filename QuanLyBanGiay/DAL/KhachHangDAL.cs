using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHangDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<KhachHang> _lstKhachHang = null;
        public KhachHangDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //thêm 1 khách hàng mới
        public bool ThemKhachHang(KhachHang kh)
        {
            try
            {
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //tìm kiếm khách hàng theo mã khách hàng hoặc tên hoặc số điện thoại
        public List<KhachHang> TimKiemKhachHang(string key)
        {
            _lstKhachHang = new List<KhachHang>();
            _lstKhachHang = db.KhachHangs.Where(t => t.MaKhachHang.Contains(key) || t.TenKhachHang.Contains(key) || t.SoDienThoai.Contains(key)).ToList();
            return _lstKhachHang;
        }
        //lấy ra tất cả khách hàng
        public List<KhachHang> LayTatCaKhachHang()
        {
            try
            {
                _lstKhachHang = new List<KhachHang>();
                _lstKhachHang = db.KhachHangs.ToList();
                return _lstKhachHang;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
