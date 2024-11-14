using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NhaCungCapBLL
    {
        public NhaCungCapBLL() { }
        NhaCungCapDAL nhaCungCapDAL = new NhaCungCapDAL();
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            return nhaCungCapDAL.LayDanhSachNhaCungCap();
        }
        public NhaCungCap LayNhaCungCap(string maNhaCungCap)
        {
            return nhaCungCapDAL.LayNhaCungCap(maNhaCungCap);
        }
        public bool CapNhatNhaCungCap(NhaCungCap ncc)
        {
            return nhaCungCapDAL.CapNhatNhaCungCap(ncc);
        }
    }
}
