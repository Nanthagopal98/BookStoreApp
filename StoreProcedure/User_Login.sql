USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[User_Login]    Script Date: 9/7/2022 9:19:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[User_Login] @Email VARCHAR(100), @Password VARCHAR (100)
AS
BEGIN
SELECT Email,Password FROM Users WHERE Email= @Email AND Password=@Password
END