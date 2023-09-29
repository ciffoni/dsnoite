-- MySqlBackup.NET 2.3.8.0
-- Dump Time: 2023-09-28 21:03:56
-- --------------------------------------
-- Server version 10.4.24-MariaDB mariadb.org binary distribution



CREATE DATABASE IF NOT EXISTS `testando` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `testando`;



/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of perfil
-- 

DROP TABLE IF EXISTS `perfil`;
CREATE TABLE IF NOT EXISTS `perfil` (
  `id_perfil` int(2) NOT NULL AUTO_INCREMENT,
  `perfil` varchar(60) NOT NULL,
  PRIMARY KEY (`id_perfil`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table perfil
-- 

/*!40000 ALTER TABLE `perfil` DISABLE KEYS */;
INSERT INTO `perfil`(`id_perfil`,`perfil`) VALUES(1,'usuario'),(2,'administrador');
/*!40000 ALTER TABLE `perfil` ENABLE KEYS */;

-- 
-- Definition of produto
-- 

DROP TABLE IF EXISTS `produto`;
CREATE TABLE IF NOT EXISTS `produto` (
  `cod_prod` int(4) NOT NULL AUTO_INCREMENT,
  `desc_prod` varchar(60) DEFAULT NULL,
  `preco_prod` decimal(7,2) DEFAULT NULL,
  `qtde_prod` int(11) DEFAULT NULL,
  `perecivel` tinyint(1) DEFAULT NULL,
  `dat_validade` date DEFAULT NULL,
  `foto` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`cod_prod`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table produto
-- 

/*!40000 ALTER TABLE `produto` DISABLE KEYS */;
INSERT INTO `produto`(`cod_prod`,`desc_prod`,`preco_prod`,`qtde_prod`,`perecivel`,`dat_validade`,`foto`) VALUES(1,'Coca cola 500 ml',6.70,1,0,'2023-08-14 00:00:00','C:\\Users\\aluno\\Documents\\GitHub\\dsnoite\\produto\\cocacola500ml.jpg');
/*!40000 ALTER TABLE `produto` ENABLE KEYS */;

-- 
-- Definition of usuario
-- 

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE IF NOT EXISTS `usuario` (
  `idusuario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) DEFAULT NULL,
  `senha` varchar(42) DEFAULT NULL,
  `id_perfil` int(2) NOT NULL,
  `email` varchar(75) NOT NULL,
  PRIMARY KEY (`idusuario`),
  KEY `FK_perfil` (`id_perfil`),
  CONSTRAINT `FK_perfil` FOREIGN KEY (`id_perfil`) REFERENCES `perfil` (`id_perfil`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;

-- 
-- Dumping data for table usuario
-- 

/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario`(`idusuario`,`nome`,`senha`,`id_perfil`,`email`) VALUES(2,'ciffoni','455371f0025c35ffe66b80dc21d05304',2,'ciffoni@gmail.com'),(3,'amanda','a123',2,'');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2023-09-28 21:03:56
-- Total time: 0:0:0:0:136 (d:h:m:s:ms)
