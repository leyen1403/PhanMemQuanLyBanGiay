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
    }
}
