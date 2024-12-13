using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class ChiTietKiemKe
{
    public string MaKiemKe { get; set; } = null!;

    public string MaSanPham { get; set; } = null!;

    public int? SoLuongThucTe { get; set; }

    public int? SoLuongHeThong { get; set; }

    public int? ChenhLech { get; set; }

    public string? LyDoChenhLech { get; set; }

    public virtual KiemKe MaKiemKeNavigation { get; set; } = null!;

    public virtual SanPham MaSanPhamNavigation { get; set; } = null!;
}
