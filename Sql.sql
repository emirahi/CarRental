CREATE DATABASE CarDB;
GO
USE CarDB;
go
CREATE TABLE Cars(
	Id int primary key identity(1,1),
	BrandId int,
	ColorId int,
	ModelYear int,
	DailyPrice decimal,
	Descriptions varchar(50)
)

CREATE TABLE Colors(
	ColorId int primary key identity(1,1),
	ColorName nvarchar(50)
)

CREATE TABLE Brands(
	BrandId int primary key identity(1,1),
	BrandName nvarchar(50)
)

/* Id,FirstName,LastName,Email,Password */
CREATE TABLE Users(
	UsersId int primary key identity(1,1),
	FirstName varchar(75),
	LastName varchar(75),
	Email varchar(75),
	Password varchar(75),
)

/* UserId,CompanyName */
Create TABLE Customers(
	CustomerId int primary key identity(1,1),
	CompanyName varchar(75),
	UserId int NOT NULL
)
/*
Id,CarId,CustomerId,RentDate(Kiralama Tarihi)
,ReturnDate(Teslim Tarihi). 
Araba teslim edilmemişse ReturnDate null'dır.
*/
CREATE TABLE Rentals(
RentalsId int primary key identity(1,1),
CarId int NOT NULL,
CustomerId int NOT NULL,
RentDate Datetime,
ReturnDate Datetime
)

INSERT INTO Cars(BrandId, ColorId, ModelYear, DailyPrice, Descriptions)
VALUES
	(1, 2, 2019, 650, 'BMW M2 COMPETITION'),
	(2, 3, 2016, 500,'AUDI A3 SEDAN'),
	(4, 1, 2017, 1000, 'ALFA ROMEO GIULIETTA'),
	(1, 5, 2016, 750, 'BMW M4 SPECIFICATIONS'),
	(5, 4, 2020, 900, 'AUDI S4');

INSERT INTO Brands(BrandName)
VALUES
	('BMW'),
	('AUDI'),
	('ALFA ROMEO'),
	('BMW'),
	('AUDI');

INSERT INTO Colors(ColorName)
VALUES
	('Black'),
	('Red'),
	('Gray'),
	('Gold'),
	('Silver');

INSERT INTO Users(FirstName,LastName,Email,Password)
VALUES ('Emir','Ahi','emirahi45@gmail.com','sifre1'),
	   ('Orhan','Veli Kanık','orhan.veli@gmail.com','sifre2');

INSERT INTO Customers(CompanyName,UserId)
VALUES ('Şirket1',1),
	   ('Şirket2',2);

INSERT INTO Rentals(CarId,CustomerId,RentDate,ReturnDate)
VALUES 
(1,2,CAST('2021-02-15' AS datetime),null),
(2,1,CAST('2021-02-22' AS datetime),null)


SELECT * FROM Cars;
SELECT * FROM Brands;
SELECT * FROM Colors;
SELECT * FROM Users;
SELECT * FROM Customers;
SELECT * FROM Rentals;

/* 2 tablo birleştirme kısaca join işlemi */
SELECT CompanyName,FirstName,LastName,Email,Password 
FROM Customers c
join Users u
on c.UserId = u.UsersId
