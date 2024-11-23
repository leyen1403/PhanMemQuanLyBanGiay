USE [db_QuanLyBanGiay]
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [DiemTichLuy], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [ThanhVien], [DiaChi]) VALUES (N'KH001', N'Nguyễn Văn A', CAST(N'1990-01-01' AS Date), N'Nam', N'0123456789', N'nguyenvana@example.com', CAST(0 AS Decimal(10, 0)), N'nguyenvana123', N'password123', N'avatar1.jpg', 1, CAST(N'2023-05-22' AS Date), CAST(N'2023-05-22' AS Date), 1, N'123 Đường Nguyễn Trãi, Hà Nội')
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [DiemTichLuy], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [ThanhVien], [DiaChi]) VALUES (N'KH002', N'Trần Thị Bích', CAST(N'1992-05-15' AS Date), N'N? ', N'0987654321', N'tranthibich@example.com', CAST(0 AS Decimal(10, 0)), N'tranthibich456', N'password456', N'avatar2.jpg', 1, CAST(N'2023-05-22' AS Date), CAST(N'2023-05-22' AS Date), 0, N'456 Đường Lý Thường Kiệt, TP HCM')
GO
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [DiemTichLuy], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [ThanhVien], [DiaChi]) VALUES (N'KH003', N'Lê Minh Hoàng', CAST(N'1985-10-20' AS Date), N'Nam', N'0912345678', N'leminhhoang@example.com', CAST(0 AS Decimal(10, 0)), N'leminhhoang789', N'password789', N'avatar3.jpg', 1, CAST(N'2023-05-22' AS Date), CAST(N'2023-05-22' AS Date), 0, N'789 Đường Hoàng Diệu, Đà Nẵng')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [ChucVu], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV001', N'Phạm Quang Duy', CAST(N'1990-02-10' AS Date), N'Nam', N'0123456789', N'phamduy@example.com', N'Quản lý kho', N'admin', N'admin', N'NV001.png', 1, CAST(N'2023-05-10' AS Date), CAST(N'2024-11-17' AS Date), N'123 Đường Nguyễn Trãi, Hà Nội')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [ChucVu], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV002', N'Hoàng Thị Mai', CAST(N'1993-08-25' AS Date), N'Nữ', N'0987654321', N'hoangmai@example.com', N'Nhân viên bán hàng', N'admin1', N'admin1', N'NV002.png', 1, CAST(N'2023-05-22' AS Date), CAST(N'2024-11-17' AS Date), N'456 Đường Lý Thường Kiệt, TP HCM')
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [GioiTinh], [SoDienThoai], [Email], [ChucVu], [TaiKhoan], [MatKhau], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat], [DiaChi]) VALUES (N'NV003', N'Trần Quốc Duy', CAST(N'1987-11-05' AS Date), N'Nam', N'0912345678', N'tranquocduy@example.com', N'Nhân viên thu ngân', N'admin123', N'admin123', N'NV003.png', 1, CAST(N'2023-05-22' AS Date), CAST(N'2024-11-17' AS Date), N'789 Đường Hoàng Diệu, Đà Nẵng')
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [TongTien], [DiemTichLuySuDung], [PhuongThucThanhToan], [NgayTao], [GhiChu]) VALUES (N'HD001', N'KH001', N'NV001', CAST(20200000.00 AS Decimal(18, 2)), 0, N'Tiền mặt', CAST(N'2024-11-10' AS Date), N'Khách hàng thanh toán bằng tiền mặt')
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [TongTien], [DiemTichLuySuDung], [PhuongThucThanhToan], [NgayTao], [GhiChu]) VALUES (N'HD002', N'KH002', N'NV002', CAST(16700000.00 AS Decimal(18, 2)), 0, N'Thẻ ngân hàng', CAST(N'2024-11-10' AS Date), N'Khách hàng thanh toán bằng thẻ ngân hàng')
GO
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [TongTien], [DiemTichLuySuDung], [PhuongThucThanhToan], [NgayTao], [GhiChu]) VALUES (N'HD003', N'KH003', N'NV003', CAST(13700000.00 AS Decimal(18, 2)), 0, N'Ví điện tử', CAST(N'2024-11-10' AS Date), N'Khách hàng thanh toán qua ví điện tử')
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'KT001', N'Nhỏ', N'Kích thước nhỏ, phù hợp với người có bàn chân nhỏ.', 1, CAST(N'2024-08-01' AS Date), CAST(N'2024-10-28' AS Date))
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'KT002', N'Trung Bình', N'Kích thước trung bình, phù hợp với người có bàn chân trung bình.', 1, CAST(N'2024-07-15' AS Date), CAST(N'2024-11-02' AS Date))
GO
INSERT [dbo].[KichThuoc] ([MaKichThuoc], [TenKichThuoc], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'KT003', N'Lớn', N'Kích thước lớn, dành cho người có bàn chân lớn.', 1, CAST(N'2024-06-20' AS Date), CAST(N'2024-10-25' AS Date))
GO
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'LSP001', N'Giày Thể Thao', N'Món giày dành cho thể thao, mang đến sự thoải mái khi vận động.', 1, CAST(N'2024-11-01' AS Date), CAST(N'2024-11-05' AS Date))
GO
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'LSP002', N'Dép', N'Món dép dùng đi trong nhà hoặc ra ngoài trời, thiết kế đơn giản.', 1, CAST(N'2024-10-25' AS Date), CAST(N'2024-11-02' AS Date))
GO
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'LSP003', N'Boots', N'Món giày cao cổ, phù hợp với thời tiết lạnh và các chuyến đi xa.', 1, CAST(N'2024-09-15' AS Date), CAST(N'2024-11-03' AS Date))
GO
INSERT [dbo].[MauSac] ([MaMauSac], [TenMauSac], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'MS001', N'Màu Đen', N'Màu đen, màu sắc cổ điển và dễ dàng phối đồ.', 1, CAST(N'2024-10-05' AS Date), CAST(N'2024-11-03' AS Date))
GO
INSERT [dbo].[MauSac] ([MaMauSac], [TenMauSac], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'MS002', N'Màu Trắng', N'Màu trắng, nhẹ nhàng và thanh thoát.', 1, CAST(N'2024-07-10' AS Date), CAST(N'2024-10-30' AS Date))
GO
INSERT [dbo].[MauSac] ([MaMauSac], [TenMauSac], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'MS003', N'Màu Xanh', N'Màu xanh, tươi mới và năng động.', 1, CAST(N'2024-06-15' AS Date), CAST(N'2024-11-01' AS Date))
GO
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'TH001', N'Nike', N'Thương hiệu giày thể thao nổi tiếng của Mỹ.', 1, CAST(N'2024-10-10' AS Date), CAST(N'2024-11-05' AS Date))
GO
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'TH002', N'Adidas', N'Thương hiệu đồ thể thao toàn cầu đến từ Đức.', 1, CAST(N'2024-09-20' AS Date), CAST(N'2024-10-28' AS Date))
GO
INSERT [dbo].[ThuongHieu] ([MaThuongHieu], [TenThuongHieu], [MoTa], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'TH003', N'Puma', N'Thương hiệu giày và phụ kiện thể thao nổi tiếng đến từ Đức.', 1, CAST(N'2024-08-05' AS Date), CAST(N'2024-11-01' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP001', N'Giày Thể Thao Nike Air Max', N'LSP001', N'TH001', N'MS001', N'KT001', CAST(2000000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)), N'Đôi', 107, 5, N'Giày thể thao Nike Air Max, thiết kế năng động, sử dụng công nghệ đệm Air.', N'images/nike_air_max.jpg', 1, CAST(N'2024-10-01' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP002', N'Dép Adidas Adilette', N'LSP002', N'TH002', N'MS002', N'KT002', CAST(600000.00 AS Decimal(18, 2)), CAST(600000.00 AS Decimal(18, 2)), N'Đôi', 175, 5, N'Dép Adidas Adilette, chất liệu bền và thoải mái, phù hợp cho mùa hè.', N'images/adidas_adilette.jpg', 1, CAST(N'2024-09-15' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP003', N'Boots Timberland', N'LSP003', N'TH003', N'MS003', N'KT003', CAST(2500000.00 AS Decimal(18, 2)), CAST(2500000.00 AS Decimal(18, 2)), N'Đôi', 60, 5, N'Boots Timberland, thiết kế cao cổ, phù hợp cho mùa đông và các chuyến đi dài.', N'images/timberland_boots.jpg', 1, CAST(N'2024-08-10' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP004', N'Giày Thể Thao Adidas UltraBoost', N'LSP001', N'TH002', N'MS003', N'KT001', CAST(2000000.00 AS Decimal(18, 2)), CAST(2700000.00 AS Decimal(18, 2)), N'Đôi', 120, 5, N'Giày thể thao Adidas UltraBoost, công nghệ đệm siêu nhẹ và thoải mái khi chạy.', N'images/adidas_ultraboost.jpg', 1, CAST(N'2024-10-05' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP005', N'Dép Nike Benassi', N'LSP002', N'TH001', N'MS001', N'KT002', CAST(350000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), N'Đôi', 125, 5, N'Dép Nike Benassi, thiết kế đơn giản nhưng cực kỳ thoải mái và dễ sử dụng.', N'images/nike_benassi.jpg', 1, CAST(N'2024-06-20' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP006', N'Giày Thể Thao Puma Suede', N'LSP001', N'TH003', N'MS002', N'KT003', CAST(1600000.00 AS Decimal(18, 2)), CAST(2200000.00 AS Decimal(18, 2)), N'Đôi', 100, 5, N'Giày thể thao Puma Suede, thiết kế cổ điển và dễ phối đồ.', N'images/puma_suede.jpg', 1, CAST(N'2024-07-25' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP007', N'Dép Crocs Classic', N'LSP002', N'TH003', N'MS002', N'KT002', CAST(500000.00 AS Decimal(18, 2)), CAST(700000.00 AS Decimal(18, 2)), N'Đôi', 174, 5, N'Dép Crocs Classic, nhẹ nhàng và dễ sử dụng trong mùa hè.', N'images/crocs_classic.jpg', 1, CAST(N'2024-09-05' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP008', N'Boots Dr. Martens 1460', N'LSP003', N'TH001', N'MS003', N'KT001', CAST(2500000.00 AS Decimal(18, 2)), CAST(3200000.00 AS Decimal(18, 2)), N'Đôi', 94, 10, N'Boots Dr. Martens 1460, thiết kế thời trang và bền bỉ, thích hợp cho mùa đông.', N'images/dr_martens_1460.jpg', 1, CAST(N'2024-06-01' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP009', N'Giày Thể Thao Nike Air Force 1', N'LSP001', N'TH001', N'MS001', N'KT003', CAST(1700000.00 AS Decimal(18, 2)), CAST(2300000.00 AS Decimal(18, 2)), N'Đôi', 146, 10, N'Giày thể thao Nike Air Force 1, phong cách cổ điển và hiện đại.', N'images/nike_air_force_1.jpg', 1, CAST(N'2024-10-01' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [MaLoaiSanPham], [MaThuongHieu], [MaMauSac], [MaKichThuoc], [GiaNhap], [GiaBan], [DonViTinh], [SoLuong], [SoLuongToiThieu], [MoTa], [HinhAnh], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'SP010', N'Giày Thể Thao Adidas NMD', N'LSP001', N'TH002', N'MS002', N'KT003', CAST(1900000.00 AS Decimal(18, 2)), CAST(2600000.00 AS Decimal(18, 2)), N'Đôi', 107, 10, N'Giày thể thao Adidas NMD, thiết kế nhẹ và linh hoạt.', N'images/adidas_nmd.jpg', 1, CAST(N'2024-09-10' AS Date), CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP001', 1, CAST(2000000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP002', 2, CAST(600000.00 AS Decimal(18, 2)), CAST(1200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP003', 1, CAST(2500000.00 AS Decimal(18, 2)), CAST(2500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP004', 3, CAST(2700000.00 AS Decimal(18, 2)), CAST(8100000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP005', 4, CAST(500000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD001', N'SP006', 2, CAST(2200000.00 AS Decimal(18, 2)), CAST(4400000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP001', 1, CAST(2000000.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP002', 1, CAST(600000.00 AS Decimal(18, 2)), CAST(600000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP007', 2, CAST(700000.00 AS Decimal(18, 2)), CAST(1400000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP008', 1, CAST(3200000.00 AS Decimal(18, 2)), CAST(3200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP009', 3, CAST(2300000.00 AS Decimal(18, 2)), CAST(6900000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD002', N'SP010', 1, CAST(2600000.00 AS Decimal(18, 2)), CAST(2600000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP003', 1, CAST(2500000.00 AS Decimal(18, 2)), CAST(2500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP004', 1, CAST(2700000.00 AS Decimal(18, 2)), CAST(2700000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP005', 2, CAST(500000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP006', 1, CAST(2200000.00 AS Decimal(18, 2)), CAST(2200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP007', 3, CAST(700000.00 AS Decimal(18, 2)), CAST(2100000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietHoaDon] ([MaHoaDon], [MaSanPham], [SoLuong], [DonGia], [ThanhTien]) VALUES (N'HD003', N'SP008', 1, CAST(3200000.00 AS Decimal(18, 2)), CAST(3200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TraSanPham] ([MaTraSanPham], [MaHoaDon], [MaKhachHang], [MaNhanVien], [LyDoTra], [NgayTra], [TongTienHoanLai]) VALUES (N'TSP001', N'HD001', N'KH001', N'NV001', N'Sản phẩm bị hỏng', CAST(N'2024-11-12' AS Date), CAST(150000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[TraSanPhamChiTiet] ([MaTraSanPham], [MaSanPham], [MaHoaDon], [SoLuong], [TinhTrangSanPham], [SoTienHoanLai]) VALUES (N'TSP001', N'SP001', N'HD001', 2, N'Hỏng do vận chuyển', CAST(50000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'NCC001', N'Công Ty Giày Đông Á', N'123 Đường Nguyễn Trãi, Hà Nội', N'Nguyễn Văn An', N'dongagiay@example.com', N'0123456789', 1, CAST(N'2023-05-22' AS Date), CAST(N'2023-05-22' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'NCC002', N'Giày Thể Thao Việt', N'456 Đường Lý Thường Kiệt, TP HCM', N'Trần Thị Bích', N'thethaoviet@example.com', N'0987654321', 1, CAST(N'2023-05-22' AS Date), CAST(N'2023-05-22' AS Date))
GO
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [DiaChi], [NguoiDaiDien], [Email], [SoDienThoai], [TrangThaiHoatDong], [NgayTao], [NgayCapNhat]) VALUES (N'NCC003', N'Nhà Phân Phối Giày Quốc Tế', N'789 Đường Hoàng Diệu, Đà Nẵng', N'Lê Văn Hoàng', N'giayquocte@example.com', N'0912345678', 1, CAST(N'2023-05-22' AS Date), CAST(N'2023-05-22' AS Date))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH001', N'NCC001', N'NV001', CAST(N'2024-11-10' AS Date), CAST(N'2024-11-15' AS Date), N'Đang giao hàng', N'Đơn đặt hàng cho lô sản phẩm Giày Đông Á', CAST(N'2024-11-10' AS Date), CAST(1648000000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH002', N'NCC002', N'NV002', CAST(N'2024-11-12' AS Date), CAST(N'2024-11-18' AS Date), N'Hoàn thành', N'Đặt hàng các sản phẩm giày thể thao Việt', CAST(N'2024-11-12' AS Date), CAST(249000000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH003', N'NCC003', N'NV003', CAST(N'2024-11-14' AS Date), CAST(N'2024-11-20' AS Date), N'Hoàn thành', N'Đơn đặt hàng bổ sung cho nhà phân phối giày quốc tế', CAST(N'2024-11-14' AS Date), CAST(229100000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH004', N'NCC001', N'NV001', CAST(N'2024-11-15' AS Date), CAST(N'2024-11-22' AS Date), N'Hoàn thành', N'Nhập hàng khẩn cấp', CAST(N'2024-11-15' AS Date), CAST(158000000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH005', N'NCC001', N'NV001', CAST(N'2024-11-16' AS Date), CAST(N'2024-11-23' AS Date), N'Hoàn thành', N'Nhập hàng đêm khuya', CAST(N'2024-11-16' AS Date), CAST(100500000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH006', N'NCC002', N'NV001', CAST(N'2024-11-16' AS Date), CAST(N'2024-11-23' AS Date), N'Hoàn thành', N'123', CAST(N'2024-11-16' AS Date), CAST(125400000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH007', N'NCC002', N'NV001', CAST(N'2024-11-16' AS Date), CAST(N'2024-11-23' AS Date), N'Hoàn thành', N'alo', CAST(N'2024-11-16' AS Date), CAST(61730000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH008', N'NCC002', N'NV001', CAST(N'2024-11-16' AS Date), CAST(N'2024-11-23' AS Date), N'Đang giao hàng', N'Ngày mới', CAST(N'2024-11-16' AS Date), CAST(395250000 AS Decimal(12, 0)))
GO
INSERT [dbo].[DonDatHang] ([MaDonDatHang], [MaNhaCungCap], [MaNhanVien], [NgayDatHang], [NgayDuKienGiao], [TrangThai], [GhiChu], [NgayTao], [TongTien]) VALUES (N'DDH009', N'NCC003', N'NV001', CAST(N'2024-11-16' AS Date), CAST(N'2024-11-23' AS Date), N'Đang giao hàng', N'...', CAST(N'2024-11-16' AS Date), CAST(28500000 AS Decimal(12, 0)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH001', N'SP001', 10, 10, 0, CAST(110000000.00 AS Decimal(18, 2)), CAST(1100000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH001', N'SP002', 20, 20, 0, CAST(600000.00 AS Decimal(18, 2)), CAST(12000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH001', N'SP003', 15, 15, 0, CAST(25000000.00 AS Decimal(18, 2)), CAST(375000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH001', N'SP004', 30, 30, 0, CAST(2700000.00 AS Decimal(18, 2)), CAST(81000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH001', N'SP005', 50, 50, 0, CAST(500000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH001', N'SP006', 25, 25, 0, CAST(2200000.00 AS Decimal(18, 2)), CAST(55000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH002', N'SP003', 10, 10, 0, CAST(2500000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH002', N'SP004', 20, 20, 0, CAST(2700000.00 AS Decimal(18, 2)), CAST(54000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH002', N'SP005', 30, 30, 0, CAST(500000.00 AS Decimal(18, 2)), CAST(15000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH002', N'SP006', 40, 40, 0, CAST(2200000.00 AS Decimal(18, 2)), CAST(88000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH002', N'SP007', 50, 50, 0, CAST(700000.00 AS Decimal(18, 2)), CAST(35000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH002', N'SP008', 10, 10, 0, CAST(3200000.00 AS Decimal(18, 2)), CAST(32000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH003', N'SP003', 15, 15, 0, CAST(2500000.00 AS Decimal(18, 2)), CAST(37500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH003', N'SP004', 20, 20, 0, CAST(2700000.00 AS Decimal(18, 2)), CAST(54000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH003', N'SP005', 30, 30, 0, CAST(500000.00 AS Decimal(18, 2)), CAST(15000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH003', N'SP006', 25, 25, 0, CAST(2200000.00 AS Decimal(18, 2)), CAST(55000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH003', N'SP007', 20, 20, 0, CAST(700000.00 AS Decimal(18, 2)), CAST(14000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH003', N'SP009', 12, 12, 0, CAST(2300000.00 AS Decimal(18, 2)), CAST(27600000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH003', N'SP010', 10, 10, 0, CAST(2600000.00 AS Decimal(18, 2)), CAST(26000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH004', N'SP004', 20, 20, 0, CAST(2000000.00 AS Decimal(18, 2)), CAST(40000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH004', N'SP008', 20, 20, 0, CAST(2500000.00 AS Decimal(18, 2)), CAST(50000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH004', N'SP009', 40, 40, 0, CAST(1700000.00 AS Decimal(18, 2)), CAST(68000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH005', N'SP001', 27, 27, 0, CAST(1500000.00 AS Decimal(18, 2)), CAST(40500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH005', N'SP004', 30, 30, 0, CAST(2000000.00 AS Decimal(18, 2)), CAST(60000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH006', N'SP003', 12, 12, 0, CAST(1800000.00 AS Decimal(18, 2)), CAST(21600000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH006', N'SP004', 15, 15, 0, CAST(2000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH006', N'SP006', 18, 18, 0, CAST(1600000.00 AS Decimal(18, 2)), CAST(28800000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH006', N'SP008', 18, 18, 0, CAST(2500000.00 AS Decimal(18, 2)), CAST(45000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH007', N'SP003', 3, 3, 0, CAST(10000.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH007', N'SP006', 4, 4, 0, CAST(1600000.00 AS Decimal(18, 2)), CAST(6400000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH007', N'SP009', 18, 18, 0, CAST(1700000.00 AS Decimal(18, 2)), CAST(30600000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH007', N'SP010', 9, 13, -4, CAST(1900000.00 AS Decimal(18, 2)), CAST(24700000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP001', 30, 30, 0, CAST(2000000.00 AS Decimal(18, 2)), CAST(60000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP002', 48, 45, 3, CAST(600000.00 AS Decimal(18, 2)), CAST(27000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP003', 15, 15, 0, CAST(2500000.00 AS Decimal(18, 2)), CAST(37500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP004', 30, 15, 15, CAST(2000000.00 AS Decimal(18, 2)), CAST(30000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP005', 24, 15, 9, CAST(350000.00 AS Decimal(18, 2)), CAST(5250000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP006', 33, 18, 15, CAST(1600000.00 AS Decimal(18, 2)), CAST(28800000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP007', 33, 24, 9, CAST(500000.00 AS Decimal(18, 2)), CAST(12000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP008', 36, 36, 0, CAST(2500000.00 AS Decimal(18, 2)), CAST(90000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP009', 18, 18, 0, CAST(1700000.00 AS Decimal(18, 2)), CAST(30600000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH008', N'SP010', 39, 39, 0, CAST(1900000.00 AS Decimal(18, 2)), CAST(74100000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH009', N'SP002', 30, 30, 0, CAST(600000.00 AS Decimal(18, 2)), CAST(18000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH009', N'SP005', 30, 30, 0, CAST(350000.00 AS Decimal(18, 2)), CAST(10500000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ChiTietDonDatHang] ([MaDonDatHang], [MaSanPham], [SoLuongYeuCau], [SoLuongCungCap], [SoLuongThieu], [DonGia], [ThanhTien]) VALUES (N'DDH009', N'SP007', 30, 0, 30, CAST(500000.00 AS Decimal(18, 2)), CAST(15000000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[KiemKe] ([MaKiemKe], [NgayKiemKe], [MaNhanVien], [GhiChu], [TrangThai], [NgayTao]) VALUES (N'KK001', CAST(N'2024-11-12' AS Date), N'NV001', N'Kiểm kê kho lần đầu', 1, CAST(N'2024-11-12' AS Date))
GO
INSERT [dbo].[KiemKe] ([MaKiemKe], [NgayKiemKe], [MaNhanVien], [GhiChu], [TrangThai], [NgayTao]) VALUES (N'KK002', CAST(N'2024-11-13' AS Date), N'NV002', N'Kiểm kê kho sau đợt nhập hàng', 1, CAST(N'2024-11-13' AS Date))
GO
INSERT [dbo].[KiemKe] ([MaKiemKe], [NgayKiemKe], [MaNhanVien], [GhiChu], [TrangThai], [NgayTao]) VALUES (N'KK003', CAST(N'2024-11-14' AS Date), N'NV003', N'Kiểm kê kho theo lịch định kỳ', 1, CAST(N'2024-11-14' AS Date))
GO
INSERT [dbo].[KiemKe] ([MaKiemKe], [NgayKiemKe], [MaNhanVien], [GhiChu], [TrangThai], [NgayTao]) VALUES (N'KK004', CAST(N'2024-11-16' AS Date), N'NV001', N'Kiểm kê đột xuất', 1, CAST(N'2024-11-16' AS Date))
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK001', N'SP001', 50, 50, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK001', N'SP002', 100, 100, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK001', N'SP003', 30, 30, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK001', N'SP004', 40, 40, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK001', N'SP005', 80, 80, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK002', N'SP006', 60, 60, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK002', N'SP007', 150, 150, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK002', N'SP008', 20, 20, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK002', N'SP009', 70, 70, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK002', N'SP010', 55, 55, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK003', N'SP001', 50, 50, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK003', N'SP002', 100, 100, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK003', N'SP003', 30, 30, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK003', N'SP004', 40, 40, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK003', N'SP005', 80, 80, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP001', 107, 107, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP002', 136, 136, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP003', 60, 60, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP004', 120, 120, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP005', 95, 95, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP006', 100, 100, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP007', 174, 174, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP008', 76, 76, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP009', 146, 146, 0, N'')
GO
INSERT [dbo].[ChiTietKiemKe] ([MaKiemKe], [MaSanPham], [SoLuongThucTe], [SoLuongHeThong], [ChenhLech], [LyDoChenhLech]) VALUES (N'KK004', N'SP010', 98, 98, 0, N'')
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT001', N'Quản trị viên', N'Quyền truy cập đầy đủ trong hệ thống')
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT002', N'Nhân viên bán hàng', N'Chỉ có quyền truy cập vào các chức năng bán hàng')
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT003', N'Nhân viên kho', N'Chỉ có quyền truy cập vào các chức năng quản lý kho')
GO
INSERT [dbo].[VaiTro] ([MaVaiTro], [TenVaiTro], [MoTa]) VALUES (N'VT004', N'Nhân viên chăm sóc khách hàng', N'Có vai trò truy cập vào các màn hình để kiểm tra quy trình chăm sóc khách hàng')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT001')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT002')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT003')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV001', N'VT004')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV002', N'VT002')
GO
INSERT [dbo].[NhanVien_VaiTro] ([MaNhanVien], [MaVaiTro]) VALUES (N'NV003', N'VT004')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q001', N'Lập hoá đơn', N'Xem màn hình lập hoá đơn')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q002', N'Lập thống kê báo cáo', N'Xem màn hình lập thống kê báo cáo')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q003', N'Lập phiếu kiểm kê', N'Quyền truy cập vào màn hình báo cáo')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q004', N'Lập đơn đặt hàng', N'Xem màn hình lập đơn đặt hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q005', N'Lâp phiếu đổi trả', N'Xem màn hình lập phiếu đổi trả')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q006', N'Quản lý hoá đơn', N'Xem màn hình quản lý hoá đơn')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q007', N'Quản lý đơn đặt hàng', N'Xem màn hình quản lý đơn đặt hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q008', N'Quản lý phiểu kiểm kê', N'Xem màn hình quản lý phiếu kiểm kê')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q009', N'Quản lý đổi trả sản phẩm', N'Xem màn hình quản lý đổi trả sản phẩm')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q010', N'Quản lý nhà cung cấp', N'Xem màn hình quản lý nhà cung cấp')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q011', N'Quản lý khách hàng', N'Xem màn hình quản lý khách hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q012', N'Quản lý kho hàng', N'Xem màn hình quản lý kho hàng')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q013', N'Quản lý nhân viên', N'Xem màn hình quản lý nhân viên')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q014', N'Quản lý hoàn sản phẩm', N'Xem màn hình quản lý hoàn sản phẩm')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q015', N'Quản lý chủng loại sản phẩm', N'Xem màn hình quản lý chủng loại sản phẩm')
GO
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (N'Q016', N'Quản lý phân quyền', N'Xem màn hình quản lý phân quyền')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q001')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q002')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q003')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q004')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q005')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q006')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q007')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q008')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q009')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q010')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q011')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q012')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q013')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q014')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q015')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT001', N'Q016')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q001')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q005')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q006')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q009')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q011')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT002', N'Q014')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q002')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q003')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q004')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q007')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q008')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q010')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q011')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q012')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q013')
GO
INSERT [dbo].[VaiTro_Quyen] ([MaVaiTro], [MaQuyen]) VALUES (N'VT003', N'Q015')
GO
