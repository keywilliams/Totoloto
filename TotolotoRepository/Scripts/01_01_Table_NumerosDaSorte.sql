USE [Totoloto]
GO

/****** Object:  Table [dbo].[NumerosDaSorte]    Script Date: 22/09/2023 18:38:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NumerosDaSorte](
	[Numero] [int] NOT NULL,
	[Par] [bit] NOT NULL,
	[Impar] [bit] NOT NULL,
 CONSTRAINT [PK_NumerosDaSorte] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


