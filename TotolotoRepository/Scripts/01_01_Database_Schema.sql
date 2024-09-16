USE [master]
GO
/****** Object:  Database [Totoloto]    Script Date: 16/09/2024 22:32:10 ******/
CREATE DATABASE [Totoloto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Totoloto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Totoloto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Totoloto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Totoloto_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Totoloto] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Totoloto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Totoloto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Totoloto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Totoloto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Totoloto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Totoloto] SET ARITHABORT OFF 
GO
ALTER DATABASE [Totoloto] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Totoloto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Totoloto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Totoloto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Totoloto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Totoloto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Totoloto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Totoloto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Totoloto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Totoloto] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Totoloto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Totoloto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Totoloto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Totoloto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Totoloto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Totoloto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Totoloto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Totoloto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Totoloto] SET  MULTI_USER 
GO
ALTER DATABASE [Totoloto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Totoloto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Totoloto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Totoloto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Totoloto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Totoloto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Totoloto] SET QUERY_STORE = ON
GO
ALTER DATABASE [Totoloto] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Totoloto]
GO
/****** Object:  Table [dbo].[Colunas]    Script Date: 16/09/2024 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colunas](
	[Numero] [int] NOT NULL,
	[NumeroColuna] [int] NOT NULL,
 CONSTRAINT [PK_Colunas_1] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstatisticasNumerosDaSorte]    Script Date: 16/09/2024 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatisticasNumerosDaSorte](
	[Numero] [int] NOT NULL,
	[Sorteado] [int] NOT NULL,
	[AtrasoMaximo] [int] NOT NULL,
	[AtrasoAtual] [int] NOT NULL,
	[MaiorSequencia] [int] NOT NULL,
	[SequenciaAtual] [int] NOT NULL,
 CONSTRAINT [PK_EstatisticasNumerosDaSorte] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstatisticasNumerosDoSorteio]    Script Date: 16/09/2024 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatisticasNumerosDoSorteio](
	[Numero] [int] NOT NULL,
	[Sorteado] [int] NOT NULL,
	[AtrasoMaximo] [int] NOT NULL,
	[AtrasoAtual] [int] NOT NULL,
	[MaiorSequencia] [int] NOT NULL,
	[SequenciaAtual] [int] NOT NULL,
 CONSTRAINT [PK_EstatisticasNumerosDoSorteio] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstatisticasNumerosUltimaData]    Script Date: 16/09/2024 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatisticasNumerosUltimaData](
	[Tabela] [varchar](50) NOT NULL,
	[Data] [datetime] NOT NULL,
 CONSTRAINT [PK_EstatisticasNumerosUltimaData_1] PRIMARY KEY CLUSTERED 
(
	[Tabela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jogos]    Script Date: 16/09/2024 22:32:10 ******/
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
/****** Object:  Table [dbo].[Linhas]    Script Date: 16/09/2024 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Linhas](
	[Numero] [int] NOT NULL,
	[NumeroLinha] [int] NOT NULL,
 CONSTRAINT [PK_Linhas_1] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NumerosDaSorte]    Script Date: 16/09/2024 22:32:10 ******/
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
/****** Object:  Table [dbo].[NumerosDoSorteio]    Script Date: 16/09/2024 22:32:10 ******/
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
	[Linha] [int] NOT NULL,
	[Coluna] [int] NOT NULL,
 CONSTRAINT [PK_Numeros] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SequenciaNumerosDaSorte]    Script Date: 16/09/2024 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SequenciaNumerosDaSorte](
	[Numero] [int] NOT NULL,
	[NumeroAnterior] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
 CONSTRAINT [PK_SequenciaNumerosDaSorte] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC,
	[NumeroAnterior] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SequenciaNumerosDoSorteio]    Script Date: 16/09/2024 22:32:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SequenciaNumerosDoSorteio](
	[Numero] [int] NOT NULL,
	[NumeroMesmoJogo] [int] NOT NULL,
	[Quantidade] [int] NOT NULL,
 CONSTRAINT [PK_SequenciaNumerosDoSorteio] PRIMARY KEY CLUSTERED 
(
	[Numero] ASC,
	[NumeroMesmoJogo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Colunas]  WITH CHECK ADD  CONSTRAINT [FK_Colunas_Colunas] FOREIGN KEY([Numero])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO
ALTER TABLE [dbo].[Colunas] CHECK CONSTRAINT [FK_Colunas_Colunas]
GO
ALTER TABLE [dbo].[EstatisticasNumerosDaSorte]  WITH CHECK ADD  CONSTRAINT [FK_EstatisticasNumerosDaSorte_NumerosDaSorte] FOREIGN KEY([Numero])
REFERENCES [dbo].[NumerosDaSorte] ([Numero])
GO
ALTER TABLE [dbo].[EstatisticasNumerosDaSorte] CHECK CONSTRAINT [FK_EstatisticasNumerosDaSorte_NumerosDaSorte]
GO
ALTER TABLE [dbo].[EstatisticasNumerosDoSorteio]  WITH CHECK ADD  CONSTRAINT [FK_EstatisticasNumerosDoSorteio_NumerosDoSorteio] FOREIGN KEY([Numero])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO
ALTER TABLE [dbo].[EstatisticasNumerosDoSorteio] CHECK CONSTRAINT [FK_EstatisticasNumerosDoSorteio_NumerosDoSorteio]
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
ALTER TABLE [dbo].[Linhas]  WITH CHECK ADD  CONSTRAINT [FK_Linhas_Numeros] FOREIGN KEY([Numero])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO
ALTER TABLE [dbo].[Linhas] CHECK CONSTRAINT [FK_Linhas_Numeros]
GO
ALTER TABLE [dbo].[SequenciaNumerosDaSorte]  WITH CHECK ADD  CONSTRAINT [FK_SequenciaNumerosDaSorte_NumerosDaSorte] FOREIGN KEY([Numero])
REFERENCES [dbo].[NumerosDaSorte] ([Numero])
GO
ALTER TABLE [dbo].[SequenciaNumerosDaSorte] CHECK CONSTRAINT [FK_SequenciaNumerosDaSorte_NumerosDaSorte]
GO
ALTER TABLE [dbo].[SequenciaNumerosDaSorte]  WITH CHECK ADD  CONSTRAINT [FK_SequenciaNumerosDaSorte_NumerosDaSorte1] FOREIGN KEY([NumeroAnterior])
REFERENCES [dbo].[NumerosDaSorte] ([Numero])
GO
ALTER TABLE [dbo].[SequenciaNumerosDaSorte] CHECK CONSTRAINT [FK_SequenciaNumerosDaSorte_NumerosDaSorte1]
GO
ALTER TABLE [dbo].[SequenciaNumerosDoSorteio]  WITH CHECK ADD  CONSTRAINT [FK_SequenciaNumerosDoSorteio_NumerosDoSorteio] FOREIGN KEY([Numero])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO
ALTER TABLE [dbo].[SequenciaNumerosDoSorteio] CHECK CONSTRAINT [FK_SequenciaNumerosDoSorteio_NumerosDoSorteio]
GO
ALTER TABLE [dbo].[SequenciaNumerosDoSorteio]  WITH CHECK ADD  CONSTRAINT [FK_SequenciaNumerosDoSorteio_NumerosDoSorteio1] FOREIGN KEY([NumeroMesmoJogo])
REFERENCES [dbo].[NumerosDoSorteio] ([Numero])
GO
ALTER TABLE [dbo].[SequenciaNumerosDoSorteio] CHECK CONSTRAINT [FK_SequenciaNumerosDoSorteio_NumerosDoSorteio1]
GO
USE [master]
GO
ALTER DATABASE [Totoloto] SET  READ_WRITE 
GO
