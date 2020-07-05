USE [master]
GO
/****** Object:  Database [MovieCatalogue]    Script Date: 07/05/2020 04:09:44 ******/
CREATE DATABASE [MovieCatalogue] ON  PRIMARY 
( NAME = N'MovieCatalogue', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MovieCatalogue.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MovieCatalogue_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\MovieCatalogue_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MovieCatalogue] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieCatalogue].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieCatalogue] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MovieCatalogue] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MovieCatalogue] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MovieCatalogue] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MovieCatalogue] SET ARITHABORT OFF
GO
ALTER DATABASE [MovieCatalogue] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [MovieCatalogue] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MovieCatalogue] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MovieCatalogue] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MovieCatalogue] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MovieCatalogue] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MovieCatalogue] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MovieCatalogue] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MovieCatalogue] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MovieCatalogue] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MovieCatalogue] SET  DISABLE_BROKER
GO
ALTER DATABASE [MovieCatalogue] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MovieCatalogue] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MovieCatalogue] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MovieCatalogue] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MovieCatalogue] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MovieCatalogue] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MovieCatalogue] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MovieCatalogue] SET  READ_WRITE
GO
ALTER DATABASE [MovieCatalogue] SET RECOVERY FULL
GO
ALTER DATABASE [MovieCatalogue] SET  MULTI_USER
GO
ALTER DATABASE [MovieCatalogue] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MovieCatalogue] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieCatalogue', N'ON'
GO
USE [MovieCatalogue]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07/05/2020 04:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 07/05/2020 04:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 07/05/2020 04:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Actor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Actor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Crew]    Script Date: 07/05/2020 04:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Crew](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_Crew] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 07/05/2020 04:09:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Year] [int] NULL,
	[Location] [text] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertGenre]    Script Date: 07/05/2020 04:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_InsertGenre] 
			@name varchar(200)			
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	INSERT INTO [Genre]
           ([Name])
     VALUES
           (@name)
           
     SELECT CAST(scope_identity() AS int);
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchGenreByName]    Script Date: 07/05/2020 04:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_SearchGenreByName] 
			@query varchar(200)
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Genre with (nolock) where name like '%'+ @query +'%'
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCatalogue]    Script Date: 07/05/2020 04:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchCatalogue] 
			@query varchar(200)
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Movie with (nolock) where Title like '%'+ @query +'%'
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertMovie]    Script Date: 07/05/2020 04:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertMovie] 
			@title varchar(200),
			@year int,
			@location varchar(200),
			@genre int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	INSERT INTO [Movie]
           ([Title]
           ,[Year]
           ,[Location]           
           ,[GenreId])
     VALUES
           (@title, @year, @location, @genre)
           
     SELECT CAST(scope_identity() AS int);
	
END;
GO
/****** Object:  Table [dbo].[CrewMovie]    Script Date: 07/05/2020 04:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrewMovie](
	[CrewId] [int] NOT NULL,
	[MovieId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 07/05/2020 04:09:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovie](
	[ActorId] [int] NOT NULL,
	[MovieId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Movie_Deleted]    Script Date: 07/05/2020 04:09:44 ******/
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF_Movie_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
/****** Object:  ForeignKey [FK_Crew_Role]    Script Date: 07/05/2020 04:09:44 ******/
ALTER TABLE [dbo].[Crew]  WITH CHECK ADD  CONSTRAINT [FK_Crew_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Crew] CHECK CONSTRAINT [FK_Crew_Role]
GO
/****** Object:  ForeignKey [FK_Movie_Genre]    Script Date: 07/05/2020 04:09:44 ******/
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Genre]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Crew]    Script Date: 07/05/2020 04:09:45 ******/
ALTER TABLE [dbo].[CrewMovie]  WITH CHECK ADD  CONSTRAINT [FK_CrewMovie_Crew] FOREIGN KEY([CrewId])
REFERENCES [dbo].[Crew] ([Id])
GO
ALTER TABLE [dbo].[CrewMovie] CHECK CONSTRAINT [FK_CrewMovie_Crew]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Movie]    Script Date: 07/05/2020 04:09:45 ******/
ALTER TABLE [dbo].[CrewMovie]  WITH CHECK ADD  CONSTRAINT [FK_CrewMovie_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[CrewMovie] CHECK CONSTRAINT [FK_CrewMovie_Movie]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Actor]    Script Date: 07/05/2020 04:09:45 ******/
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Actor] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([Id])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Actor]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Movie]    Script Date: 07/05/2020 04:09:45 ******/
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Movie]
GO
