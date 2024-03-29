USE [master]
GO
/****** Object:  Database [DANGELO_DB]    Script Date: 4/7/2019 19:48:04 ******/
CREATE DATABASE [DANGELO_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TPC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TPC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TPC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\TPC_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [DANGELO_DB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DANGELO_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DANGELO_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DANGELO_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DANGELO_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DANGELO_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DANGELO_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [DANGELO_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DANGELO_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DANGELO_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DANGELO_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DANGELO_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DANGELO_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DANGELO_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DANGELO_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DANGELO_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DANGELO_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DANGELO_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DANGELO_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DANGELO_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DANGELO_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DANGELO_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DANGELO_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DANGELO_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DANGELO_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DANGELO_DB] SET  MULTI_USER 
GO
ALTER DATABASE [DANGELO_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DANGELO_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DANGELO_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DANGELO_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DANGELO_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DANGELO_DB] SET QUERY_STORE = OFF
GO
USE [DANGELO_DB]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 4/7/2019 19:48:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[idFactura] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[importe] [decimal](12, 2) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CLIENTES]    Script Date: 4/7/2019 19:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CLIENTES](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[cp] [int] NOT NULL,
	[idprovincia] [int] NOT NULL,
	[telefono] [varchar](30) NULL,
	[EMAIL] [varchar](50) NULL,
	[IDCONTRIBUYENTE] [int] NOT NULL,
	[CUIT] [varchar](30) NOT NULL,
	[OBSERVACIONES] [varchar](100) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_Ventas]    Script Date: 4/7/2019 19:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VW_Ventas] as(
select d.idFactura, d.Fecha, c.nombre, d.importe from DetalleVenta as d
inner join CLIENTES as c on c.id=d.IdCliente    
)
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 4/7/2019 19:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[articulo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion1] [varchar](40) NOT NULL,
	[codBarras] [bigint] NULL,
	[stockMin] [int] NULL,
	[stockMax] [int] NOT NULL,
	[costo] [decimal](6, 2) NOT NULL,
	[ganancia] [int] NOT NULL,
	[idMarca] [int] NOT NULL,
	[idRubro] [int] NOT NULL,
	[idProveedores] [int] NOT NULL,
	[estado] [bit] NOT NULL,
	[StockActual] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rubros]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rubros](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[idProvincia] [int] NOT NULL,
	[CP] [int] NULL,
	[idContribuyente] [int] NOT NULL,
	[CUIT] [varchar](30) NOT NULL,
	[Contacto] [varchar](50) NULL,
	[Telefono] [varchar](30) NOT NULL,
	[estado] [bit] NOT NULL,
	[email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_Articulo]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[VW_Articulo] as

select a.id as ID, a.descripcion1 as Descripcion,a.costo as Costo, a.codBarras as CodBarras, a.Stockmin as StockMin,a.stockMax as StockMax,a.stockActual as StockActual, a.ganancia as Ganancia, m.descripcion as Marcar, r.descripcion as Rubro, pr.Nombre as Proveedor, cast(a.costo*(1+a.ganancia*0.01) as decimal(12,2)) as PrecioPublico from articulo as a
inner join Marcas as m on m.id = a.idMarca
inner join Rubros as r on r.id=a.idRubro
inner join Proveedores as pr on pr.id = a.idProveedores
where a.estado = 1
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[idproveedor] [int] NOT NULL,
	[monto] [decimal](12, 2) NOT NULL,
	[fecha] [date] NOT NULL,
	[numcomprobante] [varchar](12) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CONTRIBUYENTES]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTRIBUYENTES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPCION] [varchar](50) NOT NULL,
	[IDIVA] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleArticulo]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleArticulo](
	[IdFactura] [int] NOT NULL,
	[IdArticulo] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUni] [decimal](12, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IVA]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IVA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](20) NOT NULL,
	[Porcentaje] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROVINCIAS]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROVINCIAS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/7/2019 19:48:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Pass] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[articulo] ON 

INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (1, N'LLAVE COMBINADA PU10', 0, 0, 15, CAST(90.10 AS Decimal(6, 2)), 99, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (2, N'123', 123, 123, 123, CAST(123.00 AS Decimal(6, 2)), 132, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (3, N'1', 1, 1, 1, CAST(1.00 AS Decimal(6, 2)), 1, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (4, N'1', 1, 1, 1, CAST(1.00 AS Decimal(6, 2)), 1, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (5, N'BANANA 2', 0, 0, 10, CAST(1000.00 AS Decimal(6, 2)), 60, 1, 1, 1, 1, 45)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (6, N'DESTORNILLADOR', 0, 10, 20, CAST(12.00 AS Decimal(6, 2)), 55, 1, 1, 1, 1, 3)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (7, N'TRAPO DE PISO', 0, 2, 15, CAST(44.50 AS Decimal(6, 2)), 60, 1, 1, 1, 1, 15)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (8, N'hjsakdhkasj', 1, 1, 4, CAST(12.00 AS Decimal(6, 2)), 55, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (9, N'', 1, 1, 1, CAST(1.00 AS Decimal(6, 2)), 1, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (10, N'1', 0, 1, 1, CAST(111.40 AS Decimal(6, 2)), 50, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (11, N'123', 123, 1, 123, CAST(120.10 AS Decimal(6, 2)), 10, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (12, N'LIJA', 123, 1, 10, CAST(50.11 AS Decimal(6, 2)), 50, 1, 1, 1, 1, 15)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (13, N'DISCO', 123, 1, 12, CAST(13.10 AS Decimal(6, 2)), 50, 1, 1, 1, 1, -200)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (14, N'123', 123, 1, 123, CAST(40.10 AS Decimal(6, 2)), 50, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (15, N'23', 1, 12, 15, CAST(12.35 AS Decimal(6, 2)), 60, 1, 1, 1, 0, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (16, N'MATE', 0, 1, 10, CAST(100.10 AS Decimal(6, 2)), 60, 1, 1, 1, 1, 0)
INSERT [dbo].[articulo] ([id], [descripcion1], [codBarras], [stockMin], [stockMax], [costo], [ganancia], [idMarca], [idRubro], [idProveedores], [estado], [StockActual]) VALUES (21, N'BANANIN', 123345, 1, 12, CAST(1000.00 AS Decimal(6, 2)), 75, 3, 3, 3, 1, 0)
SET IDENTITY_INSERT [dbo].[articulo] OFF
SET IDENTITY_INSERT [dbo].[CLIENTES] ON 

INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (1, N'CONTROL SERVICE SRL', N'QUIRNO COSTA 3435', 1618, 1, N'03327-452344', N'ADMINISTRACION@CONTROLSERVICE.COM', 1, N'33-70731878-9', N'NO FIAR, NO PAGAN', 1)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (2, N'ALUEX S.A.', N'STEPHENSON 3197', 1667, 1, N'4743-5155', N'COMPRAS@ALUEX.COM.AR', 1, N'30-65583760-9', N'DEMORAS CON LOS PAGOS EN CTA/CTE', 1)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (3, N'SEVAGRAF SA', N'AV. SAN JUAN 777', 1147, 1, N'4915-9136', N'INFO@SEVAGRAF.COM.AR', 1, N'30-70934685-3', N'', 1)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (6, N'123', N'123', 123, 1, N'123', N'123', 1, N'1234', N'123', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (7, N'cardano lucas', N'av de las industrias', 1618, 6, N'03327452380', N'ads@asd.com', 1, N'23290390699', N'ninguno', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (8, N'00000', N'00000', 0, 1, N'00000', N'00000', 1, N'00000', N'00000', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (9, N'33', N'333', 33, 1, N'33', N'33', 1, N'33', N'1', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (10, N'ALEJANDRO', N'123', 123, 1, N'123', N'123', 1, N'1111', N'123', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (11, N'QWE', N'QWE', 1618, 1, N'wee', N'QWE', 1, N'123', N'QWE', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (12, N'123', N'123', 123, 1, N'123', N'123', 1, N'123', N'123', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (13, N'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', N'ASD', 123, 1, N'1234', N'ASR@ASD.COM', 1, N'1234556', N'ASD', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (14, N'hernan', N'banana 231', 1618, 1, N'03327-452388', N'hernan@gmmmil.com', 3, N'03327-452388', N'es un bobo', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (15, N'', N'blablabla', 1000, 4, N'112213214246', N'ariel@bnana.com', 4, N'112213214246', N'es un bobo', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (1014, N'ASD', N'ASD', 1111, 1, N'1111', N'ASD', 1, N'asd', N'ASD', 0)
INSERT [dbo].[CLIENTES] ([id], [nombre], [direccion], [cp], [idprovincia], [telefono], [EMAIL], [IDCONTRIBUYENTE], [CUIT], [OBSERVACIONES], [Estado]) VALUES (1015, N'AAAAAAAA', N'ASD 123', 123, 1, N'123', N'ASD@ASD.COM', 1, N'1234', N'1234', 1)
SET IDENTITY_INSERT [dbo].[CLIENTES] OFF
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1000.00 AS Decimal(12, 2)), CAST(N'2019-06-25' AS Date), N'123499999999')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (2, CAST(100.10 AS Decimal(12, 2)), CAST(N'2019-06-04' AS Date), N'31')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (2, CAST(2001.00 AS Decimal(12, 2)), CAST(N'2019-06-04' AS Date), N'30')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (2, CAST(150.10 AS Decimal(12, 2)), CAST(N'2019-06-04' AS Date), N'30')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1000.10 AS Decimal(12, 2)), CAST(N'2010-02-10' AS Date), N'300000123')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1000.10 AS Decimal(12, 2)), CAST(N'2010-02-10' AS Date), N'000300000123')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(100011.00 AS Decimal(12, 2)), CAST(N'2010-02-10' AS Date), N'000300000123')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (2, CAST(11111.00 AS Decimal(12, 2)), CAST(N'2019-06-25' AS Date), N'000200003333')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (3, CAST(10001.00 AS Decimal(12, 2)), CAST(N'2019-06-25' AS Date), N'000900009999')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1000.10 AS Decimal(12, 2)), CAST(N'2019-06-25' AS Date), N'123412345677')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(10000.00 AS Decimal(12, 2)), CAST(N'2019-06-25' AS Date), N'123412345677')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1000.11 AS Decimal(12, 2)), CAST(N'2019-06-25' AS Date), N'123412345677')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(111.00 AS Decimal(12, 2)), CAST(N'2019-06-25' AS Date), N'123412345678')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(11111.00 AS Decimal(12, 2)), CAST(N'2019-07-02' AS Date), N'000111111111')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (3, CAST(12345.11 AS Decimal(12, 2)), CAST(N'2019-06-05' AS Date), N'000100000012')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1000.00 AS Decimal(12, 2)), CAST(N'2019-07-03' AS Date), N'111100000000')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (3, CAST(111111.00 AS Decimal(12, 2)), CAST(N'2019-07-03' AS Date), N'000000000001')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1000.00 AS Decimal(12, 2)), CAST(N'2019-07-03' AS Date), N'111111111112')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1111.00 AS Decimal(12, 2)), CAST(N'2019-07-03' AS Date), N'11111111115')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (1, CAST(1111.00 AS Decimal(12, 2)), CAST(N'2019-07-03' AS Date), N'111111111199')
INSERT [dbo].[Compras] ([idproveedor], [monto], [fecha], [numcomprobante]) VALUES (2, CAST(10000.00 AS Decimal(12, 2)), CAST(N'2019-07-03' AS Date), N'123412343444')
SET IDENTITY_INSERT [dbo].[CONTRIBUYENTES] ON 

INSERT [dbo].[CONTRIBUYENTES] ([ID], [DESCRIPCION], [IDIVA]) VALUES (1, N'Responsable Inscripto', 1)
INSERT [dbo].[CONTRIBUYENTES] ([ID], [DESCRIPCION], [IDIVA]) VALUES (3, N'Responsable no Inscripto', 3)
INSERT [dbo].[CONTRIBUYENTES] ([ID], [DESCRIPCION], [IDIVA]) VALUES (4, N'Consumidor Final', 3)
INSERT [dbo].[CONTRIBUYENTES] ([ID], [DESCRIPCION], [IDIVA]) VALUES (5, N'Extranjero', 3)
INSERT [dbo].[CONTRIBUYENTES] ([ID], [DESCRIPCION], [IDIVA]) VALUES (7, N'Responsable Monotributo', 3)
INSERT [dbo].[CONTRIBUYENTES] ([ID], [DESCRIPCION], [IDIVA]) VALUES (8, N'Exento', 3)
SET IDENTITY_INSERT [dbo].[CONTRIBUYENTES] OFF
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (1, 5, 1000, CAST(2.56 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (2, 6, 10, CAST(14.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (2, 16, 1, CAST(160.16 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (2, 12, 2, CAST(75.17 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (3, 12, 1, CAST(75.17 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (3, 13, 1, CAST(19.65 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (3, 16, 1, CAST(160.16 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (3, 6, 1, CAST(14.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (4, 5, 11, CAST(1600.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (5, 13, 100, CAST(19.65 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (6, 21, 50, CAST(1750.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleArticulo] ([IdFactura], [IdArticulo], [Cantidad], [PrecioUni]) VALUES (7, 21, 100, CAST(1750.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleVenta] ([idFactura], [Fecha], [IdCliente], [importe]) VALUES (1, CAST(N'2019-06-30T16:55:51.513' AS DateTime), 1, CAST(2560.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleVenta] ([idFactura], [Fecha], [IdCliente], [importe]) VALUES (2, CAST(N'2019-06-30T16:56:17.357' AS DateTime), 2, CAST(450.48 AS Decimal(12, 2)))
INSERT [dbo].[DetalleVenta] ([idFactura], [Fecha], [IdCliente], [importe]) VALUES (3, CAST(N'2019-06-30T16:56:54.057' AS DateTime), 3, CAST(268.97 AS Decimal(12, 2)))
INSERT [dbo].[DetalleVenta] ([idFactura], [Fecha], [IdCliente], [importe]) VALUES (4, CAST(N'2019-07-02T21:45:45.733' AS DateTime), 1, CAST(17600.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleVenta] ([idFactura], [Fecha], [IdCliente], [importe]) VALUES (5, CAST(N'2019-07-03T21:18:15.930' AS DateTime), 1, CAST(1965.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleVenta] ([idFactura], [Fecha], [IdCliente], [importe]) VALUES (6, CAST(N'2019-07-03T21:18:57.100' AS DateTime), 3, CAST(87500.00 AS Decimal(12, 2)))
INSERT [dbo].[DetalleVenta] ([idFactura], [Fecha], [IdCliente], [importe]) VALUES (7, CAST(N'2019-07-03T21:20:33.743' AS DateTime), 3, CAST(175000.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[IVA] ON 

INSERT [dbo].[IVA] ([id], [descripcion], [Porcentaje]) VALUES (1, N'IVA 21%', 21)
INSERT [dbo].[IVA] ([id], [descripcion], [Porcentaje]) VALUES (2, N'IVA 10.5%', 10.5)
INSERT [dbo].[IVA] ([id], [descripcion], [Porcentaje]) VALUES (3, N'IVA 0%', 0)
SET IDENTITY_INSERT [dbo].[IVA] OFF
SET IDENTITY_INSERT [dbo].[Marcas] ON 

INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (1, N'SIN MARCA', 1)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (2, N'CROSSMASTER', 1)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (3, N'BAHCO', 1)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (4, N'BANAN', 0)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (5, N'COCA-COLA', 0)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (6, N'PEPSI', 0)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (7, N'PESI', 0)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (8, N'', 0)
INSERT [dbo].[Marcas] ([id], [descripcion], [estado]) VALUES (9, N'ASD', 0)
SET IDENTITY_INSERT [dbo].[Marcas] OFF
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([id], [Nombre], [Direccion], [idProvincia], [CP], [idContribuyente], [CUIT], [Contacto], [Telefono], [estado], [email]) VALUES (1, N'MORANO MYH', N'SAN MARTIN', 1, 1011, 1, N'23-29039069-9', N'JORGE', N'4712-2210', 1, N'ASD@ASD.COM')
INSERT [dbo].[Proveedores] ([id], [Nombre], [Direccion], [idProvincia], [CP], [idContribuyente], [CUIT], [Contacto], [Telefono], [estado], [email]) VALUES (2, N'ITURRIA', N'ANDONEAGUI 1123', 1, 1619, 1, N'23920394', N'RICARDO', N'4715-0048', 1, N'SSS@SSS.COM')
INSERT [dbo].[Proveedores] ([id], [Nombre], [Direccion], [idProvincia], [CP], [idContribuyente], [CUIT], [Contacto], [Telefono], [estado], [email]) VALUES (3, N'CLORONOR', N'COLECTORA 1440', 1, 1610, 1, N'123123', N'PABLO', N'4715-1115', 1, N'DDD@DD.COM')
INSERT [dbo].[Proveedores] ([id], [Nombre], [Direccion], [idProvincia], [CP], [idContribuyente], [CUIT], [Contacto], [Telefono], [estado], [email]) VALUES (4, N'AAA', N'AAA', 1, 1111, 1, N'bbb', N'AAA', N'AAA', 0, N'')
INSERT [dbo].[Proveedores] ([id], [Nombre], [Direccion], [idProvincia], [CP], [idContribuyente], [CUIT], [Contacto], [Telefono], [estado], [email]) VALUES (5, N'BBBBBBBBBBBBBB', N'AAA', 1, 111, 1, N'aaa', N'123', N'12234', 0, N'ASDDASD')
INSERT [dbo].[Proveedores] ([id], [Nombre], [Direccion], [idProvincia], [CP], [idContribuyente], [CUIT], [Contacto], [Telefono], [estado], [email]) VALUES (6, N'123', N'123', 1, 123, 1, N'123', N'123', N'13122', 0, N'1223')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
SET IDENTITY_INSERT [dbo].[PROVINCIAS] ON 

INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (1, N'Buenos Aires')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (2, N'Capital Federal')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (3, N'Catamarca')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (4, N'Cordoba')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (5, N'Corrientes')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (6, N'Chaco')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (7, N'Chubut')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (8, N'Entre rios')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (9, N'Formosa')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (10, N'Jujuy')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (11, N'La Pampa')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (12, N'La Rioja')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (13, N'Mendoza')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (14, N'Misiones')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (15, N'Rio Negro')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (16, N'Salta')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (17, N'San Juan')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (18, N'San Luis')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (19, N'Santa Cruz')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (20, N'Santa Fe')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (21, N'Santiago Del Estero')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (22, N'Tierra Del Fuego')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (23, N'Tucuman')
INSERT [dbo].[PROVINCIAS] ([ID], [NOMBRE]) VALUES (24, N'Exterior')
SET IDENTITY_INSERT [dbo].[PROVINCIAS] OFF
SET IDENTITY_INSERT [dbo].[Rubros] ON 

INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (1, N'VARIOSS', 1)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (2, N'HERRAMIENTAS DE MANO', 1)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (3, N'SOLVENTESS', 1)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (4, N'BANANA', 0)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (5, N'MANZANA', 0)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (6, N'PERA', 0)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (7, N'LIMA LIMON', 0)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (8, N'BANANA', 0)
INSERT [dbo].[Rubros] ([id], [descripcion], [estado]) VALUES (9, N'', 0)
SET IDENTITY_INSERT [dbo].[Rubros] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [Name], [Pass]) VALUES (1, N'admin', N'admin')
INSERT [dbo].[Users] ([id], [Name], [Pass]) VALUES (2, N'banana', N'banana')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Index [articulo_pk]    Script Date: 4/7/2019 19:48:08 ******/
ALTER TABLE [dbo].[articulo] ADD  CONSTRAINT [articulo_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [DetalleVenta_pk]    Script Date: 4/7/2019 19:48:08 ******/
ALTER TABLE [dbo].[DetalleVenta] ADD  CONSTRAINT [DetalleVenta_pk] PRIMARY KEY NONCLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [DetalleVenta_idFactura_uindex]    Script Date: 4/7/2019 19:48:08 ******/
CREATE UNIQUE NONCLUSTERED INDEX [DetalleVenta_idFactura_uindex] ON [dbo].[DetalleVenta]
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Users_pk]    Script Date: 4/7/2019 19:48:08 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [Users_pk] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [Users_id_uindex]    Script Date: 4/7/2019 19:48:08 ******/
CREATE UNIQUE NONCLUSTERED INDEX [Users_id_uindex] ON [dbo].[Users]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[articulo] ADD  DEFAULT ((0)) FOR [codBarras]
GO
ALTER TABLE [dbo].[articulo] ADD  DEFAULT ((0)) FOR [stockMin]
GO
ALTER TABLE [dbo].[articulo] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[articulo] ADD  DEFAULT ((0)) FOR [StockActual]
GO
ALTER TABLE [dbo].[CLIENTES] ADD  DEFAULT ((1)) FOR [idprovincia]
GO
ALTER TABLE [dbo].[DetalleVenta] ADD  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Marcas] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((1)) FOR [idProvincia]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((0)) FOR [Telefono]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ('') FOR [email]
GO
ALTER TABLE [dbo].[Rubros] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marcas] ([id])
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD FOREIGN KEY([idProveedores])
REFERENCES [dbo].[Proveedores] ([id])
GO
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD FOREIGN KEY([idRubro])
REFERENCES [dbo].[Rubros] ([id])
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD FOREIGN KEY([IDCONTRIBUYENTE])
REFERENCES [dbo].[CONTRIBUYENTES] ([ID])
GO
ALTER TABLE [dbo].[CLIENTES]  WITH CHECK ADD FOREIGN KEY([idprovincia])
REFERENCES [dbo].[PROVINCIAS] ([ID])
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD FOREIGN KEY([idproveedor])
REFERENCES [dbo].[Proveedores] ([id])
GO
ALTER TABLE [dbo].[CONTRIBUYENTES]  WITH CHECK ADD FOREIGN KEY([IDIVA])
REFERENCES [dbo].[IVA] ([id])
GO
ALTER TABLE [dbo].[DetalleArticulo]  WITH CHECK ADD  CONSTRAINT [DetalleArticulo___fkArticulo] FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[articulo] ([id])
GO
ALTER TABLE [dbo].[DetalleArticulo] CHECK CONSTRAINT [DetalleArticulo___fkArticulo]
GO
ALTER TABLE [dbo].[DetalleArticulo]  WITH CHECK ADD  CONSTRAINT [DetalleArticulo_DetalleVenta_idFactura_fk] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[DetalleVenta] ([idFactura])
GO
ALTER TABLE [dbo].[DetalleArticulo] CHECK CONSTRAINT [DetalleArticulo_DetalleVenta_idFactura_fk]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [DetalleVenta_CLIENTES_id_fk] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[CLIENTES] ([id])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [DetalleVenta_CLIENTES_id_fk]
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD FOREIGN KEY([idContribuyente])
REFERENCES [dbo].[CONTRIBUYENTES] ([ID])
GO
ALTER TABLE [dbo].[Proveedores]  WITH CHECK ADD FOREIGN KEY([idProvincia])
REFERENCES [dbo].[PROVINCIAS] ([ID])
GO
ALTER TABLE [dbo].[IVA]  WITH CHECK ADD CHECK  (([id]<(4)))
GO
/****** Object:  StoredProcedure [dbo].[Reporte]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Reporte](@IDFACTURA INT) as
        begin
        select
               d.Cantidad as Cant,
               d.IdArticulo as Cod,
               a.descripcion1 as Descripcion,
               d.PrecioUni as Unit,
               PrecioUni*Cantidad as total,
                cl.nombre as Cliente,
               cl.CUIT as CUIT,
                (select sum(PrecioUni*Cantidad) from DetalleArticulo as da where da.IdFactura=dv.idFactura) as Final,
               dv.Fecha
                
            from DetalleArticulo as d
        inner join articulo a on d.IdArticulo = a.id
        inner join DetalleVenta as dv on dv.idFactura=d.IdFactura
        INNER JOIN CLIENTES as cl on cl.id = dv.IdCliente
        where d.IdFactura=@IDFACTURA
        end
GO
/****** Object:  StoredProcedure [dbo].[ReporteFactura]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[ReporteFactura](@numero int)
as begin
    select d.IdArticulo as COD, d.Cantidad as Cant, a.descripcion1 as Descripcion, d.PrecioUni as Unit, d.Cantidad*d.PrecioUni as Total from DetalleArticulo as d
    inner join articulo a on d.IdArticulo = a.id
        where @numero=d.idFactura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DatosFactura]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_DatosFactura](@idfactura int)
as begin
    select dv.idFactura as NumFac,c2.nombre as Cliente,c2.CUIT as NumCuit,c2.direccion as Direccion, cast(dv.Fecha as date) as Fecha,cast(dv.Fecha as time) as HORA ,dv.importe as TOTAL  from DetalleVenta as dv
    inner join CLIENTES C2 on dv.IdCliente = C2.id
    where dv.idFactura=@idfactura
end
GO
/****** Object:  StoredProcedure [dbo].[SP_FECHACLIENTE]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_FECHACLIENTE]  (@desde varchar (15), @hasta varchar(15), @NomClie varchar (50))
as begin
set dateformat  'DMY'
 select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d
 inner join CLIENTES as c on c.id = d.IdCliente
    where c.nombre like @NomClie and d.Fecha > @desde AND d.Fecha < @hasta
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarPorFechas]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_ListarPorFechas] (@desde varchar (15), @hasta varchar(15), @NomClie varchar (50), @Factura int)
as begin
set dateformat 'DMY'
declare @nombre varchar (50)
select @nombre = isnull(@nombre, '-1')
if (@nombre = -1)
    begin
        select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d
 inner join CLIENTES as c on c.id = d.IdCliente
        where d.idFactura= @factura
    end
        end
GO
/****** Object:  StoredProcedure [dbo].[SP_NUMFACTU]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_NUMFACTU] (@Factura int)
as begin
    set dateformat  'DMY'
       select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d
 inner join CLIENTES as c on c.id = d.IdCliente
        where d.idFactura= @factura
end
GO
/****** Object:  StoredProcedure [dbo].[sp_prueba]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[sp_prueba] (@NomClie varchar(50)) as
        begin
        select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d
 inner join CLIENTES as c on c.id = d.IdCliente
    where c.nombre like @NomClie
        end
GO
/****** Object:  StoredProcedure [dbo].[SP_SOLOFECHA]    Script Date: 4/7/2019 19:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_SOLOFECHA]  (@desde varchar (15), @hasta varchar(15))
as begin
set dateformat  'DMY'
 select d.idFactura as NumFactura, d.Fecha, c.nombre as Cliente, d.importe from DetalleVenta as d
 inner join CLIENTES as c on c.id = d.IdCliente
    where d.Fecha > @desde AND d.Fecha < @hasta
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Marca del articulo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'articulo', @level2type=N'COLUMN',@level2name=N'idMarca'
GO
USE [master]
GO
ALTER DATABASE [DANGELO_DB] SET  READ_WRITE 
GO
