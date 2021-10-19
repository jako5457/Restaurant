USE master
CREATE DATABASE RestaurantDB

GO

USE RestaurantDB

GO

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Restaurants] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(80) NOT NULL,
    [Location] nvarchar(255) NOT NULL,
    [Cuisine] int NOT NULL,
    CONSTRAINT [PK_Restaurants] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cuisine', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
    SET IDENTITY_INSERT [Restaurants] ON;
INSERT INTO [Restaurants] ([Id], [Cuisine], [Location], [Name])
VALUES (1, 2, N'Maryland', N'Scott''s Pizza');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cuisine', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
    SET IDENTITY_INSERT [Restaurants] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cuisine', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
    SET IDENTITY_INSERT [Restaurants] ON;
INSERT INTO [Restaurants] ([Id], [Cuisine], [Location], [Name])
VALUES (2, 2, N'London', N'Cinnamon Club');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cuisine', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
    SET IDENTITY_INSERT [Restaurants] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cuisine', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
    SET IDENTITY_INSERT [Restaurants] ON;
INSERT INTO [Restaurants] ([Id], [Cuisine], [Location], [Name])
VALUES (3, 1, N'California', N'La Costa');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Cuisine', N'Location', N'Name') AND [object_id] = OBJECT_ID(N'[Restaurants]'))
    SET IDENTITY_INSERT [Restaurants] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211019074956_initial', N'5.0.11');
GO

COMMIT;
GO

