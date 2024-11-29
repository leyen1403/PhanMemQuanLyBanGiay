using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL sanPhamDAL = null;
        public SanPhamBLL()
        {
            sanPhamDAL = new SanPhamDAL();
        }
        public List<SanPham> timKiemSanPham(string maLoai, string maMau, string maKichThuoc, string maThuongHieu)
        {
            return sanPhamDAL.timKiemSanPham(maLoai, maMau, maKichThuoc, maThuongHieu);
        }
        public List<SanPham> layDanhSachSanPhamTheoMaKichThuoc(string maKichThuoc)
        {
            return sanPhamDAL.layDanhSachSanPhamTheoMaKichThuoc(maKichThuoc);
        }
        public List<SanPham> layDanhSachSanphamTheoMaMau(string maMau)
        {
            return sanPhamDAL.layDanhSachSanphamTheoMaMau(maMau);
        }
        public List<SanPham> layDanhSachSanPhamTheoMaThuongHieu(string maThuongHieu)
        {
            return sanPhamDAL.layDanhSachSanPhamTheoMaThuongHieu(maThuongHieu);
        }

        public List<SanPham> layDanhSachSanPhamTheoMaLoai(string maLoai)
        {
            return sanPhamDAL.layDanhSachSanPhamTheoMaLoai(maLoai);
        }

        public List<SanPham> layDanhSachSanPhamKhongTrungTen()
        {
            return sanPhamDAL.layDanhSachSanPhamKhongTrungTen();
        }

        public List<SanPham> laySanPhamTheoDieuKien(string dieuKien)
        {
            return sanPhamDAL.laySanPhamTheoDieuKien(dieuKien);
        }

        public List<SanPham> layDanhSachSanPham()
        {
            return sanPhamDAL.layTatCaSanPham();
        }

        public SanPham laySanPhamTheoMa(string maSanPham)
        {
            return sanPhamDAL.laySanPhamTheoMa(maSanPham);
        }
        public bool themSanPham(SanPham sp)
        {
            return sanPhamDAL.themSanPham(sp);
        }
        public bool suaSanPham(SanPham sp)
        {
            return sanPhamDAL.suaSanPham(sp);
        }
        public bool xoaSanPham(string maSanPham,bool trangThai)
        {
            return sanPhamDAL.xoaSanPham(maSanPham,trangThai);
        }

        public string timKiemMaSanPham(string tenSanPham,string maKichThuoc,string maSac,string maThuongHieu,string maLoaiSanPham)
        {
            return sanPhamDAL.TimKiemMaSanPham(tenSanPham,maKichThuoc,maSac,maThuongHieu,maLoaiSanPham);
        }
        public List<SanPham> timKiemSanPhamTheoTen(string tenSanPham)
        {
            return sanPhamDAL.timKiemSanPhamTheoTen(tenSanPham);
        }

        public bool xoaSanPham(string maSanPham)
        {
            return sanPhamDAL.xoaSanPham(maSanPham);
        }
        public List<SanPham> GetSanPhamsPaged(int pageNumber, int pageSize, string maLoai, string maThuongHieu,string tenSanPham, out int totalRecords)
        {
            return sanPhamDAL.GetSanPhamsPaged(pageNumber, pageSize, maLoai, maThuongHieu,tenSanPham, out totalRecords);
        }
        public string layMaSanPhamTheoTen(string tenSanPham, string tenThuongHieu, string tenMauSac, string tenKichThuoc)
        {
            return sanPhamDAL.layMaSanPhamTheoTen(tenSanPham, tenThuongHieu, tenMauSac, tenKichThuoc);
        }
        public SanPhamGioHangDTO laySanPhamTheoMaMoi(string maSanPham)
        {
            return sanPhamDAL.laySanPhamTheoMaMoi(maSanPham);
        }
        public decimal? layGiaBanTheoMaSanPham(string maSanPham)
        {
            return sanPhamDAL.layGiaBanTheoMaSanPham(maSanPham);
        }

        public SanPham LaySanPhamTheoMaSanPham(string maSanPham)
        {
            return sanPhamDAL.laySanPhamTheoMa(maSanPham);
        }
    }
}
