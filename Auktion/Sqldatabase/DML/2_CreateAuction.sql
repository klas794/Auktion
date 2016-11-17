USE Auction
GO

ALTER PROCEDURE CreateAuction
	@Name varchar(50),
	@ProductId int,
	@Startdate date,
	@Enddate date,
	@Startprice decimal(38,2),
	@BuyNow decimal(38,2),
	@Photo varbinary(MAX)
AS
	SET IDENTITY_INSERT dbo.Auction ON
	INSERT INTO dbo.Auction (Id, Name, ProductId, Startdate, Enddate, Startprice, BuyNow, Photo)
	VALUES((SELECT TOP 1 a.Id FROM Auction a ORDER BY a.Id DESC) + 1, @Name, @ProductId, @Startdate, @Enddate, @Startprice, @BuyNow, @Photo)
	SET IDENTITY_INSERT dbo.Auction OFF
GO

EXEC CreateAuction 'PlayStation', 1, '2016-11-17', '2016-11-25', 300, 1000, 0