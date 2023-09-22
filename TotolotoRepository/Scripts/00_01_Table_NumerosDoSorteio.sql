USE [Totoloto]
GO

/****** Object:  Table [dbo].[NumerosDoSorteio]    Script Date: 22/09/2023 18:36:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NumerosDoSorteio](
	[Numero] [int] NOT NULL,
	[Par] [bit] NOT NULL,
	[Impar] [bit] NOT NULL,
	[Borda] [bit] NOT NULL,
	[Miolo] [bit] NOT NULL,
	[DiagonalDireita] [bit] NOT NULL,
	[DiagonalEsquerda] [bit] NOT NULL,
 CONSTRAINT [PK_Numeros] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


