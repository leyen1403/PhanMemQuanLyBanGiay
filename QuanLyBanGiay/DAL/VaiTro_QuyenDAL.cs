using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class VaiTro_QuyenDAL
    {
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public VaiTro_QuyenDAL() { }
        public List<VaiTro_Quyen> LayDanhSachVaiTro_Quyen()
        {
            return db.VaiTro_Quyens.ToList();
        }
        public bool XoaQuyenRaKhoiVaiTro(string maVaiTro)
        {
            try
            {
                // Xoá toàn bộ quyền của vai trò có mã maVaiTro trong bảng VaiTro_Quyen
                var quyenCuaVaiTro = db.VaiTro_Quyens.Where(vt => vt.MaVaiTro == maVaiTro);
                if (quyenCuaVaiTro.Any())
                {
                    db.VaiTro_Quyens.DeleteAllOnSubmit(quyenCuaVaiTro);
                    db.SubmitChanges();
                    return true;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ThemQuyenVaoVaiTro(string maVaiTro, string maQuyen)
        {
            try
            {
                VaiTro_Quyen vaiTro_Quyen = new VaiTro_Quyen();
                vaiTro_Quyen.MaVaiTro = maVaiTro;
                vaiTro_Quyen.MaQuyen = maQuyen;
                db.VaiTro_Quyens.InsertOnSubmit(vaiTro_Quyen);
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
