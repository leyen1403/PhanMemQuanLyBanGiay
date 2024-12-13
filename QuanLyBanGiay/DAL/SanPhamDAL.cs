using System;
using System.Collections.Generic;
using System.Data;
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
        public SanPhamGioHangDTO laySanPhamTheoMaMoi(string maSanPham)
        {
            try
            {
                // Tìm sản phẩm cùng với tên màu sắc và kích thước trong cơ sở dữ liệu
                var sanPham = (from sp in db.SanPhams
                               join ms in db.MauSacs on sp.MaMauSac equals ms.MaMauSac
                               join kt in db.KichThuocs on sp.MaKichThuoc equals kt.MaKichThuoc
                               where sp.MaSanPham == maSanPham
                               select new SanPhamGioHangDTO
                               {
                                   MaSanPham = sp.MaSanPham,
                                   TenSanPham = sp.TenSanPham,
                                   MauSac = ms.TenMauSac,
                                   KichThuoc = kt.TenKichThuoc,
                                   GiaBan = (decimal)sp.GiaBan
                               }).FirstOrDefault();

                return sanPham; // Trả về đối tượng SanPhamGioHangDTO chứa thông tin sản phẩm, màu sắc và kích thước
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy sản phẩm: " + ex.Message);
                return null; // Trả về null nếu có lỗi
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
                sanPham.MoTa = sp.MoTa;
                sanPham.HinhAnh = sp.HinhAnh;
                sanPham.NgayCapNhat = DateTime.Now;
                sanPham.TrangThaiHoatDong = sp.TrangThaiHoatDong;
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
        public List<SanPham> GetSanPhamsPaged(int pageNumber, int pageSize, string maLoai, string maThuongHieu, string tenSanPham, out int totalRecords)
        {
            // Lọc sản phẩm theo mã loại và mã thương hiệu nếu có giá trị
            var query = db.SanPhams.AsQueryable();

            // Kiểm tra xem sản phẩm có bị xóa không
            query = query.Where(sp => sp.TrangThaiHoatDong == true); // Lọc chỉ lấy sản phẩm chưa bị xóa

            // Lọc theo mã loại sản phẩm nếu có
            if (!string.IsNullOrEmpty(maLoai))
            {
                query = query.Where(sp => sp.MaLoaiSanPham == maLoai);
            }

            // Lọc theo mã thương hiệu nếu có
            if (!string.IsNullOrEmpty(maThuongHieu))
            {
                query = query.Where(sp => sp.MaThuongHieu == maThuongHieu);
            }

            // Lọc theo tên sản phẩm nếu có
            if (!string.IsNullOrEmpty(tenSanPham))
            {
                query = query.Where(sp => sp.TenSanPham.Contains(tenSanPham)); // Sử dụng Contains để tìm kiếm tên sản phẩm (tìm kiếm theo chuỗi con)
            }

            // Loại bỏ sản phẩm trùng tên bằng cách nhóm theo tên sản phẩm
            var distinctSanPhams = query
                                    .GroupBy(sp => sp.TenSanPham)
                                    .Select(g => g.FirstOrDefault()) // Lấy sản phẩm đầu tiên trong mỗi nhóm
                                    .OrderBy(sp => sp.MaSanPham); // Sắp xếp theo mã sản phẩm để đảm bảo thứ tự

            // Tính tổng số sản phẩm sau khi lọc và loại bỏ trùng lặp
            totalRecords = distinctSanPhams.Count();

            // Phân trang cho danh sách sản phẩm đã lọc
            var pagedSanPhams = distinctSanPhams
                                .Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            return pagedSanPhams;
        }


        //viết hàm lấy mã sản phẩm theo tên sản phẩm ,tên thương hiệu, tên màu sắc, tên kích thước
        public string layMaSanPhamTheoTen(string tenSanPham, string tenThuongHieu, string tenMauSac, string tenKichThuoc)
        {
            try
            {
                // Lấy mã sản phẩm theo tên sản phẩm, tên thương hiệu, tên màu sắc, tên kích thước
                var maSanPham = db.SanPhams
                                .Where(sp => sp.TenSanPham == tenSanPham &&
                                             sp.ThuongHieu.TenThuongHieu == tenThuongHieu &&
                                             sp.MauSac.TenMauSac == tenMauSac &&
                                             sp.KichThuoc.TenKichThuoc == tenKichThuoc)
                                .Select(sp => sp.MaSanPham)
                                .FirstOrDefault();

                return maSanPham;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        //viết hàm lấy giá bán theo mã sản phẩm
        public decimal? layGiaBanTheoMaSanPham(string maSanPham)
        {
            try
            {
                // Tìm sản phẩm theo mã sản phẩm
                var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSanPham);

                if (sanPham != null)
                {
                    return sanPham.GiaBan; // Trả về giá bán nếu tìm thấy sản phẩm
                }
                else
                {
                    return null; // Trả về null nếu không tìm thấy sản phẩm
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy giá bán: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }
        }

        // Nam viết thêm
        public DataTable GetSanPhamBanChayDataTable()
        {
            // Tạo DataTable để lưu trữ kết quả
            DataTable dtSanPhamBanChay = new DataTable();

            // Truy vấn LINQ lấy sản phẩm bán chạy
            var query = from hd in db.HoaDons
                        join ct in db.ChiTietHoaDons on hd.MaHoaDon equals ct.MaHoaDon
                        join sp in db.SanPhams on ct.MaSanPham equals sp.MaSanPham
                        group new { ct.SoLuong, sp.MaSanPham, sp.TenSanPham } by new { sp.MaSanPham, sp.TenSanPham } into g
                        select new
                        {
                            g.Key.MaSanPham,
                            g.Key.TenSanPham,
                            TongSoLuongBan = g.Sum(x => x.SoLuong ?? 0) // Kiểm tra null cho SoLuong
                        };

            // Định nghĩa cột cho DataTable
            dtSanPhamBanChay.Columns.Add("MaSanPham", typeof(string));
            dtSanPhamBanChay.Columns.Add("TenSanPham", typeof(string));
            dtSanPhamBanChay.Columns.Add("TongSoLuongBan", typeof(int));

            // Thêm dữ liệu từ query vào DataTable
            foreach (var item in query.OrderByDescending(x => x.TongSoLuongBan))
            {
                DataRow row = dtSanPhamBanChay.NewRow();
                row["MaSanPham"] = item.MaSanPham;
                row["TenSanPham"] = item.TenSanPham;
                row["TongSoLuongBan"] = item.TongSoLuongBan;
                dtSanPhamBanChay.Rows.Add(row);
            }

            return dtSanPhamBanChay;
        }


        public DataTable GetSanPhamTonKho()
        {
            // Tạo DataTable để lưu trữ kết quả
            DataTable dtSanPhamTonKho = new DataTable();

            // Truy vấn LINQ lấy sản phẩm còn tồn kho và kiểm tra số lượng tồn so với số lượng tối thiểu
            var query = from sp in db.SanPhams
                        where sp.SoLuong > 0 // Chỉ lấy sản phẩm có số lượng tồn > 0
                        select new
                        {
                            sp.MaSanPham,
                            sp.TenSanPham,
                            sp.SoLuong,
                            sp.SoLuongToiThieu
                        };

            // Điền dữ liệu vào DataTable
            dtSanPhamTonKho.Columns.Add("MaSanPham");
            dtSanPhamTonKho.Columns.Add("TenSanPham");
            dtSanPhamTonKho.Columns.Add("SoLuongTon", typeof(int));
            dtSanPhamTonKho.Columns.Add("SoLuongToiThieu", typeof(int));
            dtSanPhamTonKho.Columns.Add("CanNhapThem", typeof(bool)); // Cột kiểm tra cần nhập thêm

            foreach (var item in query)
            {
                DataRow row = dtSanPhamTonKho.NewRow();
                row["MaSanPham"] = item.MaSanPham;
                row["TenSanPham"] = item.TenSanPham;
                row["SoLuongTon"] = item.SoLuong;
                row["SoLuongToiThieu"] = item.SoLuongToiThieu;
                row["CanNhapThem"] = item.SoLuong <= item.SoLuongToiThieu; // Kiểm tra nếu cần nhập thêm

                dtSanPhamTonKho.Rows.Add(row);
            }

            return dtSanPhamTonKho; // Trả về DataTable chứa danh sách sản phẩm còn tồn kho
        }

    }
}
