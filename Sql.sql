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

/* !!!!!!!! NORMALDE BU TAR VERİYİ AÇIK BİR ŞEKİLDE TUTMAK PEK SAĞLIKLI OLMAZ !!!!!!!!*/
CREATE TABLE Cards (
Id INT PRIMARY KEY IDENTITY(1,1),
UserId INT NOT NULL,
FullName VARCHAR(100),
CreditCard VARCHAR(16) NOT NULL,
ExpiryDate VARCHAR(6),
CVV VARCHAR(3) NOT NULL
);

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY(1,1),
CardId INT NOT NULL,
Status BIT NOT NULL
);

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
	(1, 1, 2016, 1650, 'BMW M2 COMPETITION V1'),
	(1, 2, 2017, 2650, 'BMW M2 COMPETITION V2'),
	(1, 3, 2018, 3650, 'BMW M2 COMPETITION V3'),
	(1, 4, 2019, 4650, 'BMW M2 COMPETITION V4'),
	(1, 5, 2020, 5650, 'BMW M2 COMPETITION V5'),

	(2, 1, 2016, 1650, 'AUDI Q7'),
	(2, 2, 2017, 2650, 'AUDI Q8'),
	(2, 3, 2018, 3650, 'AUDI S3'),
	(2, 4, 2019, 4650, 'AUDI S4'),
	(2, 5, 2020, 5650, 'AUDI S5'),

	(3, 1, 2016, 1650, 'ALFA ROMEO GIULA V1'),
	(3, 2, 2017, 2650, 'ALFA ROMEO GIULA V2'),
	(3, 3, 2018, 3650, 'ALFA ROMEO GIULA V3'),
	(3, 4, 2019, 4650, 'ALFA ROMEO GIULA V4'),
	(3, 5, 2020, 5650, 'ALFA ROMEO GIULA V5');

INSERT INTO Users (FirstName,LastName,Email,Status) VALUES
('Mevlânâ Celâleddîn-i','Rûmî','mevlana.rumi@gmail.com',1),
('Emir','Ahi','emirahi45@gmail.com',1)

INSERT INTO Brands(BrandName)
VALUES
	('BMW'),('AUDI'),
	('ALFA ROMEO')

INSERT INTO Colors(ColorName)
VALUES
	('Black'),('Red'),
	('Gray'),('Gold'),
	('Silver');


INSERT INTO Customers(CompanyName,UserId)
VALUES ('Şirket1',1),
	   ('Şirket2',2);

INSERT INTO Rentals(CarId,CustomerId,RentDate,ReturnDate)
VALUES 
(1,2,CAST('2021-02-15' AS datetime),CAST('2021-02-25' AS datetime)),
(2,1,CAST('2021-02-22' AS datetime),CAST('2021-03-30' AS datetime))

INSERT INTO Cards (UserId,FullName,CreditCard,ExpiryDate,CVV) VALUES
(1,'Emir Ahi','1234567890987654','12/38','123'),
(2,'Orhan Kemal','4771551993169797','06/30','553'),
(1,'Emir Ahi','5450711743458719','07/35','278');

INSERT INTO Payments (CardId,Status) VALUES
(1,1),
(2,1),
(3,0)

SELECT * FROM Cars;
SELECT * FROM Brands;
SELECT * FROM Colors;
SELECT * FROM Users;
SELECT * FROM UserOperationClaims;
SELECT * FROM OperationClaims;
SELECT * FROM Customers;
SELECT * FROM Rentals;
SELECT * FROM CarImages;
SELECT * FROM Cards;
SELECT * FROM Payments;

-- truncate table Rentals;
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

SELECT * FROM Cars
SELECT * FROM Brands
SELECT * FROM Colors
SELECT * FROM CarImages

SELECT * FROM Cars C
JOIN Brands B
ON C.BrandId = B.BrandId
JOIN Colors CLR
ON C.ColorId = CLR.ColorId

SELECT * FROM RENTALS
SELECT * FROM Users

SELECT * FROM Rentals R
JOIN Cars C
ON R.CarId = C.Id
JOIN Brands B
ON C.BrandId = b.BrandId
JOIN Customers CUS
ON R.CustomerId = CUS.CustomerId
JOIN Colors COL
ON COL.ColorId = C.ColorId
JOIN Users U
ON U.UsersId = CUS.UserId

SELECT * FROM Users;
SELECT * FROM Cards;
SELECT * FROM Payments;

SELECT * FROM Payments P
JOIN Cards C 
ON P.CardId = C.Id
JOIN Users U
ON C.UserId = U.UsersId
WHERE U.Status = 1 AND P.Status = 1

SELECT * FROM Rentals

/*
from r in context.Rentals
join c in context.Cars
on r.CarId equals c.Id
join b in context.Brands
on c.BrandId equals b.BrandId
join customer in context.Customers
on r.CustomerId equals customer.CustomerId
join color in context.Colors
on c.ColorId equals color.ColorId
join user in context.Users
on customer.UserId equals user.UsersId
where r.CarId == id
*/
SELECT * FROM Rentals R
JOIN Cars C
ON R.CarId = C.Id
JOIN Brands B
ON C.BrandId = B.BrandId
JOIN Customers CUS
ON R.CustomerId = CUS.CustomerId
JOIN Colors COL
ON C.ColorId = COL.ColorId
JOIN Users U
ON CUS.UserId = U.UsersId
Where r.CarId = 12