USE CarDb;
GO
CREATE TABLE Colors (

Id int primary key identity(1,1),
Color varchar(75)
);

CREATE TABLE Brand (
Id int primary key identity(1,1),
Model varchar(100)
);

CREATE TABLE Car (
Id int primary key identity(1,1),
BrandId int,
ColorId int,
ModelYear int,
DailyPrice Decimal,
Description varchar(750)
);

/* Brand veri ekleme işlemi */
INSERT INTO Brand (Model) VALUES ('Bmw');
INSERT INTO Brand (Model) VALUES ('Toyoto');
INSERT INTO Brand (Model) VALUES ('Tesla');

/* Colors veri ekleme işlemi */
INSERT INTO Colors (Color) VALUES ('siyah');
INSERT INTO Colors (Color) VALUES ('beyaz');
INSERT INTO Colors (Color) VALUES ('kahverengi');
INSERT INTO Colors (Color) VALUES ('lacivert');
INSERT INTO Colors (Color) VALUES ('kırmızı');
INSERT INTO Colors (Color) VALUES ('mor');
INSERT INTO Colors (Color) VALUES ('pembe');


/* Color veri ekleme */

INSERT INTO Car (BrandId,ColorId,ModelYear,DailyPrice,Description) 
VALUES (1,2,2019,2500,'This bwm is color white');
GO
INSERT INTO Car (BrandId,ColorId,ModelYear,DailyPrice,Description) 
VALUES (2,1,2020,5500,'This toyoto is color black');
GO
INSERT INTO Car (BrandId,ColorId,ModelYear,DailyPrice,Description) 
VALUES (3,4,2021,10500,'This tesla is color Nany Blue');
 
 /*
 select c.*,b.Model,color.Color from Car c
 join Brand b on
 c.BrandId = b.Id
 join COLORS color on 
 color.Id = c.ColorId
 */

 