IF (OBJECT_ID('Cars') IS NOT NULL)
	DROP TABLE Cars;

IF (OBJECT_ID('Patrons') IS NOT NULL) 
	DROP TABLE Patrons;

CREATE TABLE Patrons
(
	PatronsId INT		   NOT NULL IDENTITY(1,1),
	FirstName VARCHAR(150) NOT NULL,
	LastName  VARCHAR(150) NOT NULL,
	StartDate DateTime     NOT NULL DEFAULT(GETDATE()),
	Age		  INT		   NOT NULL,

	CONSTRAINT Patrons_PatronsId_PK PRIMARY KEY(PatronsId),		
	CONSTRAINT Patrons_Age_Restriction_Limit CHECK([Age] > 18),
	CONSTRAINT Patrons_Unique_FN_LAN UNIQUE(FirstName, LastName)
);

CREATE TABLE Cars
(
	LicensePlate VARCHAR(10) NOT NULL PRIMARY KEY,
	Make		 VARCHAR(150) NOT NULL,
	Model		 VARCHAR(150) NOT NULL,
	Year		 INT NOT NULL,
	PatronsId	 INT NOT NULL,

	CONSTRAINT Cars_FK_PatronsId_Patrons FOREIGN KEY (PatronsId) References Patrons(PatronsId)
);

INSERT INTO Patrons VALUES
	('Albert','Smith', GETDATE(), 21)

INSERT INTO Patrons VALUES
	('Sam','Hillside', GETDATE(), 21)

INSERT INTO Patrons VALUES
	('Sally','Homne', GETDATE(), 34)


INSERT INTO Cars VALUES
	('AAA1234', 'Nissan', 'Altima', 2001, 1);

INSERT INTO Cars VALUES
	('BBB5667', 'Honda', 'Accord', 2001, 2);

SELECT * FROM Patrons;
SELECT * FROM Cars;

WITH CarsThatAreHonda AS
(
	SELECT * FROM Cars WHERE Make = 'Honda'
)
SELECT * FROM CarsThatAreHonda;

