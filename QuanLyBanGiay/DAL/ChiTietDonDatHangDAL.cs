using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietDonDatHangDAL
    {
        public ChiTietDonDatHangDAL() { }
        db_QuanLyBanGiayDataContext db = new db_QuanLyBanGiayDataContext();
        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHang()
        {
            return db.ChiTietDonDatHangs.ToList();
        }
        public bool ThemChiTietDonDatHang(ChiTietDonDatHang ctdh)
        {
            try
            {
                db.ChiTietDonDatHangs.InsertOnSubmit(ctdh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHangTheoMaDDH(string maDDH)
        {
            return db.ChiTietDonDatHangs.Where(x => x.MaDonDatHang == maDDH).ToList();
        }
        public bool CapNhatChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            try
            {
                ChiTietDonDatHang ctddhNew = db.ChiTietDonDatHangs.Where(x=>x.MaDonDatHang == ctddh.MaDonDatHang && x.MaSanPham == ctddh.MaSanPham).FirstOrDefault();
                ctddhNew.MaSanPham = ctddh.MaSanPham;
                ctddhNew.SoLuongYeuCau = ctddh.SoLuongYeuCau;
                ctddhNew.SoLuongCungCap = ctddh.SoLuongCungCap;
                ctddhNew.SoLuongThieu = ctddh.SoLuongThieu;
                ctddhNew.DonGia = ctddh.DonGia;
                ctddhNew.ThanhTien = ctddh.ThanhTien;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaChiTietDonDatHang(string maDonDatHang, string maSanPham)
        {
            try
            {
                ChiTietDonDatHang ctddh = db.ChiTietDonDatHangs.Where(x => x.MaDonDatHang == maDonDatHang && x.MaSanPham == maSanPham).FirstOrDefault();
                if(ctddh == null) { return false; }
                db.ChiTietDonDatHangs.DeleteOnSubmit(ctddh);
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
