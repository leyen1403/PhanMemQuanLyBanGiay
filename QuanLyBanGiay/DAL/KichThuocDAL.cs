using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class KichThuocDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<KichThuoc> kichThuocs = new List<KichThuoc>();
        public KichThuocDAL() { db = new db_QuanLyBanGiayDataContext(); }

        //viết phương thức lấy tất cả kích thước
        public List<KichThuoc> LayTatCaKichThuoc()
        {
            kichThuocs = new List<KichThuoc>();
            kichThuocs = db.KichThuocs.ToList();
            return kichThuocs;
        }

        //viết phương thức tìm kiếm theo mã kích thước
        public KichThuoc TimKiemTheoMaKichThuoc(string maKichThuoc)
        {
            var kichThuoc = db.KichThuocs.Where(p => p.MaKichThuoc == maKichThuoc).FirstOrDefault();
            return kichThuoc;
        }

        //viết phương thức tìm kiếm theo tên kích thước
        public KichThuoc TimKiemTheoTenKichThuoc(string tenKichThuoc)
        {
            var kichThuoc = db.KichThuocs.Where(p => p.TenKichThuoc == tenKichThuoc).FirstOrDefault();
            return kichThuoc;
        }

        //viết phương thức thêm kích thước
        public bool ThemKichThuoc(KichThuoc kichThuoc)
        {
            try
            {
                db.KichThuocs.InsertOnSubmit(kichThuoc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //viết phương thức sửa kích thước
        public bool SuaKichThuoc(KichThuoc kichThuoc)
        {
            try
            {
                KichThuoc k = db.KichThuocs.Where(p => p.MaKichThuoc == kichThuoc.MaKichThuoc).FirstOrDefault();
                k.TenKichThuoc = kichThuoc.TenKichThuoc;
                k.MoTa = kichThuoc.MoTa;
                k.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //viết phương thức xóa kích thước
        public bool XoaKichThuoc(string maKichThuoc, bool trangThai)
        {
            try
            {
                KichThuoc k = db.KichThuocs.Where(p => p.MaKichThuoc == maKichThuoc).FirstOrDefault();
                k.TrangThaiHoatDong = trangThai;
                k.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //viết hàm lấy tất cả kích thước theo tên sản phẩm
        public List<KichThuoc> LayTatCaKichThuocTheoTenSanPham(string tenSanPham)
        {
            try
            {
                // Giả sử rằng bảng KichThuoc có mối quan hệ với SanPham thông qua bảng trung gian hoặc trực tiếp
                var kichThuocs = (from kt in db.KichThuocs
                                  join sp in db.SanPhams on kt.MaKichThuoc equals sp.MaKichThuoc
                                  where sp.TenSanPham == tenSanPham && sp.TrangThaiHoatDong == true // Điều kiện lọc sản phẩm có trạng thái hoạt động
                                  select kt).ToList();

                return kichThuocs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kích thước: " + ex.Message);
                return null;
            }
        }

        public List<KichThuoc> LayKichThuocTheoTenSanPhamVaMauSac(string tenSanPham, string tenMauSac)
        {
            try
            {
                var kichThuocs = (from sp in db.SanPhams
                                  join kt in db.KichThuocs on sp.MaKichThuoc equals kt.MaKichThuoc
                                  join ms in db.MauSacs on sp.MaMauSac equals ms.MaMauSac
                                  where sp.TenSanPham == tenSanPham && ms.TenMauSac == tenMauSac
                                  select kt).Distinct()
                    .ToList();

                return kichThuocs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kích thước: " + ex.Message);
                return null;
            }
        }

        public List<KichThuoc> LayKichThuocTheoThuongHieuLoaiSanPhamMauSac(
     string tenThuongHieu,
     string tenLoaiSanPham,
     string tenMauSac)
        {
            try
            {
                // Lấy danh sách kích thước dựa trên thương hiệu, loại sản phẩm và màu sắc
                var kichThuocs = (from sp in db.SanPhams
                                  join th in db.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu into thJoin
                                  from th in thJoin.DefaultIfEmpty()
                                  join lsp in db.LoaiSanPhams on sp.MaLoaiSanPham equals lsp.MaLoaiSanPham into lspJoin
                                  from lsp in lspJoin.DefaultIfEmpty()
                                  join ms in db.MauSacs on sp.MaMauSac equals ms.MaMauSac into msJoin
                                  from ms in msJoin.DefaultIfEmpty()
                                  join kt in db.KichThuocs on sp.MaKichThuoc equals kt.MaKichThuoc into ktJoin
                                  from kt in ktJoin.DefaultIfEmpty()
                                  where th.TenThuongHieu == tenThuongHieu &&
                                        lsp.TenLoaiSanPham == tenLoaiSanPham &&
                                        ms.TenMauSac == tenMauSac &&
                                        sp.TrangThaiHoatDong == true // Điều kiện lọc sản phẩm có trạng thái hoạt động
                                  select kt).ToList();

                return kichThuocs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách kích thước: " + ex.Message);
                return null;
            }
        }
    }
}
