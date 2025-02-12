USE [Project_PRN211]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/9/2023 1:32:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountID] [int] NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[TearcherId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 11/9/2023 1:32:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[TeacherID] [int] NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mark]    Script Date: 11/9/2023 1:32:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mark](
	[Student_ID] [nchar](8) NOT NULL,
	[Type_ID] [int] NOT NULL,
	[Sub_ID] [int] NOT NULL,
	[Point] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC,
	[Type_ID] ASC,
	[Sub_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 11/9/2023 1:32:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [nchar](8) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Dob] [date] NULL,
	[Address] [nvarchar](max) NULL,
	[ClassID] [int] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 11/9/2023 1:32:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[S_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[TeacherID] [int] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[S_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 11/9/2023 1:32:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeachID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeachID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type Point]    Script Date: 11/9/2023 1:32:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type Point](
	[T_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Type Point] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([AccountID], [UserName], [Password], [TearcherId]) VALUES (1, N'CHILP', N'123', 1)
INSERT [dbo].[Account] ([AccountID], [UserName], [Password], [TearcherId]) VALUES (2, N'TUANVM', N'123', 2)
INSERT [dbo].[Account] ([AccountID], [UserName], [Password], [TearcherId]) VALUES (3, N'TATD', N'123', 3)
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ClassID], [Name], [TeacherID]) VALUES (1, N'SE_1514', 1)
INSERT [dbo].[Class] ([ClassID], [Name], [TeacherID]) VALUES (2, N'SE_1623', 1)
INSERT [dbo].[Class] ([ClassID], [Name], [TeacherID]) VALUES (3, N'IS_1712', 2)
INSERT [dbo].[Class] ([ClassID], [Name], [TeacherID]) VALUES (4, N'JS_1755', 2)
INSERT [dbo].[Class] ([ClassID], [Name], [TeacherID]) VALUES (5, N'MKT_1622', 2)
INSERT [dbo].[Class] ([ClassID], [Name], [TeacherID]) VALUES (6, N'IB_1723', 3)
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'123abc. ', 1, 1, 2)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'123abc. ', 1, 4, 1)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'123abc. ', 2, 1, 4.5)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'123abc. ', 3, 1, 4)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121023', 1, 1, 7)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121023', 2, 1, 9.5)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121024', 1, 1, 9)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121024', 1, 4, 10)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121025', 2, 1, 9)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121027', 1, 1, 9.5)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121027', 2, 1, 4)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE121027', 3, 1, 3)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE141022', 1, 1, 7.5)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE141022', 2, 1, 8)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE141022', 3, 1, 6)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE141022', 4, 1, 7.5)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'HE141022', 5, 1, 7.5)
INSERT [dbo].[Mark] ([Student_ID], [Type_ID], [Sub_ID], [Point]) VALUES (N'He141184', 1, 3, 6.5)
GO
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'1122a   ', N'1212', NULL, NULL, 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'123abc. ', N'123', NULL, NULL, 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE121023', N'Hoắc Kiếm Hoa1', NULL, NULL, 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE121024', N'Nguyen Ngoc Tan', NULL, NULL, 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE121025', N'Hoắc Kiếm Hoa1', NULL, NULL, 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE121027', N'Hoắc Kiếm Hoa1', NULL, NULL, 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE141022', N'Lê Đào Quang Dũng ', CAST(N'2001-06-05' AS Date), N'Hà Nội', 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE141023', N'Hoắc Kiếm Hoa', CAST(N'2001-06-05' AS Date), N'Hà Nội', 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE141024', N'Lê Đào Quang Dũng ', NULL, NULL, 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'He141184', N'Nguyễn Xuân Hùng', NULL, NULL, 3)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE141195', N'Nguyễn Xuân Hùng', NULL, NULL, 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE151020', N'Nguyễn Ngọc Tân', CAST(N'2001-06-07' AS Date), N'Thái Bình', 3)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE151027', N'Nguyễn Văn A', CAST(N'2001-06-07' AS Date), N'Thái Bình', 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE151028', N'Nguyễn Văn C', CAST(N'2001-06-07' AS Date), N'Thái Bình', 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE151029', N'Nguyễn Văn C', CAST(N'2001-06-07' AS Date), N'Thái Bình', 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE151030', N'Nguyễn Văn D', CAST(N'2001-06-07' AS Date), N'Thái Bình', 3)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE151031', N'Nguyễn Văn D', CAST(N'2001-06-07' AS Date), N'Lào Cai', 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE151032', N'Nguyễn Văn K', CAST(N'2001-06-07' AS Date), N'Lào Cai', 3)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE161031', N'Doãn Chí Bình', CAST(N'2001-06-07' AS Date), N'Hưng Yên', 3)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE161035', N'Nguyễn Văn K', CAST(N'2001-06-07' AS Date), N'Hưng Yên', 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE161511', N'Hoàng A Kay', CAST(N'2001-06-07' AS Date), N'Thái Bình', 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE161512', N'Tùng Rinh Rinh', CAST(N'2001-06-07' AS Date), N'Thái Bình', 3)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE171027', N'Nguyễn Văn A', CAST(N'2001-06-07' AS Date), N'Thái Bình', 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HE171028', N'Nguyễn Văn B', CAST(N'2001-06-07' AS Date), N'Lào Cai', 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'HUNGNX  ', N'123123', NULL, NULL, 2)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'SONVH   ', N'SONVH', NULL, NULL, 1)
INSERT [dbo].[Students] ([StudentID], [Name], [Dob], [Address], [ClassID]) VALUES (N'tsnaa   ', N'1', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([S_ID], [Name], [TeacherID]) VALUES (1, N'PRN211    ', 1)
INSERT [dbo].[Subject] ([S_ID], [Name], [TeacherID]) VALUES (2, N'PRN221    ', 2)
INSERT [dbo].[Subject] ([S_ID], [Name], [TeacherID]) VALUES (3, N'PRN231    ', 3)
INSERT [dbo].[Subject] ([S_ID], [Name], [TeacherID]) VALUES (4, N'PMG201c   ', 1)
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeachID], [Name], [Address]) VALUES (1, N'Lê Phương Chi', N'Hà Nội')
INSERT [dbo].[Teacher] ([TeachID], [Name], [Address]) VALUES (2, N'Vương Minh Tuấn', N'Thái Bình')
INSERT [dbo].[Teacher] ([TeachID], [Name], [Address]) VALUES (3, N'Tiện Đình Tá', N'Trung Quốc')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Type Point] ON 

INSERT [dbo].[Type Point] ([T_ID], [Name]) VALUES (1, N'PT1')
INSERT [dbo].[Type Point] ([T_ID], [Name]) VALUES (2, N'PT2')
INSERT [dbo].[Type Point] ([T_ID], [Name]) VALUES (3, N'PT3')
INSERT [dbo].[Type Point] ([T_ID], [Name]) VALUES (4, N'Assiment1')
INSERT [dbo].[Type Point] ([T_ID], [Name]) VALUES (5, N'Assiment2')
INSERT [dbo].[Type Point] ([T_ID], [Name]) VALUES (6, N'Project')
SET IDENTITY_INSERT [dbo].[Type Point] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD FOREIGN KEY([TearcherId])
REFERENCES [dbo].[Teacher] ([TeachID])
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeachID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Teacher]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Students] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Students]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Subject] FOREIGN KEY([Sub_ID])
REFERENCES [dbo].[Subject] ([S_ID])
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Subject]
GO
ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Type Point] FOREIGN KEY([Type_ID])
REFERENCES [dbo].[Type Point] ([T_ID])
GO
ALTER TABLE [dbo].[Mark] CHECK CONSTRAINT [FK_Mark_Type Point]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Class]
GO
ALTER TABLE [dbo].[Subject]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeachID])
GO
