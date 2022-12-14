USE [JMCOL]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 10/13/2022 6:30:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdColegio] [int] NULL,
	[IdMateria] [int] NULL,
	[IdUsuario] [int] NULL,
	[Calificacion] [decimal](2, 0) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colegio]    Script Date: 10/13/2022 6:30:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colegio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](250) NULL,
	[TipoColegio] [varchar](64) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 10/13/2022 6:30:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdColegio] [int] NULL,
	[Nombre] [varchar](256) NULL,
	[Area] [varchar](128) NULL,
	[NumeroEstudiantes] [int] NULL,
	[DocenteAsignado] [varchar](512) NULL,
	[Curso] [varchar](64) NULL,
	[Paralelo] [varchar](16) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/13/2022 6:30:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](256) NULL,
	[Username] [varchar](128) NULL,
	[Password] [varchar](128) NULL,
	[correoElectronico] [varchar](256) NULL,
	[rol] [varchar](32) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Calificaciones] ON 

INSERT [dbo].[Calificaciones] ([Id], [IdColegio], [IdMateria], [IdUsuario], [Calificacion], [Estado]) VALUES (1, 1, 1, 1, CAST(8 AS Decimal(2, 0)), 0)
SET IDENTITY_INSERT [dbo].[Calificaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Colegio] ON 

INSERT [dbo].[Colegio] ([Id], [Nombre], [TipoColegio], [Estado]) VALUES (1, N'Benito Juárez', N'Público', 1)
SET IDENTITY_INSERT [dbo].[Colegio] OFF
GO
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([Id], [IdColegio], [Nombre], [Area], [NumeroEstudiantes], [DocenteAsignado], [Curso], [Paralelo], [Estado]) VALUES (1, 1, N'Matemática', N'Matemática', 30, N'Roberto M', N'Primero', N'A', 0)
SET IDENTITY_INSERT [dbo].[Materia] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [NombreCompleto], [Username], [Password], [correoElectronico], [rol], [Estado]) VALUES (1, N'Jefferson Montero', N'Jeff', N'jeff123', N'jm@gmail.com', N'Administrador', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Colegio__75E3EFCF023D5A04]    Script Date: 10/13/2022 6:30:58 PM ******/
ALTER TABLE [dbo].[Colegio] ADD UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Materia__75E3EFCF08EA5793]    Script Date: 10/13/2022 6:30:58 PM ******/
ALTER TABLE [dbo].[Materia] ADD UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__536C85E41CF15040]    Script Date: 10/13/2022 6:30:58 PM ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([IdColegio])
REFERENCES [dbo].[Colegio] ([Id])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[Materia] ([Id])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD FOREIGN KEY([IdColegio])
REFERENCES [dbo].[Colegio] ([Id])
GO
