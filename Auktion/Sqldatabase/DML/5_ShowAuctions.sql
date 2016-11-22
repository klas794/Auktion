USE Auction
GO

CREATE PROCEDURE ShowAuctionsByDate
	@Stardate date,
	@Enddate date
AS
	SELECT DISTINCT a.Id [Auction Id], a.Name [Product Name], a.ProductId [Product Id], a.Startdate [Start date],
	a.Enddate [End date], (SELECT s.Commission FROM Supplier s
						   WHERE s.Id = (SELECT p.SupplyId FROM Product p 
										 WHERE p.Id = a.ProductId)) [Commision]
	FROM Auction a
	WHERE a.Startdate >= @Stardate AND a.Enddate <= @Enddate
GO

EXEC ShowAuctionsByDate '2016-10-01', '2016-11-18'