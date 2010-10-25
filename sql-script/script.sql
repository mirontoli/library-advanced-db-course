-- CREATE TABLES
-- 20101025
-- Pontus
CREATE TABLE Customer (
    CustomerID INT(8) NOT NULL,
    Name VARCHAR(50),
    Address VARCHAR(75),
    Phone VARCHAR(50),
    CONSTRAINT Customer_PK PRIMARY KEY (CustomerID)
    );
 
CREATE TABLE Book (
    ISBN VARCHAR(35) NOT NULL,
    Title VARCHAR(75),
    NumberOfPages INT(10),
    Year INT(4),
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
    CopyID INT(8) NOT NULL,
    CONSTRAINT Copy_PK PRIMARY KEY (ISBN, CopyID)
    CONSTRAINT Copy_FK FOREIGN KEY (ISBN) REFERENCES Book (ISBN)
    );
 
CREATE TABLE Reserv (
    CustomerID INT(8) NOT NULL,
    ISBN VARCHAR(35) NOT NULL,
    RDate VARCHAR(10),
    CONSTRAINT Reserv_PK PRIMARY KEY (CustomerID, ISBN),
    CONSTRAINT Reserv_Customer_FK FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID),
    CONSTRAINT Reserv_Book_FK FOREIGN KEY (ISBN) REFERENCES Book (ISBN)
    );
 
CREATE TABLE Borrow (
    ISBN VARCHAR(35) NOT NULL,
    CustomerID INT(8) NOT NULL,
    CopyID INT(8) NOT NULL,
    CONSTRAINT Borrow_PK PRIMARY KEY (ISBN, CustomerID, CopyID),
    CONSTRAINT Borrow_Book_FK FOREIGN KEY (ISBN) REFERENCES Book (ISBN),
    CONSTRAINT Borrow_Customer_FK FOREIGN KEY (CustomerID) REFERENCES Customer (CustomerID)
    );

-- Goran test
-- create procedure...