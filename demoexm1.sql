CREATE DATABASE  IF NOT EXISTS `demoexm1` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `demoexm1`;
-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: demoexm1
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `equipments`
--

DROP TABLE IF EXISTS `equipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipments` (
  `IdEquipment` int NOT NULL,
  `NameEquipment` varchar(255) DEFAULT NULL,
  `TypeEquipment` int DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  `CauseEquipment` varchar(255) DEFAULT NULL,
  `SeriaEquipment` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`IdEquipment`),
  KEY `types_idx` (`TypeEquipment`),
  CONSTRAINT `types` FOREIGN KEY (`TypeEquipment`) REFERENCES `equipmenttypes` (`TypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipments`
--

LOCK TABLES `equipments` WRITE;
/*!40000 ALTER TABLE `equipments` DISABLE KEYS */;
INSERT INTO `equipments` VALUES (1,'Принтер',1,'Цветной принтер','Засоренная дюза','SN123456'),(2,'Компьютер',2,'Ноутбук Lenovo','Не включается','SN789012'),(3,'Монитор',3,'ЖК монитор 22\"','Поврежден экран','SN345678'),(4,'Тест 1',1,'оп','тестирование','1'),(5,'Тест 2',2,'оп','тестирование','2'),(6,'обогцоышшуктмг',1,'кепвмчцук','ПРОБЛЕМА!!!','12345'),(7,'vgvghgb',1,'ghghv','jbgg','wegr');
/*!40000 ALTER TABLE `equipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipmenttypes`
--

DROP TABLE IF EXISTS `equipmenttypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipmenttypes` (
  `TypeId` int NOT NULL,
  `TypeName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`TypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipmenttypes`
--

LOCK TABLES `equipmenttypes` WRITE;
/*!40000 ALTER TABLE `equipmenttypes` DISABLE KEYS */;
INSERT INTO `equipmenttypes` VALUES (1,'Принтер'),(2,'Компьютер'),(3,'Монитор');
/*!40000 ALTER TABLE `equipmenttypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repairequipments`
--

DROP TABLE IF EXISTS `repairequipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `repairequipments` (
  `IdRepairEquipment` int NOT NULL,
  `IdRepair` int DEFAULT NULL,
  `IdEquipment` int DEFAULT NULL,
  `Cost` decimal(10,2) DEFAULT NULL,
  `Status` int DEFAULT NULL,
  `Comment` varchar(255) DEFAULT NULL,
  `Executor` int DEFAULT NULL,
  PRIMARY KEY (`IdRepairEquipment`),
  KEY `IdRepair` (`IdRepair`),
  KEY `IdEquipment` (`IdEquipment`),
  KEY `Executor` (`Executor`),
  KEY `repairequipments_ibfk_4_idx` (`Status`),
  CONSTRAINT `repairequipments_ibfk_1` FOREIGN KEY (`IdRepair`) REFERENCES `repairrequests` (`IdRepairRequest`),
  CONSTRAINT `repairequipments_ibfk_2` FOREIGN KEY (`IdEquipment`) REFERENCES `equipments` (`IdEquipment`),
  CONSTRAINT `repairequipments_ibfk_3` FOREIGN KEY (`Executor`) REFERENCES `users` (`IdUser`),
  CONSTRAINT `repairequipments_ibfk_4` FOREIGN KEY (`Status`) REFERENCES `statusrepairs` (`IdStatusRepairs`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repairequipments`
--

LOCK TABLES `repairequipments` WRITE;
/*!40000 ALTER TABLE `repairequipments` DISABLE KEYS */;
INSERT INTO `repairequipments` VALUES (1,1,1,100.00,1,'Комментарий по ремонту 1',2),(2,2,2,150.00,3,'Комментарий по ремонту 2',2),(3,3,3,120.00,1,'Комментарий по ремонту 3',2),(4,5,5,1223.00,1,'12321',2),(5,6,6,123.00,1,'оеаетпспн',2),(6,8,4,6.00,1,'yb',2);
/*!40000 ALTER TABLE `repairequipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `repairrequests`
--

DROP TABLE IF EXISTS `repairrequests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `repairrequests` (
  `IdRepairRequest` int NOT NULL,
  `DateRequest` date DEFAULT NULL,
  `IdClient` int DEFAULT NULL,
  `Priority` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdRepairRequest`),
  KEY `IdClient` (`IdClient`),
  CONSTRAINT `repairrequests_ibfk_1` FOREIGN KEY (`IdClient`) REFERENCES `users` (`IdUser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `repairrequests`
--

LOCK TABLES `repairrequests` WRITE;
/*!40000 ALTER TABLE `repairrequests` DISABLE KEYS */;
INSERT INTO `repairrequests` VALUES (1,'2022-01-15',1,'Высокий'),(2,'2022-02-20',1,'Средний'),(3,'2022-03-25',1,'Низкий'),(4,'2024-03-14',1,'Высокий'),(5,'2024-03-14',1,'Высокий'),(6,'2024-03-15',1,'Средний'),(7,'2024-03-15',1,'Низкий'),(8,'2024-03-15',1,'Низкий'),(9,'2024-03-15',1,'Низкий');
/*!40000 ALTER TABLE `repairrequests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `RoleId` int NOT NULL,
  `RoleName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Клиент'),(2,'Исполнитель'),(3,'Сотрудник'),(4,'Менеджер');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statusrepairs`
--

DROP TABLE IF EXISTS `statusrepairs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statusrepairs` (
  `IdStatusRepairs` int NOT NULL,
  `StatusName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IdStatusRepairs`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statusrepairs`
--

LOCK TABLES `statusrepairs` WRITE;
/*!40000 ALTER TABLE `statusrepairs` DISABLE KEYS */;
INSERT INTO `statusrepairs` VALUES (1,'В ожидании'),(2,'В работе'),(3,'Выполнен');
/*!40000 ALTER TABLE `statusrepairs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `IdUser` int NOT NULL,
  `NameUser` varchar(100) DEFAULT NULL,
  `SurNameUser` varchar(100) DEFAULT NULL,
  `RoleId` int DEFAULT NULL,
  `PasswordUser` varchar(255) DEFAULT NULL,
  `LoginUser` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdUser`),
  KEY `roles_idx` (`RoleId`),
  CONSTRAINT `roles` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`RoleId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Иван','Иванов',1,'1','ivan_ivanov'),(2,'Петр','Петров',2,'2','petr_petrov'),(3,'Анна','Сидорова',3,'3','anna_sidorova'),(4,'Имя','Фамилия',4,'4','name');
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

-- Dump completed on 2024-04-17 19:10:36
