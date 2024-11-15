IF OBJECT_ID(N'[pizza].[_EFMigrationHistory]') IS NULL
BEGIN
    IF SCHEMA_ID(N'pizza') IS NULL EXEC(N'CREATE SCHEMA [pizza];');
    CREATE TABLE [pizza].[_EFMigrationHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK__EFMigrationHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241109035941_initial1.0'
)
BEGIN
    IF SCHEMA_ID(N'pizza') IS NULL EXEC(N'CREATE SCHEMA [pizza];');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241109035941_initial1.0'
)
BEGIN
    CREATE TABLE [pizza].[Pizzas] (
        [PizzaId] uniqueidentifier NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Tamaño] nvarchar(max) NOT NULL,
        [Descripcion] nvarchar(max) NOT NULL,
        [Precio] float NOT NULL,
        [Creado] datetime2 NOT NULL,
        [Update] datetime2 NULL,
        CONSTRAINT [PK_Pizzas] PRIMARY KEY ([PizzaId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241109035941_initial1.0'
)
BEGIN
    INSERT INTO [pizza].[_EFMigrationHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241109035941_initial1.0', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241111015619_initial1.1'
)
BEGIN
    ALTER TABLE [pizza].[Pizzas] ADD [ImagenUrl] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241111015619_initial1.1'
)
BEGIN
    INSERT INTO [pizza].[_EFMigrationHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111015619_initial1.1', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241114031057_initial1.2'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[pizza].[Pizzas]') AND [c].[name] = N'Tamaño');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [pizza].[Pizzas] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [pizza].[Pizzas] DROP COLUMN [Tamaño];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241114031057_initial1.2'
)
BEGIN
    ALTER TABLE [pizza].[Pizzas] ADD [TamanioPizzaId] uniqueidentifier NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241114031057_initial1.2'
)
BEGIN
    CREATE TABLE [pizza].[TamanioPizzas] (
        [TamanioPizzaId] uniqueidentifier NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Codigo] nvarchar(max) NOT NULL,
        [Creado] datetime2 NOT NULL,
        [Update] datetime2 NULL,
        CONSTRAINT [PK_TamanioPizzas] PRIMARY KEY ([TamanioPizzaId])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241114031057_initial1.2'
)
BEGIN
    CREATE INDEX [IX_Pizzas_TamanioPizzaId] ON [pizza].[Pizzas] ([TamanioPizzaId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241114031057_initial1.2'
)
BEGIN
    ALTER TABLE [pizza].[Pizzas] ADD CONSTRAINT [FK_Pizzas_TamanioPizzas_TamanioPizzaId] FOREIGN KEY ([TamanioPizzaId]) REFERENCES [pizza].[TamanioPizzas] ([TamanioPizzaId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241114031057_initial1.2'
)
BEGIN
    INSERT INTO [pizza].[_EFMigrationHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241114031057_initial1.2', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE TABLE [pizza].[AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Descripcion] nvarchar(max) NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE TABLE [pizza].[AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE TABLE [pizza].[AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [pizza].[AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE TABLE [pizza].[AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [pizza].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE TABLE [pizza].[AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [pizza].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE TABLE [pizza].[AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [pizza].[AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [pizza].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE TABLE [pizza].[AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [pizza].[AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [pizza].[AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [pizza].[AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [pizza].[AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [pizza].[AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [pizza].[AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [pizza].[AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [pizza].[AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241115045704_initial1.3'
)
BEGIN
    INSERT INTO [pizza].[_EFMigrationHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241115045704_initial1.3', N'8.0.10');
END;
GO

COMMIT;
GO

