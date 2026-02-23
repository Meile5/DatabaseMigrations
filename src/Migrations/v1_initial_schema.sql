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
CREATE TABLE [Books] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [ISBN] nvarchar(max) NOT NULL,
    [PublishDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);

CREATE TABLE [Members] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Members] PRIMARY KEY ([Id])
);

CREATE TABLE [Loans] (
    [Id] uniqueidentifier NOT NULL,
    [MemberId] uniqueidentifier NOT NULL,
    [BookId] uniqueidentifier NOT NULL,
    [loanDate] datetime2 NOT NULL,
    [returnDate] datetime2 NULL,
    CONSTRAINT [PK_Loans] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Loans_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Loans_Members_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Members] ([Id]) ON DELETE NO ACTION
);

CREATE INDEX [IX_Loans_BookId] ON [Loans] ([BookId]);

CREATE INDEX [IX_Loans_MemberId] ON [Loans] ([MemberId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260223113631_InitialCreate', N'10.0.3');

COMMIT;
GO

