using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SanPhamDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<SanPham> lstSanPham = null;
        public SanPhamDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //tìm kiếm sản phẩm theo nhiều điều kiện có thể mã loại, mã màu sắc , mã kích thước, mã thương hiệu
        public List<SanPham> timKiemSanPham(string maLoai, string maMau, string maKichThuoc, string maThuongHieu)
        {
            try
            {
                var query = db.SanPhams.AsQueryable();

                // Kiểm tra từng điều kiện, chỉ thêm vào truy vấn khi giá trị không null hoặc không rỗng
                if (!string.IsNullOrEmpty(maLoai))
                {
                    query = query.Where(sp => sp.MaLoaiSanPham == maLoai);
                }

                if (!string.IsNullOrEmpty(maMau))
                {
                    query = query.Where(sp => sp.MaMauSac == maMau);
                }

                if (!string.IsNullOrEmpty(maKichThuoc))
                {
                    query = query.Where(sp => sp.MaKichThuoc == maKichThuoc);
                }

                if (!string.IsNullOrEmpty(maThuongHieu))
                {
                    query = query.Where(sp => sp.MaThuongHieu == maThuongHieu);
                }

                // Thực hiện truy vấn và trả về kết quả
                return query.ToList();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần (ví dụ: ghi log, hiển thị thông báo lỗi...)
                return null;
            }
        }

        //lấy danh sách sản phảm theo mã kích thước
        public List<SanPham> layDanhSachSanPhamTheoMaKichThuoc(string maKichThuoc)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.MaKichThuoc == maKichThuoc).ToList();
                return lstSanPham;
            }
            catch
            {
                return null;
            }
        }
        //lấy danh sách sản phảm theo mã màu
        public List<SanPham> layDanhSachSanphamTheoMaMau(string maMau)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.MaMauSac == maMau).ToList();
                return lstSanPham;
            }
            catch
            {
                return null;
            }
        }
        //lấy danh sách sản phẩm theo mã thương hiệu
        public List<SanPham> layDanhSachSanPhamTheoMaThuongHieu(string maThuongHieu)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.MaThuongHieu == maThuongHieu).ToList();
                return lstSanPham;
            }
            catch
            {
                return null;
            }
        }
        //lấy danh sách sản phẩm theo maloai
        public List<SanPham> layDanhSachSanPhamTheoMaLoai(string maLoai)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.MaLoaiSanPham == maLoai).ToList();
                return lstSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<SanPham> layDanhSachSanPhamKhongTrungTen()
        {
            try
            {
                var layDanhSachSanPhamKhongTrungTen = new List<SanPham>();
                lstSanPham = db.SanPhams.ToList();
                foreach (SanPham sp in lstSanPham)
                {
                    if (layDanhSachSanPhamKhongTrungTen.Contains(sp) == false)
                    {
                        layDanhSachSanPhamKhongTrungTen.Add(sp);
                    }
                }
                return layDanhSachSanPhamKhongTrungTen;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SanPham> laySanPhamTheoDieuKien(string dieuKien)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.TenSanPham.Contains(dieuKien) || sp.MaSanPham.Contains(dieuKien)).ToList();
                return lstSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SanPham laySanPhamTheoMa(string maSanPham)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.MaSanPham == maSanPham).ToList();
                return lstSanPham[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<SanPham> layTatCaSanPham()
        {

            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.ToList();
                return lstSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool suaSanPham(SanPham sp)
        {
            try
            {
                var sanPham = db.SanPhams.Where(s => s.MaSanPham == sp.MaSanPham).SingleOrDefault();
                sanPham.TenSanPham = sp.TenSanPham;
                sanPham.MaLoaiSanPham = sp.MaLoaiSanPham;
                sanPham.MaThuongHieu = sp.MaThuongHieu;
                sanPham.MaMauSac = sp.MaMauSac;
                sanPham.MaKichThuoc = sp.MaKichThuoc;
                sanPham.DonViTinh = sp.DonViTinh;
                sanPham.SoLuongToiThieu = sp.SoLuongToiThieu;
                sanPham.GiaBan = sp.GiaBan;
                sanPham.GiaNhap = sp.GiaNhap;
                sanPham.SoLuong = sp.SoLuong;
                sanPham.MoTa = sp.MoTa;
                sanPham.HinhAnh = sp.HinhAnh;
                sanPham.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool themSanPham(SanPham sp)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool xoaSanPham(string maSanPham, bool trangThai)
        {
            try
            {
                var sanPham = db.SanPhams.Where(s => s.MaSanPham == maSanPham).SingleOrDefault();
                sanPham.TrangThaiHoatDong = trangThai;
                sanPham.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //tìm kiếm mã sản phẩm theo tên sản phẩm và mã kích thước và mã màu sắc
        public string TimKiemMaSanPham(string tenSanPham, string maKichThuoc, string maMauSac, string maThuongHieu, string maLoaiSanPham)
        {
            try
            {
                // Khai báo danh sách sản phẩm tìm được từ các điều kiện
                var lstSanPham = db.SanPhams
                                    .Where(sp => (string.IsNullOrEmpty(tenSanPham) || sp.TenSanPham.Contains(tenSanPham)) &&
                                                (string.IsNullOrEmpty(maKichThuoc) || sp.MaKichThuoc == maKichThuoc) &&
                                                (string.IsNullOrEmpty(maMauSac) || sp.MaMauSac == maMauSac) &&
                                                (string.IsNullOrEmpty(maThuongHieu) || sp.MaThuongHieu == maThuongHieu) &&
                                                (string.IsNullOrEmpty(maLoaiSanPham) || sp.MaLoaiSanPham == maLoaiSanPham))
                                    .ToList();

                // Kiểm tra nếu có sản phẩm tìm thấy
                if (lstSanPham.Count > 0)
                {
                    // Trả về mã sản phẩm của sản phẩm đầu tiên trong danh sách
                    return lstSanPham[0].MaSanPham;
                }
                else
                {
                    // Nếu không tìm thấy, trả về chuỗi trống
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                // Log error (ex.Message) ở đây nếu cần
                return "Lỗi xảy ra: " + ex.Message;  // hoặc có thể trả về string.Empty hoặc thông báo lỗi tùy vào yêu cầu
            }
        }

        //tìm kiếm theo tên sản phẩm
        public List<SanPham> timKiemSanPhamTheoTen(string tenSanPham)
        {
            try
            {
                lstSanPham = new List<SanPham>();
                lstSanPham = db.SanPhams.Where(sp => sp.TenSanPham.Contains(tenSanPham)).ToList();
                return lstSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // viết hàm xoá luôn
        public bool xoaSanPham(string maSanPham)
        {
            try
            {
                var sanPham = db.SanPhams.Where(s => s.MaSanPham == maSanPham).SingleOrDefault();
                db.SanPhams.DeleteOnSubmit(sanPham);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
