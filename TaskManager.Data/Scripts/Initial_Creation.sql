IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Employees] (
    [EmployeeId] int NOT NULL IDENTITY,
    [Name] nvarchar(500) NULL,
    [UserName] nvarchar(50) NULL,
    [Password] nvarchar(50) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeId])
);

GO

CREATE TABLE [Projects] (
    [ProjectId] int NOT NULL IDENTITY,
    [Name] nvarchar(500) NULL,
    CONSTRAINT [PK_Projects] PRIMARY KEY ([ProjectId])
);

GO

CREATE TABLE [TaskStatuses] (
    [TaskStatusId] int NOT NULL,
    [Name] nvarchar(100) NULL,
    CONSTRAINT [PK_TaskStatuses] PRIMARY KEY ([TaskStatusId])
);

GO

CREATE TABLE [EmployeeTasks] (
    [EmployeeTaskId] int NOT NULL IDENTITY,
    [TaskTitle] nvarchar(100) NULL,
    [Description] nvarchar(1000) NULL,
    [StartDate] datetime2 NOT NULL,
    [ExpectedDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    [ProjectId] int NULL,
    [TaskStatusId] int NULL,
    [EmployeeId] int NULL,
    CONSTRAINT [PK_EmployeeTasks] PRIMARY KEY ([EmployeeTaskId]),
    CONSTRAINT [FK_EmployeeTasks_Employees_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees] ([EmployeeId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmployeeTasks_Projects_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EmployeeTasks_TaskStatuses_TaskStatusId] FOREIGN KEY ([TaskStatusId]) REFERENCES [TaskStatuses] ([TaskStatusId]) ON DELETE NO ACTION
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'Name', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] ON;
INSERT INTO [Employees] ([EmployeeId], [Name], [Password], [UserName])
VALUES (1, N'Employee 1', N'1234', N'user1'),
(2, N'Employee 2', N'1234', N'user2'),
(3, N'Employee 3', N'1234', N'user3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'EmployeeId', N'Name', N'Password', N'UserName') AND [object_id] = OBJECT_ID(N'[Employees]'))
    SET IDENTITY_INSERT [Employees] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProjectId', N'Name') AND [object_id] = OBJECT_ID(N'[Projects]'))
    SET IDENTITY_INSERT [Projects] ON;
INSERT INTO [Projects] ([ProjectId], [Name])
VALUES (1, N'Testing Project 1'),
(2, N'Testing Project 2'),
(3, N'Testing Project 3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProjectId', N'Name') AND [object_id] = OBJECT_ID(N'[Projects]'))
    SET IDENTITY_INSERT [Projects] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TaskStatusId', N'Name') AND [object_id] = OBJECT_ID(N'[TaskStatuses]'))
    SET IDENTITY_INSERT [TaskStatuses] ON;
INSERT INTO [TaskStatuses] ([TaskStatusId], [Name])
VALUES (1, N'In Progress'),
(2, N'Completed');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TaskStatusId', N'Name') AND [object_id] = OBJECT_ID(N'[TaskStatuses]'))
    SET IDENTITY_INSERT [TaskStatuses] OFF;

GO

CREATE INDEX [IX_EmployeeTasks_EmployeeId] ON [EmployeeTasks] ([EmployeeId]);

GO

CREATE INDEX [IX_EmployeeTasks_ProjectId] ON [EmployeeTasks] ([ProjectId]);

GO

CREATE INDEX [IX_EmployeeTasks_TaskStatusId] ON [EmployeeTasks] ([TaskStatusId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200121220055_Initial_Creation', N'3.1.0');

GO

