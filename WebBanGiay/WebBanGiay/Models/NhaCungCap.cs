using System;
using System.Collections.Generic;

namespace WebBanGiay.Models;

public partial class NhaCungCap
{
    public string MaNhaCungCap { get; set; } = null!;

    public string TenNhaCungCap { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? NguoiDaiDien { get; set; }

    public string? Email { get; set; }

    public string? SoDienThoai { get; set; }

    public bool TrangThaiHoatDong { get; set; }

    public DateOnly? NgayTao { get; set; }

    public DateOnly? NgayCapNhat { get; set; }

    public virtual ICollection<DonDatHang> DonDatHangs { get; set; } = new List<DonDatHang>();
}
