using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class VaiTro
{
    public string MaVaiTro { get; set; } = null!;

    public string TenVaiTro { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<NhanVien> MaNhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<Quyen> MaQuyens { get; set; } = new List<Quyen>();
}
