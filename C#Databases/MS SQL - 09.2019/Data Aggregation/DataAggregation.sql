SELECT COUNT (*) AS [Count] 
FROM WizzardDeposits

SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT DepositGroup FROM(
                         SELECT TOP(2) DepositGroup
                         FROM WizzardDeposits
                         GROUP BY DepositGroup
                         ORDER BY AVG(MagicWandSize)) AS [AvgSizeTable]

SELECT DepositGroup, SUM(DepositAmount) AS TotalAmount
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
  FROM WizzardDeposits
  WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
  FROM WizzardDeposits
  WHERE MagicWandCreator = 'Ollivander family'
  GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
  ORDER BY TotalSum DESC

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
  FROM WizzardDeposits
  GROUP BY DepositGroup, MagicWandCreator
  ORDER BY MagicWandCreator, DepositGroup

  SELECT
  CASE
      WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
      WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
      WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
      WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
      WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
      WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
ELSE '[61+]'
END AS [AgeGroup],
COUNT(*) AS [WizzardCount]
FROM WizzardDeposits
GROUP BY CASE
      WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
      WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
      WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
      WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
      WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
      WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
ELSE '[61+]'
END

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
   WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired;

SELECT SUM([Difference]) FROM (SELECT
     FirstName AS [Host Wizard],
	 DepositAmount As [Host	Wizard Deposit],
	 LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
	 LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
	 DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
FROM WizzardDeposits) AS DiffTable

SELECT 
     DepartmentID, 
     SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

SELECT 
     DepartmentID, 
     Min(Salary) AS [MinimumSalary]
FROM Employees
WHERE DepartmentId IN (2, 5, 7) AND HireDate > 01/01/2000
GROUP BY DepartmentID

 SELECT * INTO NewEmployeesTable
    FROM Employees
   WHERE Salary > 30000;
  DELETE FROM NewEmployeesTable
   WHERE ManagerID = 42;
  UPDATE NewEmployeesTable
     SET Salary += 5000
   WHERE DepartmentID = 1;
  SELECT DepartmentID, AVG(Salary) AS AverageSalary
    FROM NewEmployeesTable
GROUP BY DepartmentID;

SELECT DepartmentID, MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

SELECT DepartmentId, Salary AS [ThirdHighestSalary] FROM
           (SELECT DepartmentId, Salary, DENSE_RANK() OVER(PARTITION BY DepartmentId ORDER BY Salary DESC) AS [Ranking]
           FROM Employees
		   GROUP BY DepartmentID, Salary) AS [RankingTable]
WHERE [Ranking] = 3

SELECT TOP(10)FirstName, LastName, DepartmentID
FROM Employees AS e1
WHERE Salary > (
               SELECT AVG(Salary) AS [AvgSalary]
               FROM Employees AS e2
			   WHERE e2.DepartmentID = e1.DepartmentID
               GROUP BY DepartmentID
			   )
ORDER BY e1.DepartmentID
