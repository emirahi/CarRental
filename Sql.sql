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
	Password varbinary(500),
	PasswordSalt varbinary(500),
	Status bit
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

/* CarImages (Araba Resimleri) tablosu oluşturunuz. (Id,CarId,ImagePath,Date) Bir arabanın birden fazla resmi olabilir.
 */
 CREATE TABLE CarImages(
 Id INT PRIMARY KEY IDENTITY(1,1),
 CarId INT,
 ImagePath VARCHAR(200),
 ImageDate DATE
 )

 CREATE TABLE OperationClaims(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(250) NOT NULL
 )

 CREATE TABLE UserOperationClaims(
 Id INT PRIMARY KEY IDENTITY(1,1),
 UserId INT,
 OperationClaimId INT
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
SELECT * FROM UserOperationClaims;
SELECT * FROM OperationClaims;
SELECT * FROM Customers;
SELECT * FROM Rentals;
Select * FROM CarImages;

/* 2 tablo birleştirme kısaca join işlemi */
SELECT CompanyName,FirstName,LastName,Email,Password 
FROM Customers c
join Users u
on c.UserId = u.UsersId


truncate table Users;

USE CarDB;
SELECT * FROM Users;
SELECT * FROM UserOperationClaims;
SELECT * FROM OperationClaims;

SELECT UOC.Id,Users.Email,Users.Status,OperationClaims.Name
FROM UserOperationClaims UOC 
INNER JOIN Users ON UOC.UserId = Users.UsersId
INNER JOIN OperationClaims on OperationClaims.Id = UOC.UserId;


SELECT * FROM Users
-- TRUNCATE TABLE Users;

/*
var query = from b in context.Brands
            join c in context.Cars
            on b.BrandName equals brandName
            join color in context.Colors
            on c.ColorId equals color.ColorId
            where c.BrandId == b.BrandId
            select new CarByBrandDto
            {
                Id = c.Id,
                BrandName = b.BrandName,
                ColorName = color.ColorName,
                DailyPrice = c.DailyPrice,
                ModelYear = c.ModelYear,
                Descriptions = c.Descriptions
*/

SELECT * FROM Cars c 
join  Brands b 
on b.BrandName = 'BMW'
join Colors color
on c.ColorId = color.ColorId
where c.BrandId = b.BrandId