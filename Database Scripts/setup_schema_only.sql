USE [master]
GO
/****** Object:  Database [MovieCatalogue]    Script Date: 07/06/2020 20:47:47 ******/
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
/****** Object:  ForeignKey [FK_Movie_Genre]    Script Date: 07/06/2020 20:47:54 ******/
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [FK_Movie_Genre]
GO
/****** Object:  ForeignKey [FK_Crew_Role]    Script Date: 07/06/2020 20:47:54 ******/
ALTER TABLE [dbo].[Crew] DROP CONSTRAINT [FK_Crew_Role]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Crew]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Crew]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Movie]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Movie]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Actor]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Actor]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Movie]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Movie]
GO
/****** Object:  StoredProcedure [dbo].[TruncateTables]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[TruncateTables]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertActorMovie]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_InsertActorMovie]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCrewMovie]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_InsertCrewMovie]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCatalogue]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_SearchCatalogue]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCatalogueByMovieTitle]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_SearchCatalogueByMovieTitle]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCrewById]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_SearchCrewById]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCrewByName]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_SearchCrewByName]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertMovie]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_InsertMovie]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchMovieById]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_SearchMovieById]
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateMovie]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_UpdateMovie]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCrew]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_InsertCrew]
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteMovie]    Script Date: 07/06/2020 20:47:55 ******/
DROP PROCEDURE [dbo].[usp_DeleteMovie]
GO
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Actor]
GO
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Movie]
GO
DROP TABLE [dbo].[ActorMovie]
GO
/****** Object:  Table [dbo].[CrewMovie]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Crew]
GO
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Movie]
GO
DROP TABLE [dbo].[CrewMovie]
GO
/****** Object:  Table [dbo].[Crew]    Script Date: 07/06/2020 20:47:54 ******/
ALTER TABLE [dbo].[Crew] DROP CONSTRAINT [FK_Crew_Role]
GO
DROP TABLE [dbo].[Crew]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertActor]    Script Date: 07/06/2020 20:47:54 ******/
DROP PROCEDURE [dbo].[usp_InsertActor]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 07/06/2020 20:47:54 ******/
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [FK_Movie_Genre]
GO
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [DF_Movie_Deleted]
GO
DROP TABLE [dbo].[Movie]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchActorById]    Script Date: 07/06/2020 20:47:54 ******/
DROP PROCEDURE [dbo].[usp_SearchActorById]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchActorByName]    Script Date: 07/06/2020 20:47:54 ******/
DROP PROCEDURE [dbo].[usp_SearchActorByName]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertGenre]    Script Date: 07/06/2020 20:47:54 ******/
DROP PROCEDURE [dbo].[usp_InsertGenre]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchGenreById]    Script Date: 07/06/2020 20:47:54 ******/
DROP PROCEDURE [dbo].[usp_SearchGenreById]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchGenreByName]    Script Date: 07/06/2020 20:47:54 ******/
DROP PROCEDURE [dbo].[usp_SearchGenreByName]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07/06/2020 20:47:51 ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 07/06/2020 20:47:51 ******/
DROP TABLE [dbo].[Actor]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 07/06/2020 20:47:51 ******/
DROP TABLE [dbo].[Genre]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 07/06/2020 20:47:51 ******/
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
SET IDENTITY_INSERT [dbo].[Genre] ON
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (1, N'War')
SET IDENTITY_INSERT [dbo].[Genre] OFF
/****** Object:  Table [dbo].[Actor]    Script Date: 07/06/2020 20:47:51 ******/
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
SET IDENTITY_INSERT [dbo].[Actor] ON
INSERT [dbo].[Actor] ([Id], [Name]) VALUES (1, N'Tom Berenger')
INSERT [dbo].[Actor] ([Id], [Name]) VALUES (2, N' Charlie Sheen')
SET IDENTITY_INSERT [dbo].[Actor] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 07/06/2020 20:47:51 ******/
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
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([Id], [Title]) VALUES (1, N'Director')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  StoredProcedure [dbo].[usp_SearchGenreByName]    Script Date: 07/06/2020 20:47:54 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SearchGenreById]    Script Date: 07/06/2020 20:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_SearchGenreById] 
			@id int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Genre with (nolock) where Id = @id
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertGenre]    Script Date: 07/06/2020 20:47:54 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SearchActorByName]    Script Date: 07/06/2020 20:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_SearchActorByName] 
			@query varchar(200)
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Actor with (nolock) where name like '%'+ @query +'%'
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchActorById]    Script Date: 07/06/2020 20:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_SearchActorById] 
			@id int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Actor with (nolock) where Id = @id
	
END;
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 07/06/2020 20:47:54 ******/
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
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_Movie_Deleted]  DEFAULT ((0)),
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Movie] ON
INSERT [dbo].[Movie] ([Id], [Title], [Year], [Location], [Deleted], [GenreId]) VALUES (1, N'Platoon', 1986, N'DVD', 0, 1)
SET IDENTITY_INSERT [dbo].[Movie] OFF
/****** Object:  StoredProcedure [dbo].[usp_InsertActor]    Script Date: 07/06/2020 20:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_InsertActor] 
			@name varchar(200)			
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	INSERT INTO [Actor]
           ([Name])
     VALUES
           (@name)
           
     SELECT CAST(scope_identity() AS int);
	
END;
GO
/****** Object:  Table [dbo].[Crew]    Script Date: 07/06/2020 20:47:54 ******/
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
SET IDENTITY_INSERT [dbo].[Crew] ON
INSERT [dbo].[Crew] ([Id], [Name], [RoleId]) VALUES (1, N'Oliver Stone', 1)
SET IDENTITY_INSERT [dbo].[Crew] OFF
/****** Object:  Table [dbo].[CrewMovie]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrewMovie](
	[CrewId] [int] NOT NULL,
	[MovieId] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[CrewMovie] ([CrewId], [MovieId]) VALUES (1, 1)
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovie](
	[ActorId] [int] NOT NULL,
	[MovieId] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[ActorMovie] ([ActorId], [MovieId]) VALUES (1, 1)
INSERT [dbo].[ActorMovie] ([ActorId], [MovieId]) VALUES (2, 1)
/****** Object:  StoredProcedure [dbo].[usp_DeleteMovie]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteMovie] 
			@id int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	Update Movie set Deleted = 1 where Id = @id
           
     SELECT @@rowcount;
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCrew]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_InsertCrew] 
			@name varchar(200)			
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	INSERT INTO [Crew]
           ([Name], [RoleId])
     VALUES
           (@name, 1) -- only adding functionality to add directors for now
           
     SELECT CAST(scope_identity() AS int);
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateMovie]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_UpdateMovie] 
			@id int,
			@title varchar(200),
			@year int,
			@location varchar(200),
			@genre int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	Update Movie set Title = @title, Year = @year, Location = @location, GenreId = @genre
	where Id = @id
           
     SELECT @@rowcount;
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchMovieById]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_SearchMovieById] 
			@id int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Movie with (nolock) where Id = @id
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertMovie]    Script Date: 07/06/2020 20:47:55 ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SearchCrewByName]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_SearchCrewByName] 
			@query varchar(200)
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Crew with (nolock) where name like '%'+ @query +'%'
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCrewById]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_SearchCrewById] 
			@id int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * from Crew with (nolock) where Id = @id
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCatalogueByMovieTitle]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchCatalogueByMovieTitle] 
			@query varchar(200)
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--select m.Title, a.Name, m.Location, m.Year, c.Name as 'Director', g.name as 'Genre' from Movie m with (nolock)
	--inner join ActorMovie am with (nolock) on am.movieId = m.Id
	--inner join Actor a with (nolock) on a.Id = am.actorId
	--inner join Genre g with (nolock) on g.Id = m.genreId
	--inner join CrewMovie cm with (nolock) on cm.movieId = m.Id
	--inner join Crew c with (nolock) on c.Id = cm.crewId
	--where m.Title like '%' + @query + '%' and m.deleted = 0
	
	
	select Title, Location, Year, g.Name
	from Movie m with (nolock) 
	inner join Genre g on g.Id = m.GenreId
	where deleted = 0 and title like '%' + @query + '%'
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCatalogue]    Script Date: 07/06/2020 20:47:55 ******/
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

	select m.Title, a.Name, m.Location, m.Year, c.Name as 'Director', g.name as 'Genre' from Movie m with (nolock)
	inner join ActorMovie am with (nolock) on am.movieId = m.Id
	inner join Actor a with (nolock) on a.Id = am.actorId
	inner join Genre g with (nolock) on g.Id = m.genreId
	inner join CrewMovie cm with (nolock) on cm.movieId = m.Id
	inner join Crew c with (nolock) on c.Id = cm.crewId
	where m.Title like '%' + @query + '%' and m.deleted = 0
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCrewMovie]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertCrewMovie] 
			@crewId int,
			@movieId int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	INSERT INTO [CrewMovie]
           ([CrewId], [MovieId])
     VALUES
           (@crewId, @movieId)
           
     SELECT @@RowCount;
	
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertActorMovie]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertActorMovie] 
			@actorId int,
			@movieId int
			
			AS

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	INSERT INTO [ActorMovie]
           ([ActorId], [MovieId])
     VALUES
           (@actorId, @movieId)
           
     SELECT @@RowCount;
	
END;
GO
/****** Object:  StoredProcedure [dbo].[TruncateTables]    Script Date: 07/06/2020 20:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TruncateTables] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;	

	delete from crewmovie
	delete from actormovie		
	delete from movie
	delete from actor
	delete from genre
	delete from crew
	delete from [role]
	
	DBCC CHECKIDENT ('movie', RESEED, 0)
	DBCC CHECKIDENT ('actor', RESEED, 0)
	DBCC CHECKIDENT ('genre', RESEED, 0)
	DBCC CHECKIDENT ('crew', RESEED, 0)
	DBCC CHECKIDENT ('role', RESEED, 0)
	
	insert into [role](title) values('Director')
	
END;
GO
/****** Object:  ForeignKey [FK_Movie_Genre]    Script Date: 07/06/2020 20:47:54 ******/
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Genre]
GO
/****** Object:  ForeignKey [FK_Crew_Role]    Script Date: 07/06/2020 20:47:54 ******/
ALTER TABLE [dbo].[Crew]  WITH CHECK ADD  CONSTRAINT [FK_Crew_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Crew] CHECK CONSTRAINT [FK_Crew_Role]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Crew]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[CrewMovie]  WITH CHECK ADD  CONSTRAINT [FK_CrewMovie_Crew] FOREIGN KEY([CrewId])
REFERENCES [dbo].[Crew] ([Id])
GO
ALTER TABLE [dbo].[CrewMovie] CHECK CONSTRAINT [FK_CrewMovie_Crew]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Movie]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[CrewMovie]  WITH CHECK ADD  CONSTRAINT [FK_CrewMovie_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[CrewMovie] CHECK CONSTRAINT [FK_CrewMovie_Movie]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Actor]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Actor] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([Id])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Actor]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Movie]    Script Date: 07/06/2020 20:47:55 ******/
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Movie]
GO
