use zdorovie
create database zdorovie

create table pacient(
id_pac int identity(1,1) not null,
Pol varchar(20) not null,
FIO varchar(50) not null,
Data_rogz date not null,
Adress varchar(50) not null,
Polis int not null,
pasport int not null,
invalidnost varchar(10) not null,
chron_zab varchar(10) not null
primary key(id_pac)
);


create table vrachi(
id_vracha int identity(1,1) not null,
Pol varchar(20) not null,
FIO varchar(50) not null,
Dolznost varchar(50) not null,
Data_rogz date not null,
Staz int not null,
);

alter table vrachi
Add constraint id_vracha_pk primary key (id_vracha);

create table vuzov(
id_vuzova int identity(1,1) not null,
id_pac int null,
FIO_pac varchar(50) not null,
Adress varchar(50) not null,
id_vracha int null,
FIO_vracha varchar(50) not null,
Dolznost varchar(50) not null,
Data_vuzova datetime not null,
Prichina_vuzova varchar(50) not null,
Dop_infa varchar(100) not null
);


drop table vuzov

alter table vuzov
Add constraint id_vuzova_pk primary key (id_vuzova)

create table dispetcher(
id_dis int identity(1,1) not null,
login_dis varchar(50) not null,
password_dis varchar(50) not null
);


drop table dispetcher