USE [Sales]
GO

ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_OrderItem_Order]
GO

ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_OrderItem_Item]
GO

ALTER TABLE [dbo].[ItemPrice] DROP CONSTRAINT [FK_ItemPrice_Item]
GO

ALTER TABLE [dbo].[ItemCategory] DROP CONSTRAINT [FK_ItemCategory_Item]
GO

ALTER TABLE [dbo].[ItemCategory] DROP CONSTRAINT [FK_ItemCategory_Category]
GO

ALTER TABLE [dbo].[CategoryTax] DROP CONSTRAINT [FK_CategoryTax_Tax]
GO

ALTER TABLE [dbo].[CategoryTax] DROP CONSTRAINT [FK_CategoryTax_Category]
GO

ALTER TABLE [dbo].[Tax] DROP CONSTRAINT [DF_Tax_Imported]
GO

ALTER TABLE [dbo].[Tax] DROP CONSTRAINT [DF_Tax_CreatedAt]
GO

ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [DF_OrderItem_CreatedAt]
GO

ALTER TABLE [dbo].[Order] DROP CONSTRAINT [DF_Order_CreatedAt]
GO

ALTER TABLE [dbo].[ItemPrice] DROP CONSTRAINT [DF_ItemPrice_CreatedAt]
GO

ALTER TABLE [dbo].[ItemCategory] DROP CONSTRAINT [DF_ItemCategory_CreatedAt]
GO

ALTER TABLE [dbo].[Item] DROP CONSTRAINT [DF_Item_Available]
GO

ALTER TABLE [dbo].[Item] DROP CONSTRAINT [DF_Item_CreatedAt]
GO

ALTER TABLE [dbo].[CategoryTax] DROP CONSTRAINT [DF_CategoryTax_CreatedAt]
GO

ALTER TABLE [dbo].[Category] DROP CONSTRAINT [DF_Category_Imported]
GO

ALTER TABLE [dbo].[Category] DROP CONSTRAINT [DF_Category_CreatedAt]
GO

/****** Object:  Table [dbo].[Tax]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tax]') AND type in (N'U'))
DROP TABLE [dbo].[Tax]
GO

/****** Object:  Table [dbo].[OrderItem]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
DROP TABLE [dbo].[OrderItem]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
DROP TABLE [dbo].[Order]
GO

/****** Object:  Table [dbo].[ItemPrice]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemPrice]') AND type in (N'U'))
DROP TABLE [dbo].[ItemPrice]
GO

/****** Object:  Table [dbo].[ItemCategory]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ItemCategory]') AND type in (N'U'))
DROP TABLE [dbo].[ItemCategory]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Item]') AND type in (N'U'))
DROP TABLE [dbo].[Item]
GO

/****** Object:  Table [dbo].[CategoryTax]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryTax]') AND type in (N'U'))
DROP TABLE [dbo].[CategoryTax]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 26/07/2021 14:47:09 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[Name] [varchar](30) NOT NULL,
	[Imported] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[CategoryTax]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CategoryTax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[CategoryId] [int] NOT NULL,
	[TaxId] [int] NOT NULL,
 CONSTRAINT [PK_CategoryTax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](512) NOT NULL,
	[Available] [bit] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ItemCategory]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[ItemId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ItemCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ItemPrice]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ItemPrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[ItemId] [int] NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PK_ItemPrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Order]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[CompletedAt] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[OrderItem]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[CompletedAt] [datetime] NULL,
	[OrderId] [int] NOT NULL,
	[ItemId] [int] NOT NULL,
	[Quantity] [decimal](12, 2) NOT NULL,
	[NetPrice] [decimal](18, 4) NOT NULL,
	[TotalTaxes] [decimal](18, 4) NOT NULL,
	[TotalPrice] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Tax]    Script Date: 26/07/2021 14:47:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NULL,
	[Description] [varchar](30) NOT NULL,
	[Value] [decimal](5, 2) NOT NULL,
	[Imports] [bit] NOT NULL,
 CONSTRAINT [PK_Tax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Imported]  DEFAULT ((0)) FOR [Imported]
GO

ALTER TABLE [dbo].[CategoryTax] ADD  CONSTRAINT [DF_CategoryTax_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Item] ADD  CONSTRAINT [DF_Item_Available]  DEFAULT ((1)) FOR [Available]
GO

ALTER TABLE [dbo].[ItemCategory] ADD  CONSTRAINT [DF_ItemCategory_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[ItemPrice] ADD  CONSTRAINT [DF_ItemPrice_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[OrderItem] ADD  CONSTRAINT [DF_OrderItem_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_CreatedAt]  DEFAULT (getdate()) FOR [CreatedAt]
GO

ALTER TABLE [dbo].[Tax] ADD  CONSTRAINT [DF_Tax_Imported]  DEFAULT ((0)) FOR [Imports]
GO

ALTER TABLE [dbo].[CategoryTax]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTax_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[CategoryTax] CHECK CONSTRAINT [FK_CategoryTax_Category]
GO

ALTER TABLE [dbo].[CategoryTax]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTax_Tax] FOREIGN KEY([TaxId])
REFERENCES [dbo].[Tax] ([Id])
GO

ALTER TABLE [dbo].[CategoryTax] CHECK CONSTRAINT [FK_CategoryTax_Tax]
GO

ALTER TABLE [dbo].[ItemCategory]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[ItemCategory] CHECK CONSTRAINT [FK_ItemCategory_Category]
GO

ALTER TABLE [dbo].[ItemCategory]  WITH CHECK ADD  CONSTRAINT [FK_ItemCategory_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO

ALTER TABLE [dbo].[ItemCategory] CHECK CONSTRAINT [FK_ItemCategory_Item]
GO

ALTER TABLE [dbo].[ItemPrice]  WITH CHECK ADD  CONSTRAINT [FK_ItemPrice_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO

ALTER TABLE [dbo].[ItemPrice] CHECK CONSTRAINT [FK_ItemPrice_Item]
GO

ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Item] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Item] ([Id])
GO

ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Item]
GO

ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO

ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Order]
GO


