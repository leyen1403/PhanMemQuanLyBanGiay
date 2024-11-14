using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        db_QuanLyBanGiayDataContext db = null;
        List<LoaiSanPham> lstLoaiSanPham = null;
        public LoaiSanPhamDAL()
        {
            db = new db_QuanLyBanGiayDataContext();
        }

        public List<LoaiSanPham> layLoaiSanPhamTheoDieuKien(string dieuKien)
        {
            try
            {
                lstLoaiSanPham = new List<LoaiSanPham>();
                lstLoaiSanPham = db.LoaiSanPhams.Where(lsp => lsp.TenLoaiSanPham.Contains(dieuKien) || lsp.MaLoaiSanPham.Contains(dieuKien)).ToList();
                return lstLoaiSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
         
        public LoaiSanPham layLoaiSanPhamTheoMa(string maLoaiSanPham)
        {
            try
            {
                LoaiSanPham loaiSanPham = new LoaiSanPham();
                loaiSanPham = db.LoaiSanPhams.Where(lsp => lsp.MaLoaiSanPham == maLoaiSanPham).FirstOrDefault();
                return loaiSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LoaiSanPham layLoaiSanPhamTheoTen(string tenLoaiSanPham)
        {
            try
            {
                LoaiSanPham loaiSanPham = new LoaiSanPham();
                loaiSanPham = db.LoaiSanPhams.Where(lsp => lsp.TenLoaiSanPham == tenLoaiSanPham).FirstOrDefault();
                return loaiSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<LoaiSanPham> layTatCaLoaiSanPham()
        {
            try
            {
                lstLoaiSanPham = new List<LoaiSanPham>();
                lstLoaiSanPham = db.LoaiSanPhams.ToList();
                return lstLoaiSanPham;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool suaLoaiSanPham(LoaiSanPham lsp)
        {
            try
            {
                var loaiSanPham = db.LoaiSanPhams.Where(l => l.MaLoaiSanPham == lsp.MaLoaiSanPham).SingleOrDefault();
                loaiSanPham.TenLoaiSanPham = lsp.TenLoaiSanPham;
                loaiSanPham.MoTa = lsp.MoTa;
                loaiSanPham.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool suaLoaiSanPham(string maLoaiSanPham,bool trangThai)
        {
            try
            {
                var loaiSanPham = db.LoaiSanPhams.Where(l => l.MaLoaiSanPham == maLoaiSanPham).SingleOrDefault();
                loaiSanPham.TrangThaiHoatDong = trangThai;
                loaiSanPham.NgayCapNhat = DateTime.Now;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool themLoaiSanPham(LoaiSanPham lsp)
        {
            try
            {
                db.LoaiSanPhams.InsertOnSubmit(lsp);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
