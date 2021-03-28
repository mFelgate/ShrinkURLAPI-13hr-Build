
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/21/2021 19:09:48
-- Generated from EDMX file: C:\Users\mfelg\source\repos\mFelgate\ShrinkURLAPI\URLDirectoryRepo\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Urls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Urls];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Urls'
CREATE TABLE [dbo].[Urls] (
    [id] int IDENTITY(1,1) NOT NULL,
    [shortUrl] nvarchar(25)  NULL,
    [longUrl] nvarchar(2400)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Urls'
ALTER TABLE [dbo].[Urls]
ADD CONSTRAINT [PK_Urls]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------