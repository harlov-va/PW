USE ItWebNet;
GO

IF OBJECT_ID('dbo.iwn_orders','U') IS NOT NULL
	DROP TABLE dbo.iwn_orders;

GO

IF OBJECT_ID('dbo.iwn_buyers','U') IS NOT NULL
	DROP TABLE dbo.iwn_buyers;

GO

IF OBJECT_ID('dbo.iwn_delivery','U') IS NOT NULL
	DROP TABLE dbo.iwn_delivery;

GO

IF OBJECT_ID('dbo.iwn_orders','U') IS NOT NULL
	DROP TABLE dbo.iwn_orders;

GO

IF OBJECT_ID('dbo.iwn_products','U') IS NOT NULL
	DROP TABLE dbo.iwn_products;
GO

IF OBJECT_ID('dbo.iwn_producers','U') IS NOT NULL
	DROP TABLE dbo.iwn_producers;
GO

IF OBJECT_ID('dbo.iwn_productType','U') IS NOT NULL
	DROP TABLE dbo.iwn_productType;
GO

CREATE TABLE iwn_producers(
id	INT PRIMARY KEY  IDENTITY(1,1) NOT NULL,
[name]	NVARCHAR(100) NOT NULL,
code NVARCHAR(10) NOT NULL
);
GO

INSERT INTO iwn_producers([name], code) VALUES
('Vitesse','VTS'),
('Lumme','LUM'),
('BRAND','BRND'),
('Moulinex','MOLX'),
('Redmond','RDMD')
;
GO

CREATE TABLE iwn_productType(		
id	INT PRIMARY KEY  IDENTITY(1,1) NOT NULL,
[name]	NVARCHAR(100) NOT NULL,
code NVARCHAR(10) NOT NULL
);
GO

INSERT INTO iwn_productType([name], code) VALUES
('Чайник','Tea'),
('Стиральная машина','Washing'),
('Телевизор','TV')
;
GO

CREATE TABLE iwn_products(
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[guid] UNIQUEIDENTIFIER NOT NULL,
articul	NVARCHAR(50) NOT NULL,
[name]	NVARCHAR(100) NOT NULL,
price	MONEY NOT NULL,
currency NVARCHAR(5) NOT NULL,
producerID INT NOT NULL REFERENCES iwn_producers(id) ON DELETE CASCADE,
productTypeID INT NOT NULL REFERENCES iwn_productType(id) ON DELETE CASCADE
)
GO

INSERT INTO iwn_products([guid] ,articul ,[name],price,currency,producerID,productTypeID) VALUES
(NEWID(),'78FGH1','Vitesse VS-3003',500,'RUR',1,2),
(NEWID(),'78FGH2','VES SK-A18',510,'RUR',1,2),
(NEWID(),'78FGH3','Lumme LU-1450',520,'RUR',1,2),
(NEWID(),'78FGH4','BRAND 6051',530,'RUR',1,2),
(NEWID(),'78FGH5','REDMOND RMC-PM503',547,'RUR',2,1),
(NEWID(),'78FGH6','Moulinex CE 500E32',550,'RUR',2,1),
(NEWID(),'78FGH7','REDMOND RMC-P350',560,'RUR',3,3),
(NEWID(),'78FGH11','Steba DD2',570,'RUR',3,3),
(NEWID(),'78FGH9','Redmond RMC-PM380',580,'RUR',4,3),
(NEWID(),'78FGH10','Cuckoo CMC-HE1055F',590,'RUR',5,3)
;
GO

CREATE TABLE iwn_delivery(
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
[name]	NVARCHAR(100) NOT NULL,
code NVARCHAR(10) NOT NULL
);
GO

INSERT INTO iwn_delivery([name], code) VALUES
('Самовывоз со склада','SW'),
('Почта России','PR'),
('Курьерская доставка','CD')
;
GO

CREATE TABLE iwn_buyers(
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
fullName NVARCHAR(100) NOT NULL,
phone	NVARCHAR(20) NOT NULL,
email	NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE iwn_orders(
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
amount INT NOT NULL,
total MONEY NOT NULL,
productsID INT NOT NULL REFERENCES iwn_products(id) ON DELETE CASCADE,
deliveryID INT NOT NULL REFERENCES iwn_delivery(id) ON DELETE CASCADE,
buyersID INT NOT NULL REFERENCES iwn_buyers(id) ON DELETE NO ACTION,
);
GO

