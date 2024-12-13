using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanGiay.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietKiemKe> ChiTietKiemKes { get; set; }

    public virtual DbSet<DonDatHang> DonDatHangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KichThuoc> KichThuocs { get; set; }

    public virtual DbSet<KiemKe> KiemKes { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<MauSac> MauSacs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Quyen> Quyens { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }

    public virtual DbSet<TraSanPham> TraSanPhams { get; set; }

    public virtual DbSet<TraSanPhamChiTiet> TraSanPhamChiTiets { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=db_QuanLyBanGiay;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonDatHang>(entity =>
        {
            entity.HasKey(e => new { e.MaDonDatHang, e.MaSanPham }).HasName("PK__ChiTietD__D8654D93D923A05A");

            entity.ToTable("ChiTietDonDatHang");

            entity.Property(e => e.MaDonDatHang).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaDonDatHangNavigation).WithMany(p => p.ChiTietDonDatHangs)
                .HasForeignKey(d => d.MaDonDatHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__MaDon__6E01572D");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietDonDatHangs)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietDo__MaSan__6EF57B66");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaSanPham }).HasName("PK__ChiTietH__4CF2A579BC1AB8E2");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaHoa__6FE99F9F");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaSan__70DDC3D8");
        });

        modelBuilder.Entity<ChiTietKiemKe>(entity =>
        {
            entity.HasKey(e => new { e.MaKiemKe, e.MaSanPham }).HasName("PK__ChiTietK__19BDB75DCCDF2EE6");

            entity.ToTable("ChiTietKiemKe");

            entity.Property(e => e.MaKiemKe).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.LyDoChenhLech).HasMaxLength(255);

            entity.HasOne(d => d.MaKiemKeNavigation).WithMany(p => p.ChiTietKiemKes)
                .HasForeignKey(d => d.MaKiemKe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietKi__MaKie__71D1E811");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.ChiTietKiemKes)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietKi__MaSan__72C60C4A");
        });

        modelBuilder.Entity<DonDatHang>(entity =>
        {
            entity.HasKey(e => e.MaDonDatHang).HasName("PK__DonDatHa__17C939D1A56A7DBF");

            entity.ToTable("DonDatHang");

            entity.Property(e => e.MaDonDatHang).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.MaNhaCungCap).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 0)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaNhaCungCapNavigation).WithMany(p => p.DonDatHangs)
                .HasForeignKey(d => d.MaNhaCungCap)
                .HasConstraintName("FK__DonDatHan__MaNha__73BA3083");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.DonDatHangs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__DonDatHan__MaNha__74AE54BC");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDon__835ED13B11EB4E5F");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDon__MaKhachH__75A278F5");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDon__MaNhanVi__76969D2E");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5F115EE9C");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.DiemTichLuy)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 0)");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenKhachHang).HasMaxLength(255);
            entity.Property(e => e.ThanhVien).HasDefaultValue(false);
            entity.Property(e => e.TrangThaiHoatDong).HasDefaultValue(true);
        });

        modelBuilder.Entity<KichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__KichThuo__22BFD6645949A206");

            entity.ToTable("KichThuoc");

            entity.Property(e => e.MaKichThuoc).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TenKichThuoc).HasMaxLength(50);
            entity.Property(e => e.TrangThaiHoatDong).HasDefaultValue(true);
        });

        modelBuilder.Entity<KiemKe>(entity =>
        {
            entity.HasKey(e => e.MaKiemKe).HasName("PK__KiemKe__D611C31FC57EFE72");

            entity.ToTable("KiemKe");

            entity.Property(e => e.MaKiemKe).HasMaxLength(50);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.KiemKes)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__KiemKe__MaNhanVi__778AC167");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSanPham).HasName("PK__LoaiSanP__ECCF699F0A311BFF");

            entity.ToTable("LoaiSanPham");

            entity.Property(e => e.MaLoaiSanPham).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TenLoaiSanPham).HasMaxLength(255);
            entity.Property(e => e.TrangThaiHoatDong).HasDefaultValue(true);
        });

        modelBuilder.Entity<MauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac).HasName("PK__MauSac__B9A911623E341060");

            entity.ToTable("MauSac");

            entity.Property(e => e.MaMauSac).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TenMauSac).HasMaxLength(50);
            entity.Property(e => e.TrangThaiHoatDong).HasDefaultValue(true);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNhaCungCap).HasName("PK__NhaCungC__53DA9205C9C4AA47");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNhaCungCap).HasMaxLength(50);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NguoiDaiDien).HasMaxLength(255);
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenNhaCungCap).HasMaxLength(255);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA47C5391CE7");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.ChucVu).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.GioiTinh).HasMaxLength(3);
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TaiKhoan).HasMaxLength(255);
            entity.Property(e => e.TenNhanVien).HasMaxLength(255);
            entity.Property(e => e.TrangThaiHoatDong).HasDefaultValue(true);

            entity.HasMany(d => d.MaVaiTros).WithMany(p => p.MaNhanViens)
                .UsingEntity<Dictionary<string, object>>(
                    "NhanVienVaiTro",
                    r => r.HasOne<VaiTro>().WithMany()
                        .HasForeignKey("MaVaiTro")
                        .HasConstraintName("FK__NhanVien___MaVai__797309D9"),
                    l => l.HasOne<NhanVien>().WithMany()
                        .HasForeignKey("MaNhanVien")
                        .HasConstraintName("FK__NhanVien___MaNha__787EE5A0"),
                    j =>
                    {
                        j.HasKey("MaNhanVien", "MaVaiTro").HasName("PK__NhanVien__9B960E5BAB676F57");
                        j.ToTable("NhanVien_VaiTro");
                        j.IndexerProperty<string>("MaNhanVien").HasMaxLength(50);
                        j.IndexerProperty<string>("MaVaiTro").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<Quyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("PK__Quyen__1D4B7ED47CDBFB21");

            entity.ToTable("Quyen");

            entity.Property(e => e.MaQuyen).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenQuyen).HasMaxLength(50);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__SanPham__FAC7442DAB1ACA84");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.DonViTinh).HasMaxLength(255);
            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiaNhap).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaKichThuoc).HasMaxLength(50);
            entity.Property(e => e.MaLoaiSanPham).HasMaxLength(50);
            entity.Property(e => e.MaMauSac).HasMaxLength(50);
            entity.Property(e => e.MaThuongHieu).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SoLuong).HasDefaultValue(0);
            entity.Property(e => e.TenSanPham).HasMaxLength(255);
            entity.Property(e => e.TrangThaiHoatDong).HasDefaultValue(true);

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK__SanPham__MaKichT__7A672E12");

            entity.HasOne(d => d.MaLoaiSanPhamNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoaiSanPham)
                .HasConstraintName("FK__SanPham__MaLoaiS__7B5B524B");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK__SanPham__MaMauSa__7C4F7684");

            entity.HasOne(d => d.MaThuongHieuNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaThuongHieu)
                .HasConstraintName("FK__SanPham__MaThuon__7D439ABD");
        });

        modelBuilder.Entity<ThuongHieu>(entity =>
        {
            entity.HasKey(e => e.MaThuongHieu).HasName("PK__ThuongHi__A3733E2CF76E9531");

            entity.ToTable("ThuongHieu");

            entity.Property(e => e.MaThuongHieu).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TenThuongHieu).HasMaxLength(255);
            entity.Property(e => e.TrangThaiHoatDong).HasDefaultValue(true);
        });

        modelBuilder.Entity<TraSanPham>(entity =>
        {
            entity.HasKey(e => e.MaTraSanPham).HasName("PK__TraSanPh__E5766273D390C464");

            entity.ToTable("TraSanPham");

            entity.Property(e => e.MaTraSanPham).HasMaxLength(50);
            entity.Property(e => e.LyDoTra).HasMaxLength(500);
            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.MaKhachHang).HasMaxLength(50);
            entity.Property(e => e.MaNhanVien).HasMaxLength(50);
            entity.Property(e => e.TongTienHoanLai).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TraSanPhams)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK__TraSanPha__MaHoa__7E37BEF6");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.TraSanPhams)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__TraSanPha__MaKha__7F2BE32F");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.TraSanPhams)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__TraSanPha__MaNha__00200768");
        });

        modelBuilder.Entity<TraSanPhamChiTiet>(entity =>
        {
            entity.HasKey(e => new { e.MaTraSanPham, e.MaSanPham }).HasName("PK__TraSanPh__2ADA1631A25EC7B6");

            entity.ToTable("TraSanPhamChiTiet");

            entity.Property(e => e.MaTraSanPham).HasMaxLength(50);
            entity.Property(e => e.MaSanPham).HasMaxLength(50);
            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.SoTienHoanLai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TinhTrangSanPham).HasMaxLength(100);

            entity.HasOne(d => d.MaTraSanPhamNavigation).WithMany(p => p.TraSanPhamChiTiets)
                .HasForeignKey(d => d.MaTraSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TraSanPha__MaTra__01142BA1");

            entity.HasOne(d => d.ChiTietHoaDon).WithMany(p => p.TraSanPhamChiTiets)
                .HasForeignKey(d => new { d.MaHoaDon, d.MaSanPham })
                .HasConstraintName("FK__TraSanPhamChiTie__02084FDA");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.MaVaiTro).HasName("PK__VaiTro__C24C41CFB3636F07");

            entity.ToTable("VaiTro");

            entity.Property(e => e.MaVaiTro).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.TenVaiTro).HasMaxLength(50);

            entity.HasMany(d => d.MaQuyens).WithMany(p => p.MaVaiTros)
                .UsingEntity<Dictionary<string, object>>(
                    "VaiTroQuyen",
                    r => r.HasOne<Quyen>().WithMany()
                        .HasForeignKey("MaQuyen")
                        .HasConstraintName("FK__VaiTro_Qu__MaQuy__02FC7413"),
                    l => l.HasOne<VaiTro>().WithMany()
                        .HasForeignKey("MaVaiTro")
                        .HasConstraintName("FK__VaiTro_Qu__MaVai__03F0984C"),
                    j =>
                    {
                        j.HasKey("MaVaiTro", "MaQuyen").HasName("PK__VaiTro_Q__9398F62292E31449");
                        j.ToTable("VaiTro_Quyen");
                        j.IndexerProperty<string>("MaVaiTro").HasMaxLength(50);
                        j.IndexerProperty<string>("MaQuyen").HasMaxLength(50);
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
