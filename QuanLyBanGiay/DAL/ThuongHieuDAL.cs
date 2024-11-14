using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ThuongHieuDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<ThuongHieu> thuongHieus = null;
        public ThuongHieuDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //viết phương thức lấy tất cả thương hiệu
        public List<ThuongHieu> LayTatCaThuongHieu()
        {
            thuongHieus = new List<ThuongHieu>();
            thuongHieus = db.ThuongHieus.ToList();
            return thuongHieus;
        }
        //viết phương thức tìm kiếm theo mã thương hiệu
        public ThuongHieu TimKiemTheoMaThuongHieu(string maThuongHieu)
        {
            thuongHieus = new List<ThuongHieu>();
            var thuongHieu = db.ThuongHieus.Where(p => p.MaThuongHieu == maThuongHieu).FirstOrDefault();
            return thuongHieu;
        }
        //viết phương thức tìm kiếm theo tên thương hiệu
        public ThuongHieu TimKiemTheoTenThuongHieu(string tenThuongHieu)
        {
            var thuongHieu = db.ThuongHieus.Where(p => p.TenThuongHieu == tenThuongHieu).FirstOrDefault();
            return thuongHieu;
        }
        //viết phương thức tìm kiếm theo nhiều điều kiện
        public List<ThuongHieu> TimTheoDieuKien(string dieuKien)
        {
            thuongHieus = new List<ThuongHieu>();
            thuongHieus = db.ThuongHieus.Where(p => p.TenThuongHieu.Contains(dieuKien) || p.MaThuongHieu.Contains(dieuKien)).ToList();
            return thuongHieus;
        }
            //viết phương thức thêm thương hiệu
            public bool ThemThuongHieu(ThuongHieu thuongHieu)
        {
            try
            {
                db.ThuongHieus.InsertOnSubmit(thuongHieu);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //viết phương thức sửa thương hiệu
        public bool SuaThuongHieu(ThuongHieu thuongHieu)
        {
            try
            {
                var th = db.ThuongHieus.Where(p => p.MaThuongHieu == thuongHieu.MaThuongHieu).FirstOrDefault();
                th.TenThuongHieu = thuongHieu.TenThuongHieu;
                th.MoTa = thuongHieu.MoTa;
                th.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //viết phương thức xóa thương hiệu
        public bool XoaThuongHieu(string maThuongHieu,bool trangThai)
        {
            try
            {
                var th = db.ThuongHieus.Where(p => p.MaThuongHieu == maThuongHieu).FirstOrDefault();
                th.TrangThaiHoatDong = trangThai;
                th.NgayCapNhat = DateTime.Now;
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
