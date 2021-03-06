USE [dbTareas]
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 17/04/2019 08:45:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[TareaID] [int] IDENTITY(1,1) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Estado] [bit] NOT NULL,
	[FechaVencimiento] [datetime] NOT NULL,
	[AutorTareaID] [int] NOT NULL,
 CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED 
(
	[TareaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/04/2019 08:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Roles] [nvarchar](200) NULL,
	[Nombres] [nvarchar](50) NULL,
	[Apellidos] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Tarea] ON 

GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (6, CAST(N'2019-04-15 06:30:38.167' AS DateTime), N'Tarea 921af581-8', 0, CAST(N'2019-04-17 06:30:38.167' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (7, CAST(N'2019-04-15 06:30:46.147' AS DateTime), N'Implementar web services', 1, CAST(N'2019-04-19 07:25:03.283' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (8, CAST(N'2019-04-15 06:30:54.403' AS DateTime), N'Tarea 3519431d-8', 0, CAST(N'2019-04-17 06:30:54.403' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (9, CAST(N'2019-04-16 19:26:35.143' AS DateTime), N'Tarea 064ef582-e', 0, CAST(N'2019-04-18 19:26:35.143' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (11, CAST(N'2019-04-16 21:00:12.193' AS DateTime), N'Tarea 607cb2b2-c', 0, CAST(N'2019-04-18 21:00:12.193' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (15, CAST(N'2019-04-16 22:11:25.460' AS DateTime), N'Tarea aeab1bd1-a', 0, CAST(N'2019-04-18 22:11:25.460' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (17, CAST(N'2019-04-16 22:16:59.347' AS DateTime), N'Tarea 5ae96c3d-3', 0, CAST(N'2019-04-18 22:16:59.347' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (19, CAST(N'2019-04-16 22:17:34.167' AS DateTime), N'Tarea 2ebc7f4c-0', 0, CAST(N'2019-04-18 22:17:34.167' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (21, CAST(N'2019-04-16 23:49:51.867' AS DateTime), N'Tarea 3412c009-3', 0, CAST(N'2019-04-18 23:49:51.867' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (23, CAST(N'2019-04-17 00:09:54.460' AS DateTime), N'Tarea caa414a7-8', 0, CAST(N'2019-04-19 00:09:54.460' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (25, CAST(N'2019-04-17 00:10:07.977' AS DateTime), N'Tarea 902ee8db-f', 0, CAST(N'2019-04-19 00:10:07.977' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (27, CAST(N'2019-04-17 00:10:33.853' AS DateTime), N'Tarea e7f2fac5-8', 0, CAST(N'2019-04-19 00:10:33.853' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (29, CAST(N'2019-04-17 00:36:26.300' AS DateTime), N'Tarea 4179db2b-0', 0, CAST(N'2019-04-19 00:36:26.300' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (31, CAST(N'2019-04-17 00:36:54.787' AS DateTime), N'Tarea 6112c3b8-2', 0, CAST(N'2019-04-19 00:36:54.787' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (33, CAST(N'2019-04-17 06:38:56.210' AS DateTime), N'Tarea 347d97e6-1', 0, CAST(N'2019-04-19 06:38:56.210' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (35, CAST(N'2019-04-17 07:09:34.483' AS DateTime), N'Tarea dbb2417f-a', 0, CAST(N'2019-04-19 07:09:34.483' AS DateTime), 1)
GO
INSERT [dbo].[Tarea] ([TareaID], [FechaCreacion], [Descripcion], [Estado], [FechaVencimiento], [AutorTareaID]) VALUES (37, CAST(N'2019-04-17 07:25:03.927' AS DateTime), N'Tarea b5e5a032-7', 0, CAST(N'2019-04-19 07:25:03.927' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Tarea] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([UsuarioID], [Login], [Password], [Roles], [Nombres], [Apellidos], [Email]) VALUES (1, N'user1', N'user1', N'Administrador', N'Javier', N'Tunoque', N'javiertuga@gmail.com')
GO
INSERT [dbo].[Usuario] ([UsuarioID], [Login], [Password], [Roles], [Nombres], [Apellidos], [Email]) VALUES (2, N'user2', N'user2', N'Administrador', N'Pedro', N'Diaz', N'pedrodiaz@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Tarea]  WITH CHECK ADD  CONSTRAINT [FK_Tarea_Usuario] FOREIGN KEY([AutorTareaID])
REFERENCES [dbo].[Usuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[Tarea] CHECK CONSTRAINT [FK_Tarea_Usuario]
GO
