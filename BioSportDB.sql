USE [master]
GO
/****** Object:  Database [BioSport]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE DATABASE [BioSport]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BioSport', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BioSport.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BioSport_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BioSport_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BioSport] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BioSport].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BioSport] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BioSport] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BioSport] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BioSport] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BioSport] SET ARITHABORT OFF 
GO
ALTER DATABASE [BioSport] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BioSport] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BioSport] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BioSport] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BioSport] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BioSport] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BioSport] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BioSport] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BioSport] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BioSport] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BioSport] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BioSport] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BioSport] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BioSport] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BioSport] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BioSport] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BioSport] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BioSport] SET RECOVERY FULL 
GO
ALTER DATABASE [BioSport] SET  MULTI_USER 
GO
ALTER DATABASE [BioSport] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BioSport] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BioSport] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BioSport] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BioSport] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BioSport] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BioSport', N'ON'
GO
ALTER DATABASE [BioSport] SET QUERY_STORE = OFF
GO
USE [BioSport]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[TrainerID] [int] NOT NULL,
	[AppointmentDate] [datetime] NOT NULL,
	[DurationInMinutes] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassReservations]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClassReservations](
	[ReservationID] [int] IDENTITY(1,1) NOT NULL,
	[ClassID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[ReservedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientDiscounts]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientDiscounts](
	[ClientDiscountID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[DiscountID] [int] NOT NULL,
	[AppliedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientDiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coupons]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupons](
	[CouponID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[DiscountID] [int] NOT NULL,
	[ExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CouponID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discounts]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discounts](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[DiscountType] [nvarchar](50) NOT NULL,
	[Percentage] [decimal](5, 2) NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercises]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercises](
	[ExerciseID] [int] IDENTITY(1,1) NOT NULL,
	[ExerciseTypeID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseTypes]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseTypes](
	[ExerciseTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ExerciseTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GroupClasses]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupClasses](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](100) NOT NULL,
	[Capacity] [int] NOT NULL,
	[Schedule] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measurements]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measurements](
	[MeasurementID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[TrainerID] [int] NOT NULL,
	[Weight] [decimal](5, 2) NULL,
	[Height] [decimal](5, 2) NULL,
	[BodyFatPercentage] [decimal](5, 2) NULL,
	[Age] [int] NULL,
	[Gender] [nvarchar](10) NULL,
	[MeasuredAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MeasurementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordHistory]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PasswordHistory](
	[HistoryID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PasswordHash] [varbinary](64) NOT NULL,
	[PasswordSalt] [varbinary](64) NOT NULL,
	[ChangedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[HistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentMethod] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalTrainingSessions]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalTrainingSessions](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[TrainerID] [int] NOT NULL,
	[ScheduledDate] [datetime] NOT NULL,
	[DurationInMinutes] [int] NOT NULL,
	[Cost] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoutineEquipment]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoutineEquipment](
	[RoutineEquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[RoutineExerciseID] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoutineEquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoutineExercises]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoutineExercises](
	[RoutineExerciseID] [int] IDENTITY(1,1) NOT NULL,
	[RoutineID] [int] NOT NULL,
	[ExerciseID] [int] NOT NULL,
	[Sets] [int] NULL,
	[Repetitions] [int] NULL,
	[Weight] [decimal](5, 2) NULL,
	[DurationInSeconds] [int] NULL,
	[AmrapTimeLimitInSeconds] [int] NULL,
	[AmrapRepetitions] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoutineExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routines]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routines](
	[RoutineID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[TrainerID] [int] NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoutineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subscriptions]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subscriptions](
	[SubscriptionID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[SubscriptionType] [nvarchar](50) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[SubscriptionStatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubscriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingLogs]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingLogs](
	[TrainingLogID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[RoutineExerciseID] [int] NOT NULL,
	[DateLogged] [datetime] NULL,
	[SetsCompleted] [int] NULL,
	[RepetitionsCompleted] [int] NULL,
	[WeightUsed] [decimal](5, 2) NULL,
	[DurationInSeconds] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TrainingLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCredentials]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCredentials](
	[CredentialID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PasswordHash] [varbinary](64) NOT NULL,
	[PasswordSalt] [varbinary](64) NOT NULL,
	[OTP] [nvarchar](6) NULL,
	[VerificationStatus] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CredentialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [int] NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[FirstLastName] [nvarchar](50) NOT NULL,
	[SecondLastName] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Cedula] UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_ClientID] ON [dbo].[Appointments]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_TrainerID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_TrainerID] ON [dbo].[Appointments]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassReservations_ClassID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_ClassReservations_ClassID] ON [dbo].[ClassReservations]
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassReservations_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_ClassReservations_ClientID] ON [dbo].[ClassReservations]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientDiscounts_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_ClientDiscounts_ClientID] ON [dbo].[ClientDiscounts]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientDiscounts_DiscountID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_ClientDiscounts_DiscountID] ON [dbo].[ClientDiscounts]
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Coupons_DiscountID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Coupons_DiscountID] ON [dbo].[Coupons]
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Measurements_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Measurements_ClientID] ON [dbo].[Measurements]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Measurements_TrainerID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Measurements_TrainerID] ON [dbo].[Measurements]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Payments_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Payments_ClientID] ON [dbo].[Payments]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainingSessions_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainingSessions_ClientID] ON [dbo].[PersonalTrainingSessions]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainingSessions_TrainerID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainingSessions_TrainerID] ON [dbo].[PersonalTrainingSessions]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutineEquipment_EquipmentID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_RoutineEquipment_EquipmentID] ON [dbo].[RoutineEquipment]
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutineEquipment_RoutineExerciseID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_RoutineEquipment_RoutineExerciseID] ON [dbo].[RoutineEquipment]
(
	[RoutineExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutineExercises_ExerciseID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_RoutineExercises_ExerciseID] ON [dbo].[RoutineExercises]
(
	[ExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutineExercises_RoutineID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_RoutineExercises_RoutineID] ON [dbo].[RoutineExercises]
(
	[RoutineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Routines_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Routines_ClientID] ON [dbo].[Routines]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Routines_TrainerID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Routines_TrainerID] ON [dbo].[Routines]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subscriptions_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_Subscriptions_ClientID] ON [dbo].[Subscriptions]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrainingLogs_ClientID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_TrainingLogs_ClientID] ON [dbo].[TrainingLogs]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TrainingLogs_RoutineExerciseID]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_TrainingLogs_RoutineExerciseID] ON [dbo].[TrainingLogs]
(
	[RoutineExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserDetails_UserName]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_UserDetails_UserName] ON [dbo].[UserCredentials]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserDetails_Email]    Script Date: 12-Jul-24 16:52:32 ******/
CREATE NONCLUSTERED INDEX [IX_UserDetails_Email] ON [dbo].[UserDetails]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[ClassReservations] ADD  DEFAULT (getdate()) FOR [ReservedAt]
GO
ALTER TABLE [dbo].[ClientDiscounts] ADD  DEFAULT (getdate()) FOR [AppliedAt]
GO
ALTER TABLE [dbo].[Measurements] ADD  DEFAULT (getdate()) FOR [MeasuredAt]
GO
ALTER TABLE [dbo].[PasswordHistory] ADD  DEFAULT (getdate()) FOR [ChangedAt]
GO
ALTER TABLE [dbo].[Payments] ADD  DEFAULT (getdate()) FOR [PaymentDate]
GO
ALTER TABLE [dbo].[Routines] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Subscriptions] ADD  DEFAULT ((1)) FOR [SubscriptionStatus]
GO
ALTER TABLE [dbo].[TrainingLogs] ADD  DEFAULT (getdate()) FOR [DateLogged]
GO
ALTER TABLE [dbo].[UserCredentials] ADD  DEFAULT ((0)) FOR [VerificationStatus]
GO
ALTER TABLE [dbo].[UserDetails] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([TrainerID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[ClassReservations]  WITH CHECK ADD FOREIGN KEY([ClassID])
REFERENCES [dbo].[GroupClasses] ([ClassID])
GO
ALTER TABLE [dbo].[ClassReservations]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[ClientDiscounts]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[ClientDiscounts]  WITH CHECK ADD FOREIGN KEY([DiscountID])
REFERENCES [dbo].[Discounts] ([DiscountID])
GO
ALTER TABLE [dbo].[Coupons]  WITH CHECK ADD FOREIGN KEY([DiscountID])
REFERENCES [dbo].[Discounts] ([DiscountID])
GO
ALTER TABLE [dbo].[Exercises]  WITH CHECK ADD FOREIGN KEY([ExerciseTypeID])
REFERENCES [dbo].[ExerciseTypes] ([ExerciseTypeID])
GO
ALTER TABLE [dbo].[Measurements]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Measurements]  WITH CHECK ADD FOREIGN KEY([TrainerID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[PasswordHistory]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[PersonalTrainingSessions]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[PersonalTrainingSessions]  WITH CHECK ADD FOREIGN KEY([TrainerID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[RoutineEquipment]  WITH CHECK ADD FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[RoutineEquipment]  WITH CHECK ADD FOREIGN KEY([RoutineExerciseID])
REFERENCES [dbo].[RoutineExercises] ([RoutineExerciseID])
GO
ALTER TABLE [dbo].[RoutineExercises]  WITH CHECK ADD FOREIGN KEY([ExerciseID])
REFERENCES [dbo].[Exercises] ([ExerciseID])
GO
ALTER TABLE [dbo].[RoutineExercises]  WITH CHECK ADD FOREIGN KEY([RoutineID])
REFERENCES [dbo].[Routines] ([RoutineID])
GO
ALTER TABLE [dbo].[Routines]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Routines]  WITH CHECK ADD FOREIGN KEY([TrainerID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Subscriptions]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[TrainingLogs]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[TrainingLogs]  WITH CHECK ADD FOREIGN KEY([RoutineExerciseID])
REFERENCES [dbo].[RoutineExercises] ([RoutineExerciseID])
GO
ALTER TABLE [dbo].[UserCredentials]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create New User
CREATE PROCEDURE [dbo].[CreateUser] (
    @CedulaP INT,
    @NombreP NVARCHAR(50),
	@FirstLastNameP NVARCHAR(50),
	@SecondLastNameP NVARCHAR(50),
	@PhoneP NVARCHAR(50),
	@EmailP NVARCHAR(100),
	@RoleNameP NVARCHAR(50)
)
AS
BEGIN	
    DECLARE @UserID INT;
    DECLARE @OTP NVARCHAR(6);
    DECLARE @PasswordHash VARBINARY(64);
    DECLARE @PasswordSalt VARBINARY(64);
    DECLARE @UserName NVARCHAR(50);
	DECLARE @RoleName NVARCHAR(50);

	IF EXISTS (SELECT Cedula FROM UserDetails WHERE Cedula = @CedulaP)
	BEGIN
		SELECT 'Cedula already exists, please try again' AS Message
	END

	ELSE IF EXISTS (SELECT Email FROM UserDetails WHERE Email = @EmailP)
    BEGIN
        SELECT 'Email already exists, please try again' AS Message
    END

	ELSE
	BEGIN
		INSERT INTO UserDetails ( Cedula, Nombre, FirstLastName, SecondLastName, Phone, Email)
		VALUES ( @CedulaP, @NombreP, @FirstLastNameP, @SecondLastNameP, @PhoneP, @EmailP)

		SET @UserID = SCOPE_IDENTITY();

		SET @OTP = RIGHT('000000' + CONVERT(NVARCHAR(6), ABS(CHECKSUM(NEWID())) % 1000000), 6);

		SET @UserName = @EmailP;

		SET @PasswordSalt = CAST(CRYPT_GEN_RANDOM(64) AS VARBINARY(64));

		SET @PasswordHash = HASHBYTES('SHA2_256', @OTP + CAST(@PasswordSalt AS NVARCHAR(64)));

		SET @RoleName = @RoleNameP;

		INSERT INTO UserCredentials (UserID, UserName, PasswordHash, PasswordSalt, OTP, VerificationStatus)
		VALUES (@UserID, @UserName, @PasswordHash, @PasswordSalt, @OTP, 0);

		EXEC SetUserRole @UserID, @RoleName;

		SELECT 'New user registered succesfully' AS Message, @OTP AS OTPCode;
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Find user based on email and verification status
CREATE PROCEDURE [dbo].[GetUser] (
    @EmailP NVARCHAR(100)
)
AS
BEGIN
    DECLARE @OTP NVARCHAR(6);
    DECLARE @UserID INT;
    DECLARE @VerificationStatus BIT;

    -- Check if the user exists based on the provided email
    IF EXISTS (SELECT Email FROM UserDetails WHERE Email = @EmailP)
    BEGIN
        -- Retrieve UserID and VerificationStatus
        SELECT 
            @UserID = UD.UserID, 
            @VerificationStatus = UC.VerificationStatus
        FROM 
            UserDetails UD
        JOIN 
            UserCredentials UC ON UD.UserID = UC.UserID
        WHERE 
            UD.Email = @EmailP;

        -- Check if the user has not been verified
        IF @VerificationStatus = 0
        BEGIN
            -- Inform the user to use the code sent to their email address
            SELECT 'Use the code sent to your email address' AS Message, @VerificationStatus AS OTPState;
        END
        ELSE
        BEGIN
            -- Generate a new 6-digit OTP
            SET @OTP = RIGHT('000000' + CONVERT(NVARCHAR(6), ABS(CHECKSUM(NEWID())) % 1000000), 6);

            -- Update the OTP in the UserCredentials table
            UPDATE UserCredentials
            SET OTP = @OTP
            WHERE UserID = @UserID;

            -- Inform the user about the new OTP
            SELECT 'A new OTP has been generated and sent to your email address' AS Message, @OTP AS OTPCode;
        END
    END
    ELSE
    BEGIN
        -- Inform the user that the email does not exist
        SELECT 'The email provided does not exist in our records.' AS Message;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[PasswordReset]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Password Reset
CREATE PROCEDURE [dbo].[PasswordReset] (
    @UserID INT,
    @NewPassword NVARCHAR(255)
)
AS
BEGIN
    DECLARE @Salt VARBINARY(64);
    DECLARE @PasswordHash VARBINARY(64);
    DECLARE @OldPasswordHash VARBINARY(64);
    DECLARE @OldPasswordSalt VARBINARY(64);
    DECLARE @MatchFound BIT = 0;

    -- Retrieve last five password hashes and salts
    DECLARE PasswordCursor CURSOR FOR
    SELECT TOP 5 PasswordHash, PasswordSalt
    FROM PasswordHistory
    WHERE UserID = @UserID
    ORDER BY ChangedAt DESC;

    OPEN PasswordCursor;

    FETCH NEXT FROM PasswordCursor INTO @OldPasswordHash, @OldPasswordSalt;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Hash the new password with the old salts and compare
        IF @OldPasswordHash = HASHBYTES('SHA2_256', @NewPassword + CAST(@OldPasswordSalt AS NVARCHAR(64)))
        BEGIN
            SET @MatchFound = 1;
        END
        FETCH NEXT FROM PasswordCursor INTO @OldPasswordHash, @OldPasswordSalt;
    END

    CLOSE PasswordCursor;
    DEALLOCATE PasswordCursor;

    IF @MatchFound = 1
    BEGIN
        -- Match found, reject the password        
        RAISERROR('New password cannot be the same as any of the last five passwords.', 16, 1);
        RETURN;
    END

    -- No match found, create new salt and hash
    SET @Salt = CAST(CRYPT_GEN_RANDOM(64) AS VARBINARY(64));
    SET @PasswordHash = HASHBYTES('SHA2_256', @NewPassword + CAST(@Salt AS NVARCHAR(64)));

    -- Update the password in UserCredentials
    UPDATE UserCredentials
    SET PasswordHash = @PasswordHash, PasswordSalt = @Salt
    WHERE UserID = @UserID;

    -- Insert new password into PasswordHistory table
    INSERT INTO PasswordHistory (UserID, PasswordHash, PasswordSalt, ChangedAt)
    VALUES (@UserID, @PasswordHash, @Salt, GETDATE());

    -- Delete oldest password, if more than five entries
    DELETE FROM PasswordHistory
    WHERE UserID = @UserID AND HistoryID NOT IN (
        SELECT TOP 5 HistoryID
        FROM PasswordHistory
        WHERE UserID = @UserID
        ORDER BY ChangedAt DESC
    );
END;
GO
/****** Object:  StoredProcedure [dbo].[SetUserRole]    Script Date: 12-Jul-24 16:52:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create SetUserRole stored procedure
CREATE PROCEDURE [dbo].[SetUserRole] (
    @UserID INT,
    @RoleName NVARCHAR(50)
)
AS
BEGIN
    DECLARE @RoleID INT;

    -- Retrieve the RoleID based on the RoleName
    SELECT @RoleID = RoleID FROM Roles WHERE RoleName = @RoleName;

    -- Check if the role exists
    IF @RoleID IS NOT NULL
    BEGIN
        -- Insert the UserID and RoleID into the UserRoles table
        INSERT INTO UserRoles (UserID, RoleID)
        VALUES (@UserID, @RoleID);

        SELECT 'Role assigned successfully' AS Message;
    END
    ELSE
    BEGIN
        -- Inform the user if the role does not exist
        SELECT 'Role does not exist' AS Message;
    END
END;
GO
USE [master]
GO
ALTER DATABASE [BioSport] SET  READ_WRITE 
GO
