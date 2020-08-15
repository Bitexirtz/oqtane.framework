CREATE TABLE [dbo].[ItmShift]
(
	[ShiftId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
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

CREATE TABLE [dbo].[ItmWork]
(
	[WorkId] [int] IDENTITY(1,1) NOT NULL,
	[DailyWorkId] [int] NOT NULL,
	[ShiftId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[RegularMh] [int] NOT NULL,
	[OvertimeMh] [int],
	CONSTRAINT [PK_ItmWork] PRIMARY KEY CLUSTERED
	(
		[WorkId] ASC
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
	[ModuleId] [int] NOT NULL,
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

CREATE TABLE [dbo].[ItmDailyWork]
(
	[DailyWorkId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[ShiftId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
	CONSTRAINT [PK_ItmDailyWork] PRIMARY KEY CLUSTERED
	(
		[DailyWorkId] ASC
	)
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[ItmDailyWork]  WITH CHECK ADD  CONSTRAINT [FK_ItmDailyWork_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([ModuleId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmProcess]  WITH CHECK ADD  CONSTRAINT [FK_ItmProcess_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([ModuleId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmShift]  WITH CHECK ADD  CONSTRAINT [FK_ItmShift_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].[Module] ([ModuleId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmDailyWork] WITH CHECK ADD  CONSTRAINT [FK_ItmDailyWork_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmWork] WITH CHECK ADD  CONSTRAINT [FK_ItmWork_ItmShift] FOREIGN KEY([ShiftId])
REFERENCES [dbo].[ItmShift] ([ShiftId])
ON DELETE NO ACTION
GO

ALTER TABLE [dbo].[ItmWork] WITH CHECK ADD  CONSTRAINT [FK_ItmWork_ItmDailyWork] FOREIGN KEY([DailyWorkId])
REFERENCES [dbo].[ItmDailyWork] ([DailyWorkId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[ItmWork] WITH CHECK ADD  CONSTRAINT [FK_ItmWork_ItmProject] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[ItmProject] ([ProjectId])
ON DELETE CASCADE
GO