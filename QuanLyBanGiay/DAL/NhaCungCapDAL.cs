using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCapDAL
    {
        public NhaCungCapDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            return db.NhaCungCaps.ToList();
        }
        public NhaCungCap LayNhaCungCap(string maNhaCungCap)
        {
            return db.NhaCungCaps.Where(x => x.MaNhaCungCap == maNhaCungCap).FirstOrDefault();
        }
        public bool CapNhatNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                NhaCungCap nccNew = db.NhaCungCaps.Where(x => x.MaNhaCungCap == ncc.MaNhaCungCap).FirstOrDefault();
                if (nccNew == null) { return false; }
                else
                {
                    nccNew.TenNhaCungCap = ncc.TenNhaCungCap;
                    nccNew.DiaChi = ncc.DiaChi;
                    nccNew.NguoiDaiDien = ncc.NguoiDaiDien;
                    nccNew.SoDienThoai = ncc.SoDienThoai;
                    nccNew.Email = ncc.Email;
                    nccNew.TrangThaiHoatDong = ncc.TrangThaiHoatDong;
                    nccNew.NgayCapNhat = DateTime.Now;
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool ThemNhaCungCap(NhaCungCap ncc)
        {
            try
            {
                db.NhaCungCaps.InsertOnSubmit(ncc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // viết hàm kiểm tra tên nhà cung cấp đã tồn tại chưa
        public bool KiemTraTenNhaCungCap(string tenNhaCungCap)
        {
            NhaCungCap ncc = db.NhaCungCaps.Where(x => x.TenNhaCungCap == tenNhaCungCap).FirstOrDefault();
            if (ncc == null) { return false; }
            return true;
        }
    }
}
