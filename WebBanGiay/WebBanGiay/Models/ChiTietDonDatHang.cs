using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class ChiTietDonDatHang
{
    public string MaDonDatHang { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public int? SoLuongYeuCau { get; set; }

    public int? SoLuongCungCap { get; set; }

    public int? SoLuongThieu { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual DonDatHang MaDonDatHangNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
