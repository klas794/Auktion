USE Auction
GO

CREATE PROCEDURE ListCurrentAuctions
AS
	SELECT DISTINCT a.Id [Auction Id], a.ProductId [Product Id], a.Startdate [Start Date], a.Enddate [End Date], 
		   (SELECT MAX(Price) FROM Bids WHERE AuctionId = a.Id) [Highest Bid],
		   (SELECT BidderId FROM Bids WHERE AuctionId = a.Id AND Price = (SELECT MAX(Price) FROM Bids WHERE AuctionId = a.Id)) [Bidder Id]
	FROM dbo.Auction a
	FULL JOIN dbo.Bids b
	ON b.AuctionId = a.Id
	WHERE a.Startdate <= CAST(GETDATE() AS DATE) AND a.Enddate >= CAST(GETDATE() AS DATE) 
GO

EXEC ListCurrentAuctions
