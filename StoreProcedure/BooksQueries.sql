

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

GO
CREATE PROCEDURE [dbo].[Add_Book] @BookName  VARCHAR(250), @AuthorName VARCHAR(250), @Rating VARCHAR(250),
					@TotalRating  INT, @DiscountPrice VARCHAR(250), @ActualPrice  VARCHAR(250),
					@Description  VARCHAR(250), @BookImage  VARCHAR(250), @BookQuantity  INT
AS
BEGIN
INSERT INTO Books VALUES (@BookName, @AuthorName, @Rating,@TotalRating, @DiscountPrice, @ActualPrice,
					@Description, @BookImage, @BookQuantity)
END