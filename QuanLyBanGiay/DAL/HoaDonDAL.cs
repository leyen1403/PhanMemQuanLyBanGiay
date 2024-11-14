using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class HoaDonDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<HoaDon> listHoaDon = new List<HoaDon>();
        public HoaDonDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }
        //viết phương thức thêm vào hoá đơn
        public bool ThemHoaDon(HoaDon hd)
        {
            try
            {
                db.HoaDons.InsertOnSubmit(hd);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //viết phương thức lấy ra tất cả hoá đơn
        public List<HoaDon> LayTatCaHoaDon()
        {
            try
            {
                listHoaDon = db.HoaDons.ToList();
                return listHoaDon;
            }
            catch
            {
                return null;
            }
        }

    }
}
