CREATE database Asses1DB;

Use Asses1DB;

Create Table Sales_Raw
(
	OrderID INT,
    OrderDate VARCHAR(20),
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50),
    ProductNames VARCHAR(200),   -- Multiple products comma-separated
    Quantities VARCHAR(100),     -- Multiple quantities comma-separated
    UnitPrices VARCHAR(100),     -- Multiple prices comma-separated
    SalesPerson VARCHAR(100)
);

INSERT INTO Sales_Raw VALUES
(101, '2024-01-05', 'Ravi Kumar', '9876543210', 'Chennai', 'Laptop,Mouse', '1,2', '55000,500', 'Anitha'),
(102, '2024-01-06', 'Priya Sharma', '9123456789', 'Bangalore', 'Keyboard,Mouse', '1,1', '1500,500', 'Anitha'),
(103, '2024-01-10', 'Ravi Kumar', '9876543210', 'Chennai', 'Laptop', '1', '54000', 'Suresh'),
(104, '2024-02-01', 'John Peter', '9988776655', 'Hyderabad', 'Monitor,Mouse', '1,1', '12000,500', 'Anitha'),
(105, '2024-02-10', 'Priya Sharma', '9123456789', 'Bangalore', 'Laptop,Keyboard', '1,1', '56000,1500', 'Suresh');

Select * from Sales_Raw;

--Question 1 – Normalization (Design Thinking)

create Table Customers
(
    CustomerID int identity primary key,
    CustomerName VARCHAR(100),
    CustomerPhone VARCHAR(20),
    CustomerCity VARCHAR(50)
);
--Select * from Customers;

create table SalesPersons
(
    SalesPersonID int identity primary key,
    SalesPersonName VARCHAR(100)
);

create table Products
(
    ProductID int identity primary key,
    ProductName Varchar(100),
    UnitPrice decimal(10,2)
);

create table Orders
(
    OrderID int primary key,
    OrderDate Date,
    CustomerID int,
    SalesPersonID int,
    Foreign key (CustomerID) References Customers(CustomerID),
    Foreign key (SalesPersonID) References SalesPersons(SalesPersonID)
);

Create table OrderDetails
(
    OrderDetailID int identity primary key,
    OrderID int,
    ProductID int,
    Quantity int,
    Foreign key (OrderID) References Orders(OrderID),
    Foreign key (ProductID) References Products(ProductID)
);

--Question 2 – Third Highest Total Sales (Analytical Query)

