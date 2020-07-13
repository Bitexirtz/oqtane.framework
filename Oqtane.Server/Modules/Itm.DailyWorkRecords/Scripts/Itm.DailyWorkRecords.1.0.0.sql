/*  
Create Itm Daily Work Record tables
*/

CREATE TABLE [dbo].[ItmDailyWorkRecord]
(
	[DailyWorkRecordId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[ShiftId] [int] NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	CONSTRAINT [PK_ItmDailyWorkRecord] PRIMARY KEY CLUSTERED
	(
		[DailyWorkRecordId] ASC
	)
)
GO

CREATE TABLE [dbo].[ItmShift]
(
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar] (256) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Description] [nvarchar] (256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	CONSTRAINT [PK_ItmShift] PRIMARY KEY CLUSTERED
	(
		[ShiftId] ASC
	)
)
GO

CREATE TABLE [dbo].[ItmTask]
(
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[DailyWorkRecordId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[RegularMh] [int] NOT NULL,
	[OvertimeMh] [int],
	CONSTRAINT [PK_ItmTask] PRIMARY KEY CLUSTERED
	(
		[TaskId] ASC
	)
)
GO

CREATE TABLE [dbo].[ItmProject]
(
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](256) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	CONSTRAINT [PK_ItmProject] PRIMARY KEY CLUSTERED
	(
		[ProjectId] ASC
	)
)
GO

CREATE TABLE [dbo].[ItmProcess] 
(
	[ProcessId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar] (256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	CONSTRAINT [PK_ItmProcess] PRIMARY KEY CLUSTERED
	(
		[ProcessId] ASC
	)
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[ItmDailyWorkRecord]  WITH CHECK ADD  CONSTRAINT [FK_ItmDailyWorkRecord_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([ModuleId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmDailyWorkRecord] WITH CHECK ADD  CONSTRAINT [FK_ItmDailyWorkRecord_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmWork] WITH CHECK ADD  CONSTRAINT [FK_ItmWork_ItmShift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[ItmShift] ([ShiftId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmTask] WITH CHECK ADD  CONSTRAINT [FK_ItmTask_ItmDailyWorkRecord] FOREIGN KEY([DailyWorkRecordId])
REFERENCES [dbo].[ItmDailyWorkRecord] ([DailyWorkRecordId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmTask] WITH CHECK ADD  CONSTRAINT [FK_ItmTask_ItmProject] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ItmProject] ([ProjectId])
ON DELETE CASCADE
GO
