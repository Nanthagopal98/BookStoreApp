create database BookStore
USE BookStore

SELECT * FROM Users

CREATE TABLE Users(
UserId INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
UserName VARCHAR(100),
Email VARCHAR(100),
Phone BIGINT,
Password VARCHAR (100)
)

CREATE PROCEDURE AddUser
AS

CREATE PROCEDURE Userlogin
AS

USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[User_Procedures]    Script Date: 9/6/2022 9:22:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_User] @UserName VARCHAR(100), @Email VARCHAR(100), @Phone BIGINT, @Password VARCHAR (100)
AS
BEGIN
INSERT INTO Users(UserName,Email,Phone,Password) VALUES (@UserName, @Email, @Phone, @Password)
END



GO
CREATE PROCEDURE [dbo].[User_Login] @Email VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT Email,Password FROM Users WHERE Email= @Email AND Password=@Password
END


GO
CREATE PROCEDURE [dbo].[Reset_Password] @Email VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
UPDATE Users SET Password = @Password WHERE Email = @Email
END