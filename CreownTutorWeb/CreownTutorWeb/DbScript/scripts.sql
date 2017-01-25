USE [master]
GO
/****** Object:  Database [CreownTutor]    Script Date: 25-Jan-17 4:47:52 PM ******/
CREATE DATABASE [CreownTutor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CreownTutor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CreownTutor.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CreownTutor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CreownTutor_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CreownTutor] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreownTutor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CreownTutor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CreownTutor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CreownTutor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CreownTutor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CreownTutor] SET ARITHABORT OFF 
GO
ALTER DATABASE [CreownTutor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CreownTutor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CreownTutor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CreownTutor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CreownTutor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CreownTutor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CreownTutor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CreownTutor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CreownTutor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CreownTutor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CreownTutor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CreownTutor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CreownTutor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CreownTutor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CreownTutor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CreownTutor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CreownTutor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CreownTutor] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CreownTutor] SET  MULTI_USER 
GO
ALTER DATABASE [CreownTutor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CreownTutor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CreownTutor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CreownTutor] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CreownTutor] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CreownTutor]
GO
/****** Object:  Table [dbo].[CartInfomation]    Script Date: 25-Jan-17 4:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartInfomation](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[NoOfItems] [int] NOT NULL,
	[TotalPrice] [bigint] NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[IsItemDelivered] [bit] NOT NULL,
 CONSTRAINT [PK_CartInfomation] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 25-Jan-17 4:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NOT NULL,
	[CourseDescription] [varchar](max) NOT NULL,
	[NoOfChapters] [int] NOT NULL,
	[DurationOfCourse] [datetime] NOT NULL,
	[NoOfAttendees] [int] NOT NULL,
	[TypeOfCourse] [varchar](50) NOT NULL,
	[Language] [varchar](50) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	[ContentType] [varbinary](max) NOT NULL,
	[CreatedDateAndTime] [datetime] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LiveSession]    Script Date: 25-Jan-17 4:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LiveSession](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Date] [datetime] NOT NULL,
	[FromTime] [time](7) NOT NULL,
	[ToTime] [time](7) NOT NULL,
	[Timezone] [datetime] NULL,
	[IsLanguagecgangeable] [bit] NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[NoOfAttendees] [int] NOT NULL,
	[ClassroomType] [varchar](50) NULL,
	[Visibility] [bit] NOT NULL,
	[TypeOfCourse] [varchar](50) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_LiveSession] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 25-Jan-17 4:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reviews](
	[ReviewId] [int] IDENTITY(1,1) NOT NULL,
	[ReviewRating] [int] NOT NULL,
	[ReviewComments] [varchar](300) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Role]    Script Date: 25-Jan-17 4:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Test]    Script Date: 25-Jan-17 4:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Test](
	[TestID] [int] IDENTITY(1,1) NOT NULL,
	[TestName] [varchar](50) NOT NULL,
	[TestDescription] [varchar](300) NOT NULL,
	[TestInstructions] [varchar](max) NOT NULL,
	[AllowViewingAnswer] [bit] NOT NULL,
	[IsTimeAlloted] [bit] NOT NULL,
	[Hour] [time](7) NOT NULL,
	[Minutes] [time](7) NOT NULL,
	[Seconds] [time](7) NOT NULL,
	[Marks] [int] NOT NULL,
	[Percentage] [decimal](18, 0) NOT NULL,
	[Result] [bit] NOT NULL,
	[PaymentType] [bit] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 25-Jan-17 4:47:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserDetails](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](max) NOT NULL,
	[Password] [varchar](max) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[ContactDetails] [varchar](50) NOT NULL,
	[DateOfBirth] [varchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[ProfileImage] [image] NOT NULL,
	[SessionID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [CreownTutor] SET  READ_WRITE 
GO
