USE BookStore

CREATE TABLE Address(
AddressId INT PRIMARY KEY IDENTITY(1,1),
Address VARCHAR(250) NOT NULL,
City VARCHAR(250) NOT NULL,
State VARCHAR(250) NOT NULL,
TypeId INT FOREIGN KEY (TypeId) REFERENCES AddressType(TypeId),
UserId INT FOREIGN KEY (UserId) REFERENCES Users(UserId)
)

SELECT  * FROM Address



CREATE TABLE AddressType(
TypeId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
Type VARCHAR(250) 
)

SELECT * FROM AddressType

INSERT INTO AddressType VALUES ('Home')
INSERT INTO AddressType VALUES ('Office')
INSERT INTO AddressType VALUES ('Other')

GO
CREATE PROCEDURE Add_Address @Address VARCHAR(250), @City VARCHAR (250), @State VARCHAR(250), @TypeId INT, @UserId INT
AS
BEGIN
INSERT INTO Address VALUES (@Address, @City, @State, @TypeId, @UserId)
END

GO
ALTER PROCEDURE Update_Address @Address VARCHAR(250), @City VARCHAR (250), @State VARCHAR(250), @TypeId INT, @UserId INT, @AddressId INT
AS
BEGIN
UPDATE Address SET Address = @Address, City = @City, State = @State, TypeId = @TypeId WHERE UserId = @UserId AND @AddressId = AddressId
END


GO 
CREATE PROCEDURE Get_Address @UserId INT
AS 
BEGIN
SELECT * FROM Address WHERE UserId = @UserId
END
