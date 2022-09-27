
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


GO
ALTER PROCEDURE [dbo].[Delete_Book_WishList] @bookId INT , @UserId INT
AS
BEGIN
DELETE FROM WishList WHERE BookId = @bookId AND UserId = @UserId
END

GO
CREATE PROCEDURE [dbo].[Get_Procedure_WishList] @UserId INT
AS 
BEGIN
SELECT * FROM WishList WHERE UserId = @UserId
END