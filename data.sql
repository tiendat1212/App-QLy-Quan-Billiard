-- Nhập dữ liệu vào bảng Ban
INSERT INTO Bans (TenBan, TrangThai, GiaGio, IsDelete, NgayTao, NgayCapNhap) VALUES
(N'Bàn 1', N'Trống', 50000, 0, GETDATE(), GETDATE()),
(N'Bàn 2', N'Đang sử dụng', 50000, 0, GETDATE(), GETDATE()),
(N'Bàn 3', N'Trống', 50000, 0, GETDATE(), GETDATE());

-- Nhập dữ liệu vào bảng Kho
INSERT INTO Khos (TenMatHang, SoLuong, GiaNhap, GiaBan, IsDelete, NgayTao, NgayCapNhap) VALUES
(N'Bóng billiard', 100, 20000, 30000, 0, GETDATE(), GETDATE()),
(N'Que đánh billiard', 50, 15000, 25000, 0, GETDATE(), GETDATE()),
(N'Bàn thắng', 20, 50000, 70000, 0, GETDATE(), GETDATE());

-- Nhập dữ liệu vào bảng NhanVien
INSERT INTO NhanViens (TenNhanVien, NgaySinh, SoDienThoai, Email, ChucVu, LuongCoBan, IsDelete, NgayBatDauLam, NgayTao, NgayCapNhap) VALUES
(N'Nguyễn Văn A', '1990-01-01', '0123456789', 'a@example.com', N'Nhân viên', 3000000, 0, GETDATE(), GETDATE(), GETDATE()),
(N'Trần Thị B', '1992-02-02', '0987654321', 'b@example.com', N'Quản lý', 5000000, 0, GETDATE(), GETDATE(), GETDATE());

-- Nhập dữ liệu vào bảng TaiKhoan
INSERT INTO TaiKhoans (NhanVienId, TenDangNhap, MatKhau, TenQuyen, IsDelete, NgayTao, NgayCapNhap) VALUES
(1, 'admin', 'AQAAAAEAACcQAAAAEKlKvG3pE8/uZ2aUNYgYJNKuaOxplMlipt/znaWGvrtnOfvdvew9okXdO7O8LFuvmw==', N'Quản Lý', 0, GETDATE(), GETDATE()),
(2, 'user', 'AQAAAAEAACcQAAAAEKlKvG3pE8/uZ2aUNYgYJNKuaOxplMlipt/znaWGvrtnOfvdvew9okXdO7O8LFuvmw==', N'Tiếp Tân', 0, GETDATE(), GETDATE());

-- Nhập dữ liệu vào bảng TheThanhVien
INSERT INTO TheThanhViens (TenKhachHang, SoDienThoai, IsDelete, NgayDangKy, NgayTao, NgayCapNhap) VALUES
(N'Khách hàng 1', '0123456789', 0, '2021-01-01', GETDATE(), GETDATE()),
(N'Khách hàng 2', '0987654321', 0, '2021-02-01', GETDATE(), GETDATE());

-- Nhập dữ liệu vào bảng HoaDon
INSERT INTO HoaDons (BanId, NhanVienId, TheThanhVienId, NgayLap, GioBatDau, GioKetThuc, GiaGio, TongTien, TrangThai) VALUES
(1, 1, NULL, GETDATE(), '10:00:00', '12:00:00', 50000, 100000, N'Đã thanh toán'),
(2, 2, 1, GETDATE(), '14:00:00', '15:00:00', 50000, 150000, N'Chưa thanh toán');

-- Nhập dữ liệu vào bảng HoaDonChiTiet
INSERT INTO HoaDonChiTiets (HoaDonId, IdKho, SoLuong, GiaNhap, GiaBan) VALUES
(1, 1, 2, 20000, 30000),
(1, 2, 1, 15000, 25000),
(2, 3, 3, 50000, 70000);

-- Nhập dữ liệu vào bảng Luong
INSERT INTO Luongs (NhanVienId, Thang, LuongCoBan, Thuong, IsDelete, NgayTao, NgayCapNhap) VALUES
(1, '2024-01-01', 3000000, 500000, 0, GETDATE(), GETDATE()),
(2, '2024-01-01', 5000000, 1000000, 0, GETDATE(), GETDATE());