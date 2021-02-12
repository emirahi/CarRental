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

SELECT * FROM Cars;
SELECT * FROM Brands;
SELECT * FROM Colors;

