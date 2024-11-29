using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL _khachHangDAL = null;
        public KhachHangBLL()
        {
            _khachHangDAL = new KhachHangDAL();
        }
        public bool ThemKhachHang(KhachHang kh)
        {
            return _khachHangDAL.ThemKhachHang(kh);
        }
        public List<KhachHang> TimKiemKhachHang(string key)
        {
            return _khachHangDAL.TimKiemKhachHang(key);
        }
        public List<KhachHang> LayTatCaKhachHang()
        {
            return _khachHangDAL.LayTatCaKhachHang();
        }
        public KhachHang LayKhachHangTheoDieuKien(string maKH, string tenKhachHang, string SDT)
        {
            return _khachHangDAL.LayKhachHangTheoDieuKien(maKH, tenKhachHang, SDT);
        }
        public bool AddDiemCongTichLuy(string maKhachHang, decimal diemCong)
        {
            return _khachHangDAL.AddDiemCongTichLuy(maKhachHang, diemCong);
        }
        public bool SuaThongTinKhachHang(KhachHang kh)
        {
            return _khachHangDAL.SuathongtinKhachHang(kh);
        }

        public KhachHang LayKhachHangTheoMa(string maKhachHang)
        {
            return _khachHangDAL.LayTatCaKhachHang().Where(x => x.MaKhachHang == maKhachHang).FirstOrDefault();
        }
    }
}
