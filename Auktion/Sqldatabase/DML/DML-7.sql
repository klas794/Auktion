
GO

CREATE TRIGGER ArchiveAuction ON Auction
INSTEAD OF DELETE AS
BEGIN
	DECLARE @FinalPrice DECIMAL
	DECLARE @FinalBidderId INT
	SELECT @FinalPrice = Max(Price), @FinalBidderId = Bids.BidderId 
		FROM Bids, DELETED WHERE Bids.AuctionId = DELETED.Id
		GROUP BY Bids.BidderId

	DECLARE @Id INT
	SET @Id = (SELECT Id FROM DELETED)

	DELETE FROM Auction WHERE Id = @Id

	INSERT INTO AuctionHistory (ProductId,Name,Startdate,Enddate,StartPrice,BuyNow,FinalBid,BidderId)
	SELECT ProductId,Name,Startdate,Enddate,StartPrice,BuyNow, @FinalPrice, @FinalBidderId FROM DELETED
END

GO

--DELETE FROM Auction WHERE Id = 2

