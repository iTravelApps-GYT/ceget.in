USE [master]
GO
/****** Object:  Database [GCNI]    Script Date: 11/14/2015 21:39:56 ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'GCNI')
BEGIN
CREATE DATABASE [GCNI] ON  PRIMARY 
( NAME = N'GCNI', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GCNI.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GCNI_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\GCNI_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [GCNI] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GCNI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GCNI] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [GCNI] SET ANSI_NULLS OFF
GO
ALTER DATABASE [GCNI] SET ANSI_PADDING OFF
GO
ALTER DATABASE [GCNI] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [GCNI] SET ARITHABORT OFF
GO
ALTER DATABASE [GCNI] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [GCNI] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [GCNI] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [GCNI] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [GCNI] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [GCNI] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [GCNI] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [GCNI] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [GCNI] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [GCNI] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [GCNI] SET  DISABLE_BROKER
GO
ALTER DATABASE [GCNI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [GCNI] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [GCNI] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [GCNI] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [GCNI] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [GCNI] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [GCNI] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [GCNI] SET  READ_WRITE
GO
ALTER DATABASE [GCNI] SET RECOVERY SIMPLE
GO
ALTER DATABASE [GCNI] SET  MULTI_USER
GO
ALTER DATABASE [GCNI] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [GCNI] SET DB_CHAINING OFF
GO
USE [GCNI]
GO
/****** Object:  Table [dbo].[PublicationMaster]    Script Date: 11/14/2015 21:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PublicationMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PublicationMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[ThumbnailURL] [nvarchar](250) NULL,
	[FileURL] [nvarchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDisplayOnHome] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_PublicationMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[PublicationMaster] ON
INSERT [dbo].[PublicationMaster] ([ID], [Title], [Description], [ThumbnailURL], [FileURL], [IsActive], [IsDisplayOnHome], [CreatedOn]) VALUES (10, N'ttyrtyrtyr', N'tyrtyrtyrtyrtyrty', N'0a634cc4-0782-4e2c-bf6c-d2209151c5dc20140327_213656.jpg', N'849027a0-531f-4181-82a9-5bf66af9a8d020140324_103730.jpg', 1, 1, CAST(0x0000A54B015A551E AS DateTime))
SET IDENTITY_INSERT [dbo].[PublicationMaster] OFF
/****** Object:  Table [dbo].[NewsMaster]    Script Date: 11/14/2015 21:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NewsMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NewsMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[City] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[IsDisplayOnHome] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_NewsMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[NewsMaster] ON
INSERT [dbo].[NewsMaster] ([Id], [Title], [Description], [City], [IsActive], [IsDisplayOnHome], [CreatedOn]) VALUES (1, N'gfhfgh', N'fghfghfgh', N'nbnvbnvbn', 1, 0, CAST(0x0000A54B01613388 AS DateTime))
INSERT [dbo].[NewsMaster] ([Id], [Title], [Description], [City], [IsActive], [IsDisplayOnHome], [CreatedOn]) VALUES (2, N'gfhfghvnvbn', N'fghfghfghvbnvbn', N'nbnvbnvbnvbnvbn', 1, 0, CAST(0x0000A54B01613EFF AS DateTime))
INSERT [dbo].[NewsMaster] ([Id], [Title], [Description], [City], [IsActive], [IsDisplayOnHome], [CreatedOn]) VALUES (3, N'gfhfghvnvbnnbvbn', N'fghfghfghvbnvbnvbnv', N'nbnvbnvbnvbnvbnvbnv', 1, 0, CAST(0x0000A54B016145E8 AS DateTime))
SET IDENTITY_INSERT [dbo].[NewsMaster] OFF
/****** Object:  Table [dbo].[EventMaster]    Script Date: 11/14/2015 21:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventMaster](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[Venue] [varchar](200) NULL,
	[Lat] [numeric](18, 6) NULL,
	[Lng] [numeric](18, 6) NULL,
	[VideoURL] [nvarchar](250) NULL,
	[ImageURL] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[IsDisplayOnHome] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_EventMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EventMaster] ON
INSERT [dbo].[EventMaster] ([Id], [Title], [Description], [Venue], [Lat], [Lng], [VideoURL], [ImageURL], [IsActive], [IsDisplayOnHome], [CreatedOn]) VALUES (1, N'gdgh', N'dfgdfg', N'dfg', CAST(18.964700 AS Numeric(18, 6)), CAST(72.825800 AS Numeric(18, 6)), N'hgfhfgh', N',2730cinsertsimisangjump635830485147699761.png', 1, 1, CAST(0x0000A54F01693E46 AS DateTime))
SET IDENTITY_INSERT [dbo].[EventMaster] OFF
/****** Object:  Table [dbo].[BlogMaster]    Script Date: 11/14/2015 21:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BlogMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[BlogMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[IsDisplay] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_BlogMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleMaster]    Script Date: 11/14/2015 21:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ArticleMaster]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ArticleMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[IsDisplayOnHome] [bit] NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_ArticleMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ArticleMaster] ON
INSERT [dbo].[ArticleMaster] ([ID], [Title], [Description], [IsActive], [IsDisplayOnHome], [CreatedOn]) VALUES (1, N'ar', N'des', 1, 1, CAST(0x0000A54A01536545 AS DateTime))
INSERT [dbo].[ArticleMaster] ([ID], [Title], [Description], [IsActive], [IsDisplayOnHome], [CreatedOn]) VALUES (2, N'ar2', N'des2', 1, 1, CAST(0x0000A54A01537921 AS DateTime))
SET IDENTITY_INSERT [dbo].[ArticleMaster] OFF
/****** Object:  StoredProcedure [dbo].[spPublication]    Script Date: 11/14/2015 21:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPublication]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <06 Nov,2015>
-- Description:	<For Publication Management>
-- =============================================
CREATE PROCEDURE [dbo].[spPublication]
@ID bigint=0,
@Title varchar(50)='''',
@Description varchar(200)='''',
@ThumbnailURL nvarchar(250)='''',
@FileURL nvarchar(250)='''',
@IsDisplayOnHome bit=0,
@Qtype varchar(100)=''''
AS
BEGIN
	if(@Qtype=''Insert'')
	Begin
	Insert into PublicationMaster(Title,Description,ThumbnailURL,FileURL,IsDisplayOnHome)values(@Title,@Description,@ThumbnailURL,@FileURL,@IsDisplayOnHome);
	End
	if(@Qtype=''update'')
	Begin
	update PublicationMaster set Title=@Title, Description=@Description, ThumbnailURL=@ThumbnailURL , FileURL=@FileURL, IsDisplayOnHome=@IsDisplayOnHome where ID=@ID;
	End
	if(@Qtype=''Select'')
	Begin
		Select * from PublicationMaster where IsActive=1;
	End
	if(@Qtype=''delete'')
	Begin
		delete from PublicationMaster where ID=@ID;
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spNews]    Script Date: 11/14/2015 21:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spNews]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <06 Nov,2015>
-- Description:	<For News Management>
-- =============================================
CREATE PROCEDURE [dbo].[spNews]
@ID bigint=0,
@Title varchar(50)='''',
@Description varchar(200)='''',
@City varchar(50)='''',
@IsDisplayOnHome bit=0,
@Qtype varchar(100)=''''
AS
BEGIN
	if(@Qtype=''Insert'')
	Begin
	--if Exists(Select 1 from EventMaster where EventTitle=@Title And Description=@Description And Venue=@Venue And IsActive=0)
	--Begin
	--	Update EventMaster set IsActive=1;
	--End
	--else if Exists(Select 1 from EventMaster where EventTitle=@Title And Description=@Description And Venue=@Venue And IsActive=0)
	--Begin
	Insert into NewsMaster(Title,Description,City,IsDisplayOnHome)values(@Title,@Description,@City,@IsDisplayOnHome);
	--End
	--else
	--		begin
	--			Select ''Event, Is Already Exists,..Try With Another!!!''
	--		end
			
	End
	if(@Qtype=''update'')
	Begin
	update NewsMaster set Title=@Title, Description=@Description, City=@City, IsDisplayOnHome=@IsDisplayOnHome where ID=@ID;
	End
	if(@Qtype=''Select'')
	Begin
		Select * from NewsMaster where IsActive=1;
	End
	if(@Qtype=''delete'')
	Begin
		delete from NewsMaster where ID=@ID;
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spEvent]    Script Date: 11/14/2015 21:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spEvent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <06 Nov,2015>
-- Description:	<For Event Management>
-- =============================================
CREATE PROCEDURE [dbo].[spEvent]
@ID bigint=0,
@Title varchar(50)='''',
@Description varchar(200)='''',
@Venue varchar(200)='''',
@Lat numeric(18,6)=0,
@Lng numeric(18,6)=0,
@videoURL varchar(250)='''',
@ImageURL varchar(Max)='''',
@IsDisplayOnHome bit=0,

@Qtype varchar(100)=''''
AS
BEGIN
	if(@Qtype=''Insert'')
	Begin
	
	Insert into EventMaster(Title,Description,Venue,Lat,Lng,VideoURL,ImageURL,IsDisplayOnHome)values(@Title,@Description,@Venue,@Lat,@Lng,@videoURL,@ImageURL,@IsDisplayOnHome);
	
	End
	if(@Qtype=''Select'')
	Begin
		Select * from EventMaster where IsActive=1;
	End
	if(@Qtype=''delete'')
	Begin
		delete from EventMaster where ID=@ID;
	End
	if(@Qtype=''update'')
	Begin
	
	update EventMaster set Title=@Title,Description=@Description,Venue=@Venue,Lat=@Lat,Lng=@lng,VideoURL=@videoURL,ImageURL=@ImageURL,IsDisplayOnHome=@IsDisplayOnHome where id=@ID; 
	
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spBlog]    Script Date: 11/14/2015 21:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBlog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <06 Nov,2015>
-- Description:	<For Blogs Management>
-- =============================================
Create PROCEDURE [dbo].[spBlog]
@ID bigint=0,
@Title varchar(50)='''',
@Description varchar(200)='''',
@Qtype varchar(100)=''''
AS
BEGIN
	if(@Qtype=''Insert'')
	Begin
	--if Exists(Select 1 from EventMaster where EventTitle=@Title And Description=@Description And Venue=@Venue And IsActive=0)
	--Begin
	--	Update EventMaster set IsActive=1;
	--End
	--else if Exists(Select 1 from EventMaster where EventTitle=@Title And Description=@Description And Venue=@Venue And IsActive=0)
	--Begin
	Insert into BlogMaster(Title,Description)values(@Title,@Description);
	--End
	--else
	--		begin
	--			Select ''Event, Is Already Exists,..Try With Another!!!''
	--		end
			
	End
	if(@Qtype=''Select'')
	Begin
		Select * from BlogMaster where IsActive=1;
	End
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spArticle]    Script Date: 11/14/2015 21:40:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spArticle]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Bhupendra Kumar>
-- Create date: <06 Nov,2015>
-- Description:	<For Event Management>
-- =============================================
CREATE PROCEDURE [dbo].[spArticle]
@ID bigint=0,
@Title varchar(50)='''',
@Description varchar(200)='''',
@IsDisplayOnHome bit=0,

@Qtype varchar(100)=''''
AS
BEGIN
	if(@Qtype=''Insert'')
	Begin
	
	Insert into ArticleMaster(Title,Description,IsDisplayOnHome)values(@Title,@Description,@IsDisplayOnHome);
	
	End
	if(@Qtype=''update'')
	Begin
	
	update ArticleMaster set Title=@Title, Description=@Description, IsDisplayOnHome=@IsDisplayOnHome where ID=@ID;
	
	End
	if(@Qtype=''Select'')
	Begin
		Select * from ArticleMaster where IsActive=1;
	End
	if(@Qtype=''delete'')
	Begin
		delete from ArticleMaster where ID=@ID;
	End
END

' 
END
GO
/****** Object:  Default [DF_PublicationMaster_IsActive]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_PublicationMaster_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[PublicationMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PublicationMaster_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PublicationMaster] ADD  CONSTRAINT [DF_PublicationMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
/****** Object:  Default [DF_PublicationMaster_CreatedOn]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_PublicationMaster_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[PublicationMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PublicationMaster_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PublicationMaster] ADD  CONSTRAINT [DF_PublicationMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
END


End
GO
/****** Object:  Default [DF_NewsMaster_IsActive]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_NewsMaster_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[NewsMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_NewsMaster_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[NewsMaster] ADD  CONSTRAINT [DF_NewsMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
/****** Object:  Default [DF_NewsMaster_CreatedOn]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_NewsMaster_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[NewsMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_NewsMaster_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[NewsMaster] ADD  CONSTRAINT [DF_NewsMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
END


End
GO
/****** Object:  Default [DF_EventMaster_IsActive]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EventMaster_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EventMaster_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EventMaster] ADD  CONSTRAINT [DF_EventMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
/****** Object:  Default [DF_EventMaster_IsDisplayOnHome]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EventMaster_IsDisplayOnHome]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EventMaster_IsDisplayOnHome]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EventMaster] ADD  CONSTRAINT [DF_EventMaster_IsDisplayOnHome]  DEFAULT ((0)) FOR [IsDisplayOnHome]
END


End
GO
/****** Object:  Default [DF_EventMaster_CreatedOn]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_EventMaster_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_EventMaster_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EventMaster] ADD  CONSTRAINT [DF_EventMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
END


End
GO
/****** Object:  Default [DF_BlogMaster_IsActive]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_BlogMaster_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[BlogMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BlogMaster_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[BlogMaster] ADD  CONSTRAINT [DF_BlogMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
/****** Object:  Default [DF_BlogMaster_CreatedOn]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_BlogMaster_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[BlogMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_BlogMaster_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[BlogMaster] ADD  CONSTRAINT [DF_BlogMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
END


End
GO
/****** Object:  Default [DF_ArticleMaster_IsActive]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ArticleMaster_IsActive]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArticleMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ArticleMaster_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ArticleMaster] ADD  CONSTRAINT [DF_ArticleMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
END


End
GO
/****** Object:  Default [DF_ArticleMaster_CreatedOn]    Script Date: 11/14/2015 21:39:58 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ArticleMaster_CreatedOn]') AND parent_object_id = OBJECT_ID(N'[dbo].[ArticleMaster]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ArticleMaster_CreatedOn]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ArticleMaster] ADD  CONSTRAINT [DF_ArticleMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
END


End
GO
