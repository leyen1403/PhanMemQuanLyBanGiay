using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class TraSanPham
{
    public string MaTraSanPham { get; set; } = null!;

    public string? MaHoaDon { get; set; }

    public string? MaKhachHang { get; set; }

    public string? MaNhanVien { get; set; }

    public string? LyDoTra { get; set; }

    public DateOnly? NgayTra { get; set; }

    public decimal? TongTienHoanLai { get; set; }

    public virtual HoaDon? MaHoaDonNavigation { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<TraSanPhamChiTiet> TraSanPhamChiTiets { get; set; } = new List<TraSanPhamChiTiet>();
}
