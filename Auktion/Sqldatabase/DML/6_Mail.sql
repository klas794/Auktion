USE Auction
GO		

CREATE PROCEDURE SendMailIfAuctionFinishedWithOutBids
AS
DECLARE @id int, @max_id int, @mailbody NVARCHAR(255), @mailtitle NVARCHAR(255)

SELECT @id = MIN(a.Id), @max_id = MAX(a.id) FROM Auction a
WHERE a.Enddate = CAST(GETDATE() AS DATE) AND NOT EXISTS (SELECT * FROM dbo.Bids b WHERE b.AuctionId = a.Id)

WHILE @id <= @max_id
BEGIN

	SET @mailbody = 'The auction with the ID ' + CAST(@id as nvarchar(10)) + ' ended without any bids.'
	SET @mailtitle = 'An auction (ID ' + CAST(@id as nvarchar(10)) + ') ended without any bids.'

	EXEC msdb.dbo.sp_send_dbmail
		@profile_name = 'Gmail',
		@recipients = 'gucollin@gmail.com',
		@body = @mailbody,
		@subject = @mailtitle

    SELECT @id = MIN(a.Id) FROM Auction a WHERE a.Id > @id
	AND a.Enddate = CAST(GETDATE() AS DATE) AND NOT EXISTS (SELECT * FROM dbo.Bids b WHERE b.AuctionId = a.Id)

END

EXEC SendMailIfAuctionFinishedWithOutBids