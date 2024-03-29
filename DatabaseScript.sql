USE [master]
GO
/****** Object:  Database [IncomExpenseDB]    Script Date: 9/28/2019 11:17:43 AM ******/
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
/****** Object:  Table [dbo].[BankInfo]    Script Date: 9/28/2019 11:17:44 AM ******/
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
/****** Object:  Table [dbo].[Expense]    Script Date: 9/28/2019 11:17:44 AM ******/
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
/****** Object:  Table [dbo].[Income]    Script Date: 9/28/2019 11:17:44 AM ******/
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
/****** Object:  Table [dbo].[RegistrationEmployee]    Script Date: 9/28/2019 11:17:44 AM ******/
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
SET IDENTITY_INSERT [dbo].[RegistrationEmployee] ON 

INSERT [dbo].[RegistrationEmployee] ([Id], [Name], [Email], [Designation], [Password]) VALUES (1, N'Nasim Uddin', N'nasim@mail.com', N'Jr Accountant', N'12345')
INSERT [dbo].[RegistrationEmployee] ([Id], [Name], [Email], [Designation], [Password]) VALUES (2, N'Sabbir Rahman', N'sabbir@gmail.com', N'Sr Accountant', N'12345')
INSERT [dbo].[RegistrationEmployee] ([Id], [Name], [Email], [Designation], [Password]) VALUES (3, N'Atikur Rahman', N'atik@gmail.com', N'Jr Accountant', N'12345')
SET IDENTITY_INSERT [dbo].[RegistrationEmployee] OFF
USE [master]
GO
ALTER DATABASE [IncomExpenseDB] SET  READ_WRITE 
GO
