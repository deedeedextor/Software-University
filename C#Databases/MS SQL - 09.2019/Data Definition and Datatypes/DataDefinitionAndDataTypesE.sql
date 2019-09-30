CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions (
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
Age INT 
)

SELECT * FROM Minions

CREATE TABLE Towns (
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

SELECT * FROM Towns

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

INSERT INTO Towns(Id, Name) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions(Id, Name, Age, TownId) VALUES
(1,'Kevin', 22, 1),
(2,'Bob', 15, 3),
(3,'Steward', NULL, 2)

TRUNCATE TABLE Minions

DROP TABLE Minions

DROP TABLE Towns

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture TEXT,
Height DECIMAL(15, 2),
[Weight] DECIMAL (15, 2),  
Gender CHAR NOT NULL,
Birthdate DATE NOT NULL,
Biography TEXT
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Nick', NULL, 168.01, 87.50, 'm', '1986-07-13', NULL),
('Maria', NULL, 165.01, 48.00, 'f', '1989-01-07', NULL),
('Peter', NULL, 198.00, 100.50, 'm', '2000-11-15', NULL),
('Mark', NULL, 184.25, 91.00, 'm', '1987-12-20', NULL),
('Carmen', NULL, 161.00, 52.20, 'f', '1988-05-30', NULL)

SELECT * FROM People

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
Password VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted BIT
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Simon', 'asd', NULL, GETDATE(), 0),
('KSK', 'asf', NULL, GETDATE(), 0),
('IVan', 'as1', NULL, GETDATE(), 0),
('Dilki', 'as3', NULL, GETDATE(), 0),
('Surya', '123', NULL, GETDATE(), 0)


SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07516F3153

ALTER TABLE Users
ADD CONSTRAINT PK__User PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT [MinLengthConstraint]
CHECK (DATALENGTH([Password]) >= 5)

ALTER TABLE Users
DROP CONSTRAINT PK__User

ALTER TABLE Users
ADD CONSTRAINT PK__User PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT Username__unique UNIQUE (Username)

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes TEXT
)

SELECT * FROM Directors

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(50) NOT NULL,
Notes TEXT
)

SELECT * FROM Genres

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes TEXT
)

SELECT * FROM Categories

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
CopyrightYear INT NOT NULL,
Length VARCHAR(10) NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating INT,
Notes Text
)

SELECT * FROM Movies

INSERT INTO Directors (DirectorName, Notes) VALUES
('Ivan Petrov', NULL),
('Peter Petrov', NULL),
('Maria Ivanova', NULL),
('Dimitar Dimov', NULL),
('Ivana Stoqnova', NULL)

INSERT INTO Genres(GenreName, Notes) VALUES
('Fantasy', NULL),
('Horror', NULL),
('Romance', NULL),
('Comedy', NULL),
('Romantic comedy', NULL)

INSERT INTO Categories(CategoryName, Notes) VALUES
('Action', NULL),
('Adventure', NULL),
('Cartoon', NULL),
('Thriller', NULL),
('Documentary', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('Love is in the air', 1, 1989, '1:30:45', 1, 5, 0, NULL),
('Love is in the air', 1, 1989, '1:30:45', 3, 5, 0, NULL),
('Love is in the air', 1, 1989, '1:30:45', 2, 5, 0, NULL),
('Love is in the air', 1, 1989, '1:30:45', 4, 5, 0, NULL),
('Love is in the air', 1, 1989, '1:30:45', 5, 5, 0, NULL)


CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
DailyRate INT,
WeeklyRate INT,
MonthlyRate INT,
WeekendRate INT
)

SELECT * FROM Categories

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY,
PlateNumber NVARCHAR(50)NOT NULL,
Manufacturer NVARCHAR(50),
Model NVARCHAR(50),
CarYear INT,
Category_id INT,
Doors INT,
Picture BINARY,
Condition NVARCHAR(50),
Available BIT NOT NULL
)

SELECT * FROM Cars

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL,
Notes TEXT
)

SELECT * FROM Employees

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber INT NOT NULL,
FullName NVARCHAR(50) NOT NULL,
[Address] NVARCHAR(50),
City NVARCHAR(50) NOT NULL,
ZIPCode NVARCHAR(50) NOT NULL,
Notes TEXT
)

SELECT * FROM Customers

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmplayeeId INT FOREIGN KEY REFERENCES Employees(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
CarId INT FOREIGN KEY REFERENCES Cars(Id),
TankLevel INT,
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage INT,
StartDate DATE,
EndDate DATE,
Totaldays INT,
RateApplied INT,
TaxRate INT,
OrderStatus NVARCHAR(50),
Notes TEXT
)

SELECT * FROM RentalOrders

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Classic', NULL, NULL, NULL, NULL),
('Limuzine', NULL, NULL, NULL, NULL),
('Sport', NULL, NULL, NULL, NULL)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, Category_id, Doors, Picture, Condition, Available) VALUES
('123', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1),
('1234', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1),
('12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Ivanov', 'Test', NULL),
('Peter', 'Petrov', 'Test', NULL),
('Mariq', 'Marinova', 'Test', NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('123', 'Dimo Dimov', NULL, 'Varna', '1223', NULL),
('1234', 'Kiro Kirov', NULL, 'Plovdiv', '1225', NULL),
('12345', 'Plamen Danailov', NULL, 'Sofia', '1226', NULL)

INSERT INTO RentalOrders(EmplayeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, Totaldays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, 2, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, 3, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50),
Notes TEXT
)

INSERT INTO Employees VALUES
('Velizar', 'Ivanov', 'Receptionist', NULL),
('Ivan', 'Petrov', 'Concierge', NULL),
('Elisaveta', 'Dimova', 'Cleaner', NULL)

SELECT * FROM Employees

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
AccountNumber BIGINT NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(50) NOT NULL,
EmergencyName NVARCHAR(50),
EmergencyNumber NVARCHAR(50),
Notes TEXT
)

INSERT INTO Customers VALUES
(123452389, 'Ginka', 'Shikerova', '359888777888', 'Sis', '7708315342', NULL),
(123483933, 'Borqna', 'Stamenova', '359888777888', 'Sis', '7708315342', NULL),
(123454432009, 'Mladen', 'Isaev', '359888777888', 'Sis', '7708315342', NULL)

SELECT * FROM Customers

CREATE TABLE RoomStatus(
RoomStatus INT PRIMARY KEY IDENTITY,
Notes TEXT
)

INSERT INTO RoomStatus(Notes) VALUES
('Refill the minibar'),
('Check the towels'),
('Move the bed for couple')

SELECT * FROM RoomStatus

CREATE TABLE RoomTypes(
RoomType NVARCHAR(50) PRIMARY KEY,
Notes TEXT
)

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('Suite', 'Two beds'),
('Wedding suite', 'One king size bed'),
('Apartment', 'Up to 3 adults and 2 children')

SELECT * FROM RoomTypes

CREATE TABLE BedTypes(
BedType NVARCHAR(50) PRIMARY KEY,
Notes TEXT
)

INSERT INTO BedTypes VALUES
('Double', 'One adult and one child'),
('King size', 'Two adults'),
('Couch', 'One child')

SELECT * FROM BedTypes

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(10, 2),
RoomStatus NVARCHAR(50),
Notes TEXT
)

INSERT INTO Rooms (Rate, Notes) VALUES
(12,'Free'),
(15, 'Free'),
(23, 'Clean it')

SELECT * FROM Rooms

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE,
AccountNumber BIGINT,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
AmountCharged DECIMAL(15,2),
TaxRate DECIMAL(15, 2),
TaxAmount DECIMAL(15, 2),
PaymentTotal DECIMAL(15, 2),
Notes TEXT
)

INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged) VALUES
(1, '12/12/2018', 2000.40),
(2, '12/12/2018', 1500.40),
(3, '12/12/2018', 1000.40)

CREATE TABLE Occupancies(
Id  INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumber BIGINT,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(6,2),
PhoneCharge DECIMAL(6,2),
Notes TEXT
)

INSERT INTO Occupancies (EmployeeId, RateApplied, Notes) VALUES
(1, 55.55, 'too'),
(2, 15.55, 'much'),
(3, 35.55, 'typing')

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50)
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
AddressText VARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
MiddleName VARCHAR(50),
LastName VARCHAR(50),
JobTitle VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
HireDate DATE NOT NULL,
Salary Decimal(15, 2) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns (Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments(Name) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, JobTitle, DepartmentId, HireDate, Salary) VALUES
('Ivan Ivanov Ivanov', '.NET Developer', 4, '2013-01-02', 3500.00),
('Petar Petrov Petrov', 'Senior Engineer', 1, '2004-02-03', 4000.00),
('Maria Petrova Ivanova', 'Intern', 5, '2016-08-28', 525.25),
('Georgi Teziev Ivanov', 'CEO', 2, '2007', 3000.00),
('Peter Pan Pan', 'Intern', 3, '2016-09-12', 599.88)

SELECT Name FROM Towns
ORDER BY Name
SELECT Name FROM Departments
ORDER BY Name
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC 

UPDATE Employees
SET Salary = Salary * 1.1
SELECT Salary FROM Employees

USE Hotel

INSERT INTO Payments (TaxRate) VALUES
(6.81),
(10.30),
(3.45)

UPDATE Payments
SET TaxRate -= TaxRate * 0.03
SELECT TaxRate FROM Payments

TRUNCATE TABLE Occupancies
