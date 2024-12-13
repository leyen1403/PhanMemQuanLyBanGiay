using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class DonDatHang
{
    public string MaDonDatHang { get; set; } = null!;

    public string? MaNhaCungCap { get; set; }

    public string? MaNhanVien { get; set; }

    public DateOnly? NgayDatHang { get; set; }

    public DateOnly? NgayDuKienGiao { get; set; }

    public string? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public DateOnly? NgayTao { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; } = new List<ChiTietDonDatHang>();

    public virtual NhaCungCap? MaNhaCungCapNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
