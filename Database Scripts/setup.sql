USE [master]
GO
/****** Object:  Database [MovieCatalogue]    Script Date: 07/02/2020 23:15:27 ******/
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
/****** Object:  ForeignKey [FK_Movie_Genre]    Script Date: 07/02/2020 23:15:30 ******/
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [FK_Movie_Genre]
GO
/****** Object:  ForeignKey [FK_Crew_Role]    Script Date: 07/02/2020 23:15:30 ******/
ALTER TABLE [dbo].[Crew] DROP CONSTRAINT [FK_Crew_Role]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Crew]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Crew]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Movie]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Movie]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Actor]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Actor]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Movie]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Movie]
GO
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Actor]
GO
ALTER TABLE [dbo].[ActorMovie] DROP CONSTRAINT [FK_ActorMovie_Movie]
GO
DROP TABLE [dbo].[ActorMovie]
GO
/****** Object:  Table [dbo].[CrewMovie]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Crew]
GO
ALTER TABLE [dbo].[CrewMovie] DROP CONSTRAINT [FK_CrewMovie_Movie]
GO
DROP TABLE [dbo].[CrewMovie]
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchCatalogue]    Script Date: 07/02/2020 23:15:33 ******/
DROP PROCEDURE [dbo].[usp_SearchCatalogue]
GO
/****** Object:  Table [dbo].[Crew]    Script Date: 07/02/2020 23:15:30 ******/
ALTER TABLE [dbo].[Crew] DROP CONSTRAINT [FK_Crew_Role]
GO
DROP TABLE [dbo].[Crew]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 07/02/2020 23:15:30 ******/
ALTER TABLE [dbo].[Movie] DROP CONSTRAINT [FK_Movie_Genre]
GO
DROP TABLE [dbo].[Movie]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07/02/2020 23:15:30 ******/
DROP TABLE [dbo].[Role]
GO
/****** Object:  Table [dbo].[Actor]    Script Date: 07/02/2020 23:15:30 ******/
DROP TABLE [dbo].[Actor]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 07/02/2020 23:15:30 ******/
DROP TABLE [dbo].[Genre]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 07/02/2020 23:15:30 ******/
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
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (1, N'Crime')
SET IDENTITY_INSERT [dbo].[Genre] OFF
/****** Object:  Table [dbo].[Actor]    Script Date: 07/02/2020 23:15:30 ******/
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
INSERT [dbo].[Actor] ([Id], [Name]) VALUES (1, N'Robert De Niro')
INSERT [dbo].[Actor] ([Id], [Name]) VALUES (2, N'Ray Liotta')
INSERT [dbo].[Actor] ([Id], [Name]) VALUES (3, N'Joe Pesci')
SET IDENTITY_INSERT [dbo].[Actor] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 07/02/2020 23:15:30 ******/
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
INSERT [dbo].[Role] ([Id], [Title]) VALUES (2, N'Writer')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (3, N'Editor')
INSERT [dbo].[Role] ([Id], [Title]) VALUES (4, N'Director of Photography')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Movie]    Script Date: 07/02/2020 23:15:30 ******/
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
SET IDENTITY_INSERT [dbo].[Movie] ON
INSERT [dbo].[Movie] ([Id], [Title], [Year], [Location], [Deleted], [GenreId]) VALUES (1, N'Goodfellas', 1990, N'DVD', 0, 1)
SET IDENTITY_INSERT [dbo].[Movie] OFF
/****** Object:  Table [dbo].[Crew]    Script Date: 07/02/2020 23:15:30 ******/
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
INSERT [dbo].[Crew] ([Id], [Name], [RoleId]) VALUES (1, N'Martin Scorcese', 1)
INSERT [dbo].[Crew] ([Id], [Name], [RoleId]) VALUES (2, N'Nicholas Pileggi', 2)
INSERT [dbo].[Crew] ([Id], [Name], [RoleId]) VALUES (3, N'James Kwei', 3)
INSERT [dbo].[Crew] ([Id], [Name], [RoleId]) VALUES (4, N'Thelma Schoonmaker', 3)
INSERT [dbo].[Crew] ([Id], [Name], [RoleId]) VALUES (5, N'Michael Ballhaus', 4)
SET IDENTITY_INSERT [dbo].[Crew] OFF
/****** Object:  StoredProcedure [dbo].[usp_SearchCatalogue]    Script Date: 07/02/2020 23:15:33 ******/
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
/****** Object:  Table [dbo].[CrewMovie]    Script Date: 07/02/2020 23:15:33 ******/
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
INSERT [dbo].[CrewMovie] ([CrewId], [MovieId]) VALUES (2, 1)
INSERT [dbo].[CrewMovie] ([CrewId], [MovieId]) VALUES (3, 1)
INSERT [dbo].[CrewMovie] ([CrewId], [MovieId]) VALUES (4, 1)
INSERT [dbo].[CrewMovie] ([CrewId], [MovieId]) VALUES (5, 1)
/****** Object:  Table [dbo].[ActorMovie]    Script Date: 07/02/2020 23:15:33 ******/
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
INSERT [dbo].[ActorMovie] ([ActorId], [MovieId]) VALUES (3, 1)
/****** Object:  ForeignKey [FK_Movie_Genre]    Script Date: 07/02/2020 23:15:30 ******/
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Genre]
GO
/****** Object:  ForeignKey [FK_Crew_Role]    Script Date: 07/02/2020 23:15:30 ******/
ALTER TABLE [dbo].[Crew]  WITH CHECK ADD  CONSTRAINT [FK_Crew_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[Crew] CHECK CONSTRAINT [FK_Crew_Role]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Crew]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[CrewMovie]  WITH CHECK ADD  CONSTRAINT [FK_CrewMovie_Crew] FOREIGN KEY([CrewId])
REFERENCES [dbo].[Crew] ([Id])
GO
ALTER TABLE [dbo].[CrewMovie] CHECK CONSTRAINT [FK_CrewMovie_Crew]
GO
/****** Object:  ForeignKey [FK_CrewMovie_Movie]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[CrewMovie]  WITH CHECK ADD  CONSTRAINT [FK_CrewMovie_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[CrewMovie] CHECK CONSTRAINT [FK_CrewMovie_Movie]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Actor]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Actor] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actor] ([Id])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Actor]
GO
/****** Object:  ForeignKey [FK_ActorMovie_Movie]    Script Date: 07/02/2020 23:15:33 ******/
ALTER TABLE [dbo].[ActorMovie]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovie_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[ActorMovie] CHECK CONSTRAINT [FK_ActorMovie_Movie]
GO
