SELECT TOP 1 * FROM TableA ORDER BY TableAId ASC

-- [1] Common in both tables (INNER JOIN)
SELECT 
	TableA.*, 
	TableB.*
FROM 
	TableA INNER JOIN TableB
		ON TableA.TableAId = TableB.TableBId

-- [2] Everything in A and what matches in B
SELECT
	TableA.*,
	TableB.*
FROM TableA LEFT JOIN TableB
		ON TableA.TableAId = TableB.TableBId
		
-- [3] Everything in B and what matches in A
SELECT
	TableA.*,
	TableB.*
FROM TableA RIGHT JOIN TableB
		ON TableA.TableAId = TableB.TableBId

-- [4] (A - B) Everything in A remove any matched B records
SELECT 
	TableA.*,
	TableB.*
FROM
	TableA LEFT JOIN TableB
		ON TableA.TableAId = TableB.TableBId
WHERE TableB.TableBId IS NULL

-- [5] (B - A) Everything in B remove any match A records
SELECT
	TableA.*,
	TableB.*
FROM
	TableA RIGHT JOIN TableB
		ON TableA.TableAId = TableB.TableBId						
WHERE
	TableA.TableAId IS NULL

-- [6] Everything in A and B
SELECT 
	TableA.*,
	TableB.*
FROM
	TableA FULL OUTER JOIN TableB
		ON TableA.TableAId = TableB.TableBId

-- [7] Everything in A and B - minus the matching records
SELECT 
	TableA.*,
	TableB.*
FROM 
	TableA FULL OUTER JOIN TableB
		ON TableA.TableAId = TableB.TableBId
WHERE
	TableA.TableAId IS NULL OR TableB.TableBId IS NULL


/*
CREATE TABLE [dbo].[TableA]
(
	[TableAId] INT NOT NULL PRIMARY KEY ,
	[Description] VARCHAR(150)
)

CREATE TABLE [dbo].[TableB]
(
	[TableBId] INT NOT NULL PRIMARY KEY ,
	[Description] VARCHAR(150)
)

INSERT INTO TableA (TableAId, Description) VALUES (1, 'AAA');

INSERT INTO TableA (TableAId, Description) VALUES (3, 'CCC');
INSERT INTO TableA (TableAId, Description) VALUES (4, 'DDD');
INSERT INTO TableA (TableAId, Description) VALUES (5, 'EEE');
INSERT INTO TableA (TableAId, Description) VALUES (6, 'FFF');
INSERT INTO TableA (TableAId, Description) VALUES (7, 'GGG');

INSERT INTO TableA (TableAId, Description) VALUES (9, 'III');

INSERT INTO TableB (TableBId, Description) VALUES (1, 'AAA');
INSERT INTO TableB (TableBId, Description) VALUES (2, 'BBB');
INSERT INTO TableB (TableBId, Description) VALUES (3, 'CCC');

INSERT INTO TableB (TableBId, Description) VALUES (5, 'EEE');
INSERT INTO TableB (TableBId, Description) VALUES (6, 'FFF');

INSERT INTO TableB (TableBId, Description) VALUES (8, 'HHH');
INSERT INTO TableB (TableBId, Description) VALUES (9, 'III');
*/

SELECT A.*
FROM TableA A
WHERE 5 > SOME (SELECT B.TableBId FROM TableB B)


SELECT 'YES'
WHERE 4 NOT IN (1, 2, 3, NULL)

SELECT
	CASE 1
	   WHEN 1 THEN 'One'
	   WHEN 2 THEN 'Two'
	   WHEN 3 THEN 'Three'
	   ELSE '???'
	END

DECLARE @Age INT
SELECT @Age = 5  -- NULL

SELECT 
	CASE 
		WHEN @Age > 5 THEN 'Toddler'
		WHEN @Age > 10 THEN 'Pre-Teen'
		WHEN @Age > 20 THEN 'Teen'
		ELSE 'Adult'
	END

CREATE TABLE [dbo].[Employee]
(
	[EmployeeId] INT NOT NULL PRIMARY KEY ,
	[Salary] INT
)

INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (1, 53);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (2, 47);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (3, 28);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (5, 84);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (6, 26);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (7, 37);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (8, 97);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (9, 35);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (10, 12);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (11, 76);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (12, 38);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (13, 134);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (14, 64);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (15, 75);
INSERT INTO [Employee] ([EmployeeId], Salary) VALUES (16, 48);

SELECT TOP (1) A.*
FROM (
	SELECT TOP (10) EmployeeId, Salary
	FROM Employee
	ORDER BY Salary DESC
) AS A
ORDER BY A.Salary ASC

SELECT TableA
UNION 
SELECT TableB

CREATE TABLE Persons
(
	PersonId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName varchar(255) NULL,
	LastName varchar(255) NULL
)

CREATE INDEX IX_Persons ON Persons (FirstName, LastName)

SELECT * FROM Persons

INSERT INTO Persons VALUES ('John1', ' Smith')
INSERT INTO Persons VALUES ('Sara1', 'Milk')

DELETE FROM Persons WHERE PersonId = 4

INSERT INTO Persons VALUES ('Biggie', 'Bob')

SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]
SELECT @@IDENTITY       AS [@@IDENTITY]

SELECT * FROM Persons;

THROW 50000, 'Failed!', 1;
SELECT ERROR_NUMBER()

BEGIN TRY
	BEGIN TRANSACTION myTX
		INSERT INTO Persons VALUES ('John1', ' Smith');
		INSERT INTO Persons VALUES ('Sara1', 'Milk');

		THROW 50000, 'Failure occurred!', 1;

	COMMIT TRANSACTION myTX
END TRY
BEGIN CATCH
	ROLLBACK TRANSACTION myTX
	SELECT 'Rollback transaction', ERROR_MESSAGE()
END CATCH

	BEGIN TRANSACTION myTX
		INSERT INTO Persons VALUES ('John1', ' Smith');
