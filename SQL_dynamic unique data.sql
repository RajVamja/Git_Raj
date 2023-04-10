use RV355RajVamja

--create table Data_Products(
--    ProductID int primary key,
--    Name varchar(100),
--    ProductNumber nvarchar(50)
--);

--create table Data_ProductDetails(
--    ProductID int,
--    Color nvarchar(30),
--    SafetyStockLevel smallint,
--    ReorderPoint smallint,
--    StandardCost money,
--    ListPrice money,
--    Size nvarchar(20),
--	FOREIGN KEY (ProductID) REFERENCES Data_Products (ProductID)
--);

--create table Data_Orders(
--	PurchaseOrderID int,
--	PurchaseOrderDetailID int,
--	OrderQty int,
--	ProductID int, 
--	UnitPrice float,
--	LineTotal float,
--	ReceivedQty int,
--	RejectedQty int,
--	StockedQty int,
--);
--ALTER TABLE Data_Orders
--ADD PRIMARY KEY (PurchaseOrderID);

--delete from Data_Orders where PurchaseOrderID >= 1

--create table Data_OrderDetails(
--	PurchaseOrderID int,
--	RevisionNumber int,
--	Status int,
--	EmployeeID int,
--	VendorID int,
--	ShipMethodID int,
--	SubTotal float,
--	TaxAmt float,
--	Freight float,
--	TotalDue float,
--);



--select * from Data_Orders
--select * from Data_OrderDetails
--select * from Data_ProductDetails
--select * from Data_Products














----------------------------------------------------------------------------------------------------------------------------------------------





drop table DY_Employee
CREATE TABLE DY_Employee (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(50),
	Title VARCHAR(50),
    Birthdate DATE,
    HireDate DATE
);
DECLARE @n INT = 1;
WHILE @n <= 500
BEGIN
  DECLARE @E_Name VARCHAR(50) = (SELECT TOP 1 Name FROM Data_Products ORDER BY NEWID());
  INSERT INTO DY_Employee (EmployeeID, Name, Title, BirthDate, HireDate)
  VALUES (@n, @E_Name, 'Title ' + CAST(@n AS VARCHAR(10)), DATEADD(year, -18, GETDATE()), DATEADD(day, -@n, GETDATE()));
  SET @n = @n + 1;
END;
drop table DY_EmployeeDetails
CREATE TABLE DY_EmployeeDetails (
    EmployeeID INT,
	Age INT,
    Email VARCHAR(100),
    Phone VARCHAR(20),
	Title VARCHAR(50),
	Salary float,
    CONSTRAINT FK_EmployeeDetails_EmployeeID FOREIGN KEY (EmployeeID) REFERENCES DY_Employee(EmployeeID)
);

DECLARE @n INT = 1;
WHILE @n <= 500
BEGIN
  DECLARE @JobTitles TABLE (Title VARCHAR(50));
  INSERT INTO @JobTitles (Title)
  VALUES ('Assistant'), ('HR'), ('CEO'), ('Developer'), ('Designer'), ('Marketing Manager'), ('Sales Representative'), ('Accountant');

  DECLARE @Title VARCHAR(50) = (SELECT TOP 1 Title FROM @JobTitles ORDER BY NEWID());
  INSERT INTO DY_EmployeeDetails (EmployeeID, Age, Email, Phone, Title,Salary)
  VALUES (@n, ABS(CHECKSUM(NEWID())) % 40 + 18, 'email' + CAST(@n AS VARCHAR(10)) + '@gmail.com', '123-456-' + RIGHT('0000' + CAST(ABS(CHECKSUM(NEWID())) % 10000 AS VARCHAR(4)), 4), @Title,ABS(CHECKSUM(NEWID())) % 100000 + 50000);
  SET @n = @n + 1;
END;



select * from DY_Employee
select * from DY_EmployeeDetails


--DECLARE @n INT = 1;
--WHILE @n <= 500
--BEGIN
--  INSERT INTO DY_Employee (EmployeeID, FirstName, LastName, Title, BirthDate, HireDate)
--  VALUES (@n, 'FirstName ' + CAST(@n AS VARCHAR(10)), 'LastName ' + CAST(@n AS VARCHAR(10)), 'Title ' + CAST(@n AS VARCHAR(10)), DATEADD(year, -18, GETDATE()), DATEADD(day, -@n, GETDATE()));
--  SET @n = @n + 1;
--END;


--INSERT INTO Customers (CustomerID, CustomerName, ContactName, Address, City, Country)
--SELECT n, 'Customer ' + CAST(n AS VARCHAR(10)), 'Contact ' + CAST(n AS VARCHAR(10)), 'Address ' + CAST(n AS VARCHAR(10)), 'City ' + CAST(n AS VARCHAR(10)), 'Country ' + CAST(n AS VARCHAR(10))
--FROM (SELECT TOP 500 ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS n FROM sys.columns c1, sys.columns c2) AS numbers;


create table Eemployee(
	JobTitle nvarchar(max)
);


DECLARE @n INT = 1;
WHILE @n <= 500
BEGIN
  DECLARE @E_Name VARCHAR(50) = (SELECT TOP 1 Name FROM Data_Products ORDER BY NEWID());
  DECLARE @E_Title VARCHAR(50) = (SELECT CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 2) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 3) % 26));
  INSERT INTO DY_Employee (EmployeeID, Name, Title, BirthDate, HireDate)
  VALUES (@n, @E_Name, @E_Title, DATEADD(year, -18, GETDATE()), DATEADD(day, -@n, GETDATE()));
  SET @n = @n + 1;
END;


DECLARE @n INT = 1;
WHILE @n <= 500
BEGIN
  DECLARE @JobTitles TABLE (Title VARCHAR(50));
  INSERT INTO @JobTitles (Title)
  VALUES ('Assistant'), ('HR'), ('CEO'), ('Developer'), ('Designer'), ('Marketing Manager'), ('Sales Representative'), ('Accountant');
  
  DECLARE @E_Name VARCHAR(50) = (SELECT TOP 1 Name FROM Data_Products ORDER BY NEWID());
  DECLARE @Title VARCHAR(50) = (SELECT TOP 1 Title FROM @JobTitles ORDER BY NEWID());
  DECLARE @BirthDate DATE = DATEADD(YEAR, -ABS(CHECKSUM(NEWID())) % 44, '2003-01-01');
  
  INSERT INTO DY_Employee (EmployeeID, Name, Title, BirthDate, HireDate)
  VALUES (@n, @E_Name, @Title, @BirthDate, DATEADD(day, -@n, GETDATE()));
  
  SET @n = @n + 1;
END;

--DECLARE @n INT = 1;
--WHILE @n <= 500
--BEGIN
--  DECLARE @E_Name VARCHAR(50) = (SELECT TOP 1 Name FROM Data_Products ORDER BY NEWID());
  --DECLARE @BirthYear INT = ABS(CHECKSUM(NEWID())) % 54 + 1950; 
  --DECLARE @BirthMonth INT = ABS(CHECKSUM(NEWID())) % 12 + 1; 
  --DECLARE @BirthDay INT = ABS(CHECKSUM(NEWID())) % DAY(EOMONTH(DATEFROMPARTS(@BirthYear, @BirthMonth, 1))) + 1; 
  --DECLARE @BirthDate DATE = DATEFROMPARTS(@BirthYear, @BirthMonth, @BirthDay);
  
--  INSERT INTO DY_Employee (EmployeeID, Name, Title, BirthDate, HireDate)
--  VALUES (@n, @E_Name, 'Title ' + CAST(@n AS VARCHAR(10)), @BirthDate, DATEADD(day, -@n, GETDATE()));
  
--  SET @n = @n + 1;
--END;


--  For generating unique job title with limit of 3 alphabets
--DECLARE @n INT = 1;
--WHILE @n <= 500
--BEGIN
--  DECLARE @E_Name VARCHAR(50) = (SELECT TOP 1 Name FROM Data_Products ORDER BY NEWID());
--  DECLARE @E_Title VARCHAR(50) = (SELECT CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 2) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 3) % 26));
--  INSERT INTO DY_Employee (EmployeeID, Name, Title, BirthDate, HireDate)
--  VALUES (@n, @E_Name, @E_Title, DATEADD(year, -18, GETDATE()), DATEADD(day, -@n, GETDATE()));
--  SET @n = @n + 1;
--END;



select * from DY_Employee
select * from DY_EmployeeDetails
delete from DY_Employee where EmployeeID >= 1


-- Create Products table
drop table DY_Products
CREATE TABLE DY_Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(50),
    UnitPrice DECIMAL(8, 2),
	InStockProducts INT
);

-- Insert 500 unique records into Products table
delete from DY_Products where ProductID >= 1
DECLARE @i INT = 1;
WHILE @i <= 500
BEGIN
    DECLARE @Product VARCHAR(50) = (SELECT CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 2) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 3) % 26)+ ' ' + CHAR(65 + ABS(CHECKSUM(NEWID()) / 4) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 5) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 6) % 26));
    INSERT INTO DY_Products (ProductID, ProductName, UnitPrice, InStockProducts)
    VALUES (@i, @Product, ABS(CHECKSUM(NEWID())) % 1000, ABS(CHECKSUM(NEWID())) % 100);
    SET @i = @i + 1;
END;

--DECLARE @i INT = 1;
--WHILE @i <= 500
--BEGIN
--    INSERT INTO DY_Products (ProductID, ProductName, UnitPrice)
--    VALUES (@i, 'Product ' + CAST(@i AS VARCHAR(10)), ABS(CHECKSUM(NEWID())) % 1000 + 10.00);
--    SET @i = @i + 1;
--END;


delete from DY_ProductDetails where ProductID >= 1
-- Create ProductDetails table
drop table DY_ProductDetails
CREATE TABLE DY_ProductDetails (
    ProductID INT,
    Description VARCHAR(500),
    CONSTRAINT FK_ProductID FOREIGN KEY (ProductID) REFERENCES DY_Products(ProductID)
);

-- Insert 500 unique records into ProductDetails table
DECLARE @j INT = 1;
WHILE @j <= 500
BEGIN
    INSERT INTO DY_ProductDetails (ProductID, Description)
    VALUES (@j, 'Description for Product ' + CAST(@j AS VARCHAR(10)) + '...');
    SET @j = @j + 1;
END;


select * from DY_Products
select * from DY_ProductDetails

create table DY_Orders(
	OrderID int Primary key,
	OrderName varchar(max),
	OrderQty int,
	UnitPrice float
);
DECLARE @o INT = 1;
WHILE @o <= 500
BEGIN
    DECLARE @OrderName VARCHAR(50) = (SELECT CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 2) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 3) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 4) % 26));
    INSERT INTO DY_Orders (OrderID, OrderName, OrderQty, UnitPrice)
    VALUES (@o, @OrderName, ABS(CHECKSUM(NEWID())) % 100, ABS(CHECKSUM(NEWID())) % 1000);
    SET @o = @o + 1;
END;


drop table DY_OrdersDetails
create table DY_OrdersDetails(
	OrderID int,
	OrderDescriptions varchar(max),
	ProductID int,
	TotalOrdrAmt DECIMAL(8, 2),
	StockedQty int
	CONSTRAINT FK_OrderID FOREIGN KEY (OrderID) REFERENCES DY_Orders(OrderID)
);

DECLARE @od INT = 1;
WHILE @od <= 500
BEGIN
    DECLARE @OrderDescriptions VARCHAR(50) = (SELECT CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 2) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 3) % 26)+ ' ' + CHAR(65 + ABS(CHECKSUM(NEWID()) / 4) % 26) + ' ' +CHAR(65 + ABS(CHECKSUM(NEWID()) / 5) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 6) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 7) % 26) + ' ' + CHAR(65 + ABS(CHECKSUM(NEWID()) / 8) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 9) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 10) % 26) + '......');
    INSERT INTO DY_OrdersDetails (OrderID, OrderDescriptions, ProductID, TotalOrdrAmt,StockedQty)
    VALUES (@od, @OrderDescriptions, ABS(CHECKSUM(NEWID())) % 50, ABS(CHECKSUM(NEWID())) % 100000,ABS(CHECKSUM(NEWID())) % 1000);
    SET @od = @od + 1;
END;


select * from DY_Orders
select * from DY_OrdersDetails