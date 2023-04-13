use RV355RajVamja;
create database RV355RajVamja
use RV355RajVamja

CREATE TABLE CUSTOMERS (
	CUST_ID INT IDENTITY(1,1) PRIMARY KEY,
	CUST_NAME VARCHAR(250) NOT NULL,
	CUST_ADDRESS VARCHAR(MAX),
	CUST_BALANCE DECIMAL(10,2) NOT NULL
);

CREATE TABLE PRODUCTS(
	PRO_ID INT IDENTITY(1,1) PRIMARY KEY,
	PRO_NAME VARCHAR(250) NOT NULL,
	PRO_PRICE DECIMAL(10,2) NOT NULL
);

CREATE TABLE ORDERS_ (
	ORDER_ID INT IDENTITY(1,1) PRIMARY KEY,
	ORDER_DATE DATE NOT NULL,
	QUANTITY INT NOT NULL,
	PAY_STATUS VARCHAR(10) NOT NULL CHECK (PAY_STATUS IN ('PAID','UNPAID')),
	CUST_ID INT NOT NULL,
	PRO_ID INT NOT NULL,
	FOREIGN KEY (CUST_ID) REFERENCES CUSTOMERS(CUST_ID),
	FOREIGN KEY (PRO_ID) REFERENCES PRODUCTS(PRO_ID)
);

INSERT INTO CUSTOMERS (CUST_NAME,CUST_ADDRESS,CUST_BALANCE) 
VALUES
('Sashenka Clarycott', '0438 Mifflin Terrace', '5625.83'),
('Olivero Triswell', '60 Warbler Point', '5265.87'),
('Shepherd O'' Shea', '744 Crescent Oaks Trail', '6074.64'),
('Ezmeralda Cartin', '5 David Alley', '5854.99'),
('Enrique Stogill', '48889 Farmco Hill', '7383.32'),
('Cassaundra Whetland', '8820 Karstens Parkway', '8430.55'),
('Jamesy Rowe', '9 Sage Drive', '9264.34'),
('Heath Lias', '86362 Moulton Avenue', '8166.91'),
('Hildagarde Garretts', '004 Columbus Parkway', '8631.59'),
('Gerhardine Chiswell', '1660 Fairfield Parkway', '6913.19'),
('Abigale Duesbury', '81 Mesta Street', '9623.77'),
('Elladine Rossborough', '437 Knutson Place', '8234.43'),
('Constanta Venturoli', '62 2nd Place', '9266.10'),
('Shanie Varndall', '97 Eagan Street', '5829.89'),
('Mahmoud Roskrug', '11 Dunning Park', '9390.88'),
('Fenelia Saer', '3155 Alpine Road', '6857.52'),
('Catharina Sainer', '0 Pearson Crossing', '6377.45'),
('Calhoun Finnigan', '49757 Stuart Place', '5024.06'),
('Sallee Sodo', '85658 Hagan Road', '7236.29'),
('Todd Hoyes', '1519 Duke Avenue', '5528.70');


INSERT INTO PRODUCTS(PRO_NAME,PRO_PRICE) 
VALUES
('Southern Comfort', '777.29'),
('Cheese - Roquefort Pappillon', '329.89'),
('Lettuce - Radicchio', '407.82'),
('Long Island Ice Tea', '495.44'),
('Roe - White Fish', '907.42'),
('Emulsifier', '623.96'),
('Wine - Wyndham Estate Bin 777', '303.84'),
('Beef - Rouladin, Sliced', '651.14'),
('Pepper - Green Thai', '809.66'),
('Pie Filling - Apple', '338.23'),
('Nougat - Paste / Cream', '278.51'),
('Oats Large Flake', '960.83'),
('Veal - Sweetbread', '206.06'),
('Oil - Canola', '640.94'),
('Arctic Char - Fillets', '686.10'),
('Containter - 3oz Microwave Rect.', '318.53'),
('Hold Up Tool Storage Rack', '887.98'),
('Trout Rainbow Whole', '561.72'),
('Cheese - Stilton', '472.64'),
('Versatainer Nc - 888', '970.25');


INSERT INTO ORDERS_(ORDER_DATE,QUANTITY,PAY_STATUS,CUST_ID,PRO_ID) 
VALUES
('4/7/2022', 4, 'UNPAID', 4, 9),
('5/6/2022', 4, 'PAID', 3, 5),
('4/26/2022', 3, 'PAID', 11, 13),
('6/11/2022', 3, 'PAID', 3, 12),
('11/10/2022', 4, 'UNPAID', 11, 14),
('8/4/2022', 3, 'PAID', 2, 12),
('5/30/2022', 2, 'UNPAID', 10, 6),
('1/21/2023', 3, 'UNPAID', 8, 15),
('2/23/2023', 2, 'PAID', 10, 3),
('5/17/2022', 4, 'UNPAID', 8, 10),
('8/27/2022', 2, 'UNPAID', 3, 7),
('4/28/2022', 4, 'UNPAID', 7, 12),
('11/11/2022', 4, 'PAID', 7, 13),
('12/18/2022', 3, 'UNPAID', 8, 14),
('10/9/2022', 4, 'UNPAID', 10, 5),
('2/14/2023', 1, 'PAID', 5, 12),
('5/31/2022', 4, 'PAID', 4, 6),
('1/3/2023', 2, 'PAID', 14, 13),
('1/23/2023', 1, 'PAID', 4, 15),
('12/1/2022', 1, 'UNPAID', 7, 11),
('7/21/2022', 1, 'PAID', 12, 15),
('11/30/2022', 1, 'UNPAID', 12, 13),
('1/7/2023', 2, 'PAID', 8, 10),
('10/20/2022', 1, 'UNPAID', 10, 11),
('8/22/2022', 1, 'UNPAID', 14, 15),
('8/22/2022', 2, 'PAID', 9, 5),
('9/30/2022', 3, 'UNPAID', 4, 10),
('2/16/2023', 1, 'PAID', 10, 14),
('4/30/2022', 2, 'PAID', 6, 15),
('10/19/2022', 3, 'PAID', 6, 9),
('5/20/2022', 2, 'PAID', 9, 2),
('4/6/2022', 2, 'UNPAID', 11, 6),
('2/1/2023', 2, 'UNPAID', 11, 7),
('5/7/2022', 3, 'PAID', 9, 1),
('8/11/2022', 2, 'PAID', 3, 2),
('4/20/2022', 2, 'UNPAID', 12, 8),
('11/13/2022', 1, 'UNPAID', 2, 3),
('12/26/2022', 1, 'PAID', 8, 15),
('11/10/2022', 3, 'PAID', 10, 12),
('11/2/2022', 3, 'UNPAID', 6, 5);




--1.Create a stored procedure called "get_customers" that returns all customers from the "customers" table.
	CREATE PROCEDURE SP_get_customers
	AS
	BEGIN
		SELECT * FROM CUSTOMERS;
	END
	EXEC SP_get_customers;

--2.Create a stored procedure called "get_orders" that returns all orders from the "orders" table.
alter proc get_orders
as
begin
     select * from ORDERS_
end
exec get_orders;

--3.Create a stored procedure called "get_order_details" that accepts an order ID as a parameter and returns the details of that order (i.e., the products and quantities)
alter proc get_order_details (@O_Id int)
as
begin
     select o.ORDER_ID,  p.PRO_NAME, o.quantity  from orders_ as o
	 inner join PRODUCTS as p on o.pro_id = p.pro_id
	 where ORDER_ID = @O_Id
 end    
 exec get_order_details 5;


 --4.Create a stored procedure called "get_customer_orders" that accepts a customer ID as a parameter and returns all orders for that customer.

 alter proc get_customer (@c_id int)
 as 
 begin
       select * from orders_ where cust_id = @c_id
 end
 exec get_customer 6;


 
--5.Create a stored procedure called "get_order_total" that accepts an order ID as a parameter and returns the total amount of the order.
create proc total (@O_id int)
as
begin
     select o.order_id, p.pro_price
	 from orders_ as o
	 inner join products as p on o.pro_id = p.pro_id
	 where order_id = @O_id
end
exec total 8;



--6.Create a stored procedure called "get_product_list" that returns a list of all products from the "products" table.
create proc get_product_list 
as
begin
      select * from products  
end
exec get_product_list


--7.Create a stored procedure called "get_product_info" that accepts a product ID as a parameter and returns the details of that product.
create proc get_product_info (@Pid int)
as
begin
      select * from products where pro_id = @Pid
end
exec get_product_info 4;

--8.Create a stored procedure called "get_customer_info" that accepts a customer ID as a parameter and returns the details of that customer.
create proc get_customer_info (@Cid int)
as
begin
      select * from customers where cust_id = @Cid
end
exec get_customer_info 9;


--9.Create a stored procedure called "update_customer_info" that accepts a customer ID and new information as parameters and updates the customer's information in the "customers" table.
create proc update_customer_info (@Cid int, @Cname varchar(max), @Cadd nvarchar(max), @Cbal float)
as
begin
      update customers
	  set cust_name = @Cname,
	      cust_address = @Cadd,
		  cust_balance = @Cbal
	  where cust_id = @Cid;
end
begin tran
exec update_customer_info 1, 'Raj', 'D-601, shivplaza', 4000.30;
commit tran
rollback tran

--10.Create a stored procedure called "delete_customer" that accepts a customer ID as a parameter and deletes that customer from the "customers" table.
create proc delete_customer (@Cid int)
as
begin
      delete from customers where cust_id = @Cid
end

begin tran 
exec delete_customer 1;
commit tran
rollback tran

--11.Create a stored procedure called "get_order_count" that accepts a customer ID as a parameter and returns the number of orders for that customer.
alter proc get_order_count (@Cid int)
as
begin
     select  cust_id, count(order_id) as [Total orders] from orders_ group by cust_id having cust_id = @Cid
end

exec get_order_count 6



--12.Create a stored procedure called "get_customer_balance" that accepts a customer ID as a parameter and returns the customer's balance (i.e., the total amount of all orders minus the total amount of all payments).

alter PROCEDURE SP_get_customer_balance(@C_ID INT)
	AS 
	BEGIN
		SELECT O.CUST_ID,CUST_BALANCE-SUM(P.PRO_PRICE*O.QUANTITY) FROM CUSTOMERs C 
		INNER JOIN ORDERs_ O ON C.CUST_ID = O.CUST_ID 
		INNER JOIN PRODUCTs P ON O.PRO_ID = P.PRO_ID 
		WHERE O.PAY_STATUS = 'PAID' AND O.CUST_ID = @C_ID
		GROUP BY O.CUST_ID,C.CUST_BALANCE 
	END
EXEC SP_get_customer_balance 11;

--13.Create a stored procedure called "get_customer_payments" that accepts a customer ID as a parameter and returns all payments made by that customer.
create proc payments (@Cid int)
as
begin
     select * from orders_ where pay_status = 'PAID' AND cust_id = @Cid
end
exec payments 3;


--14.Create a stored procedure called "add_customer" that accepts a name and address as parameters and adds a new customer to the "customers" table.



--15.Create a stored procedure called "get_top_products" that returns the top 10 products based on sales volume.
	alter PROCEDURE SP_get_top_products
	AS
	BEGIN
		SELECT TOP 10 O.PRO_ID,SUM(O.QUANTITY) AS 'Total Orders' FROM ORDERs_ O 
		GROUP BY O.PRO_ID 
		ORDER BY SUM(O.QUANTITY) DESC;
	END

	EXEC SP_get_top_products;


--16.Create a stored procedure called "get_product_sales" that accepts a product ID as a parameter and returns the total sales volume for that product.
	alter PROCEDURE SP_get_product_sales(@P_ID INT)
	AS 
	BEGIN
		SELECT O.PRO_ID,SUM(O.QUANTITY) as [total sales volume] FROM ORDERs_ O
		GROUP BY O.PRO_ID HAVING O.PRO_ID = @P_ID;
	END

	EXEC SP_get_product_sales 10;


--17.Create a stored procedure called "get_customer_orders_by_date" that accepts a customer ID and date range as parameters and returns all orders for that customer within the specified date range.
	CREATE PROCEDURE SP_get_customer_orders_by_date(@C_ID INT, @FROM_DATE DATE, @TO_DATE DATE)
	AS
	BEGIN
		SELECT * FROM ORDERs_ O 
		WHERE O.CUST_ID = @C_ID
			AND O.ORDER_DATE BETWEEN @FROM_DATE AND @TO_DATE
	END

	EXEC SP_get_customer_orders_by_date 4, '2023-01-01', '2023-02-01';


--18.Create a stored procedure called "get_order_details_by_date" that accepts an order ID and date range as parameters and returns the details of that order within the specified date range.
alter proc get_order_details_by_date (@Oid int, @Fdate date, @Tdate date)
as
begin
      select * from orders_
	  where order_id = @Oid And
	  order_date between @Fdate AND @Tdate
end
exec get_order_details_by_date 4, '2022-04-26', '2022-11-10';

--19.Create a stored procedure called "get_product_sales_by_date" that accepts a product ID and date range as parameters and returns the total sales volume for that product within the specified date range.
alter proc get_product_sales_by_date (@Oid int, @Fdate date, @Tdate date)
as
begin
      select p.pro_id, sum(o.quantity*p.pro_price) from orders_ as o
	  inner join products as p on o.pro_id = p.pro_id
	  where p.pro_id = @Oid And order_date between @Fdate AND @Tdate
	  group by p.pro_id
end
exec get_product_sales_by_date 14, '2022-11-10', '2023-02-16';



--23.Create a stored procedure called "delete_order" that accepts an order ID as a parameter and deletes that order from the "orders" table.
alter proc delete_order(@Oid int)
as
begin
	 delete from orders_ where order_id = @Oid;
end


begin tran
exec delete_order 4;
commit tran
rollback tran





create function func_ (@status varchar(20))
returns table
as
return(select * from orders_ where pay_status = @status)

select * from dbo.func_('PAID')


alter function func_ ()
returns table
as
return(select * from orders_ where pay_status = 'PAID')

select * from dbo.func_()


SELECT * FROM PRODUCTS;
SELECT * FROM ORDERS_;
SELECT * FROM CUSTOMERS;



-- Create a stored procedure called "add_order" that accepts a customer ID, order date, and total amount as parameters and adds a new order to the "orders" table.
alter proc SP_add_order(@date date, @qua int, @status varchar(20), @c_id int, @p_id int)
as
begin
     insert into orders_(ORDER_DATE,QUANTITY,PAY_STATUS,CUST_ID,PRO_ID)
	 values(@date,@qua,@status,@c_id,@p_id);
end

exec SP_add_order '2001-08-24', 0, 'PAID', 2, 3;

--19.Create a stored procedure called "get_product_sales_by_date" that accepts a product ID and date range as parameters and returns the total sales volume for that product within the specified date range.
create proc SP_sales_by_date(@p_id int, @Sdate date, @Edate date)
as
begin
      select p.pro_id, p.Pro_name, sum(p.Pro_price * o.quantity) from products as p
	  inner join orders_ as o on p.pro_id = o.pro_id
	  where p.pro_id = @p_id and o.order_date between @Sdate and @Edate
	  group by p.pro_id, p.Pro_name
end

exec SP_sales_by_date 12, '2022-06-11', '2022-11-10'

--16.Create a stored procedure called "get_product_sales" that accepts a product ID as a parameter and returns the total sales volume for that product.
create proc S_get_product_sales(@p_id int)
as
begin
      select p.pro_id, p.pro_name, sum(p.pro_price * o.quantity) from products as p
	  inner join orders_ as o on p.pro_id = o.pro_id
	  group by p.pro_id, p.pro_name
	  having p.pro_id = @p_id
end

exec S_get_product_sales 2;

alter function f_raj(@p_id int)
returns table
as
return(
      select p.pro_id, p.pro_name, sum(p.pro_price * o.quantity) as [sales volume] from products as p
	  inner join orders_ as o on p.pro_id = o.pro_id
	  group by p.pro_id, p.pro_name
	  having p.pro_id = @p_id
	  )

select * from dbo.f_raj(2);


--17.Create a stored procedure called "get_customer_orders_by_date" that accepts a customer ID and date range as parameters and returns all orders for that customer within the specified date range.
create proc get_customer_Sp(@c_id int, @fdate date, @ldate date)
as
begin
     select * from orders_ where cust_id = @c_id AND (order_date between @fdate and @ldate)
end

exec get_customer_Sp 2, '2001-08-24', '2022-11-13'


create function func_abc(@c_id int, @fdate date, @ldate date)
returns table
as
return(     
        select * from orders_ where cust_id = @c_id AND (order_date between @fdate and @ldate)
      )

	  select * from dbo.func_abc(2,'2001-08-24', '2022-11-13')


--11.Create a stored procedure called "get_order_count" that accepts a customer ID as a parameter and returns the number of orders for that customer.
create proc get_order_count_sp(@c_id int)
as
begin
      select cust_id, count(order_id) from ORDERS_
	  group by cust_id
	  having CUST_ID = @c_id
end
exec get_order_count_sp 11;


SELECT * FROM PRODUCTS;
SELECT * FROM ORDERS_;
SELECT * FROM CUSTOMERS;

create view [C_V]
as
select * from ORDERS_
where ORDER_DATE between '2022-01-01' and '2022-12-01'

select * from [C_V]


create view [view_]
as
    select c.CUST_ID, c.cust_name, o.order_id, o.quantity, o.pay_status 
	from CUSTOMERS as c
	inner join ORDERS_ as o on c.cust_id = o.CUST_ID

select * from [view_]


--13.Create a stored procedure called "get_customer_payments" that accepts a customer ID as a parameter and returns all payments made by that customer.
create proc get_customer__payments(@c_id int)
as
begin
      select * from orders_ where PAY_STATUS = 'PAID' AND CUST_ID = @c_id
end

exec get_customer__payments 2;


alter function function_l(@c_id int)
returns table
as
return (select order_date,PAY_STATUS,ORDER_ID  from ORDERS_ where CUST_ID = @c_id)


select * from dbo.function_l(12);








SELECT * FROM PRODUCTS;
SELECT * FROM ORDERS_;
SELECT * FROM CUSTOMERS;


alter proc SP_raj
as
begin
	declare @id int
	select * from PRODUCTS where PRO_ID = @id or isnull(@id, '') = ''
end

exec SP_raj 