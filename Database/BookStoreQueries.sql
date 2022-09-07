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

CREATE TABLE Login(

)

CREATE PROCEDURE Userlogin
AS

SELECT Email,Password FROM Users WHERE Email=Nantha@gmail.com AND Password=Nanthsa@123

EXEC User_Login @Email='nantha', @Password='123'


SELECT * FROM Users WHERE Email='Nantha@gmail.com'