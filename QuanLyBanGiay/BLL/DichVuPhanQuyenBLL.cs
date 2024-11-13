using System;
using System.Collections.Generic;
using DAL; // Sử dụng lớp DAL trong BLL
using DTO;
namespace BLL
{
    public class DichVuPhanQuyenBLL
    {
        private DichVuPhanQuyenDAL _phanQuyenDAL;

        public DichVuPhanQuyenBLL()
        {
            _phanQuyenDAL = new DichVuPhanQuyenDAL(); // Khởi tạo đối tượng DAL
        }

        // Phương thức kiểm tra quyền của nhân viên
        public bool KiemTraQuyen(string maNhanVien, string tenQuyen)
        {
            return _phanQuyenDAL.CoQuyen(maNhanVien, tenQuyen);
        }

        // Phương thức lấy danh sách quyền của nhân viên
        public List<string> LayDanhSachQuyen(string maNhanVien)
        {
            return _phanQuyenDAL.LayDanhSachQuyen(maNhanVien);
        }
    }
}
