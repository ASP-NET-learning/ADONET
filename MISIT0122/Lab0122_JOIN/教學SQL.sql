--SELECT DISTINCT c.CustomerID, o.OrderID, p.ProductName, cat.CategoryName
--FROM Customers c
--LEFT JOIN
--	Orders o ON o.CustomerID = c.CustomerID
--LEFT JOIN
--	[Order Details] od ON od.OrderID = o.OrderID
--LEFT JOIN
--	Products p ON p.ProductID = od.ProductID
--LEFT JOIN
--	Categories cat ON  cat.CategoryID = p.CategoryID
--ORDER BY c.CustomerID

--SELECT SUM(UnitsInStock) FROM Products WHERE CategoryID = 1
--UNION
--SELECT SUM(UnitsInStock) FROM Products WHERE CategoryID = 2

SELECT CategoryID, ProductID, sum(UnitsInStock) AS '小計/總計'
FROM Products
GROUP BY CategoryID, ProductID WITH ROLLUP
ORDER BY CategoryID



