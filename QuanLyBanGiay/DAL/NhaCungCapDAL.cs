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
    }
}
