--  To activate this database
use RV355RajVamja

-- Write a sql query for the 'T_Employees' table  creation 
CREATE TABLE T_Employees(
	EmployeeID INT,
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
	DesTitle VARCHAR(100),
	BirthDate DATE,
	HireDate DATE,
	ReportsTo VARCHAR(100),
	Addr VARCHAR(250)
); 
	INSERT INTO T_Employees(EmployeeID,FirstName,LastName,DesTitle,BirthDate,HireDate,ReportsTo,Addr)
	VALUES
		(1,'George','Mardy','Office Manager','1980-02-15','2023-01-02','Alex','67890 Birchwood Ave, New Orleans, LA 70112'),
		(2,'Joseph','Dosni','Regional Manager','1978-06-05','2022-01-01','Maria','11100 Birchwood Blvd, Nashville, TN 37201'),
		(3,'Mario','Saule','Human Resources Manager','1980-02-15','2023-02-06','Alex','5555 Maplewood Dr, Atlanta, GA 30303'),
		(4,'George','Robbin','Quality Control/Safety Manager','1988-07-05','2023-01-23','Alex','67890 Birchwood Ave, New Orleans, LA 70112'),
		(5,'Jhon','Dosni','Sales Representative','1990-11-26','2022-06-15','Alex','6666 Pineview Rd, Denver, CO 80202'),
		(6,'Enric','Manuel','Administrative Assistant','1997-08-15','2023-01-23','Maria','45678 Elmwood Dr, Austin, TX 78701'),
		(7,'Carlos','Foster','Accountant','1981-09-15','2022-03-16','Alex','7777 Cedar Lane, Houston, TX 77002'),
		(8,'Kuleswar','Sitaraman','Marketing Specialist','1970-08-03','2023-02-15','Maria','8888 Elmwood Ave, Philadelphia, PA 19102'),
		(9,'Hoag','Malfoy','Product Specialist','1977-08-24','2023-01-23','Maria','4194  Pine Ave, Madrid, FL 33130'),
		(10,'Alister','Thomsan','Assistant','1992-03-09','2022-12-01','Alex','12345 Oakdale Dr, Phoenix, AZ 85001')


-- Write a sql query for the 'T_Orders' table  creation 
CREATE TABLE T_Orders(
	OrderID INT,
	CustomerID INT,
	EmployeeID INT,
	OrderDate DATE
); 
INSERT INTO T_Orders(OrderID,CustomerID,EmployeeID,OrderDate)
	VALUES
		(1,1,1,'2019-02-12'),(2,2,2,'2018-11-11'),(3,3,3,'2023-01-19'),(4,4,4,'2023-02-18'),(5,5,5,'2023-03-02'),(6,6,6,'2017-12-29'),(7,7,7,'2017-12-29'),(8,8,8,'2017-12-29'),
        (9,3,3,'2020-09-06'),(10,1,1,'2017-04-22'),(11,6,6,'2020-12-31'), (12,7,4,'2016-06-17'), (13,8,4,'2019-10-27')


-- Write a sql query for the 'T_Customers' table  creation 
CREATE TABLE T_Customers(
	CustomerID INT,
	CompanyName VARCHAR(100),
	ContactName VARCHAR(100),
	ContactTitle VARCHAR(100),
	Addr VARCHAR(250),
	City VARCHAR(50),
	Country VARCHAR(50)
);
	INSERT INTO T_Customers(CustomerID,CompanyName,ContactName,ContactTitle,Addr,City,Country)
	VALUES
		(1,'HBO','Harry','Chief Executive Officer','123 Main St, Los Angeles, CA 90001','Los Angeles','USA'),
		(2,'Universal','Severus','Chief Financial Officer','456 Oak St, San Francisco, CA 94102','San Francisco','USA'),
		(3,'Warner Bros','Ron',' Executive Assistant','789 Maple Ave, New York, NY 10001','New York','USA'),
		(4,'LionsGate','Dobby','Product Manager','1010 Pine St, Seattle, WA 98101','Los Seattle','USA'),
		(5,'Focus','Jhon','Project Manager','1111 Elm St, Dallas, TX 75201','Dallas','USA'),
		(6,'Pixar','Draco','President','4444 Oakwood Ave, Miami, FL 33130','Miami','USA'),
		(7,'UNO','Lusius','Manager','6018 Maple Av Ave, London, FL 33130','Miami','UK'),
		(8,'Hogwards','John','Product Manager','4194  Pine Ave, Madrid, FL 33130','Madrid','Spain'),
		(9,'Unicorn','Moris','Social Media Handler','11100 Birchwood Blvd, Nashville, TN 37201','Moscow','Russia'),
		(10,'5Star','Luthar','Developer','9999 Maple Lane, San Diego, CA 92101','Manitoba','Canada')


-- Write a SQL query to retrieve the list of all orders made by customers in the "USA".
SELECT o.OrderID, c.CompanyName, c.ContactName, c.ContactTitle, c.City
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON o.CustomerID = c.CustomerID
WHERE c.Country = 'USA';


-- Write a SQL query to retrieve the list of all customers who have placed an order.
SELECT c.CustomerID, o.OrderID, c.CompanyName, c.ContactName
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID ORDER BY c.CustomerID;


-- Write a SQL query to retrieve the list of all employees who have not yet placed an order.
SELECT e.EmployeeID, e.FirstName, e.LastName
FROM T_Employees AS e
LEFT JOIN T_Orders AS o ON e.EmployeeID = o.EmployeeID
WHERE o.EmployeeID is NULL;


-- Write a SQL query to retrieve the list of all employees who have placed an order.
SELECT *
FROM T_Employees AS e
INNER JOIN T_Orders AS o ON e.EmployeeID = o.EmployeeID
ORDER BY e.EmployeeID;


-- Write a SQL query to retrieve the list of all customers who have not yet placed an order.
SELECT c.CustomerID, c.CompanyName, c.ContactName, c.ContactTitle, c.Addr, c.City, c.Country
FROM T_Customers AS c
LEFT JOIN T_Orders AS o ON c.CustomerID = o.CustomerID  WHERE o.CustomerID IS NULL;


-- Write a SQL query to retrieve the list of all customers who have placed an order, along with the order date.
SELECT c.CustomerID, o.OrderDate,c.CompanyName, c.ContactName, c.ContactTitle, c.Addr, c.City, c.Country
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID  ORDER BY c.CustomerID;


-- Write a SQL query to retrieve the list of all orders placed by a particular customer.
SELECT o.OrderID, o.CustomerID, o.OrderDate, c.ContactName 
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON o.CustomerID = c.CustomerID  ORDER BY c.CustomerID;


-- Write a SQL query to retrieve the list of all orders placed by a particular employee.
SELECT o.OrderID, o.EmployeeID, o.OrderDate, e.FirstName, e.LastName  
FROM T_Orders AS o
INNER JOIN T_Employees AS e ON o.EmployeeID = e.EmployeeID  ORDER BY e.EmployeeID;


-- Write a SQL query to retrieve the list of all orders placed by a particular customer on a particular date.
SELECT o.OrderID, c.CustomerID, o.OrderDate, c.ContactName
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID  ORDER BY c.CustomerID;


-- Write a SQL query to retrieve the list of all customers who have not yet placed an order, sorted by their country.
SELECT c.CustomerID, c.CompanyName, c.ContactName, c.ContactTitle, c.Addr, c.City, c.Country
FROM T_Customers AS c
LEFT JOIN T_Orders AS o ON c.CustomerID = o.CustomerID  WHERE o.CustomerID IS NULL ORDER BY Country;


-- Write a SQL query to retrieve the list of all orders placed by customers in the "USA", sorted by order date.
SELECT o.OrderID, o.OrderDate,c.CompanyName, c.ContactName, c.ContactTitle, c.City, c.Country
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON o.CustomerID = c.CustomerID
WHERE c.Country = 'USA' ORDER BY o.OrderDate;


-- Write a SQL query to retrieve the list of all employees who have not yet placed an order, sorted by last name.
SELECT e.*
FROM T_Employees AS e
LEFT JOIN T_Orders AS o ON o.EmployeeID = e.EmployeeID
WHERE o.EmployeeID IS NULL ORDER BY e.LastName;


-- Write a SQL query to retrieve the list of all customers who have placed an order, sorted by their company name.
SELECT c.*, o.OrderID,o.OrderDate
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID ORDER BY c.CompanyName;


-- Write a SQL query to retrieve the list of all employees who have placed an order, sorted by their hire date.
SELECT o.OrderID, e.*
FROM T_Employees AS e
INNER JOIN T_Orders AS o ON o.EmployeeID = e.EmployeeID ORDER BY e.HireDate;


-- Write a SQL query to retrieve the list of all customers who have placed an order on a particular date, sorted by their company name.
SELECT o.OrderID, o.OrderDate, c.*
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID ORDER BY c.CompanyName;


-- Write a SQL query to retrieve the list of all customers who have placed an order, along with the employee who handled the order.
SELECT  e.EmployeeID, c.*, o.OrderID, o.OrderDate, CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName]
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID
INNER JOIN T_Employees AS e ON e.EmployeeID = o.EmployeeID ORDER BY c.CustomerID;


-- Write a SQL query to retrieve the list of all employees who have placed an order, along with the customer who placed the order.
SELECT o.OrderID, o.OrderDate, e.*, c.*
FROM T_Orders AS o
INNER JOIN T_Employees AS e ON e.EmployeeID = o.EmployeeID
INNER JOIN T_Customers AS c ON c.CustomerID = o.CustomerID ;


-- Write a SQL query to retrieve the list of all orders placed by customers in a particular country, along with the customer name and order date.
SELECT o.OrderID, o.OrderDate, c.ContactName, c.Country
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON c.CustomerID = o.CustomerID WHERE c.Country = 'Spain';



-- Write a SQL query to retrieve the list of all orders placed by employees who were born in a particular year, along with the employee name and order date.
SELECT o.OrderID, e.EmployeeID, o.OrderDate, CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName], e.BirthDate
FROM T_Employees AS e
INNER JOIN T_Orders AS o ON e.EmployeeID = o.EmployeeID WHERE YEAR(e.BirthDate) = '1980';


-- Write a SQL query to retrieve the list of all customers who have placed an order, along with the customer name, order date, and employee who handled the order.
SELECT o.OrderID, o.OrderDate, c.ContactName, CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName who Handled the order]
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON c.CustomerID = o.CustomerID
INNER JOIN T_Employees AS e ON e.EmployeeID = o.EmployeeID;



-- Write a SQL query to retrieve the list of all orders placed by customers who have a particular contact title, along with the customer name and order date.
SELECT o.OrderID, o.OrderDate, c.ContactName, c.ContactTitle
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID WHERE c.ContactTitle = 'Product Manager';



-- Write a SQL query to retrieve the list of all orders placed by employees who have a particular job title, along with the employee name and order date.
SELECT o.OrderID, o.OrderDate, CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName], e.DesTitle
FROM T_Employees AS e
INNER JOIN T_Orders AS o ON e.EmployeeID = o.EmployeeID WHERE e.DesTitle = 'Human Resources Manager';



-- Write a SQL query to retrieve the list of all customers who have placed an order on a particular date, along with the customer name, order date, and employee who handled the order.
SELECT o.OrderID, o.OrderDate, c.ContactName, CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName who Handled the order]
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON c.CustomerID = o.CustomerID 
INNER JOIN T_Employees AS e ON e.EmployeeID = o.EmployeeID WHERE o.OrderDate = '2017-12-29';



-- Write a SQL query to retrieve the list of all orders placed by customers in a particular city, along with the customer name and order date.
SELECT o.OrderID, o.OrderDate, c.ContactName, c.City
FROM T_Customers AS c
INNER JOIN T_Orders AS o ON c.CustomerID = o.CustomerID WHERE c.City = 'Miami';


-- Write a SQL query to retrieve the list of all orders placed by employees who were born in a particular city, along with the employee name and order date.
SELECT  o.OrderID, o.OrderDate, CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName]
FROM T_Employees AS e
INNER JOIN T_Orders AS o ON e.EmployeeID = o.EmployeeID WHERE e.Addr = '45678 Elmwood Dr, Austin, TX 78701';


-- Write a SQL query to retrieve the list of all customers who have placed an order, along with the customer name, order date, and employee who handled the order, sorted by order date.
SELECT o.OrderID, o.OrderDate, c.CustomerID, c.ContactName, CONCAT(e.FirstName,' ',e.LastName) AS [EmployeeName]
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON c.CustomerID = o.CustomerID
INNER JOIN T_Employees AS e ON e.EmployeeID = o.EmployeeID  ORDER BY o.OrderDate;


-- Write a SQL query to retrieve the list of all orders placed by customers in a particular country, along with the customer name and order date, sorted by order date.
SELECT o.OrderID, c.CustomerID, o.OrderDate, c.ContactName
FROM T_Orders AS o
INNER JOIN T_Customers AS c ON c.CustomerID = o.CustomerID WHERE c.Country = 'USA' ORDER BY o.OrderDate;

SELECT * FROM T_Employees;
SELECT * FROM T_Orders;
SELECT * FROM T_Customers;

-- Write a SQL query to retrieve the list of all orders placed by customers in a particular country, along with the customer name and order date, sorted by order date.
select o.OrderID, o.OrderDate, c.CustomerID, c.ContactName, c.City from T_Orders as o
inner join T_Customers as c on o.CustomerID = c.CustomerID
order by  o.OrderDate;