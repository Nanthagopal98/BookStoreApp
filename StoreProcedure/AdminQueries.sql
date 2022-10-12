use BookStore

CREATE DATABASE BookStore

CREATE TABLE Admin(
AdminId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
AdminName VARCHAR(100),
AdminEmailID VARCHAR(100),
AdminPhone VARCHAR(10),
Password VARCHAR (100),
Address varchar(300)
)


INSERT INTO Admin VALUES('Natha','Nantha@gmail.com','9874561230','123456','My Address')

UPDATE Admin SET Address = '1/100, ABC Sttreet, Coimbatore, Tamilnadu - 641048'

select * from Admin

GO
CREATE PROCEDURE [dbo].[Admin_Login] @Email VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT AdminEmailID,Password FROM Admin WHERE AdminEmailID= @Email AND Password=@Password
END

GO
CREATE PROCEDURE [dbo].[Get_Admin]
AS
BEGIN
select * from Admin
END
