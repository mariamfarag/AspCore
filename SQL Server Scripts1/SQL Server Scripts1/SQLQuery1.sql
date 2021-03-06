
create database Products

--======== Table Type
create table TypeGoods
( 
ID int identity(1,1), 
[Type] nvarchar(90) not null
constraint PK_ID primary key(ID) 
)

--======== table Offers
create table Offers
( 
ID int identity(1,1),
IDTyG int ,
Offer nvarchar(max),
size nvarchar(100),
constraint PK_IDOffers primary key(ID),
constraint FK_IDTYG foreign key(IDTyG) references TypeGoods(ID)
)

--========= table Goods
create table Goods
(
ID int  identity(1,1),
IDTG int ,
[Name] nvarchar(100) not null,
Quantity int not null,
Size nvarchar(50),
Price money not null,
Expire_Date nvarchar(20) not null,
images nvarchar(100) not null,
IDOffers int,
constraint PK_IDGOODS primary key(ID),
constraint FK_IDTYPE foreign key(IDTG) references TypeGoods(ID),
constraint FK_IDOffers foreign key(IDOffers) references Offers(ID)
)


--================= table type register
create table TypeRegister
(
ID int identity(1,1),
[Type] nvarchar(20) not null,
--constraint CK_REGTYPE check([Type] in('Admin,Manager,User')),
constraint PK_IDTYPEREGISTER primary key(ID)
)

--=========== table Register
create table Register
(
ID int identity(1,1) , 
IDTyReg int,
FName nvarchar(50) not null,
LName nvarchar(50) not null,
Phone nvarchar(100),
[Address] nvarchar(100),
ShopeName nvarchar(80),
Email nvarchar(80),
[Password] nvarchar(100),
constraint PK_REGISTER primary key(ID),
constraint FK_IDTPEREG foreign key(IDTyReg) references TypeRegister(ID)
)

--============= Bills
create table Bills
(
ID int identity(1,1),
IDTrade int ,
IDGoods int,
Quantity int ,
PriceForPic money ,
DatePayment Date ,
constraint PK_IDBILL primary key(ID),
constraint FK_IDTRADE foreign key(IDTrade) references Register(ID),
constraint FK_Goods foreign key(IDGoods) references Goods(ID),
)

--drop database Products

--drop table Offers
--alter table Offers
--drop constraint FK_IDTYG