CREATE DATABASE Auctions
GO

USE Auctions
GO

CREATE TABLE Address
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Zip CHAR(5) NOT NULL,
City NVARCHAR(50) NOT NULL,
Street NVARCHAR(50) NOT NULL,
Country NVARCHAR(50) NOT NULL
);

INSERT INTO Address VALUES ('60229','Norrk�ping');
INSERT INTO Address VALUES ('60250','Norrk�ping');
INSERT INTO Address VALUES ('60339','Norrk�ping');

GO

CREATE TABLE Supplier
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
Email NVARCHAR(50) NOT NULL,
Phone CHAR(10) NOT NULL,
AdressId INT NOT NULL,
Commission DECIMAL(3,2) NOT NULL,
FOREIGN KEY (AdressId) REFERENCES Address(Id)
);

INSERT INTO Supplier VALUES ('Erik Hammar','Erik.Hammar@lev.se','0762114822','60229',0.25);
INSERT INTO Supplier VALUES ('Bj�rn Gustafsson','Bjorn.Gustafsson@lev.se','0762444832','60250',0.25);

GO

CREATE TABLE Product
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
Description NVARCHAR(200) NOT NULL,
Condition INT NOT NULL,
SupplyId INT,
FOREIGN KEY (SupplyId)  REFERENCES Supplier(Id) 
);
INSERT INTO Product VALUES ('Playstation','Spelkonsol med tv� kontroller och fem spel',3,1);

CREATE TABLE Auction
(
Id INT PRIMARY KEY IDENTITY(1,1),
Name VARCHAR(50) NOT NULL,
ProductId INT,
Startdate DATE NOT NULL,
Enddate DATE NOT NULL,
Startprice DECIMAL(38,2) NOT NULL,
BuyNow DECIMAL(38,2) NOT NULL,
Photo VARBINARY(MAX) NOT NULL,
FOREIGN KEY (ProductId) REFERENCES Product(Id)
);
INSERT INTO Auction VALUES ('PlaystationAuktion',1,'2016-09-23','2016-09-23',900,1599);
INSERT INTO Auction VALUES ('PlaystationAuktion',1,'2016-10-23','2016-11-01',9,199);
INSERT INTO Auction VALUES ('PlaystationAuktion',1,'2016-10-25','2016-11-01',9,199);

GO
CREATE TABLE Bidder
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Firstname NVARCHAR(50) NOT NULL,
Lastname NVARCHAR(50) NOT NULL,
SSN CHAR(10) NOT NULL,
Phone CHAR(10) NOT NULL,
Email NVARCHAR(50) NOT NULL,
Username NVARCHAR(50) NOT NULL,
Password NVARCHAR(50) NOT NULL,
AddressId INT NOT NULL,
FOREIGN KEY (AddressId) REFERENCES Address(Id)
);

INSERT INTO Bidder VALUES ('Arya','Stark','8505251987','0737123123','Arya.Stark@winterfell.se','NoOne','Hejhej','60339')

GO
CREATE TABLE Bids
(
BidderId INT,
AuctionId INT,
Date DATE NOT NULL,
Price DECIMAL(38,2) NOT NULL,
PRIMARY KEY (BidderId, AuctionId, Date, Price),
FOREIGN KEY (BidderId) REFERENCES Bidder(Id),
FOREIGN KEY (AuctionId) REFERENCES Auction(Id)
);
INSERT INTO Bids VALUES (1,1,'2016-09-27',1100)
INSERT INTO Bids VALUES (1,1,'2016-09-27',1200)

INSERT INTO Bids VALUES (1,2,'2016-10-27',1300)
INSERT INTO Bids VALUES (1,2,'2016-10-27',1400)

INSERT INTO Bids VALUES (1,3,'2016-10-28',1300)
INSERT INTO Bids VALUES (1,3,'2016-10-28',1400)

GO
CREATE TABLE AuctionHistory
(
Id INT IDENTITY(1,1) PRIMARY KEY,
AuctionId INT,
Name VARCHAR(50) NOT NULL,
ProductId INT,
Startdate DATE NOT NULL,
Enddate DATE NOT NULL,
Startprice DECIMAL(38,2) NOT NULL,
BuyNow DECIMAL(38,2) NOT NULL,
FinalBid DECIMAL(38,2) NOT NULL,
FOREIGN KEY (AuctionId) REFERENCES Auction(Id),
FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

INSERT INTO AuctionHistory VALUES (3,'PlaystationAuktion',1,'2016-10-25','2016-11-01',9,199,27)

GO

