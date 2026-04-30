-- MySQL dump 10.13  Distrib 9.7.0, for Win64 (x86_64)
--
-- Host: localhost    Database: himashift
-- ------------------------------------------------------
-- Server version	9.7.0

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `absen`
--

DROP TABLE IF EXISTS `absen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `absen` (
  `id_absen` bigint unsigned NOT NULL AUTO_INCREMENT,
  `jenis_absen` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `mulai` datetime DEFAULT NULL,
  `akhir` datetime DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_absen`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `absen`
--

LOCK TABLES `absen` WRITE;
/*!40000 ALTER TABLE `absen` DISABLE KEYS */;
/*!40000 ALTER TABLE `absen` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `divisi`
--

DROP TABLE IF EXISTS `divisi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `divisi` (
  `id_divisi` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `nama_divisi` varchar(100) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_divisi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `divisi`
--

LOCK TABLES `divisi` WRITE;
/*!40000 ALTER TABLE `divisi` DISABLE KEYS */;
INSERT INTO `divisi` VALUES ('DU','Dana Usaha','2026-04-29 10:40:56','2026-04-29 10:40:56'),('HM','Hubungan Masyarakat','2026-04-29 10:40:56','2026-04-29 10:40:56'),('MB','Minat dan Bakat','2026-04-29 10:40:56','2026-04-29 10:40:56'),('MI','Media dan Informasi','2026-04-29 10:40:56','2026-04-29 10:40:56'),('PS','Pengembangan Sumber Daya Anggota','2026-04-29 10:40:56','2026-04-29 10:40:56'),('RT','Riset dan Teknologi','2026-04-29 10:40:56','2026-04-29 10:40:56'),('SA','Sosial dan Agama','2026-04-29 10:40:56','2026-04-29 10:40:56');
/*!40000 ALTER TABLE `divisi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event` (
  `id_acara` bigint unsigned NOT NULL AUTO_INCREMENT,
  `nama_acara` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tanggal` date NOT NULL,
  `ketua_pelaksana` varchar(70) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id_acara`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
INSERT INTO `event` VALUES (1,'Welcome Maru','2022-09-04','Saddam Husein','2026-04-29 10:40:57','2026-04-29 10:40:57'),(2,'Makrab akt 2022','2022-12-03','Sahdan Wira','2026-04-29 10:40:57','2026-04-29 10:40:57'),(3,'SI wisuda 102','2023-01-21','Dzaky Athaullah Rajasa','2026-04-29 10:40:57','2026-04-29 10:40:57'),(4,'SI Goes To School','2023-01-06','Putra Indi Apriliano','2026-04-29 10:40:57','2026-04-29 10:40:57'),(5,'Training Dasar Organisasi','2023-03-11','Ayatul Rahmat Tajri','2026-04-29 10:40:57','2026-04-29 10:40:57'),(6,'Bukber Himasi','2023-04-10','Adrian Rahmad','2026-04-29 10:40:57','2026-04-29 10:40:57'),(7,'SI wisuda 103','2023-05-20','Usman Kamarudin','2026-04-29 10:40:57','2026-04-29 10:40:57'),(8,'Dies Natalis SI 10th','2023-06-08','M Saddam Abdillah','2026-04-29 10:40:57','2026-04-29 10:40:57');
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `failed_jobs`
--

DROP TABLE IF EXISTS `failed_jobs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `failed_jobs` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `uuid` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `connection` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `queue` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `payload` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `exception` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `failed_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `failed_jobs_uuid_unique` (`uuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `failed_jobs`
--

LOCK TABLES `failed_jobs` WRITE;
/*!40000 ALTER TABLE `failed_jobs` DISABLE KEYS */;
/*!40000 ALTER TABLE `failed_jobs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kehadiran`
--

DROP TABLE IF EXISTS `kehadiran`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kehadiran` (
  `nim` varchar(9) COLLATE utf8mb4_unicode_ci NOT NULL,
  `id_absen` bigint unsigned NOT NULL,
  `status_kehadiran` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`nim`,`id_absen`),
  KEY `kehadiran_id_absen_foreign` (`id_absen`),
  CONSTRAINT `kehadiran_id_absen_foreign` FOREIGN KEY (`id_absen`) REFERENCES `absen` (`id_absen`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `kehadiran_nim_foreign` FOREIGN KEY (`nim`) REFERENCES `mahasiswa` (`nim`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kehadiran`
--

LOCK TABLES `kehadiran` WRITE;
/*!40000 ALTER TABLE `kehadiran` DISABLE KEYS */;
/*!40000 ALTER TABLE `kehadiran` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mahasiswa`
--

DROP TABLE IF EXISTS `mahasiswa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mahasiswa` (
  `nim` varchar(9) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(20) COLLATE utf8mb4_unicode_ci NOT NULL,
  `nama` varchar(70) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`nim`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mahasiswa`
--

LOCK TABLES `mahasiswa` WRITE;
/*!40000 ALTER TABLE `mahasiswa` DISABLE KEYS */;
INSERT INTO `mahasiswa` VALUES ('F1E120002','12345678','Tarisa','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120004','12345678','Valezza Juliani Arnflk','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120006','12345678','Arif Chandra Firmansynh','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120007','12345678','Muhammad Firly Ramadhan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120008','12345678','Delvit Armandani','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120010','12345678','Tien Rama Pakpahan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120016','12345678','Najml Laila','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120019','12345678','Aisyah Sabrina','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120022','12345678','M.Ari Saputra','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120023','12345678','Sahdan Wira','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120026','12345678','Christina Mutiara Ishak','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120032','12345678','Natasya Yonike Ambarita','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120037','12345678','Sahrul Ikhwan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120038','12345678','Harul Risina Siagian','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120040','12345678','Ricky Maulana Sinurat','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120046','12345678','Muhamad Sadam Abdillah H','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120049','12345678','Amanda Stiawan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120051','12345678','Najwa Aulla Saphana','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120052','12345678','Julian Fahrizu','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120053','12345678','M.Syahan Afdhal Hadaya','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120054','12345678','Muhamad Arrafi','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120057','12345678','Ragyl Mohammad Haekal','2026-04-29 10:40:55','2026-04-29 10:40:55'),('F1E120058','12345678','Rizkl Dafta Muttaqin','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120061','12345678','Saddam Hussein','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120063','12345678','Dito Firmansyach','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120064','12345678','Putra Indi Apriliano','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120065','12345678','Rahmad Adrian','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120067','12345678','Zikri Hanan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120072','12345678','Robby Yehezklel Pardomuan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121006','12345678','Elisa Novitayanah','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121009','12345678','Tria Eka Lestari','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121010','12345678','Kiki Aulla Oriza','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121012','12345678','Dina Veronika','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121015','12345678','Farisyah Lutfiah Hanis','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121016','12345678','Dzaky Athaulla Rajasa','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121030','12345678','Ayatul Rahmat Tajri','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121039','12345678','Sahrul Gunawan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121041','12345678','Sri Sullstina','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121046','12345678','Raka Firmansyah','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121049','12345678','Iqbal Revianda','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121054','12345678','Reni Triyaningsih','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121055','12345678','Nurhaliza','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121059','12345678','Adfa Aditiya','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121067','12345678','Rabdiansya','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121070','12345678','Jumiati Sadiah','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121082','12345678','Opinur Destiana','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121086','12345678','Nabilah Ramalia','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121091','12345678','Usman Kamaruddin','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121092','12345678','Imelda Raudati','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121095','12345678','Ayu Indryani','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121098','12345678','Najla Muthia Khansa','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121106','12345678','Katrin Apriayu Napitu','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121111','12345678','Yosika Dian Saputri','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121112','12345678','TITIN PRATIWI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121116','12345678','Kelvin Adinata','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121119','12345678','Divo Rio Gllang','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121127','12345678','Sava Cavan Wiharja','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121132','12345678','Audrey Michelle Vincentine Pelealu','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121133','12345678','Yuda Fatoni','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121138','12345678','Muhammad Gema Ramadhan','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121147','12345678','Rahul Marcellino Holis','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121151','12345678','Dini Safitri','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121153','12345678','Diah Ambarwati','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121160','12345678','Alfadli Rahmat Putra','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121162','12345678','M.Hazron Redian','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121164','12345678','Umar Al Masjid','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121165','12345678','Alyudha Maryon','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121168','12345678','Ketri Genes Yolanda','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121170','12345678','Khairinnisa Putri.Z','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121177','12345678','Sukaya Uliza','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121178','12345678','Rachmelia Rarnadhana','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121181','12345678','Jesica Pitos Dwi Putri','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121185','12345678','TIAS LUFIANI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121187','12345678','Grishelda Ulfariyan Revaly','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121189','12345678','Reidila Ariska Widya','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121191','12345678','Julin Wulandari','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121194','12345678','Riska Rahma Sari','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121198','12345678','Devano Danendra','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121218','12345678','Agnes Wulan Dari','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121220','12345678','Rifki Iskandar','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121221','12345678','M.Hakan Haekal','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121228','12345678','Ajeng Ayu Larasati','2026-04-29 10:40:56','2026-04-29 10:40:56');
/*!40000 ALTER TABLE `mahasiswa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mahasiswa_divisi`
--

DROP TABLE IF EXISTS `mahasiswa_divisi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mahasiswa_divisi` (
  `nim` varchar(9) COLLATE utf8mb4_unicode_ci NOT NULL,
  `id_divisi` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`nim`,`id_divisi`),
  KEY `mahasiswa_divisi_id_divisi_foreign` (`id_divisi`),
  CONSTRAINT `mahasiswa_divisi_id_divisi_foreign` FOREIGN KEY (`id_divisi`) REFERENCES `divisi` (`id_divisi`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `mahasiswa_divisi_nim_foreign` FOREIGN KEY (`nim`) REFERENCES `mahasiswa` (`nim`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mahasiswa_divisi`
--

LOCK TABLES `mahasiswa_divisi` WRITE;
/*!40000 ALTER TABLE `mahasiswa_divisi` DISABLE KEYS */;
INSERT INTO `mahasiswa_divisi` VALUES ('F1E120002','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120004','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120006','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120007','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120008','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120010','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120016','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120019','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120022','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120023','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120026','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120032','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120037','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120038','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120040','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120046','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120049','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120051','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120052','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120053','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120054','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120057','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120058','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120061','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120063','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120064','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120065','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120067','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E120072','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121006','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121009','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121010','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121012','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121015','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121016','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121030','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121039','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121041','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121046','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121049','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121054','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121055','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121059','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121067','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121070','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121082','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121086','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121091','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121092','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121095','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121098','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121106','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121111','MB','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121112','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121116','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121119','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121127','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121132','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121133','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121138','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121147','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121151','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121153','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121160','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121162','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121164','MI','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121165','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121168','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121170','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121177','PS','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121178','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121181','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121185','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121187','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121189','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121191','SA','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121194','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121198','RT','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121218','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121220','DU','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121221','HM','2026-04-29 10:40:56','2026-04-29 10:40:56'),('F1E121228','MB','2026-04-29 10:40:56','2026-04-29 10:40:56');
/*!40000 ALTER TABLE `mahasiswa_divisi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `migrations`
--

DROP TABLE IF EXISTS `migrations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `migrations` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `migrations`
--

LOCK TABLES `migrations` WRITE;
/*!40000 ALTER TABLE `migrations` DISABLE KEYS */;
INSERT INTO `migrations` VALUES (1,'2014_10_12_000000_create_users_table',1),(2,'2014_10_12_100000_create_password_reset_tokens_table',1),(3,'2014_10_12_100000_create_password_resets_table',1),(4,'2019_08_19_000000_create_failed_jobs_table',1),(5,'2019_12_14_000001_create_personal_access_tokens_table',1),(6,'2023_06_12_094120_create_mahasiswa_table',1),(7,'2023_06_12_094121_create_absen_table',1),(8,'2023_06_12_094121_create_divisi_table',1),(9,'2023_06_12_094121_create_kehadiran_table',1),(10,'2023_06_12_094121_create_mahasiswa_divisi_table',1),(11,'2023_06_12_094122_create_event_table',1);
/*!40000 ALTER TABLE `migrations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `password_reset_tokens`
--

DROP TABLE IF EXISTS `password_reset_tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `password_reset_tokens` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `password_reset_tokens`
--

LOCK TABLES `password_reset_tokens` WRITE;
/*!40000 ALTER TABLE `password_reset_tokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `password_reset_tokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `password_resets`
--

DROP TABLE IF EXISTS `password_resets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `password_resets` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  KEY `password_resets_email_index` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `password_resets`
--

LOCK TABLES `password_resets` WRITE;
/*!40000 ALTER TABLE `password_resets` DISABLE KEYS */;
/*!40000 ALTER TABLE `password_resets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personal_access_tokens`
--

DROP TABLE IF EXISTS `personal_access_tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personal_access_tokens` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `tokenable_type` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `tokenable_id` bigint unsigned NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `abilities` text COLLATE utf8mb4_unicode_ci,
  `last_used_at` timestamp NULL DEFAULT NULL,
  `expires_at` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `personal_access_tokens_token_unique` (`token`),
  KEY `personal_access_tokens_tokenable_type_tokenable_id_index` (`tokenable_type`,`tokenable_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personal_access_tokens`
--

LOCK TABLES `personal_access_tokens` WRITE;
/*!40000 ALTER TABLE `personal_access_tokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `personal_access_tokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` bigint unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_email_unique` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','rafuplayz123@gmail.com',NULL,'$2y$10$DwIdcsta.mEnpFoUUSVzhupYR8PX6vGR9NcHXksTznCLd5Wk4AkY2',NULL,'2026-04-29 10:40:57','2026-04-29 10:40:57');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-04-30 13:27:09
