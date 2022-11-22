
CREATE TABLE Cart(
CartId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Quantity INT DEFAULT 1,
UserId INT FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId INT FOREIGN KEY (BookId) REFERENCES Books(BookId)
)



ALTER TABLE Cart ADD UserId  INT FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE NO ACTION
ALTER TABLE Cart ADD BookId INT FOREIGN KEY (BookId) REFERENCES Books(BookId) ON DELETE NO ACTION

SELECT * FROM Cart

INSERT INTO Cart VALUES (50,1,1)

SELECT BookId FROM Cart
DELETE FROM Cart WHERE CartId = 5
GO
CREATE PROCEDURE [dbO].[Add_To_Cart] @Quantity INT, @UserId INT, @BookId INT
AS
BEGIN
INSERT INTO Cart VALUES(@Quantity, @UserId, @BookId)
END

GO
ALTER PROCEDURE [dbo].[Update_Cart] @Quantity INT, @CartId INT, @UserId INT
AS
BEGIN
UPDATE Cart SET Quantity = @Quantity WHERE CartId = @CartId AND UserId = @UserId
END

GO
ALTER PROCEDURE [dbO].[Delete_Cart] @BookId INT, @UserId INT
AS
BEGIN
DELETE FROM Cart WHERE BookId = @BookId AND UserId = @UserId
END

GO
ALTER PROCEDURE [dbo].[Get_Procedure]
AS
BEGIN
SELECT * FROM BookAndCart
END

GO
ALTER VIEW BookAndCart AS
SELECT  BK.BookId,CartId,BookName,AuthorName,Rating,TotalRating,DiscountPrice,ActualPrice,Description,BookImage,BookQuantity,Quantity,UserId
FROM Cart CT INNER JOIN Books BK ON CT.BookId = BK.BookId 

SELECT * FROM BookAndCart