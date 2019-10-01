CREATE DATABASE OneToOne

USE OneToOne

CREATE TABLE Persons(
 PersonID INT NOT NULL,
 FirstName VARCHAR(50),
 Salary DECIMAL(15,2),
 PassportID INT
)

CREATE TABLE Passports(
 PassportsId INT NOT NULL,
 PassportNumber VARCHAR(50)
)

INSERT INTO Persons VALUES
(1,'Roberto',43300.00,102),
(2,'Tom',56100.00,103),
(3,'Yana',60200.00,101)

INSERT INTO Passports VALUES 
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')	

ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID
PRIMARY KEY (PersonId) 

ALTER TABLE Passports
ADD CONSTRAINT PK_PassportsId
PRIMARY KEY (PassportsId) 

ALTER TABLE Persons
ADD CONSTRAINT FK_PersonsPasspord
FOREIGN KEY (PassportId) REFERENCES Passports(PassportsId) 

SELECT *
FROM Persons AS p
JOIN Passports AS pass ON pass.PassportId = p.PassportId
-----
CREATE DATABASE OneToMany

USE OneToMany

CREATE TABLE Models(
 ModelID INT NOT NULL,
 Name VARCHAR(50),
 ManufacturerID INT
)

CREATE TABLE Manufacturers(
 ManufacturerId INT NOT NULL,
 Name VARCHAR(50),
 EstablishedOn DATE
)

INSERT INTO Models VALUES
(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)

INSERT INTO Manufacturers VALUES
(1, 'BMW','07/03/1916'),
(2, 'Tesla','01/01/2003'),
(3, 'Lada','01/05/1966')

ALTER TABLE Models
ADD CONSTRAINT PK_ModelsId
PRIMARY KEY (ModelId)

ALTER TABLE Manufacturers
ADD CONSTRAINT PK_ManufacturerId
PRIMARY KEY (ManufacturerId)

ALTER TABLE Models
ADD CONSTRAINT FK_ModelsManufacturers
FOREIGN KEY(ManufacturerId) REFERENCES Manufacturers(ManufacturerId)
-------
CREATE DATABASE ManyToMany

USE ManyToMany

CREATE TABLE Students(
StudentId INT NOT NULL,
[Name] NVARCHAR(50)
)

CREATE TABLE Exams(
ExamId INT NOT NULL,
[Name] NVARCHAR(50)
)

ALTER TABLE Students
ADD CONSTRAINT PK_StudentId
PRIMARY KEY(StudentId)

ALTER TABLE Exams
ADD CONSTRAINT PK_ExamId
PRIMARY KEY(ExamId)

CREATE TABLE StudentsExams(
StudentId INT NOT NULL,
ExamId INT NOT NULL
)

ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExamsId
PRIMARY KEY(StudentId, ExamId)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Students
FOREIGN KEY(StudentId) REFERENCES Students(StudentId)

ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Exams
FOREIGN KEY(ExamId) REFERENCES Exams(ExamId)

INSERT INTO Students VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO Exams VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)
-------
CREATE DATABASE SelfReferencing

Use SelfReferencing

CREATE TABLE Teachers(
TeacherID INT NOT NULL,
[Name] NVARCHAR(50),
ManagerID INT
)

ALTER TABLE Teachers
ADD CONSTRAINT PK_TeacherId
PRIMARY KEY(TeacherId)

ALTER TABLE Teachers
ADD CONSTRAINT FK_ManagerId
FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)

INSERT INTO Teachers VALUES
(101,'John',NULL),
(102,'Maya',106),
(103,'Silvia',106),
(104,'Ted',105),
(105,'Mark',101),
(106,'Greta',101)
-------
CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Orders(
OrderID INT NOT NULL,
CustomerID INT NOT NULL
)

CREATE TABLE Customers(
CustomerID INT NOT NULL,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT NOT NULL
)

CREATE TABLE Cities(
CityID INT NOT NULL,
[Name] VARCHAR(50)
)

CREATE TABLE OrderItems(
OrderID INT NOT NULL,
ItemID INT NOT NULL
)

CREATE TABLE Items(
ItemID INT NOT NULL,
[Name] VARCHAR(50),
ItemTypeID INT NOT NULL
)

CREATE TABLE ItemTypes(
ItemTypeID INT NOT NULL,
[Name] VARCHAR(50)
)

ALTER TABLE Orders
ADD CONSTRAINT PK_OrderId
PRIMARY KEY(OrderID)

ALTER TABLE Customers
ADD CONSTRAINT PK_CustomerId
PRIMARY KEY(CustomerID)

ALTER TABLE Orders
ADD CONSTRAINT FK_OrdersCustomers
FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)

ALTER TABLE Cities
ADD CONSTRAINT PK_CityId
PRIMARY KEY(CityID)

ALTER TABLE Customers
ADD CONSTRAINT FK_CustomerCities
FOREIGN KEY(CityID) REFERENCES Cities(CityID)

ALTER TABLE Items
ADD CONSTRAINT PK_ItemId
PRIMARY KEY(ItemID)

ALTER TABLE OrderItems
ADD CONSTRAINT PK_OrderItems
PRIMARY KEY(OrderID, ItemID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems
FOREIGN KEY(OrderID) REFERENCES Orders(OrderID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_Items
FOREIGN KEY(ItemID) REFERENCES Items(ItemID)

ALTER TABLE ItemTypes
ADD CONSTRAINT PK_ItemTypeId
PRIMARY KEY(ItemTypeID)

ALTER TABLE Items
ADD CONSTRAINT FK_ItemTypesItems
FOREIGN KEY(ItemTypeID) REFERENCES ItemTypes(ItemTypeID)

--------
CREATE DATABASE University

USE University

CREATE TABLE Majors(
MajorID INT NOT NULL,
[Name] VARCHAR(50)
)

CREATE TABLE Payments(
PaymentID INT NOT NULL,
PaymentDate DATE,
PaymentAmount DECIMAL(15, 2),
StudentID INT NOT NULL
)

CREATE TABLE Students(
StudentID INT NOT NULL,
StudentNumber VARCHAR(50),
StudentName VARCHAR(50),
MajorID INT NOT NULL
)

CREATE TABLE Agenda(
StudentID INT NOT NULL,
SubjectID INT NOT NULL
)

CREATE TABLE Subjects(
SubjectID INT NOT NULL,
SubjectName VARCHAR(50)
)

ALTER TABLE Majors
ADD CONSTRAINT PK_MajorsId
PRIMARY KEY(MajorID)

ALTER TABLE Payments
ADD CONSTRAINT PK_PaymentId
PRIMARY KEY(PaymentID)

ALTER TABLE Students
ADD CONSTRAINT PK_StudentId
PRIMARY KEY(StudentID)

ALTER TABLE Students
ADD CONSTRAINT FK_StudentsMajors
FOREIGN KEY(MajorID) REFERENCES Majors(MajorId)

ALTER TABLE Payments
ADD CONSTRAINT FK_PaymentsStudents
FOREIGN KEY(StudentID) REFERENCES Students(StudentID)

ALTER TABLE Subjects
ADD CONSTRAINT PK_SubjectId
PRIMARY KEY(SubjectID)

ALTER TABLE Agenda
ADD CONSTRAINT PK_AgendaId
PRIMARY KEY(StudentID, SubjectID)

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda
FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
FOREIGN KEY(SubjectID) REFERENCES Subjects(SubjectID)

-----
USE Geography

SELECT m.MountainRange, p.PeakName, p.Elevation
  FROM Peaks AS p
  JOIN Mountains AS m ON p.MountainId = m.Id
  WHERE m.MountainRange = 'Rila'
  ORDER BY p.Elevation DESC

SELECT (
       SELECT MountainRange FROM Mountains WHERE MountainRange = 'Rila'
	   ) AS [MountainRange] ,
	   PeakName, 
	   Elevation 
	   FROM Peaks
WHERE MountainId = (SELECT Id FROM Mountains WHERE MountainRange = 'Rila')
ORDER BY Elevation DESC