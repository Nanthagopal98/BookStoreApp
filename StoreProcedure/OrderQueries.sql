
CREATE TABLE TrackOrder(
OrderId INT IDENTITY(1,1) PRIMARY KEY,
Quantity INT,
UserId INT FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId INT FOREIGN KEY (BookId) REFERENCES Books(BookId),
AddressId INT FOREIGN KEY (AddressId) REFERENCES Address(AddressId)
)

ALTER TABLE TrackOrder DROP COLUMN CartId

ALTER TABLE TrackOrder ADD CartId INT FOREIGN KEY (CartId) REFERENCES Cart(CartId) ON DELETE SET NULL
ALTER TABLE TrackOrder ADD OrderCost INT NOT NULL
ALTER TABLE TrackOrder ADD DateTime VARCHAR(MAX) NOT NULL

DELETE FROM TrackOrder WHERE OrderId = 2

ALTER TABLE TrackOrder ALTER COLUMN OrderCost FLOAT NOT NULL 

SELECT * FROM TrackOrder

SELECT * FROM Cart



GO
ALTER PROCEDURE Place_Order @CartId INT, @AddressId INT, @DateTime DateTime
AS
BEGIN TRY
	DECLARE @REQQuantity INT = (SELECT Quantity FROM Cart WHERE CartId = @CartId)
	DECLARE @UserId INT = (SELECT UserId FROM Cart WHERE CartId = @CartId)
	DECLARE @BookId INT = (SELECT BookId FROM CART WHERE CartId = @CartId)
	DECLARE @Cost FLOAT = (SELECT DiscountPrice FROM Books WHERE BookId = @BookId)
	DECLARE @ActualQuantity INT = (SELECT BookQuantity FROM Books WHERE BookId = @BookId)

	IF(@ActualQuantity >= @REQQuantity  )
	BEGIN
	DECLARE @OrderCost FLOAT = @Cost * @REQQuantity
	INSERT INTO TrackOrder VALUES (@REQQuantity, @UserId, @BookId, @AddressId, @OrderCost, @DateTime, @CartId)
	UPDATE Books SET BookQuantity = @ActualQuantity - @REQQuantity WHERE BookId = @BookId
	DELETE FROM Cart WHERE CartId = @CartId
	END
END TRY
BEGIN CATCH
END CATCH
GO

exec Place_Order 5,1,'Sep 21 2022 10:10AM'


GO
ALTER PROCEDURE Cancel_Order @orderId INT, @UserId INT
AS
BEGIN
DELETE FROM TrackOrder WHERE OrderId = @orderId AND UserId = @UserId
END

GO
CREATE PROCEDURE Get_Order @UserId INT
AS
BEGIN
SELECT * FROM TrackOrder WHERE UserId = @UserId
END
