USE Auction
GO

CREATE PROCEDURE GetBiddingHistory
	@AuctionId int
AS
	SELECT * FROM Bids b
	JOIN Bidder br
	ON br.Id = b.BidderId
	WHERE b.AuctionId = @AuctionId
GO

EXEC GetBiddingHistory 2