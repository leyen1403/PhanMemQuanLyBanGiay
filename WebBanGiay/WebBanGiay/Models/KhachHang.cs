using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class KhachHang
{
    public string MaKhachHang { get; set; } = null!;

    public string TenKhachHang { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string GioiTinh { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public decimal? DiemTichLuy { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public string? HinhAnh { get; set; }

    public bool? TrangThaiHoatDong { get; set; }

    public DateOnly? NgayTao { get; set; }

    public DateOnly? NgayCapNhat { get; set; }

    public bool? ThanhVien { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<TraSanPham> TraSanPhams { get; set; } = new List<TraSanPham>();
}
