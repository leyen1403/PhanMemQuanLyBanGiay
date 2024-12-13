using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class KiemKe
{
    public string MaKiemKe { get; set; } = null!;

    public DateOnly? NgayKiemKe { get; set; }

    public string? MaNhanVien { get; set; }

    public string? GhiChu { get; set; }

    public bool? TrangThai { get; set; }

    public DateOnly? NgayTao { get; set; }

    public virtual ICollection<ChiTietKiemKe> ChiTietKiemKes { get; set; } = new List<ChiTietKiemKe>();

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
