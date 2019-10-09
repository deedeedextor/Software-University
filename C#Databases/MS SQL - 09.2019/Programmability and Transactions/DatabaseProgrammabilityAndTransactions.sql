---Problem 1
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT FirstName,
       LastName
  FROM Employees
  WHERE Salary > 35000

  EXEC usp_GetEmployeesSalaryAbove35000
  GO

 ---Problem 2
CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4) = 48100
AS
SELECT FirstName,
       LastName
  FROM Employees
  WHERE Salary >= @Number

  EXEC usp_GetEmployeesSalaryAboveNumber
  GO

  ---Problem 3
  CREATE PROC usp_GetTownsStartingWith @Symbol VARCHAR(30) = 'b'
  AS
       SELECT [Name]
         FROM Towns
		 WHERE [Name] LIKE @Symbol + '%'

EXEC usp_GetTownsStartingWith
GO

---Problem 4
CREATE PROC usp_GetEmployeesFromTown @Town VARCHAR(30) = 'Sofia'
  AS
       SELECT e.FirstName, 
	          e.LastName
         FROM Employees AS e
		 JOIN Addresses AS a ON a.AddressID = e.AddressID
		 JOIN Towns AS t ON t.TownID = a.TownID
		 WHERE t.Name = @Town

EXEC usp_GetEmployeesFromTown
GO

---Problem 5
CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
DECLARE @salaryLevel NVARCHAR(10)

IF (@salary < 30000)
  SET @salaryLevel = 'Low'
ELSE IF (@salary >= 30000 AND @salary <= 50000)
  SET @salaryLevel = 'Average'
ELSE
  SET @salaryLevel = 'High'

RETURN @salaryLevel
END

GO

---Problem 6
CREATE PROC usp_EmployeesBySalaryLevel @Level VARCHAR(10) = 'High'
AS
SELECT FirstName, 
       LastName
  FROM Employees
  WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level

  EXEC usp_EmployeesBySalaryLevel 
  GO

  ---Problem 7
  CREATE FUNCTION ufn_IsWordComprised (@setOfLetters VARCHAR(30),@word VARCHAR(30))
  RETURNS BIT
  AS
  BEGIN 
    
	   DECLARE @result BIT
	   DECLARE @count INT = 1

	   WHILE @count <= LEN(@word)
	   BEGIN
	        
			DECLARE @currentSymbol VARCHAR(2) = SUBSTRING(@word, @count, 1)

			IF(CHARINDEX(@currentSymbol, @setOfLetters)) > 0
			     
				 BEGIN 
				      SET @result = 1
					  SET @count+=1
                 END
			ELSE
			     BEGIN
				      SET @result = 0
					  BREAK
                 END
       END
	   RETURN @result
END
GO

---Problem 8
CREATE PROC usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN 
          ALTER TABLE Departments
		  ALTER COLUMN ManagerID INT

		  DELETE
		    FROM EmployeesProjects
			WHERE EmployeesProjects.EmployeeID IN (
			SELECT EmployeeID
			FROM Employees AS e
			WHERE e.DepartmentID = @departmentId)

		 UPDATE Departments
		    SET ManagerID = NULL
			WHERE DepartmentID = @departmentId

		UPDATE Employees
		   SET ManagerID = NULL
		   WHERE ManagerID IN (
		   SELECT e.EmployeeID 
		   FROM Employees AS e
			WHERE e.DepartmentID = @departmentId)

		DELETE
		  FROM Employees 
		  WHERE Employees.DepartmentID = @departmentId

	    DELETE
		  FROM Departments
		  WHERE Departments.DepartmentID = @departmentId

		SELECT COUNT(*)
		  FROM Employees
		  WHERE DepartmentID = @departmentId
END
GO

---Problem 9
CREATE PROCEDURE usp_GetHoldersFullName
AS 
SELECT FirstName + ' ' + LastName AS [Full Name]
  FROM AccountHolders
  GO

  ---Problem 10
  CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan @Amount DECIMAL(15,2)
  AS
  SELECT ah.FirstName, ah.LastName
  FROM AccountHolders AS ah
  INNER JOIN Accounts AS a ON a.AccountHolderId = ah.Id
  GROUP BY ah.FirstName, ah.LastName
  HAVING SUM(a.Balance) > @Amount
  ORDER BY ah.FirstName, ah.LastName

  GO

  ---Problem 11
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15, 2), @Rate FLOAT, @Years INT)
RETURNS DECIMAL(15, 4)
AS
BEGIN
	RETURN @sum * (POWER(1 + @Rate, @Years))
END

GO

---Problem 12
CREATE PROCEDURE usp_CalculateFutureValueForAccount @AccountId INT, @Rate FLOAT
AS
BEGIN
SELECT a.Id AS [Account Id], 
       ah.FirstName AS [First Name], 
	   ah.LastName [Last Name], 
	   a.Balance AS [Current Balance],
	   dbo.ufn_CalculateFutureValue (a.Balance, @Rate, 5) AS [Balance in 5 years]
FROM Accounts AS a
INNER JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
WHERE a.Id = @AccountId
END
GO

---Problem 13
CREATE FUNCTION ufn_CashInUsersGames (@GameName VARCHAR(50))
RETURNS TABLE
AS
RETURN 
SELECT SUM(k.Cash) AS [SumCash]
  FROM (
SELECT ug.Cash AS [Cash],
       ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [Row]
  FROM Games AS g
  JOIN UsersGames AS ug ON g.Id = ug.GameId
 WHERE g.[Name] = @GameName) AS k
 WHERE k.[Row] % 2 = 1

 GO

 ---Problem 14
 CREATE TABLE Logs(
 LogId INT PRIMARY KEY IDENTITY,
 AccountId INT,
 OldSum DECIMAL(15,2),
 NewSum DECIMAL(15,2)
 )
 GO

 CREATE TRIGGER tr_UpdateBalance ON Accounts FOR UPDATE
 As
 BEGIN
           DECLARE @newSum DECIMAL(15,2) = (SELECT i.Balance FROM INSERTED AS i )
		   DECLARE @oldSum DECIMAL(15,2) = (SELECT d.Balance FROM DELETED AS d)
		   DECLARE @accountId INT = (SELECT i.Id FROM INSERTED AS i)

		   INSERT INTO Logs(AccountId, OldSum, NewSum) VALUES
		   (@accountId, @oldSum, @newSum)
END

---Problem 15
CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY,
Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
[Subject] VARCHAR(50),
Body VARCHAR(MAX)
)
GO

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
BEGIN
     DECLARE @recipient INT = (SELECT AccountId FROM inserted)
	 DECLARE @oldSum DECIMAL(15, 2) = (SELECT OldSum FROM inserted)
	 DECLARE @newSum DECIMAL(15, 2) = (SELECT NewSum FROM inserted)

	 INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES
	 (
	 @recipient,
	 'Balance change for account: ' + CAST(@recipient AS VARCHAR(30)),
	 'On ' + CAST(GETDATE() AS VARCHAR(30)) + ' your balance was changed from ' 
	 + CAST(@oldSum AS VARCHAR(50)) + ' to ' 
	 + CAST(@newSum AS VARCHAR(50)) + '.'
	 )
END
GO

---Problem 16
CREATE PROCEDURE usp_DepositMoney @AccountId INT, @MoneysAmount DECIMAL(15, 4)
AS
BEGIN
     DECLARE @targetAccountId INT = (SELECT a.Id FROM Accounts AS a WHERE a.Id = @AccountId)

	 IF(@targetAccountId IS NULL)
	 BEGIN 
	      ROLLBACK
		  RAISERROR('Invalid Id Parameter', 16, 1)
		  RETURN 
	 END

	 IF(@MoneysAmount < 0 OR @MoneysAmount IS NULL)
	 BEGIN
	      ROLLBACK
		  RAISERROR('Invalid amount of money', 16, 2)
	 END

	 UPDATE Accounts
	 SET Balance +=@MoneysAmount
	 WHERE Id = @AccountId
END
GO

---Problem 17
CREATE PROCEDURE usp_WithdrawMoney @AccountId INT, @MoneyAmount DECIMAL(15, 4)
AS
BEGIN
     DECLARE @targetAccountId INT = (SELECT a.Id FROM Accounts AS a WHERE a.Id = @AccountId)

	 IF(@targetAccountId IS NULL)
	 BEGIN 
	      ROLLBACK
		  RAISERROR('Invalid Id Parameter', 16, 1)
		  RETURN
	 END

	 IF(@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	 BEGIN 
	      ROLLBACK
		  RAISERROR('Invalid amount of money', 16, 2)
		  RETURN
	 END

	 UPDATE Accounts
	 SET Balance -= @MoneyAmount
	 WHERE Id = @targetAccountId
END
GO

---Problem 18
CREATE PROCEDURE usp_TransferMoney @SenderID INT, @ReceiverId INT, @Amount DECIMAL(15, 4)
AS
BEGIN
      EXEC usp_WithdrawMoney @SenderId, @Amount
	  EXEC usp_DepositMoney @ReceiverId, @Amount
END
GO

---Problem 19
CREATE TRIGGER tr_UserGameItems_LevelRestriction ON UserGameItems
INSTEAD OF UPDATE
AS
     BEGIN
         IF(
           (
               SELECT Level
               FROM UsersGames
               WHERE Id =
               (
                   SELECT UserGameId
                   FROM inserted
               )
           ) <
           (
               SELECT MinLevel
               FROM Items
               WHERE Id =
               (
                   SELECT ItemId
                   FROM inserted
               )
           ))
             BEGIN
                 RAISERROR('Your current level is not enough', 16, 1);
         END;

/* Assign the new item when the exception isn't thrown */
         INSERT INTO UserGameItems
         VALUES
         (
         (
             SELECT ItemId
             FROM inserted
         ),
         (
             SELECT UserGameId
             FROM inserted
         )
         )
     END
	 
/* Add bonus cash */
UPDATE ug
  SET
      ug.Cash+=50000
FROM UsersGames AS ug
     JOIN Users AS u ON u.Id = ug.UserId
     JOIN Games AS g ON g.Id = ug.GameId
WHERE u.FirstName IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.Name = 'Bali'

---Problem 20
DECLARE @UserName VARCHAR(50) = 'Stamat'
DECLARE @GameName VARCHAR(50) = 'Safflower'
DECLARE @UserID int = (SELECT Id FROM Users WHERE Username = @UserName)
DECLARE @GameID int = (SELECT Id FROM Games WHERE Name = @GameName)
DECLARE @UserMoney money = (SELECT Cash FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)
DECLARE @ItemsTotalPrice money
DECLARE @UserGameID int = (SELECT Id FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)

BEGIN TRANSACTION
	SET @ItemsTotalPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)

	IF(@UserMoney - @ItemsTotalPrice >= 0)
	BEGIN
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameID FROM Items AS i
		WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)

		UPDATE UsersGames
		SET Cash -= @ItemsTotalPrice
		WHERE GameId = @GameID AND UserId = @UserID
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
	END

SET @UserMoney = (SELECT Cash FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)
BEGIN TRANSACTION
	SET @ItemsTotalPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

	IF(@UserMoney - @ItemsTotalPrice >= 0)
	BEGIN
		INSERT INTO UserGameItems
		SELECT i.Id, @UserGameID FROM Items AS i
		WHERE i.Id IN (SELECT Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)

		UPDATE UsersGames
		SET Cash -= @ItemsTotalPrice
		WHERE GameId = @GameID AND UserId = @UserID
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
	END

SELECT Name AS [Item Name]
FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @userGameID)
ORDER BY [Item Name]
GO

---Problem 21
CREATE PROCEDURE usp_AssignProject (@EmployeeId INT, @ProjectID INT)
AS
BEGIN 
     DECLARE @maxEmployeeProjectsCount INT = 3
	 DECLARE @employeeProjectsCount INT
	 SET @employeeProjectsCount = (SELECT COUNT(*) FROM EmployeesProjects AS ep WHERE ep.EmployeeID = @EmployeeId)

	 BEGIN TRANSACTION
	 INSERT INTO EmployeesProjects (EmployeeID, ProjectID)VALUES
	 (@EmployeeId, @ProjectID)

	 IF(@employeeProjectsCount >= @maxEmployeeProjectsCount)
	 BEGIN 
		  RAISERROR('The employee has too many projects!', 16, 1)
	      ROLLBACK
	 END
	 ELSE
	     COMMIT
END

---Problem 22
CREATE TABLE Deleted_Employees(
EmployeeId INT PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
MiddleName VARCHAR(50),
JobTitle VARCHAR(50),
DepartmentId INT,
Salary DECIMAL(15, 2)
)
GO 

CREATE TRIGGER tr_DeletedEmployees ON Employees AFTER DELETE
AS
  INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, 
  DepartmentId, Salary)
  SELECT FirstName, LastName, MiddleName, JobTitle, 
  DepartmentId, Salary FROM deleted
