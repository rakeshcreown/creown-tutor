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


IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'LiveSession')
BEGIN
drop table [LiveSession]
END
go


IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'LiveSession')
BEGIN
CREATE TABLE [dbo].[LiveSession](
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[FromDateTime] [datetime] NULL,
	[ToDateTime] [datetime] NULL,
	[Timezone] [datetime] NULL,
	[Description] [varchar](MAX) NULL,
	[CourseID] int null
 CONSTRAINT [PK_LiveSession] PRIMARY KEY CLUSTERED 
(
	[SessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
Go

alter table LiveSession
add constraint fk_courseid foreign key (CourseID) references Course (CourseID)
go


IF NOT EXISTS (SELECT * 
    FROM CreownTutor.INFORMATION_SCHEMA.TABLES   
    WHERE TABLE_SCHEMA = N'dbo'  AND TABLE_NAME = N'CourseRegistration')
BEGIN
CREATE TABLE [dbo].[CourseRegistration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_CourseRegistration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[CourseRegistration]  WITH CHECK ADD  CONSTRAINT [FK_CourseRegistration_UserDetails] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])

ALTER TABLE [dbo].[CourseRegistration] CHECK CONSTRAINT [FK_CourseRegistration_UserDetails]
END
go

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'SessionID' AND Object_ID = Object_ID(N'UserDetails'))
BEGIN
Alter Table UserDetails
drop column SessionID
END
go

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'CourseID' AND Object_ID = Object_ID(N'UserDetails'))
BEGIN
Alter Table UserDetails
drop column CourseID
END
go

IF EXISTS(SELECT * FROM sys.columns WHERE Name = N'RoleID' AND Object_ID = Object_ID(N'Course'))
BEGIN
alter table Course
drop Column RoleID
END
go

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'AttendessLimit' AND Object_ID = Object_ID(N'Course'))
BEGIN
alter table Course
add AttendessLimit int null
END
go

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'RegisteredDateTime' AND Object_ID = Object_ID(N'CourseRegistration'))
BEGIN
alter table CourseRegistration
add RegisteredDateTime datetime null 
END
go

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'CoursePrice' AND Object_ID = Object_ID(N'Course'))
BEGIN
alter table Course
add CoursePrice float  null
END
go

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ContactNumber' AND Object_ID = Object_ID(N'UserDetails'))
BEGIN
alter table UserDetails
add ContactNumber varchar(20) null
END
go

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ContactEmail' AND Object_ID = Object_ID(N'UserDetails'))
BEGIN
alter table UserDetails
add ContactEmail varchar(20) null
END
go

alter table UserDetails
alter column EmailAddress varchar(20) not null
go

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'ExperienceInfo' AND Object_ID = Object_ID(N'UserDetails'))
BEGIN
alter table UserDetails
add ExperienceInfo varchar(100) null
END
go

IF NOT EXISTS(SELECT * FROM sys.columns WHERE Name = N'BioGraphInfo' AND Object_ID = Object_ID(N'UserDetails'))
BEGIN
alter table UserDetails
add BioGraphInfo varchar(MAX) null
END
go

/*Created by Apurva on 2/2/2017 */
Alter table Reviews add ReviewAddedBy int

Alter table Reviews
add foreign key (ReviewAddedBy)
references UserDetails(UserID)

alter table CourseRegistration 
add IsCourseRegistered bit 

alter table CourseRegistration
drop column IsCourseRegistered


/*Created by Apurva on 02/07/2017*/
alter table Test
add Category varchar(50) null

alter table Test
drop column Hour 

alter table Test
add Hour int

alter table Test
drop column Minutes

alter table Test
add Minutes int

alter table Test
drop column Seconds

alter table Test
add Seconds int


/*Created by Apurva 02/08/2017*/
CREATE TABLE [dbo].[UsersInRoles](
	[RoleID] [int] NOT NULL,
	[UserID] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO

ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_Role]
GO

ALTER TABLE [dbo].[UsersInRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersInRoles_UserDetails] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserDetails] ([UserID])
GO

ALTER TABLE [dbo].[UsersInRoles] CHECK CONSTRAINT [FK_UsersInRoles_UserDetails]
GO


