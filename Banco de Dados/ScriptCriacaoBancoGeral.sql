USE [master]
GO
/****** Object:  Database [TocaLivrosDB]    Script Date: 19/01/2016 22:59:28 ******/
CREATE DATABASE [TocaLivrosDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TOCALIVROS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TOCALIVROS.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TOCALIVROS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TOCALIVROS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TocaLivrosDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TocaLivrosDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TocaLivrosDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TocaLivrosDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TocaLivrosDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TocaLivrosDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TocaLivrosDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TocaLivrosDB] SET  MULTI_USER 
GO
ALTER DATABASE [TocaLivrosDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TocaLivrosDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TocaLivrosDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TocaLivrosDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TocaLivrosDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TocaLivrosDB', N'ON'
GO
USE [TocaLivrosDB]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[CategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](30) NOT NULL,
	[DtDesativacao] [smalldatetime] NULL,
	[DtInclusao] [smalldatetime] NULL,
	[DtAlteracao] [smalldatetime] NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_NOME] UNIQUE NONCLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[CodCliID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CPF] [varchar](11) NULL,
	[DtNascimento] [smalldatetime] NULL,
	[Sexo] [char](1) NULL,
	[Telefone] [varchar](10) NULL,
	[Celular] [varchar](11) NULL,
	[Email] [varchar](100) NULL,
	[DataDesativacao] [smalldatetime] NULL,
	[DataInclusao] [smalldatetime] NULL,
	[DtAlteracao] [smalldatetime] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[CodCliID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_CPF] UNIQUE NONCLUSTERED 
(
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PEDIDOS]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PEDIDOS](
	[CodPedidoID] [int] IDENTITY(1,1) NOT NULL,
	[CodCliID] [int] NOT NULL,
	[CodProdID] [int] NOT NULL,
	[DtCompra] [datetime] NOT NULL,
	[DtCancelado] [datetime] NULL,
	[Obs] [varchar](max) NULL,
	[DtInclusao] [smalldatetime] NULL,
	[DtAlteracao] [smalldatetime] NULL,
 CONSTRAINT [PK_PEDIDOS_1] PRIMARY KEY CLUSTERED 
(
	[CodPedidoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PRODUTOS]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PRODUTOS](
	[CodProdID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](30) NOT NULL,
	[ISBN] [varchar](20) NULL,
	[Paginas] [int] NULL,
	[Edicao] [int] NULL,
	[Editora] [varchar](30) NULL,
	[AnoLanca] [int] NULL,
	[CategoriaID] [int] NOT NULL,
	[Idioma] [varchar](1) NULL,
	[Sinopse] [varchar](max) NULL,
	[DtDesativacao] [smalldatetime] NULL,
	[DtInclusao] [smalldatetime] NULL,
	[DtAlteracao] [smalldatetime] NULL,
	[Preco] [decimal](10, 2) NULL,
 CONSTRAINT [PK_PRODUTOS] PRIMARY KEY CLUSTERED 
(
	[CodProdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_ISBN] UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PEDIDOS]  WITH CHECK ADD  CONSTRAINT [FK_PEDIDOS_CLIENTES] FOREIGN KEY([CodCliID])
REFERENCES [dbo].[CLIENTES] ([CodCliID])
GO
ALTER TABLE [dbo].[PEDIDOS] CHECK CONSTRAINT [FK_PEDIDOS_CLIENTES]
GO
ALTER TABLE [dbo].[PEDIDOS]  WITH CHECK ADD  CONSTRAINT [FK_PEDIDOS_PRODUTOS] FOREIGN KEY([CodProdID])
REFERENCES [dbo].[PRODUTOS] ([CodProdID])
GO
ALTER TABLE [dbo].[PEDIDOS] CHECK CONSTRAINT [FK_PEDIDOS_PRODUTOS]
GO
ALTER TABLE [dbo].[PRODUTOS]  WITH CHECK ADD  CONSTRAINT [FK_PRODUTOS_CATEGORIAS] FOREIGN KEY([CategoriaID])
REFERENCES [dbo].[CATEGORIAS] ([CategoriaID])
GO
ALTER TABLE [dbo].[PRODUTOS] CHECK CONSTRAINT [FK_PRODUTOS_CATEGORIAS]
GO
/****** Object:  StoredProcedure [dbo].[CATEGORIAS_ALTERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para INCLUIR de registro da tabela CATEGORIAS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CATEGORIAS_ALTERAR]
	@PAR_CategoriaID	INT,
	@PAR_Nome			varchar(30),
	@PAR_DtDesativacao	smalldatetime

	AS
	BEGIN

	UPDATE CATEGORIAS
	SET 
		Nome			= @PAR_Nome,
		DtDesativacao	= @PAR_DtDesativacao,
		DtAlteracao		= GETDATE()
	WHERE
		CategoriaID = @PAR_CategoriaID
END


GO
/****** Object:  StoredProcedure [dbo].[CATEGORIAS_CONSULTAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para CONSULTAR de registro da tabela CATEGORIAS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CATEGORIAS_CONSULTAR]
AS
	BEGIN
	SELECT
		CategoriaID		AS [Código],
		Nome,
		DtDesativacao	as [Data Desativação]
	FROM CATEGORIAS WITH(NOLOCK)
END
GO
/****** Object:  StoredProcedure [dbo].[CATEGORIAS_EXCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para _EXCLUIR de registro da tabela CATEGORIAS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CATEGORIAS_EXCLUIR]
	@PAR_CategoriaID	INT
AS
	BEGIN
	DELETE FROM CATEGORIAS
	WHERE
		CategoriaID = @PAR_CategoriaID
END
GO
/****** Object:  StoredProcedure [dbo].[CATEGORIAS_INCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para INCLUIR de registro da tabela CATEGORIAS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CATEGORIAS_INCLUIR]
	@PAR_Nome			varchar(30),
	@PAR_DtDesativacao	smalldatetime

	AS
	BEGIN

	INSERT INTO CATEGORIAS
	(
		Nome,
		DtDesativacao,
		DtInclusao
	)
	VALUES
	(
		@PAR_Nome,
		@PAR_DtDesativacao,
		GETDATE()
	)
	SELECT	max(CategoriaID) from CATEGORIAS With(nolock)
END


GO
/****** Object:  StoredProcedure [dbo].[CATEGORIAS_LISTA]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para LISTA de registro da tabela CATEGORIAS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 18/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CATEGORIAS_LISTA]
AS
	BEGIN
	SELECT
		CategoriaID		AS [Código],
		Nome
	FROM CATEGORIAS WITH(NOLOCK)
	WHERE
		DtDesativacao IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[CATEGORIAS_RECUPERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para RECUPERAR de registro da tabela CATEGORIAS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CATEGORIAS_RECUPERAR]
	@PAR_CategoriaID	INT
AS
	BEGIN
	SELECT
		Nome,
		DtDesativacao,
		DtInclusao,
		DtAlteracao
	FROM CATEGORIAS WITH(NOLOCK)
	WHERE
		CategoriaID = @PAR_CategoriaID
END
GO
/****** Object:  StoredProcedure [dbo].[CLIENTES_ALTERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para ALTERAR de registro da tabela CLIENTES. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CLIENTES_ALTERAR]
@PAR_CodCliID			int,
@PAR_Nome				varchar(100),
@PAR_CPF				VARCHAR(11),
@PAR_DtNascimento		smalldatetime,
@PAR_Sexo				char(1),
@PAR_Telefone			varchar(10),
@PAR_Celular			varchar(11),
@PAR_Email				varchar(100),
@PAR_DataDesativacao	smalldatetime

	AS
	BEGIN

	UPDATE CLIENTES
	SET 
			
	Nome			=	@PAR_Nome,				
	CPF				=	@PAR_CPF,
	DtNascimento	=	@PAR_DtNascimento,
	Sexo			=	@PAR_Sexo,
	Telefone		=	@PAR_Telefone,		
	Celular			=	@PAR_Celular,		
	Email			=	@PAR_Email,			
	DataDesativacao	=	@PAR_DataDesativacao,
	DtAlteracao		=	getdate()	
	WHERE
		CodCliID	=	@PAR_CodCliID
	END
GO
/****** Object:  StoredProcedure [dbo].[CLIENTES_CONSULTAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para RECUPERAR de registro da tabela CLIENTES. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CLIENTES_CONSULTAR]
AS
BEGIN
	SELECT
		CodCliID		AS [Código],
		Nome,
		CPF				AS [Número CPF],
		DtNascimento	AS [Data Nascimento],
		CASE 
			WHEN Sexo = 'M' THEN
				'Masculino'
			WHEN Sexo = 'F' THEN
				'Feminino'
			else
				'Outros'
		END				AS Sexo,
		Telefone,
		Celular,
		Email			AS [E-mail]
	FROM CLIENTES WITH(NOLOCK)
END
GO
/****** Object:  StoredProcedure [dbo].[CLIENTES_EXCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para _EXCLUIR de registro da tabela CLIENTES. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CLIENTES_EXCLUIR]
	@PAR_CodCliID	INT
AS
	BEGIN
	DELETE FROM CLIENTES
	WHERE
		CodCliID = @PAR_CodCliID
END
GO
/****** Object:  StoredProcedure [dbo].[CLIENTES_INCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para INCLUIR de registro da tabela CLIENTES. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CLIENTES_INCLUIR]
@PAR_Nome				varchar(100),
@PAR_CPF				VARCHAR(11),
@PAR_DtNascimento		smalldatetime,
@PAR_Sexo				char(1),
@PAR_Telefone			varchar(10),
@PAR_Celular			varchar(11),
@PAR_Email				varchar(100),
@PAR_DataDesativacao	smalldatetime

	AS
	BEGIN

	INSERT INTO CLIENTES
	(
		Nome,
		CPF,
		DtNascimento,
		Sexo,
		Telefone,
		Celular,
		Email,
		DataDesativacao,
		DataInclusao,
		DtAlteracao
	)
	VALUES
	(
	@PAR_Nome,			
	@PAR_CPF,
	@PAR_DtNascimento,	
	@PAR_Sexo,			
	@PAR_Telefone,		
	@PAR_Celular,		
	@PAR_Email,			
	@PAR_DataDesativacao,
	GETDATE(),
	NULL
	)

	SELECT	max(CodCliID) from CLIENTES With(nolock)
	END
GO
/****** Object:  StoredProcedure [dbo].[CLIENTES_LISTA]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para LISTA de registro da tabela CLIENTES. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 18/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CLIENTES_LISTA]
AS
	BEGIN
	SELECT
		CodCliID		AS [Código],
		Nome
	FROM CLIENTES WITH(NOLOCK)
	WHERE
	 DataDesativacao IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[CLIENTES_RECUPERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para RECUPERAR de registro da tabela CLIENTES. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[CLIENTES_RECUPERAR]
@PAR_CodCliID INT
AS
BEGIN
	SELECT
		
		Nome,
		CPF,
		DtNascimento,
		Sexo,
		Telefone,
		Celular,
		Email,
		DataDesativacao,
		DataInclusao,
		DtAlteracao
	FROM CLIENTES WITH(NOLOCK)
	WHERE
		CodCliID = @PAR_CodCliID
END
GO
/****** Object:  StoredProcedure [dbo].[PEDIDOS_ALTERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para INCLUIR de registro da tabela PEDIDOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 19/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PEDIDOS_ALTERAR]
@PAR_CodPedidoID	int,
@PAR_DtCancelado	DATETIME,
@PAR_Obs			VARCHAR(MAX)

	AS
	BEGIN

	UPDATE PEDIDOS
	SET 
		
		DtCancelado	= @PAR_DtCancelado,
		Obs			= @PAR_Obs,
		DtAlteracao = GETDate()
	WHERE
		CodPedidoID =	@PAR_CodPedidoID	

END


GO
/****** Object:  StoredProcedure [dbo].[PEDIDOS_CONSULTAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para CONSULTAR de registro da tabela PEDIDOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PEDIDOS_CONSULTAR]
AS
BEGIN
	SELECT
		PED.CodPedidoID		AS [Código],
		CLI.Nome			AS [Cliente],
		PROD.Titulo			AS [Produto],
		PED.DtCompra		As [Data da Compra],
		PED.DtCancelado		As	[Data do Cancelamento]
	FROM PEDIDOS AS PED WITH(NOLOCK) 
	INNER JOIN [CLIENTES] AS CLI WITH(NOLOCK)
	ON
		PED.[CodCliID] = CLI.[CodCliID]
	INNER JOIN [PRODUTOS] AS PROD WITH(NOLOCK)
	ON
		PED.CodProdID = PROD.CodProdID
END
GO
/****** Object:  StoredProcedure [dbo].[PEDIDOS_EXCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para _EXCLUIR de registro da tabela PEDIDOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PEDIDOS_EXCLUIR]
	@PAR_CodPedidoID	INT
AS
	BEGIN
	DELETE FROM PEDIDOS
	WHERE
		CodPedidoID = @PAR_CodPedidoID
END
GO
/****** Object:  StoredProcedure [dbo].[PEDIDOS_INCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para INCLUIR de registro da tabela PEDIDOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PEDIDOS_INCLUIR]
	@PAR_CodCliID		int,
	@PAR_CodProdID		int,
	@PAR_DtCompra		datetime,
	@PAR_DtCancelado	datetime,
	@PAR_Obs			varchar

	AS
	BEGIN

	INSERT INTO PEDIDOS
	(
		CodCliID,
		CodProdID,
		DtCompra,
		DtCancelado,
		Obs,
		DtInclusao
	)
	VALUES
	(
		@PAR_CodCliID,	
		@PAR_CodProdID,	
		@PAR_DtCompra,
		@PAR_DtCancelado,
		@PAR_Obs,
		GETDATE()
	)
	SELECT	max(CodPedidoID) from PEDIDOS With(nolock)
END


GO
/****** Object:  StoredProcedure [dbo].[PEDIDOS_RECUPERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para RECUPERAR de registro da tabela PEDIDOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PEDIDOS_RECUPERAR]
	@PAR_CodPedidoID	INT
AS
	BEGIN
	SELECT
		CodCliID,
		CodProdID,
		DtCompra,
		DtCancelado,
		Obs,
		DtInclusao,
		DtAlteracao
	FROM PEDIDOS WITH(NOLOCK)
	WHERE
		CodPedidoID = @PAR_CodPedidoID
END
GO
/****** Object:  StoredProcedure [dbo].[PRODUTOS_ALTERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para ALTERAR de registro da tabela PRODUTOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PRODUTOS_ALTERAR]
@PAR_CodProdID		INT,
@PAR_Titulo			varchar(30),
@PAR_ISBN			VARCHAR(20),
@PAR_Paginas		int,
@PAR_Edicao			int,
@PAR_Editora		varchar(30),
@PAR_AnoLanca		int,
@PAR_CategoriaID	int,
@PAR_Idioma			varchar(30),
@PAR_Sinopse		varchar(MAX),
@PAR_DtDesativacao	smalldatetime,
@PAR_Preco			decimal(10,2)

	AS
	BEGIN

	UPDATE PRODUTOS
	SET 
		Titulo		=	@PAR_Titulo,	
		ISBN		=	@PAR_ISBN,		
		Paginas		=	@PAR_Paginas,	
		Edicao		=	@PAR_Edicao,
		Editora		=	@PAR_Editora,		
		AnoLanca	=	@PAR_AnoLanca,		
		CategoriaID	=	@PAR_CategoriaID,
		Idioma		=	@PAR_Idioma	,		
		Sinopse		=	@PAR_Sinopse,		
		DtDesativacao	=	 @PAR_DtDesativacao,
		DtAlteracao		=	GETDATE(),
		Preco		=	@PAR_Preco
	WHERE
		CodProdID = @PAR_CodProdID
END		
	
GO
/****** Object:  StoredProcedure [dbo].[PRODUTOS_CONSULTAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para RECUPERAR de registro da tabela PRODUTOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PRODUTOS_CONSULTAR]
AS
	BEGIN
		SELECT
			CodProdID	as [Código],
			Titulo		as [Título],
			ISBN,
			Paginas		as	[Páginas],
			Edicao		as	[Edição],
			Editora,
			AnoLanca	as [Ano Lançamento],
			Preco		as [Preço]
		
		FROM PRODUTOS WITH(NOLOCK)
END
GO
/****** Object:  StoredProcedure [dbo].[PRODUTOS_EXCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para _EXCLUIR de registro da tabela PRODUTOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PRODUTOS_EXCLUIR]
	@PAR_CodProdID	INT
AS
	BEGIN
	DELETE FROM PRODUTOS
	WHERE
		CodProdID = @PAR_CodProdID
END
GO
/****** Object:  StoredProcedure [dbo].[PRODUTOS_INCLUIR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para INCLUIR de registro da tabela PRODUTOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PRODUTOS_INCLUIR]
@PAR_Titulo			VARCHAR(30),
@PAR_ISBN			VARCHAR(20),
@PAR_Paginas		INT,
@PAR_Edicao			INT,
@PAR_Editora		VARCHAR(30),
@PAR_AnoLanca		INT,
@PAR_CategoriaID	INT,
@PAR_Idioma			VARCHAR(20),
@PAR_Sinopse		VARCHAR(MAX),
@PAR_DtDesativacao	SMALLDATETIME,
@PAR_Preco			DECIMAL(10,2)

	AS
	BEGIN

	INSERT INTO PRODUTOS
	(
		Titulo,
		ISBN,
		Paginas,
		Edicao,
		Editora,
		AnoLanca,
		CategoriaID,
		Idioma,
		Sinopse,
		DtDesativacao,
		DtInclusao,
		Preco
	)
	VALUES
	(
		@PAR_Titulo,
		@PAR_ISBN,
		@PAR_Paginas,
		@PAR_Edicao,
		@PAR_Editora,
		@PAR_AnoLanca,
		@PAR_CategoriaID,
		@PAR_Idioma,
		@PAR_Sinopse,
		@PAR_DtDesativacao,
		GETDATE(),
		@PAR_Preco
	)

	SELECT	max(CodProdID) from PRODUTOS With(nolock)
END


GO
/****** Object:  StoredProcedure [dbo].[PRODUTOS_LISTA]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para LISTA de registro da tabela PRODUTOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 18/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PRODUTOS_LISTA]
AS
	BEGIN
	SELECT
		CodProdID		AS [Código],
		Titulo,
		Preco
	FROM PRODUTOS WITH(NOLOCK)
	WHERE
		DtDesativacao IS NULL
END
GO
/****** Object:  StoredProcedure [dbo].[PRODUTOS_RECUPERAR]    Script Date: 19/01/2016 22:59:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*=========================================================
Descrição:  StoredProcedure usada para RECUPERAR de registro da tabela PRODUTOS. 
===========================================================
Autor: Deivid Veloso
===========================================================
Data de Criação: 15/01/2016
===========================================================
Histórico:

===========================================================
Aplicação - 
===========================================================
Sistema - TocaLivros
==========================================================*/
CREATE PROCEDURE [dbo].[PRODUTOS_RECUPERAR]
	@PAR_CodProdID	INT
AS
	BEGIN
	SELECT
		Titulo,
		ISBN,
		Paginas,
		Edicao,
		Editora,
		AnoLanca,
		CategoriaID,
		Idioma,
		Sinopse,
		DtDesativacao,
		DtInclusao,
		DtAlteracao,
		Preco
	FROM PRODUTOS WITH(NOLOCK)
	WHERE
		CodProdID = @PAR_CodProdID
END
GO
USE [master]
GO
ALTER DATABASE [TocaLivrosDB] SET  READ_WRITE 
GO
