CREATE DATABASE SyzygyLibraryDB;
GO
USE SyzygyLibraryDB;
GO

CREATE TABLE Students(
    Code VARCHAR(9) NOT NULL PRIMARY KEY,
    StudentName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Address VARCHAR(175),
    Email NVARCHAR(100),
    Phone VARCHAR(20)
);
GO

CREATE TABLE Authors(
    AuthorId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    AuthorName NVARCHAR(100) NOT NULL,
    Nationality VARCHAR(100),
    BirthDate DATE
);
GO

CREATE TABLE Publishers(
    PublisherId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    PublisherName NVARCHAR(100) NOT NULL,
    Country VARCHAR(100)
);
GO

CREATE TABLE Books(
    BookId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    Title NVARCHAR(100) NOT NULL,
    AuthorId INT NOT NULL FOREIGN KEY REFERENCES Authors(AuthorId),
    PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(PublisherId),
    PublicationYear DATE,
    Genre VARCHAR(25),
    Quantity INT NOT NULL
);
GO

CREATE TABLE Loans(
    LoanId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    StudentCode VARCHAR(9) NOT NULL FOREIGN KEY REFERENCES Students(Code),
    LoanDate DATE NOT NULL,
    ReturnDate DATE NOT NULL,
    LoanStatus VARCHAR(20) NOT NULL
);
GO

CREATE TABLE LoanDetails(
    DetailId INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    LoanId INT NOT NULL FOREIGN KEY REFERENCES Loans(LoanId),
    BookId INT NOT NULL FOREIGN KEY REFERENCES Books(BookId),
    Quantity INT NOT NULL
);
GO

INSERT INTO Students
VALUES('U20210463', 'Ariel', 'Chávez', NULL, 'cristian.1945theend@gmail.com', NULL);
GO

INSERT INTO Authors
VALUES('Ariel', 'El Salvador', NULL);
GO

INSERT INTO Books
VALUES('Hola Mundo', 1, 1, NULL, NULL, 25);
GO


--SP Publishers--
CREATE OR ALTER PROCEDURE spPublishers_Delete
	@PublisherId INT
AS
BEGIN
	DELETE FROM Publishers
	WHERE PublisherId = @PublisherId;
END;
GO
CREATE OR ALTER PROCEDURE spPublishers_GetAll
AS
BEGIN
	SELECT PublisherId, PublisherName, Country 
	FROM Publishers;
END;
GO
CREATE OR ALTER PROCEDURE spPublishers_GetById
	@PublisherId INT
AS
BEGIN
	SELECT PublisherId, PublisherName, Country 
	FROM Publishers
	WHERE PublisherId = @PublisherId;
END;
GO
CREATE OR ALTER PROCEDURE spPublishers_Insert
	@PublisherName NVARCHAR(100),
    @Country VARCHAR(100)
AS
BEGIN
	INSERT INTO Publishers(PublisherName, Country)
	VALUES(@PublisherName, @Country);
END;
GO
CREATE OR ALTER PROCEDURE spPublishers_Update
	@PublisherId INT,
    @PublisherName NVARCHAR(100),
    @Country VARCHAR(100)
AS
BEGIN
	UPDATE Publishers
	SET PublisherName = @PublisherName,
		Country = @Country
	WHERE PublisherId = @PublisherId
END;
GO

--SP Loans--
CREATE OR ALTER PROCEDURE spLoans_Delete
	@LoanId INT
AS
BEGIN
	DELETE FROM Loans
	WHERE LoanId = @LoanId;
END;
GO
CREATE OR ALTER PROCEDURE spLoans_GetAll
AS
BEGIN
	SELECT LoanId, StudentCode, LoanDate, ReturnDate, LoanStatus
	FROM Loans;
END;
GO
CREATE OR ALTER PROCEDURE spLoans_GetById
	@LoanId INT
AS
BEGIN
	SELECT LoanId, StudentCode, LoanDate, ReturnDate, LoanStatus
	FROM Loans
	WHERE LoanId = @LoanId;
END;
GO
CREATE OR ALTER PROCEDURE spLoans_Insert
	@StudentCode VARCHAR(9),
    @LoanDate DATE,
    @ReturnDate DATE,
    @LoanStatus VARCHAR(20)
AS
BEGIN
	INSERT INTO Loans(StudentCode, LoanDate, ReturnDate, LoanStatus)
	VALUES(@StudentCode, @LoanDate, @ReturnDate, @LoanStatus);
END;
GO
CREATE OR ALTER PROCEDURE spLoans_Update
	@LoanId INT,
    @StudentCode VARCHAR(9),
    @LoanDate DATE,
    @ReturnDate DATE,
    @LoanStatus VARCHAR(20)
AS
BEGIN
	UPDATE Loans
	SET StudentCode = @StudentCode,
		LoanDate = @LoanDate,
		ReturnDate = @ReturnDate,
		LoanStatus = @LoanStatus
	WHERE LoanId = @LoanId
END;
GO

--SP Books--
CREATE OR ALTER PROCEDURE spBooks_GetAll
AS
BEGIN
	SELECT BookId, Title, AuthorId, PublisherId, PublicationYear, Genre, Quantity
	FROM Books;
END;
GO

--SP LoanDetails--
CREATE OR ALTER PROCEDURE spLoanDetails_GetAll
AS
BEGIN
	SELECT ld.DetailId, ld.LoanId, b.Title, ld.Quantity
	FROM LoanDetails ld
	INNER JOIN Books b
	ON ld.BookId = b.BookId;
END;
GO

CREATE OR ALTER PROCEDURE spLoanDetails_GetById
	@DetailId INT
AS
BEGIN
	 SELECT DetailId, LoanId, BookId, Quantity
	 FROM LoanDetails
	 WHERE DetailId = @DetailId;
END
GO

CREATE OR ALTER PROCEDURE spLoanDetails_Insert
(
    @LoanId INT,
    @BookId INT,
    @Quantity INT
)
AS
BEGIN
	INSERT INTO LoanDetails
	VALUES(@LoanId, @BookId, @Quantity);
END
GO