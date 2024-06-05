
create table Lich_lam_viec
(
	Ma_ca_lam nvarchar(20) not null ,
    Ngay_lam_viec date,
    Ca int,
	constraint pk_lich primary key (Ma_ca_lam) 
)
create table Nhan_vien_Lich_lam_viec
	(
		Ma_nhan_vien nvarchar(20) not null,
		Ma_ca_lam    nvarchar(20) not null ,
		mota         nvarchar(100),
		constraint pk_key primary key (Ma_nhan_vien,Ma_ca_lam) ,
		constraint fk_key  foreign key (Ma_ca_lam) references Lich_lam_viec(Ma_ca_lam) on update cascade on delete cascade ,
		constraint fk_key1  foreign key (Ma_nhan_vien) references Nhan_vien(Ma_nhan_vien) on update cascade on delete cascade 
	)
create table Nhan_vien (
		Ma_nhan_vien nvarchar(20) ,
		Ten_nhan_vien nvarchar(30),
		SDT int ,
		Email varchar(20),
		Chuc_vu varchar(20),
		Ngay_tuyen_dung date,
		constraint pk_nv primary key (Ma_nhan_vien) 
		)
create table Lich_hen(
  Ma_lich_hen nvarchar(20) not null ,
  Ma_khach_hang nvarchar(20),
  Ma_nhan_vien nvarchar(20),
  Ma_dich_vu nvarchar(20),
  Lich_hen date,
  Ghi_chu nvarchar(40),
  constraint pk_lichhen primary key (Ma_lich_hen),
  constraint fk_kh2      foreign key (Ma_khach_hang) references Khach_hang(Ma_khach_hang) on update cascade on delete cascade ,
  constraint fk_nv      foreign key (Ma_nhan_vien) references Nhan_vien(Ma_nhan_vien) on update cascade on delete cascade ,
  constraint fk_dv      foreign key (Ma_dich_vu) references Dich_vu(Ma_dich_vu) on update cascade on delete cascade 
  )
  create table Dich_vu(
	 Ma_dich_vu nvarchar(20) not null,
	Ten_dich_vu nvarchar(50),
	Gia_dich_vu int,
	constraint pk_dv primary key (Ma_dich_vu)  
	)
	create table San_pham
	(
	Ma_san_pham nvarchar(20) Primary key,
	Ten_san_pham  nvarchar(30),
	Gia_san_pham int,
	So_luong int,
	Mo_ta nvarchar(100)
	)
	create table Chi_tiet_hoa_don_San_pham 
	(
	 Ma_san_pham nvarchar(20) ,
	 Ma_hoa_don nvarchar(20),
	 Mo_ta nvarchar(100) ,
	 constraint pk_sphd primary key(Ma_hoa_don, Ma_san_pham),
	 constraint fk_hd3 foreign key (Ma_hoa_don) references Chi_tiet_hoa_don(Ma_hoa_don) on update cascade on delete cascade,
	 constraint fk_sp4 foreign key (Ma_san_pham) references San_pham(Ma_san_pham)  
	 )
	 create table Chi_tiet_hoa_don_Dich_vu 
	 (
	 Ma_dich_vu nvarchar(20) not null,
	 Ma_hoa_don nvarchar(20) not null,
	 Mo_ta nvarchar(100) ,
	 constraint pk_ct primary key (Ma_hoa_don, Ma_dich_vu) ,
	  constraint fk_hd foreign key (Ma_hoa_don) references Chi_tiet_hoa_don(Ma_hoa_don)  on update cascade on delete cascade,
	  constraint fk_dv8 foreign key (Ma_dich_vu) references Dich_vu(Ma_dich_vu)  on update cascade on delete cascade
	  )
	  create table Khach_hang 
	  (
	    Ma_khach_hang nvarchar(20),
		Ten_khach_hang nvarchar(50),
		SDT int ,
		Email nvarchar(40),
		Dia_chi nvarchar(40),
		constraint pk_kh primary key (Ma_khach_hang) 
		)
		create table Phan_hoi
		(
	      Ma_phan_hoi nvarchar(20),
		  Ma_khach_hang nvarchar(20),
		  Danh_gia   nvarchar(50),
		  Binh_luan  nvarchar(50),
		  constraint pk_ph primary key (Ma_phan_hoi),
		  constraint fk_kh foreign key (Ma_khach_hang) references Khach_hang(Ma_khach_hang)  on update cascade on delete cascade
		  )
		  create table Quan_ly
		  (
		   Ma_nguoi_quan_ly nvarchar(20) primary key,
		  Ten_nguoi_quan_ly nvarchar(30),
		  SDT nvarchar(12) ,
		  Email nvarchar(30),
	      Dia_chi nvarchar(100)
		  )
		  create table Chi_tiet_hoa_don 
		  (
		 Ma_hoa_don nvarchar(20) primary key ,
		Ma_thanh_toan nvarchar(20),
		Ma_san_pham nvarchar(20),
		Tien_san_pham int,
		Ma_dich_vu nvarchar(20),
		Tien_dich_vu int,
		constraint fk_dv1 foreign key (Ma_dich_vu) references Dich_vu(Ma_dich_vu),
		constraint fk_hd11  foreign key (Ma_thanh_toan) references Thanh_toan(Ma_thanh_toan)  on update cascade on delete cascade,
		constraint fk_sp  foreign key (Ma_san_pham) references San_pham(Ma_san_pham)  on update cascade on delete cascade
		  )
		  create table Thanh_toan1
		  (
		  Ma_thanh_toan nvarchar(20) primary key,
		Ma_khach_hang nvarchar(20),
		 So_tien_thanh_toan int,
		 Ngay_thanh_toan date,
		 Phuong_thuc_thanh_toan varchar(20),
		 Ma_cua_hang nvarchar(20),
		 Ten_cua_hang nvarchar(30),
		 constraint fk_kh12 foreign key (Ma_khach_hang) references Khach_hang(Ma_khach_hang)  on update cascade on delete cascade,
		 constraint fk_ch12 foreign key (Ma_cua_hang) references Cua_hang(Ma_cua_hang)  on update cascade on delete cascade
		 )
	create table Cua_hang
	(
	 Ma_cua_hang nvarchar(20) primary key,
  Ten_cua_hang nvarchar(40),
  Dia_chi nvarchar(30),
  SDT int,
  Email nvarchar(30),
  Ma_nguoi_quan_ly nvarchar(20),
  Ghi_chu nvarchar(50),
  constraint fk_ql foreign key(Ma_nguoi_quan_ly) references Quan_ly(Ma_nguoi_quan_ly)
  )
