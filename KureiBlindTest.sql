-- MySQL dump 10.13  Distrib 9.0.0, for Win64 (x86_64)
--
-- Host: localhost    Database: KureiBlindTest
-- ------------------------------------------------------
-- Server version	8.0.39-0ubuntu0.22.04.1

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
-- Table structure for table `GENRES`
--

DROP TABLE IF EXISTS `GENRES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `GENRES` (
  `idGenre` int NOT NULL AUTO_INCREMENT,
  `nameGenre` varchar(250) NOT NULL,
  PRIMARY KEY (`idGenre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `GENRES`
--

LOCK TABLES `GENRES` WRITE;
/*!40000 ALTER TABLE `GENRES` DISABLE KEYS */;
INSERT INTO `GENRES` VALUES (1,'Rock'),(2,'HipHop'),(3,'Pop');
/*!40000 ALTER TABLE `GENRES` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `SONGS`
--

DROP TABLE IF EXISTS `SONGS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `SONGS` (
  `idSong` int NOT NULL AUTO_INCREMENT,
  `nameSong` varchar(250) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `artistSong` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `idGenre` int NOT NULL,
  `song` longtext NOT NULL,
  PRIMARY KEY (`idSong`),
  KEY `SONGS_GENRES_FK` (`idGenre`),
  CONSTRAINT `SONGS_GENRES_FK` FOREIGN KEY (`idGenre`) REFERENCES `GENRES` (`idGenre`)
) ENGINE=InnoDB AUTO_INCREMENT=240 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `SONGS`
--

LOCK TABLES `SONGS` WRITE;
/*!40000 ALTER TABLE `SONGS` DISABLE KEYS */;
INSERT INTO `SONGS` VALUES (5,'Smells Like Teen Spirit','Nirvana',1,'https://www.youtube.com/watch?v=hTWKbfoikeg'),(8,'Feel Good Inc.','Gorillaz',1,'https://www.youtube.com/watch?v=HyHNuVaZJ-k'),(14,'Bohemian Rhapsody','Queen',1,'https://www.youtube.com/watch?v=fJ9rUzIMcZQ'),(15,'Wonderwall','Oasis',1,'https://www.youtube.com/watch?v=6hzrDeceEKc'),(62,'Highway to Hell','AC/DC',1,'https://www.youtube.com/watch?v=l482T0yNkeo'),(68,'Enter Sandman','Metallica',1,'https://www.youtube.com/watch?v=CD-E-LDc384'),(70,'Smells Like Teen Spirit','Nirvana',1,'https://www.youtube.com/watch?v=hTWKbfoikeg'),(100,'The vampyre of tyme and memory','Queens',1,'https://youtu.be/MRC1RWqHwtU?si=GJzQtUkjTWFGVdNU'),(101,'Twisted Transistor','Korn',1,'https://youtu.be/o7uGPWFwg1I?si=78MXGWsvw6y1HEcc'),(102,'Broken','Gorillaz',1,'https://www.youtube.com/watch?v=crC4DKiKPYY'),(103,'Cigaro','System of a down',1,'https://www.youtube.com/watch?v=L4M98z22pgI'),(104,'Stairway to Heaven','Led Zeppelin',1,'https://www.youtube.com/watch?v=QkF3oxziUI4'),(110,'Born to Run','Bruce Springsteen',1,'https://www.youtube.com/watch?v=IxuThNgl3YA'),(111,'Livin\' on a Prayer','Bon Jovi',1,'https://www.youtube.com/watch?v=lDK9QqIzhwk'),(124,'Eye of the Tiger','Survivor',1,'https://www.youtube.com/watch?v=btPJPFnesV4'),(157,'Do I Wanna Know?','Arctic Monkeys',1,'https://www.youtube.com/watch?v=bpOSxM0rNPM'),(161,'Bitter Sweet Symphony','The Verve',1,'https://www.youtube.com/watch?v=1lyu1KKwC74'),(166,'The Pretender','Foo Fighters',1,'https://www.youtube.com/watch?v=SBjQ9tuuTJQ'),(168,'The Sound of Silence','Disturbed',1,'https://www.youtube.com/watch?v=u9Dg-g7t2l4'),(170,'Radioactive','Imagine Dragons',1,'https://www.youtube.com/watch?v=ktvTqknDobU'),(194,'Chop Suey!','System of a Down',1,'https://www.youtube.com/watch?v=CSvFpBOe8eY'),(197,'Numb','Linkin Park',1,'https://www.youtube.com/watch?v=kXYiU_JCYtU'),(212,'Nookie','Limp Bizkit',1,'https://youtu.be/JTMVOzPPtiw?si=IdAxvW9WUTBv3r2s'),(213,'Master of puppets','Metallica',1,'https://youtu.be/E0ozmU9cJDg?si=Zuz0k_QDilHxdTCZ'),(214,'Bombtrack','Rage against the machine',1,'https://youtu.be/MUaL1FnotRQ?si=2FTey2IG2l3BrGU3'),(215,'My Generation','Limp Bizkit',1,'https://youtu.be/BE9CXWV1alg?si=8jl92239r9HE2J9a'),(216,'In Your World','Muse',1,'https://youtu.be/lqmTQnW01qc?si=ysV2m1WV5iJFYdbU'),(217,' I-E-A-I-A-I-O','System of a down',1,'https://youtu.be/eudOwe3Rz-0?si=MSt6_Rod0PcQmZXq'),(218,'Teddy Picker','Arctic Monkeys',1,'https://youtu.be/VredAgNScOw?si=SO4MPbvA_hv_2q9h'),(219,'Balaclava','Arctic Monkeys',1,'https://youtu.be/GeyA2L5LNBk?si=T9sF2GwsB6OIW8XC'),(220,'Go With the Flow','Queens',1,'https://youtu.be/DcHKOC64KnE?si=cKQcGxleiuHePAJW'),(221,'Freak on a Leash','Korn',1,'https://youtu.be/kAwCPpiiEQY?si=01hlt-S9mY-Teo9N'),(222,'Funky Monks','Red Hot',1,'https://youtu.be/vGMqOhXtIa0?si=68FI2vt8s0gKTMGp'),(223,'No One Knows','Queens',1,'https://youtu.be/OM0z2C0sMxI?si=8vdChfb3zbBijEbE'),(224,'If You Were There, Beware\r\n','Arctic Monkeys',1,'https://youtu.be/wU0UbTDxABI?si=Hyg3NmYeDlPbQtBk'),(225,'B.Y.O.B.','System of a down',1,'https://youtu.be/CwiNlXybbrI?si=KKTHuuFbUbK55trb'),(226,'Tornado of souls','Megadeth',1,'https://youtu.be/L8HhOMNrulE?si=Ke1NauJeadZ1LmGf'),(227,'Got the Life','Korn',1,'https://youtu.be/ay4ScWSmOgg?si=MzEr_9-fPyobxbYY'),(228,'Trash','Korn',1,'https://youtu.be/oH9qfBQZYSo?si=8zsGBsJwCOBrjZw_'),(229,'Show me how to live','Audioslave',1,'https://youtu.be/gquZ01Yrhzg?si=7LUQ0tPCDl0Jq3qZ'),(230,'Suck my kiss','Red Hot',1,'https://youtu.be/H0FEuG07Zas?si=SKUDkr0IaUNVpNqU'),(231,'Justin','Korn',1,'https://youtu.be/1RX_ZzbptoU?si=9yNzBFAhdQijV_yX'),(232,'Blood Sugar Sex Magik','Red Hot',1,'https://youtu.be/Sl1QCusosNs?si=ff4dETIP8Jce7sQI'),(233,'Rollin','Limp Bizkit',1,'https://youtu.be/AcWygF_e_2M?si=4UvIqKc6BIMVLzOZ'),(234,'Iron Maiden','The Trooper',1,'https://youtu.be/t24ij5kI2cg?si=Vt3HwU2_cB7gDyWf'),(235,'Even Flow','Pearl Jam',1,'https://youtu.be/tkbgtVFlyCQ?si=uYJJnETpZbRx61bU'),(236,'Hysteria','Muse',1,'https://youtu.be/3dm_5qWWDV8?si=Dh4OMBF_hE0sdGx1'),(237,'Aerials','System of a down',1,'https://youtu.be/zk62uUqcNyo?si=UYBAuCYgHjq5_rck'),(238,'All my life','Foo Fighters',1,'https://youtu.be/YqYYgeeqRLo?si=K1Ocgzj967qiDzyJ'),(239,'Whenever i may roam','Metallica',1,'https://youtu.be/Z-cEyiM9adE?si=Npj_6psEr8s1mEje');
/*!40000 ALTER TABLE `SONGS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'KureiBlindTest'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-10-25 14:11:04
