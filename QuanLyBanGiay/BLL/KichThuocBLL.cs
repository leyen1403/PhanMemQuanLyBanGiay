﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class KichThuocBLL
    {
        KichThuocDAL _kichThuocDAL = null;
        public KichThuocBLL() {
            _kichThuocDAL = new KichThuocDAL();
        }
        public List<KichThuoc> LayTatCaKichThuoc()
        {
            return _kichThuocDAL.LayTatCaKichThuoc();
        }
        public KichThuoc TimKiemTheoMaKichThuoc(string maKichThuoc)
        {
            return _kichThuocDAL.TimKiemTheoMaKichThuoc(maKichThuoc);
        }
        public KichThuoc TimKiemTheoTenKichThuoc(string tenKichThuoc)
        {
            return _kichThuocDAL.TimKiemTheoTenKichThuoc(tenKichThuoc);
        }
        public bool ThemKichThuoc(KichThuoc kichThuoc)
        {
            return _kichThuocDAL.ThemKichThuoc(kichThuoc);
        }
        public bool XoaKichThuoc(string maKichThuoc,bool trangThai)
        {
            return _kichThuocDAL.XoaKichThuoc(maKichThuoc,trangThai);
        }
        public bool SuaKichThuoc(KichThuoc kichThuoc)
        {
            return _kichThuocDAL.SuaKichThuoc(kichThuoc);
        }
        public List<KichThuoc> LayTatCaKichThuocTheoTenSanPham(string tenSanPham)
        {
            return _kichThuocDAL.LayTatCaKichThuocTheoTenSanPham(tenSanPham);
        }
        public List<KichThuoc> LayKichThuocTheoTenSanPhamVaMauSac(string tenSanPham, string tenMauSac)
        {
            return _kichThuocDAL.LayKichThuocTheoTenSanPhamVaMauSac(tenSanPham, tenMauSac);
        }
        public List<KichThuoc> LayKichThuocTheoThuongHieuLoaiSanPhamMauSac(string tenThuongHieu, string tenLoaiSanPham, string tenMauSac)
        {
            return _kichThuocDAL.LayKichThuocTheoThuongHieuLoaiSanPhamMauSac(tenThuongHieu, tenLoaiSanPham, tenMauSac);
        }
    }
}
