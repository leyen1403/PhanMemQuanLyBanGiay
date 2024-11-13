using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DichVuPhanQuyenDAL
    {
        private readonly db_QuanLyBanGiayDataContext _context;

        public DichVuPhanQuyenDAL()
        {
            _context = new db_QuanLyBanGiayDataContext();
        }

        // Hàm kiểm tra xem nhân viên có quyền truy cập một quyền cụ thể không
        public bool CoQuyen(string maNhanVien, string tenQuyen)
        {
            var query = from nv in _context.NhanViens
                        join nvvaitro in _context.NhanVien_VaiTros on nv.MaNhanVien equals nvvaitro.MaNhanVien
                        join vaitro in _context.VaiTros on nvvaitro.MaVaiTro equals vaitro.MaVaiTro
                        join vaitroquyen in _context.VaiTro_Quyens on vaitro.MaVaiTro equals vaitroquyen.MaVaiTro
                        join quyen in _context.Quyens on vaitroquyen.MaQuyen equals quyen.MaQuyen
                        where nv.MaNhanVien == maNhanVien && quyen.TenQuyen == tenQuyen
                        select quyen;

            return query.Any();
        }

        // Hàm lấy danh sách quyền của nhân viên
        public List<string> LayDanhSachQuyen(string maNhanVien)
        {
            // Lấy danh sách quyền của nhân viên thông qua các vai trò của họ
            var query = from nv in _context.NhanViens
                        join nvvaitro in _context.NhanVien_VaiTros on nv.MaNhanVien equals nvvaitro.MaNhanVien
                        join vaitro in _context.VaiTros on nvvaitro.MaVaiTro equals vaitro.MaVaiTro
                        join vaitroquyen in _context.VaiTro_Quyens on vaitro.MaVaiTro equals vaitroquyen.MaVaiTro
                        join quyen in _context.Quyens on vaitroquyen.MaQuyen equals quyen.MaQuyen
                        where nv.MaNhanVien == maNhanVien
                        select quyen.TenQuyen;

            return query.Distinct().ToList(); // Distinct() để loại bỏ quyền trùng lặp
        }

    }
}

