USE [CasoPrac3]
GO
/****** Object:  Table [dbo].[Autos]    Script Date: 07/10/2023 10:56:12 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autos](
	[ID_Auto] [uniqueidentifier] NOT NULL,
	[Marca] [varchar](50) NULL,
	[Modelo] [varchar](50) NULL,
	[anio_Fabricacion] [varchar](50) NULL,
	[Precio] [decimal](18, 2) NULL,
	[Color] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.Autos] PRIMARY KEY CLUSTERED 
(
	[ID_Auto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Autos] ADD  CONSTRAINT [DF_Autos_ID_Auto]  DEFAULT (newid()) FOR [ID_Auto]
GO
