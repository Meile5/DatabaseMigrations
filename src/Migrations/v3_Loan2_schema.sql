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

BEGIN TRANSACTION;
ALTER TABLE [Loans] ADD [AuthorId] uniqueidentifier NULL;

CREATE TABLE [Author] (
    [Id] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Biography] nvarchar(max) NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY ([Id])
);

CREATE TABLE [BookAuthor] (
    [Id] uniqueidentifier NOT NULL,
    [BookId] uniqueidentifier NOT NULL,
    [AuthorId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_BookAuthor] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BookAuthor_Author_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Author] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_BookAuthor_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE NO ACTION
);

CREATE INDEX [IX_Loans_AuthorId] ON [Loans] ([AuthorId]);

CREATE INDEX [IX_BookAuthor_AuthorId] ON [BookAuthor] ([AuthorId]);

CREATE INDEX [IX_BookAuthor_BookId] ON [BookAuthor] ([BookId]);

ALTER TABLE [Loans] ADD CONSTRAINT [FK_Loans_Author_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Author] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260228130246_BookAuthor', N'10.0.3');

COMMIT;
GO

BEGIN TRANSACTION;
CREATE TABLE [Member2] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Email] nvarchar(450) NOT NULL,
    [Phone] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Member2] PRIMARY KEY ([Id])
);

CREATE TABLE [Loan2] (
    [Id] uniqueidentifier NOT NULL,
    [MemberId] uniqueidentifier NOT NULL,
    [BookId] uniqueidentifier NOT NULL,
    [loanDate] datetime2 NOT NULL,
    [returnDate] datetime2 NULL,
    CONSTRAINT [PK_Loan2] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Loan2_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Loan2_Member2_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [Member2] ([Id]) ON DELETE NO ACTION
);

CREATE INDEX [IX_Loan2_BookId] ON [Loan2] ([BookId]);

CREATE INDEX [IX_Loan2_MemberId] ON [Loan2] ([MemberId]);

CREATE UNIQUE INDEX [IX_Member2_Email] ON [Member2] ([Email]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260228155100_Loan2', N'10.0.3');

COMMIT;
GO

