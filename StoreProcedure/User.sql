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