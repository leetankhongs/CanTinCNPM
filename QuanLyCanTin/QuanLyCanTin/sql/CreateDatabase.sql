create database QuanLyCanTin;
Use QuanLyCanTin;

Create table NhanVien(
	MaNV varchar(8) primary key not null,
	HoTen varchar(32),
	SDT varchar(11),
	DiaChi varchar(45),
	Luong Int
);

create table SanPham(
	MaSanPham varchar(7) primary key not null,
	TenSanPham varchar(50),
	LoaiSanPham varchar(5),
	ImgUrl varchar(100),
	Gia INT,
	YeuThich Bit,
	isDelete Bit
);

create table LoaiSanPham(
	MaLoaiSP varchar(5) primary key not null,
	TenLoaiSP varchar(32)
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
	TenComBo varchar(50),
	GiaComBo INT
);

alter table SanPham add constraint FK_LoaiSanPham_SanPham foreign key (LoaiSanPham) references LoaiSanPham(MaLoaiSP);
alter table HoaDon add constraint FK_NhanVien_HoaDon foreign key (NhanVien) references NhanVien(MaNV);
alter table ChiTietHoaDon add constraint FK_HoaDon_ChiTietHoaDon foreign key (MaHoaDon) references HoaDon(MaHoaDon);
alter table ChiTietHoaDon add constraint FK_SanPham_ChiTietHoaDon foreign key (MaSanPham) references SanPham(MaSanPham);
alter table ChiTietComBo add constraint FK_ComBo_ChiTietComBo foreign key (MaComBo) references ComBo(MaComBo);
alter table ChiTietComBo add constraint FK_SanPham_ChiTietComBo foreign key (MaSanPham) references SanPham(MaSanPham);
