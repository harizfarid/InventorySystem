USE [InventorySystem]
GO
/****** Object:  Table [dbo].[SalesOrder]    Script Date: 08/17/2013 22:37:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[ProductId] [int] NULL,
	[MaterialId] [int] NULL,
	[CustomerPO] [varchar](150) NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [varchar](150) NULL,
	[LeadTime] [varchar](150) NULL,
	[Status] [int] NULL,
	[Remarks] [varchar](299) NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesOrderDetails]    Script Date: 08/17/2013 22:37:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalesOrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SalesOrderId] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Description] [varchar](299) NULL,
	[UnitPrice] [decimal](18, 2) NULL,
	[Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalesOrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_SalesOrderDetails_SalesOrder]    Script Date: 08/17/2013 22:37:53 ******/
ALTER TABLE [dbo].[SalesOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrderDetails_SalesOrder] FOREIGN KEY([SalesOrderId])
REFERENCES [dbo].[SalesOrder] ([Id])
GO
ALTER TABLE [dbo].[SalesOrderDetails] CHECK CONSTRAINT [FK_SalesOrderDetails_SalesOrder]
GO
