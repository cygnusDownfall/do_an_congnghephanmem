create database QLKS
go
use QLKS
go
create table DANGNHAP
(taikhoan nvarchar(20)not null primary key,
matkhau nvarchar(20))
go
create table KHACHHANG
(makhachhang nvarchar(20)not null primary key,
tenkhachhang nvarchar(50),
socmnd int,
ngaysinh date,
tuoi int,
gioitinh nvarchar(10),
sodienthoai int,
diachi nvarchar(50))
go
create table PHONG
(maphong nvarchar(20) not null primary key,
maloaiphong nvarchar(20),
dientich nvarchar(20),
tang nvarchar(50),
trangthai nvarchar(50))
go
create table PHIEUDATPHONG
(maphieudatphong nvarchar(20) not null primary key,
 makhachhang nvarchar(20),
 maphong nvarchar(20),
 ngaythue date,
 ngaytra date,
 songayo int,
 datcoc int,
 tonggiatrihopdong int,
 conlai nvarchar(50))
 go
 create table HOADON
 (mahoadon nvarchar(20) not null primary key,
 maphieudatphong nvarchar(20),
 tonghoadon int,
 ngaylaphoadon date)
 go
 create table LOAIPHONG
 (maloaiphong nvarchar(20)not null primary key,
 tenloaiphong nvarchar(50),
 giailoai int)
 

select *from PHONG
select *from PHIEUDATPHONG
select *from DANGNHAP
select *from KHACHHANG
select *from LOAIPHONG
select *from HOADON
