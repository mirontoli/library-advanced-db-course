-- Create database Anatoly 20101015
CREATE DATABASE bibliotek

-- CREATE TABLES
-- 20101025
-- Pontus
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
    CONSTRAINT Book_PK PRIMARY KEY (ISBN)
    );
 
CREATE TABLE Author (
    ISBN VARCHAR(35) NOT NULL,
    Authors VARCHAR(50) NOT NULL,
    CONSTRAINT Author_PK PRIMARY KEY (ISBN, Authors),
    CONSTRAINT Author_FK FOREIGN KEY (ISBN) REFERENCES Book (ISBN)
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




-- Create functions Anatoly 20101026
CREATE FUNCTION search_books_titles(@title VARCHAR(75))
RETURNS TABLE
AS RETURN (
	SELECT *
	FROM Book
	WHERE Title LIKE '%' + @title + '%'
)


CREATE PROCEDURE usp_add_book
@isbn VARCHAR(35),
@title VARCHAR(75),
@number_of_pages INT,
@print_year INT,
@publisher VARCHAR(50)
AS
	begin
		INSERT INTO Book values(@isbn, @title, @number_of_pages, @print_year, @publisher)
	end

-- inserts Anatoly 20101026
insert into Book values('9789121100523', 'Latinsk grammatik', 247, 1989, 'Almqvist & Wiksell läromedel');
exec usp_add_book '9781412929554', 'Global shift, mapping the changing contours of the world economy', 599, 2007, 'Sage'