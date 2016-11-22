USE Auction
GO

CREATE PROCEDURE AddProduct
	@Name nvarchar(50),
	@Description nvarchar(200),
	@Condition int,
	@SupplyId int,
	@PhotoPath nvarchar(MAX)
AS
	DECLARE @query NVARCHAR(MAX), @Apostrophe NVARCHAR(10), @NewId int, @NewIdText nvarchar(15)
	SET @NewId = ((SELECT TOP 1 p.Id FROM Product p ORDER BY p.Id DESC) + 1)

	SET IDENTITY_INSERT dbo.Product ON
	INSERT INTO Product (Id, Name, Description, Condition, SupplyId, Photo)
	VALUES(@NewId, @Name, @Description, @Condition, @SupplyId, 0)
	SET IDENTITY_INSERT dbo.Product OFF

	SET @NewIdText = CAST(@NewId AS NVARCHAR(15))	
	SET @Apostrophe = ''''
	SET @query = 'DECLARE @file VARBINARY(MAX)
	SET @file = (SELECT * FROM OPENROWSET(BULK ''' + @PhotoPath + @Apostrophe + ', SINGLE_BLOB) Photo)
	UPDATE dbo.Product
	SET Photo = @file
	WHERE Id = ' + @NewIdText

	--PRINT @query
	EXEC sp_executesql @query

GO

EXEC AddProduct 'Headphones', 'Yellow headphones', 1, 1, 'C:\Projects\a.jpg'