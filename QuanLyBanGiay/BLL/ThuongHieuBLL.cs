using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ThuongHieuBLL
    {
        ThuongHieuDAL _thuongHieuDAL = null;
        public ThuongHieuBLL()
        {
            _thuongHieuDAL = new ThuongHieuDAL();
        }
        public List<ThuongHieu> LayTatCaThuongHieu()
        {
            return _thuongHieuDAL.LayTatCaThuongHieu();
        }
        public ThuongHieu TimKiemTheoMaThuongHieu(string maThuongHieu)
        {
            return _thuongHieuDAL.TimKiemTheoMaThuongHieu(maThuongHieu);
        }
        public ThuongHieu TimKiemTheoTenThuongHieu(string tenThuongHieu)
        {
            return _thuongHieuDAL.TimKiemTheoTenThuongHieu(tenThuongHieu);
        }
        public List<ThuongHieu> TimTheoDieuKien(string dieuKien)
        {
            return _thuongHieuDAL.TimTheoDieuKien(dieuKien);
        }

        public bool ThemThuongHieu(ThuongHieu thuongHieu)
        {
            return _thuongHieuDAL.ThemThuongHieu(thuongHieu);
        }
        public bool XoaThuongHieu(string maThuongHieu, bool trangThai)
        {
            return _thuongHieuDAL.XoaThuongHieu(maThuongHieu, trangThai);
        }
        public bool SuaThuongHieu(ThuongHieu thuongHieu)
        {
            return _thuongHieuDAL.SuaThuongHieu(thuongHieu);
        }
        public ThuongHieu layThuongHieuTheoTenSanPham(string tenSanPham)
        {
            return _thuongHieuDAL.layThuongHieuTheoTenSanPham(tenSanPham);
        }
    }
}
