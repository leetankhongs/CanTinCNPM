GO
CREATE DATABASE QUANLYCANTIN

GO
USE QUANLYCANTIN

GO
Create table NhanVien(
	MaNV varchar(8) primary key not null,
	HoTen nvarchar(32),
	SDT varchar(11),
	DiaChi nvarchar(45),
	Luong int,
	Username varchar(30),
	Password varchar(100)
);

create table SanPham(
	MaSanPham varchar(7) primary key not null,
	TenSanPham nvarchar(50),
	LoaiSanPham varchar(5),
	ImgUrl varchar(100),
	Gia INT,
	YeuThich Bit,
	isDelete Bit
);

create table LoaiSanPham(
	MaLoaiSP varchar(5) primary key not null,
	TenLoaiSP nvarchar(32)
);

create table HoaDon(
	MaHoaDon varchar(8) primary key not null,
	STT INT,
	ThoiGian Datetime,
	TongTien INT,
	NhanVien varchar(8)
);

create table ChiTietHoaDon(
	MaHoaDon varchar(8) not null,
	MaSanPham varchar(7) not null,
	SL int,
	constraint PK_CTHoaDon primary key (MaHoaDon,MaSanPham)
);

create table ChiTietComBo(
	MaComBo varchar(5) not null,
	MaSanPham varchar(7) not null,
	constraint PK_CTComBo primary key (MaComBo,MaSanPham)
);

create table ComBo(
	MaComBo varchar(5) primary key not null,
	TenComBo nvarchar(50),
	GiaComBo INT
);

alter table SanPham add constraint FK_LoaiSanPham_SanPham foreign key (LoaiSanPham) references LoaiSanPham(MaLoaiSP);
alter table HoaDon add constraint FK_NhanVien_HoaDon foreign key (NhanVien) references NhanVien(MaNV);
alter table ChiTietHoaDon add constraint FK_HoaDon_ChiTietHoaDon foreign key (MaHoaDon) references HoaDon(MaHoaDon);
alter table ChiTietHoaDon add constraint FK_SanPham_ChiTietHoaDon foreign key (MaSanPham) references SanPham(MaSanPham);
alter table ChiTietComBo add constraint FK_ComBo_ChiTietComBo foreign key (MaComBo) references ComBo(MaComBo);
alter table ChiTietComBo add constraint FK_SanPham_ChiTietComBo foreign key (MaSanPham) references SanPham(MaSanPham);

GO
USE QUANLYCANTIN

GO
INSERT INTO LoaiSanPham(MaLoaiSP, TenLoaiSP)
VALUES('001', N'Thức ăn'),
('002', N'Nước uống')

GO
INSERT INTO SanPham(MaSanPham, TenSanPham, LoaiSanPham, ImgUrl, Gia, YeuThich, isDelete)
VALUES('001', N'Cơm chiên', '001', 'Images/comchien.jpeg', 25000, 1, 0),
('002', N'Cơm nấm', '001', 'Images/comnam.jpeg', 20000, 0, 0),
('003', 'Sting', '002', 'Images/sting.jpg', 12000, 0, 0),
('004', 'Coca', '002', 'Images/coca.jpg', 10000, 1, 0)

GO
INSERT INTO ComBo(MaComBo, TenComBo, GiaComBo)
VALUES('001', N'Cơm chiên + sting', 35000),
('002', N'Cơm nấm + coca', 30000)

GO
INSERT INTO NhanVien(MaNV, HoTen, SDT, DiaChi, Luong, Username, Password)
VALUES('001', N'Nguyễn Văn Nam', '0987654321', N'227 Nguyễn Văn Cừ, Q5, TPHCM', 10000000, 'nvnam', '1'),
('002', N'Trần Thị Thanh Trúc', '1234567890', N'135B Trần Hưng Đạo, Q1, TPHCM', 9000000, 'ttttruc', '123'),
('003', N'Võ Nguyễn Duy Mạnh', '0918273645', N'399 Xô Viết Nghệ Tĩnh, Q8, TPHCM', 12000000, 'vndmanh', '111')

GO
CREATE PROC Login
@userName nvarchar(30), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END