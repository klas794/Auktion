GO

CREATE VIEW [Provision per month]
AS
SELECT Month, SUM(Commission) AS Commission FROM (
SELECT  FORMAT(Auction.EndDate, 'yyyy-MM') AS Month, 
		MAX(Bids.Price) * Supplier.Commission AS Commission 
	FROM Auction
	INNER JOIN Bids ON Bids.AuctionId = Auction.Id
	INNER JOIN Product ON Product.Id = Auction.ProductId 
	INNER JOIN Supplier ON Supplier.Id = Product.SupplyId 
	GROUP BY Auction.Id, FORMAT(Auction.EndDate, 'yyyy-MM'), Auction.EndDate, Supplier.Commission
	HAVING Auction.EndDate <= GETDATE()
	) a
	GROUP BY a.Month
GO

--SELECT * FROM [Provision per month]