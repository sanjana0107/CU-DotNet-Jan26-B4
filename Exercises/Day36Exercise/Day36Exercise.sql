-- displaying product name with category names.
select p.ProductName, c.CategoryName
from Products p join Categories c on p.CategoryID = c.CategoryID;


--Display every Order ID alongside the Company Name of the customer who placed it.
select o.OrderID, c.CompanyName
from Customers c join Orders o on o.CustomerID = c.CustomerID;


--: Show all Product Names and the Company Name of their respective suppliers.
select p.ProductName, s.CompanyName
from Suppliers s join Products p on s.SupplierID = p.SupplierID;

--: List all Orders (ID and Date) and the First/Last Name of the employee who processed them.
select o.OrderID, o.OrderDate, e.EmployeeID, concat(e.FirstName,' ',e.LastName) as FullName
from Employees e join Orders o on e.EmployeeID = o.EmployeeID ;

--International Logistics: Find all Orders shipped to "France," 
--showing the Order ID and the Company Name of the Shipper (from the Shippers table).
select o.OrderID, c.Country, s.CompanyName
from Orders o join Customers c on o.CustomerID = c.CustomerID join Shippers s on s.ShipperID = o.ShipVia;

--Level 2: Aggregations with Joins

--Category Stock: Show the Category Name and the total number of units in stock for that category.
select c.CategoryName, sum(p.UnitsInStock) as TotalUnits
from Products p join Categories c on p.CategoryID = c.CategoryID group by c.CategoryName order by TotalUnits desc;

--Customer Spend: List the Company Name and the total amount of money (Price $\times$ Quantity) they have spent across all orders.
select sum(od.UnitPrice * od.Quantity) as totalAmount, c.CompanyName
from Orders o join [Order Details] od on o.OrderID = od.OrderID join Customers c
on c.CustomerID = o.CustomerID group by c.CompanyName order by totalAmount desc;

--Employee Performance: Display the Last Name of each employee and the total number of orders they have taken.
select e.LastName, count(o.OrderID) as TotalOrders
from Employees e join Orders o on e.EmployeeID = o.EmployeeID group by e.EmployeeID, e.LastName;


--Top Products: List the top 5 Product Names based on total quantity sold.
  select top 5 p.ProductName, sum(od.Quantity) as totalQuantity
from Products p join [Order Details] od on p.ProductID = od.ProductID group by p.ProductID order by totalQuantity desc;

--Above Average: List all Product Names whose UnitPrice is greater than the average price of all products.
select ProductName from Products where UnitPrice >(select AVG(UnitPrice) from Products);

--The Bosses: Use a Self-Join on the Employees table to show each employee's name and their manager's name.
select (e1.FirstName +' '+ e1.LastName) as Name, (e2.FirstName +' ' + e2.LastName) as ManagerName
from Employees e1 inner join Employees e2 on e1.ReportsTo = e2.EmployeeID;

--No Orders: Find all Customers (Company Name) who have never placed an order (Use NOT IN or NOT EXISTS).
select CompanyName
from Customers where CustomerID not in (select CustomerID from Orders);

--High-Value Orders: Identify Order IDs where the total order value is higher than the average order value of the entire database.
select OrderID from [Order Details] group by OrderID having sum(UnitPrice * Quantity) > 
(select avg(OrderTotal) from (select sum(UnitPrice * Quantity) as OrderTotal from
[Order Details] group by OrderID) as T); 

--Late Bloomers: Select Product Names that have never been ordered after the year 1997.
select p.ProductName from Products p where not exists (select o.OrderID from [Order Details] od 
join Orders o on od.OrderID = o.OrderID where od.ProductID = p.ProductID and o.OrderDate >= '1998-01-01');

--Territory Coverage: List all Employees and the names of the Regions they 
--cover (requires joining Employees, EmployeeTerritories, Territories, and Region)
select Distinct(e.FirstName + ' ' + e.LastName) as Name, r.RegionDescription from Employees e join EmployeeTerritories 
et on e.EmployeeID = et.EmployeeID join Territories t
on et.TerritoryID = t.TerritoryID join Region r on r.RegionID = t.RegionID;


--Duplicate Cities: Find Customers and Suppliers who are located in the same city.
select c.ContactName as CustomerName, s.ContactName as SupplierName, s.City
from Customers c join Suppliers s on c.City = s.City;


--Multi-Category Customers: List Customers who have purchased products 
--from more than 3 different categories.
select c.ContactName from [Order Details] od join Orders o on o.OrderID = 
od.OrderID join Customers c on c.CustomerID = o.CustomerID join Products
p on p.ProductID = od.ProductID  group by c.ContactName having 
count(distinct p.CategoryID) > 3;

--Discontinued Sales: Calculate the total revenue generated only by products that are currently Discontinued.
select sum(od.UnitPrice * od.Quantity) as totalRevenue, p.ProductName  from Products p join [Order Details] od on 
p.ProductID = od.ProductID where p.Discontinued = 'True' group by p.ProductName;