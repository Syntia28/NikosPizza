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

