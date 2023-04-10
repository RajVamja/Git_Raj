create database RajVamja_355
use RajVamja_355

create table Customer(
	Id int primary key Identity(1,1),
	Name varchar(255),
	UserName varchar(255),
	Password varchar(255),
	Email varchar(255),
	DOB date,
	Address varchar(max),        
	ContactNo varchar(max),
);
alter table Customer
add primary key (Id)

-- [1.]
Alter Table Customer Add Id int Identity(1,1) primary key

--alter table Customer
--alter column UserName varchar(255) unique

-- [2.]
alter proc SP_AddEditCustomer 
@id int, 
@name varchar(255), 
@uname varchar(255),
@pass varchar(255), 
@email varchar(255), 
@dob date, 
@add varchar(255), 
@contact varchar(max) 
as
    --select Id from Customer where Id = @id
	if (@id = 0)
	begin
		insert into Customer (Name, UserName, Password, Email, DOB, Address, ContactNo) 
		values (@name, @uname, @pass, @email, @dob, @add, @contact)
	end;

	else 
	begin
		update Customer
			set Name = @name,
			UserName = @uname, 
			Password =  @pass,
			Email = @email, 
			DOB = @dob, 
			Address = @add, 
			ContactNo = @contact
		where Id = @id
end;

select * from Customer

exec SP_AddEditCustomer 1,'Raj', 'Raj Vamja', 'Rajvamja@123', 'vamjaraj40@gmail.com', '2001-08-24', 'D-601, shivplaza, surat', 7878508479
exec SP_AddEditCustomer 0,'Harsh', 'HarshVamja', 'harsh#99045', 'harsh99045@gmail.com', '1997-08-04', 'D-601, shivplaza, surat', 9904536054
exec SP_AddEditCustomer 0, 'Anand', 'AnandPatel', 'Anand@321', 'anand90@gmail.com', '1999-08-04', 'sulay row house, vejalpur, ahmedabad', 9541257952
exec SP_AddEditCustomer 0, 'karan', 'KaranViroja', 'Karan@1001', 'karanv85@gmail.com', '2001-08-02', 'jalcon apartment, ahmedabad', 9081001281
exec SP_AddEditCustomer 0, 'Rohan', 'RohanPatel', 'Rohan#961', 'patelrohan51@gmail.com', '2003-04-15', 'Guma, bopal, ahmedabad', 8754125896

begin tran
exec SP_AddEditCustomer 5, 'Ram', 'RohanPatel', 'Rohan#961', 'patelrohan51@gmail.com', '2003-04-15', 'Guma, bopal, ahmedabad', 8754125896
commit tran
rollback tran

select * from Customer
------------------------------------------------------------------------------------------------------------------------------------------------------------------

Create Table Salesman(
	Id int primary key identity (1,1),
	Name varchar(255),
	UserName varchar(255),
	Password varchar(255),
	Email varchar(255),
	DOB date,
	Address varchar(max),
	ContactNo varchar(max),
); 

alter proc SP1_AddEditCustomer (@id int, @name varchar(255), @uname varchar(255),@pass varchar(255), @email varchar(255), @dob date, @add varchar(255), @contact varchar(max)) 
as
    --select Id from Customer where Id = @id
	if (@id = 0)
	begin
		insert into Salesman (Name, UserName, Password, Email, DOB, Address, ContactNo) 
		values (@name, @uname, @pass, @email, @dob, @add, @contact)
	end;

	else 
	begin
		update Salesman
			set Name = @name,
			UserName = @uname, 
			Password =  @pass,
			Email = @email, 
			DOB = @dob, 
			Address = @add, 
			ContactNo = @contact
		where Id = @id
end;

exec SP1_AddEditCustomer 0,'Davuid', 'DavidWorn', 'David006@123', 'davidw006@gmail.com', '1989-02-15', '5515, Bela street, paris', 8964785126
exec SP1_AddEditCustomer 0,'Moris', 'MorisYugo', 'moris#99045', 'morisyugo@gmail.com', '1986-12-10', '5454A, colony, manitoba', 9874521458
exec SP1_AddEditCustomer 0, 'Harry', 'HarryPotter', 'Harry$321', 'haryy62@gmail.com', '1999-06-14', '492, caligary', 8541259635
exec SP1_AddEditCustomer 0, 'Ron', 'RonWissly', 'Ron#1001', 'ronw62@gmail.com', '2004-05-23', '554AC5, ontario', 8965412598
exec SP1_AddEditCustomer 0, 'Hagrid', 'HagridWon', 'Hag#751', 'hagrid@gmail.com', '1991-04-15', '4951, downtown, manitoba', 7512485963

begin tran
exec SP1_AddEditCustomer 5, 'Hagrid_updated', 'HagridWon', 'Hag#751', 'hagrid@gmail.com', '1991-04-15', '4951, downtown, manitoba', 7512485963
commit tran
rollback tran

select * from Salesman
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Create Table Category(
	Id int primary key identity(1,1),
	Name varchar(255)
);


create proc SP2_AddEditCustomer (@id int, @name varchar(255)) 
as
    --select Id from Customer where Id = @id
	if (@id = 0)
	begin
		insert into Category (Name) 
		values (@name)
	end;

	else 
	begin
		update Category
			set Name = @name
		where Id = @id
end;

exec SP2_AddEditCustomer 0, 'Cosmatic'
exec SP2_AddEditCustomer 0, 'Fation'
exec SP2_AddEditCustomer 0, 'Medicin'
exec SP2_AddEditCustomer 0, 'Food'
exec SP2_AddEditCustomer 0, 'Footwear'

begin tran
exec SP2_AddEditCustomer 2, 'Dairy Product'
commit tran
rollback tran

select * from Category
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Create Table Items(
	Id int primary key identity(1,1),
	Name varchar(255),
	Category varchar(255),
	Rate float,
	DOM date,
	DOE date
); 

create proc SP3_AddEditCustomer (@id int, @name varchar(255), @cat varchar(255),@rate float, @dom date, @doe date) 
as
    --select Id from Customer where Id = @id
	if (@id = 0)
	begin
		insert into Items (Name, Category, Rate, DOM, DOE) 
		values (@name, @cat, @rate, @dom, @doe)
	end;

	else 
	begin
		update Items
			set Name = @name,
			Category = @cat, 
			Rate =  @rate,
			DOM = @dom, 
			DOE = @doe
		where Id = @id
end;

exec SP3_AddEditCustomer 0, 'facewash', 'Cosmatic', 189, '2021-08-10', '2025-08-10'
exec SP3_AddEditCustomer 0, 'shreeKhand', 'Dairy Product', 229, '2023-01-10', '2025-08-10'
exec SP3_AddEditCustomer 0, 'Matacine', 'Medicin', 19, '2021-06-19', '2025-06-19'
exec SP3_AddEditCustomer 0, 'maggi', 'Food', 59, '2021-10-10', '2025-10-10'
exec SP3_AddEditCustomer 0, 'sleeper', 'Footwear', 199, '2019-12-30', '2025-12-30'

begin tran
exec SP3_AddEditCustomer 5, 'Boots_updated', 'Footwear', 199, '2019-12-30', '2025-12-30'
commit tran
rollback tran


select * from Items


alter table Items
add foreign key(Id) references Category(Id)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Create Table ModeOfPayment(
	Id int identity(1,1),
	Name varchar(255) primary key
); 


create proc SP4_AddEditCustomer (@id int, @name varchar(255)) 
as
    --select Id from Customer where Id = @id
	if (@id = 0)
	begin
		insert into ModeOfPayment (Name) 
		values (@name)
	end;

	else 
	begin
		update ModeOfPayment
			set Name = @name
		where Id = @id
end;

exec SP4_AddEditCustomer 0, 'Cash on Delivery'
exec SP4_AddEditCustomer 0, 'UPI'
exec SP4_AddEditCustomer 0, 'Credit Card'
exec SP4_AddEditCustomer 0, 'EMi'
exec SP4_AddEditCustomer 0, 'COD'

begin tran
exec SP4_AddEditCustomer 5, 'COD-updated'
commit tran
rollback tran

select * from ModeOfPayment
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Create Table Orders(
	Id int primary key identity (1,1),    
	OrderNo int,
	Customer varchar(255),
	OrderQty int,
	BillAmount float,
	DOD date,
	Salesman varchar(255),
	DeliveryAddress varchar(max),
	City varchar(255),
	ContactNo varchar(225),
	MOP varchar(255),
	OrderStatus int default 0
);

create proc SP5_AddEditCustomer (@id int, @OrderNo int,@Customer varchar(255),@OrderQty int,@amt float, @DOD date, @Salesman varchar(255), @DeliveryAdd varchar(max), @City varchar(255),
                                 @Cont varchar(225),@MOP varchar(255),@OrderStatus int) 
as
    --select Id from Customer where Id = @id
	if (@id = 0)
	begin
		insert into Orders (OrderNo,Customer,OrderQty,BillAmount,DOD,Salesman,DeliveryAddress,City,ContactNo,MOP,OrderStatus) 
		values (@OrderNo,@Customer,@OrderQty,@amt,@DOD,@Salesman,@DeliveryAdd,@City,@Cont,@MOP,@OrderStatus)
	end;

	else 
	begin
		update Orders
			set OrderNo = @OrderNo,
			Customer = @Customer, 
			OrderQty =  @OrderQty,
			BillAmount = @amt, 
			DOD = @DOD, 
			Salesman = @Salesman, 
			DeliveryAddress = @DeliveryAdd,
			City = @City,
			ContactNo = @Cont,
			MOP = @MOP,
			OrderStatus = @OrderStatus
		where Id = @id
end;

exec SP5_AddEditCustomer 0, '101', 'Raj',10, 1890, '2023-02-12', 'Davuid', 'D-601, shivplaza, surat', 'surat', '7878508479', 'Cash on Delivery', 1
exec SP5_AddEditCustomer 0, '102', 'Harsh',08, 1832, '2022-10-30', 'Moris', 'D-601, shivplaza, surat', 'surat', '9904536054', 'UPI',1
exec SP5_AddEditCustomer 0, '103', 'Anand',15, 285, '2023-02-12', 'Harry', 'sulay row house, vejalpur, ahmedabad', 'ahmedabad','9541257952', 'Credit Card', 1
exec SP5_AddEditCustomer 0, '104', 'karan',20, 1180, '2021-10-25', 'Ron', 'jalcon apartment, ahmedabad', 'ahmedabad','9081001281', 'EMi', 1
exec SP5_AddEditCustomer 0, '105', 'Ram',09, 1791, '2021-03-16', 'Hagrid_updated', 'Guma, bopal, ahmedabad', 'surat', '8754125896', 'COD-updated', 1

begin tran
exec SP5_AddEditCustomer 5, '105', 'Ram',09, 6490.3, '2021-03-16', 'Hagrid_updated', 'Guma, bopal, ahmedabad', 'surat', '8754125896', 'COD-updated', 0
commit tran
rollback tran

select * from Orders
select * from ModeOfPayment

alter table Orders
add foreign key(Id) references customer(Id)

alter table Orders
add foreign key(Id) references salesman(Id)

alter table Orders
add foreign key(MOP) references ModeOfPayment(Name)

select * from Orders
select * from items
----------------------------------------------------------------------------------------------------------------------------------------------------------------------
Create Table OrderDetails(
	Id int identity(1,1),
	OrderId int,
	ItemId int,
	OrderQty int,
	OrderAmount float
); 

create proc SP6_AddEditCustomer (@id int,@OrderId int,@ItemId int,@OrderQty int,@OrderAmount float) 
as
    --select Id from Customer where Id = @id
	if (@id = 0)
	begin
		insert into OrderDetails (OrderId,ItemId, OrderQty,OrderAmount) 
		values (@OrderId,@ItemId,@OrderQty,@OrderAmount)
	end;

	else 
	begin
		update OrderDetails
			set OrderId = @OrderId,
			    ItemId = @ItemId,
				OrderQty = @OrderQty,
				OrderAmount = @OrderAmount
		where Id = @id
end;

exec SP6_AddEditCustomer 0, 101, 1, 10, 1890 
exec SP6_AddEditCustomer 0, 102, 2, 8, 1832
exec SP6_AddEditCustomer 0, 103, 3, 15, 285
exec SP6_AddEditCustomer 0, 104, 4, 20, 1180
exec SP6_AddEditCustomer 0, 105, 5, 9, 1791



alter table OrderDetails
add foreign key(Id) references orders(Id)

alter table OrderDetails
add foreign key(Id) references items(Id)

select * from OrderDetails
select * from Customer
select * from salesman
select * from ModeOfPayment
select * from orders
select * from items






Alter Table City Add CityId int Identity(1,1)   

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- [3.] Create a Parameterized Store Procedure to retrive all the OrderDetails as per Customer (If CustomerId not passed then retrive all the orders) ( Make sure to Add Everything in Single Procedure) [8]
--	Information I want : 
		--CustomerName
		--ItemName
		--Item Rate
		--Qty
		--OrderAmount (Qty * ItemRate)

alter proc SP_procedure3 (@id int)
as
begin
		select c.Name, i.name, i.Rate, o.orderqty, sum(i.rate * o.orderqty) as [OrderAmount] from Orders as o
		inner join Customer as c on c.Id = o.Id
		inner join items as i on i.Id = o.Id
		where o.Id = @id or isnull(@id,'') = ''
		group by c.Name, i.name, i.Rate, o.orderqty;

end;

exec SP_procedure3 ''

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--[4] Create a User Defined Function that will retrive TotalOrderAmount from the OrderDetails Table as per Customer in sql.
	--  I just want total amount as per customerid I Passed.

alter function funcquery (@id int)
returns float
as
	begin
	   return (select OrderAmount from OrderDetails where Id = @id)
	end;

select dbo.funcquery(4);

select * from OrderDetails



create proc SP_rajvamja (@id int)
as
begin
	select OrderAmount from OrderDetails 
end;



-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--[5]Create a prameterized Store Procedure to retrive all the Order Information as per Customer. (If CustomerId not passed then retrive all the orders) [8]
--	Information I want : 
--		--CustomerName
--		--OrderNo
--		--OrderQty (Total Qty of all the Items) (Using Function)
--		--OrderAmount (Total Amount of Order) (Using Function)
--		--SalesmanName
--		--Address
--		--City
--		--ContactNo
--		--MOP Name
--		--DOD

create proc SP_procedure5 (@id int)
as
if(@id is null)
	begin
		select Customer, Id, OrderNo, OrderQty,BillAmount, Salesman, DeliveryAddress, City, ContactNo, MOP,DOD from Orders
	end;

	else
	begin
		select Customer, Id, OrderNo, OrderQty,BillAmount, Salesman, DeliveryAddress, City, ContactNo, MOP,DOD from Orders
		where Id = @id		
end;

exec SP_procedure5 2
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [6.] Create a Parameterized Store Procedure to Cancel Order as per OrderNo (If I pass wrong orderno then message should be there) [8]

create proc SP_procedure6 (@id int, @status int)
as
if(@status = 1 and @id is not null)
	begin
				update Orders
				set OrderStatus = @status
				where Id = @id and OrderStatus = @status
		end;
		else
		begin
			select * from orders
	end;	

exec SP_procedure6 5, 1


	  select * from Orders
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- [7.] Create a Parameterized Store Procedure for Login as per Customer/Salesman EmailId and Password.  [10]
	--(If credentials matched then show "Login Successfull" then "Invalid User Input" , If EmailId  is not having in the Table then Create Emaild with Password( Random) ).

alter proc SP_procedure7 (@email varchar(max), @pass varchar(255))
as
begin
if exists (select * from Customer where Email = @email and Password = @pass)
	begin
		print	'Login Successfull' 
	end;
	else
	begin
	   --print 'User is not registerd'

	   declare @randomPassword nvarchar(50)
	   declare @randomEmail varchar(max)

       --set @randomPassword = CAST(NEWID() AS varchar(50))
       set @randomEmail = char(65 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26))+ trim(str((RAND() * 100)) +'@gmail.com')

	   set @randomPassword =  char(floor(65 + (RAND() * 26))) + char(floor(97 + (RAND() * 26)))+ char(floor(97 + (RAND() * 26)))+ char(floor(97 + (RAND() * 26))) + char(floor(97 + (RAND() * 26))) + char(floor(97 + (RAND() * 26)))+ '#' +trim(str((RAND() * 1000)))
      
	  insert into Customer (Email, Password) 
	   values (@randomEmail, @randomPassword)
       print 'New Customer Added. Email: ' + @randomEmail +'and Password: ' + @randomPassword

	end;
end;	
exec SP_procedure7 'vamjaraj40@gmail.com', 'Rajvamja@33'

select char(65 + (RAND() * 26))

delete from Customer where id >= 7


select * from Orders
select * from Customer
select * from OrderDetails
select * from items
select * from salesman
select * from ModeOfPayment






select char(65 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26))+ trim(str((RAND() * 100)) +'@gmail.com')

select char(65 + (RAND() * 26)) + char(97 + (RAND() * 26))+ char(97 + (RAND() * 26))+ char(97 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26))+ '#' +trim(str((RAND() * 1000)))



BEGIN
    DECLARE @randomPassword VARCHAR(50) = (SELECT CHAR(65 + ABS(CHECKSUM(NEWID())) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 2) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 3) % 26)+ ' ' + CHAR(65 + ABS(CHECKSUM(NEWID()) / 4) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 5) % 26) + CHAR(65 + ABS(CHECKSUM(NEWID()) / 6) % 26));
    INSERT INTO DY_Products (ProductID, ProductName, UnitPrice, InStockProducts)
    VALUES (@i, @Product, ABS(CHECKSUM(NEWID())) % 1000, ABS(CHECKSUM(NEWID())) % 100); 
END;


select char(65 + abs(checksum(newid())) % 26) + trim(str(rand() * 100))
select char(65 + (rand() * 26)) + trim(str(rand() * 100))


create table cust(
	id int identity(1,1),
	name varchar(255),
	number int
);

select * from cust

alter table cust
add primary key(id)

alter table cust
alter column id int not null

alter table cust
add unique (name)


-- 8. Create a Parameterized Store Procedure for Delete Customer from the UserName	[5] All the orders linked to that customer should also be deleted.

CREATE or ALTER PROCEDURE SP_DeleteCustomer
    (@Id INT)
AS
BEGIN
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Delete  order details's records
        DELETE FROM OrderDetails WHERE Id IN (SELECT Id FROM Orders WHERE Id = @Id);
        
        -- Delete related order's records
        DELETE FROM Orders WHERE Id = @Id;

        -- Delete customer's record
        DELETE FROM Customer WHERE Id = @Id;

        COMMIT TRANSACTION;
        PRINT 'Customer deleted successfully.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Error deleting customer: ' + ERROR_MESSAGE();
    END CATCH;
END


SP_DeleteCustomer 4;

select * from Customer

-- 9. Create a OrderDetails using OrderId of Order in a Single Store Procedure.

CREATE PROCEDURE CreateOrderDetails
    @orderId INT,
    @productId INT,
    @quantity INT
AS
BEGIN
    DECLARE @orderTotal DECIMAL(18,2);
    DECLARE @unitPrice DECIMAL(18,2);

    -- Calculate the unit price of the product
    SELECT @unitPrice = Rate FROM Items WHERE Id = @productId;

    -- Calculate the total price of the order details
    SELECT @orderTotal = @unitPrice * @quantity;

    -- Insert the order details record
    INSERT INTO OrderDet (OrderId, ProductId, UnitPrice, Quantity, TotalPrice)
    VALUES (@orderId, @productId, @unitPrice, @quantity, @orderTotal);

    PRINT 'Order details created successfully.';
END

exec CreateOrderDetails 1, 1, 12
exec CreateOrderDetails 2, 2, 18


create table OrderDet(
	OrderId int,
	ProductId int,
	UnitPrice float, 
	Quantity int,
	TotalPrice float
);
select * from OrderDet

drop table students

create table students(
	id int identity(1,1),
	name varchar(255),
	email varchar(255),
	password varchar(255),
	grade int
);


select * from students 

create or alter proc SP_dynamic
as
begin

declare @id int = 1;
declare @name varchar(255);
declare @email varchar(255);
declare @pass varchar(255);

	while @id <= 10
	begin
		set @name = char(65 + rand() * 26) + char(97 + rand() * 26) + char(97 + rand() * 26) + char(97 + rand() * 26) + char(97 + rand() * 26) + char(97 + rand() * 26) + char(97 + rand() * 26)
		set @email =  char(97 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26))+ trim(str((RAND() * 100)) +'@gmail.com')
		set @pass = char(65 + (RAND() * 26)) + char(97 + (RAND() * 26))+ char(97 + (RAND() * 26))+ char(97 + (RAND() * 26)) + char(97 + (RAND() * 26)) + char(97 + (RAND() * 26))+ '#' +trim(str((RAND() * 1000)))

		insert into students(name, email, password, grade)
		values(@name,@email,@pass,floor((rand() * 100)))

		set @id = @id + 1
	end
end

exec SP_dynamic

----------------------------------view for random email---------------------
create or alter view [Random_Char] 
as
select case when RAND() < 0.7 then char(65 + RAND() * 26) else char(97 + RAND() * 26) end as char

select char from [Random_Char] 


----------------------------------view for random number---------------------

create or alter view [Random_num]
as
select floor(rand() * 100) as num

select num from [Random_num]


----------------------------------view for random date---------------------

create or alter view [Random_date]
as
select convert(date, dateadd(day,-rand()*3650,current_timestamp)) as R_date

select R_date from Random_Date


create or alter function FN_GenerateEmail()
returns varchar(50)
as
begin
	declare @i int = 0
	declare @str varchar(50) = ''
	declare @number varchar(5) = ''
	declare @fullstr varchar(50) = ''
	 while @i < 5
		begin
			set @str = @str + (select char from [Random_Char]) 
			set @number = @number + (select num from [Random_num]) 
			set @fullstr = @str + @number
			set @i = @i + 1
		end
	return @fullstr + ('@gmail.com')
end

select dbo.FN_GenerateEmail()

----------------------------------------create function for password-----------------
create or alter function FN_GeneratePass()
returns varchar(100)

as
begin
	declare @j int = 0
	declare @str varchar(50) = ''
	declare @number varchar(5) = ''
	
	while @j < = 6
		begin
			set @str = @str + (select char from [Random_Char])
			set @number = @number + (select num from [Random_num]) 
			set @j = @j + 1
		end

	return @str + ('@') + @number
end

select dbo.FN_GeneratePass()


----------------------------------------create function for date-----------------
create function FN_GenerateDate()
returns date
as
begin
	declare @rand_date date = ( select R_date from [Random_date])
	return @rand_date
end

select dbo.FN_GenerateDate()


create table EmailPass(
	id int identity(1,1),
	Email varchar(100),
	Password varchar(100)
);

select * from EmailPass

insert into EmailPass
values (dbo.FN_GenerateEmail(), dbo.FN_GeneratePass())


create or alter proc SP_DynamicWithFunc
as
begin
declare @i int = 0

	while @i <= 5
		begin
			insert into EmailPass
			values (dbo.FN_GenerateEmail(), dbo.FN_GeneratePass())
			set @i = @i + 1
		end
end

exec SP_DynamicWithFunc




SELECT CHAR(65 + RAND() * 26 ) AS RandomLetter;


select case when RAND() < 0.7 then char(65 + RAND() * 26) else char(97 + RAND() * 26) end ;


select convert(date, dateadd(day,-rand()*3650,current_timestamp)) as [Random Date]

create table datetable(
	id int identity(1,1),
	Randomd_ate date
);

create or alter proc SP_date
as
begin
declare @d int = 0
	while @d < 5
		begin
			insert into datetable
			values(dbo.FN_GenerateDate())
			set @d = @d +1
		end
end

exec SP_date


select * from datetable

---------------------------------------------------------------------------------------view------------------------------------------------------------------------------------------------------
sp_helptext 


-- DECLARE @E_Name VARCHAR(50) = (SELECT TOP 1 Name FROM Data_Products ORDER BY NEWID())

select * from datetable where year(Randomd_ate) = year(CURRENT_TIMESTAMP) - 3

select * from datetable where DATEDIFF(YEAR,Randomd_ate,CURRENT_TIMESTAMP) <= 3

select convert(date, dateadd(day, -rand() * 3650, current_timestamp)) as [Date]