using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL _hoaDonDAL = null;
        public HoaDonBLL()
        {
            _hoaDonDAL = new HoaDonDAL();
        }
        public bool ThemHoaDon(HoaDon hd)
        {
            return _hoaDonDAL.ThemHoaDon(hd);
        }
        public List<HoaDon> LayTatCaHoaDon()
        {
            return _hoaDonDAL.LayTatCaHoaDon();
        }
    }
}
