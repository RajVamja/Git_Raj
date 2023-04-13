--  To activate this database
use RV355RajVamja

-- Write a sql query for the 'Tab_Employees' table  creation 
CREATE TABLE Tab_Employees(
	Employee_Id INT,
	Emplpyee_Name TEXT,
	Department TEXT,
	Salary NUMERIC,
	Hire_Date DATE
); 

	INSERT INTO Tab_Employees(Employee_Id,Employee_Name,Department,Salary,Hire_Date)
	VALUES
		(1,'Michale','IT',28000,'2023-01-23'),
		(2,'Carlos','HR',33000,'2023-01-23'),
		(3,'Enric','IT',28000,'2023-01-23'),
		(4,'Jhon','Finance',39000,'2023-01-23'),
		(5,'Joseph','IT',25000,'2023-01-23'),
		(6,'Zanifer','IT',35000,'2023-01-23'),
		(7,'Kuleswar','HR',57000,'2023-01-23'),
		(8,'Henrey','Finance',25000,'2023-01-23'),
		(9,'Alex','IT',25000,'2023-01-23'),
		(10,'George','Finance',27000,'2023-01-23'),
		(11,'Alan','HR',33000,'2023-01-23'),
		(12,'Haryy','RD',66000,'2023-01-23'),
		(13,'Ron','QC',51000,'2023-01-23'),
		(14,'Hermione','Finance',33000,'2023-01-23'),
		(15,'Jinny','IT',33000,'2023-01-23'),
		(16,'Draco','IT',57000,'2023-01-23'),
		(17,'Dobby','Sales',33000,'2023-01-23'),
		(18,'Albus','Sales',33000,'2023-01-23'),
		(19,'Severus','Sales',35000,'2022-01-01'),
		(20,'Sirius','Sales',39000,'2022-10-23'),
		(21,'McGonigal','HR',30000,'2022-11-01'),
		(22,'Hagrid','IT',29000,'2022-10-01'),
		(23,'Tom','QC',49000,'2023-03-10')



-- How many employees are in the table?
SELECT COUNT (Employee_Id) AS [Total Nnumber of employees] FROM Tab_Employees;
 
-- What is the highest salary in the table?
SELECT MAX(Salary) AS [Highest salary] FROM Tab_Employees;

-- What is the average salary by department?
SELECT AVG(Salary) AS [Average salary] FROM Tab_Employees;

-- Who are the top 5 highest paid employees?
SELECT TOP 5 * FROM Tab_Employees ORDER BY Salary DESC;

--How many employees were hired in the last year?
SELECT * FROM Tab_Employees WHERE YEAR (Hire_Date) = YEAR(CURRENT_TIMESTAMP) - 1;
SELECT * FROM Tab_Employees WHERE month (Hire_Date) = month(CURRENT_TIMESTAMP) - 1;


--How do you select all columns from a table named "employees"?
SELECT * FROM Tab_Employees;

--How do you select only the "employee_id" and "employee_name" columns from a table named "employees"?
SELECT Employee_Id, Employee_Name FROM Tab_Employees;

--How do you filter records in a table named "employees" to only include those where the "salary" column is greater than or equal to 50000?
SELECT * FROM Tab_Employees WHERE Salary >= 50000 ;

--How do you filter records in a table named "employees" to only include those where the "department" column is "Sales"?
SELECT * FROM Tab_Employees WHERE Department = 'Sales' ;

--How do you filter records in a table named "employees" to only include those where the "hire_date" column is between January 1, 2022 and December 31, 2022?
SELECT * FROM Tab_Employees WHERE Hire_Date BETWEEN '2022-01-01' AND '2022-12-31';

--How do you calculate the average salary of all employees in a table named "employees"?
SELECT AVG(Salary) AS [Average salary of employee] FROM Tab_Employees;

--How do you calculate the total salary of all employees in a table named "employees"?
SELECT SUM(Salary) AS [Total of employee salary] FROM Tab_Employees;

--How do you calculate the highest salary in a table named "employees"?
SELECT MAX(Salary) AS [Highest salary] FROM Tab_Employees;

--How do you calculate the lowest salary in a table named "employees"?
SELECT MIN(Salary) AS [Lowest salary] FROM Tab_Employees;

--How do you calculate the number of employees in a table named "employees"?
SELECT COUNT(Employee_Id) AS [Total employee] FROM Tab_Employees;

--How do you sort the records in a table named "employees" by the "salary" column in ascending order?
SELECT * FROM Tab_Employees ORDER BY Salary;

--How do you sort the records in a table named "employees" by the "salary" column in descending order?
SELECT * FROM Tab_Employees ORDER BY Salary DESC;

--How do you count the number of employees in each department in a table named "employees"?
SELECT Department, COUNT(Employee_Id) AS [Number of employees] FROM Tab_Employees GROUP BY Department;

--How do you select the first 10 records in a table named "employees"?
SELECT TOP 10 * FROM Tab_Employees;

--How do you select the last 10 records in a table named "employees"?
SELECT TOP 10 * FROM Tab_Employees ORDER BY Employee_Id DESC;

--How do you select the top 5 highest paid employees from a table named "employees"?
SELECT TOP 5 * FROM Tab_Employees ORDER BY Salary DESC;

--How do you select the top 10 highest paid employees from a table named "employees"?
SELECT TOP 10 * FROM Tab_Employees ORDER BY Salary DESC;

--How do you select the bottom 5 lowest paid employees from a table named "employees"?
SELECT TOP 5 * FROM Tab_Employees ORDER BY Salary;

--How do you select the employees who have a salary that is above the average salary in a table named "employees"?
SELECT * FROM Tab_Employees WHERE Salary >= 36750.000000 ;

--How do you select the employees who have a salary that is below the average salary in a table named "employees"?
SELECT * FROM Tab_Employees WHERE Salary <= 36750.000000 ;

--How do you select the employees who have a salary that is between 40000 and 60000 in a table named "employees"?
SELECT * FROM Tab_Employees WHERE Salary betweeN 40000 and 60000 ;

--How do you calculate the total salary of all employees in each department in a table named "employees"?
SELECT Department, SUM(Salary) AS [Total of employee salary] FROM Tab_Employees GROUP BY Department;

--How do you calculate the average salary of all employees in each department in a table named "employees"?
SELECT Department, AVG(Salary) AS [Average of employee salary] FROM Tab_Employees GROUP BY Department;

--How do you calculate the highest salary of all employees in each department in a table named "employees"?
SELECT Department, MAX(Salary) AS [Maximum salary in department] FROM Tab_Employees GROUP BY Department;

--How do you calculate the lowest salary of all employees in each department in a table named "employees"?
SELECT Department, MIN(Salary) AS [Minimum salary in department] FROM Tab_Employees GROUP BY Department;

--How do you select the employees who have been hired in the last year from a table named "employees"?
SELECT * FROM Tab_Employees WHERE YEAR (Hire_Date) = YEAR(CURRENT_TIMESTAMP) - 1;

--How do you select the employees who have been hired in the last 6 months from a table named "employees"?
SELECT * FROM Tab_Employees WHERE DATEDIFF (MONTH, Hire_Date,CURRENT_TIMESTAMP) <= 6;
select * from Tab_Employees where MONTH (Hire_Date) = MONTH(CURRENT_TIMESTAMP)-1;

select * from Tab_Employees where DATEdiff (YEAR, Hire_Date, CURRENT_TIMESTAMP) <= 3

--How do you select the employees who have been hired in the last 3 months from a table named "employees"?
SELECT * FROM Tab_Employees WHERE DATEDIFF (MONTH, Hire_Date,CURRENT_TIMESTAMP) <= 1;
select * from Tab_Employees where MONTH(Hire_Date) = MONTH(CURRENT_TIMESTAMP) - 1

--How do you select the employees who have been hired in the last week from a table named "employees"?
SELECT * FROM Tab_Employees WHERE DATEDIFF (WEEk, Hire_Date,CURRENT_TIMESTAMP) <= 3;

--How do you select the employees who have a name that starts with the letter "A" in a table named "employees"?
SELECT * FROM Tab_Employees WHERE Employee_Name LIKE 'A%';

--How do you select the employees who have a name that ends with the letter "s" in a table named "employees"?
SELECT * FROM Tab_Employees WHERE Employee_Name LIKE '%s';


SELECT * FROM Tab_Employees;