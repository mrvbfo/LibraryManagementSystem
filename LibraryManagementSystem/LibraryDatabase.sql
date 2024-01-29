CREATE DATABASE  IF NOT EXISTS `mylibrary` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `mylibrary`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mylibrary
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `author` (
  `authorID` int NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `surname` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`authorID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author`
--

LOCK TABLES `author` WRITE;
/*!40000 ALTER TABLE `author` DISABLE KEYS */;
INSERT INTO `author` VALUES (100,'Oguz','Atay'),(101,'Sabahattin','Ali'),(102,'Orhan','Kemal'),(103,'Elif','Safak'),(104,'Kemal','Tahir'),(105,'Fyodor','Dostoyevski'),(106,'Ernest','Hemingway'),(107,'George','Orwell'),(108,'Oscar','Wilde'),(109,'Lev','Tolstoy'),(110,'Zülfü','Livaneli'),(111,'Cemal','Süreya'),(112,'Stefan','Zweig'),(113,'Virginia','Woolf'),(114,'Orhan','Pamuk'),(115,'Ahmet Hamdi','Tanpınar'),(116,'Victor','Hugo'),(117,'Sait Faik','Abasıyanık'),(118,'Ömer','Seyfettin'),(119,'John','Steinback'),(120,'Jack','London'),(121,'Yusuf','Atılgan'),(122,'Peyami','Sefa'),(123,'Nazım','Hikmet'),(124,'Atilla','İlhan');
/*!40000 ALTER TABLE `author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `books`
--

DROP TABLE IF EXISTS `books`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `books` (
  `bookID` int NOT NULL,
  `book_status` int DEFAULT NULL,
  `title` varchar(100) DEFAULT NULL,
  `category_name` varchar(100) DEFAULT NULL,
  `authorID` int DEFAULT NULL,
  `publisherID` int DEFAULT NULL,
  `librarianID` int DEFAULT NULL,
  PRIMARY KEY (`bookID`),
  KEY `authorID` (`authorID`),
  KEY `publisherID` (`publisherID`),
  KEY `librarianID` (`librarianID`),
  CONSTRAINT `books_ibfk_1` FOREIGN KEY (`authorID`) REFERENCES `author` (`authorID`),
  CONSTRAINT `books_ibfk_2` FOREIGN KEY (`publisherID`) REFERENCES `publisher` (`publisherID`),
  CONSTRAINT `books_ibfk_3` FOREIGN KEY (`librarianID`) REFERENCES `librarian` (`librarianID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `books`
--

LOCK TABLES `books` WRITE;
/*!40000 ALTER TABLE `books` DISABLE KEYS */;
INSERT INTO `books` VALUES (1000,1,'Tutunamayanlar','novel',100,6,10001),(1001,1,'Kuyucaklı Yusuf','novel',101,7,10000),(1002,1,'Eskici ve Oğulları','novel',102,4,10000),(1003,1,'Ustam ve Ben','novel',103,8,10000),(1004,1,'Devlet Ana','novel',104,9,10000),(1006,1,'Yeraltından Notlar','novel',105,10,10002),(1007,1,'Kafamda Bir Tuhaflık','novel',114,7,10001),(1008,1,'Çanlar Kimin İçin Çalıyor','novel',106,3,10002),(1009,1,'Yaşlı Adam ve Deniz','novel',106,3,10003),(1010,1,'1984','novel',107,2,10002),(1011,1,'Hayvan Çiftliği','novel',107,2,10001),(1012,1,'Mutlu Prens','novel',108,10,10003),(1013,2,'Anna Karenina','novel',109,10,10000),(1014,1,'Huzursuzluk','novel',110,8,10001),(1015,1,'Sevda Sözleri','poem',111,7,10002),(1016,1,'Satranç','novel',112,10,10003),(1017,1,'Sefiller','novel',116,10,10002),(1018,1,'Seçme Hikayeler','story',117,10,10001),(1019,1,'Falaka','novel',118,11,10000);
/*!40000 ALTER TABLE `books` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `borrow`
--

DROP TABLE IF EXISTS `borrow`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `borrow` (
  `borrowID` int NOT NULL,
  `delay_fine` int DEFAULT NULL,
  `due_date` date DEFAULT NULL,
  `issue_date` date DEFAULT NULL,
  `return_date` date DEFAULT NULL,
  `bookID` int DEFAULT NULL,
  `memberID` int DEFAULT NULL,
  PRIMARY KEY (`borrowID`),
  KEY `bookID` (`bookID`),
  KEY `memberID` (`memberID`),
  CONSTRAINT `borrow_ibfk_1` FOREIGN KEY (`bookID`) REFERENCES `books` (`bookID`),
  CONSTRAINT `borrow_ibfk_2` FOREIGN KEY (`memberID`) REFERENCES `member` (`memberID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `borrow`
--

LOCK TABLES `borrow` WRITE;
/*!40000 ALTER TABLE `borrow` DISABLE KEYS */;
INSERT INTO `borrow` VALUES (11000,0,'2024-01-02','2023-12-26','2024-01-04',1000,100000),(11001,0,'2024-01-02','2023-12-26','2024-01-04',1001,100001),(11002,0,'2024-01-06','2023-12-30','2024-01-05',1001,100000),(11003,0,'2024-01-07','2023-12-30','2024-01-01',1000,100000),(11004,0,'2024-01-06','2023-12-30','2024-01-02',1004,100001),(11005,0,'2024-01-07','2023-12-30','2024-01-02',1004,100001),(11006,0,'2024-01-07','2023-12-30','2024-01-01',1006,100002),(11007,0,'2024-01-07','2023-12-30','2023-12-31',1000,100002),(11008,0,'2024-01-05','2023-12-30','2024-01-07',1002,100002),(11009,0,'2024-01-05','2023-12-30','2024-01-07',1003,100001),(11010,0,'2024-01-02','2023-12-30','2024-01-03',1001,100003),(11011,0,'2024-01-06','2023-12-30','2024-01-08',1003,100002),(11012,0,'2024-01-07','2023-12-30','2024-01-08',1004,100003),(11013,0,'2024-01-02','2023-12-30','2024-01-03',1000,100000),(11014,0,'2024-01-03','2023-12-30','2024-01-04',1000,100000),(11015,0,'2023-12-31','2023-12-30','2024-01-02',1003,100000),(11016,0,'2024-01-05','2023-12-30','2024-01-04',1004,100000),(11017,0,'2024-01-21','2024-01-14','2024-01-23',1004,1000004),(11018,0,'2024-01-24','2024-01-17','2024-01-25',1014,1034),(11019,0,'2024-01-19','2024-01-17',NULL,1013,1034),(11020,200,'2024-01-20','2024-01-18','2024-01-22',1010,100003);
/*!40000 ALTER TABLE `borrow` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `librarian`
--

DROP TABLE IF EXISTS `librarian`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `librarian` (
  `librarianID` int NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `surname` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phone_no` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`librarianID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `librarian`
--

LOCK TABLES `librarian` WRITE;
/*!40000 ALTER TABLE `librarian` DISABLE KEYS */;
INSERT INTO `librarian` VALUES (10000,'Deniz','Yilmaz','deniz@example.com','İstanbul','123456789','12345'),(10001,'İrem','Gündüz','irem@example.com','Bursa','1234567891','12345'),(10002,'Hatice','Senol','hatice@example.com','Kocaeli','1234567898','12345'),(10003,'İsmail','Taspinar','ismail@example','Bursa','1234567890','12345');
/*!40000 ALTER TABLE `librarian` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `login`
--

DROP TABLE IF EXISTS `login`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `login` (
  `name` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login`
--

LOCK TABLES `login` WRITE;
/*!40000 ALTER TABLE `login` DISABLE KEYS */;
/*!40000 ALTER TABLE `login` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `member`
--

DROP TABLE IF EXISTS `member`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `member` (
  `memberID` int NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `surname` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` varchar(100) DEFAULT NULL,
  `phone_no` varchar(100) DEFAULT NULL,
  `librarianID` int DEFAULT NULL,
  PRIMARY KEY (`memberID`),
  KEY `librarianID` (`librarianID`),
  CONSTRAINT `member_ibfk_1` FOREIGN KEY (`librarianID`) REFERENCES `librarian` (`librarianID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `member`
--

LOCK TABLES `member` WRITE;
/*!40000 ALTER TABLE `member` DISABLE KEYS */;
INSERT INTO `member` VALUES (1034,'Hakan','Gündüz','hakan@examle.com','kocaeli','586989',10001),(100000,'Merve','Fenerci','merve@example.com','Kocaeli','1234567892',10000),(100001,'Selin','Kulavuz','selin@example.com','Antalya','1234567893',10001),(100002,'Ebru','Dagdelen','ebru@hotmail.com','Antalya','1234567895',10001),(100003,'Havva','Cetin','havva@hotmail.com','Afyon','1234567896',10000),(1000004,'Bugra','Kulavuz','bugra@example.com','Antalya','123464664',10000);
/*!40000 ALTER TABLE `member` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publisher`
--

DROP TABLE IF EXISTS `publisher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `publisher` (
  `publisherID` int NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`publisherID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publisher`
--

LOCK TABLES `publisher` WRITE;
/*!40000 ALTER TABLE `publisher` DISABLE KEYS */;
INSERT INTO `publisher` VALUES (1,'pegasus'),(2,'can'),(3,'bilgi'),(4,'everest'),(5,'epsilon'),(6,'iletisim'),(7,'yapi kredi'),(8,'dogan'),(9,'ithaki'),(10,'is bankasi'),(11,'altın'),(12,'remzi');
/*!40000 ALTER TABLE `publisher` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-29 18:31:11
