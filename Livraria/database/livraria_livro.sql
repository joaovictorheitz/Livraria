CREATE DATABASE  IF NOT EXISTS `livraria` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `livraria`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: livraria
-- ------------------------------------------------------
-- Server version	8.0.33

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
-- Table structure for table `livro`
--

DROP TABLE IF EXISTS `livro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `livro` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nome` varchar(255) NOT NULL,
  `AutorId` int NOT NULL,
  `CategoriaId` int NOT NULL,
  `EditoraId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `livro_ibfk_2_idx` (`CategoriaId`),
  KEY `livro_ibfk_3_idx` (`EditoraId`),
  KEY `livro_ibfk_1` (`AutorId`),
  CONSTRAINT `livro_ibfk_1` FOREIGN KEY (`AutorId`) REFERENCES `autor` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `livro_ibfk_2` FOREIGN KEY (`CategoriaId`) REFERENCES `categorias` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `livro_ibfk_3` FOREIGN KEY (`EditoraId`) REFERENCES `editora` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=123 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livro`
--

LOCK TABLES `livro` WRITE;
/*!40000 ALTER TABLE `livro` DISABLE KEYS */;
INSERT INTO `livro` VALUES (103,'A Guerra dos Tronos',21,2,2),(104,'O Senhor dos Anéis',23,2,2),(107,'1984',26,1,4),(108,'A Arte da Guerra',35,9,7),(109,'O Conde de Monte Cristo',32,3,3),(110,'O Nome da Rosa',25,5,1),(111,'O Amor nos Tempos do Cólera',25,3,4),(113,'O Iluminado',19,4,4),(114,'Guerra e Paz',33,6,8),(115,'Cem Anos de Solidão',25,3,9),(116,'O Sol é para Todos',27,5,10),(117,'O Pequeno Príncipe',35,3,3),(118,'O Vermelho e o Negro',35,3,1),(119,'A Revolução dos Bichos',26,1,4),(120,'O Grande Gatsby',35,3,6),(121,'Crime e Castigo',33,4,2),(122,'Diário de um banana',18,1,1);
/*!40000 ALTER TABLE `livro` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-06 10:10:43
