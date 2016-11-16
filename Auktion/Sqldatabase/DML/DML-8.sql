
GO

CREATE TRIGGER ArchiveAuction ON Auction
INSTEAD OF DELETE AS
BEGIN
	DECLARE @FinalPrice DECIMAL
	SELECT @FinalPrice = Max(Price) FROM Bids, DELETED WHERE Bids.AuctionId = DELETED.Id

	DECLARE @Id INT
	SET @Id = (SELECT Id FROM DELETED)

	DELETE FROM Auction WHERE Id = @Id

	INSERT INTO AuctionHistory (ProductId,Startdate,Enddate,StartPrice,BuyNow,FinalBid)
	SELECT ProductId,Startdate,Enddate,StartPrice,BuyNow, @FinalPrice FROM DELETED
END

GO

--DELETE FROM Auction WHERE Id = 2

