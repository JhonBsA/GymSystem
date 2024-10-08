USE [master]
GO
/****** Object:  Database [BioSport]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  UserDefinedTableType [dbo].[RoutineExerciseDetailType]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE TYPE [dbo].[RoutineExerciseDetailType] AS TABLE(
	[ExerciseID] [int] NULL,
	[EquipmentID] [int] NULL,
	[Sets] [int] NULL,
	[Repetitions] [int] NULL,
	[Weight] [decimal](5, 2) NULL,
	[DurationInSeconds] [int] NULL,
	[AmrapTimeLimitInSeconds] [int] NULL,
	[AmrapRepetitions] [int] NULL,
	[Dia] [int] NULL
)
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 08-Aug-24 21:22:42 ******/
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
	[Notes] [nvarchar](max) NULL,
	[MeasurementID] [int] NULL,
	[CalendarID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendar]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendar](
	[CalendarID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Year] [int] NULL,
	[Month] [int] NULL,
	[Day] [int] NULL,
	[DayOfWeek] [int] NULL,
	[DayOfYear] [int] NULL,
	[WeekOfYear] [int] NULL,
	[MonthName] [varchar](20) NULL,
	[DayName] [varchar](20) NULL,
	[IsWeekend] [bit] NULL,
	[TrainerID] [int] NULL,
	[ClientID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CalendarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClassReservations]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[ClientDiscounts]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Coupons]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Discounts]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Equipment]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Exercises]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[ExerciseTypes]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[GroupClasses]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Measurements]    Script Date: 08-Aug-24 21:22:42 ******/
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
	[AppointmentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MeasurementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PasswordHistory]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Payments]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[PaymentMethodID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalTrainingSessions]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Roles]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[RoutineExerciseDetails]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoutineExerciseDetails](
	[RoutineExerciseDetailID] [int] IDENTITY(1,1) NOT NULL,
	[RoutineID] [int] NOT NULL,
	[ExerciseID] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[Sets] [int] NULL,
	[Repetitions] [int] NULL,
	[Weight] [decimal](5, 2) NULL,
	[DurationInSeconds] [int] NULL,
	[AmrapTimeLimitInSeconds] [int] NULL,
	[AmrapRepetitions] [int] NULL,
	[Dia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoutineExerciseDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoutineExercises]    Script Date: 08-Aug-24 21:22:42 ******/
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
	[Dia] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoutineExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routines]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[Subscriptions]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[TrainingLogs]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingLogs](
	[TrainingLogID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NOT NULL,
	[DateLogged] [datetime] NULL,
	[SetsCompleted] [int] NULL,
	[RepetitionsCompleted] [int] NULL,
	[WeightUsed] [decimal](5, 2) NULL,
	[DurationInSeconds] [int] NULL,
	[ExerciseName] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrainingLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCredentials]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[UserDetails]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Table [dbo].[UserPaymentMethods]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPaymentMethods](
	[PaymentMethodID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[PaymentMethodType] [nvarchar](50) NOT NULL,
	[CreditCardNumber] [char](16) NULL,
	[CreditCardExpiryDate] [datetime] NULL,
	[PayPalEmail] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  Index [IX_Appointments_ClientID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_ClientID] ON [dbo].[Appointments]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Appointments_TrainerID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Appointments_TrainerID] ON [dbo].[Appointments]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassReservations_ClassID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_ClassReservations_ClassID] ON [dbo].[ClassReservations]
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClassReservations_ClientID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_ClassReservations_ClientID] ON [dbo].[ClassReservations]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientDiscounts_ClientID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_ClientDiscounts_ClientID] ON [dbo].[ClientDiscounts]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientDiscounts_DiscountID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_ClientDiscounts_DiscountID] ON [dbo].[ClientDiscounts]
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Coupons_DiscountID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Coupons_DiscountID] ON [dbo].[Coupons]
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Measurements_ClientID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Measurements_ClientID] ON [dbo].[Measurements]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Measurements_TrainerID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Measurements_TrainerID] ON [dbo].[Measurements]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainingSessions_ClientID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainingSessions_ClientID] ON [dbo].[PersonalTrainingSessions]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_PersonalTrainingSessions_TrainerID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_PersonalTrainingSessions_TrainerID] ON [dbo].[PersonalTrainingSessions]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutineExercises_ExerciseID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_RoutineExercises_ExerciseID] ON [dbo].[RoutineExercises]
(
	[ExerciseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RoutineExercises_RoutineID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_RoutineExercises_RoutineID] ON [dbo].[RoutineExercises]
(
	[RoutineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Routines_ClientID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Routines_ClientID] ON [dbo].[Routines]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Routines_TrainerID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Routines_TrainerID] ON [dbo].[Routines]
(
	[TrainerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Subscriptions_ClientID]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_Subscriptions_ClientID] ON [dbo].[Subscriptions]
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserDetails_UserName]    Script Date: 08-Aug-24 21:22:42 ******/
CREATE NONCLUSTERED INDEX [IX_UserDetails_UserName] ON [dbo].[UserCredentials]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserDetails_Email]    Script Date: 08-Aug-24 21:22:42 ******/
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
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD  CONSTRAINT [FK_Appointments_Calendar] FOREIGN KEY([CalendarID])
REFERENCES [dbo].[Calendar] ([CalendarID])
GO
ALTER TABLE [dbo].[Appointments] CHECK CONSTRAINT [FK_Appointments_Calendar]
GO
ALTER TABLE [dbo].[Calendar]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Calendar]  WITH CHECK ADD FOREIGN KEY([TrainerID])
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
ALTER TABLE [dbo].[Measurements]  WITH CHECK ADD  CONSTRAINT [FK_Measurements_Appointments] FOREIGN KEY([AppointmentID])
REFERENCES [dbo].[Appointments] ([AppointmentID])
GO
ALTER TABLE [dbo].[Measurements] CHECK CONSTRAINT [FK_Measurements_Appointments]
GO
ALTER TABLE [dbo].[PasswordHistory]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([PaymentMethodID])
REFERENCES [dbo].[UserPaymentMethods] ([PaymentMethodID])
GO
ALTER TABLE [dbo].[PersonalTrainingSessions]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[PersonalTrainingSessions]  WITH CHECK ADD FOREIGN KEY([TrainerID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[RoutineExerciseDetails]  WITH CHECK ADD FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[RoutineExerciseDetails]  WITH CHECK ADD FOREIGN KEY([ExerciseID])
REFERENCES [dbo].[Exercises] ([ExerciseID])
GO
ALTER TABLE [dbo].[RoutineExerciseDetails]  WITH CHECK ADD FOREIGN KEY([RoutineID])
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
ALTER TABLE [dbo].[UserCredentials]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[UserPaymentMethods]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO
/****** Object:  StoredProcedure [dbo].[CreateAppointment]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create Appointment/Calendar2 
CREATE PROCEDURE [dbo].[CreateAppointment]
(
    @ClientName NVARCHAR(150),
    @TrainerName NVARCHAR(150),
    @AppointmentDate DATETIME,
    @DurationInMinutes INT,
    @CreatedAt DATETIME,
    @Notes NVARCHAR(MAX)
)
AS
BEGIN
    DECLARE @ClientID INT;
    DECLARE @TrainerID INT;
    
    -- Extract client details from ClientName
    DECLARE @ClientFirstName NVARCHAR(50);
    DECLARE @ClientFirstLastName NVARCHAR(50);
    DECLARE @ClientSecondLastName NVARCHAR(50);
    
    SET @ClientFirstName = PARSENAME(REPLACE(@ClientName, ' ', '.'), 3);
    SET @ClientFirstLastName = PARSENAME(REPLACE(@ClientName, ' ', '.'), 2);
    SET @ClientSecondLastName = PARSENAME(REPLACE(@ClientName, ' ', '.'), 1);
    
    -- Extract trainer details from TrainerName
    DECLARE @TrainerFirstName NVARCHAR(50);
    DECLARE @TrainerFirstLastName NVARCHAR(50);
    DECLARE @TrainerSecondLastName NVARCHAR(50);
    
    SET @TrainerFirstName = PARSENAME(REPLACE(@TrainerName, ' ', '.'), 3);
    SET @TrainerFirstLastName = PARSENAME(REPLACE(@TrainerName, ' ', '.'), 2);
    SET @TrainerSecondLastName = PARSENAME(REPLACE(@TrainerName, ' ', '.'), 1);
    
    -- Get ClientID
    SELECT @ClientID = UserID 
    FROM UserDetails 
    WHERE Nombre = @ClientFirstName 
      AND FirstLastName = @ClientFirstLastName 
      AND SecondLastName = @ClientSecondLastName;
    
    -- Get TrainerID
    SELECT @TrainerID = UserID 
    FROM UserDetails 
    WHERE Nombre = @TrainerFirstName 
      AND FirstLastName = @TrainerFirstLastName 
      AND SecondLastName = @TrainerSecondLastName;

    -- Check if ClientID and TrainerID are found
    IF @ClientID IS NULL OR @TrainerID IS NULL
    BEGIN
        SELECT 'Client or Trainer not found' AS Message;
        RETURN;
    END
    
    DECLARE @CalendarIDTable TABLE (CalendarID INT);

    -- Calendar table
    INSERT INTO Calendar (Date, Year, Month, Day, DayOfWeek, DayOfYear, WeekOfYear, MonthName, DayName, IsWeekend, TrainerID, ClientID)
    OUTPUT INSERTED.CalendarID INTO @CalendarIDTable
    SELECT 
        CONVERT(DATE, @AppointmentDate) AS Date,
        YEAR(@AppointmentDate) AS Year,
        MONTH(@AppointmentDate) AS Month,
        DAY(@AppointmentDate) AS Day,
        DATEPART(WEEKDAY, @AppointmentDate) AS DayOfWeek,
        DATEPART(DAYOFYEAR, @AppointmentDate) AS DayOfYear,
        DATEPART(WEEK, @AppointmentDate) AS WeekOfYear,
        DATENAME(MONTH, @AppointmentDate) AS MonthName,
        DATENAME(WEEKDAY, @AppointmentDate) AS DayName,
        CASE 
            WHEN DATEPART(WEEKDAY, @AppointmentDate) IN (1, 7) THEN 1
            ELSE 0
        END AS IsWeekend,
        @TrainerID AS TrainerID,
        @ClientID AS ClientID;

    -- CalendarID from the table variable
    DECLARE @CalendarID INT;
    SELECT @CalendarID = CalendarID FROM @CalendarIDTable;

    -- Appointments table
    INSERT INTO Appointments (ClientID, TrainerID, AppointmentDate, DurationInMinutes, CreatedAt, Notes, CalendarID)
    VALUES (@ClientID, @TrainerID, @AppointmentDate, @DurationInMinutes, @CreatedAt, @Notes, @CalendarID);

    -- Return
    SELECT 'Appointment created successfully' AS Message, SCOPE_IDENTITY() AS AppointmentID;
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateRole]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateRole]
    @Name NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @RoleID INT;

    -- Check for duplicate RoleName
    IF EXISTS (SELECT 1 FROM Roles WHERE RoleName = @Name)
    BEGIN
        SELECT 'Error, RoleName already exists' AS MESSAGE;
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Roles (RoleName)
        VALUES (@Name);

        -- Retrieve the ID of the newly created role
        SELECT @RoleID = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
        
        -- Return the ID of the newly created role
        SELECT @RoleID AS RoleID;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;

        -- Return error message
        SELECT 'Error, transaction rejected' AS MESSAGE;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateRoutineWithDetails]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateRoutineWithDetails]
    @ClientID INT,
    @TrainerID INT,
    @CreatedAt DATETIME,
    @ExerciseDetails dbo.RoutineExerciseDetailType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @RoutineID INT;

        -- Insert into Routines table
        INSERT INTO Routines (ClientID, TrainerID, CreatedAt)
        VALUES (@ClientID, @TrainerID, @CreatedAt);

        -- Get the newly created RoutineID
        SET @RoutineID = SCOPE_IDENTITY();

        -- Insert into RoutineExerciseDetails table
        INSERT INTO RoutineExerciseDetails (
            RoutineID, 
            ExerciseID, 
            EquipmentID, 
            Sets, 
            Repetitions, 
            Weight, 
            DurationInSeconds, 
            AmrapTimeLimitInSeconds, 
            AmrapRepetitions, 
            Dia)
        SELECT 
            @RoutineID, 
            ExerciseID, 
            EquipmentID, 
            Sets, 
            Repetitions, 
            Weight, 
            DurationInSeconds, 
            AmrapTimeLimitInSeconds, 
            AmrapRepetitions, 
            Dia
        FROM @ExerciseDetails;

        COMMIT TRANSACTION;

        -- Return the RoutineID and success message
        SELECT @RoutineID AS RoutineID, 'Routine created successfully' AS SuccessMessage;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Return error message
        SELECT ERROR_MESSAGE() AS ErrorMessage;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateTrainingLogs]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateTrainingLogs]
    @ClientID INT,
    @DateLogged DATETIME,
    @ExerciseName NVARCHAR(100),
    @SetsCompleted INT,
    @RepetitionsCompleted INT,
    @WeightUsed DECIMAL(5,2),
    @DurationInSeconds INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ExerciseID INT;

    -- Find the ExerciseID using ExerciseName
    SELECT @ExerciseID = ExerciseID
    FROM Exercises
    WHERE Name = @ExerciseName;

    -- If ExerciseID is not found, raise an error
    IF @ExerciseID IS NULL
    BEGIN
        SELECT 'Exercise not found' AS Message;
        RETURN;
    END

    -- Insert into TrainingLogs with the ExerciseName
    INSERT INTO TrainingLogs (
        ClientID,
        DateLogged,
        SetsCompleted,
        RepetitionsCompleted,
        WeightUsed,
        DurationInSeconds,
        ExerciseName -- Add ExerciseName to the insertion
    )
    VALUES (
        @ClientID,
        @DateLogged,
        @SetsCompleted,
        @RepetitionsCompleted,
        @WeightUsed,
        @DurationInSeconds,
        @ExerciseName -- Use the @ExerciseName parameter here
    );

    SELECT 'Training log created successfully' AS Message;
END;
GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 08-Aug-24 21:22:42 ******/
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

		SELECT 'New user registered succesfully' AS Message, @OTP AS OTPCode, @EmailP as Email;
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteAppointment]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Delete Appointment
CREATE PROCEDURE [dbo].[DeleteAppointment]
(
    @AppointmentID INT
)
AS
BEGIN

    DECLARE @CalendarID INT;

    SELECT @CalendarID = CalendarID
    FROM Appointments
    WHERE AppointmentID = @AppointmentID;

    DELETE FROM Appointments
    WHERE AppointmentID = @AppointmentID;

    IF @CalendarID IS NOT NULL
    BEGIN
        DELETE FROM Calendar
        WHERE CalendarID = @CalendarID;
    END

    SELECT 'Appointment and associated Calendar record deleted successfully' AS Message;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- DeleteUser
CREATE PROCEDURE [dbo].[DeleteUser]
(
    @CedulaP INT
)
AS
BEGIN
    DECLARE @UserID INT;

    SELECT @UserID = UserID FROM UserDetails WHERE Cedula = @CedulaP;

    IF @UserID IS NOT NULL
    BEGIN
        UPDATE UserCredentials
        SET UserName = CASE 
                            WHEN LEFT(UserName, 4) = 'del.' THEN UserName 
                            ELSE 'del.' + UserName 
                       END,
            PasswordHash = HASHBYTES('SHA2_256', 'NewPasswordHash'),
            PasswordSalt = CAST(CRYPT_GEN_RANDOM(64) AS VARBINARY(64)),
            OTP = '000000',
            VerificationStatus = 2
        WHERE UserID = @UserID;

        DELETE FROM PasswordHistory WHERE UserID = @UserID;

        -- DELETE FROM UserRoles WHERE UserID = @UserID;

        UPDATE UserDetails
        SET Cedula = UserID * -1,
            Nombre = CASE 
                        WHEN LEFT(Nombre, 4) = 'del.' THEN Nombre 
                        ELSE 'del.' + Nombre 
                     END,
            FirstLastName = CASE 
                                WHEN LEFT(FirstLastName, 4) = 'del.' THEN FirstLastName 
                                ELSE 'del.' + FirstLastName 
                            END,
            SecondLastName = CASE 
                                WHEN LEFT(SecondLastName, 4) = 'del.' THEN SecondLastName 
                                ELSE 'del.' + SecondLastName 
                             END,
            Phone = CASE 
                        WHEN LEFT(Phone, 4) = 'del.' THEN Phone 
                        ELSE 'del.' + Phone 
                    END,
            Email = CASE 
                        WHEN LEFT(Email, 4) = 'del.' THEN Email 
                        ELSE 'del.' + Email 
                    END
        WHERE UserID = @UserID;

        SELECT 'User deleted successfully' AS Message;
    END
    ELSE
    BEGIN
        SELECT 'Cedula not found' AS Message;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    -- Select all records from the UserDetails table
    IF EXISTS (SELECT 1 FROM UserDetails)
    BEGIN
        SELECT 
            Cedula, 
            Nombre, 
            FirstLastName, 
            SecondLastName, 
            Phone, 
            Email 
        FROM 
            UserDetails;
    END
    ELSE
    BEGIN
        -- If no users exist, return an empty result set with a message
        SELECT 'No users found' AS Message;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCreatePayment]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCreatePayment]
    @ClientID INT,
    @Amount DECIMAL(10,2),
    @PaymentMethodID INT,
    @PaymentDate DATETIME = NULL
AS
BEGIN
    BEGIN TRY
        IF @PaymentDate IS NULL
        BEGIN
            SET @PaymentDate = GETDATE();
        END
        
        INSERT INTO Payments (
            ClientID,
            Amount,
            PaymentDate,
            PaymentMethodID
        )
        VALUES (
            @ClientID,
            @Amount,
            @PaymentDate,
            @PaymentMethodID
        );

        -- If the INSERT succeeds, return 1 as Success
        SELECT 1 AS Success;
    END TRY
    BEGIN CATCH
        -- If there is an error, return 0 as Success
        SELECT 0 AS Success, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[GetCreateUserPaymentMethod]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCreateUserPaymentMethod]
    @UserID INT,
    @PaymentMethodType NVARCHAR(50),
    @CreditCardNumber NVARCHAR(50) = NULL,
    @CreditCardExpiryDate DATETIME = NULL,
    @PayPalEmail NVARCHAR(100) = NULL
AS
BEGIN
    DECLARE @Verified CHAR(16);
    BEGIN TRY
        IF @PaymentMethodType = 'Credit Card'
        BEGIN

            IF LEN(@CreditCardNumber) <> 16
            BEGIN
                SELECT 'Invalid credit card number' AS Message;
                RETURN;
            END
            

            IF EXISTS (SELECT 1 FROM UserPaymentMethods WHERE UserID = @UserID AND CreditCardNumber = @CreditCardNumber)
            BEGIN
                SELECT 'Duplicate credit card entry for this user' AS Message;
                RETURN;
            END

            SET @Verified = @CreditCardNumber;
            INSERT INTO UserPaymentMethods (
                UserID,
                PaymentMethodType,
                CreditCardNumber,
                CreditCardExpiryDate,
                PayPalEmail
            )
            VALUES (
                @UserID,
                @PaymentMethodType,
                @Verified,
                @CreditCardExpiryDate,
                NULL
            );
        END
        ELSE IF @PaymentMethodType = 'PayPal'
        BEGIN

            IF @PayPalEmail IS NULL OR LEN(@PayPalEmail) = 0
            BEGIN
                SELECT 0 AS Success, 'PayPal email is required' AS Message;
                RETURN;
            END

    
            IF EXISTS (SELECT 1 FROM UserPaymentMethods WHERE UserID = @UserID AND PayPalEmail = @PayPalEmail)
            BEGIN
                SELECT 'Duplicate PayPal entry for this user' AS Message;
                RETURN;
            END

            INSERT INTO UserPaymentMethods (
                UserID,
                PaymentMethodType,
                CreditCardNumber,
                CreditCardExpiryDate,
                PayPalEmail
            )
            VALUES (
                @UserID,
                @PaymentMethodType,
                NULL,
                NULL,
                @PayPalEmail
            );
        END

        SELECT 1 AS Success, 'Payment method added successfully' AS Message;
    END TRY
    BEGIN CATCH

        SELECT 0 AS Success, ERROR_MESSAGE() AS Message;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[GetDeleteUserPaymentMethod]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDeleteUserPaymentMethod]
    @PaymentMethodID INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM UserPaymentMethods
        WHERE PaymentMethodID = @PaymentMethodID;

        SELECT 1 AS Success, 'Payment method deleted successfully' AS Message;
    END TRY
    BEGIN CATCH

        SELECT ERROR_MESSAGE() AS Message;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[GetLastAppointmentDate]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLastAppointmentDate]
AS
BEGIN
    SELECT MAX(AppointmentDate) AS LastAppointmentDate
    FROM Appointments;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetLogin]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----------------------- Login ----------------
CREATE PROCEDURE [dbo].[GetLogin] (
    @EmailP NVARCHAR(100),
    @PasswordP NVARCHAR(255)
)
AS
BEGIN
    DECLARE @UserID INT;
    DECLARE @VerificationStatus BIT;
    DECLARE @PasswordHash VARBINARY(64);
    DECLARE @PasswordSalt VARBINARY(64);
    DECLARE @StoredPasswordHash VARBINARY(64);
    DECLARE @RoleID INT;

    IF EXISTS (SELECT Email FROM UserDetails WHERE Email = @EmailP)
    BEGIN
        SELECT 
            @UserID = UD.UserID, 
            @VerificationStatus = UC.VerificationStatus,
            @PasswordHash = UC.PasswordHash,
            @PasswordSalt = UC.PasswordSalt
        FROM 
            UserDetails UD
        JOIN 
            UserCredentials UC ON UD.UserID = UC.UserID
        WHERE 
            UD.Email = @EmailP;

        IF @VerificationStatus = 0
        BEGIN
            SELECT 'User not verified' AS Message;
        END
        ELSE
        BEGIN
            SET @StoredPasswordHash = HASHBYTES('SHA2_256', @PasswordP + CAST(@PasswordSalt AS NVARCHAR(64)));

            IF @StoredPasswordHash = @PasswordHash
            BEGIN
                SELECT @RoleID = UR.RoleID
                FROM UserRoles UR
                WHERE UR.UserID = @UserID;

                SELECT @RoleID AS RoleID, @UserID AS UserID;
            END
            ELSE
            BEGIN
                SELECT 'Invalid email or password' AS Message;
            END
        END
    END
    ELSE
    BEGIN
        SELECT 'Invalid email or password' AS Message;
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[GetPaymentMethod]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetPaymentMethod]
    @DisplayPaymentMethod NVARCHAR(50),
    @UserID INT
AS
BEGIN
    BEGIN TRY
        SELECT 
            PaymentMethodID
        FROM UserPaymentMethods
        WHERE 
            UserID = @UserID AND 
            (PaymentMethodType = 'Credit Card' AND '************' + RIGHT(CreditCardNumber, 4) = @DisplayPaymentMethod
            OR 
            PaymentMethodType = 'PayPal' AND PayPalEmail = @DisplayPaymentMethod);

    END TRY
    BEGIN CATCH
        SELECT ERROR_MESSAGE() AS Message;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[GetRetrieveAllUserPaymentMethods]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRetrieveAllUserPaymentMethods]
    @UserID INT
AS
BEGIN
    BEGIN TRY
        SELECT 
            PaymentMethodID,
            UserID,
            PaymentMethodType,
            CASE 
                WHEN PaymentMethodType = 'Credit Card' THEN '************' + RIGHT(CreditCardNumber, 4)
                ELSE PayPalEmail
            END AS DisplayPaymentMethod,
            CreditCardNumber,
            CreditCardExpiryDate,
            PayPalEmail
        FROM UserPaymentMethods
        WHERE UserID = @UserID;

        -- If the SELECT succeeds, return the result set
    END TRY
    BEGIN CATCH
        -- If there is an error, return the error message
        SELECT ERROR_MESSAGE() AS Message;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[GetRetrievePaymentByUserId]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRetrievePaymentByUserId]
    @ClientID INT
AS
BEGIN
    BEGIN TRY
        SELECT 
            p.PaymentID,
            p.Amount,
            p.PaymentDate,
            CASE 
                WHEN upm.PaymentMethodType = 'Credit Card' THEN '************' + RIGHT(upm.CreditCardNumber, 4)
                ELSE 'PayPal'
            END AS PaymentMethod
        FROM Payments p
        JOIN UserPaymentMethods upm ON p.PaymentMethodID = upm.PaymentMethodID
        WHERE p.ClientID = @ClientID;


    END TRY
    BEGIN CATCH

        SELECT ERROR_MESSAGE() AS Message;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[GetRetrieveTrainingLogsByUserId]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRetrieveTrainingLogsByUserId]
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Retrieve all training logs that match the given UserID
    SELECT 
        *
    FROM 
        TrainingLogs
    WHERE 
        ClientID = @UserID
    ORDER BY 
        DateLogged DESC;

    -- If no records found, return a message
    IF @@ROWCOUNT = 0
    BEGIN
        SELECT 'No training logs found for the specified UserID' AS Message;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
            SELECT 'A new OTP has been generated and sent to your email address' AS Message, @OTP AS OTPCode, @EmailP AS Email, @UserID AS UserID;
        END
    END
    ELSE
    BEGIN
        -- Inform the user that the email does not exist
        SELECT 'The email provided does not exist in our records.' AS Message;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUserByUserID]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Find user based on UserID
CREATE PROCEDURE [dbo].[GetUserByUserID] (
    @UserID INT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM UserDetails WHERE UserID = @UserID)
    BEGIN
        SELECT 
            Cedula, 
            Nombre, 
            FirstLastName, 
            SecondLastName, 
            Phone, 
            Email 
        FROM 
            UserDetails
        WHERE 
            UserID = @UserID;
    END
    ELSE
    BEGIN
        -- If UserID does not exist, return an error message
        SELECT 'UserID not found' AS ErrorMessage;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GetUserRoutinesWithDetails]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserRoutinesWithDetails]
    @UserID INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Retrieve routines for the given UserID sorted by RoutineID in descending order
    SELECT 
        r.RoutineID,
        r.ClientID,
        r.TrainerID,
        r.CreatedAt,
        red.RoutineExerciseDetailID AS RoutineExerciseID,
        red.ExerciseID,
        e.Name AS ExerciseName,
        et.ExerciseTypeID,
        et.TypeName AS ExerciseTypeName, -- Changed alias to ExerciseTypeName
        red.Sets,
        red.Repetitions,
        red.Weight,
        red.DurationInSeconds,
        red.AmrapTimeLimitInSeconds,
        red.AmrapRepetitions,
        red.Dia,
        red.EquipmentID,
        eq.Name AS EquipmentName
    FROM 
        Routines r
    LEFT JOIN 
        RoutineExerciseDetails red ON r.RoutineID = red.RoutineID
    LEFT JOIN 
        Exercises e ON red.ExerciseID = e.ExerciseID
    LEFT JOIN 
        Equipment eq ON red.EquipmentID = eq.EquipmentID
    LEFT JOIN 
        ExerciseTypes et ON e.ExerciseTypeID = et.ExerciseTypeID
    WHERE 
        r.ClientID = @UserID
    ORDER BY 
        r.RoutineID DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[NewUserPasswordReset]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[NewUserPasswordReset] (
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

    -- Verify UserID is not null
    IF @UserID IS NOT NULL
    BEGIN
        DECLARE PasswordCursor CURSOR FOR
        SELECT TOP 5 PasswordHash, PasswordSalt
        FROM PasswordHistory
        WHERE UserID = @UserID
        ORDER BY ChangedAt DESC;

        OPEN PasswordCursor;

        FETCH NEXT FROM PasswordCursor INTO @OldPasswordHash, @OldPasswordSalt;

        WHILE @@FETCH_STATUS = 0
        BEGIN
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
            RAISERROR('New password cannot be the same as any of the last five passwords.', 16, 1);
            RETURN;
        END

        SET @Salt = CAST(CRYPT_GEN_RANDOM(64) AS VARBINARY(64));
        SET @PasswordHash = HASHBYTES('SHA2_256', @NewPassword + CAST(@Salt AS NVARCHAR(64)));

        IF @PasswordHash IS NULL
        BEGIN
            RAISERROR('Password hashing failed.', 16, 1);
            RETURN;
        END

        UPDATE UserCredentials
        SET PasswordHash = @PasswordHash, PasswordSalt = @Salt, OTP = '000000'
        WHERE UserID = @UserID;

        INSERT INTO PasswordHistory (UserID, PasswordHash, PasswordSalt, ChangedAt)
        VALUES (@UserID, @PasswordHash, @Salt, GETDATE());

        DELETE FROM PasswordHistory
        WHERE UserID = @UserID AND HistoryID NOT IN (
            SELECT TOP 5 HistoryID
            FROM PasswordHistory
            WHERE UserID = @UserID
            ORDER BY ChangedAt DESC
        );

        SELECT 1 AS StatusCode, 'Password reset successfully' AS Message;
    END
    ELSE
    BEGIN
        RAISERROR('Invalid UserID.', 16, 1);
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[PasswordReset]    Script Date: 08-Aug-24 21:22:42 ******/
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
/****** Object:  StoredProcedure [dbo].[RetrieveAppointmentsByDateRange]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RetrieveAppointmentsByDateRange]
(
    @StartDate DATETIME,
    @EndDate DATETIME
)
AS
BEGIN
    SELECT 
        a.AppointmentID,
        a.ClientID,
        a.TrainerID,
        a.AppointmentDate,
        a.DurationInMinutes,
        a.CreatedAt,
        a.Notes,
        a.CalendarID,
        c.Nombre + ' ' + c.FirstLastName + ' ' + c.SecondLastName AS ClientName,
        t.Nombre + ' ' + t.FirstLastName + ' ' + t.SecondLastName AS TrainerName
    FROM 
        Appointments a
    INNER JOIN 
        UserDetails c ON a.ClientID = c.UserID
    INNER JOIN 
        UserDetails t ON a.TrainerID = t.UserID
    WHERE 
        a.AppointmentDate BETWEEN @StartDate AND @EndDate
    ORDER BY 
        a.AppointmentDate;
END;
GO
/****** Object:  StoredProcedure [dbo].[RetrieveRoles]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RetrieveRoles]
AS
BEGIN
    SET NOCOUNT ON;

    -- Select all roles from the Roles table
    SELECT RoleID, RoleName
    FROM Roles;
END;
GO
/****** Object:  StoredProcedure [dbo].[SetUserRole]    Script Date: 08-Aug-24 21:22:42 ******/
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

    END
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateAppointment]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAppointment]
(
    @AppointmentID INT,
    @ClientID INT,
    @TrainerID INT,
    @AppointmentDate DATETIME,
    @DurationInMinutes INT,
    @Notes NVARCHAR(MAX)
)
AS
BEGIN

    IF NOT EXISTS (SELECT 1 FROM Appointments WHERE AppointmentID = @AppointmentID)
    BEGIN
        RAISERROR ('Appointment not found', 16, 1);
        RETURN;
    END

    UPDATE Calendar
    SET 
        Date = CONVERT(DATE, @AppointmentDate),
        Year = YEAR(@AppointmentDate),
        Month = MONTH(@AppointmentDate),
        Day = DAY(@AppointmentDate),
        DayOfWeek = DATEPART(WEEKDAY, @AppointmentDate),
        DayOfYear = DATEPART(DAYOFYEAR, @AppointmentDate),
        WeekOfYear = DATEPART(WEEK, @AppointmentDate),
        MonthName = DATENAME(MONTH, @AppointmentDate),
        DayName = DATENAME(WEEKDAY, @AppointmentDate),
        IsWeekend = CASE WHEN DATEPART(WEEKDAY, @AppointmentDate) IN (1, 7) THEN 1 ELSE 0 END,
        TrainerID = @TrainerID,
        ClientID = @ClientID
    WHERE CalendarID = (SELECT CalendarID FROM Appointments WHERE AppointmentID = @AppointmentID);

    UPDATE Appointments
    SET 
        ClientID = @ClientID,
        TrainerID = @TrainerID,
        AppointmentDate = @AppointmentDate,
        DurationInMinutes = @DurationInMinutes,
        Notes = @Notes
    WHERE AppointmentID = @AppointmentID;

    SELECT 'Appointment updated successfully' AS Message;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoleName]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateRoleName]
    @OldRoleName NVARCHAR(50),
    @NewRoleName NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Check if the role with the OldRoleName exists
        IF EXISTS (SELECT 1 FROM Roles WHERE RoleName = @OldRoleName)
        BEGIN
            -- Update the RoleName
            UPDATE Roles
            SET RoleName = @NewRoleName
            WHERE RoleName = @OldRoleName;

            COMMIT TRANSACTION;
            SELECT 'Role name updated successfully' AS Message;
        END
        ELSE
        BEGIN
            ROLLBACK TRANSACTION;
            SELECT 'Error, RoleName not found' AS Message;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;

        -- Return error message
        SELECT 'Error, transaction failed' AS Message;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Update User
CREATE PROCEDURE [dbo].[UpdateUser]
(
    @UserID INT,
    @CedulaP INT,
    @NombreP NVARCHAR(50),
    @FirstLastNameP NVARCHAR(50),
    @SecondLastNameP NVARCHAR(50),
    @PhoneP NVARCHAR(50),
    @EmailP NVARCHAR(100)
)
AS
BEGIN

    UPDATE UserDetails
    SET
        Cedula = @CedulaP,
        Nombre = @NombreP,
        FirstLastName = @FirstLastNameP,
        SecondLastName = @SecondLastNameP,
        Phone = @PhoneP,
        Email = @EmailP
    WHERE
        UserID = @UserID;

    SELECT
        Cedula,
        Nombre,
        FirstLastName,
        SecondLastName,
        Phone,
        Email
    FROM
        UserDetails
    WHERE
        UserID = @UserID;
END;

GO
/****** Object:  StoredProcedure [dbo].[VerifyAndResetOTP]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerifyAndResetOTP] (
    @OTPP NVARCHAR(6),
    @NewPassword NVARCHAR(255)
)
AS
BEGIN
    DECLARE @Email NVARCHAR(100);
    DECLARE @UserID INT;
    DECLARE @StatusCode INT;
    DECLARE @Message NVARCHAR(255);

    -- Check if the OTP exists
    IF EXISTS (SELECT UserID FROM UserCredentials WHERE OTP = @OTPP)
    BEGIN
        -- Retrieve Email and UserID based on OTP
        SELECT 
            @Email = UD.Email,
            @UserID = UC.UserID
        FROM 
            UserDetails UD
        JOIN 
            UserCredentials UC ON UD.UserID = UC.UserID
        WHERE 
            UC.OTP = @OTPP;

        -- Call NewUserPasswordReset
        EXEC [dbo].[NewUserPasswordReset] @UserID = @UserID, @NewPassword = @NewPassword;

		-- Update VerificationStatus to 1
        UPDATE UserCredentials
        SET VerificationStatus = 1
        WHERE UserID = @UserID;

        -- Return the Email address and the success message
        SELECT @Email AS Email, 1 AS StatusCode, 'Password reset successfully' AS Message;
    END
    ELSE
    BEGIN
        -- OTP does not exist
        SELECT 0 AS StatusCode, 'The provided OTP does not exist.' AS Message;
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[VerifyUserOTP]    Script Date: 08-Aug-24 21:22:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------- VerifyUserOTP --------------------  
CREATE PROCEDURE [dbo].[VerifyUserOTP] (
    @EmailP NVARCHAR(100),
    @OTPP NVARCHAR(6)
)
AS
BEGIN
    DECLARE @UserID INT;
    DECLARE @StoredOTP NVARCHAR(6);
    DECLARE @VerificationStatus BIT;

    IF EXISTS (SELECT Email FROM UserDetails WHERE Email = @EmailP)
    BEGIN
        SELECT 
            @UserID = UD.UserID, 
            @StoredOTP = UC.OTP,
            @VerificationStatus = UC.VerificationStatus
        FROM 
            UserDetails UD
        JOIN 
            UserCredentials UC ON UD.UserID = UC.UserID
        WHERE 
            UD.Email = @EmailP;

        IF @VerificationStatus = 1
        BEGIN
            SELECT 2 AS Result; -- User already verified
        END
        ELSE
        BEGIN
            IF @StoredOTP = @OTPP
            BEGIN
                UPDATE UserCredentials
                SET VerificationStatus = 1
                WHERE UserID = @UserID;
                SELECT 1 AS Result; -- Verification success
            END
            ELSE
            BEGIN
                SELECT 3 AS Result; --OTP incorrect
            END
        END
    END
    ELSE
    BEGIN
        SELECT 4 AS Result; --User does not exist incorrect
    END
END;

GO
USE [master]
GO
ALTER DATABASE [BioSport] SET  READ_WRITE 
GO
