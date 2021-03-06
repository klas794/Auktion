DROP DATABASE Auction
CREATE DATABASE Auction
USE Auction

CREATE TABLE Address
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Zip CHAR(5) NOT NULL,
City NVARCHAR(50) NOT NULL,
Street NVARCHAR(50) NOT NULL,
Country NVARCHAR(50) NOT NULL
);

INSERT INTO Address VALUES ('60229','Norrk�ping','Hantverkaregatan 23','Sweden');
INSERT INTO Address VALUES ('60250','Norrk�ping','Smedjegatan 52','Sweden');
INSERT INTO Address VALUES ('60339','Norrk�ping','Garvaregatan 72','Sweden');

GO

CREATE TABLE Supplier
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Firstname NVARCHAR(50) NOT NULL,
Lastname NVARCHAR(50) NOT NULL,
Email NVARCHAR(50) NOT NULL,
Phone CHAR(10) NOT NULL,
AdressId INT NOT NULL,
Commission DECIMAL(3,2) NOT NULL,
FOREIGN KEY (AdressId) REFERENCES Address(Id)
);

INSERT INTO Supplier VALUES ('Erik', 'Hammar','Erik.Hammar@lev.se','0762114822',1,0.25);
INSERT INTO Supplier VALUES ('Bj�rn', 'Gustafsson','Bjorn.Gustafsson@lev.se','0762444832',2,0.25);

GO

CREATE TABLE Product
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name NVARCHAR(50) NOT NULL,
Description NVARCHAR(200) NOT NULL,
Condition INT NOT NULL,
SupplyId INT,
Photo VARBINARY(MAX),
FOREIGN KEY (SupplyId)  REFERENCES Supplier(Id) 
);
INSERT INTO Product VALUES ('Playstation','Spelkonsol med tv� kontroller och fem spel',3,1,0);

CREATE TABLE Auction
(
Id INT IDENTITY(1,1),
Name VARCHAR(50) NOT NULL,
ProductId INT,
Startdate DATE NOT NULL,
Enddate DATE NOT NULL,
Startprice DECIMAL(38,2) NOT NULL,
BuyNow DECIMAL(38,2) NOT NULL,
PRIMARY KEY (Id, ProductId), 
FOREIGN KEY (ProductId) REFERENCES Product(Id) ON DELETE CASCADE
);
INSERT INTO Auction VALUES ('PlaystationAuktion',1,'2016-09-23','2016-09-23',900,1599);




GO
CREATE TABLE Bidder
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Firstname NVARCHAR(50) NOT NULL,
Lastname NVARCHAR(50) NOT NULL,
Phone CHAR(10) NOT NULL,
Email NVARCHAR(50) NOT NULL,
Username NVARCHAR(50) NOT NULL,
AddressId INT NOT NULL,
FOREIGN KEY (AddressId) REFERENCES Address(Id)
);

INSERT INTO Bidder VALUES ('Arya','Stark','0737123123','Arya.Stark@winterfell.se','NoOne',3)

GO
CREATE TABLE Bids
(
BidderId INT,
AuctionId INT,
ProductId INT,
Date DATE NOT NULL,
Price DECIMAL(38,2) NOT NULL,
PRIMARY KEY (BidderId, AuctionId, ProductId, Date, Price),
FOREIGN KEY (BidderId) REFERENCES Bidder(Id),
FOREIGN KEY (AuctionId, ProductId) REFERENCES Auction(Id, ProductId) ON DELETE CASCADE
);
INSERT INTO Bids VALUES (1,1,1,'2016-09-27',1100)
INSERT INTO Bids VALUES (1,1,1,'2016-09-27',1200)


GO
CREATE TABLE AuctionHistory
(
Id INT IDENTITY(1,1) PRIMARY KEY,
Name VARCHAR(50) NOT NULL,
ProductId INT,
Startdate DATE NOT NULL,
Enddate DATE NOT NULL,
Startprice DECIMAL(38,2) NOT NULL,
BuyNow DECIMAL(38,2) NOT NULL,
FinalBid DECIMAL(38,2) NOT NULL,
BidderId INT NOT NULL,
FOREIGN KEY (BidderId) REFERENCES Bidder(Id),
FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

INSERT INTO AuctionHistory VALUES ('PlaystationAuktion',1,'2016-10-25','2016-11-01',9,199,27,1)

GO

