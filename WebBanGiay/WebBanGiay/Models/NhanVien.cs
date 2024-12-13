using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string TenNhanVien { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string GioiTinh { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? ChucVu { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public string? HinhAnh { get; set; }

    public bool? TrangThaiHoatDong { get; set; }

    public DateOnly? NgayTao { get; set; }

    public DateOnly? NgayCapNhat { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<DonDatHang> DonDatHangs { get; set; } = new List<DonDatHang>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<KiemKe> KiemKes { get; set; } = new List<KiemKe>();

    public virtual ICollection<TraSanPham> TraSanPhams { get; set; } = new List<TraSanPham>();

    public virtual ICollection<VaiTro> MaVaiTros { get; set; } = new List<VaiTro>();
}
