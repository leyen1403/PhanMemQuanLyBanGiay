using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class HoaDon
{
    public string MaHoaDon { get; set; } = null!;

    public string? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public decimal? TongTien { get; set; }

    public int? DiemTichLuySuDung { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public DateOnly? NgayTao { get; set; }

    public string? GhiChu { get; set; }
    public string ? TrangThai { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<TraSanPham> TraSanPhams { get; set; } = new List<TraSanPham>();
}
