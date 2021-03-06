USE [master]
GO
/****** Object:  Database [NPD]    Script Date: 12-11-2018 09:19:45 ******/
CREATE DATABASE [NPD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NPD', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\NPD.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NPD_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\NPD_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [NPD] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NPD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NPD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NPD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NPD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NPD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NPD] SET ARITHABORT OFF 
GO
ALTER DATABASE [NPD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NPD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NPD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NPD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NPD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NPD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NPD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NPD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NPD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NPD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [NPD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NPD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NPD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NPD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NPD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NPD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NPD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NPD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NPD] SET  MULTI_USER 
GO
ALTER DATABASE [NPD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NPD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NPD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NPD] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [NPD] SET DELAYED_DURABILITY = DISABLED 
GO
USE [NPD]
GO
/****** Object:  Table [dbo].[company]    Script Date: 12-11-2018 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Status] [int] NULL CONSTRAINT [DF_company_Status]  DEFAULT ((1)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_company_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL CONSTRAINT [DF_company_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[errorlog]    Script Date: 12-11-2018 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[errorlog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](2000) NULL,
	[Description] [varchar](2000) NULL,
	[CreatedDate] [datetime] NULL,
	[Filename] [nvarchar](100) NULL,
	[Methodname] [nvarchar](100) NULL,
	[Url] [nvarchar](100) NULL,
	[Ip] [nvarchar](100) NULL,
	[Classname] [nvarchar](100) NULL,
 CONSTRAINT [PK_errorlog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FaultComplexity]    Script Date: 12-11-2018 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaultComplexity](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_FaultComplexity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FaultLibrary]    Script Date: 12-11-2018 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaultLibrary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FaultId] [int] NULL,
	[Url] [nvarchar](500) NULL,
	[FileName] [nvarchar](500) NULL,
	[Status] [int] NULL CONSTRAINT [DF_FaultLibrary_Status]  DEFAULT ((1)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_FaultLibrary_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL CONSTRAINT [DF_FaultLibrary_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_FaultLibrary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FaultPriorities]    Script Date: 12-11-2018 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaultPriorities](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
 CONSTRAINT [PK_FaultPriorities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faults]    Script Date: 12-11-2018 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NULL,
	[Location] [nvarchar](50) NULL,
	[MachineDescription] [nvarchar](500) NULL,
	[FaultDescription] [nvarchar](500) NULL,
	[Priority] [int] NULL,
	[Complexity] [int] NULL,
	[FaultStatus] [int] NULL,
	[StartDate] [datetime] NULL,
	[AssignedTo] [int] NULL,
	[Status] [int] NULL CONSTRAINT [DF_Faults_Status]  DEFAULT ((1)),
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Faults_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [int] NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL CONSTRAINT [DF_Faults_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Faults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsersInfo]    Script Date: 12-11-2018 09:19:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](500) NULL,
	[RoleId] [int] NULL,
	[Status] [int] NULL CONSTRAINT [DF_UsersInfo_Status]  DEFAULT ((1)),
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_UsersInfo_CreatedDate]  DEFAULT (getdate()),
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL CONSTRAINT [DF_UsersInfo_ModifiedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_UsersInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[company] ON 

INSERT [dbo].[company] ([Id], [Name], [Address], [Phone], [Fax], [Email], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'sdfsdfsd', N'fdgfddfgdfgdf
fdgdfg
fdgdfgfd
fdgdfggfdgdfg', N'23324234', N'4234234', N'dfdsfsdf@fsd.com', 1, 1, CAST(N'2018-12-09 20:40:57.940' AS DateTime), 1, CAST(N'2018-12-09 20:40:57.987' AS DateTime))
INSERT [dbo].[company] ([Id], [Name], [Address], [Phone], [Fax], [Email], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Company1', N'dfsdf', N'22222222222222', N'3333333333', N'dfdsfsdf@fsd.com', 1, 1, CAST(N'2018-12-09 21:16:50.367' AS DateTime), 1, CAST(N'2018-12-09 21:16:50.367' AS DateTime))
INSERT [dbo].[company] ([Id], [Name], [Address], [Phone], [Fax], [Email], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Company1dsfdsf', N'dsfdsf', N'22222222222222', N'4234234', N'dsfsdfdsfsdf', 1, 1, CAST(N'2018-12-09 21:18:05.530' AS DateTime), 1, CAST(N'2018-12-09 21:18:05.530' AS DateTime))
INSERT [dbo].[company] ([Id], [Name], [Address], [Phone], [Fax], [Email], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'sdfdsfsdf', N'sdfsdf', N'22222222222222', N'4234234', N'sdfsdfsdf', 1, 1, CAST(N'2018-12-09 21:19:11.963' AS DateTime), 1, CAST(N'2018-12-09 21:19:11.963' AS DateTime))
INSERT [dbo].[company] ([Id], [Name], [Address], [Phone], [Fax], [Email], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'sdfsdfsd', NULL, NULL, NULL, NULL, 1, 1, CAST(N'2018-12-09 21:19:32.727' AS DateTime), 1, CAST(N'2018-12-09 21:19:32.727' AS DateTime))
INSERT [dbo].[company] ([Id], [Name], [Address], [Phone], [Fax], [Email], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (6, N'dsfsdfsdfsdf', N'sdfsdfsdf', N'22222222222222', NULL, NULL, 1, 1, CAST(N'2018-12-09 21:20:31.047' AS DateTime), 1, CAST(N'2018-12-09 21:20:31.047' AS DateTime))
SET IDENTITY_INSERT [dbo].[company] OFF
INSERT [dbo].[FaultComplexity] ([Id], [Name]) VALUES (0, N'Small low complexity machine, usually a single operator table top machine.')
INSERT [dbo].[FaultComplexity] ([Id], [Name]) VALUES (1, N'Machine is table top but complex.')
INSERT [dbo].[FaultComplexity] ([Id], [Name]) VALUES (2, N'Machine is medium sized and has medium complexity')
INSERT [dbo].[FaultComplexity] ([Id], [Name]) VALUES (3, N'Machine is medium sized with high complexity')
INSERT [dbo].[FaultComplexity] ([Id], [Name]) VALUES (4, N'Large machine with low complexity')
INSERT [dbo].[FaultComplexity] ([Id], [Name]) VALUES (5, N'Large machine with high complexity')
SET IDENTITY_INSERT [dbo].[FaultLibrary] ON 

INSERT [dbo].[FaultLibrary] ([Id], [FaultId], [Url], [FileName], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 7, N'40ef56b9-c17c-4964-8042-c91246a0af5c.txt', N'Release Dec.txt', NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[FaultLibrary] OFF
INSERT [dbo].[FaultPriorities] ([Id], [Name]) VALUES (0, N'Non-urgent jobs')
INSERT [dbo].[FaultPriorities] ([Id], [Name]) VALUES (1, N'Must be started 40 days')
INSERT [dbo].[FaultPriorities] ([Id], [Name]) VALUES (2, N'A machine is broken')
SET IDENTITY_INSERT [dbo].[Faults] ON 

INSERT [dbo].[Faults] ([Id], [CompanyId], [Location], [MachineDescription], [FaultDescription], [Priority], [Complexity], [FaultStatus], [StartDate], [AssignedTo], [Status], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) VALUES (1, 3, N'fgdgdgdfg', NULL, NULL, NULL, NULL, 1, CAST(N'2018-12-09 21:41:56.967' AS DateTime), NULL, 1, CAST(N'2018-12-09 21:41:56.963' AS DateTime), 1, 1, CAST(N'2018-12-09 21:41:56.967' AS DateTime))
INSERT [dbo].[Faults] ([Id], [CompanyId], [Location], [MachineDescription], [FaultDescription], [Priority], [Complexity], [FaultStatus], [StartDate], [AssignedTo], [Status], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) VALUES (2, 6, N'fgdgdgdfg', N'dsfldsfjdslfdsf
ds
fds
fdsfdsf', N'sdfdsfdsff dsfdsfdsfsdf
dsfsdfsdf', 0, 1, 1, CAST(N'2018-12-09 21:45:09.173' AS DateTime), NULL, 1, CAST(N'2018-12-09 21:45:09.170' AS DateTime), 1, 1, CAST(N'2018-12-09 21:45:09.173' AS DateTime))
INSERT [dbo].[Faults] ([Id], [CompanyId], [Location], [MachineDescription], [FaultDescription], [Priority], [Complexity], [FaultStatus], [StartDate], [AssignedTo], [Status], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) VALUES (3, 2, N'fgdgdgdfg', N'ljljll
;lk;k;k;', N'bmbmbmb
hkhhk
khhkhk', 0, 1, 0, CAST(N'2018-12-09 22:20:27.807' AS DateTime), NULL, 1, CAST(N'2018-12-09 22:20:27.803' AS DateTime), 1, 1, CAST(N'2018-12-09 22:20:27.807' AS DateTime))
INSERT [dbo].[Faults] ([Id], [CompanyId], [Location], [MachineDescription], [FaultDescription], [Priority], [Complexity], [FaultStatus], [StartDate], [AssignedTo], [Status], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) VALUES (4, 2, N'London', N'test
', N'test', 2, 5, 1, CAST(N'2018-12-11 07:09:05.367' AS DateTime), NULL, 1, CAST(N'2018-12-11 07:09:05.363' AS DateTime), 1, 1, CAST(N'2018-12-11 07:09:05.367' AS DateTime))
INSERT [dbo].[Faults] ([Id], [CompanyId], [Location], [MachineDescription], [FaultDescription], [Priority], [Complexity], [FaultStatus], [StartDate], [AssignedTo], [Status], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) VALUES (5, 2, N'London', N'test
', N'test', 2, 5, 1, CAST(N'2018-12-11 07:13:52.167' AS DateTime), 1, 1, CAST(N'2018-12-11 07:13:52.163' AS DateTime), 1, 1, CAST(N'2018-12-11 07:13:52.163' AS DateTime))
INSERT [dbo].[Faults] ([Id], [CompanyId], [Location], [MachineDescription], [FaultDescription], [Priority], [Complexity], [FaultStatus], [StartDate], [AssignedTo], [Status], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) VALUES (6, 2, N'London', N'xcvxc', N'xcvxv', 2, 2, 1, CAST(N'2018-12-11 07:24:59.347' AS DateTime), 1, 1, CAST(N'2018-12-11 07:24:59.343' AS DateTime), 1, 1, CAST(N'2018-12-11 07:24:59.347' AS DateTime))
INSERT [dbo].[Faults] ([Id], [CompanyId], [Location], [MachineDescription], [FaultDescription], [Priority], [Complexity], [FaultStatus], [StartDate], [AssignedTo], [Status], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) VALUES (7, 2, N'London', N'dfdfg', N'dfgdfgdf', 2, 3, 1, CAST(N'2018-12-11 07:26:58.997' AS DateTime), 1, 1, CAST(N'2018-12-11 07:26:58.797' AS DateTime), 1, 1, CAST(N'2018-12-11 07:26:58.967' AS DateTime))
SET IDENTITY_INSERT [dbo].[Faults] OFF
SET IDENTITY_INSERT [dbo].[UsersInfo] ON 

INSERT [dbo].[UsersInfo] ([Id], [Name], [Email], [Password], [RoleId], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Jason', N'jason@gmail.com', N'123456', 2, 1, NULL, CAST(N'2018-12-11 07:02:53.610' AS DateTime), NULL, CAST(N'2018-12-11 07:02:53.610' AS DateTime))
INSERT [dbo].[UsersInfo] ([Id], [Name], [Email], [Password], [RoleId], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'Admin', N'admin', N'123456', 1, 1, NULL, CAST(N'2018-12-11 07:03:09.430' AS DateTime), NULL, CAST(N'2018-12-11 07:03:09.430' AS DateTime))
SET IDENTITY_INSERT [dbo].[UsersInfo] OFF
ALTER TABLE [dbo].[FaultLibrary]  WITH CHECK ADD  CONSTRAINT [FK_FaultLibrary_Faults] FOREIGN KEY([FaultId])
REFERENCES [dbo].[Faults] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FaultLibrary] CHECK CONSTRAINT [FK_FaultLibrary_Faults]
GO
USE [master]
GO
ALTER DATABASE [NPD] SET  READ_WRITE 
GO
