USE [master]
GO
/****** Object:  Database [IncomExpenseDB]    Script Date: 10/11/2019 2:34:27 AM ******/
CREATE DATABASE [IncomExpenseDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IncomExpenseDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\IncomExpenseDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'IncomExpenseDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\IncomExpenseDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [IncomExpenseDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IncomExpenseDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IncomExpenseDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IncomExpenseDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IncomExpenseDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [IncomExpenseDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IncomExpenseDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET RECOVERY FULL 
GO
ALTER DATABASE [IncomExpenseDB] SET  MULTI_USER 
GO
ALTER DATABASE [IncomExpenseDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IncomExpenseDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IncomExpenseDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IncomExpenseDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [IncomExpenseDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IncomExpenseDB', N'ON'
GO
USE [IncomExpenseDB]
GO
/****** Object:  Table [dbo].[BankInfo]    Script Date: 10/11/2019 2:34:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](500) NOT NULL,
	[AccountNumber] [varchar](50) NOT NULL,
	[CurrentBalance] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_BankInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 10/11/2019 2:34:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Expense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApproveStatus] [varchar](50) NULL,
	[Date] [date] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[PaymentType] [varchar](50) NOT NULL,
	[CheckNo] [varchar](50) NULL,
	[BankName] [varchar](200) NULL,
	[Particular] [varchar](500) NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Income]    Script Date: 10/11/2019 2:34:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Income](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApprovalStatus] [varchar](50) NULL,
	[Date] [date] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[PaymentType] [varchar](50) NOT NULL,
	[CheckNo] [varchar](50) NULL,
	[BankName] [varchar](200) NULL,
	[Particular] [varchar](500) NULL,
 CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RegistrationEmployee]    Script Date: 10/11/2019 2:34:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RegistrationEmployee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
 CONSTRAINT [PK_RegistrationEmployee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BankInfo] ON 

INSERT [dbo].[BankInfo] ([Id], [BankName], [AccountNumber], [CurrentBalance]) VALUES (1, N'Rupali Bank', N'Cur-123456789', CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[BankInfo] OFF
SET IDENTITY_INSERT [dbo].[Expense] ON 

INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (21, N'Yes', CAST(N'2019-01-01' AS Date), CAST(200000.00 AS Decimal(18, 2)), N'Check', N'159786314', N'Rupali Bank', N'10pcs Hp PC')
INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (22, N'No', CAST(N'2019-01-02' AS Date), CAST(5000.00 AS Decimal(18, 2)), N'Cash', N'', N'Select Your Bank Name', N'Buy a Table')
INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (23, N'Yes', CAST(N'2019-02-12' AS Date), CAST(20000.00 AS Decimal(18, 2)), N'Cash', N'', N'Select Your Bank Name', N'buy 10pcs Power supply')
INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (24, N'No', CAST(N'2019-03-12' AS Date), CAST(60000.00 AS Decimal(18, 2)), N'Cash', N'', N'Select Your Bank Name', N'20pcs HDD 1TB,RAM 4GB 10pcs,')
INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (25, N'Yes', CAST(N'2019-06-11' AS Date), CAST(100000.00 AS Decimal(18, 2)), N'Cash', N'', N'Select Your Bank Name', N'Buy 20pcs Monitor')
INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (26, N'No', CAST(N'2019-04-24' AS Date), CAST(100000.00 AS Decimal(18, 2)), N'Cash', N'', N'Select Your Bank Name', N'10pcs Gigabyte,10pcs Esonic MotherBoard')
INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (27, N'Yes', CAST(N'2019-01-08' AS Date), CAST(50000.00 AS Decimal(18, 2)), N'Cash', N'', N'Select Your Bank Name', N'20pcs Power supply')
INSERT [dbo].[Expense] ([Id], [ApproveStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (28, N'No', CAST(N'2019-01-18' AS Date), CAST(15000.00 AS Decimal(18, 2)), N'Cash', N'', N'Select Your Bank Name', N'20pcs Keyboard,20pcs Mouse')
SET IDENTITY_INSERT [dbo].[Expense] OFF
SET IDENTITY_INSERT [dbo].[Income] ON 

INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (37, N'Yes', CAST(N'2019-10-10' AS Date), CAST(30000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Sell a PC With Hp Monitor')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (38, N'No', CAST(N'2019-01-09' AS Date), CAST(50000.00 AS Decimal(18, 2)), N'Check', N'123456789', N'Marckentile Bank', N'HP Core i5 Laptop with 32 GB Pendrive')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (39, N'Yes', CAST(N'2019-01-21' AS Date), CAST(5000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Gigabyte motherboard ')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (40, N'No', CAST(N'2019-01-14' AS Date), CAST(80000.00 AS Decimal(18, 2)), N'Check', N'458796321', N'AB Bank', N'3pcs Hp Monitor,5 pcs Motherboard,Corei3 processor 2pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (41, N'Yes', CAST(N'2019-01-23' AS Date), CAST(800.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'1pcs Mouse,1pcs Keyboard')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (42, N'No', CAST(N'2019-02-05' AS Date), CAST(20000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'1pcs Computer')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (43, N'Yes', CAST(N'2019-02-12' AS Date), CAST(7000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Gigabyte motherboard')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (44, N'No', CAST(N'2019-02-19' AS Date), CAST(60000.00 AS Decimal(18, 2)), N'Check', N'985476321', N'Rupali Bank', N'10 pcs Hp Monitor')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (45, N'Yes', CAST(N'2019-02-20' AS Date), CAST(4500.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Dell Power supply 1pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (46, N'No', CAST(N'2019-03-06' AS Date), CAST(50000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Esonic Motherboard
')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (47, N'Yes', CAST(N'2019-03-14' AS Date), CAST(50000.00 AS Decimal(18, 2)), N'Check', N'789654123', N'AB Bank', N'3pcs Dell Monitor,HDD 5pcs 2TB')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (48, N'No', CAST(N'2019-04-03' AS Date), CAST(50000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Processeor corei3 5 pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (49, N'Yes', CAST(N'2019-10-17' AS Date), CAST(70000.00 AS Decimal(18, 2)), N'Check', N'154698632', N'One Bank', N'Dell PC 2 pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (50, N'No', CAST(N'2019-05-05' AS Date), CAST(15000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Motherboard 3 pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (51, N'Yes', CAST(N'2019-05-14' AS Date), CAST(7000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'RAM 4GB 3 pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (52, N'No', CAST(N'2019-06-24' AS Date), CAST(10000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'RAM 1GB 10pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (53, N'Yes', CAST(N'2019-05-12' AS Date), CAST(50000.00 AS Decimal(18, 2)), N'Check', N'1258874693', N'Rupali Bank', N'Dell Monitor 10 pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (54, N'No', CAST(N'2019-06-18' AS Date), CAST(20000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'HDD 2TB 10pcs')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (55, N'Yes', CAST(N'2019-07-01' AS Date), CAST(5000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'Gigabyte Motherboard')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (56, N'No', CAST(N'2019-07-08' AS Date), CAST(15000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'5pcs Dell power supply')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (57, N'Yes', CAST(N'2019-07-16' AS Date), CAST(7000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'1pcs Dell Monitor')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (58, N'No', CAST(N'2019-07-04' AS Date), CAST(80000.00 AS Decimal(18, 2)), N'Check', N'582369741', N'AB Bank', N'3pcs HP PC ')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (59, N'Yes', CAST(N'2019-08-04' AS Date), CAST(15000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'3pcs Monitor HP')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (60, N'No', CAST(N'2019-08-20' AS Date), CAST(20000.00 AS Decimal(18, 2)), N'', N'', N'', N'3pcs Processor corei3')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (61, N'Yes', CAST(N'2019-09-01' AS Date), CAST(50000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'5pcs Dell Monitor')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (62, N'No', CAST(N'2019-09-17' AS Date), CAST(20000.00 AS Decimal(18, 2)), N'', N'', N'', N'7pcs Power supply ')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (63, N'Yes', CAST(N'2019-09-17' AS Date), CAST(120000.00 AS Decimal(18, 2)), N'Check', N'1597536482', N'Marckentile Bank', N'5pcs Hp Pc')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (64, N'No', CAST(N'2017-01-02' AS Date), CAST(20000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'5pcs Motherboard')
INSERT [dbo].[Income] ([Id], [ApprovalStatus], [Date], [Amount], [PaymentType], [CheckNo], [BankName], [Particular]) VALUES (65, N'Yes', CAST(N'2018-02-13' AS Date), CAST(15000.00 AS Decimal(18, 2)), N'Cash', N'', N'', N'1pcs PC')
SET IDENTITY_INSERT [dbo].[Income] OFF
SET IDENTITY_INSERT [dbo].[RegistrationEmployee] ON 

INSERT [dbo].[RegistrationEmployee] ([Id], [Name], [Email], [Designation], [Password]) VALUES (1, N'Nasim Uddin', N'nasim@gmail.com', N'Jr Accountant', N'12345')
INSERT [dbo].[RegistrationEmployee] ([Id], [Name], [Email], [Designation], [Password]) VALUES (2, N'Sabbir Rahman', N'sabbir@gmail.com', N'Sr Accountant', N'12345')
INSERT [dbo].[RegistrationEmployee] ([Id], [Name], [Email], [Designation], [Password]) VALUES (3, N'Atikur Rahman', N'atik@gmail.com', N'Jr Accountant', N'12345')
INSERT [dbo].[RegistrationEmployee] ([Id], [Name], [Email], [Designation], [Password]) VALUES (4, N'Siam Ahmed', N'siam@gmail.com', N'Sr Accountant', N'12345')
SET IDENTITY_INSERT [dbo].[RegistrationEmployee] OFF
USE [master]
GO
ALTER DATABASE [IncomExpenseDB] SET  READ_WRITE 
GO
