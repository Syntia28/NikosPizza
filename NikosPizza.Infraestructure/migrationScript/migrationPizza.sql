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
    WHERE [MigrationId] = N'20241111050838_initial1.2'
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
    WHERE [MigrationId] = N'20241111050838_initial1.2'
)
BEGIN
    ALTER TABLE [pizza].[Pizzas] ADD [TamanioPizzaId] uniqueidentifier NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241111050838_initial1.2'
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
    WHERE [MigrationId] = N'20241111050838_initial1.2'
)
BEGIN
    CREATE INDEX [IX_Pizzas_TamanioPizzaId] ON [pizza].[Pizzas] ([TamanioPizzaId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241111050838_initial1.2'
)
BEGIN
    ALTER TABLE [pizza].[Pizzas] ADD CONSTRAINT [FK_Pizzas_TamanioPizzas_TamanioPizzaId] FOREIGN KEY ([TamanioPizzaId]) REFERENCES [pizza].[TamanioPizzas] ([TamanioPizzaId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [pizza].[_EFMigrationHistory]
    WHERE [MigrationId] = N'20241111050838_initial1.2'
)
BEGIN
    INSERT INTO [pizza].[_EFMigrationHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241111050838_initial1.2', N'8.0.10');
END;
GO

COMMIT;
GO

