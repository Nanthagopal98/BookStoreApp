

CREATE TABLE Books(
BookId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
BookName  VARCHAR(250),
AuthorName VARCHAR(250),
Rating VARCHAR(250),
TotalRating  INT,
DiscountPrice VARCHAR(250),
ActualPrice  VARCHAR(250),
Description  VARCHAR(250),
BookImage  VARCHAR(250),
BookQuantity  INT
)

SELECT * FROM Books
UPDATE Books SET BookQuantity = 1000 WHERE BookId = 1

SELECT * FROM Books

GO
CREATE PROCEDURE [dbo].[Add_Book] @BookName  VARCHAR(250), @AuthorName VARCHAR(250), @Rating VARCHAR(250),
					@TotalRating  INT, @DiscountPrice VARCHAR(250), @ActualPrice  VARCHAR(250),
					@Description  VARCHAR(250), @BookImage  VARCHAR(250), @BookQuantity  INT
AS
BEGIN
INSERT INTO Books VALUES (@BookName, @AuthorName, @Rating,@TotalRating, @DiscountPrice, @ActualPrice,
					@Description, @BookImage, @BookQuantity)
END

GO 
CREATE PROCEDURE [dbo].[Get_All_Book]
AS
BEGIN
SELECT * FROM Books
END

GO
CREATE PROCEDURE [dbo].[Get_Book_By_Id] @BookId INT
AS 
BEGIN
SELECT * FROM Books WHERE BookId = @BookId
END


GO
CREATE PROCEDURE [dbo].[Update_Book] @BookId INT, @BookName  VARCHAR(250), @AuthorName VARCHAR(250), @Rating VARCHAR(250),
					@TotalRating  INT, @DiscountPrice VARCHAR(250), @ActualPrice  VARCHAR(250),
					@Description  VARCHAR(250), @BookImage  VARCHAR(250), @BookQuantity  INT
AS 
BEGIN
UPDATE Books SET BookName = @BookName, AuthorName = @AuthorName, Rating = @Rating,
					TotalRating = @TotalRating, DiscountPrice = @DiscountPrice, ActualPrice = @ActualPrice,
					Description = @Description, BookImage = @BookImage, BookQuantity = @BookQuantity  WHERE BookId = @BookId
END


GO
CREATE PROCEDURE [dbo].[Delete_Book] @BookId INT
AS
BEGIN
DELETE FROM Books WHERE BookId = @BookId
END

