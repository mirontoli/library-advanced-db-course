-- Create database Anatoly 20101015
CREATE DATABASE bibliotek
GO
USE bibliotek
GO

-- CREATE TABLES
-- Pontus 20101025
-- revision Pontus 20101104
CREATE TABLE Customer (
    CustomerID INT NOT NULL,
    Name VARCHAR(50),
    Address VARCHAR(75),
    Phone VARCHAR(50),
    CONSTRAINT Customer_PK PRIMARY KEY (CustomerID)
    );
 
CREATE TABLE Book (
    ISBN VARCHAR(35) NOT NULL,
    Title VARCHAR(75),
    NumberOfPages INT,
    PrintYear INT,
    Publisher VARCHAR(50),
    Author VARCHAR(50),
    CONSTRAINT Book_PK PRIMARY KEY (ISBN)
    );
 
CREATE TABLE Copy (
    ISBN VARCHAR(35) NOT NULL,
    CopyID INT NOT NULL,
    CONSTRAINT Copy_PK PRIMARY KEY (ISBN, CopyID),
    CONSTRAINT Copy_FK FOREIGN KEY (ISBN) REFERENCES Book (ISBN)
    );
 
CREATE TABLE Reserv (
    CustomerID INT NOT NULL,
    ISBN VARCHAR(35) NOT NULL,
    RDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT Reserv_PK PRIMARY KEY (CustomerID, ISBN, RDate),
    CONSTRAINT Reserv_Customer_FK FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID),
    CONSTRAINT Reserv_Book_FK FOREIGN KEY (ISBN) REFERENCES Book (ISBN)
    );
 
CREATE TABLE Borrow (
    ISBN VARCHAR(35) NOT NULL,
    CustomerID INT NOT NULL,
    CopyID INT NOT NULL,
    BDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT Borrow_PK PRIMARY KEY (ISBN, CustomerID, CopyID, BDate),
    CONSTRAINT Borrow_Copy_FK FOREIGN KEY (ISBN, CopyID) REFERENCES Copy (ISBN, CopyID),
    CONSTRAINT Borrow_Customer_FK FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID)
    );

CREATE TABLE Borrow_History (
    ISBN VARCHAR(35) NOT NULL,
    CustomerID INT NOT NULL,
    CopyID INT NOT NULL,
    BDate DATETIME,
	RDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT Borrow_History_PK PRIMARY KEY (ISBN, CustomerID, CopyID, BDate),
    CONSTRAINT Borrow_History_Copy_FK FOREIGN KEY (ISBN, CopyID) REFERENCES Copy (ISBN, CopyID),
    CONSTRAINT Borrow__History_Customer_FK FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID)
    );


-- Create functions Anatoly 20101026
CREATE FUNCTION search_books_titles(@title VARCHAR(75))
RETURNS TABLE
AS RETURN (
	SELECT *
	FROM Book
	WHERE Title LIKE '%' + @title + '%'
)

-- Create functions Pontus 20101028
CREATE FUNCTION search_number_of_book_pages()
RETURNS TABLE
AS RETURN (
	SELECT *
	FROM Book
	WHERE NumberOfPages > 500
)

CREATE FUNCTION search_book_print_year()
RETURNS TABLE
AS RETURN (
		SELECT *
		FROM Book
		WHERE PrintYear < 1995
)

-- Create procedures Anatoly 20101026
CREATE PROCEDURE usp_add_book
@isbn VARCHAR(35),
@title VARCHAR(75),
@number_of_pages INT,
@print_year INT,
@publisher VARCHAR(50),
@author VARCHAR(50)
AS
	begin
		IF NOT EXISTS(SELECT isbn FROM Book where isbn = @isbn)
			BEGIN 
				INSERT INTO Book values(@isbn, @title, @number_of_pages, @print_year, @publisher, @author)
			END
		ELSE 
			BEGIN
				RAISERROR('There is already such a book', 11, 1)
			END
	end

-- Pontus 20101104
CREATE PROCEDURE usp_add_copy
@isbn VARCHAR(35)
AS
	begin
	declare @copyid INT
	SELECT @copyid = MAX(CopyID) + 1
	FROM Copy
	WHERE ISBN = @isbn
	INSERT INTO Copy values(@isbn, @copyid)
	end

-- inserts Anatoly 20101026
-- revision Pontus 20101104
insert into Book values('9789121100523', 'Latinsk grammatik', 247, 1989, 'Almqvist & Wiksell läromedel', 'Erik Tidner');
exec usp_add_book '9781412929554', 'Global Shift: Mapping the Changing Contours of the World Economy', 599, 2007, 'Sage', 'Peter Dicken'
exec usp_add_book '0316769533', 'The Catcher in the Rye', 276, 1951, 'Little, Brown and Company', 'J. D. Salinger'

-- CREATE TRIGGER Dino 20101104
CREATE TRIGGER SaveBorrowHistory
ON Borrow
AFTER DELETE
AS
INSERT INTO Borrow_History (ISBN, CustomerID, CopyID, BDate)
SELECT *
FROM deleted