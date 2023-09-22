USE [Totoloto]
GO

/****** Object:  Table [dbo].[Jogos]    Script Date: 22/09/2023 18:47:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Jogos](
	[IdJogo] [int] IDENTITY(1,1) NOT NULL,
	[NumeroJogo] [int] NOT NULL,
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

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_Jogos_Numeros1] FOREIGN KEY([Numero1])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_Jogos_Numeros1]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_Jogos_Numeros2] FOREIGN KEY([Numero2])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_Jogos_Numeros2]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_Jogos_Numeros3] FOREIGN KEY([Numero3])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_Jogos_Numeros3]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_Jogos_Numeros4] FOREIGN KEY([Numero4])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_Jogos_Numeros4]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_Jogos_Numeros5] FOREIGN KEY([Numero5])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_Jogos_Numeros5]
GO

ALTER TABLE [dbo].[Jogos]  WITH CHECK ADD  CONSTRAINT [FK_Jogos_NumerosDaSorte] FOREIGN KEY([NumeroSorte])
REFERENCES [dbo].[NumerosDaSorte] ([Numero])
GO

ALTER TABLE [dbo].[Jogos] CHECK CONSTRAINT [FK_Jogos_NumerosDaSorte]
GO


