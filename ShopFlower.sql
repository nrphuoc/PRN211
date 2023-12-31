USE [master]
GO
/****** Object:  Database [ShopFlower]    Script Date: 11/13/2022 7:24:19 PM ******/
CREATE DATABASE [ShopFlower]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopFlower', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopFlower.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ShopFlower_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ShopFlower_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ShopFlower] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopFlower].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopFlower] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopFlower] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopFlower] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopFlower] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopFlower] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopFlower] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopFlower] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopFlower] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopFlower] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopFlower] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopFlower] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopFlower] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopFlower] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopFlower] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopFlower] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopFlower] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopFlower] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopFlower] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopFlower] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopFlower] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopFlower] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ShopFlower] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopFlower] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopFlower] SET  MULTI_USER 
GO
ALTER DATABASE [ShopFlower] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopFlower] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopFlower] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopFlower] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ShopFlower] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ShopFlower] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ShopFlower] SET QUERY_STORE = OFF
GO
USE [ShopFlower]
GO
/****** Object:  Table [dbo].[BillItems]    Script Date: 11/13/2022 7:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillItems](
	[proID] [varchar](30) NOT NULL,
	[orderID] [varchar](32) NOT NULL,
	[quantity] [int] NULL,
	[price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[proID] ASC,
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bills]    Script Date: 11/13/2022 7:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[orderID] [varchar](32) NOT NULL,
	[address] [nvarchar](100) NULL,
	[total] [money] NULL,
	[status] [int] NULL,
	[cusID] [int] NOT NULL,
	[staffID] [int] NULL,
	[created_at] [timestamp] NULL,
 CONSTRAINT [PK__Bill__0809337D7889ADF1] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 11/13/2022 7:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[cusID] [int] IDENTITY(1,1) NOT NULL,
	[cusName] [varchar](30) NOT NULL,
	[email] [varchar](50) NULL,
	[cusPhone] [varchar](15) NULL,
	[cusAddress] [varchar](100) NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](16) NOT NULL,
 CONSTRAINT [PK__Customer__BA9897D3DBF43C3A] PRIMARY KEY CLUSTERED 
(
	[cusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/13/2022 7:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[proID] [varchar](30) NOT NULL,
	[proName] [nvarchar](100) NOT NULL,
	[quantity] [int] NULL,
	[price] [money] NULL,
	[image] [varchar](100) NULL,
	[description] [nvarchar](1000) NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[proID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 11/13/2022 7:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[staffID] [int] NOT NULL,
	[username] [varchar](30) NOT NULL,
	[password] [varchar](16) NOT NULL,
	[email] [varchar](50) NULL,
	[phone] [varchar](10) NULL,
	[address] [varchar](50) NULL,
	[storeID] [varchar](2) NULL,
	[managerID] [int] NULL,
 CONSTRAINT [PK__Admin__AD0500863EF1F5E4] PRIMARY KEY CLUSTERED 
(
	[staffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stocks]    Script Date: 11/13/2022 7:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stocks](
	[storeID] [varchar](2) NOT NULL,
	[productID] [varchar](30) NOT NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[storeID] ASC,
	[productID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stores]    Script Date: 11/13/2022 7:24:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
	[storeID] [varchar](2) NOT NULL,
	[storename] [nvarchar](50) NULL,
	[phone] [varchar](11) NULL,
	[email] [varchar](50) NULL,
	[address] [varchar](100) NULL,
 CONSTRAINT [PK__Category__A88B4DC4957C03EF] PRIMARY KEY CLUSTERED 
(
	[storeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P01', N'B04', 1, 250.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P02', N'B03', 1, 150.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P02', N'B06', 1, 150.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P02', N'B07', 1, 150.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P02', N'B08', 2, 150.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P02', N'B10', 1, 150.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P03', N'B01', 2, 250.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P04', N'B05', 1, 190.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P05', N'B06', 1, 130.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P08', N'B06', 1, 150.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P09', N'B03', 3, 230.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P11', N'B02', 1, 280.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P12', N'B06', 1, 190.0000)
INSERT [dbo].[BillItems] ([proID], [orderID], [quantity], [price]) VALUES (N'P15', N'B02', 1, 360.0000)
GO
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B01', N'Yuanlin, Changhua, Taiwan', 500.0000, 0, 1, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B02', N'Taichung, Taiwan', 640.0000, 0, 2, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B03', N'Hanoi, Vietnam', 840.0000, 0, 3, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B04', N'Hanoi, Vietnam', 250.0000, 0, 3, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B05', N'Taichung, Taiwan', 190.0000, 0, 2, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B06', N'Yuanlin, Changhua, Taiwan', 620.0000, 0, 1, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B07', N'Taichung, Taiwan', 150.0000, 0, 2, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B08', N'Taichung, Taiwan', 300.0000, 0, 2, NULL)
INSERT [dbo].[Bills] ([orderID], [address], [total], [status], [cusID], [staffID]) VALUES (N'B10', N'Taichung, Taiwan', 150.0000, 0, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([cusID], [cusName], [email], [cusPhone], [cusAddress], [username], [password]) VALUES (1, N'Nguyen Van A', NULL, N'0964234234', N'Yuanlin, Changhua, Taiwan', N'customer', N'12345678')
INSERT [dbo].[Customers] ([cusID], [cusName], [email], [cusPhone], [cusAddress], [username], [password]) VALUES (2, N'Nguyen Tuong Phuoc', NULL, N'0123789567', N'Taichung, Taiwan', N'ntphuoc', N'12345678')
INSERT [dbo].[Customers] ([cusID], [cusName], [email], [cusPhone], [cusAddress], [username], [password]) VALUES (3, N'Le Quang Duy', N'duylq@gmail.com', N'016327884', N'Hanoi, Vietnam', N'lqduy', N'12345678')
INSERT [dbo].[Customers] ([cusID], [cusName], [email], [cusPhone], [cusAddress], [username], [password]) VALUES (4, N'Doan Van Dong', N'dong123@gmail.com', N'0917076864', N'Hung yen', N'dvdong', N'12345678')
INSERT [dbo].[Customers] ([cusID], [cusName], [email], [cusPhone], [cusAddress], [username], [password]) VALUES (5, N'Tran Dinh Hieu', N'hieu123@gmail.com', N'0988888888', N'Ha Noi', N'tdhieu', N'12345678')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P01', N'EnlessLove', 16, 250.0000, N'images/WD-LoveLetter.jpg', N'A bouquet of red roses is not just romantic and classic - it is also timeless and elegant. Their enchanting smell refines the absolute beauty in them and delivers passion. Red roses will always be a way to say Ã¢Â€ÂœI love youÃ¢Â€Â.', NULL)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P02', N'Magic Moments', 15, 150.0000, N'images/WD-MagicMoments.jpg', N'Can you resist the sweet promise of angelic white Chrysanthemums, cream-coloured Germini blooms embracing the gorgeous scented Lily? This bouquet inspires an atmosphere of warmth that will give you wings and melt your heart.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P03', N'Spring Poetry', 15, 250.0000, N'images/WD-SpringPoetry.jpg', N'This adorable arrangement comes in different shades of pink roses and lilies. Pink is known to be the color of serenity, positive energy, inspiration and hope. A uniquely designed best-selling beauty that knows the true meaning of flower power.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P04', N'Beautiful Day', 15, 190.0000, N'images/CO-BeautifulDay.jpg', N'Create a special moment with this gorgeous bouquet of white lilies, roses and alstroemerias. A classic design that gives off simplicity and purity. Whatever the occasion, it will make its recipient’s day.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P05', N'New Day', 15, 130.0000, N'images/CO-NewDay.jpg', N'Wealth, prosperity, good fortune? Know anyone who would not be delighted to receive of all of these? Our exclusive good-luck bamboo not only delivers good luck, it has good karma attached.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P06', N'Silent', 15, 200.0000, N'images/CO-Silent.jpg', N'White roses is accented with the bright green stems of Bells of Ireland and a gorgeous assortment of lush greens, while seated in a white designer plastic urn to create a beautiful way to honour the life of the deceased.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P07', N'Forever', 15, 500.0000, N'images/AN-Forever.jpg', N'Orange Asiatic lilies, fuchsia carnations, red Peruvian lilies, lavender chrysanthemums and lush greens are perfectly arranged in a clear glass bubble bowl vase to send your sweetest sentiments across the miles.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P08', N'Pink Dream', 15, 150.0000, N'images/AN-PinkDream.jpg', N'Ready for the runway, as it were. A delightful combination of light colours and lovely flowers, it is simply beautiful. Light pink roses, alstroemeria, cushion spray chrysanthemums and statice are delivered in a stylish vase.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P09', N'Sweet Thoughts', 15, 230.0000, N'images/AN-SweetThoughts.jpg', N'If you would like someone to think sweet thoughts, send them this delightful bouquet! A graceful heart of bear grass is tied with purple waxflower, and appears to float above roses. How sweet it is!', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P10', N'Color Of Love', 15, 260.0000, N'images/RO-ColorOfLove.jpg', N'Make love blossom all over again. Surprise her with not one, but two dozen gorgeous red roses in a sparkling clear glass vase. Life will be twice as rosy for you both all week long.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P11', N'Told me', 15, 280.0000, N'images/RO-ToldMe.jpg', N'What is more romantic than a dozen red roses? Proclaim your love eternal with this radiant gift of crimson blooms and fresh greens, gathered in a classic clear vase. This bouquet features twelve red roses arranged with spiral eucalyptus and lemon leaf.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P12', N'Falling In Love', 15, 190.0000, N'images/RO-FallingInLove.jpg', N'One, two, three! Three dozen spectacularly gorgeous red roses delivered in a dazzling flared glass vase positive proof that love is a many-splendoured thing. Imagine her loving this amazing bouquet day after day. Hero-worshipping time.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P13', N'Reaching Hearts', 15, 320.0000, N'images/DE-ReachingHearts.jpg', N'Share a touch of class with your loved. With elegance, class and purity a dozen white roses is a graceful way to express your feelings on occasions where only pure emotion will do such as weddings, anniversaries and demonstrations of love.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P14', N'Warm Sunny', 15, 420.0000, N'images/DE-WarmSunny.jpg', N'The Sunny Bouquets is a blooming expression of charming cheer. Brilliant yellow roses and Peruvian lilies share the spotlight with white traditional daisies and green button poms to create a memorable bouquet.', 1)
INSERT [dbo].[Products] ([proID], [proName], [quantity], [price], [image], [description], [status]) VALUES (N'P15', N'Wonder', 15, 360.0000, N'images/DE-Wonder.jpg', N'This arrangement of pink roses and alstroemerias releases the perfect blend of sweetness and energy to send your love across the distance to someone on their birthday, to celebrate a new baby or just because.', 1)
GO
INSERT [dbo].[Staffs] ([staffID], [username], [password], [email], [phone], [address], [storeID], [managerID]) VALUES (1, N'admin', N'12345678', NULL, NULL, NULL, N'AN', NULL)
INSERT [dbo].[Staffs] ([staffID], [username], [password], [email], [phone], [address], [storeID], [managerID]) VALUES (2, N'dinhnam277', N'87654321', NULL, NULL, NULL, N'CO', NULL)
INSERT [dbo].[Staffs] ([staffID], [username], [password], [email], [phone], [address], [storeID], [managerID]) VALUES (5, N'duong01', N'12345678', N'duong@gmail.com', N'078264723', N'Ha Noi', N'DE', NULL)
INSERT [dbo].[Staffs] ([staffID], [username], [password], [email], [phone], [address], [storeID], [managerID]) VALUES (6, N'huong01', N'12345678', N'huong@gmail.com', N'0876542732', N'Hung Yen', N'WD', NULL)
INSERT [dbo].[Staffs] ([staffID], [username], [password], [email], [phone], [address], [storeID], [managerID]) VALUES (7, N'phuong01', N'12345678', N'phuong@gmail.com', N'0178273845', N'Hung Yen', N'CO', NULL)
GO
INSERT [dbo].[Stores] ([storeID], [storename], [phone], [email], [address]) VALUES (N'AN', N'Anniversary', N'1', NULL, NULL)
INSERT [dbo].[Stores] ([storeID], [storename], [phone], [email], [address]) VALUES (N'CO', N'Congratulations', N'1', NULL, NULL)
INSERT [dbo].[Stores] ([storeID], [storename], [phone], [email], [address]) VALUES (N'DE', N'Decoration', N'1', NULL, NULL)
INSERT [dbo].[Stores] ([storeID], [storename], [phone], [email], [address]) VALUES (N'RO', N'Romance', N'1', NULL, NULL)
INSERT [dbo].[Stores] ([storeID], [storename], [phone], [email], [address]) VALUES (N'WD', N'Wedding', N'1', NULL, NULL)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__F3DBC572C2AD0D81]    Script Date: 11/13/2022 7:24:19 PM ******/
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [UQ__Customer__F3DBC572C2AD0D81] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Admin__F3DBC572DF7554DE]    Script Date: 11/13/2022 7:24:19 PM ******/
ALTER TABLE [dbo].[Staffs] ADD  CONSTRAINT [UQ__Admin__F3DBC572DF7554DE] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bills] ADD  CONSTRAINT [DF__Bill__status__30F848ED]  DEFAULT ((0)) FOR [status]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[Stores] ADD  CONSTRAINT [DF__Category__status__31EC6D26]  DEFAULT ((1)) FOR [phone]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD  CONSTRAINT [FK__BillDetai__order__35BCFE0A] FOREIGN KEY([orderID])
REFERENCES [dbo].[Bills] ([orderID])
GO
ALTER TABLE [dbo].[BillItems] CHECK CONSTRAINT [FK__BillDetai__order__35BCFE0A]
GO
ALTER TABLE [dbo].[BillItems]  WITH CHECK ADD FOREIGN KEY([proID])
REFERENCES [dbo].[Products] ([proID])
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK__Bill__cusID__34C8D9D1] FOREIGN KEY([cusID])
REFERENCES [dbo].[Customers] ([cusID])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK__Bill__cusID__34C8D9D1]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD  CONSTRAINT [FK_Bills_Staffs] FOREIGN KEY([staffID])
REFERENCES [dbo].[Staffs] ([staffID])
GO
ALTER TABLE [dbo].[Bills] CHECK CONSTRAINT [FK_Bills_Staffs]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK__Staffs__storeID__6EF57B66] FOREIGN KEY([storeID])
REFERENCES [dbo].[Stores] ([storeID])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK__Staffs__storeID__6EF57B66]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_Staffs] FOREIGN KEY([managerID])
REFERENCES [dbo].[Staffs] ([staffID])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_Staffs]
GO
ALTER TABLE [dbo].[Stocks]  WITH CHECK ADD FOREIGN KEY([productID])
REFERENCES [dbo].[Products] ([proID])
GO
ALTER TABLE [dbo].[Stocks]  WITH CHECK ADD  CONSTRAINT [FK__Stocks__storeID__5EBF139D] FOREIGN KEY([storeID])
REFERENCES [dbo].[Stores] ([storeID])
GO
ALTER TABLE [dbo].[Stocks] CHECK CONSTRAINT [FK__Stocks__storeID__5EBF139D]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [CK__Customer__passwo__398D8EEE] CHECK  ((len([password])>=(8)))
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [CK__Customer__passwo__398D8EEE]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD CHECK  (([price]>=(0)))
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD CHECK  (([quantity]>=(0)))
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [CK__Admin__password__38996AB5] CHECK  ((len([password])>=(8)))
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [CK__Admin__password__38996AB5]
GO
USE [master]
GO
ALTER DATABASE [ShopFlower] SET  READ_WRITE 
GO
