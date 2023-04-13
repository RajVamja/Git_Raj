--  To activate this database
use RV355RajVamja


-- [1] Write a SQL statement to prepare a list with salesman name, customer name and their cities for the salesmen and customer who belongs to the same city.
SELECT s.salesman_name, c.cust_name, c.city
FROM customer AS c
INNER JOIN salesman AS s ON s.city = c.city;


-- [2] Write a SQL statement to make a list with order no, purchase amount, customer name and their cities for those orders which order amount between 500 and 2000
SELECT o.ord_no, o.purch_amt, c.cust_name, c.city
FROM customer AS c
INNER JOIN orders AS o ON c.customer_id = o.customer_id WHERE o.purch_amt BETWEEN 500 AND 2000;

-- [3] Write a SQL statement to know which salesman are working for which customer.
SELECT s.salesman_id, s.salesman_name, c.customer_id, c.cust_name
FROM customer AS c
INNER JOIN salesman AS s ON c.salesman_id = s.salesman_id;

-- [4]. Write a SQL statement to find the list of customers who appointed a salesman for their jobs who gets a commission from the company is more than 12%
SELECT s.salesman_id, c.customer_id, c.cust_name
FROM customer AS c
INNER JOIN salesman AS s ON c.salesman_id = s.salesman_id WHERE s.commission > 0.12;

-- [5] Write a SQL statement to find the list of customers who appointed a salesman for their jobs who does not live in the same city where their customer lives, and gets a commission is above 12%
SELECT s.salesman_id, c.customer_id, c.cust_name
FROM customer AS c
INNER JOIN salesman AS s ON c.salesman_id = s.salesman_id WHERE s.commission > 0.12 AND  c.city != s.city;

-- [6] Write a SQL statement to find the details of a order i.e. order number, order date, amount of order, which customer gives the order and which salesman works for that customer and how much commission he gets for an order.

SELECT o.*, c.cust_name, s.salesman_name, s.commission
FROM orders AS o
INNER JOIN customer AS c ON c.customer_id = o.customer_id
INNER JOIN salesman AS s ON s.salesman_id = o.salesman_id; 

-- [7] Write a SQL statement to make a join on the tables salesman, customer and orders in such a form that the same column of each table will appear once and only the relational rows will come.


-- [8] Write a SQL statement to make a list in ascending order for the customer who works either through a salesman or by own. 
SELECT * FROM customer WHERE salesman_id IS NOT NULL OR salesman_id IS NULL ORDER BY customer_id;


-- [9] Write a SQL statement to make a list in ascending order for the customer who holds a grade less than 300 and works either through a salesman or by own. 
SELECT * FROM customer WHERE grade < 300 AND salesman_id IS NOT NULL OR salesman_id IS NULL ORDER BY customer_id ;

-- [10] Write a SQL statement to make a report with customer name, city, order number, order date, and order amount in ascending order according to the order date to find that either any of the existing customers have placed no order or placed one or more orders.
SELECT c.customer_id, c.cust_name, c.city, o.ord_no, o.ord_date, o.purch_amt
FROM orders AS o
LEFT JOIN customer AS c ON c.customer_id = o.customer_id ORDER BY o.ord_date;

-- [11] Write a SQL statement to make a report with customer name, city, order number, order date, order amount salesman name and commission to find that either any of the existing customers have placed no order or placed one or more orders by their salesman or by own. 
SELECT c.cust_name, c.city, o.ord_no, o.ord_date, o.purch_amt, s.salesman_name, s.commission
FROM customer AS c
LEFT JOIN orders AS o ON c.customer_id = o.customer_id
LEFT JOIN salesman AS s ON s.salesman_id = o.salesman_id;

-- [12] Write a SQL statement to make a list in ascending order for the salesmen who works either for one or more customer or not yet join under any of the customers.  
SELECT distinct s.* 
FROM salesman AS s
LEFT JOIN customer AS c ON c.salesman_id = s.salesman_id ORDER BY s.salesman_id;

-- [13] Write a SQL statement to make a list for the salesmen who works either for one or more customer or not yet join under any of the customers who placed either one or more orders or no order to their supplier.
SELECT distinct s.* 
FROM salesman AS s
LEFT JOIN orders AS o ON s.salesman_id = o.salesman_id;

-- [14] Write a SQL statement to make a list for the salesmen who either work for one or more customers or yet to join any of the customer. The customer may have placed, either one or more orders on or above order amount 2000 and must have a grade, or he may not have placed any order to the associated supplier.

 SELECT DISTINCT s.*, o.purch_amt
FROM salesman AS s
LEFT JOIN customer AS c ON s.salesman_id = c.salesman_id
LEFT JOIN orders AS o ON o.customer_id = c.customer_id AND o.purch_amt > 2000
WHERE c.customer_id IS NULL OR c.grade IS NOT NULL;

-- [15] Write a SQL statement to make a report with customer name, city, order no. order date, purchase amount for those customers from the existing list who placed one or more orders or which order(s) have been placed by the customer who is not on the list.
SELECT  c.cust_name, c.city, o.ord_no, o.ord_date, o.purch_amt
FROM customer AS c
LEFT JOIN orders AS o ON o.customer_id = c.customer_id
WHERE c.customer_id IS NOT NULL OR o.customer_id NOT IN (SELECT customer_id FROM customer);

-- [16] Write a SQL statement to make a report with customer name, city, order no. order date, purchase amount for only those customers on the list who must have a grade and placed one or more orders or which order(s) have been placed by the customer who is neither in the list not have a grade. 
SELECT c.cust_name, c.city, o.ord_no, o.ord_date, o.purch_amt
FROM customer AS c
LEFT JOIN orders AS o ON c.customer_id = o.customer_id
WHERE c.customer_id IN (
    SELECT customer_id FROM orders
    UNION
    SELECT customer_id FROM customer
    WHERE customer_id NOT IN (SELECT DISTINCT customer_id FROM orders)
);

-- [17] Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa.
SELECT * FROM salesman CROSS JOIN customer;

-- [18] Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa for that customer who belongs to a city.
SELECT * FROM salesman CROSS JOIN customer WHERE salesman.city IS NOT NULL AND customer.city IS NOT NULL;

-- [19] Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa for those salesmen who belongs to a city and the customers who must have a grade. 
SELECT * FROM salesman CROSS JOIN customer 
WHERE salesman.city IS NOT NULL AND customer.city IS NOT NULL AND customer.grade IS NOT NULL;

-- [20] Write a SQL statement to make a cartesian product between salesman and customer i.e. each salesman will appear for all customer and vice versa for those salesmen who must belong a city which is not the same as his customer and the customers should have an own grade. 
SELECT * FROM salesman CROSS JOIN customer 
WHERE salesman.city <> customer.city AND customer.grade IS NOT NULL;

-- [21] Write a SQL query to display all the data from the item_mast, including all the data for each item's producer company.
SELECT im.*, cm.COM_NAME
FROM item_mast AS im
LEFT JOIN company_mast AS cm ON im.PRO_COM = cm.COM_ID;

-- [22] Write a SQL query to display the item name, price, and company name of all the product
SELECT im.PRO_NAME, im.PRO_PRICE, cm.COM_NAME
FROM item_mast AS im
LEFT JOIN company_mast AS cm ON im.PRO_COM = cm.COM_ID;

-- [23] Write a SQL query to display the average price of items of each company, showing the name of the company. 
SELECT im.PRO_COM, cm.COM_NAME, AVG(im.PRO_PRICE) AS Average_price
FROM company_mast AS cm
inner JOIN item_mast AS im ON im.PRO_COM = cm.COM_ID
GROUP BY cm.COM_NAME, im.PRO_COM;

-- [24] Write a SQL query to display the names of the company whose products have an average price larger than or equal to Rs. 350.
SELECT im.PRO_COM, cm.COM_NAME, AVG(im.PRO_PRICE) AS Average_price
FROM company_mast AS cm
LEFT JOIN item_mast AS im ON im.PRO_COM = cm.COM_ID
GROUP BY cm.COM_NAME, im.PRO_COM HAVING AVG(im.PRO_PRICE) >= 350;

-- [25] Write a SQL query to display the name of each company along with the ID and price for their most expensive product.
SELECT im.PRO_COM, cm.COM_NAME, MAX(im.PRO_PRICE) AS Average_price
FROM company_mast AS cm
inner JOIN item_mast AS im ON im.PRO_COM = cm.COM_ID
GROUP BY cm.COM_NAME, im.PRO_COM;

-- [26]  Write a query in SQL to display all the data of employees including their department
SELECT det.*, dep.DPT_NAME
FROM emp_details AS det
LEFT JOIN emp_department AS dep ON det.EMP_DEPT = dep.DPT_CODE;

-- [27]  Write a query in SQL to display the first name and last name of each employee, along with the name and sanction amount for their department.
SELECT det.EMP_FNAME, det.EMP_LNAME, dep.DPT_NAME, dep.DPT_ALLOTMENT AS [Sanction amount]
FROM emp_details AS det
LEFT JOIN emp_department AS dep ON det.EMP_DEPT = dep.DPT_CODE ORDER BY dep.DPT_NAME;

-- [28]  Write a query in SQL to find the first name and last name of employees working for departments with a budget more than Rs. 50000. 
SELECT det.EMP_FNAME, det.EMP_LNAME, dep.DPT_ALLOTMENT AS [Department budget]
FROM emp_details AS det
LEFT JOIN emp_department AS dep ON det.EMP_DEPT = dep.DPT_CODE WHERE dep.DPT_ALLOTMENT > 50000 ORDER BY dep.DPT_ALLOTMENT;

-- [29] Write a query in SQL to find the names of departments where more than two employees are working.
SELECT dep.DPT_NAME
FROM emp_details AS det
inner JOIN emp_department AS dep ON det.EMP_DEPT = dep.DPT_CODE
GROUP BY dep.DPT_NAME HAVING COUNT(*) > 2 ;

-- [30] Write a query to display all the orders from the orders table issued by the salesman 'Paul Adam'
SELECT o.*, s.salesman_name
FROM orders AS o
INNER JOIN salesman AS s ON o.salesman_id = s.salesman_id WHERE s.salesman_name = 'Paul Adam';

-- [31] Write a query to display all the orders for the salesman who belongs to the city London.
SELECT o.*, s.salesman_name
FROM orders AS o
INNER JOIN salesman AS s ON o.salesman_id = s.salesman_id WHERE s.city = 'London';

-- [32] Write a query to find all the orders issued against the salesman who may works for customer whose id is 3007.
SELECT  o.*
FROM salesman AS s
INNER JOIN orders AS o ON o.salesman_id = s.salesman_id   WHERE o.customer_id = 3007;

-- [33] Write a query to display all the orders which values are greater than the average order value for 10th October 2012.
SELECT * 
FROM orders 
WHERE purch_amt > (SELECT AVG(purch_amt) FROM orders WHERE ord_date = '2012-10-10');

-- [34] Write a query to find all orders attributed to a salesman in New york.
SELECT o.*, s.city
FROM orders AS o
INNER JOIN salesman AS s ON o.salesman_id = s.salesman_id WHERE s.city = 'New York';

-- [35] Write a query to count the customers with grades above New York's average
SELECT COUNT(*)as customers FROM customer C WHERE C.grade > (SELECT AVG(C.grade) FROM customer C WHERE C.city = 'New york');

-- [36] Write a query to display all the customers with orders issued on date 17th August, 2012
SELECT o.ord_no, o.customer_id, o.purch_amt,c.cust_name
FROM orders AS o
INNER JOIN customer AS c ON o.customer_id = c.customer_id WHERE o.ord_date = '2012-08-17';

-- [37] Write a query to find the name and numbers of all salesmen who had more than one customer. 
SELECT s.salesman_name, s.salesman_id, COUNT(c.customer_id) AS customer_count
FROM salesman AS s
INNER JOIN customer AS c ON s.salesman_id = c.salesman_id
GROUP BY s.salesman_name, s.salesman_id HAVING COUNT(c.customer_id) > 1;

-- [38] Write a query to find all orders with order amounts which are above-average amounts for their customers.
SELECT * FROM orders O
WHERE O.purch_amt > (SELECT AVG(OS.purch_amt) FROM orders OS GROUP BY OS.customer_id HAVING OS.customer_id = O.customer_id);













--39 . Write a queries to find all orders with order amounts which are on or above-average amounts for their customers.  
SELECT * FROM orders O
WHERE O.purch_amt >= (SELECT AVG(OS.purch_amt) FROM orders OS GROUP BY OS.customer_id HAVING OS.customer_id = O.customer_id);


--40 . Write a query to find the sums of the amounts from the orders table, grouped by date, eliminating all those dates where the sum was not at least 1000.00 above the maximum order amount for that date
SELECT O.ord_date, SUM(O.purch_amt) AS 'Sum of Orders' FROM orders O GROUP BY O.ord_date HAVING SUM(O.purch_amt) > 1000;



--41 . Write a query to extract the data from the customer table if and only if one or more of the customers in the customer table are located in London. 
SELECT * FROM customer C WHERE C.city = ANY (SELECT DISTINCT C.city FROM customer C);


--42 . Write a query to find the salesmen who have multiple customers. 
select s.salesman_id,count(c.customer_id) from salesman as s
inner join customer as c on c.salesman_id = s.salesman_id 
 group by s.salesman_id
 having count(c.customer_id)>1




--43 . Write a query to find all the salesmen who worked for only one customer
select s.salesman_id,s.salesman_name,count(c.customer_id) as [count of customers] from salesman as s
inner join customer as c on c.salesman_id = s.salesman_id 
 group by s.salesman_id, s.salesman_name
 having count(c.customer_id)=1

--44 . Write a query that extract the rows of all salesmen who have customers with more than one orders.
SELECT O.salesman_id , COUNT(O.ord_no) as [numbers of orders] FROM orders O GROUP BY O.salesman_id HAVING COUNT(O.customer_id) > 1;

--45 . Write a query to find salesmen with all information who lives in the city where any of the customers lives. 

--46 . Write a query to find all the salesmen for whom there are customers that follow them.
select distinct s.* from salesman as s
inner join customer as c on s.city = c.city

--47 . Write a query to display the salesmen which name are alphabetically lower than the name of the customers.
SELECT * FROM salesman WHERE salesman_name < ANY (SELECT DISTINCT cust_name FROM customer);

--48 . Write a query to display the customers who have a greater gradation than any customer who belongs to the alphabetically lower than the city New York.
SELECT * FROM customer WHERE grade > ANY(SELECT grade FROM CUSTOMER WHERE  city < 'New York');


--49 . Write a query to display all the orders that had amounts that were greater than at least one of the orders on September 10th 2012. 
select * from orders where purch_amt > ANY(select purch_amt from orders where ord_date = '2012-09-10')



--50 . Write a query to find all orders with an amount smaller than any amount for a customer in London.
select * from orders where purch_amt < any(select o.purch_amt from orders as o inner join customer as c on c.customer_id = o.customer_id where c.city = 'London' )


--51 . Write a query to display all orders with an amount smaller than any amount for a customer in London.


--52 . Write a query to display only those customers whose grade are, in fact, higher than every customer in New York. 

--53 . Write a query to find only those customers whose grade are, higher than every customer to the city New York. 

--54 . Write a query to get all the information for those customers whose grade is not as the grade of customer who belongs to the city London

--55 . Write a query to find all those customers whose grade are not as the grade, belongs to the city Paris.

--56 . Write a query to find all those customers who hold a different grade than any customer of the city Dallas.

--57 . Write a SQL query to find the average price of each manufacturer's products along with their name.
SELECT IM.PRO_COM,AVG(IM.PRO_PRICE) AS 'Avrage Price',CM.COM_NAME  FROM item_mast IM 
INNER JOIN company_mast CM ON CM.COM_ID = IM.PRO_COM 
GROUP BY IM.PRO_COM,CM.COM_NAME;



--58 . Write a SQL query to display the average price of the products which is more than or equal to 350 along with their names.
select im.pro_name, avg(im.pro_price) [average_price], cm.com_name from item_mast as im
inner join company_mast as cm on im.pro_com = cm.com_id
group by im.pro_name, cm.com_name
having  avg(im.pro_price) >= 350;


--59 . Write a SQL query to display the name of each company, price for their most expensive product along with their Name.
select  cm.com_name ,max(im.pro_price) from item_mast as im
inner join company_mast as cm on im.pro_com = cm.com_id
group by  cm.com_name

SELECT CM.COM_ID,CM.COM_NAME,MAX(IM.PRO_PRICE) AS 'Most Expensive' FROM item_mast IM 
INNER JOIN company_mast CM ON CM.COM_ID = IM.PRO_COM 
GROUP BY CM.COM_NAME,CM.COM_ID;


SELECT * FROM emp_details;
SELECT * FROM emp_department;
SELECT * FROM company_mast;
SELECT * FROM item_mast;
SELECT * FROM orders;
SELECT * FROM salesman;
SELECT * FROM customer;