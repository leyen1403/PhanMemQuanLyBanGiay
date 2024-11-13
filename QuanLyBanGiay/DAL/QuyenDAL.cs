using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class QuyenDAL
    {
        public QuyenDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public List<Quyen> LayDanhSachQuyen()
        {
            return db.Quyens.ToList();
        }
        public bool ThemQuyen(Quyen quyen)
        {
            try
            {
                db.Quyens.InsertOnSubmit(quyen);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhatQuyen(Quyen quyen)
        {
            try
            {
                Quyen quyenNew = db.Quyens.Where(q=>q.MaQuyen==quyen.MaQuyen).FirstOrDefault();
                if(quyenNew != null)
                {
                    quyenNew.TenQuyen = quyen.TenQuyen;
                    quyenNew.MoTa = quyen.MoTa;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
