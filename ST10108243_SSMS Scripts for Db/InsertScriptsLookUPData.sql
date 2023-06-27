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