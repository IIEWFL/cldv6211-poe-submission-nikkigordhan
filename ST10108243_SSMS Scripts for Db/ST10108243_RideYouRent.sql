--Creates the database. 
	USE master
	IF EXISTS (SELECT * FROM Sys.databases WHERE name = 'RideYouRent')
	DROP DATABASE RideYouRent
	CREATE DATABASE RideYouRent
	GO
	USE RideYouRent
	GO 

--Creates the tables.
	IF OBJECT_ID (N'CarMake', N'U') IS NOT NULL 
	DROP TABLE CarMake
	GO
	CREATE TABLE CarMake
	(
		CarMakeId int IDENTITY(1,1) PRIMARY KEY,
		Description varchar (255),
	);


	IF OBJECT_ID (N'CarBodyType', N'U') IS NOT NULL 
	DROP TABLE CarBodyType
	GO
	CREATE TABLE CarBodyType
	(
		CarBodyTypeId int IDENTITY(1,1) PRIMARY KEY,
		Description varchar (255),
	);

	IF OBJECT_ID (N'Car', N'U') IS NOT NULL 
	DROP TABLE Car
	GO
	CREATE TABLE Car
	(
		CarId int IDENTITY(1,1) PRIMARY KEY,
		CarNo varchar (6) NOT NULL,
		CarMakeId int NOT NULL,
		CarBodyTypeId int NOT NULL,
		Model varchar (200) NOT NULL,
		KilometersTravelled int NOT NULL,
		ServiceKilometers int NOT NULL,
		Available bit NOT NULL,
	
		CONSTRAINT CarMakeId_fk
			FOREIGN KEY (CarMakeId)
			REFERENCES CarMake (CarMakeId),

		CONSTRAINT CarBodyType_fk
			FOREIGN KEY (CarBodyTypeId)
			REFERENCES CarBodyType (CarBodyTypeId),
	);

	IF OBJECT_ID (N'Driver', N'U') IS NOT NULL 
	DROP TABLE Driver
	GO
	CREATE TABLE Driver
	(
		DriveId int IDENTITY(1,1) PRIMARY KEY,
		Name varchar (200),
		Address varchar (150),
		Email varchar (50),
		Mobile varchar (10),
	);

	IF OBJECT_ID (N'Inspector', N'U') IS NOT NULL 
	DROP TABLE Inspector
	GO
	CREATE TABLE Inspector
	(
		InspectorId int IDENTITY(1,1) PRIMARY KEY,
		InspectorNo varchar (4),
		Name varchar (200),
		Email varchar (50),
		Mobile varchar (10)
	);

	IF OBJECT_ID (N'tblRental', N'U') IS NOT NULL 
	DROP TABLE tblRental
	GO
	CREATE TABLE tblRental
	(
		Rental_ID int IDENTITY(1,1) PRIMARY KEY,
		Car_ID int,
		Inspector_ID int,
		Driver_ID int,
		Rental_Fee money,
		Start_Date date,
		End_Date date
	);

	IF OBJECT_ID (N'tblReturn', N'U') IS NOT NULL 
	DROP TABLE tblReturn
	GO
	CREATE TABLE tblReturn
	(
		Return_ID int IDENTITY(1,1) PRIMARY KEY,
		Car_ID int,
		Inspector_ID int,
		Driver_ID int,
		Return_Date date,
		Elapsed_Date int,
		Fine money
	);

--Populates the tables 
	--Populates the Car_Make table
		INSERT INTO CarMake (Description)
		VALUES ('Hyundai');

		INSERT INTO CarMake (Description)
		VALUES ('BMW');

		INSERT INTO CarMake (Description)
		VALUES ('Mercedes Benz');

		INSERT INTO CarMake (Description)
		VALUES ('Toyota');

		INSERT INTO CarMake (Description)
		VALUES ('Ford');

--Checking to see the recoreds in the table
	SELECT *
	FROM CarMake;

	--Populates the Car_Body_Type table
		INSERT INTO CarBodyType (Description)
		VALUES ('Hatchback');

		INSERT INTO CarBodyType (Description)
		VALUES ('Sedan');

		INSERT INTO CarBodyType (Description)
		VALUES ('Coupe');

		INSERT INTO CarBodyType (Description)
		VALUES ('SUV');

--Checking to see the recoreds in the table
	SELECT * 
	FROM CarBodyType;

	--Populates the Car table
		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('HYU001',1,1,'Grand i10 1.0 Motion', 1500,15000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('HYU002',1,1,'i20 1.2 Fluid', 3000,15000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('BMW001',2,2,'320d 1.', 20000,50000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('BMW002',2,2,'240d 1.4', 9500,15000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('TOY001',4,2,'Corolla 1.0', 15000,50000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('TOY002',4,4,'Avanza 1.0', 98000,15000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('TOY003',4,2,'Corolla Quest 1.0', 15000,50000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('MER001',3,2,'c180', 5200,15000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('MER002',3,2,'A200 Sedan', 4080,15000,1);

		INSERT INTO Car (CarNo,CarMakeId,CarBodyTypeId,Model,KilometersTravelled,ServiceKilometers,Available)
		VALUES ('FOR001',5,2,'Fiesta 1.0', 7600,15000,1);


--Checking to see the recoreds in the table
	SELECT *
	FROM Car;
	
	--Populates the Driver table
		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Gabrielle Clarke', '917 Heuvel St Botshabelo Free State 9781', 'gorix10987@macauvpn.com', '0837113269');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Geoffrey Franklin', '1114 Dorp St Paarl Western Cape 7655', 'noceti8743@drlatvia.com', '0847728052');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Fawn Cooke', '2158 Prospect St Garsfontein Gauteng 0042', 'yegifav388@enamelme.com', '0821966584');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Darlene Peters', '2529 St. John Street Somerset West Western Cape 7110', 'mayeka4267@macauvpn.com', '0841221244');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Vita Soto', '1474 Wolmarans St Sundra Mpumalanga 2200', 'wegog55107@drlatvia.com', '0824567924');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Opal Rehbein', '697 Thutlwa St Letaba Limpopo 0870', 'yiyow34505@enpaypal.com', '0826864938');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Vernon Hodgson', '1935 Thutlwa St Letsitele Limpopo 0885', 'gifeh11935@enamelme.com', '0855991446');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Crispin Wheatly', '330 Sandown Rd Cape Town Western Cape 8018', 'likon78255@macauvpn.com', '0838347945');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Melanie Cunningham', '616 Loop St Atlantis Western Cape 7350', 'sehapeb835@macauvpn.com', '0827329001');

		INSERT INTO Driver (Name, Address, Email, Mobile)
		VALUES ('Kevin Peay', '814 Daffodil Dr Elliotdale Eastern Cape 5118', 'xajic53991@enpaypal.com', '0832077149');

--Checking to see the recoreds in the table
	SELECT *
	FROM Driver;

	--Populates the Inspector table.
		INSERT INTO Inspector (Inspector_No, Name, Email, Mobile)
		VALUES ('I101', 'Bud Barnes', 'bud@therideyourent.com', '0821585359');

		INSERT INTO Inspector (Inspector_No, Name, Email, Mobile)
		VALUES ('I102', 'Tracy Reeves', 'tracy@therideyourent.com', '0822889988');

		INSERT INTO Inspector (Inspector_No, Name, Email, Mobile)
		VALUES ('I103', 'Sandra Goodwin', ' sandra@therideyourent.com', '0837695468');

		INSERT INTO Inspector (Inspector_No, Name, Email, Mobile)
		VALUES ('I104', 'Shannon Burke', 'shannon@therideyourent.com', '0836802514');

--Checking to see the recoreds in the table
	SELECT *
	FROM Inspector;

	--Populates the Rental table.
		INSERT INTO tblRental(Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (1,1,1,5000,'2021-08-30','2021-08-31');

		INSERT INTO tblRental (Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (2,1,1,5000,'2021-09-01','2021-09-10');

		INSERT INTO tblRental (Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (4,2,5,7000,'2021-09-20','2021-09-25');

		INSERT INTO tblRental (Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (6,2,4,5000,'2021-10-03','2021-10-31');

		INSERT INTO tblRental (Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (8,3,4,8000,'2021-10-05','2021-10-15');

		INSERT INTO tblRental (Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (2,4,7,5000,'2021-12-01','2022-02-10');

		INSERT INTO tblRental (Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (7,4,9,5000,'2021-08-10','2021-08-31');

		INSERT INTO tblRental (Car_ID,Inspector_ID,Driver_ID,Rental_Fee,Start_Date,End_Date)
		VALUES (10,1,2,6500,'2021-09-01','2021-09-10');

--Checking to see the recoreds in the table
	SELECT *
	FROM tblRental;

	--Populates the Return table.
		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (1,1,1,'2021-08-31',0,0);

		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (2,1,1,'2021-09-10',0,0);

		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (10,1,2,'2021-09-10',0,0);

		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (4,2,5,'2021-09-30',5,2500);

		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (6,2,4,'2021-10-31',2,1000);

		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (8,3,4,'2021-10-15',1,500);

		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (2,4,7,'2022-02-10',0,0);

		INSERT INTO tblReturn (Car_ID,Inspector_ID,Driver_ID,Return_Date,Elapsed_Date,Fine)
		VALUES (7,4,9,'2021-08-31',0,0);

--Checking to see the recoreds in the table
	SELECT *
	FROM tblReturn;

--Query 5
	SELECT *
	FROM tblRental 
	WHERE Start_Date Between '2021-08-01' AND '2021-10-30';

--Query 6
	SELECT C.CarNo,
		I.Name,
		D.Name,
		R.Rental_Fee,R.Start_Date,R.End_Date
		FROM tblRental R
		INNER JOIN Inspector I
			ON R.Inspector_ID = I.InspectorId
		INNER JOIN Car C
			ON C.CarId = R.Car_ID
		INNER JOIN Driver D
			ON D.DriveId = R.Driver_ID
		WHERE I.Name = 'Bud Barnes';

--Query 7
	SELECT C.Car_No,
		I.Name,
		D.Name,
		R.Return_Date,R.Elapsed_Date,R.Fine
		FROM tblReturn R
			INNER JOIN Car C
				ON R.Car_ID = C.CarId
			INNER JOIN CarMake CM
				ON C.CarMakeId = CM.CarMakeId
			INNER JOIN Inspector I
				ON R.Inspector_ID = I.InspectorId
			INNER JOIN Driver D
				ON D.DriveId = R.Driver_ID
		WHERE CM.Description = 'Toyota';

--Query 8
	SELECT CM.Description, COUNT(CM.Description) AS NoOfHyundai
		FROM tblReturn R
			INNER JOIN Car C
				ON R.Car_ID = C.CarId
			INNER JOIN CarMake CM
				ON C.CarMakeId = CM.CarMakeId
			INNER JOIN Inspector I
				ON R.Inspector_ID = I.InspectorId
			INNER JOIN Driver D
				ON D.DriveId = R.Driver_ID
		WHERE CM.Description = 'Hyundai'
		GROUP BY CM.Description;

--Query 9
	/*SELECT *
		FROM tblCar
		WHERE Car_No = 'FOR001';*/

	UPDATE Car
		SET Model  = 'Focus'
		WHERE CarNo = 'FOR001';

--Query 10
	SELECT C.CarNo,
		D.Name,
		R.Rental_Fee,R.Start_Date,R.End_Date,
		C.Available
		FROM tblRental R
			INNER JOIN Car C
				ON R.Car_ID = C.CarId
			INNER JOIN Driver D
				ON D.DriveId = R.Driver_ID
		WHERE Available = 1;

--Query 11
	SELECT DISTINCT Description
		FROM CarMake;

--Query 12
	SELECT C.CarNo,
	CM.Description,
	C.Model,
	CBT.Description,
	C.KilometersTravelled, C.ServiceKilometers

	FROM Car C
		INNER JOIN CarMake CM
			ON C.CarMakeId = CM.CarMakeId
		INNER JOIN CarBodyType CBT
			ON C.CarBodyTypeId = CBT.CarBodyTypeId
	WHERE KilometersTravelled BETWEEN (ServiceKilometers - 9000) AND ServiceKilometers;

--Query 13
	SELECT c.CarNo,
	I.Name,
	D.Name,
	R.Return_Date,R.Elapsed_Date,R.Fine,( DATEDIFF(year,GETDATE(),Return_Date) * 500) AS TotalFine
	FROM tblReturn R
		INNER JOIN Car C
				ON C.CarId = R.Car_ID
		INNER JOIN Inspector I
				ON R.Inspector_ID = I.InspectorId
		INNER JOIN Driver D
				ON D.DriveId = R.Driver_ID;

-- ********** Set up scripts for the azure db --
USE [RideYouRent]
GO

INSERT INTO [dbo].[CarBodyType]
           ([Description])
     VALUES
           ()
GO
select [Description] from  [dbo].[CarBodyType]



Select Description, 'INSERT INTO [dbo].[CarBodyType]
           ([Description])
     VALUES
           (''' +  [Description] + ''')'
		   
		   from [dbo].[CarBodyType]

INSERT INTO [dbo].[CarBodyType] ([Description])       VALUES             ('Hatchback')
INSERT INTO [dbo].[CarBodyType] ([Description])       VALUES             ('Sedan')
INSERT INTO [dbo].[CarBodyType] ([Description])       VALUES             ('Coupe')
INSERT INTO [dbo].[CarBodyType] ([Description])       VALUES             ('SUV')

INSERT INTO [dbo].[CarMake]
           ([Description])
     VALUES
           ()
GO
select [Description] from  [dbo].[CarMake]



Select Description, 'INSERT INTO [dbo].[CarMake]
           ([Description])
     VALUES
           (''' +  [Description] + ''')'
		   
		   from [dbo].[CarMake]
INSERT INTO [dbo].[CarMake]             ([Description])       VALUES             ('Hyundai')
INSERT INTO [dbo].[CarMake]             ([Description])       VALUES             ('BMW')
INSERT INTO [dbo].[CarMake]             ([Description])       VALUES             ('Mercedes Benz')
INSERT INTO [dbo].[CarMake]             ([Description])       VALUES             ('Toyota')
INSERT INTO [dbo].[CarMake]             ([Description])       VALUES             ('Ford')