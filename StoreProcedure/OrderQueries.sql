

CREATE TABLE TrackOrder(
OrderId INT IDENTITY(1,1) PRIMARY KEY,
Quantity INT,
UserId INT FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId INT FOREIGN KEY (BookId) REFERENCES Books(BookId),
AddressId INT FOREIGN KEY (AddressId) REFERENCES Address(AddressId)
)

DROP TABLE TrackOrder
ALTER TABLE TrackOrder ADD CartId INT FOREIGN KEY (CartId) REFERENCES Cart(CartId)
ALTER TABLE TrackOrder ADD OrderCost INT NOT NULL
ALTER TABLE TrackOrder ADD DateTime VARCHAR(MAX) NOT NULL

DELETE FROM TrackOrder WHERE OrderId = 2

ALTER TABLE TrackOrder ALTER COLUMN OrderCost FLOAT NOT NULL 



alter table TrackOrder add constraint fk_CARTID foreign key(CartId) references Cart(CartId) ON DELETE CASCADE ON UPDATE CASCADE;

SELECT * FROM TrackOrder



GO
ALTER PROCEDURE Place_Order @CartId INT, @AddressId INT, @DateTime DateTime
AS
BEGIN TRY
	DECLARE @REQQuantity INT = (SELECT Quantity FROM Cart WHERE CartId = @CartId)
	DECLARE @UserId INT = (SELECT UserId FROM Cart WHERE CartId = @CartId)
	DECLARE @BookId INT = (SELECT BookId FROM CART WHERE CartId = @CartId)
	DECLARE @Cost FLOAT = (SELECT DiscountPrice FROM Books WHERE BookId = @BookId)
	DECLARE @ActualQuantity INT = (SELECT BookQuantity FROM Books WHERE BookId = @BookId)
	IF(@REQQuantity < @ActualQuantity)
	BEGIN
	
	DECLARE @OrderCost FLOAT = @Cost * @REQQuantity
	INSERT INTO TrackOrder VALUES(@REQQuantity, @UserId, @BookId, @AddressId, @CartId, @OrderCost, @DateTime)
	END
END TRY
BEGIN CATCH
END CATCH