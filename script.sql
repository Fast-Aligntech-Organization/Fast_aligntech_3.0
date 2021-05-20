BEGIN TRANSACTION;
GO

ALTER TABLE [usuarios] ADD [GoogleUUID] uniqueidentifier NULL;
GO

ALTER TABLE [files] ADD [Extencion] nvarchar(max) NULL;
GO

ALTER TABLE [files] ADD [FileName] nvarchar(max) NULL;
GO

ALTER TABLE [files] ADD [SizeFile] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210331010249_GoogleSessionIntegration', N'5.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [usuarios] ADD [Role] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210331053146_AgregarRoles', N'5.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210504190318_files', N'5.0.3');
GO

COMMIT;
GO

