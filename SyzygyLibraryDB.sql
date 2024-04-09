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
    PublicationYear DATE,
    Genre VARCHAR(25),
    Quantity INT NOT NULL,
	AuthorId INT NOT NULL FOREIGN KEY REFERENCES Authors(AuthorId),
    PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(PublisherId)
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
    Quantity INT NOT NULL,
	LoanId INT NOT NULL FOREIGN KEY REFERENCES Loans(LoanId),
    BookId INT NOT NULL FOREIGN KEY REFERENCES Books(BookId)
);
GO

INSERT INTO Students
VALUES('U20210463', 'Ariel', 'Chávez', NULL, 'cristian.1945theend@gmail.com', NULL);
GO

INSERT INTO Authors
VALUES('Ariel', 'El Salvador', NULL);
GO
INSERT INTO Authors
VALUES('SVV', 'El Salvador', NULL);
GO

INSERT INTO Books
VALUES('Hola Mundo', NULL, NULL, 25, 1, 1);
GO

--SP Publishers Pueden guiarse de estos procedimientos almacenados para hacer Authors y Studens--

--SP Para eliminar
CREATE OR ALTER PROCEDURE spPublishers_Delete
	@PublisherId INT
AS
BEGIN
	DELETE FROM Publishers
	WHERE PublisherId = @PublisherId;
END;
GO

--SP Para listar
CREATE OR ALTER PROCEDURE spPublishers_GetAll
AS
BEGIN
	SELECT PublisherId, PublisherName, Country 
	FROM Publishers;
END;
GO

--SP Para obtener registro especifico
CREATE OR ALTER PROCEDURE spPublishers_GetById
	@PublisherId INT
AS
BEGIN
	SELECT PublisherId, PublisherName, Country 
	FROM Publishers
	WHERE PublisherId = @PublisherId;
END;
GO

--SP Para insertar
CREATE OR ALTER PROCEDURE spPublishers_Insert
	@PublisherName NVARCHAR(100),
    @Country VARCHAR(100)
AS
BEGIN
	INSERT INTO Publishers(PublisherName, Country)
	VALUES(@PublisherName, @Country);
END;
GO

--SP Para actualizar
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

--SP Students--
--SP Para eliminar
CREATE OR ALTER PROCEDURE spStudents_Delete
	@Code VARCHAR(9)
AS
BEGIN
	DELETE FROM Students
	WHERE Code = @Code;
END;
GO

--SP Para listar
CREATE OR ALTER PROCEDURE spStudents_GetAll
AS
BEGIN
	SELECT Code, StudentName, LastName, Address, Email, Phone
	FROM Students;
END;
GO

--SP Para obtener registro especifico
CREATE OR ALTER PROCEDURE spStudents_GetById
	@Code VARCHAR(9)
AS
BEGIN
	SELECT Code, StudentName, LastName, Address, Email, Phone
	FROM Students
	WHERE Code = @Code;
END;
GO

--SP Para insertar
CREATE OR ALTER PROCEDURE spStudents_Insert
	@Code VARCHAR(9),
	@StudentName NVARCHAR,
    @LastName NVARCHAR(50),
    @Address VARCHAR(175),
    @Email NVARCHAR(100),
    @Phone VARCHAR(20)
AS
BEGIN
	INSERT INTO Students(Code, StudentName, LastName, Address, Email, Phone)
	VALUES(@Code, @StudentName, @LastName, @Address, @Email, @Phone);
END;
GO

--SP Para actualizar
CREATE OR ALTER PROCEDURE spStudents_Update
	@Code VARCHAR(9),
    @StudentName VARCHAR(50),
	@LastName VARCHAR(50),
    @Address VARCHAR(175),
	@Email VARCHAR(100),
    @Phone VARCHAR(20)
AS
BEGIN
	UPDATE Students
	SET StudentName = @StudentName,
		LastName = @LastName,
		Address = @Address,
		Email =  @Email,
		Phone = @Phone
	WHERE Code = @Code
END;
GO

--Estos son los otros sp, no guiarse de estos c:
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

--SP LoanDetails--

CREATE OR ALTER PROCEDURE spLoanDetails_Delete
	@DetailId INT
AS
BEGIN
	DELETE FROM LoanDetails
	WHERE DetailId = @DetailId;
END;
GO

CREATE OR ALTER PROCEDURE spLoanDetails_GetAll
AS
BEGIN
	SELECT ld.DetailId, ld.Quantity, ld.LoanId, b.Title
	FROM LoanDetails ld
	INNER JOIN Books b
	ON ld.BookId = b.BookId;
END;
GO

CREATE OR ALTER PROCEDURE spLoanDetails_GetAllSpecific
	@LoanId INT
AS
BEGIN
	SELECT ld.DetailId, ld.Quantity, ld.LoanId, b.Title
	FROM LoanDetails ld
	INNER JOIN Books b
	ON ld.BookId = b.BookId
	WHERE ld.LoanId = @LoanId;
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
	@Quantity INT,
    @LoanId INT,
    @BookId INT
)
AS
BEGIN
	INSERT INTO LoanDetails
	VALUES(@Quantity, @LoanId, @BookId);
END
GO

CREATE OR ALTER PROCEDURE spLoanDetails_Update
(
	@DetailId INT,
	@Quantity INT,
    @LoanId INT,
    @BookId INT
)
AS
BEGIN
	UPDATE LoanDetails
	SET Quantity = @Quantity,
		LoanId = @LoanId,
		BookId = @BookId
	WHERE DetailId = @DetailId;
END;
GO

CREATE OR ALTER PROCEDURE spDBooks_GetAll
AS
BEGIN
	SELECT BookId, Title, AuthorId, PublisherId, PublicationYear, Genre, Quantity
	FROM Books;
END;
GO

--SP Books--

CREATE OR ALTER PROCEDURE spBooks_Delete
	@BookId INT
AS
BEGIN
	DELETE FROM Books
	WHERE BookId = @BookId;
END;
GO

CREATE OR ALTER PROCEDURE spBooks_GetAll
AS
BEGIN
	SELECT b.BookId, b.Title, b.PublicationYear, b.Genre, b.Quantity, a.AuthorName, p.PublisherName
	FROM Books b
	INNER JOIN Authors a ON b.AuthorId = a.AuthorId
	INNER JOIN Publishers p ON b.PublisherId = p.PublisherId;
	
END;
GO

CREATE OR ALTER PROCEDURE spBooks_GetById
	@BookId INT
AS
BEGIN
	 SELECT BookId, Title, AuthorId, PublisherId, PublicationYear, Genre, Quantity
	 FROM Books
	 WHERE BookId = @BookId;
END
GO

CREATE OR ALTER PROCEDURE spBooks_Insert
(
    @Title NVARCHAR(100),
    @PublicationYear DATE,
    @Genre VARCHAR(25),
    @Quantity INT,
	@AuthorId INT,
    @PublisherId INT
)
AS
BEGIN
	INSERT INTO Books
	VALUES(@Title, @PublicationYear, @Genre, @Quantity, @AuthorId, @PublisherId);
END
GO

CREATE OR ALTER PROCEDURE spBooks_Update
(
	@BookId INT,
    @Title NVARCHAR(100),
    @PublicationYear DATE,
    @Genre VARCHAR(25),
    @Quantity INT,
	@AuthorId INT,
    @PublisherId INT
)
AS
BEGIN
	UPDATE Books
	SET Title = @Title,
		PublicationYear = @PublicationYear,
		Genre = @Genre,
		Quantity = @Quantity,
		AuthorId = @AuthorId,
		PublisherId = @PublisherId
	WHERE BookId = @BookId;
END;
GO

--SP Authors--
CREATE OR ALTER PROCEDURE spAuthors_GetAll
AS
BEGIN
	SELECT AuthorId, AuthorName, Nationality, BirthDate 
	FROM Authors;
END;
GO


--Triggers--
CREATE OR ALTER TRIGGER SubtractBookQuantity
ON LoanDetails
AFTER INSERT
AS
BEGIN
    UPDATE Books
    SET Quantity = Quantity - (SELECT Quantity FROM inserted WHERE Books.BookId = inserted.BookId)
    WHERE BookId IN (SELECT BookId FROM inserted);
END;
GO

CREATE OR ALTER TRIGGER AddBookQuantity
ON LoanDetails
AFTER DELETE
AS
BEGIN
    UPDATE Books
    SET Quantity = Quantity + (SELECT Quantity FROM deleted WHERE Books.BookId = deleted.BookId)
    WHERE BookId IN (SELECT BookId FROM deleted);
END;
GO

CREATE OR ALTER TRIGGER UpdateBookQuantity
ON LoanDetails
INSTEAD OF UPDATE
AS
BEGIN
    -- Actualizar la cantidad de libros y los detalles del préstamo
    UPDATE Books
    SET Quantity = Quantity - COALESCE((SELECT SUM(CASE WHEN i.Quantity > d.Quantity THEN (i.Quantity - d.Quantity) ELSE 0 END) 
                                         FROM inserted i JOIN deleted d ON i.DetailId = d.DetailId 
                                         WHERE Books.BookId = d.BookId), 0) +
                   COALESCE((SELECT SUM(CASE WHEN d.Quantity > i.Quantity THEN (d.Quantity - i.Quantity) ELSE 0 END) 
                                         FROM inserted i JOIN deleted d ON i.DetailId = d.DetailId 
                                         WHERE Books.BookId = d.BookId), 0)
    WHERE BookId IN (SELECT BookId FROM inserted);

    -- Actualizar los detalles del préstamo
    UPDATE LoanDetails
    SET Quantity = i.Quantity
    FROM inserted i
    WHERE LoanDetails.DetailId = i.DetailId;
END;
