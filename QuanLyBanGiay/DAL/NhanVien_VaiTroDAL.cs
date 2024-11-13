using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVien_VaiTroDAL
    {
        public NhanVien_VaiTroDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public bool XoaNhanVienKhoiVaiTro(string maNhanVien)
        {
            try
            {
                // Lấy danh sách tất cả các vai trò của nhân viên có mã maNhanVien
                var vaiTroCuaNhanVien = db.NhanVien_VaiTros.Where(nv => nv.MaNhanVien == maNhanVien);

                // Nếu có vai trò, tiến hành xóa
                if (vaiTroCuaNhanVien.Any())
                {
                    db.NhanVien_VaiTros.DeleteAllOnSubmit(vaiTroCuaNhanVien);
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
        public bool ThemNhanVienVaoVaiTro(string maNhanVien, string maVaiTro)
        {
            try
            {
                NhanVien_VaiTro nhanVien_VaiTro = new NhanVien_VaiTro();
                nhanVien_VaiTro.MaNhanVien = maNhanVien;
                nhanVien_VaiTro.MaVaiTro = maVaiTro;
                db.NhanVien_VaiTros.InsertOnSubmit(nhanVien_VaiTro);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<NhanVien_VaiTro> LayDanhSachNhanVien_VaiTro()
        {
            return db.NhanVien_VaiTros.ToList();
        }
    }
}
