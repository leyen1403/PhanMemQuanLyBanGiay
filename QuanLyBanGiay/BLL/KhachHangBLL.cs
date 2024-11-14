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
    }
}
