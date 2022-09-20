
CREATE TABLE WishList(
WishListId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
UserId INT FOREIGN KEY (UserId) REFERENCES Users(UserId),
BookId INT FOREIGN KEY (BookId) REFERENCES Books(BookId)
)

SELECT * FROM WishList

GO
CREATE PROCEDURE [dbo].[Add_To_WishList] @UserId INT, @BookId INT
AS 
BEGIN
INSERT INTO WishList VALUES (@UserId,@BookId)
END