SELECT FirstName, LastName
  FROM Employees
  WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName
  FROM Employees
  WHERE LastName LIKE '%ei%'

SELECT FirstName
  FROM Employees
  WHERE DepartmentID IN(3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

SELECT FirstName, LastName
  FROM Employees
  WHERE JobTitle NOT LIKE '%engineer%'

SELECT Name
  FROM Towns
  WHERE LEN(Name) IN (5, 6)
  ORDER BY Name

SELECT *
  FROM Towns
  WHERE Name LIKE '[mkbe]%'
  ORDER BY Name

SELECT *
  FROM Towns
  WHERE Name LIKE '[^rbd]%'
  ORDER BY Name

GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
  FROM Employees
  WHERE DATEPART(YEAR, HireDate) > 2000
GO

SELECT FirstName, LastName
  FROM Employees
  WHERE LEN(LastName) = 5

SELECT * 
FROM(
SELECT EmployeeId, FirstName, LastName, Salary,
 DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeId) AS Rank
  FROM Employees
  WHERE Salary BETWEEN 10000 AND 50000) AS MyTable
  WHERE MyTable.Rank = 2
  ORDER BY Salary DESC

SELECT CountryName, IsoCode
  FROM Countries 
  WHERE CountryName LIKE '%a%a%a%'
  ORDER BY IsoCode

SELECT PeakName, RiverName, LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName)))
  FROM Peaks, Rivers
  WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
  ORDER BY PeakName, RiverName

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
    FROM Games
	WHERE YEAR(Start) BETWEEN 2011 AND 2012
	ORDER BY [Start], [Name]

	SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
	  FROM Users
	  ORDER BY [Email Provider], Username

	  SELECT Username, IpAddress
	  FROM Users
	  WHERE IpAddress LIKE '___.1_%._%.___'
	  ORDER BY Username

	  SELECT Name,
	  CASE
	  WHEN DATEPART(HOUR, Start) >= 0 AND DATEPART(HOUR, Start) < 12 THEN 'Morning'
	  WHEN DATEPART(HOUR, Start) >= 12 AND DATEPART(HOUR, Start) < 18 THEN 'Afternoon'
	  WHEN DATEPART(HOUR, Start) >= 18 AND DATEPART(HOUR, Start) < 24 THEN 'Evening'
	  END AS [Part of the Day],
	  CASE
	  WHEN Duration <= 3 THEN 'Extra Short'
	  WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	  WHEN Duration > 6 THEN 'Long'
	  WHEN Duration IS NULL THEN 'Extra Long'
	  END AS [Duration]
	  FROM Games
	  ORDER BY [Name], Duration, [Part of the Day]

SELECT ProductName, OrderDate, DATEADD(DAY, 3, OrderDate) AS [Pay Due],
       DATEADD(MONTH, 1, OrderDate) AS [Delivery Due]
FROM Orders

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
Birthdate DATETIME NOT NULL
)

INSERT INTO People ([Name], Birthdate) VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephan', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT [Name],
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],  
       DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],  
       DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Years] 
FROM People