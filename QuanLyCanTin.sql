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
	Luong Int
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

INSERT INTO LoaiSanPham(MaLoaiSP, TenLoaiSP)
VALUES('001', N'Thức ăn'),
('002', N'Nước uống')

INSERT INTO SanPham(MaSanPham, TenSanPham, LoaiSanPham, ImgUrl, Gia, YeuThich, isDelete)
VALUES('001', N'Cơm chiên', '001', 'Images/comchien.jpeg', 25000, 1, 0),
('002', N'Cơm nấm', '001', 'Images/comnam.jpeg', 20000, 0, 0),
('003', 'Sting', '002', 'Images/sting.jpg', 12000, 0, 0),
('004', 'Coca', '002', 'Images/coca.jpg', 10000, 1, 0)
