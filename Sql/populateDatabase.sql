USE CodeInterview;
CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [Type]        NVARCHAR (50)  NULL,
    [Quantity]    INT            DEFAULT ((1)) NULL,
    [Cost]        FLOAT (53)     DEFAULT ((0)) NULL,
    [DateAdded]   DATETIME       DEFAULT (getdate()) NULL,
    [ImageUrl]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Username]    NVARCHAR (50) NOT NULL,
    [Password]    NVARCHAR (50) NOT NULL,
    [AdminStatus] BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [AdminStatus]) VALUES (1, N'Jacob', N'Arsenault', 0)
INSERT INTO [dbo].[Users] ([Id], [Username], [Password], [AdminStatus]) VALUES (2, N'Admin', N'Password', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [Type], [Quantity], [Cost], [DateAdded], [ImageUrl]) VALUES (1, N'Razer Basilisk', N'Wireless Gaming Mouse Using Razers 5G Advanced Sensor', N'Mouse', 5, 59.99, N'2021-09-05 13:12:00', N'~/Content/Images/Products/razerBasilisk.jpg')
INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [Type], [Quantity], [Cost], [DateAdded], [ImageUrl]) VALUES (2, N'Razer Viper', N'Wired RGB Gaming Mouse.  The Razer Viper is durable for over 50 million clicks.', N'Mouse', 4, 49.99, N'2021-09-05 13:12:00', N'~/Content/Images/Products/razerViper.jpg')
INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [Type], [Quantity], [Cost], [DateAdded], [ImageUrl]) VALUES (3, N'Corsair HS70 Pro Gaming Headset', N'Wireless gaming headset with up to 16 hours of battery life!', N'Headset', 15, 109.99, N'2021-09-05 13:12:00', N'~/Content/Images/Products/corsairHS70.jpg')
INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [Type], [Quantity], [Cost], [DateAdded], [ImageUrl]) VALUES (4, N'Corsair k57 RGB Keyboard', N'Wireless gaming headset with 110 keys.', N'Keyboard', 2, 129.99, N'2021-09-05 13:12:00', N'~/Content/Images/Products/corsairK57.jpg')
INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [Type], [Quantity], [Cost], [DateAdded], [ImageUrl]) VALUES (5, N'Airpod Max Blue', N'Active noise cancellation for a quiet workout.', N'Headset', 2, 779.99, N'2021-09-05 13:12:00', N'~/Content/Images/Products/airpodMaxBlue.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF

