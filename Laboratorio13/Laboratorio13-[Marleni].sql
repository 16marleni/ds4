--Ejemplo 131
Select * from Products

--Ejemplo 132
Select ProductID, ProductName, UnitPrice from Products

--Ejemplo 133
Select ProductID, ProductName, UnitPrice
from Products
where UnitPrice > 15

--Ejemplo 134
Select ProductID, ProductName, UnitPrice
from Products
where UnitPrice >= 15 and UnitPrice <= 50

--Ejemplo 135
Select ProductID, ProductName, UnitPrice
from Products
where UnitPrice between 15 and 50

--Ejemplo 136
Select ProductID, ProductName, UnitPrice
from Products
where not UnitPrice > 15

--Ejemplo 137
Select ProductID, ProductName, UnitPrice
from Products
where ProductID > 15 or UnitPrice < 10

--Ejemplo 138
Select EmployeeID, LastName from Employees
where LastName like 'D%'

--Ejemplo 139
Select EmployeeID, LastName from Employees
where LastName like '%N'

--Ejemplo 1310
Select EmployeeID, LastName, Title from Employees
where Title like '%SALES%'

--Ejemplo 1311
Select EmployeeID, LastName from Employees
where LastName not like 'D%'

--Ejemplo 1312
Select ProductID, ProductName, UnitPrice
from Products
order by ProductID asc

--Ejemplo 1313
Select ProductID, ProductName, UnitPrice
from Products
order by ProductID desc

--Ejemplo 1314
Select distinct OrderID from [Order Details]

--Ejemplo 1315
Select top 5 OrderID, ProductID, Quantity
from [Order Details]

--Ejemplo 1316
Select top 10 percent OrderID, ProductID, Quantity
from [Order Details]

--Ejemplo 1317
Select CategoryName as [Nombre de Categoria]
from Categories

--Ejemplo 1318
Select OrderId, OrderDate, ShippedDate, ShippedDate + 5 as RetrasoEnvio
from Orders

--Ejemplo 1319
Select OrderID, P.ProductID, ProductName
from Products P
inner join [Order Details] OD
on P.ProductID = OD.ProductID

--Ejemplo 1320
Select ProductName, CompanyName, ContactName
from Products P
full join Suppliers S
on P.SupplierID = S.SupplierID