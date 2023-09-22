USE [Totoloto]
GO

/****** Object:  Table [dbo].[Colunas]    Script Date: 22/09/2023 18:39:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Colunas](
	[NumeroColuna] [int] NOT NULL,
	[Numero] [int] NOT NULL,
 CONSTRAINT [PK_Colunas] PRIMARY KEY CLUSTERED 
(
	[NumeroColuna] ASC,
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Colunas]  WITH CHECK ADD  CONSTRAINT [FK_Colunas_Colunas] FOREIGN KEY([Numero])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO

ALTER TABLE [dbo].[Colunas] CHECK CONSTRAINT [FK_Colunas_Colunas]
GO


