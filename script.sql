USE [master]
GO
/****** Object:  Database [ChessDatabase]    Script Date: 14.06.2025 18:51:32 ******/
CREATE DATABASE [ChessDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ChessDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ChessDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ChessDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ChessDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ChessDatabase] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ChessDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ChessDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ChessDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ChessDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ChessDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ChessDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [ChessDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ChessDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ChessDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ChessDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ChessDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ChessDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ChessDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ChessDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ChessDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ChessDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ChessDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ChessDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ChessDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ChessDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ChessDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ChessDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ChessDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ChessDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [ChessDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [ChessDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ChessDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ChessDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ChessDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ChessDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ChessDatabase] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ChessDatabase', N'ON'
GO
ALTER DATABASE [ChessDatabase] SET QUERY_STORE = ON
GO
ALTER DATABASE [ChessDatabase] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ChessDatabase]
GO
/****** Object:  Table [dbo].[Oyuncular]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oyuncular](
	[FideID] [int] NOT NULL,
	[Isim] [nvarchar](50) NOT NULL,
	[Soyisim] [nvarchar](50) NOT NULL,
	[DogumTarihi] [date] NULL,
	[Rating] [int] NULL,
	[UnvanAdi] [nvarchar](10) NULL,
	[UlkeKodu] [char](3) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FideID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Acilislar]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acilislar](
	[AcilisKodu] [char](3) NOT NULL,
	[AcilisAdi] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AcilisKodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnuvalar]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnuvalar](
	[TurnuvaID] [int] IDENTITY(1,1) NOT NULL,
	[TurnuvaAdi] [nvarchar](100) NOT NULL,
	[BaslangicTarihi] [date] NOT NULL,
	[BitisTarihi] [date] NOT NULL,
	[Konum] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TurnuvaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Oyunlar]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Oyunlar](
	[OyunID] [int] IDENTITY(1,1) NOT NULL,
	[TurnuvaID] [int] NOT NULL,
	[BeyazOyuncuID] [int] NOT NULL,
	[SiyahOyuncuID] [int] NOT NULL,
	[AcilisKodu] [char](3) NULL,
	[Notasyon] [text] NOT NULL,
	[OyunSonucu] [nvarchar](10) NOT NULL,
	[OyunTarihi] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OyunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[TurnuvaOyunlari]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- TurnuvaOyunlari
-- Turnuva oyunlarının detaylarını (oyuncular, açılış, sonuç, turnuva adı) gösterir.
CREATE VIEW [dbo].[TurnuvaOyunlari] AS
SELECT 
    o.OyunID,
    t.TurnuvaAdi,
    t.BaslangicTarihi,
    t.BitisTarihi,
    t.Konum,
    ob.Isim AS BeyazIsim,
    ob.Soyisim AS BeyazSoyisim,
    os.Isim AS SiyahIsim,
    os.Soyisim AS SiyahSoyisim,
    a.AcilisAdi,
    o.Notasyon,
    o.OyunSonucu,
    o.OyunTarihi
FROM Oyunlar o
INNER JOIN Turnuvalar t ON o.TurnuvaID = t.TurnuvaID
INNER JOIN Oyuncular ob ON o.BeyazOyuncuID = ob.FideID
INNER JOIN Oyuncular os ON o.SiyahOyuncuID = os.FideID
LEFT JOIN Acilislar a ON o.AcilisKodu = a.AcilisKodu;
GO
/****** Object:  Table [dbo].[Ulkeler]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ulkeler](
	[UlkeKodu] [char](3) NOT NULL,
	[UlkeAdi] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UlkeKodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unvanlar]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unvanlar](
	[UnvanAdi] [nvarchar](10) NOT NULL,
	[Aciklama] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UnvanAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[OyuncuBilgileri]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- OyuncuBilgileri
-- Oyuncuların isim, soyisim, rating, ünvan ve ülke bilgilerini birleştirir.
CREATE VIEW [dbo].[OyuncuBilgileri] AS
SELECT 
    o.FideID,
    o.Isim,
    o.Soyisim,
    o.DogumTarihi,
    o.Rating,
    u.UnvanAdi,
    u.Aciklama AS UnvanAciklama,
    ul.UlkeKodu,
    ul.UlkeAdi
FROM Oyuncular o
LEFT JOIN Unvanlar u ON o.UnvanAdi = u.UnvanAdi
INNER JOIN Ulkeler ul ON o.UlkeKodu = ul.UlkeKodu;
GO
/****** Object:  Table [dbo].[Kitaplar]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitaplar](
	[KitapID] [int] IDENTITY(1,1) NOT NULL,
	[FideID] [int] NOT NULL,
	[KitapAdi] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KitapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[OyuncuKitaplari]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- OyuncuKitaplari view
-- Oyuncuların yazdığı kitapları ve oyuncu bilgilerini listeler.
CREATE VIEW [dbo].[OyuncuKitaplari] AS
SELECT 
    o.FideID,
    o.Isim,
    o.Soyisim,
    k.KitapID,
    k.KitapAdi
FROM Oyuncular o
LEFT JOIN Kitaplar k ON o.FideID = k.FideID;
GO
ALTER TABLE [dbo].[Kitaplar]  WITH CHECK ADD FOREIGN KEY([FideID])
REFERENCES [dbo].[Oyuncular] ([FideID])
GO
ALTER TABLE [dbo].[Oyuncular]  WITH CHECK ADD FOREIGN KEY([UlkeKodu])
REFERENCES [dbo].[Ulkeler] ([UlkeKodu])
GO
ALTER TABLE [dbo].[Oyuncular]  WITH CHECK ADD FOREIGN KEY([UnvanAdi])
REFERENCES [dbo].[Unvanlar] ([UnvanAdi])
GO
ALTER TABLE [dbo].[Oyunlar]  WITH CHECK ADD FOREIGN KEY([AcilisKodu])
REFERENCES [dbo].[Acilislar] ([AcilisKodu])
GO
ALTER TABLE [dbo].[Oyunlar]  WITH CHECK ADD FOREIGN KEY([BeyazOyuncuID])
REFERENCES [dbo].[Oyuncular] ([FideID])
GO
ALTER TABLE [dbo].[Oyunlar]  WITH CHECK ADD FOREIGN KEY([SiyahOyuncuID])
REFERENCES [dbo].[Oyuncular] ([FideID])
GO
ALTER TABLE [dbo].[Oyunlar]  WITH CHECK ADD FOREIGN KEY([TurnuvaID])
REFERENCES [dbo].[Turnuvalar] ([TurnuvaID])
GO
ALTER TABLE [dbo].[Oyuncular]  WITH CHECK ADD CHECK  (([Rating]>=(0)))
GO
ALTER TABLE [dbo].[Oyunlar]  WITH CHECK ADD CHECK  (([OyunSonucu]='1/2-1/2' OR [OyunSonucu]='0-1' OR [OyunSonucu]='1-0'))
GO
ALTER TABLE [dbo].[Turnuvalar]  WITH CHECK ADD CHECK  (([BitisTarihi]>=[BaslangicTarihi]))
GO
/****** Object:  StoredProcedure [dbo].[OyuncununOyunlariniListele]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Oyuncu Oyunlarını Listeleme
CREATE PROCEDURE [dbo].[OyuncununOyunlariniListele]
    @FideID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        o.OyunID,
        t.TurnuvaAdi,
        t.Konum,
        ob.Isim + ' ' + ob.Soyisim AS BeyazOyuncu,
        os.Isim + ' ' + os.Soyisim AS SiyahOyuncu,
        a.AcilisAdi,
        o.OyunSonucu,
        o.OyunTarihi
    FROM Oyunlar o
    INNER JOIN Turnuvalar t ON o.TurnuvaID = t.TurnuvaID
    INNER JOIN Oyuncular ob ON o.BeyazOyuncuID = ob.FideID
    INNER JOIN Oyuncular os ON o.SiyahOyuncuID = os.FideID
    LEFT JOIN Acilislar a ON o.AcilisKodu = a.AcilisKodu
    WHERE o.BeyazOyuncuID = @FideID OR o.SiyahOyuncuID = @FideID
    ORDER BY o.OyunTarihi DESC;
END;
GO
/****** Object:  StoredProcedure [dbo].[TurnuvaIstatistikleri]    Script Date: 14.06.2025 18:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Turnuva Bilgilerini Gösterme
CREATE PROCEDURE [dbo].[TurnuvaIstatistikleri]
    @TurnuvaID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        t.TurnuvaAdi,
        t.BaslangicTarihi,
        t.BitisTarihi,
        t.Konum,
        COUNT(o.OyunID) AS ToplamOyun,
        SUM(CASE WHEN o.OyunSonucu = '1-0' THEN 1 ELSE 0 END) AS BeyazKazandi,
        SUM(CASE WHEN o.OyunSonucu = '0-1' THEN 1 ELSE 0 END) AS SiyahKazandi,
        SUM(CASE WHEN o.OyunSonucu = '1/2-1/2' THEN 1 ELSE 0 END) AS Berabere
    FROM Turnuvalar t
    LEFT JOIN Oyunlar o ON t.TurnuvaID = o.TurnuvaID
    WHERE t.TurnuvaID = @TurnuvaID
    GROUP BY t.TurnuvaAdi, t.BaslangicTarihi, t.BitisTarihi, t.Konum;
END;
GO
USE [master]
GO
ALTER DATABASE [ChessDatabase] SET  READ_WRITE 
GO
