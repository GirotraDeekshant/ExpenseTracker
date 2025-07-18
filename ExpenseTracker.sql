USE [master]
GO
/****** Object:  Database [ExpenseTracker]    Script Date: 06-07-2025 16:45:52 ******/
CREATE DATABASE [ExpenseTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ExpenseTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ExpenseTracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ExpenseTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ExpenseTracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ExpenseTracker] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExpenseTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExpenseTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ExpenseTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ExpenseTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ExpenseTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ExpenseTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [ExpenseTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ExpenseTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ExpenseTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ExpenseTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ExpenseTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ExpenseTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ExpenseTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ExpenseTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ExpenseTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ExpenseTracker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ExpenseTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ExpenseTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ExpenseTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ExpenseTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ExpenseTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ExpenseTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ExpenseTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ExpenseTracker] SET RECOVERY FULL 
GO
ALTER DATABASE [ExpenseTracker] SET  MULTI_USER 
GO
ALTER DATABASE [ExpenseTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ExpenseTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ExpenseTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ExpenseTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ExpenseTracker] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ExpenseTracker] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ExpenseTracker', N'ON'
GO
ALTER DATABASE [ExpenseTracker] SET QUERY_STORE = ON
GO
ALTER DATABASE [ExpenseTracker] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ExpenseTracker]
GO
/****** Object:  Table [dbo].[Budget]    Script Date: 06-07-2025 16:45:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Budget](
	[BudgetId] [uniqueidentifier] NOT NULL,
	[LimitAmount] [varchar](200) NOT NULL,
	[Month] [varchar](200) NOT NULL,
	[Year] [varchar](200) NOT NULL,
	[CatId] [varchar](200) NOT NULL,
	[UserId] [varchar](500) NOT NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedBy] [varchar](500) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 06-07-2025 16:45:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CatId] [uniqueidentifier] NOT NULL,
	[CatName] [varchar](200) NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedBy] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 06-07-2025 16:45:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[TransactionsId] [uniqueidentifier] NOT NULL,
	[Title] [varchar](200) NULL,
	[Amount] [varchar](200) NOT NULL,
	[Dates] [datetime] NOT NULL,
	[Typeid] [varchar](200) NOT NULL,
	[CatId] [varchar](200) NOT NULL,
	[UserId] [varchar](500) NOT NULL,
	[Notes] [varchar](200) NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedBy] [varchar](500) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 06-07-2025 16:45:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[TypesId] [uniqueidentifier] NOT NULL,
	[TypeName] [varchar](200) NULL,
	[CreatedTime] [datetime] NULL,
	[CreatedBy] [varchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06-07-2025 16:45:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [uniqueidentifier] NOT NULL,
	[Username] [varchar](200) NULL,
	[Password] [varchar](500) NULL,
	[Email] [varchar](200) NOT NULL,
	[Emailverified] [bit] NULL,
	[CreatedTime] [datetime] NULL,
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Budget] ADD  DEFAULT (newid()) FOR [BudgetId]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (newid()) FOR [CatId]
GO
ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (newid()) FOR [TransactionsId]
GO
ALTER TABLE [dbo].[Types] ADD  DEFAULT (newid()) FOR [TypesId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (newid()) FOR [UserId]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [Emailverified]
GO
USE [master]
GO
ALTER DATABASE [ExpenseTracker] SET  READ_WRITE 
GO
