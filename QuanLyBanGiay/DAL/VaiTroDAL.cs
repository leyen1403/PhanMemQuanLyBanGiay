using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class VaiTroDAL
    {
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public VaiTroDAL() { }
        public List<VaiTro> LayDanhSachVaiTro()
        {
            return db.VaiTros.ToList();
        }
        public VaiTro LayVaiTro(string maVaiTro)
        {
            return db.VaiTros.Where(vt => vt.MaVaiTro == maVaiTro).FirstOrDefault();
        }
        public bool ThemVaiTro(VaiTro vt)
        {
            try
            {
                db.VaiTros.InsertOnSubmit(vt);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhatVaiTro(VaiTro vaiTro)
        {
            try
            {
                VaiTro vt = db.VaiTros.Where(v => v.MaVaiTro == vaiTro.MaVaiTro).FirstOrDefault();
                if (vt != null)
                {
                    vt.TenVaiTro = vaiTro.TenVaiTro;
                    vt.MoTa = vaiTro.MoTa;
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
