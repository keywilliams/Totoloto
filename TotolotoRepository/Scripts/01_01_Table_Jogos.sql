USE [Totoloto]
GO

/****** Object:  Table [dbo].[Jogos]    Script Date: 21/09/2023 22:39:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Jogos](
	[IdJogo] [int] IDENTITY(1,1) NOT NULL,
	[Jogo] [int] NOT NULL,
	[Data] [datetime] NOT NULL,
	[Numero1] [int] NOT NULL,
	[Numero2] [int] NOT NULL,
	[Numero3] [int] NOT NULL,
	[Numero4] [int] NOT NULL,
	[Numero5] [int] NOT NULL,
	[NumeroSorte] [int] NOT NULL,
 CONSTRAINT [PK_Jogos] PRIMARY KEY CLUSTERED 
(
	[IdJogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


