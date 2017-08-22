/*
IF (OBJECT_ID('Customers') IS NOT NULL)
	DROP TABLE Customers;
	
IF (OBJECT_ID('Orders') IS NOT NULL)
	DROP TABLE Orders;

create table [dbo].Customers
(
	[CustomerId] [int] NOT NULL PRIMARY KEY,
	[CustomerName] varchar(255) NULL
)

create table [dbo].Orders
(
	[OrderId] [int] NOT NULL PRIMARY KEY,
	[CustomerId] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[Items] varchar(1000)
)
*/

select c.CustomerName, o.OrderDate
from Customers c join Orders o 
	on c.CustomerId = o.CustomerId
where o.OrderDate = (select max(oo.OrderDate)
                     from   Orders oo
			         where  oo.CustomerId = c.CustomerId)
