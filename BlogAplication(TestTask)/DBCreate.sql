CREATE DATABASE Users
GO

CREATE TABLE Roles
(
	Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Role NVARCHAR(10) NOT NULL
)

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Email NVARCHAR(40) NOT NULL UNIQUE,
	Pass NVARCHAR(30) NOT NULL,
	RoleID INT NOT NULL DEFAULT '1',
	CONSTRAINT FK_Roles FOREIGN KEY(RoleID) REFERENCES Roles (Id) ON DELETE SET DEFAULT ON UPDATE CASCADE 
);


CREATE DATABASE Blog
GO

USE Blog 

CREATE TABLE Category
(
	Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	CategoryName NVARCHAR(20) NOT NULL 
)

CREATE TABLE News
(
	Id INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	ShortDesc NVARCHAR(1000) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	ImageLink NVARCHAR(500),
	CategoryID INT NOT NULL DEFAULT '1',
	Tags NVARCHAR(400) NOT NULL,
	Date DATETIME2 
	CONSTRAINT FK_Category FOREIGN KEY(CategoryID) REFERENCES Category (Id) ON DELETE SET DEFAULT ON UPDATE CASCADE
)