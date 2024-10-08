﻿USE [master]
GO
CREATE DATABASE [QuanLyQuanBilliard]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyQuanBilliard', FILENAME = N'D:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuanLyQuanBilliard.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyQuanBilliard_log', FILENAME = N'D:\SQL2019\MSSQL15.MSSQLSERVER\MSSQL\DATA\QuanLyQuanBilliard_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyQuanBilliard] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyQuanBilliard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyQuanBilliard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET RECOVERY FULL 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyQuanBilliard] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyQuanBilliard] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'QuanLyQuanBilliard', N'ON'
GO
ALTER DATABASE [QuanLyQuanBilliard] SET QUERY_STORE = OFF
GO
USE [QuanLyQuanBilliard]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bans]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bans](
	[BanId] [int] IDENTITY(1,1) NOT NULL,
	[TenBan] [nvarchar](100) NOT NULL,
	[TrangThai] [nvarchar](max) NOT NULL,
	[GiaGio] [bigint] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NgayCapNhap] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Bans] PRIMARY KEY CLUSTERED 
(
	[BanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDonChiTiets]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonChiTiets](
	[HoaDonChiTietId] [int] IDENTITY(1,1) NOT NULL,
	[HoaDonId] [int] NOT NULL,
	[IdKho] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaNhap] [bigint] NOT NULL,
	[GiaBan] [bigint] NOT NULL,
 CONSTRAINT [PK_HoaDonChiTiets] PRIMARY KEY CLUSTERED 
(
	[HoaDonChiTietId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDons]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDons](
	[HoaDonId] [int] IDENTITY(1,1) NOT NULL,
	[BanId] [int] NOT NULL,
	[NhanVienId] [int] NOT NULL,
	[TheThanhVienId] [int] NULL,
	[NgayLap] [datetime2](7) NOT NULL,
	[GioBatDau] [time](7) NOT NULL,
	[GioKetThuc] [time](7) NOT NULL,
	[GiaGio] [bigint] NOT NULL,
	[TongTien] [bigint] NOT NULL,
	[TrangThai] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_HoaDons] PRIMARY KEY CLUSTERED 
(
	[HoaDonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khos]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khos](
	[IdMatHang] [int] IDENTITY(1,1) NOT NULL,
	[TenMatHang] [nvarchar](100) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaNhap] [bigint] NOT NULL,
	[GiaBan] [bigint] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NgayCapNhap] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Khos] PRIMARY KEY CLUSTERED 
(
	[IdMatHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Luongs]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luongs](
	[LuongId] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienId] [int] NOT NULL,
	[Thang] [datetime2](7) NOT NULL,
	[LuongCoBan] [bigint] NOT NULL,
	[Thuong] [bigint] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NgayCapNhap] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Luongs] PRIMARY KEY CLUSTERED 
(
	[LuongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanViens]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanViens](
	[NhanVienId] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](60) NOT NULL,
	[NgaySinh] [datetime2](7) NOT NULL,
	[SoDienThoai] [nvarchar](10) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[ChucVu] [nvarchar](255) NOT NULL,
	[LuongCoBan] [bigint] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[NgayBatDauLam] [datetime2](7) NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NgayCapNhap] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_NhanViens] PRIMARY KEY CLUSTERED 
(
	[NhanVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoans]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoans](
	[TaiKhoanId] [int] IDENTITY(1,1) NOT NULL,
	[NhanVienId] [int] NOT NULL,
	[TenDangNhap] [nvarchar](100) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
	[TenQuyen] [nvarchar](255) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NgayCapNhap] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TaiKhoans] PRIMARY KEY CLUSTERED 
(
	[TaiKhoanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TheThanhViens]    Script Date: 10/8/2024 10:28:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TheThanhViens](
	[TheThanhVienId] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](255) NOT NULL,
	[SoDienThoai] [nvarchar](10) NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[NgayDangKy] [datetime2](7) NOT NULL,
	[NgayTao] [datetime2](7) NOT NULL,
	[NgayCapNhap] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TheThanhViens] PRIMARY KEY CLUSTERED 
(
	[TheThanhVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240930035341_InitialCreate', N'6.0.15')
GO
SET IDENTITY_INSERT [dbo].[Bans] ON 

INSERT [dbo].[Bans] ([BanId], [TenBan], [TrangThai], [GiaGio], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (1, N'Bàn 1', N'Trống', 50000, 0, CAST(N'2024-10-01T19:17:44.2266667' AS DateTime2), CAST(N'2024-10-01T19:17:44.2266667' AS DateTime2))
INSERT [dbo].[Bans] ([BanId], [TenBan], [TrangThai], [GiaGio], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (2, N'Bàn 2', N'Trống', 50000, 0, CAST(N'2024-10-01T22:45:03.3889098' AS DateTime2), CAST(N'2024-10-01T22:45:03.3897460' AS DateTime2))
INSERT [dbo].[Bans] ([BanId], [TenBan], [TrangThai], [GiaGio], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (3, N'Bàn 3', N'Đang sử dụng', 50000, 0, CAST(N'2024-10-01T19:17:44.2266667' AS DateTime2), CAST(N'2024-10-01T19:17:44.2266667' AS DateTime2))
INSERT [dbo].[Bans] ([BanId], [TenBan], [TrangThai], [GiaGio], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (4, N'Bàn Vip', N'Trống', 100000, 0, CAST(N'2024-10-01T22:47:10.0608998' AS DateTime2), CAST(N'2024-10-01T22:47:10.0609011' AS DateTime2))
INSERT [dbo].[Bans] ([BanId], [TenBan], [TrangThai], [GiaGio], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (1002, N'Bàn Vip10', N'Trống', 100000, 0, CAST(N'2024-10-03T09:31:01.7399603' AS DateTime2), CAST(N'2024-10-03T09:31:01.7399614' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Bans] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDonChiTiets] ON 

INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (1, 1, 1, 2, 20000, 30000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (2, 1, 2, 1, 15000, 25000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (3, 2, 3, 3, 50000, 70000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (4, 3, 4, 4, 9000, 20000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (5, 3, 5, 4, 8000, 18000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (6, 4, 4, 2, 9000, 20000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (7, 4, 6, 1, 9000, 20000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (1002, 1002, 4, 1, 9000, 20000)
INSERT [dbo].[HoaDonChiTiets] ([HoaDonChiTietId], [HoaDonId], [IdKho], [SoLuong], [GiaNhap], [GiaBan]) VALUES (1003, 1002, 5, 1, 8000, 18000)
SET IDENTITY_INSERT [dbo].[HoaDonChiTiets] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDons] ON 

INSERT [dbo].[HoaDons] ([HoaDonId], [BanId], [NhanVienId], [TheThanhVienId], [NgayLap], [GioBatDau], [GioKetThuc], [GiaGio], [TongTien], [TrangThai]) VALUES (1, 1, 1, NULL, CAST(N'2024-10-01T19:17:44.4100000' AS DateTime2), CAST(N'10:00:00' AS Time), CAST(N'12:00:00' AS Time), 50000, 100000, N'Đã thanh toán')
INSERT [dbo].[HoaDons] ([HoaDonId], [BanId], [NhanVienId], [TheThanhVienId], [NgayLap], [GioBatDau], [GioKetThuc], [GiaGio], [TongTien], [TrangThai]) VALUES (2, 2, 2, 1, CAST(N'2024-10-01T19:17:44.4100000' AS DateTime2), CAST(N'14:00:00' AS Time), CAST(N'15:00:00' AS Time), 50000, 150000, N'Đã thanh toán')
INSERT [dbo].[HoaDons] ([HoaDonId], [BanId], [NhanVienId], [TheThanhVienId], [NgayLap], [GioBatDau], [GioKetThuc], [GiaGio], [TongTien], [TrangThai]) VALUES (3, 1, 1, 1, CAST(N'2024-10-01T22:46:04.8728682' AS DateTime2), CAST(N'00:00:00' AS Time), CAST(N'01:00:00' AS Time), 50000, 202000, N'Đã thanh toán')
INSERT [dbo].[HoaDons] ([HoaDonId], [BanId], [NhanVienId], [TheThanhVienId], [NgayLap], [GioBatDau], [GioKetThuc], [GiaGio], [TongTien], [TrangThai]) VALUES (4, 1, 1, 1, CAST(N'2024-10-02T01:24:12.2783809' AS DateTime2), CAST(N'13:00:00' AS Time), CAST(N'15:00:00' AS Time), 50000, 160000, N'Đã thanh toán')
INSERT [dbo].[HoaDons] ([HoaDonId], [BanId], [NhanVienId], [TheThanhVienId], [NgayLap], [GioBatDau], [GioKetThuc], [GiaGio], [TongTien], [TrangThai]) VALUES (1002, 3, 1, NULL, CAST(N'2024-10-03T09:30:16.4447055' AS DateTime2), CAST(N'00:00:00' AS Time), CAST(N'00:00:00' AS Time), 50000, 38000, N'Chưa thanh toán')
SET IDENTITY_INSERT [dbo].[HoaDons] OFF
GO
SET IDENTITY_INSERT [dbo].[Khos] ON 

INSERT [dbo].[Khos] ([IdMatHang], [TenMatHang], [SoLuong], [GiaNhap], [GiaBan], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (1, N'Bóng billiard', 100, 20000, 30000, 0, CAST(N'2024-10-01T19:17:44.3033333' AS DateTime2), CAST(N'2024-10-01T19:17:44.3033333' AS DateTime2))
INSERT [dbo].[Khos] ([IdMatHang], [TenMatHang], [SoLuong], [GiaNhap], [GiaBan], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (2, N'Que đánh billiard', 50, 15000, 25000, 1, CAST(N'2024-10-01T22:44:18.5256593' AS DateTime2), CAST(N'2024-10-01T22:44:18.5280377' AS DateTime2))
INSERT [dbo].[Khos] ([IdMatHang], [TenMatHang], [SoLuong], [GiaNhap], [GiaBan], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (3, N'Bàn thắng', 20, 50000, 70000, 1, CAST(N'2024-10-01T22:44:23.4518266' AS DateTime2), CAST(N'2024-10-01T22:44:23.4519511' AS DateTime2))
INSERT [dbo].[Khos] ([IdMatHang], [TenMatHang], [SoLuong], [GiaNhap], [GiaBan], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (4, N'Sting', 43, 9000, 20000, 0, CAST(N'2024-10-01T22:44:45.2444621' AS DateTime2), CAST(N'2024-10-01T22:44:45.2444628' AS DateTime2))
INSERT [dbo].[Khos] ([IdMatHang], [TenMatHang], [SoLuong], [GiaNhap], [GiaBan], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (5, N'Pepsi', 55, 8000, 18000, 0, CAST(N'2024-10-01T22:44:56.6821330' AS DateTime2), CAST(N'2024-10-01T22:44:56.6821337' AS DateTime2))
INSERT [dbo].[Khos] ([IdMatHang], [TenMatHang], [SoLuong], [GiaNhap], [GiaBan], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (6, N'CocaCola', 49, 9000, 20000, 0, CAST(N'2024-10-01T22:46:28.6808942' AS DateTime2), CAST(N'2024-10-01T22:46:28.6808951' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Khos] OFF
GO
SET IDENTITY_INSERT [dbo].[Luongs] ON 

INSERT [dbo].[Luongs] ([LuongId], [NhanVienId], [Thang], [LuongCoBan], [Thuong], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (1, 1, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), 3000000, 500000, 0, CAST(N'2024-10-01T19:17:44.6133333' AS DateTime2), CAST(N'2024-10-01T19:17:44.6133333' AS DateTime2))
INSERT [dbo].[Luongs] ([LuongId], [NhanVienId], [Thang], [LuongCoBan], [Thuong], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (2, 2, CAST(N'2024-01-01T00:00:00.0000000' AS DateTime2), 5000000, 1000000, 0, CAST(N'2024-10-01T19:17:44.6133333' AS DateTime2), CAST(N'2024-10-01T19:17:44.6133333' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Luongs] OFF
GO
SET IDENTITY_INSERT [dbo].[NhanViens] ON 

INSERT [dbo].[NhanViens] ([NhanVienId], [TenNhanVien], [NgaySinh], [SoDienThoai], [Email], [ChucVu], [LuongCoBan], [IsDelete], [NgayBatDauLam], [NgayTao], [NgayCapNhap]) VALUES (1, N'Nguyễn Văn A', CAST(N'1990-01-01T00:00:00.0000000' AS DateTime2), N'0123456789', N'a@example.com', N'Nhân viên', 3000000, 0, CAST(N'2024-10-01T19:17:44.3266667' AS DateTime2), CAST(N'2024-10-01T19:17:44.3266667' AS DateTime2), CAST(N'2024-10-01T19:17:44.3266667' AS DateTime2))
INSERT [dbo].[NhanViens] ([NhanVienId], [TenNhanVien], [NgaySinh], [SoDienThoai], [Email], [ChucVu], [LuongCoBan], [IsDelete], [NgayBatDauLam], [NgayTao], [NgayCapNhap]) VALUES (2, N'Trần Thị B', CAST(N'1992-02-02T00:00:00.0000000' AS DateTime2), N'0987654321', N'b@example.com', N'Quản lý', 5000000, 0, CAST(N'2024-10-01T19:17:44.3266667' AS DateTime2), CAST(N'2024-10-01T19:17:44.3266667' AS DateTime2), CAST(N'2024-10-01T19:17:44.3266667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[NhanViens] OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoans] ON 

INSERT [dbo].[TaiKhoans] ([TaiKhoanId], [NhanVienId], [TenDangNhap], [MatKhau], [TenQuyen], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (1, 1, N'admin', N'AQAAAAEAACcQAAAAEKlKvG3pE8/uZ2aUNYgYJNKuaOxplMlipt/znaWGvrtnOfvdvew9okXdO7O8LFuvmw==', N'Quản Lý', 0, CAST(N'2024-10-01T19:17:44.3400000' AS DateTime2), CAST(N'2024-10-01T19:17:44.3400000' AS DateTime2))
INSERT [dbo].[TaiKhoans] ([TaiKhoanId], [NhanVienId], [TenDangNhap], [MatKhau], [TenQuyen], [IsDelete], [NgayTao], [NgayCapNhap]) VALUES (2, 2, N'user', N'AQAAAAEAACcQAAAAEKlKvG3pE8/uZ2aUNYgYJNKuaOxplMlipt/znaWGvrtnOfvdvew9okXdO7O8LFuvmw==', N'Tiếp Tân', 0, CAST(N'2024-10-01T19:17:44.3400000' AS DateTime2), CAST(N'2024-10-01T19:17:44.3400000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TaiKhoans] OFF
GO
SET IDENTITY_INSERT [dbo].[TheThanhViens] ON 

INSERT [dbo].[TheThanhViens] ([TheThanhVienId], [TenKhachHang], [SoDienThoai], [IsDelete], [NgayDangKy], [NgayTao], [NgayCapNhap]) VALUES (1, N'Khách hàng 1', N'0123456789', 0, CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-01T19:17:44.3866667' AS DateTime2), CAST(N'2024-10-01T19:17:44.3866667' AS DateTime2))
INSERT [dbo].[TheThanhViens] ([TheThanhVienId], [TenKhachHang], [SoDienThoai], [IsDelete], [NgayDangKy], [NgayTao], [NgayCapNhap]) VALUES (2, N'Khách hàng 2', N'0987654321', 0, CAST(N'2021-02-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-10-01T19:17:44.3866667' AS DateTime2), CAST(N'2024-10-01T19:17:44.3866667' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TheThanhViens] OFF
GO
/****** Object:  Index [IX_HoaDonChiTiets_HoaDonId]    Script Date: 10/8/2024 10:28:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonChiTiets_HoaDonId] ON [dbo].[HoaDonChiTiets]
(
	[HoaDonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDonChiTiets_IdKho]    Script Date: 10/8/2024 10:28:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDonChiTiets_IdKho] ON [dbo].[HoaDonChiTiets]
(
	[IdKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDons_BanId]    Script Date: 10/8/2024 10:28:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDons_BanId] ON [dbo].[HoaDons]
(
	[BanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDons_NhanVienId]    Script Date: 10/8/2024 10:28:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDons_NhanVienId] ON [dbo].[HoaDons]
(
	[NhanVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_HoaDons_TheThanhVienId]    Script Date: 10/8/2024 10:28:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_HoaDons_TheThanhVienId] ON [dbo].[HoaDons]
(
	[TheThanhVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Luongs_NhanVienId]    Script Date: 10/8/2024 10:28:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_Luongs_NhanVienId] ON [dbo].[Luongs]
(
	[NhanVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TaiKhoans_NhanVienId]    Script Date: 10/8/2024 10:28:10 PM ******/
CREATE NONCLUSTERED INDEX [IX_TaiKhoans_NhanVienId] ON [dbo].[TaiKhoans]
(
	[NhanVienId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HoaDonChiTiets]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiets_HoaDons_HoaDonId] FOREIGN KEY([HoaDonId])
REFERENCES [dbo].[HoaDons] ([HoaDonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonChiTiets] CHECK CONSTRAINT [FK_HoaDonChiTiets_HoaDons_HoaDonId]
GO
ALTER TABLE [dbo].[HoaDonChiTiets]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiets_Khos_IdKho] FOREIGN KEY([IdKho])
REFERENCES [dbo].[Khos] ([IdMatHang])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonChiTiets] CHECK CONSTRAINT [FK_HoaDonChiTiets_Khos_IdKho]
GO
ALTER TABLE [dbo].[HoaDons]  WITH CHECK ADD  CONSTRAINT [FK_HoaDons_Bans_BanId] FOREIGN KEY([BanId])
REFERENCES [dbo].[Bans] ([BanId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDons] CHECK CONSTRAINT [FK_HoaDons_Bans_BanId]
GO
ALTER TABLE [dbo].[HoaDons]  WITH CHECK ADD  CONSTRAINT [FK_HoaDons_NhanViens_NhanVienId] FOREIGN KEY([NhanVienId])
REFERENCES [dbo].[NhanViens] ([NhanVienId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDons] CHECK CONSTRAINT [FK_HoaDons_NhanViens_NhanVienId]
GO
ALTER TABLE [dbo].[HoaDons]  WITH CHECK ADD  CONSTRAINT [FK_HoaDons_TheThanhViens_TheThanhVienId] FOREIGN KEY([TheThanhVienId])
REFERENCES [dbo].[TheThanhViens] ([TheThanhVienId])
GO
ALTER TABLE [dbo].[HoaDons] CHECK CONSTRAINT [FK_HoaDons_TheThanhViens_TheThanhVienId]
GO
ALTER TABLE [dbo].[Luongs]  WITH CHECK ADD  CONSTRAINT [FK_Luongs_NhanViens_NhanVienId] FOREIGN KEY([NhanVienId])
REFERENCES [dbo].[NhanViens] ([NhanVienId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Luongs] CHECK CONSTRAINT [FK_Luongs_NhanViens_NhanVienId]
GO
ALTER TABLE [dbo].[TaiKhoans]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoans_NhanViens_NhanVienId] FOREIGN KEY([NhanVienId])
REFERENCES [dbo].[NhanViens] ([NhanVienId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoans] CHECK CONSTRAINT [FK_TaiKhoans_NhanViens_NhanVienId]
GO
USE [master]
GO
ALTER DATABASE [QuanLyQuanBilliard] SET  READ_WRITE 
GO
