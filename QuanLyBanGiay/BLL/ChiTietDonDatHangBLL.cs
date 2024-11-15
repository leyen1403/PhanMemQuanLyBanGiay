using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietDonDatHangBLL
    {
        public ChiTietDonDatHangBLL() { }
        ChiTietDonDatHangDAL chiTietDonDatHangDAL = new ChiTietDonDatHangDAL();
        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHang()
        {
            return chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHang();
        }
        public bool ThemChiTietDonDatHang(ChiTietDonDatHang ctdh)
        {
            return chiTietDonDatHangDAL.ThemChiTietDonDatHang(ctdh);
        }
        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHangTheoMaDDH(string maDDH)
        {
            return chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDDH);
        }

        public decimal tinhTongTien(string maDonDatHang)
        {
            List<ChiTietDonDatHang> lstCTDDH = chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDonDatHang);
            decimal tongTien = 0;
            foreach (ChiTietDonDatHang ctddh in lstCTDDH)
            {
                tongTien += ctddh.ThanhTien ?? 0;
            }
            return tongTien;
        }

        public bool CapNhatChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            return chiTietDonDatHangDAL.CapNhatChiTietDonDatHang(ctddh);
        }

        public bool XoaChiTietDonDatHang(string maDonDatHang, string maSanPham)
        {
            return chiTietDonDatHangDAL.XoaChiTietDonDatHang(maDonDatHang, maSanPham);
        }
        public decimal TinhTongTienDaThanhToan(string maDonDatHang)
        {
            // số lượng yêu cầu * đơn giá = số tiền phải thanh toán
            // số tiền phải thanh toán - số tiền còn nợ = số tiền đã thanh toán
            List<ChiTietDonDatHang> lstCTDDH = chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDonDatHang);
            decimal soTienPhaiThanhToan = 0;
            foreach (ChiTietDonDatHang ctddh in lstCTDDH)
            {
                soTienPhaiThanhToan = (decimal)(soTienPhaiThanhToan + (ctddh.SoLuongYeuCau * ctddh.DonGia));
            }
            decimal soTienConNo = 0;
            foreach (ChiTietDonDatHang ctddh in lstCTDDH)
            {
                soTienConNo = (decimal)(soTienConNo + (ctddh.SoLuongThieu * ctddh.DonGia));
            }
            decimal soTienDaThanhToan = soTienPhaiThanhToan - soTienConNo;
            return soTienDaThanhToan;
        }
        public decimal TinhTienConNo(string maDonDatHang)
        {
            List<ChiTietDonDatHang> lstCTDDH = chiTietDonDatHangDAL.LayDanhSachChiTietDonDatHangTheoMaDDH(maDonDatHang);
            decimal soTienConNo = 0;
            foreach (ChiTietDonDatHang ctddh in lstCTDDH)
            {
                soTienConNo = (decimal)(soTienConNo + (ctddh.SoLuongThieu * ctddh.DonGia));
            }
            return soTienConNo;
        }
    }
}
