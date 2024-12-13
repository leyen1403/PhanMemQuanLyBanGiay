using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class MauSac
{
    public string MaMauSac { get; set; } = null!;

    public string TenMauSac { get; set; } = null!;

    public string? MoTa { get; set; }

    public bool? TrangThaiHoatDong { get; set; }

    public DateOnly? NgayTao { get; set; }

    public DateOnly? NgayCapNhat { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
