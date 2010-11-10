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
 
CREATE TABLE Borrow (
    ISBN VARCHAR(35) NOT NULL,
    CustomerID INT NOT NULL,
    CopyID INT NOT NULL,
    BDate DATETIME DEFAULT GETDATE(),
    CONSTRAINT Borrow_PK PRIMARY KEY (ISBN, CustomerID, CopyID),
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
-- get all copies of an book Anatoly 20101108
-- return isbn, copyID, customerID, if customerID null,the book is available
CREATE FUNCTION get_copies_for_a_book(@isbn VARCHAR(35))
RETURNS TABLE
AS RETURN (
	select c.ISBN, c.CopyID, b.CustomerID
	from Copy c left outer join Borrow b
	ON c.ISBN = b.ISBN
	and c.CopyID = b.CopyID
	where c.ISBN = @isbn
)
-- Anatoly 20101108
CREATE FUNCTION get_available_copies_for_a_book(@isbn VARCHAR(35))
RETURNS TABLE
AS RETURN (
	select c.ISBN, c.CopyID
	from Copy c left outer join Borrow b
	ON c.ISBN = b.ISBN
	and c.CopyID = b.CopyID
	where c.ISBN = @isbn
	and b.CustomerID IS NULL
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

CREATE FUNCTION search_books_with_a_title_that_begins_with_A()
RETURNS TABLE
AS RETURN (
	SELECT *
	FROM Book
	WHERE Title LIKE 'A' + '%'
)

CREATE FUNCTION search_customers_with_more_than_one_book()
RETURNS TABLE
AS RETURN (
		SELECT COUNT(b.CustomerID) AS NumberOf
		FROM Borrow b, Customer c
		WHERE b.CustomerID = c.CustomerID
		GROUP BY b.CustomerID
		HAVING COUNT(b.CustomerID) > 1
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

-- Pontus 20101104. Updated by Anatoly (if)
CREATE PROCEDURE usp_add_copy
@isbn VARCHAR(35)
AS
	BEGIN
		IF NOT EXISTS (SELECT isbn FROM Book WHERE isbn = @isbn)
			BEGIN
				RAISERROR('There is no such book', 11, 1);
			END
		ELSE 
			BEGIN
				declare @copyid INT
				SELECT @copyid = MAX(CopyID) + 1
				FROM Copy
				WHERE ISBN = @isbn
				IF @copyid IS NULL
					BEGIN
						SET @copyid = 1
					END
				INSERT INTO Copy values(@isbn, @copyid)
			END
	END


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

-- Create Procedures Dino 20101104
CREATE PROCEDURE usp_borrow_book
@isbn VARCHAR(35),
@customerID INT,
@copyID INT
AS
	begin
		INSERT INTO Borrow(ISBN, CustomerID, CopyID) values(@isbn, @customerID, @copyID)
	end

CREATE PROCEDURE usp_return_book
@isbn VARCHAR(35),
@customerID INT,
@copyID INT
AS
	begin
		DELETE FROM Borrow
		WHERE ISBN = @isbn
		AND CustomerID = @customerID
		AND CopyID = @copyID
	end	

-- Create Function Dino 20101105
CREATE FUNCTION get_last_book_borrowed()
RETURNS TABLE
AS RETURN (
	SELECT *
	FROM Book
	WHERE ISBN =
	(SELECT ISBN
		FROM(
		SELECT ISBN, CopyID, CustomerID, BDate,
		row_no = row_number() OVER (ORDER BY BDate DESC)
        FROM Borrow
	) d
	WHERE  row_no = 1)
)

--create function Dino 20101108

CREATE FUNCTION get_all_customers()
RETURNS TABLE
AS RETURN (
	SELECT *
	FROM Customer
)
-- Anatoly 20101108
CREATE PROCEDURE usp_add_customer
@name VARCHAR(50),
@address VARCHAR(75),
@phone VARCHAR(50)
AS
	begin
		DECLARE @CustomerID INT
		SELECT @CustomerID = MAX(CustomerID) + 1
		FROM Customer
		IF @CustomerID IS NULL
			BEGIN
				SET @CustomerID = 1
			END
		INSERT INTO Customer VALUES(@customerID, @name, @address, @phone)
	end
-- create procedure Dino 20101108
CREATE PROCEDURE usp_delete_customer
@customerID INT
AS
	begin
		IF NOT EXISTS(SELECT CustomerID FROM Customer WHERE CustomerID = @customerID)
			BEGIN 
				RAISERROR('The customer you are trying to delete does not exist!', 11, 1)
			END
		ELSE
			BEGIN
				DELETE FROM Customer WHERE CustomerID = @customerID
			END
	end
)

CREATE FUNCTION get_all_borrows()
RETURNS TABLE
AS RETURN (
	SELECT b.ISBN, c.CustomerID, c.Name, b.CopyID
	FROM Borrow b, Customer c
	WHERE b.CustomerID = c.CustomerID
)

-- Anatoly 20101109
CREATE PROCEDURE usp_update_customer
@customerID INT,
@name VARCHAR(50),
@address VARCHAR(75),
@phone VARCHAR(50)
AS
	begin
		IF NOT EXISTS(SELECT CustomerID FROM Customer WHERE CustomerID = @customerID)
			BEGIN 
				RAISERROR('The customer you are trying to update does not exist!', 11, 1)
			END
		ELSE
			BEGIN
				UPDATE Customer 
				SET Name = @name, Address = @address, Phone = @phone
				WHERE CustomerID = @customerID
			END
	end

CREATE PROCEDURE usp_update_book
@isbn VARCHAR (35),
@title VARCHAR(75),
@numberofpages INT,
@pyear INT,
@publisher VARCHAR(50),
@author VARCHAR(50)

AS
	begin
		IF NOT EXISTS(SELECT ISBN FROM Book WHERE ISBN = @isbn)
			BEGIN 
				RAISERROR('The Book you are trying to update does not exist!', 11, 1)
			END
		ELSE
			BEGIN
				UPDATE Book 
				SET Title = @title, Author = @author, Publisher = @publisher, NumberOfPages = @numberofpages, PrintYear = @pyear
				WHERE ISBN = @isbn
			END
	end