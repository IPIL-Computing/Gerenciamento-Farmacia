-- MySQL dump 10.13  Distrib 5.6.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: farmacia
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `farmacia`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `farmacia` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `farmacia`;

--
-- Table structure for table `medicamento`
--

DROP TABLE IF EXISTS `medicamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medicamento` (
  `idmedicamento` int(11) NOT NULL AUTO_INCREMENT,
  `nomeMedicamento` varchar(255) NOT NULL,
  `categoria` int(11) NOT NULL,
  `qtdEstoque` int(11) NOT NULL,
  `preco` decimal(10,0) NOT NULL,
  `howToUse` text NOT NULL,
  `sideEfects` text NOT NULL,
  PRIMARY KEY (`idmedicamento`),
  KEY `categoria` (`categoria`),
  CONSTRAINT `medicamento_ibfk_1` FOREIGN KEY (`categoria`) REFERENCES `categoria` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicamento`
--

LOCK TABLES `medicamento` WRITE;
/*!40000 ALTER TABLE `medicamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `categoria` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) NOT NULL,
  `descricao` text NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nome_UNIQUE` (`nome`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Antibi?ticos','Medicamentos usados para tratar infec??es bacterianas. Eles funcionam matando ou inibindo o crescimento das bact?rias respons?veis pela infec??o.'),(2,'Anticoagulantes','Medicamentos que ajudam a prevenir a forma??o de co?gulos sangu?neos. Eles s?o usados no tratamento e preven??o de condi??es como trombose venosa profunda, embolia pulmonar e AVC.'),(3,'Analg?sicos','Medicamentos usados para aliviar a dor.'),(4,'Anti?cidos','Medicamentos utilizados para neutralizar o excesso de ?cido no est?mago. Eles aliviam os sintomas de azia, indigest?o e refluxo ?cido.'),(5,'Antial?rgicos','Medicamentos usados para tratar rea??es al?rgicas. Eles ajudam a aliviar os sintomas de alergias sazonais, como espirros, coriza e coceira nos olhos.');
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;


--
-- Table structure for table `venda`
--

DROP TABLE IF EXISTS `venda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `venda` (
  `idVenda` int(11) NOT NULL AUTO_INCREMENT,
  `data` date NOT NULL,
  PRIMARY KEY (`idVenda`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venda`
--

LOCK TABLES `venda` WRITE;
/*!40000 ALTER TABLE `venda` DISABLE KEYS */;
/*!40000 ALTER TABLE `venda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendadetalhes`
--

DROP TABLE IF EXISTS `vendadetalhes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `vendadetalhes` (
  `idDetalhes` int(11) NOT NULL AUTO_INCREMENT,
  `idVenda` int(11) NOT NULL,
  `idMedicamento` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL,
  PRIMARY KEY (`idDetalhes`),
  KEY `idVenda` (`idVenda`),
  KEY `idMedicamento` (`idMedicamento`),
  CONSTRAINT `vendadetalhes_ibfk_1` FOREIGN KEY (`idVenda`) REFERENCES `venda` (`idVenda`),
  CONSTRAINT `vendadetalhes_ibfk_2` FOREIGN KEY (`idMedicamento`) REFERENCES `medicamento` (`idmedicamento`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendadetalhes`
--

LOCK TABLES `vendadetalhes` WRITE;
/*!40000 ALTER TABLE `vendadetalhes` DISABLE KEYS */;
/*!40000 ALTER TABLE `vendadetalhes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-23 23:23:48
