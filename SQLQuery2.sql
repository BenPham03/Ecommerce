USE banmaytinh

CREATE TABLE Users(
ID INT IDENTITY(1,1) PRIMARY KEY,
IDCustomer INT REFERENCES Customer(ID),
PassWord VARCHAR(100),
Email VARCHAR(100),
Fund DECIMAL(18,2),
Type INT,
Status INT,
CreatedOn DateTime
) 
Drop Table Users

SELECT * FROM Users
SELECT * FROM Bill
SELECT * FROM BillInfo
SELECT * FROM Category
SELECT * FROM ImportInvoice
SELECT * FROM ImportInvoiceInfo
SELECT * FROM Staff
SELECT * FROM Supplier
SELECT * FROM Customer
SELECT * FROM Product

CREATE TABLE Users(
ID INT IDENTITY(1,1) PRIMARY KEY,
IDCustomer INT REFERENCES Customer(ID),
PassWord VARCHAR(100),
Email VARCHAR(100),
Fund DECIMAL(18,2),
Type INT,
Status INT,
CreatedOn DateTime
) 
Drop Table Users