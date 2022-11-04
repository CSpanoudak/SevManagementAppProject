USE [SevDB]
GO
/****** Object:  Table [dbo].[COURSES]    Script Date: 4/11/2022 3:57:41 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COURSES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](max) NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
	[TEACHER_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[COURSES]  WITH CHECK ADD  CONSTRAINT [FK_Table_ToTEACHERS] FOREIGN KEY([TEACHER_ID])
REFERENCES [dbo].[TEACHERS] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[COURSES] CHECK CONSTRAINT [FK_Table_ToTEACHERS]
GO
