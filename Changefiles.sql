BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[files]') AND [c].[name] = N'SizeFile');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [files] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [files] ALTER COLUMN [SizeFile] bigint NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210509130223_ChangeFile', N'5.0.3');
GO

COMMIT;
GO

