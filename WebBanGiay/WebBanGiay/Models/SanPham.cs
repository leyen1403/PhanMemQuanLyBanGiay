using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class SanPham
{
    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string? MaLoaiSanPham { get; set; }

    public string? MaThuongHieu { get; set; }

    public string? MaMauSac { get; set; }

    public string? MaKichThuoc { get; set; }

    public decimal? GiaNhap { get; set; }

    public decimal? GiaBan { get; set; }

    public string? DonViTinh { get; set; }

    public int? SoLuong { get; set; }

    public int? SoLuongToiThieu { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public bool? TrangThaiHoatDong { get; set; }

    public DateOnly? NgayTao { get; set; }

    public DateOnly? NgayCapNhat { get; set; }

    public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; } = new List<ChiTietDonDatHang>();

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ICollection<ChiTietKiemKe> ChiTietKiemKes { get; set; } = new List<ChiTietKiemKe>();

    public virtual KichThuoc? MaKichThuocNavigation { get; set; }

    public virtual LoaiSanPham? MaLoaiSanPhamNavigation { get; set; }

    public virtual MauSac? MaMauSacNavigation { get; set; }

    public virtual ThuongHieu? MaThuongHieuNavigation { get; set; }
}
