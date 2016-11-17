USE Auction
GO

ALTER PROCEDURE AddProduct
	@Name nvarchar(50),
	@Description nvarchar(200),
	@Condition int,
	@SupplyId int
AS
	SET IDENTITY_INSERT dbo.Product ON
	INSERT INTO Product (Id, Name, Description, Condition, SupplyId)
	VALUES((SELECT TOP 1 p.Id FROM Product p ORDER BY p.Id DESC) + 1, @Name, @Description, @Condition, @SupplyId)
	SET IDENTITY_INSERT dbo.Product OFF
GO

EXEC AddProduct 'Headphones', 'Yellow headphones', 1, 1