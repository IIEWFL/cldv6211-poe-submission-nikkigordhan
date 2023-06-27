USE [RideYouRentDb]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[CarNo] [varchar](6) NOT NULL,
	[CarMakeId] [int] NOT NULL,
	[CarBodyTypeId] [int] NOT NULL,
	[Model] [varchar](200) NOT NULL,
	[KilometersTravelled] [int] NOT NULL,
	[ServiceKilometers] [int] NOT NULL,
	[Available] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarBodyType]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarBodyType](
	[CarBodyTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarBodyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarMake]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarMake](
	[CarMakeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CarMakeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Driver]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[DriverId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inspector]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inspector](
	[InspectorId] [int] IDENTITY(1,1) NOT NULL,
	[InspectorNo] [varchar](4) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Mobile] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Inspector] PRIMARY KEY CLUSTERED 
(
	[InspectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[InspectorID] [int] NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblRental]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRental](
	[Rental_ID] [int] IDENTITY(1,1) NOT NULL,
	[Car_ID] [int] NOT NULL,
	[Inspector_ID] [int] NOT NULL,
	[Driver_ID] [int] NOT NULL,
	[Rental_Fee] [money] NOT NULL,
	[Start_Date] [date] NOT NULL,
	[End_Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Rental_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblReturn]    Script Date: 2023/06/26 17:53:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblReturn](
	[Return_ID] [int] IDENTITY(1,1) NOT NULL,
	[Car_ID] [int] NOT NULL,
	[Inspector_ID] [int] NOT NULL,
	[Driver_ID] [int] NOT NULL,
	[Return_Date] [date] NOT NULL,
	[Elapsed_Date] [int] NOT NULL,
	[Fine] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[Return_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [Car_Body_Type_fk] FOREIGN KEY([CarBodyTypeId])
REFERENCES [dbo].[CarBodyType] ([CarBodyTypeId])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [Car_Body_Type_fk]
GO
ALTER TABLE [dbo].[Car]  WITH CHECK ADD  CONSTRAINT [Car_Make_ID_fk] FOREIGN KEY([CarMakeId])
REFERENCES [dbo].[CarMake] ([CarMakeId])
GO
ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [Car_Make_ID_fk]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [Login_Inspector_fk] FOREIGN KEY([InspectorID])
REFERENCES [dbo].[Inspector] ([InspectorId])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [Login_Inspector_fk]
GO
ALTER TABLE [dbo].[tblRental]  WITH CHECK ADD  CONSTRAINT [Rental_Car_fk] FOREIGN KEY([Car_ID])
REFERENCES [dbo].[Car] ([CarId])
GO
ALTER TABLE [dbo].[tblRental] CHECK CONSTRAINT [Rental_Car_fk]
GO
ALTER TABLE [dbo].[tblRental]  WITH CHECK ADD  CONSTRAINT [Rental_Driver_fk] FOREIGN KEY([Driver_ID])
REFERENCES [dbo].[Driver] ([DriverId])
GO
ALTER TABLE [dbo].[tblRental] CHECK CONSTRAINT [Rental_Driver_fk]
GO
ALTER TABLE [dbo].[tblRental]  WITH CHECK ADD  CONSTRAINT [Rental_Inspector_fk] FOREIGN KEY([Inspector_ID])
REFERENCES [dbo].[Inspector] ([InspectorId])
GO
ALTER TABLE [dbo].[tblRental] CHECK CONSTRAINT [Rental_Inspector_fk]
GO
ALTER TABLE [dbo].[tblReturn]  WITH CHECK ADD  CONSTRAINT [Return_Car_fk] FOREIGN KEY([Car_ID])
REFERENCES [dbo].[Car] ([CarId])
GO
ALTER TABLE [dbo].[tblReturn] CHECK CONSTRAINT [Return_Car_fk]
GO
ALTER TABLE [dbo].[tblReturn]  WITH CHECK ADD  CONSTRAINT [Return_Driver_fk] FOREIGN KEY([Driver_ID])
REFERENCES [dbo].[Driver] ([DriverId])
GO
ALTER TABLE [dbo].[tblReturn] CHECK CONSTRAINT [Return_Driver_fk]
GO
ALTER TABLE [dbo].[tblReturn]  WITH CHECK ADD  CONSTRAINT [Return_Inspector_fk] FOREIGN KEY([Inspector_ID])
REFERENCES [dbo].[Inspector] ([InspectorId])
GO
ALTER TABLE [dbo].[tblReturn] CHECK CONSTRAINT [Return_Inspector_fk]
GO
