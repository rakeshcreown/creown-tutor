
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

CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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


alter table [dbo].[LiveSession]
add [Status] int not null default 1
GO

alter table LiveSession
add CreatedBy int null
go

alter table LiveSession
add CreatedDate DateTime null
go

alter table Reviews
add CourseID int null 
go

alter table Reviews
add SessionID int null
go

alter table Reviews
add AddedTime DateTime null 
go

