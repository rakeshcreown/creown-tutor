IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'CartInfomation')
BEGIN
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
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'Course')
BEGIN
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
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'LiveSession')
BEGIN
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
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'Reviews')
BEGIN
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
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'Role')
BEGIN
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'Test')
BEGIN
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
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'UserDetails')
BEGIN
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
END
GO


IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'Status'
      AND Object_ID = Object_ID(N'LiveSession'))
BEGIN
alter table [dbo].[LiveSession]
add [Status] int not null default 1
END
GO

IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'CreatedBy'
      AND Object_ID = Object_ID(N'LiveSession'))
BEGIN
alter table LiveSession
add CreatedBy int null
END
go

IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'CreatedDate'
      AND Object_ID = Object_ID(N'LiveSession'))
BEGIN
alter table LiveSession
add CreatedDate DateTime null
END
go

IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'CourseID'
      AND Object_ID = Object_ID(N'Reviews'))
BEGIN
alter table Reviews
add CourseID int null 
END
go

IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'SessionID'
      AND Object_ID = Object_ID(N'Reviews'))
BEGIN
alter table Reviews
add SessionID int null
END
go

IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'AddedTime'
      AND Object_ID = Object_ID(N'Reviews'))
BEGIN
alter table Reviews
add AddedTime DateTime null 
END
go

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'Category')
BEGIN
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'SubCategory')
BEGIN
CREATE TABLE [dbo].[SubCategory](
	[SubCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[SubCategory] [varchar](50) NULL,
	[CategoryID] [int] NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO


Alter Table Course
alter column NoOfChapters int null
go

Alter Table Course
alter column DurationOfCourse datetime null
go

Alter Table Course
alter column NoOfAttendees int null
go

Alter Table Course
alter column TypeOfCourse varchar(50) null
go

Alter Table Course
alter column [Language] varchar(50) null
go

Alter Table Course
alter column Category varchar(50) null
go


IF EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'ContentType'
      AND Object_ID = Object_ID(N'Course'))
BEGIN
Alter Table Course
drop column ContentType
END
go

Alter Table Course
alter column CreatedDateAndTime datetime null
go

Alter Table Course
alter column RoleID int null
go


IF NOT EXISTS(
    SELECT *
    FROM sys.columns 
    WHERE Name      = N'CreatedBy'
      AND Object_ID = Object_ID(N'Course'))
BEGIN
Alter Table Course
add CreatedBy int null
END
go

alter table Course
add constraint fk_createdby_user foreign key (createdby) references UserDetails (UserID)
go

Alter Table UserDetails
alter column Location varchar(50) null
go

Alter Table UserDetails
alter column ContactDetails varchar(50) null
go

Alter Table UserDetails
alter column DateOfBirth varchar(50) null
go

Alter Table UserDetails
alter column Gender varchar(50) null
go

Alter Table UserDetails
alter column ProfileImage image null
go



IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'SessionStatus')
BEGIN
CREATE TABLE [dbo].[SessionStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_SessionStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'SessionUsers')
BEGIN
CREATE TABLE [dbo].[SessionUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SessionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[IsPresenter] [bit] NULL,
 CONSTRAINT [PK_SessionUsers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO

