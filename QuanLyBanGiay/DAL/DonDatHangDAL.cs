using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DonDatHangDAL
    {
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public DonDatHangDAL()
        {

        }
        public List<DonDatHang> LayDanhSachDonDatHang()
        {
            return db.DonDatHangs.ToList();
        }
        public bool CapNhatDonDatHang(DonDatHang ddh)
        {
            DonDatHang ddhNew = db.DonDatHangs.Where(x => x.MaDonDatHang == ddh.MaDonDatHang).FirstOrDefault();
            if (ddhNew == null) { return false; }
            else
            {
                ddhNew.MaNhaCungCap = ddh.MaNhaCungCap;
                ddhNew.MaNhanVien = ddh.MaNhanVien;
                ddhNew.NgayDatHang = ddh.NgayDatHang;
                ddhNew.NgayDuKienGiao = ddh.NgayDuKienGiao;
                ddhNew.TrangThai = ddh.TrangThai;
                ddhNew.GhiChu = ddh.GhiChu;
                ddhNew.NgayTao = ddh.NgayTao;
                db.SubmitChanges();
                return true;
            }
        }

        public bool ThemDonDatHang(DonDatHang ddh)
        {
            try
            {
                DonDatHang ddh1 = LayDanhSachDonDatHang().Where(x=>x.MaDonDatHang == ddh.MaDonDatHang).FirstOrDefault();
                if(ddh1 != null) { return false; }
                db.DonDatHangs.InsertOnSubmit(ddh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
