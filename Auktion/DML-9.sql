CREATE PROCEDURE GetMonthlyRevenue AS SELECT SUM(SellPrice) FROM (
SELECT FORMAT(Auction.EndDate, 'yyyy-MM') AS Month, MAX(Bids.Price) AS SellPrice FROM Auction
	INNER JOIN Bids ON Bids.AuctionId = Auction.Id
	GROUP BY Auction.Id, FORMAT(Auction.EndDate, 'yyyy-MM'), Auction.EndDate
	HAVING Auction.EndDate <= GETDATE()
	) a
	GROUP BY a.Month
GO

CREATE VIEW [List Of Customer Purchases] AS
SELECT 

