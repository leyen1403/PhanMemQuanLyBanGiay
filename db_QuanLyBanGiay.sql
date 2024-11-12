use master
go
create database db_QuanLyBanGiay
go
use db_QuanLyBanGiay;
go
CREATE TABLE NhaCungCap (
    MaNhaCungCap NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenNhaCungCap NVARCHAR(255) NOT NULL,
    DiaChi NVARCHAR(255),
    NguoiDaiDien NVARCHAR(255),
    Email NVARCHAR(255),
    SoDienThoai NVARCHAR(15),
    TrangThaiHoatDong BIT NOT NULL,
    NgayTao DATE DEFAULT GETDATE(),
    NgayCapNhat DATE
);
INSERT INTO NhaCungCap (MaNhaCungCap, TenNhaCungCap, DiaChi, NguoiDaiDien, Email, SoDienThoai, TrangThaiHoatDong, NgayTao, NgayCapNhat)
VALUES 
    (N'NCC001', N'Công Ty Giày Đông Á', N'123 Đường Nguyễn Trãi, Hà Nội', N'Nguyễn Văn An', N'dongagiay@example.com', N'0123456789', 1, '2023-05-22', '2023-05-22'),
    (N'NCC002', N'Giày Thể Thao Việt', N'456 Đường Lý Thường Kiệt, TP HCM', N'Trần Thị Bích', N'thethaoviet@example.com', N'0987654321', 1, '2023-05-22', '2023-05-22'),
    (N'NCC003', N'Nhà Phân Phối Giày Quốc Tế', N'789 Đường Hoàng Diệu, Đà Nẵng', N'Lê Văn Hoàng', N'giayquocte@example.com', N'0912345678', 1, '2023-05-22', '2023-05-22');
select * from NhaCungCap;
CREATE TABLE KhachHang (
    MaKhachHang NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenKhachHang NVARCHAR(255) NOT NULL,
    NgaySinh DATE,
    GioiTinh CHAR(3) NOT NULL,
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(255),
    DiemTichLuy DECIMAL(10, 0) DEFAULT 0,
    TaiKhoan NVARCHAR(255),
    MatKhau NVARCHAR(255),
    HinhAnh NVARCHAR(255),
    TrangThaiHoatDong BIT DEFAULT 1,
    NgayTao DATE,
    NgayCapNhat DATE,
    ThanhVien BIT DEFAULT 0,
    DiaChi NVARCHAR(255)
);
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, NgaySinh, GioiTinh, SoDienThoai, Email, TaiKhoan, MatKhau, HinhAnh, TrangThaiHoatDong, ThanhVien, DiaChi, NgayTao, NgayCapNhat)
VALUES 
    (N'KH001', N'Nguyễn Văn A', '1990-01-01', N'Nam', N'0123456789', N'nguyenvana@example.com', N'nguyenvana123', N'password123', N'avatar1.jpg', 1, 1, N'123 Đường Nguyễn Trãi, Hà Nội', '2023-05-22', '2023-05-22'),
    (N'KH002', N'Trần Thị Bích', '1992-05-15', N'Nữ', N'0987654321', N'tranthibich@example.com', N'tranthibich456', N'password456', N'avatar2.jpg', 1, 0, N'456 Đường Lý Thường Kiệt, TP HCM', '2023-05-22', '2023-05-22'),
    (N'KH003', N'Lê Minh Hoàng', '1985-10-20', N'Nam', N'0912345678', N'leminhhoang@example.com', N'leminhhoang789', N'password789', N'avatar3.jpg', 1, 0, N'789 Đường Hoàng Diệu, Đà Nẵng', '2023-05-22', '2023-05-22');
select * from KhachHang;	
CREATE TABLE NhanVien (
    MaNhanVien NVARCHAR(50) PRIMARY KEY,
    TenNhanVien NVARCHAR(255) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(3) NOT NULL,
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(255),
    ChucVu NVARCHAR(255), 
    TaiKhoan NVARCHAR(255),
    MatKhau NVARCHAR(255),
    HinhAnh NVARCHAR(255),
    TrangThaiHoatDong BIT DEFAULT 1,
    NgayTao DATE DEFAULT GETDATE(),
    NgayCapNhat DATE,
    DiaChi NVARCHAR(255)
);
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, NgaySinh, GioiTinh, SoDienThoai, Email, ChucVu, TaiKhoan, MatKhau, HinhAnh, TrangThaiHoatDong, DiaChi, NgayTao, NgayCapNhat)
VALUES 
    (N'NV001', N'Phạm Quang Duy', '1990-02-10', N'Nam', N'0123456789', N'phamduy@example.com', N'Quản lý kho', N'phamduy123', N'password123', N'avatar1.jpg', 1, N'123 Đường Nguyễn Trãi, Hà Nội', '2023-05-22', '2023-05-22'),
    (N'NV002', N'Hoàng Thị Mai', '1993-08-25', N'Nữ', N'0987654321', N'hoangmai@example.com', N'Nhân viên bán hàng', N'hoangmai456', N'password456', N'avatar2.jpg', 1, N'456 Đường Lý Thường Kiệt, TP HCM', '2023-05-22', '2023-05-22'),
    (N'NV003', N'Trần Quốc Duy', '1987-11-05', N'Nam', N'0912345678', N'tranquocduy@example.com', N'Nhân viên thu ngân', N'tranquocduy789', N'password789', N'avatar3.jpg', 1, N'789 Đường Hoàng Diệu, Đà Nẵng', '2023-05-22', '2023-05-22');
select * from NhanVien;
CREATE TABLE LoaiSanPham (
    MaLoaiSanPham NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenLoaiSanPham NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(500),
    TrangThaiHoatDong BIT DEFAULT 1,
    NgayTao DATE DEFAULT GETDATE(),
    NgayCapNhat DATE
);
INSERT INTO LoaiSanPham 
    (MaLoaiSanPham, TenLoaiSanPham, MoTa, TrangThaiHoatDong, NgayTao, NgayCapNhat)
VALUES
    (N'LSP001', N'Giày Thể Thao', N'Món giày dành cho thể thao, mang đến sự thoải mái khi vận động.', 1, '2024-11-01', '2024-11-05'),
    (N'LSP002', N'Dép', N'Món dép dùng đi trong nhà hoặc ra ngoài trời, thiết kế đơn giản.', 1, '2024-10-25', '2024-11-02'),
    (N'LSP003', N'Boots', N'Món giày cao cổ, phù hợp với thời tiết lạnh và các chuyến đi xa.', 1, '2024-09-15', '2024-11-03');
select * from LoaiSanPham;	
CREATE TABLE ThuongHieu (
    MaThuongHieu NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenThuongHieu NVARCHAR(255) NOT NULL,
    MoTa NVARCHAR(500),
    TrangThaiHoatDong BIT DEFAULT 1,
    NgayTao DATE DEFAULT GETDATE(),
    NgayCapNhat DATE
);
INSERT INTO ThuongHieu 
    (MaThuongHieu, TenThuongHieu, MoTa, TrangThaiHoatDong, NgayTao, NgayCapNhat)
VALUES
    (N'TH001', N'Nike', N'Thương hiệu giày thể thao nổi tiếng của Mỹ.', 1, '2024-10-10', '2024-11-05'),
    (N'TH002', N'Adidas', N'Thương hiệu đồ thể thao toàn cầu đến từ Đức.', 1, '2024-09-20', '2024-10-28'),
    (N'TH003', N'Puma', N'Thương hiệu giày và phụ kiện thể thao nổi tiếng đến từ Đức.', 1, '2024-08-05', '2024-11-01');
select * from ThuongHieu;	
CREATE TABLE MauSac (
    MaMauSac NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenMauSac NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(500),
    TrangThaiHoatDong BIT DEFAULT 1,
    NgayTao DATE DEFAULT GETDATE(),
    NgayCapNhat DATE
);
INSERT INTO MauSac 
    (MaMauSac, TenMauSac, MoTa, TrangThaiHoatDong, NgayTao, NgayCapNhat)
VALUES
    (N'MS001', N'Màu Đen', N'Màu đen, màu sắc cổ điển và dễ dàng phối đồ.', 1, '2024-10-05', '2024-11-03'),
    (N'MS002', N'Màu Trắng', N'Màu trắng, nhẹ nhàng và thanh thoát.', 1, '2024-07-10', '2024-10-30'),
    (N'MS003', N'Màu Xanh', N'Màu xanh, tươi mới và năng động.', 1, '2024-06-15', '2024-11-01');
select * from MauSac
CREATE TABLE KichThuoc (
    MaKichThuoc NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenKichThuoc NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(500),
    TrangThaiHoatDong BIT DEFAULT 1,
    NgayTao DATE DEFAULT GETDATE(),
    NgayCapNhat DATE
);
INSERT INTO KichThuoc 
    (MaKichThuoc, TenKichThuoc, MoTa, TrangThaiHoatDong, NgayTao, NgayCapNhat)
VALUES
    (N'KT001', N'Nhỏ', N'Kích thước nhỏ, phù hợp với người có bàn chân nhỏ.', 1, '2024-08-01', '2024-10-28'),
    (N'KT002', N'Trung Bình', N'Kích thước trung bình, phù hợp với người có bàn chân trung bình.', 1, '2024-07-15', '2024-11-02'),
    (N'KT003', N'Lớn', N'Kích thước lớn, dành cho người có bàn chân lớn.', 1, '2024-06-20', '2024-10-25');
select * from KichThuoc
CREATE TABLE SanPham (
    MaSanPham NVARCHAR(50) PRIMARY KEY NOT NULL,
    TenSanPham NVARCHAR(255) NOT NULL,
    MaLoaiSanPham NVARCHAR(50),
    MaThuongHieu NVARCHAR(50),
    MaMauSac NVARCHAR(50),
    MaKichThuoc NVARCHAR(50),
	GiaNhap DECIMAL(18, 2),
    GiaBan DECIMAL(18, 2),
	DonViTinh NVARCHAR(255),
    SoLuong INT DEFAULT 0,
    MoTa NVARCHAR(500),
    HinhAnh NVARCHAR(255),
    TrangThaiHoatDong BIT DEFAULT 1,
    NgayTao DATE DEFAULT GETDATE(),
    NgayCapNhat DATE,
    FOREIGN KEY (MaLoaiSanPham) REFERENCES LoaiSanPham(MaLoaiSanPham),
    FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu(MaThuongHieu),
    FOREIGN KEY (MaMauSac) REFERENCES MauSac(MaMauSac),
    FOREIGN KEY (MaKichThuoc) REFERENCES KichThuoc(MaKichThuoc)
);
INSERT INTO SanPham 
    (MaSanPham, TenSanPham, MaLoaiSanPham, MaThuongHieu, MaMauSac, MaKichThuoc, GiaNhap, GiaBan, DonViTinh, SoLuong, MoTa, HinhAnh, TrangThaiHoatDong, NgayTao, NgayCapNhat)
VALUES
    (N'SP001', N'Giày Thể Thao Nike Air Max', N'LSP001', N'TH001', N'MS001', N'KT001', 1500000, 2000000, N'Đôi', 50, N'Giày thể thao Nike Air Max, thiết kế năng động, sử dụng công nghệ đệm Air.', N'images/nike_air_max.jpg', 1, '2024-10-01', '2024-11-05'),
    (N'SP002', N'Dép Adidas Adilette', N'LSP002', N'TH002', N'MS002', N'KT002', 400000, 600000, N'Đôi', 100, N'Dép Adidas Adilette, chất liệu bền và thoải mái, phù hợp cho mùa hè.', N'images/adidas_adilette.jpg', 1, '2024-09-15', '2024-10-28'),
    (N'SP003', N'Boots Timberland', N'LSP003', N'TH003', N'MS003', N'KT003', 1800000, 2500000, N'Đôi', 30, N'Boots Timberland, thiết kế cao cổ, phù hợp cho mùa đông và các chuyến đi dài.', N'images/timberland_boots.jpg', 1, '2024-08-10', '2024-11-03'),
    (N'SP004', N'Giày Thể Thao Adidas UltraBoost', N'LSP001', N'TH002', N'MS003', N'KT001', 2000000, 2700000, N'Đôi', 40, N'Giày thể thao Adidas UltraBoost, công nghệ đệm siêu nhẹ và thoải mái khi chạy.', N'images/adidas_ultraboost.jpg', 1, '2024-10-05', '2024-10-30'),
    (N'SP005', N'Dép Nike Benassi', N'LSP002', N'TH001', N'MS001', N'KT002', 350000, 500000, N'Đôi', 80, N'Dép Nike Benassi, thiết kế đơn giản nhưng cực kỳ thoải mái và dễ sử dụng.', N'images/nike_benassi.jpg', 1, '2024-06-20', '2024-10-25'),
    (N'SP006', N'Giày Thể Thao Puma Suede', N'LSP001', N'TH003', N'MS002', N'KT003', 1600000, 2200000, N'Đôi', 60, N'Giày thể thao Puma Suede, thiết kế cổ điển và dễ phối đồ.', N'images/puma_suede.jpg', 1, '2024-07-25', '2024-10-22'),
    (N'SP007', N'Dép Crocs Classic', N'LSP002', N'TH003', N'MS002', N'KT002', 500000, 700000, N'Đôi', 150, N'Dép Crocs Classic, nhẹ nhàng và dễ sử dụng trong mùa hè.', N'images/crocs_classic.jpg', 1, '2024-09-05', '2024-10-30'),
    (N'SP008', N'Boots Dr. Martens 1460', N'LSP003', N'TH001', N'MS003', N'KT001', 2500000, 3200000, N'Đôi', 20, N'Boots Dr. Martens 1460, thiết kế thời trang và bền bỉ, thích hợp cho mùa đông.', N'images/dr_martens_1460.jpg', 1, '2024-06-01', '2024-09-30'),
    (N'SP009', N'Giày Thể Thao Nike Air Force 1', N'LSP001', N'TH001', N'MS001', N'KT003', 1700000, 2300000, N'Đôi', 70, N'Giày thể thao Nike Air Force 1, phong cách cổ điển và hiện đại.', N'images/nike_air_force_1.jpg', 1, '2024-10-01', '2024-10-28'),
    (N'SP010', N'Giày Thể Thao Adidas NMD', N'LSP001', N'TH002', N'MS002', N'KT003', 1900000, 2600000, N'Đôi', 55, N'Giày thể thao Adidas NMD, thiết kế nhẹ và linh hoạt.', N'images/adidas_nmd.jpg', 1, '2024-09-10', '2024-10-25');
select * from SanPham;
CREATE TABLE KiemKe (
    MaKiemKe NVARCHAR(50) PRIMARY KEY NOT NULL,
    NgayKiemKe DATE, 
    MaNhanVien NVARCHAR(50),
    GhiChu NVARCHAR(500),
    TrangThai BIT DEFAULT 1, 
    NgayTao DATE,
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
INSERT INTO KiemKe (MaKiemKe, NgayKiemKe, MaNhanVien, GhiChu, TrangThai, NgayTao)
VALUES ('KK001', '2024-11-12', 'NV001', N'Kiểm kê kho lần đầu', 1, '2024-11-12');
INSERT INTO KiemKe (MaKiemKe, NgayKiemKe, MaNhanVien, GhiChu, TrangThai, NgayTao)
VALUES ('KK002', '2024-11-13', 'NV002', N'Kiểm kê kho sau đợt nhập hàng', 1, '2024-11-13');
INSERT INTO KiemKe (MaKiemKe, NgayKiemKe, MaNhanVien, GhiChu, TrangThai, NgayTao)
VALUES ('KK003', '2024-11-14', 'NV003', N'Kiểm kê kho theo lịch định kỳ', 1, '2024-11-14');
select * from KiemKe
CREATE TABLE ChiTietKiemKe (
    MaKiemKe NVARCHAR(50),
    MaSanPham NVARCHAR(50),
    SoLuongThucTe INT, 
    SoLuongHeThong INT,                       
    ChenhLech INT,                                
    PRIMARY KEY (MaKiemKe, MaSanPham),          
    FOREIGN KEY (MaKiemKe) REFERENCES KiemKe(MaKiemKe),  
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham) 
);
INSERT INTO ChiTietKiemKe (MaKiemKe, MaSanPham, SoLuongThucTe, SoLuongHeThong, ChenhLech)
VALUES
('KK001', 'SP001', 50, 50, 0),
('KK001', 'SP002', 100, 100, 0),
('KK001', 'SP003', 30, 30, 0),
('KK001', 'SP004', 40, 40, 0),
('KK001', 'SP005', 80, 80, 0);
INSERT INTO ChiTietKiemKe (MaKiemKe, MaSanPham, SoLuongThucTe, SoLuongHeThong, ChenhLech)
VALUES
('KK002', 'SP006', 60, 60, 0),
('KK002', 'SP007', 150, 150, 0),
('KK002', 'SP008', 20, 20, 0),
('KK002', 'SP009', 70, 70, 0),
('KK002', 'SP010', 55, 55, 0);
INSERT INTO ChiTietKiemKe (MaKiemKe, MaSanPham, SoLuongThucTe, SoLuongHeThong, ChenhLech)
VALUES
('KK003', 'SP001', 50, 50, 0),
('KK003', 'SP002', 100, 100, 0),
('KK003', 'SP003', 30, 30, 0),
('KK003', 'SP004', 40, 40, 0),
('KK003', 'SP005', 80, 80, 0);
select * from ChiTietKiemKe
CREATE TABLE DonDatHang (
    MaDonDatHang NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaNhaCungCap NVARCHAR(50),
    MaNhanVien NVARCHAR(50),
    NgayDatHang DATE,
    NgayDuKienGiao DATE,
    TrangThai NVARCHAR(50),
    GhiChu NVARCHAR(500), 
    NgayTao DATE,
    FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
INSERT INTO DonDatHang (MaDonDatHang, MaNhaCungCap, MaNhanVien, NgayDatHang, NgayDuKienGiao, TrangThai, GhiChu, NgayTao)
VALUES 
    (N'DDH001', N'NCC001', N'NV001', '2024-11-10', '2024-11-15', N'Chưa Xác Nhận', N'Đơn đặt hàng cho lô sản phẩm Giày Đông Á', '2024-11-10'),
    (N'DDH002', N'NCC002', N'NV002', '2024-11-12', '2024-11-18', N'Chưa Xác Nhận', N'Đặt hàng các sản phẩm giày thể thao Việt', '2024-11-12'),
    (N'DDH003', N'NCC003', N'NV003', '2024-11-14', '2024-11-20', N'Chưa Xác Nhận', N'Đơn đặt hàng bổ sung cho nhà phân phối giày quốc tế', '2024-11-14');
select * from DonDatHang
CREATE TABLE ChiTietDonDatHang (
    MaDonDatHang NVARCHAR(50), 
    MaSanPham NVARCHAR(50),
    SoLuongYeuCau INT,
	SoLuongCungCap INT,
	SoLuongThieu INT,
    DonGia DECIMAL(18, 2),
    ThanhTien DECIMAL(18, 2),
    PRIMARY KEY (MaDonDatHang, MaSanPham),
    FOREIGN KEY (MaDonDatHang) REFERENCES DonDatHang(MaDonDatHang),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
INSERT INTO ChiTietDonDatHang (MaDonDatHang, MaSanPham, SoLuongYeuCau, SoLuongCungCap, SoLuongThieu, DonGia, ThanhTien)
VALUES 
    (N'DDH001', N'SP001', 10, 10, 0, 2000000, 20000000),
    (N'DDH001', N'SP002', 20, 20, 0, 600000, 12000000),
    (N'DDH001', N'SP003', 15, 15, 0, 2500000, 37500000),
    (N'DDH001', N'SP004', 30, 30, 0, 2700000, 81000000),
    (N'DDH001', N'SP005', 50, 50, 0, 500000, 25000000),
    (N'DDH001', N'SP006', 25, 25, 0, 2200000, 55000000);
INSERT INTO ChiTietDonDatHang (MaDonDatHang, MaSanPham, SoLuongYeuCau, SoLuongCungCap, SoLuongThieu, DonGia, ThanhTien)
VALUES 
    (N'DDH002', N'SP003', 10, 10, 0, 2500000, 25000000),
    (N'DDH002', N'SP004', 20, 20, 0, 2700000, 54000000),
    (N'DDH002', N'SP005', 30, 30, 0, 500000, 15000000),
    (N'DDH002', N'SP006', 40, 40, 0, 2200000, 88000000),
    (N'DDH002', N'SP007', 50, 50, 0, 700000, 35000000),
    (N'DDH002', N'SP008', 10, 10, 0, 3200000, 32000000);
INSERT INTO ChiTietDonDatHang (MaDonDatHang, MaSanPham, SoLuongYeuCau, SoLuongCungCap, SoLuongThieu, DonGia, ThanhTien)
VALUES 
    (N'DDH003', N'SP009', 12, 12, 0, 2300000, 27600000),
    (N'DDH003', N'SP010', 10, 10, 0, 2600000, 26000000),
    (N'DDH003', N'SP003', 15, 15, 0, 2500000, 37500000),
    (N'DDH003', N'SP004', 20, 20, 0, 2700000, 54000000),
    (N'DDH003', N'SP005', 30, 30, 0, 500000, 15000000),
    (N'DDH003', N'SP006', 25, 25, 0, 2200000, 55000000),
    (N'DDH003', N'SP007', 20, 20, 0, 700000, 14000000);
select * from ChiTietDonDatHang

CREATE TABLE HoaDon (
    MaHoaDon NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaKhachHang NVARCHAR(50),
    MaNhanVien NVARCHAR(50),
    TongTien DECIMAL(18, 2),
    DiemTichLuySuDung INT,
    PhuongThucThanhToan NVARCHAR(50),
    NgayTao DATE,
    GhiChu NVARCHAR(500),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, TongTien, DiemTichLuySuDung, PhuongThucThanhToan, NgayTao, GhiChu)
VALUES 
('HD001', 'KH001', 'NV001', 20200000, 0, N'Tiền mặt', '2024-11-10', N'Khách hàng thanh toán bằng tiền mặt');

INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, TongTien, DiemTichLuySuDung, PhuongThucThanhToan, NgayTao, GhiChu)
VALUES 
('HD002', 'KH002', 'NV002', 16700000, 0, N'Thẻ ngân hàng', '2024-11-10', N'Khách hàng thanh toán bằng thẻ ngân hàng');

INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, TongTien, DiemTichLuySuDung, PhuongThucThanhToan, NgayTao, GhiChu)
VALUES 
('HD003', 'KH003', 'NV003', 13700000.00, 0, N'Ví điện tử', '2024-11-10', N'Khách hàng thanh toán qua ví điện tử');
select * from HoaDon
CREATE TABLE ChiTietHoaDon (
    MaHoaDon NVARCHAR(50),
    MaSanPham NVARCHAR(50),
    SoLuong INT,
    DonGia DECIMAL(18, 2),
    ThanhTien DECIMAL(18, 2),
    PRIMARY KEY (MaHoaDon, MaSanPham),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien)
VALUES
('HD001', 'SP001', 1, 2000000, 2000000),
('HD001', 'SP002', 2, 600000, 1200000),
('HD001', 'SP003', 1, 2500000, 2500000),
('HD001', 'SP004', 3, 2700000, 8100000),
('HD001', 'SP005', 4, 500000, 2000000),
('HD001', 'SP006', 2, 2200000, 4400000);
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien)
VALUES
('HD002', 'SP007', 2, 700000, 1400000),
('HD002', 'SP008', 1, 3200000, 3200000),
('HD002', 'SP009', 3, 2300000, 6900000),
('HD002', 'SP010', 1, 2600000, 2600000),
('HD002', 'SP001', 1, 2000000, 2000000),
('HD002', 'SP002', 1, 600000, 600000);
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien)
VALUES
('HD003', 'SP003', 1, 2500000, 2500000),
('HD003', 'SP004', 1, 2700000, 2700000),
('HD003', 'SP005', 2, 500000, 1000000),
('HD003', 'SP006', 1, 2200000, 2200000),
('HD003', 'SP007', 3, 700000, 2100000),
('HD003', 'SP008', 1, 3200000, 3200000);
SELECT 
    HoaDon.MaHoaDon,
    SUM(ChiTietHoaDon.ThanhTien) AS TongTien
FROM 
    HoaDon
JOIN 
    ChiTietHoaDon ON HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon
GROUP BY 
    HoaDon.MaHoaDon;

CREATE TABLE TraSanPham (
    MaTraSanPham NVARCHAR(50) PRIMARY KEY NOT NULL,
    MaHoaDon NVARCHAR(50),
    MaKhachHang NVARCHAR(50),
    MaNhanVien NVARCHAR(50),
    LyDoTra NVARCHAR(500),
    NgayTra DATE,
    TongTienHoanLai DECIMAL(18, 2),
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
INSERT INTO TraSanPham (MaTraSanPham, MaHoaDon, MaKhachHang, MaNhanVien, LyDoTra, NgayTra, TongTienHoanLai)
VALUES ('TSP001', 'HD001', 'KH001', 'NV001', N'Sản phẩm bị hỏng', '2024-11-12', 150000.00);
CREATE TABLE TraSanPhamChiTiet (
    MaTraSanPham NVARCHAR(50),
    MaSanPham NVARCHAR(50),
	MaHoaDon NVARCHAR(50),
    SoLuong INT,           
    TinhTrangSanPham NVARCHAR(100),
    SoTienHoanLai DECIMAL(18, 2),
    PRIMARY KEY (MaTraSanPham, MaSanPham),
    FOREIGN KEY (MaTraSanPham) REFERENCES TraSanPham(MaTraSanPham),
    FOREIGN KEY (MaHoaDon, MaSanPham) REFERENCES ChiTietHoaDon(MaHoaDon, MaSanPham)
);
INSERT INTO TraSanPhamChiTiet (MaTraSanPham, MaSanPham, MaHoaDon, SoLuong, TinhTrangSanPham, SoTienHoanLai)
VALUES ('TSP001', 'SP001', 'HD001', 2, N'Hỏng do vận chuyển', 50000.00);

CREATE TABLE VaiTro (
    MaVaiTro NVARCHAR(50) PRIMARY KEY,
    TenVaiTro NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(255)
);
INSERT INTO VaiTro (MaVaiTro, TenVaiTro, MoTa) VALUES 
    (N'VT001', N'Quản trị viên', N'Quyền truy cập đầy đủ trong hệ thống'),
    (N'VT002', N'Nhân viên bán hàng', N'Chỉ có quyền truy cập vào các chức năng bán hàng'),
    (N'VT003', N'Nhân viên kho', N'Chỉ có quyền truy cập vào các chức năng quản lý kho');
select * from VaiTro
CREATE TABLE Quyen (
    MaQuyen NVARCHAR(50) PRIMARY KEY,
    TenQuyen NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(255)
);
INSERT INTO Quyen (MaQuyen, TenQuyen, MoTa) VALUES 
    (N'Q001', N'Xem màn hình quản lý kho', N'Quyền truy cập vào màn hình quản lý kho'),
    (N'Q002', N'Xem màn hình bán hàng', N'Quyền truy cập vào màn hình bán hàng'),
    (N'Q003', N'Xem màn hình báo cáo', N'Quyền truy cập vào màn hình báo cáo'),
    (N'Q004', N'Quản lý tài khoản', N'Quyền truy cập và quản lý tài khoản người dùng');
select * from Quyen
CREATE TABLE VaiTro_Quyen (
    MaVaiTro NVARCHAR(50),
    MaQuyen NVARCHAR(50),
    PRIMARY KEY (MaVaiTro, MaQuyen),
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro) ON DELETE CASCADE,
    FOREIGN KEY (MaQuyen) REFERENCES Quyen(MaQuyen) ON DELETE CASCADE
);
-- Gán quyền cho "Quản trị viên"
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen) VALUES 
    (N'VT001', N'Q001'), 
    (N'VT001', N'Q002'), 
    (N'VT001', N'Q003'),
    (N'VT001', N'Q004');

-- Gán quyền cho "Nhân viên bán hàng"
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen) VALUES 
    (N'VT002', N'Q002'); 

-- Gán quyền cho "Nhân viên kho"
INSERT INTO VaiTro_Quyen (MaVaiTro, MaQuyen) VALUES 
    (N'VT003', N'Q001');

CREATE TABLE NhanVien_VaiTro (
    MaNhanVien NVARCHAR(50),
    MaVaiTro NVARCHAR(50),
    PRIMARY KEY (MaNhanVien, MaVaiTro),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien) ON DELETE CASCADE,
    FOREIGN KEY (MaVaiTro) REFERENCES VaiTro(MaVaiTro) ON DELETE CASCADE
);
-- Gán vai trò "Quản trị viên" cho nhân viên có mã 'NV001'
INSERT INTO NhanVien_VaiTro (MaNhanVien, MaVaiTro) VALUES 
    (N'NV001', N'VT001');

-- Gán vai trò "Nhân viên bán hàng" cho nhân viên có mã 'NV002'
INSERT INTO NhanVien_VaiTro (MaNhanVien, MaVaiTro) VALUES 
    (N'NV002', N'VT002');

-- Gán vai trò "Nhân viên kho" cho nhân viên có mã 'NV003'
INSERT INTO NhanVien_VaiTro (MaNhanVien, MaVaiTro) VALUES 
    (N'NV003', N'VT003');