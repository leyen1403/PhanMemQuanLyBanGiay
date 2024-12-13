using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class TraSanPhamChiTiet
{
    public string MaTraSanPham { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public string? MaHoaDon { get; set; }

    public int? SoLuong { get; set; }

    public string? TinhTrangSanPham { get; set; }

    public decimal? SoTienHoanLai { get; set; }

    public virtual ChiTietHoaDon? ChiTietHoaDon { get; set; }

    public virtual TraSanPham MaTraSanPhamNavigation { get; set; } = null!;
}
