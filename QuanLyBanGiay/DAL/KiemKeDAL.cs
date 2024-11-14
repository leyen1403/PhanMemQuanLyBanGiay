using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KiemKeDAL
    {
        public KiemKeDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public List<KiemKe> LayDanhSachKiemKe()
        {
            return db.KiemKes.ToList();
        }
        public bool ThemKiemKe(KiemKe kiemKe)
        {
            try
            {
                KiemKe kiemKe1 = db.KiemKes.Where(p => p.MaKiemKe == kiemKe.MaKiemKe).FirstOrDefault();
                if (kiemKe1 != null) { return false; }
                db.KiemKes.InsertOnSubmit(kiemKe);
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public bool CapNhatKiemKe(KiemKe kiemKe)
        {
            try
            {
                KiemKe kkNew = db.KiemKes.Where(x=>x.MaKiemKe == kiemKe.MaKiemKe).FirstOrDefault();
                if(kkNew == null)
                {
                    return false;
                }
                kkNew.NgayKiemKe = kiemKe.NgayKiemKe;
                kkNew.MaNhanVien = kiemKe.MaNhanVien;
                kkNew.GhiChu = kiemKe.GhiChu;
                db.SubmitChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
