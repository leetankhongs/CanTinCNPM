GO
CREATE DATABASE QUANLYCANTIN

GO
USE QUANLYCANTIN

GO
Create table NhanVien(
	MaNV nvarchar(8) primary key not null,
	HoTen nvarchar(32),
	SDT varchar(11),
	DiaChi nvarchar(100),
	Luong int,
	Username varchar(30),
	Password varchar(100)
);


create table SanPham(
	MaSanPham nvarchar(7) primary key not null,
	TenSanPham nvarchar(50),
	LoaiSanPham nvarchar(5),
	IMGUrl nvarchar(100),
	Gia INT,
	YeuThich Bit,
	isDelete Bit
);

create table LoaiSanPham(
	MaLoaiSP nvarchar(5) primary key not null,
	TenLoaiSP nvarchar(32)
);

create table HoaDon(
	MaHoaDon nvarchar(8) primary key not null,
	STT INT,
	ThoiGian Datetime,
	TongTien INT,
	NhanVien nvarchar(8)
);

create table ChiTietHoaDon(
	MaHoaDon nvarchar(8) not null,
	MaSanPham nvarchar(7) not null,
	SL int,
	constraint PK_CTHoaDon primary key (MaHoaDon,MaSanPham)
);

create table ChiTietComBo(
	MaComBo nvarchar(5) not null,
	MaSanPham nvarchar(7) not null,
	constraint PK_CTComBo primary key (MaComBo,MaSanPham)
);

create table ComBo(
	MaComBo nvarchar(5) primary key not null,
	TenComBo nvarchar(50),
	GiaComBo INT
);

alter table SanPham add constraint FK_LoaiSanPham_SanPham foreign key (LoaiSanPham) references LoaiSanPham(MaLoaiSP);
alter table HoaDon add constraint FK_NhanVien_HoaDon foreign key (NhanVien) references NhanVien(MaNV);
alter table ChiTietHoaDon add constraint FK_HoaDon_ChiTietHoaDon foreign key (MaHoaDon) references HoaDon(MaHoaDon);
alter table ChiTietHoaDon add constraint FK_SanPham_ChiTietHoaDon foreign key (MaSanPham) references SanPham(MaSanPham);
alter table ChiTietComBo add constraint FK_ComBo_ChiTietComBo foreign key (MaComBo) references ComBo(MaComBo);
alter table ChiTietComBo add constraint FK_SanPham_ChiTietComBo foreign key (MaSanPham) references SanPham(MaSanPham);


INSERT INTO LoaiSanPham VALUES
	('001', N'Thức ăn'),
	('002', N'Nước uống')


Insert into NhanVien Values 
	('NV000001',N'Lê Tấn Hưng','0963214587',N'135b Đường Trần Hưng Đạo, Phường Cầu Ông Lãnh, Quận 1, Hồ Chí Minh',5600000,'hung123','135207232157214230604222416262062047659100'),
	('NV000002',N'Lê Đào Nhật Thiện','0985214578',N'85 Đường Trần Hưng Đạo, Phường 7, Quận 5, Hồ Chí Minh',5600000,'thien123','17225219213317312114413020817024919615117311062'),
	('NV000003',N'Bùi Đỗ Huy','0932154754',N'12 Trường Chinh,Phường 12, Tân Bình, Hồ Chí Minh',5400000,'huy123','1842204451402472222391762361063876147112'),
	('NV000004',N'Phan Thị Hường','0912358746',N'36 Cao Thắng, phường 5, Quận 3, Hồ Chí Minh',6200000,'huong123','892368913123015218413019317961914621613589'),
	('NV000005',N'Nguyễn Thị Hồng','0952147584',N'25 Phạm Văn Đồng, Phường 3, Gò Vấp, Hồ Chí Minh',5800000,'hong123','18624120810420721715714914715272791751761622');

Insert into SanPham values
	('SP00001',N'Cơm tự chọn loại 1','001','Images/comchien.jpeg',20000,1,0),
	('SP00002',N'Cơm tự chọn loại 2','001','Images/comnam.jpeg',25000,1,0),
	('SP00003',N'Mì Spaghetti','001','Images/spaghetti.jpg',25000,1,0),
	('SP00004',N'Hủ tiếu','001','Images/hutieu.jpg',25000,0,0),
	('SP00005',N'Sting','002','Images/sting.jpg',10000,1,0),
	('SP00006',N'Pepsi','002','Images/pepsi.jpg',8000,0,0),
	('SP00007',N'Nước lọc','002','Images/nuocloc.jpg',5000,0,0),
	('SP00008',N'Nước mía','002','Images/nuocmia.jpg',6000,0,0),
	('SP00009',N'Bún bò Huế','001','Images/bunbo.jpg',30000,0,0),
	('SP00010',N'Bánh Canh','001','Images/banhcanh.jpg',25000,0,0),
	('SP00011',N'Bún gạo','001','Images/bungao.jpg',25000,0,0),
	('SP00012',N'Mì gói thịt bò','001','Images/migoi.jpg',30000,1,0),
	('SP00013',N'Bánh mì ốp la','001','Images/banhmi.jpg',15000,0,0),
	('SP00014',N'Sâm dứa','002','Images/samdua.jpg',7000,0,0),
	('SP00015',N'Nước cà rốt ép','002','Images/carotep.jpg',15000,0,0),
	('SP00016',N'Sâm dứa sữa','002','Images/samduasua.jpg',9000,0,0),
	('SP00017',N'Chanh dây','002','Images/chanhday.jpg',6000,1,0),
	('SP00018',N'Chanh muối','002','Images/chanhmuoi.jpg',6000,0,0),
	('SP00019',N'Nước đá me','002','Images/dame.jpg',6000,0,0),
	('SP00020',N'Sâm bổ lượng','002','Images/samboluong.jpg',6000,0,0),
	('SP00021',N'Siro sữa','002','Images/sirosua.jpg',9000,0,0),
	('SP00022',N'Nước bưởi ép','002','Images/buoiep.jpg',18000,0,0),
	('SP00023',N'Thơm ép','002','Images/thomep.jpg',15000,0,0),
	('SP00024',N'Sữa chua đá đường','002','Images/suachua.jpg',8000,0,0),
	('SP00025',N'Rau má đậu xanh','002','Images/rauma.jpg',6000,1,0);

Insert into HoaDon values
	('HD000001',1,convert(datetime,'11:5 20/11/2019',103),25000,'NV000005'),
	('HD000002',2,convert(datetime,'11:11 20/11/2019',103),35000,'NV000005'),
	('HD000003',3,convert(datetime,'11:12 20/11/2019',103),25000,'NV000005'),
	('HD000004',4,convert(datetime,'11:20 20/11/2019',103),20000,'NV000005'),
	('HD000005',5,convert(datetime,'11:22 20/11/2019',103),30000,'NV000005'),
	('HD000006',6,convert(datetime,'11:30 20/11/2019',103),25000,'NV000005'),
	('HD000007',7,convert(datetime,'11:33 20/11/2019',103),25000,'NV000005'),
	('HD000008',8,convert(datetime,'11:43 20/11/2019',103),31000,'NV000005'),
	('HD000009',9,convert(datetime,'11:51 20/11/2019',103),10000,'NV000005'),
	('HD000010',10,convert(datetime,'12:12 20/11/2019',103),5000,'NV000005'),
	('HD000011',11,convert(datetime,'9:32 21/11/2019',103),22000,'NV000001'),
	('HD000012',12,convert(datetime,'9:40 21/11/2019',103),18000,'NV000001'),
	('HD000013',13,convert(datetime,'19:53 21/11/2019',103),36000,'NV000001'),
	('HD000014',14,convert(datetime,'11:15 21/11/2019',103),30000,'NV000001'),
	('HD000015',15,convert(datetime,'11:25 21/11/2019',103),34000,'NV000001'),
	('HD000016',16,convert(datetime,'11:32 21/11/2019',103),31000,'NV000001'),
	('HD000017',17,convert(datetime,'11:35 21/11/2019',103),25000,'NV000001'),
	('HD000018',18,convert(datetime,'11:41 21/11/2019',103),15000,'NV000001'),
	('HD000019',19,convert(datetime,'11:45 21/11/2019',103),20000,'NV000001'),
	('HD000020',20,convert(datetime,'12:00 21/11/2019',103),25000,'NV000001'),
	('HD000021',21,convert(datetime,'9:20 22/11/2019',103),6000,'NV000002'),
	('HD000022',22,convert(datetime,'19:10 22/11/2019',103),15000,'NV000002'),
	('HD000023',23,convert(datetime,'11:20 22/11/2019',103),39000,'NV000002'),
	('HD000024',24,convert(datetime,'11:22 22/11/2019',103),35000,'NV000002'),
	('HD000025',25,convert(datetime,'11:35 22/11/2019',103),40000,'NV000002'),
	('HD000026',26,convert(datetime,'11:44 22/11/2019',103),48000,'NV000002');

Insert into ChiTietHoaDon values
	('HD000001','SP00002',1),
	('HD000001','SP00007',1),
	('HD000002','SP00002',1),
	('HD000002','SP00005',1),
	('HD000003','SP00002',1),
	('HD000004','SP00001',1),
	('HD000005','SP00002',1),
	('HD000005','SP00007',1),
	('HD000006','SP00002',1),
	('HD000007','SP00001',1),
	('HD000007','SP00007',1),
	('HD000008','SP00002',1),
	('HD000008','SP00005',1),
	('HD000009','SP00007',2),
	('HD000010','SP00007',1),
	('HD000011','SP00013',1),
	('HD000011','SP00014',1),
	('HD000012','SP00022',1),
	('HD000013','SP00009',1),
	('HD000013','SP00017',1),
	('HD000014','SP00003',1),
	('HD000014','SP00007',1),
	('HD000015','SP00010',1),
	('HD000015','SP00021',1),
	('HD000016','SP00002',1),
	('HD000016','SP00008',1),
	('HD000017','SP00002',1),
	('HD000018','SP00023',1),
	('HD000019','SP00001',1),
	('HD000020','SP00011',1),
	('HD000021','SP00025',1),
	('HD000022','SP00015',1),
	('HD000023','SP00009',1),
	('HD000023','SP00016',1),
	('HD000024','SP00012',1),
	('HD000024','SP00007',1),
	('HD000025','SP00004',1),
	('HD000025','SP00015',1),
	('HD000026','SP00009',1),
	('HD000026','SP00022',1);

Insert into ComBo values
	('CB001',N'Spaghetti + Sting',35000),
	('CB002',N'Cơm tự chọn loại 1 + Nước mía',26000),
	('CB003',N'Hủ tiếu + Pepsi',33000);

Insert into ChiTietComBo values
	('CB001','SP00003'),
	('CB001','SP00005'),
	('CB002','SP00001'),
	('CB002','SP00008'),
	('CB003','SP00004'),
	('CB003','SP00006');

-----------------------------------------------------
GO
IF(OBJECT_ID('Login', 'P') IS NOT NULL)
	DROP PROC Login
GO
CREATE PROC Login
	@userName nvarchar(30),
	@passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM NhanVien WHERE Username = @username AND Password = @password
END

----------------------------------------------
GO
IF(OBJECT_ID('insertBill', 'P') IS NOT NULL)
	DROP PROC insertBill
GO
CREATE PROC insertBill
	@id nvarchar(8),
	@stt int,
	@dateTime DateTime,
	@total int,
	@account nvarchar(8)
AS
BEGIN
	INSERT INTO HoaDon (MaHoaDon, STT, ThoiGian, TongTien, NhanVien)
	VALUES(@id, @stt, @dateTime, @total, @account)
END

--------------------------------------------------
GO
IF(OBJECT_ID('insertBillInfo', 'P') IS NOT NULL)
	DROP PROC insertBillInfo
GO
CREATE PROC insertBillInfo
	@billID nvarchar(8),
	@productID nvarchar(8),
	@sl int
AS
BEGIN
	INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SL)
	VALUES(@billID, @productID, @sl)
END

---------------------------------------------------------
GO
IF(OBJECT_ID('getAccountIDByUsername', 'P') IS NOT NULL)
	DROP PROC getAccountIDByUsername
GO
CREATE PROC getAccountIDByUsername
	@username varchar(30)
AS
BEGIN
	SELECT MaNV FROM NhanVien WHERE Username = @username
END
