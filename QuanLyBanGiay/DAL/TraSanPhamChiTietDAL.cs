using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class TraSanPhamChiTietDAL
    {
        public TraSanPhamChiTietDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public bool ThemTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            try
            {
                TraSanPhamChiTiet t = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                if (t != null)
                {
                    return false;
                }
                else
                {
                    db.TraSanPhamChiTiets.InsertOnSubmit(traSanPhamChiTiet);
                    // Trừ đi số lượng tồn kho của sản phẩm
                    SanPhamDAL sanPhamDAL = new SanPhamDAL();
                    SanPham sanPham = sanPhamDAL.laySanPhamTheoMa(traSanPhamChiTiet.MaSanPham);
                    sanPham.SoLuong -= traSanPhamChiTiet.SoLuong;
                    sanPham.NgayCapNhat = DateTime.Now;
                    // Cập nhật lại tổng tiền của hóa đơn
                    HoaDonDAL hoaDonDAL = new HoaDonDAL();
                    HoaDon hoaDon = hoaDonDAL.TimHoaDonTheoMaHoaDon(traSanPhamChiTiet.MaHoaDon).FirstOrDefault();
                    hoaDon.TongTien -= traSanPhamChiTiet.SoTienHoanLai;
                    if (hoaDonDAL.SuaHoaDon(hoaDon) == false)
                    {
                        return false;
                    }
                    // Cập nhật lại số lượng trong chi tiết hoá đơn
                    ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
                    ChiTietHoaDon chiTietHoaDon = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(traSanPhamChiTiet.MaHoaDon).Where(p => p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                    chiTietHoaDon.SoLuong -= traSanPhamChiTiet.SoLuong;
                    chiTietHoaDon.ThanhTien -= traSanPhamChiTiet.SoTienHoanLai;
                    if (chiTietHoaDonDAL.CapNhatChiTietHoaDon(chiTietHoaDon) == false)
                    {
                        return false;
                    }
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhatTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            try
            {
                TraSanPhamChiTiet traSanPhamChiTietUpdate = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                traSanPhamChiTietUpdate.MaHoaDon = traSanPhamChiTiet.MaHoaDon;
                traSanPhamChiTietUpdate.SoLuong = traSanPhamChiTiet.SoLuong;
                traSanPhamChiTietUpdate.TinhTrangSanPham = traSanPhamChiTiet.TinhTrangSanPham;
                traSanPhamChiTietUpdate.SoTienHoanLai = traSanPhamChiTiet.SoTienHoanLai;
                // Cập nhật số lượng sản phẩm trong kho
                SanPhamDAL sanPhamDAL = new SanPhamDAL();
                SanPham sanPham = sanPhamDAL.laySanPhamTheoMa(traSanPhamChiTiet.MaSanPham);
                sanPham.SoLuong += traSanPhamChiTietUpdate.SoLuong - traSanPhamChiTiet.SoLuong;
                sanPham.NgayCapNhat = DateTime.Now;
                if (sanPhamDAL.suaSanPham(sanPham) == false)
                {
                    return false;
                }
                // Cập nhật lại tổng tiền của hóa đơn
                HoaDonDAL hoaDonDAL = new HoaDonDAL();
                HoaDon hoaDon = hoaDonDAL.TimHoaDonTheoMaHoaDon(traSanPhamChiTiet.MaHoaDon).FirstOrDefault();
                hoaDon.TongTien += traSanPhamChiTietUpdate.SoTienHoanLai - traSanPhamChiTiet.SoTienHoanLai;
                if (hoaDonDAL.SuaHoaDon(hoaDon) == false)
                {
                    return false;
                }
                // Cập nhật lại số lượng trong chi tiết hoá đơn
                ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
                ChiTietHoaDon chiTietHoaDon = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(traSanPhamChiTiet.MaHoaDon).Where(p => p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                chiTietHoaDon.SoLuong += traSanPhamChiTietUpdate.SoLuong - traSanPhamChiTiet.SoLuong;
                chiTietHoaDon.ThanhTien += traSanPhamChiTietUpdate.SoTienHoanLai - traSanPhamChiTiet.SoTienHoanLai;
                if (chiTietHoaDonDAL.CapNhatChiTietHoaDon(chiTietHoaDon) == false)
                {
                    return false;
                }
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaTraSanPhamChiTiet(TraSanPhamChiTiet traSanPhamChiTiet)
        {
            try
            {
                TraSanPhamChiTiet traSanPhamChiTietDelete = db.TraSanPhamChiTiets.Where(p => p.MaTraSanPham == traSanPhamChiTiet.MaTraSanPham && p.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                // Cập nhật số lượng sản phẩm trong kho
                SanPhamDAL sanPhamDAL = new SanPhamDAL();
                SanPham sanPham = sanPhamDAL.laySanPhamTheoMa(traSanPhamChiTietDelete.MaSanPham);
                sanPham.SoLuong += traSanPhamChiTietDelete.SoLuong;
                sanPham.NgayCapNhat = DateTime.Now;
                if (sanPhamDAL.suaSanPham(sanPham) == false)
                {
                    return false;
                }
                // Cập nhật tổng tiền của hoá đơn
                HoaDonDAL hoaDonDAL = new HoaDonDAL();
                HoaDon hoaDon = hoaDonDAL.TimHoaDonTheoMaHoaDon(traSanPhamChiTiet.MaHoaDon).FirstOrDefault();
                hoaDon.TongTien += traSanPhamChiTiet.SoTienHoanLai;
                if (hoaDonDAL.SuaHoaDon(hoaDon) == false) { return false; }
                // Cập nhật số lượng và thành tiền của hoá đơn
                ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
                ChiTietHoaDon chiTietHoaDon = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(traSanPhamChiTietDelete.MaHoaDon).Where(x => x.MaSanPham == traSanPhamChiTiet.MaSanPham).FirstOrDefault();
                chiTietHoaDon.SoLuong += traSanPhamChiTietDelete.SoLuong;
                chiTietHoaDon.ThanhTien += traSanPhamChiTietDelete.SoTienHoanLai;
                if (chiTietHoaDonDAL.CapNhatChiTietHoaDon(chiTietHoaDon) == false)
                {
                    return false;
                }
                db.TraSanPhamChiTiets.DeleteOnSubmit(traSanPhamChiTietDelete);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<TraSanPhamChiTiet> LayTraSanPhamChiTiet()
        {
            return db.TraSanPhamChiTiets.ToList();
        }
        public List<TraSanPhamChiTiet> LayTraSanPhamChiTiet(string maTraSanPham)
        {
            return LayTraSanPhamChiTiet().Where(p => p.MaTraSanPham == maTraSanPham).ToList();
        }
    }
}
