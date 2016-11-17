﻿GO
CREATE VIEW Buyers
AS
SELECT Bidder.Id, SUM(h.FinalBid) AS BuysTotal FROM Bidder
	INNER JOIN AuctionHistory h ON Bidder.Id = h.FinalBidderId
	GROUP BY Bidder.Id