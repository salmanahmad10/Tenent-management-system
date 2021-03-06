USE [TMS_FINAL_DB]
GO
/****** Object:  Table [dbo].[appartment]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[appartment](
	[appartment_number] [int] NOT NULL,
	[appartment_size] [int] NOT NULL,
	[apt_fee] [int] NOT NULL,
	[rental_fee] [int] NOT NULL,
	[building_name] [varchar](50) NOT NULL,
	[available] [bit] NOT NULL,
	[rentStatus] [bit] NOT NULL,
	[tenant_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[appartment_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[building]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[building](
	[building_name] [varchar](50) NOT NULL,
	[address] [varchar](50) NOT NULL,
	[cityStateZip] [int] NOT NULL,
	[landlordId] [int] NOT NULL,
	[totalAppartments] [int] NOT NULL,
	[freeAppartments] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[building_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[idGen]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[idGen](
	[id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inspection]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inspection](
	[apartmentNumber] [int] NOT NULL,
	[inspectionID] [int] NOT NULL,
	[inspectionDate] [date] NOT NULL,
	[inspectionResult] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[inspectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Landlord]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Landlord](
	[landlordId] [int] NOT NULL,
	[password] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[landlordId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lease]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lease](
	[leaseId] [int] NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL,
	[balance] [int] NOT NULL,
	[securityDeposit] [int] NOT NULL,
	[rentalDate] [date] NOT NULL,
	[tenantId] [int] NOT NULL,
	[apartmentNumber] [int] NOT NULL,
	[terminationID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[leaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maintenance]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maintenance](
	[appartmentNumber] [int] NOT NULL,
	[maintenanceID] [int] NOT NULL,
	[maintenanceDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[maintenanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[manager]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[manager](
	[managerID] [int] NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NULL,
	[password] [varchar](50) NOT NULL,
	[landlordID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[managerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[notfication_template]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notfication_template](
	[notification_id] [int] NOT NULL,
	[subject] [varchar](20) NOT NULL,
	[message] [varchar](200) NOT NULL,
	[receiver_type] [varchar](20) NOT NULL,
	[receiver_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[notification_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment](
	[payID] [int] NOT NULL,
	[payDate] [date] NOT NULL,
	[payamount] [int] NOT NULL,
	[rentid] [int] NULL,
	[payMethod] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[payID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[renewal]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[renewal](
	[renewalID] [int] NOT NULL,
	[renewalDate] [date] NOT NULL,
	[renewalPeriod] [varchar](40) NOT NULL,
	[leaseID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[renewalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rent]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rent](
	[rentID] [int] NOT NULL,
	[rentalFee] [int] NOT NULL,
	[lateFee] [int] NOT NULL,
	[daytopay] [date] NOT NULL,
	[leaseID] [int] NULL,
	[payId] [int] NULL,
	[status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[report_template]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[report_template](
	[report_id] [int] NOT NULL,
	[subject] [varchar](20) NOT NULL,
	[message] [varchar](200) NOT NULL,
	[receiver_type] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[staff]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff](
	[staffID] [int] NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[managerID] [int] NOT NULL,
	[fk_staff] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[staffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[staffTenent]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staffTenent](
	[staffId] [int] NOT NULL,
	[tenantId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tenant]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tenant](
	[tenant_id] [int] NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[current_address] [varchar](50) NOT NULL,
	[phone] [int] NOT NULL,
	[ssn] [varchar](20) NULL,
	[appartmentType] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[tenant_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[termination]    Script Date: 05/01/2020 7:33:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[termination](
	[ternimationId] [int] NOT NULL,
	[leavingDate] [date] NOT NULL,
	[leaving_reason] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ternimationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[appartment]  WITH CHECK ADD  CONSTRAINT [fk_building] FOREIGN KEY([building_name])
REFERENCES [dbo].[building] ([building_name])
GO
ALTER TABLE [dbo].[appartment] CHECK CONSTRAINT [fk_building]
GO
ALTER TABLE [dbo].[appartment]  WITH CHECK ADD  CONSTRAINT [fk_tenant] FOREIGN KEY([tenant_id])
REFERENCES [dbo].[tenant] ([tenant_id])
GO
ALTER TABLE [dbo].[appartment] CHECK CONSTRAINT [fk_tenant]
GO
ALTER TABLE [dbo].[building]  WITH CHECK ADD  CONSTRAINT [fk_landlord] FOREIGN KEY([landlordId])
REFERENCES [dbo].[Landlord] ([landlordId])
GO
ALTER TABLE [dbo].[building] CHECK CONSTRAINT [fk_landlord]
GO
ALTER TABLE [dbo].[inspection]  WITH CHECK ADD  CONSTRAINT [fk_inspection] FOREIGN KEY([apartmentNumber])
REFERENCES [dbo].[appartment] ([appartment_number])
GO
ALTER TABLE [dbo].[inspection] CHECK CONSTRAINT [fk_inspection]
GO
ALTER TABLE [dbo].[lease]  WITH CHECK ADD  CONSTRAINT [fk_lease] FOREIGN KEY([tenantId])
REFERENCES [dbo].[tenant] ([tenant_id])
GO
ALTER TABLE [dbo].[lease] CHECK CONSTRAINT [fk_lease]
GO
ALTER TABLE [dbo].[lease]  WITH CHECK ADD  CONSTRAINT [fk_lease_apt] FOREIGN KEY([apartmentNumber])
REFERENCES [dbo].[appartment] ([appartment_number])
GO
ALTER TABLE [dbo].[lease] CHECK CONSTRAINT [fk_lease_apt]
GO
ALTER TABLE [dbo].[lease]  WITH CHECK ADD  CONSTRAINT [fk_lease_ter] FOREIGN KEY([terminationID])
REFERENCES [dbo].[termination] ([ternimationId])
GO
ALTER TABLE [dbo].[lease] CHECK CONSTRAINT [fk_lease_ter]
GO
ALTER TABLE [dbo].[Maintenance]  WITH CHECK ADD  CONSTRAINT [fk_Maintenance] FOREIGN KEY([appartmentNumber])
REFERENCES [dbo].[appartment] ([appartment_number])
GO
ALTER TABLE [dbo].[Maintenance] CHECK CONSTRAINT [fk_Maintenance]
GO
ALTER TABLE [dbo].[manager]  WITH CHECK ADD  CONSTRAINT [fk_manager] FOREIGN KEY([landlordID])
REFERENCES [dbo].[Landlord] ([landlordId])
GO
ALTER TABLE [dbo].[manager] CHECK CONSTRAINT [fk_manager]
GO
ALTER TABLE [dbo].[payment]  WITH CHECK ADD  CONSTRAINT [fk_payment] FOREIGN KEY([rentid])
REFERENCES [dbo].[rent] ([rentID])
GO
ALTER TABLE [dbo].[payment] CHECK CONSTRAINT [fk_payment]
GO
ALTER TABLE [dbo].[renewal]  WITH CHECK ADD  CONSTRAINT [fk_renewal] FOREIGN KEY([leaseID])
REFERENCES [dbo].[lease] ([leaseId])
GO
ALTER TABLE [dbo].[renewal] CHECK CONSTRAINT [fk_renewal]
GO
ALTER TABLE [dbo].[rent]  WITH CHECK ADD  CONSTRAINT [fk_rent] FOREIGN KEY([leaseID])
REFERENCES [dbo].[lease] ([leaseId])
GO
ALTER TABLE [dbo].[rent] CHECK CONSTRAINT [fk_rent]
GO
ALTER TABLE [dbo].[staff]  WITH CHECK ADD FOREIGN KEY([managerID])
REFERENCES [dbo].[manager] ([managerID])
GO
ALTER TABLE [dbo].[staff]  WITH CHECK ADD FOREIGN KEY([managerID])
REFERENCES [dbo].[manager] ([managerID])
GO
ALTER TABLE [dbo].[staffTenent]  WITH CHECK ADD  CONSTRAINT [fk_staffTan] FOREIGN KEY([staffId])
REFERENCES [dbo].[staff] ([staffID])
GO
ALTER TABLE [dbo].[staffTenent] CHECK CONSTRAINT [fk_staffTan]
GO
ALTER TABLE [dbo].[staffTenent]  WITH CHECK ADD  CONSTRAINT [fk_staffTan2] FOREIGN KEY([tenantId])
REFERENCES [dbo].[tenant] ([tenant_id])
GO
ALTER TABLE [dbo].[staffTenent] CHECK CONSTRAINT [fk_staffTan2]
GO
