
CREATE TABLE Cart(
CartId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Quantity INT DEFAULT 1,
UserId INT FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId INT FOREIGN KEY (BookId) REFERENCES Books(BookId)
)

SELECT * FROM Cart

INSERT INTO Cart VALUES (2,5,3)

SELECT BookId FROM Cart

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
CREATE PROCEDURE [dbO].[Delete_Cart] @CartId INT, @UserId INT
AS
BEGIN
DELETE FROM Cart WHERE CartId = @CartId AND UserId = @UserId
END

GO
CREATE PROCEDURE [dbo].[Get_Procedure] @UserId INT
AS
BEGIN
SELECT * FROM Cart WHERE UserId = @UserId
END