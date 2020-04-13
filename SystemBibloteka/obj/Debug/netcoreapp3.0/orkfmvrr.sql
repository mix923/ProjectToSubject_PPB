IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Library] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Library] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Book] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [LibraryId] int NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Book_Library_LibraryId] FOREIGN KEY ([LibraryId]) REFERENCES [Library] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Book_LibraryId] ON [Book] ([LibraryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200411205133_AddProductReviews', N'3.1.3');

GO

ALTER TABLE [Library] ADD [City] nvarchar(max) NULL;

GO

ALTER TABLE [Library] ADD [SchoolId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Book] ADD [Author] nvarchar(max) NULL;

GO

ALTER TABLE [Book] ADD [Date] nvarchar(max) NULL;

GO

ALTER TABLE [Book] ADD [Side] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [School] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [City] nvarchar(max) NULL,
    CONSTRAINT [PK_School] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Library_SchoolId] ON [Library] ([SchoolId]);

GO

ALTER TABLE [Library] ADD CONSTRAINT [FK_Library_School_SchoolId] FOREIGN KEY ([SchoolId]) REFERENCES [School] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200411212618_AddSchool', N'3.1.3');

GO

