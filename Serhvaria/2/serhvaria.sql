USE serhvaria
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('users') and type='U')
DROP TABLE users

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('movements') and type='U')
DROP TABLE movements

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('reports') and type='U')
DROP TABLE reports

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('trainings') and type='U')
DROP TABLE trainings

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('zones') and type='U')
DROP TABLE zones

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('ulists') and type='U')
DROP TABLE ulists

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('players') and type='U')
DROP TABLE players
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('users') and type='U')
CREATE TABLE users
(
	idp NUMERIC IDENTITY(1,1) NOT NULL PRIMARY KEY,
	uname VARCHAR(30) NOT NULL,
	pass VARCHAR(30) NOT NULL,
	fname VARCHAR(15) NOT NULL,
	lname VARCHAR(15) NOT NULL,
	email VARCHAR(30) NOT NULL,
	secq VARCHAR(100) NOT NULL,
	seca VARCHAR(20) NOT NULL	
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('players') and type='U')
CREATE TABLE players
(
	idp NUMERIC(3,0) NOT NULL PRIMARY KEY,
	name VARCHAR(30) NOT NULL,
	exp NUMERIC(3,0) NOT NULL
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('ulists') and type='U')
CREATE TABLE ulists
(
	idl NUMERIC IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nrp NUMERIC(3,0),
	nrw NUMERIC(3,0),
	nrd NUMERIC(3,0),
	nrb NUMERIC(3,0),
	nrc NUMERIC(3,0),
	nrs NUMERIC(3,0)
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('zones') and type='U')
CREATE TABLE zones
(
	idz NUMERIC(3,0) NOT NULL PRIMARY KEY,
	x NUMERIC(2,0) NOT NULL,
	y NUMERIC(2,0) NOT NULL,
	hp NUMERIC(3,0) NOT NULL,
	name VARCHAR(30) NOT NULL,
	idp NUMERIC(3,0) FOREIGN KEY REFERENCES players(idp),
	idl NUMERIC FOREIGN KEY REFERENCES ulists(idl)
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('movements') and type='U')
CREATE TABLE movements
(
	idm NUMERIC IDENTITY(1,1) NOT NULL PRIMARY KEY,
	iatk BIT NOT NULL,
	edate DATETIME NOT NULL,
	idzs NUMERIC(3,0) NOT NULL FOREIGN KEY REFERENCES zones(idz),
	idzd NUMERIC(3,0) NOT NULL FOREIGN KEY REFERENCES zones(idz),
	idl NUMERIC NOT NULL FOREIGN KEY REFERENCES ulists(idl)
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('trainings') and type='U')
CREATE TABLE trainings
(
	idt NUMERIC IDENTITY(1,1) NOT NULL PRIMARY KEY,
	unit VARCHAR(10) NOT NULL,
	idz NUMERIC(3,0) NOT NULL FOREIGN KEY REFERENCES zones(idz),
	edate DATE NOT NULL
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('reports') and type='U')
CREATE TABLE reports
(
	idr NUMERIC IDENTITY(1,1) NOT NULL PRIMARY KEY,
	dmg NUMERIC(3,0),
	edate DATE NOT NULL,
	idzs NUMERIC(3,0) NOT NULL FOREIGN KEY REFERENCES zones(idz),
	idzd NUMERIC(3,0) NOT NULL FOREIGN KEY REFERENCES zones(idz),
	idlsb NUMERIC NOT NULL FOREIGN KEY REFERENCES ulists(idl),
	idlsa NUMERIC NOT NULL FOREIGN KEY REFERENCES ulists(idl),
	idldb NUMERIC NOT NULL FOREIGN KEY REFERENCES ulists(idl),
	idlda NUMERIC NOT NULL FOREIGN KEY REFERENCES ulists(idl)
)
GO

DROP PROCEDURE populateZones;
GO

CREATE PROCEDURE populateZones
AS
	DECLARE @id numeric(3,0)=1
	DECLARE @cx numeric(2,0)=1
	DECLARE @cy numeric(2,0)=1
	WHILE (@cx<=20)
	BEGIN
		WHILE (@cy<=20)
		BEGIN
			INSERT INTO dbo.zones(idz, x, y, hp, name)
			VALUES(@id, @cx, @cy, 0, 'Unclaimed Zone')
			SET @id=@id+1
			SET @cy=@cy+1
		END		
		SET @cx=@cx+1
		SET @cy=1
	END
GO

EXEC populateZones;
GO