-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.1.34-MariaDB-0ubuntu0.18.04.1 - Ubuntu 18.04
-- Server OS:                    debian-linux-gnu
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for sirmotodevel
CREATE DATABASE IF NOT EXISTS `sirmotodevel` /*!40100 DEFAULT CHARACTER SET latin1 COLLATE latin1_general_ci */;
USE `sirmotodevel`;

-- Dumping structure for table sirmotodevel.AspNetRoleClaims
CREATE TABLE IF NOT EXISTS `AspNetRoleClaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext COLLATE latin1_general_ci,
  `ClaimValue` longtext COLLATE latin1_general_ci,
  `RoleId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.AspNetRoleClaims: ~0 rows (approximately)
/*!40000 ALTER TABLE `AspNetRoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoleClaims` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.AspNetRoles
CREATE TABLE IF NOT EXISTS `AspNetRoles` (
  `Id` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `ConcurrencyStamp` longtext COLLATE latin1_general_ci,
  `Name` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `NormalizedName` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.AspNetRoles: ~0 rows (approximately)
/*!40000 ALTER TABLE `AspNetRoles` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetRoles` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.AspNetUserClaims
CREATE TABLE IF NOT EXISTS `AspNetUserClaims` (
  `Id` int(11) NOT NULL,
  `ClaimType` longtext COLLATE latin1_general_ci,
  `ClaimValue` longtext COLLATE latin1_general_ci,
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.AspNetUserClaims: ~0 rows (approximately)
/*!40000 ALTER TABLE `AspNetUserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserClaims` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.AspNetUserLogins
CREATE TABLE IF NOT EXISTS `AspNetUserLogins` (
  `LoginProvider` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `ProviderKey` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `ProviderDisplayName` longtext COLLATE latin1_general_ci,
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.AspNetUserLogins: ~0 rows (approximately)
/*!40000 ALTER TABLE `AspNetUserLogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserLogins` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.AspNetUserRoles
CREATE TABLE IF NOT EXISTS `AspNetUserRoles` (
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `RoleId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.AspNetUserRoles: ~0 rows (approximately)
/*!40000 ALTER TABLE `AspNetUserRoles` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserRoles` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.AspNetUsers
CREATE TABLE IF NOT EXISTS `AspNetUsers` (
  `Id` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `ConcurrencyStamp` longtext COLLATE latin1_general_ci,
  `Email` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `NormalizedEmail` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `PasswordHash` longtext COLLATE latin1_general_ci,
  `PhoneNumber` longtext COLLATE latin1_general_ci,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `SecurityStamp` longtext COLLATE latin1_general_ci,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `UserName` varchar(256) COLLATE latin1_general_ci DEFAULT NULL,
  `Address` longtext COLLATE latin1_general_ci,
  `Birthdate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.AspNetUsers: ~30 rows (approximately)
/*!40000 ALTER TABLE `AspNetUsers` DISABLE KEYS */;
INSERT INTO `AspNetUsers` (`Id`, `AccessFailedCount`, `ConcurrencyStamp`, `Email`, `EmailConfirmed`, `LockoutEnabled`, `LockoutEnd`, `NormalizedEmail`, `NormalizedUserName`, `PasswordHash`, `PhoneNumber`, `PhoneNumberConfirmed`, `SecurityStamp`, `TwoFactorEnabled`, `UserName`, `Address`, `Birthdate`) VALUES
	('0', 0, NULL, NULL, b'0', b'0', NULL, NULL, NULL, NULL, NULL, b'0', NULL, b'0', NULL, NULL, '0001-01-01 00:00:00.000000'),
	('0c7c4997-4db0-410d-bc49-d1cc71680c0d', 0, 'a187b74b-d6ab-40a2-93cb-8e6235542e2e', 'test123@123.com', b'0', b'1', NULL, 'TEST123@123.COM', 'TEST123@123.COM', 'AQAAAAEAACcQAAAAEE9zCfDbQkvU/ST7WsCP0RowcWcJ7P+BrJwWbNMnloK6tEu6fiGXcmK3sOFdEyj+TA==', NULL, b'0', '7ZFKF7IZDRED5B4TJ7FAGZCVGJJUI4Z6', b'0', 'test123@123.com', NULL, '0001-01-01 00:00:00.000000'),
	('11084358-e5fe-4ad6-9994-92a379ea886b', 0, '12adb9db-eb16-4237-8a84-3b0907b0d512', 'a@a.com', b'0', b'1', NULL, 'A@A.COM', 'A@A.COM', 'AQAAAAEAACcQAAAAEPZZkenU5k76wCMauLLMgvSGLXUmZCFs0NqR8vd9Kr/6FU4fKLFIIAhhwGPHXQUWQQ==', NULL, b'0', 'MH5AP256FK3F6GVGBZOBFQXMHDYE6XPK', b'0', 'a@a.com', NULL, '0001-01-01 00:00:00.000000'),
	('26a13167-e762-4280-89f4-7fa9f82ebc95', 0, '983f4ddc-f084-4e4e-9df9-73625398971d', 'ProGardening1@Proclub.com', b'0', b'1', NULL, 'PROGARDENING1@PROCLUB.COM', 'PROGARDENING@PROCLUB.COM', 'AQAAAAEAACcQAAAAENlEsbuCqCzva4tKzZBfToRIviUay7flYauYM70/ekfi6hPhHycGYP9q6NhxNvBY5w==', NULL, b'0', 'DUXNFSASFYU2FAOEXE5B7P7QZYJQHWD2', b'0', 'ProGardening@Proclub.com', NULL, '0001-01-01 00:00:00.000000'),
	('2955ec4d-4de4-4a31-a8b4-eaa2d9a2b246', 0, '4aea9dcc-e424-4f7a-921f-1111eba7afd0', 'deniFlorist@partner.sirmoto.com', b'0', b'1', NULL, 'DENIFLORIST@PARTNER.SIRMOTO.COM', 'DENIFLORIST@PARTNER.SIRMOTO.COM', 'AQAAAAEAACcQAAAAEANbjRrDOjtOBu6AEu889L5em6KbE+xf4WW/IGkzxMGgbb8oufxPt/1yAcdioTwitw==', NULL, b'0', 'BRG2NNEADM4NJSRFHSA6DIBD2FFNBOAP', b'0', 'deniFlorist@partner.sirmoto.com', NULL, '0001-01-01 00:00:00.000000'),
	('2c6a3338-4ecd-4b2c-8e33-a5da8e2bfbda', 0, 'c863ce86-9d74-4c8d-86b2-69ad9dda254f', 'employee3@e.com', b'0', b'1', NULL, 'EMPLOYEE3@E.COM', 'EMPLOYEE3@E.COM', 'AQAAAAEAACcQAAAAEJk7yR3oykHExdsHmZChK6VB1OsS5tXAru/xW0Y64C62HAcRUwG+MuRK3wglRJS/zw==', NULL, b'0', '7INKLQ2KY4O6HVBGGGVSGVIEJPHQTPNU', b'0', 'employee3@e.com', NULL, '0001-01-01 00:00:00.000000'),
	('4bc746d8-557d-4e89-9b5e-5dcd4f668ef0', 0, 'ab49a8de-d49d-4aa7-986f-d9a5e5da6b7d', 'worker3@gmail.com', b'0', b'1', NULL, 'WORKER3@GMAIL.COM', 'WORKER3@GMAIL.COM', 'AQAAAAEAACcQAAAAEEP6QWSR1+UdeE9lYqcWntvEUxFi90LHC8HshijXqfDn1Gboyf6som1qv7/D4LXfKg==', NULL, b'0', 'TTNVZ2HAUR2ONZM2RV5B7N75GG2XMJSG', b'0', 'worker3@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('573a8c50-9caf-4df2-989a-62c7a7551944', 0, '9ef4751c-7a31-4058-92fa-dda50a62f153', 'dadangFlorist@partner.sirmoto.com', b'0', b'1', NULL, 'DADANGFLORIST@PARTNER.SIRMOTO.COM', 'DADANGFLORIST@PARTNER.SIRMOTO.COM', 'AQAAAAEAACcQAAAAEHHB2K6wul+qTfO9+3X+8fp547/DAyS2OTlweW0lSRbmhiqZCECqz2rMP4ZmTR2GyA==', NULL, b'0', 'NNT7AC3PMYKVP24CB6C2FJFPSY6NAFT4', b'0', 'dadangFlorist@partner.sirmoto.com', NULL, '0001-01-01 00:00:00.000000'),
	('596d1b0e-3cd6-46b6-adc4-590ff82908e3', 0, '7b2c19f1-c4e4-4c2f-94de-f081e3d87583', 'zxcvbnm@zxcvbnm.com', b'0', b'1', NULL, 'ZXCVBNM@ZXCVBNM.COM', 'ZXCVBNM@ZXCVBNM.COM', 'AQAAAAEAACcQAAAAEBjNn2ClTOWZYTTIOHu6VixbWZ5OmEEVjoEmQSYqeIYiZa5OWIWT65WYtAUCpiZG8A==', NULL, b'0', '5SSHQMIZIM6HI4AEQ5GLMZPJWSCLS47F', b'0', 'zxcvbnm@zxcvbnm.com', NULL, '0001-01-01 00:00:00.000000'),
	('68f8df5d-bef3-43f1-afea-8df0334e9d01', 0, '85ad3c4a-6b87-47ce-b1ec-1b8f22e9c81a', 'worker2@gmail.com', b'0', b'1', NULL, 'WORKER2@GMAIL.COM', 'WORKER2@GMAIL.COM', 'AQAAAAEAACcQAAAAEIwTpKknYOgeOLg7W14W14Z77rlthRpmHzfCBgh7+uv8QTItGTsTKE4eR1osqmDDNA==', NULL, b'0', 'M4LXZOSIRB7A4XUJQ4PSUF6CJZ7BOPT2', b'0', 'worker2@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('713070ec-40f5-470a-9bbe-f562c0ce5261', 0, '1a23a4e8-ff20-40a0-914c-5a45ded50bb6', 'tester@tester.com', b'0', b'1', NULL, 'TESTER@TESTER.COM', 'TESTER@TESTER.COM', 'AQAAAAEAACcQAAAAEIRn1d+8CNXAs40WXb3Xj4nPZ1K5pyK/RCYf+PP4koGmQkmVGffUPkQKKemlBCwZdQ==', NULL, b'0', 'DOOLO3KLG4Q6KHCRP7RY5B2IOB5MOKYK', b'0', 'tester@tester.com', NULL, '0001-01-01 00:00:00.000000'),
	('72c94293-e873-4a3e-bf89-65ace433fae1', 0, 'ae42e00c-9a21-4a82-94a3-206ae1c4b808', 'qwerty123@qwerty.com', b'0', b'1', NULL, 'QWERTY123@QWERTY.COM', 'QWERTY123@QWERTY.COM', 'AQAAAAEAACcQAAAAEJPzRQT+YcP+ZB72IZOl5/wIvbFHCe+hR4DnND7aw2kz1Z2Rixpy9IK+rm88wHf2dw==', NULL, b'0', 'UJM7PI2JBMO62O3NXHXOQ3VGDMDX66CY', b'0', 'qwerty123@qwerty.com', NULL, '0001-01-01 00:00:00.000000'),
	('78d82fd7-b0ce-4f4f-a0cd-161004ce668b', 0, 'a39833aa-bc74-4a33-bd1b-45521872c89d', 'sudrajatFlorist@partner.sirmoto.com', b'0', b'1', NULL, 'SUDRAJATFLORIST@PARTNER.SIRMOTO.COM', 'SUDRAJATFLORIST@PARTNER.SIRMOTO.COM', 'AQAAAAEAACcQAAAAEAD6AspHwvI36shCM7dNCRqWz/MyfqQfuOfwE89tOPo5dVAiHWxtAvVd9/nRY2USWA==', NULL, b'0', 'SV4DNSAKFMPGXRMWD4ZCD6JAQLUBYPRE', b'0', 'sudrajatFlorist@partner.sirmoto.com', NULL, '0001-01-01 00:00:00.000000'),
	('7f46b146-f1c6-4042-b93d-b15fe46de864', 0, 'eb493bf5-90d8-4ee1-b0e8-ca3e7698a4e2', 'worker6@gmail.com', b'0', b'1', NULL, 'WORKER6@GMAIL.COM', 'WORKER6@GMAIL.COM', 'AQAAAAEAACcQAAAAEIMdv+7h/iN11Ghy9GvCEH23iyKUyq4BW+IeFcRy2O2GsgT3M/fHhPIvnvZ8f7cJZg==', NULL, b'0', 'TO5MRHJHSMLO3YJWK5EZBABA6WDM6VUB', b'0', 'worker6@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('85dca68b-2d06-403b-be79-0732d99a5bf6', 0, '56184421-4edc-45b7-9077-7c0993a5f8c4', 'employee1@e.com', b'0', b'1', NULL, 'EMPLOYEE1@E.COM', 'EMPLOYEE1@E.COM', 'AQAAAAEAACcQAAAAEHaEqmkc9Wc+dA/evVCCFAb7hhnYDDv59fwNEk1ER+WLMYJ2NF/J2EwcZZtgnlW8ow==', NULL, b'0', 'M3XG4VAC5QNGVYU4A2JVTVZJ2DQIFNID', b'0', 'employee1@e.com', NULL, '0001-01-01 00:00:00.000000'),
	('8911ab6d-c5cc-491b-9e27-d968258c22ae', 0, '54f3ae26-d71f-4252-ac19-bd20643fa336', 'telyuGardeningTools@telyu.com', b'0', b'1', NULL, 'TELYUGARDENINGTOOLS@TELYU.COM', 'TELYUGARDENINGTOOLS@TELYU.COM', 'AQAAAAEAACcQAAAAEJ9oLQn6+Np5VQrse2ZUfdAYZkLl24FkVolxTpUYJf62JwtoIFwwUNgEesZPLKUeog==', NULL, b'0', '555QQAYMHEJ5DBEVCQ4RNKUOQTK7GPYI', b'0', 'telyuGardeningTools@telyu.com', NULL, '0001-01-01 00:00:00.000000'),
	('8d7f7adc-5ba2-4c9a-b3cb-c773fce00241', 0, '4ed3fc67-14d4-48ed-a7e1-2081291009d6', 'sirmoto@sirmoto.com', b'0', b'1', NULL, 'SIRMOTO@SIRMOTO.COM', 'SIRMOTO@SIRMOTO.COM', 'AQAAAAEAACcQAAAAEO2pO6033VxIxuEsnCk67UdTpWXGoAS/xl0b34NecZZmRndiuVGlfR41Ps8RX+JKsw==', NULL, b'0', 'YBWVMPXBZF7VCGBMB64WYPJHIUP2I3QP', b'0', 'sirmoto@sirmoto.com', NULL, '0001-01-01 00:00:00.000000'),
	('9bdde49d-a541-4984-bdee-4e12c60b5a6b', 0, 'c461133d-9116-4506-b985-c0a3beb1acf5', 't1ester@tester.com', b'0', b'1', NULL, 'T1ESTER@TESTER.COM', 'T1ESTER@TESTER.COM', 'AQAAAAEAACcQAAAAEGON6RuNkHI+h+bxOZuc8WMZOleySlQVTl7Jarh5OLS+XG33LQJZVXTtwsuDxUc6CA==', NULL, b'0', 'LGURN3FTP45YPNVAED6RKY4NWAAXL7P7', b'0', 't1ester@tester.com', NULL, '0001-01-01 00:00:00.000000'),
	('9c86a07e-5e62-4b85-bf04-495411a0073e', 0, '9f9cccce-dc84-41e6-8da6-80f4de0ac987', 'employee2@e.com', b'0', b'1', NULL, 'EMPLOYEE2@E.COM', 'EMPLOYEE2@E.COM', 'AQAAAAEAACcQAAAAEI/HZNiJnrJDLLfN9lUnGWkuoXVo+757p+hUY+2fSeJTtb8xVSXYMy1TjU0ZbZb4PA==', NULL, b'0', 'TCW4AF355DQYOAE22ULQRGOUYZKOX46I', b'0', 'employee2@e.com', NULL, '0001-01-01 00:00:00.000000'),
	('af6827ea-487c-4c78-a34d-5470697ee139', 0, 'c5f95fc2-aad2-4d00-9afb-c32c12cec986', 'b@b.com', b'0', b'1', NULL, 'B@B.COM', 'B@B.COM', 'AQAAAAEAACcQAAAAEBXxpWzFMIIkHpxPBbQGj9TeKrWnGrunG/kHUdZlSpJBdf6UX+FG/5rW+HdqJHF63Q==', NULL, b'0', 'HXHXO3ONMTWMCVL7IC7IBZSWE3QGCUMH', b'0', 'b@b.com', NULL, '0001-01-01 00:00:00.000000'),
	('b32b391e-d837-49a2-8ce6-2a9bcba8255c', 0, '37b99737-9114-4dca-9e5c-e3cde0acecc3', 'progardening@gmail.com', b'0', b'1', NULL, 'PROGARDENING@GMAIL.COM', 'PROGARDENING@GMAIL.COM', 'AQAAAAEAACcQAAAAEHchD0rmWRA5WGud3kuuFLk79OcG8jbMUdYhSTd+6/9UJbmM3/1CBfkP527mFKmpgg==', NULL, b'0', 'GUZGXUMEKMOOI77XXZFYO2M5UKTUE6KB', b'0', 'progardening@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('b94b2d0d-86a7-4c44-a86a-978a00545103', 0, '2c5541a9-b870-4862-b738-0e0751dbdedc', 'worker4@gmail.com', b'0', b'1', NULL, 'WORKER4@GMAIL.COM', 'WORKER4@GMAIL.COM', 'AQAAAAEAACcQAAAAEH0wMCLqBJdTo0kJwvTXf2wC1Hl85zoNdGZVh9zxYZlccA6EDk3E7aYsQzjpzAxWfw==', NULL, b'0', 'KPKG53INTPNT2RXTLK725FP5ZGR4FSYE', b'0', 'worker4@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('bd2602be-b2d1-4490-825a-2c7305406cff', 0, '68be1fef-bc0f-40e7-89a6-0fc18076dbb3', 'worker1@gmail.com', b'0', b'1', NULL, 'WORKER1@GMAIL.COM', 'WORKER1@GMAIL.COM', 'AQAAAAEAACcQAAAAEOgNusPY6RTXP2fJhvnqs0ybbdhe+4NbVoTTRbpDFqbVYnEDidXNj5u56lKceFvaow==', NULL, b'0', 'Y5ZN2FWRRJPYREFXUH4HSHENW7NHCG2H', b'0', 'worker1@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('c0d28bfc-cd87-4b01-88fd-82fb6ccc678a', 0, 'b1abdcf9-de1b-4341-a1ec-f40c90a28dcc', 'qwerty1234@qwerty.com', b'0', b'1', NULL, 'QWERTY1234@QWERTY.COM', 'QWERTY1234@QWERTY.COM', 'AQAAAAEAACcQAAAAEKJCAc6Uan4gkhSw/nlDf2Ie1uZzeH8y8ib5QyHACsZtvn1WcQtYMKvyZmdZI/Gz0w==', NULL, b'0', 'VPPQ5N6NH6KYYVTIGSNTFWOMQPPCYHCU', b'0', 'qwerty1234@qwerty.com', NULL, '0001-01-01 00:00:00.000000'),
	('cc252fdb-8af3-46f2-90f0-492db669cd30', 0, '7940ee9c-920f-43fa-b2c3-0a3db26a10da', 'bulma1@bulma.com', b'0', b'1', NULL, 'BULMA1@BULMA.COM', 'BULMA1@BULMA.COM', 'AQAAAAEAACcQAAAAECVjv5le5FXNle26lORbTEfT11qE1PnesMH68T5+QEhIjAhp4lAyNPz7SyP5sTLcTA==', NULL, b'0', '3HIRE2OUKOTXUWDR3DNQKVRFK75R3LAZ', b'0', 'bulma1@bulma.com', NULL, '0001-01-01 00:00:00.000000'),
	('d060e91c-7831-4791-89b0-4fb74f6a1fc3', 0, 'bc7e0337-db14-4e4d-8145-20050207507e', 'worker5@gmail.com', b'0', b'1', NULL, 'WORKER5@GMAIL.COM', 'WORKER5@GMAIL.COM', 'AQAAAAEAACcQAAAAEH0sA10msP2t0lviraW08X2FDv2RnHLHioFceLKHSb8bQKVUH7cb3bCPE5Sw8J/RWQ==', NULL, b'0', '7BCPEDXNLZLR233FQUULKAB4YZXGOZAA', b'0', 'worker5@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('daa808f8-6339-4204-a5cb-62a3d9edf072', 0, 'c715a7d8-adb5-455a-8dd9-7519e4940357', 'bannerlord@bannerlord.com', b'0', b'1', NULL, 'BANNERLORD@BANNERLORD.COM', 'BANNERLORD@BANNERLORD.COM', 'AQAAAAEAACcQAAAAEPNPKKqKKphiO16Q3EVcPt05j72+z8/Wvgc78Igta96nOnNusz59W1g2VUimHDoOnA==', NULL, b'0', 'UFTLVUE5APT5WFFSA3SCM3X6EELJRVMC', b'0', 'bannerlord@bannerlord.com', NULL, '0001-01-01 00:00:00.000000'),
	('e9e4a8ac-6847-4d4d-873e-a5e718c15134', 0, 'b34ff25b-a78b-4a2b-9856-28a6117e17c1', 'bulma@bulma.com', b'0', b'1', NULL, 'BULMA@BULMA.COM', 'BULMA@BULMA.COM', 'AQAAAAEAACcQAAAAEPFzQsqOcLYeXQCFeLShyiRFZJdMIKPJOkcgtbrvkNeOx+d5ft6TUypEW6m81ztFpw==', NULL, b'0', 'X6VB3SSMNPLGGTZ7A4Y4ORVLWZQT5KER', b'0', 'bulma@bulma.com', NULL, '0001-01-01 00:00:00.000000'),
	('f3c7559b-f391-4005-b7b9-3f08d8244bbb', 0, 'aee10a17-f620-4e14-87e2-2788eff5c3cb', 'worker8@gmail.com', b'0', b'1', NULL, 'WORKER8@GMAIL.COM', 'WORKER8@GMAIL.COM', 'AQAAAAEAACcQAAAAECTZMoHlRp9YyMu5Jp1behsrmIWdj0Xc/NzA0GI+oGcL4EYtzxpbWvcQphAbcosdRQ==', NULL, b'0', 'WDSZM3ASULP4GFMG6PFXCWKBMCMAJV2P', b'0', 'worker8@gmail.com', NULL, '0001-01-01 00:00:00.000000'),
	('fdc20744-74e0-4dc3-a422-4a6a75f512ef', 0, '978c9658-ce8d-4b15-89bf-f95ce5eb4ad4', 'c@c.com', b'0', b'1', NULL, 'C@C.COM', 'C@C.COM', 'AQAAAAEAACcQAAAAEDL0fNAod28kx0q5xponZQMfT/zdAMNO2u/YN+OgQxWoCB9QX8ACS4lNIIUCRrc5wA==', NULL, b'0', 'QUOQ37VTE2JD33NL2SO23A2YOWAIBQLX', b'0', 'c@c.com', NULL, '0001-01-01 00:00:00.000000');
/*!40000 ALTER TABLE `AspNetUsers` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.AspNetUserTokens
CREATE TABLE IF NOT EXISTS `AspNetUserTokens` (
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `LoginProvider` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Name` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Value` longtext COLLATE latin1_general_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.AspNetUserTokens: ~0 rows (approximately)
/*!40000 ALTER TABLE `AspNetUserTokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `AspNetUserTokens` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.Companies
CREATE TABLE IF NOT EXISTS `Companies` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `PicturePath` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Name` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Address` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Email` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `PhoneNumber` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `Website` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `State` text COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserId` (`UserId`),
  CONSTRAINT `CompanyBelongsToUser_fk` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.Companies: ~7 rows (approximately)
/*!40000 ALTER TABLE `Companies` DISABLE KEYS */;
INSERT INTO `Companies` (`Id`, `UserId`, `PicturePath`, `Name`, `Address`, `Email`, `PhoneNumber`, `Website`, `State`) VALUES
	(0, '0', '', '', '', '', '', '', ''),
	(1, 'b32b391e-d837-49a2-8ce6-2a9bcba8255c', '', 'Proclub Gardening', '{\r\n	"y":-6.976463,\r\n	"x":107.631412,\r\n	"Address":"Computing Laboratory, School of Computing, Telkom University, Jl. Telekomunikasi No.1, Sukapura, Dayeuhkolot, Bandung, West Java 40257"\r\n}', 'ProGardening@Proclub.com', '726826', 'progarden.com', ''),
	(2, '8911ab6d-c5cc-491b-9e27-d968258c22ae', '', 'Telyu Garden', '{\r\n	"y":-6.971269,\r\n	"x":107.630049,\r\n	"Address":"Jl. Telekomunikasi Sukapura Dayeuhkolot Bandung "\r\n}', 'telyu@telyu.com', '7468324', '', ''),
	(3, '78d82fd7-b0ce-4f4f-a0cd-161004ce668b', '', 'Kebun Sudrajat', '{\r\n	"y":-6.936474,\r\n	"x":107.606273,\r\n	"Address":"Jl. Moch. Toha, Ciateul, Regol, Kota Bandung, Jawa Barat 40252 "\r\n}', 'sudrajat@gmail.com', '54564654', '', ''),
	(4, '573a8c50-9caf-4df2-989a-62c7a7551944', '', 'Mas Dadang', '{\r\n	"y":-6.936474,\r\n	"x":107.606273,\r\n	"Address":"Jl. Moch. Toha, Ciateul, Regol, Kota Bandung, Jawa Barat 40252 "\r\n}', 'dadang@gmail.com', '545454', '', ''),
	(5, '2955ec4d-4de4-4a31-a8b4-eaa2d9a2b246', '', 'Deni Florist', '{\r\n	"y":-6.936474,\r\n	"x":107.606273,\r\n	"Address":"Jl. Moch. Toha, Ciateul, Regol, Kota Bandung, Jawa Barat 40252 "\r\n}', 'deni@deni.com', '518784', '', ''),
	(6, '8d7f7adc-5ba2-4c9a-b3cb-c773fce00241', '', 'Sirmoto', '{\r\n	"y":-6.980514,\r\n	"x": 107.651125,\r\n	"Address":"Jl. Moch. Toha, Ciateul, Regol, Kota Bandung, Jawa Barat 40252 "\r\n}', 'sirmoto@sirmoto.com', '5445565', '', '');
/*!40000 ALTER TABLE `Companies` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.Employees
CREATE TABLE IF NOT EXISTS `Employees` (
  `Id` int(11) NOT NULL,
  `CompanyId` int(11) NOT NULL,
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `State` text COLLATE latin1_general_ci NOT NULL,
  `Rating` decimal(10,0) NOT NULL,
  `PicturePath` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `Location` text COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `OwnedByUser` (`UserId`),
  KEY `WorksInCompany` (`CompanyId`),
  CONSTRAINT `OwnedByUser` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`),
  CONSTRAINT `WorksInCompany` FOREIGN KEY (`CompanyId`) REFERENCES `Companies` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.Employees: ~3 rows (approximately)
/*!40000 ALTER TABLE `Employees` DISABLE KEYS */;
INSERT INTO `Employees` (`Id`, `CompanyId`, `UserId`, `State`, `Rating`, `PicturePath`, `Location`) VALUES
	(1, 1, '11084358-e5fe-4ad6-9994-92a379ea886b', 'WORKING', 5, NULL, '{\r\n	"x":22222,\r\n	"y":123213123,\r\n	"Address": "Jalanxyz"\r\n}'),
	(2, 1, 'af6827ea-487c-4c78-a34d-5470697ee139', 'IDLE', 5, NULL, '{\r\n	"x":22222,\r\n	"y":123213123,\r\n	"Address": "Jalanxyz"\r\n}'),
	(3, 1, 'fdc20744-74e0-4dc3-a422-4a6a75f512ef', 'IDLE', 4, NULL, '{\r\n	"x":223222,\r\n	"y":12313123,\r\n	"Address": "Jalanxyz"\r\n}');
/*!40000 ALTER TABLE `Employees` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.Items
CREATE TABLE IF NOT EXISTS `Items` (
  `Id` int(11) NOT NULL,
  `Rating` float NOT NULL,
  `CompanyId` int(11) NOT NULL,
  `Price` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `Item_Owned_by_Company` (`CompanyId`),
  CONSTRAINT `FK_Item_Product` FOREIGN KEY (`Id`) REFERENCES `Products` (`Id`),
  CONSTRAINT `Item_Owned_by_Company` FOREIGN KEY (`CompanyId`) REFERENCES `Companies` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.Items: ~10 rows (approximately)
/*!40000 ALTER TABLE `Items` DISABLE KEYS */;
INSERT INTO `Items` (`Id`, `Rating`, `CompanyId`, `Price`) VALUES
	(13, 1, 6, 0),
	(14, 0.8, 4, 0),
	(16, 0.7, 2, 0),
	(17, 0.7, 4, 0),
	(18, 0.9, 1, 0),
	(19, 0.8, 2, 0),
	(20, 0.6, 4, 0),
	(21, 0.7, 1, 0),
	(22, 0.6, 5, 0),
	(23, 1, 5, 0);
/*!40000 ALTER TABLE `Items` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.Layanans
CREATE TABLE IF NOT EXISTS `Layanans` (
  `Id` int(11) NOT NULL,
  `Price` double NOT NULL,
  `Hit` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `FK_Service_Products` FOREIGN KEY (`Id`) REFERENCES `Products` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.Layanans: ~12 rows (approximately)
/*!40000 ALTER TABLE `Layanans` DISABLE KEYS */;
INSERT INTO `Layanans` (`Id`, `Price`, `Hit`) VALUES
	(1, 35000, 0),
	(2, 50000, 0),
	(3, 35000, 0),
	(4, 40000, 0),
	(5, 100000, 0),
	(6, 500000, 0),
	(7, 200000, 0),
	(8, 300000, 0),
	(9, 0, 0),
	(10, 0, 0),
	(11, 0, 0),
	(12, 0, 0);
/*!40000 ALTER TABLE `Layanans` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.PickedUpEmployees
CREATE TABLE IF NOT EXISTS `PickedUpEmployees` (
  `Id` int(11) NOT NULL,
  `EmployeeId` int(11) NOT NULL,
  `TransactionId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `PointsToEmployee` (`EmployeeId`),
  KEY `BelongsToTransaction1` (`TransactionId`),
  CONSTRAINT `BelongsToTransaction1` FOREIGN KEY (`TransactionId`) REFERENCES `Transactions` (`Id`),
  CONSTRAINT `PointsToEmployee` FOREIGN KEY (`EmployeeId`) REFERENCES `Employees` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.PickedUpEmployees: ~1 rows (approximately)
/*!40000 ALTER TABLE `PickedUpEmployees` DISABLE KEYS */;
INSERT INTO `PickedUpEmployees` (`Id`, `EmployeeId`, `TransactionId`) VALUES
	(1429678721, 2, 578887924);
/*!40000 ALTER TABLE `PickedUpEmployees` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.PickedUpProducts
CREATE TABLE IF NOT EXISTS `PickedUpProducts` (
  `Id` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `TransactionId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `ProductId_FK` (`ProductId`),
  KEY `BelongsToTransaction` (`TransactionId`),
  CONSTRAINT `BelongsToTransaction` FOREIGN KEY (`TransactionId`) REFERENCES `Transactions` (`Id`),
  CONSTRAINT `PointsToProduct` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci ROW_FORMAT=COMPACT;

-- Dumping data for table sirmotodevel.PickedUpProducts: ~3 rows (approximately)
/*!40000 ALTER TABLE `PickedUpProducts` DISABLE KEYS */;
INSERT INTO `PickedUpProducts` (`Id`, `ProductId`, `Quantity`, `TransactionId`) VALUES
	(627324037, 1, 1, 578887924),
	(811899329, 1, 1, 361117326),
	(1409018272, 1, 1, 1885016268);
/*!40000 ALTER TABLE `PickedUpProducts` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.Products
CREATE TABLE IF NOT EXISTS `Products` (
  `Id` int(11) NOT NULL,
  `HitCount` int(11) NOT NULL,
  `Name` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Type` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `Descriptions` text COLLATE latin1_general_ci NOT NULL,
  `RequiredWorker` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.Products: ~23 rows (approximately)
/*!40000 ALTER TABLE `Products` DISABLE KEYS */;
INSERT INTO `Products` (`Id`, `HitCount`, `Name`, `Type`, `Descriptions`, `RequiredWorker`) VALUES
	(1, 1, 'Potong Rumput', 'LAYANAN', 'Ya potong rumput bro', 1),
	(2, 0, 'Tebang Pohon', 'LAYANAN', '', 1),
	(3, 0, 'Pangkas Semak', 'LAYANAN', '', 1),
	(4, 0, 'Tanam Bibit Pohon Besar', 'LAYANAN', '', 2),
	(5, 0, 'Penanaman Bibit Rumput', 'LAYANAN', '', 0),
	(6, 0, 'Pembukaan Lahan Kosong', 'LAYANAN', '', 3),
	(7, 0, 'Maintenance Taman', 'LAYANAN', '', 1),
	(8, 0, 'Bongkar dan Transport Pohon', 'LAYANAN', '', 0),
	(9, 0, 'Peremajaan Rumput', 'LAYANAN', '', 3),
	(10, 0, 'Peremajaan Taman', 'LAYANAN', '', 3),
	(11, 0, 'Restorasi Taman', 'LAYANAN', '', 4),
	(12, 0, 'Kontrol Gulma dan Hama', 'LAYANAN', '', 3),
	(13, 0, 'Sirmoto-EZ', 'ITEM', '', 0),
	(14, 0, 'Sekop', 'ITEM', '', 0),
	(15, 0, 'Pohon Akasia', 'ITEM', '', 0),
	(16, 0, 'Pohon Jepon', 'ITEM', '', 0),
	(17, 0, 'Bibit Mangga', 'ITEM', '', 0),
	(18, 0, 'Gardening Kit', 'ITEM', '', 0),
	(19, 0, 'Pot Tambulapot (10cm)', 'ITEM', '', 0),
	(20, 0, 'Aolun R108 Garden Sprinkler- Automatic Lawn Water Sprinkler 360 Degree 3- Arm Rotating ', 'ITEM', '', 0),
	(21, 0, 'sprinkler 5 nozzle alat irigasi bisa berputar', 'ITEM', '', 0),
	(22, 0, 'Rotaty Sprinkler', 'ITEM', '', 0),
	(23, 0, 'Selang Air', 'ITEM', '', 0);
/*!40000 ALTER TABLE `Products` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.ProductsPictures
CREATE TABLE IF NOT EXISTS `ProductsPictures` (
  `Id` int(11) NOT NULL,
  `Path` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `ProductId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `PicturesBelongToProduct` (`ProductId`),
  CONSTRAINT `PicturesBelongToProduct` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.ProductsPictures: ~12 rows (approximately)
/*!40000 ALTER TABLE `ProductsPictures` DISABLE KEYS */;
INSERT INTO `ProductsPictures` (`Id`, `Path`, `ProductId`) VALUES
	(1, 'lawnmowing1.jpg', 1),
	(2, 'tebang pohon.jpg', 2),
	(3, 'pangkassemak.jpg', 3),
	(4, 'bibit pohon.jpg', 4),
	(5, 'tanam pohon besar.jpg', 5),
	(6, 'pembukaan lahan.jpg', 6),
	(7, 'maintenance.jpg', 7),
	(8, 'pemindahan pohon.jpg', 8),
	(9, 'peremajaan taman.jpg', 9),
	(10, 'peremajaan taman.jpg', 10),
	(11, 'restorasi taman.jpg', 11),
	(12, 'gulma kontrol.jpg', 12);
/*!40000 ALTER TABLE `ProductsPictures` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.SirmotoDevices
CREATE TABLE IF NOT EXISTS `SirmotoDevices` (
  `Id` int(11) NOT NULL,
  `Description` text COLLATE latin1_general_ci NOT NULL,
  `DeviceName` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `DeviceState` text COLLATE latin1_general_ci NOT NULL,
  `DeviceInfo` text COLLATE latin1_general_ci NOT NULL,
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `Owner_FK` (`UserId`),
  CONSTRAINT `Owner_FK` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.SirmotoDevices: ~9 rows (approximately)
/*!40000 ALTER TABLE `SirmotoDevices` DISABLE KEYS */;
INSERT INTO `SirmotoDevices` (`Id`, `Description`, `DeviceName`, `DeviceState`, `DeviceInfo`, `UserId`) VALUES
	(281213180, 'tezzt', 'Sirmoto-EZ', 'lol', 'Ready', 'daa808f8-6339-4204-a5cb-62a3d9edf072'),
	(318211113, 'tezzt', 'Sirmoto-EZ', 'lol', 'Ready', 'daa808f8-6339-4204-a5cb-62a3d9edf072'),
	(557190390, 'tezzt', 'Sirmoto-EZ', 'lol', 'Ready', 'daa808f8-6339-4204-a5cb-62a3d9edf072'),
	(673936864, 'None', 'New Sirmoto Device', '{"Mode":"SCHEDULED"}', 'Sirmoto-EZ', 'af6827ea-487c-4c78-a34d-5470697ee139'),
	(872403529, 'tezzt', 'Sirmoto-EZ', 'lol', 'Ready', 'daa808f8-6339-4204-a5cb-62a3d9edf072'),
	(1271825299, 'None', 'New Sirmoto Device', '{"Mode":"SCHEDULED"}', 'Sirmoto-EZ', 'af6827ea-487c-4c78-a34d-5470697ee139'),
	(1933281808, 'None', 'New Sirmoto Device', '{"Mode":"SCHEDULED"}', 'Sirmoto-EZ', 'af6827ea-487c-4c78-a34d-5470697ee139'),
	(2090083098, 'tezzt', 'Sirmoto-EZ', 'lol', 'Ready', 'daa808f8-6339-4204-a5cb-62a3d9edf072'),
	(2123050480, 'Siraman depan', 'Sirmoto 1', '{\r\n	"Mode" : "SCHEDULED"\r\n}', 'Sirmoto-EZ', 'af6827ea-487c-4c78-a34d-5470697ee139');
/*!40000 ALTER TABLE `SirmotoDevices` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.SirmotoDeviceSchedule
CREATE TABLE IF NOT EXISTS `SirmotoDeviceSchedule` (
  `Id` int(11) NOT NULL,
  `DeviceId` int(11) NOT NULL,
  `Time` time NOT NULL,
  `Duration` time NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `belongstodevice_fk` (`DeviceId`),
  CONSTRAINT `belongstodevice_fk` FOREIGN KEY (`DeviceId`) REFERENCES `SirmotoDevices` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.SirmotoDeviceSchedule: ~2 rows (approximately)
/*!40000 ALTER TABLE `SirmotoDeviceSchedule` DISABLE KEYS */;
INSERT INTO `SirmotoDeviceSchedule` (`Id`, `DeviceId`, `Time`, `Duration`) VALUES
	(1, 1271825299, '18:06:06', '18:06:08'),
	(1559312046, 2123050480, '17:00:00', '00:05:00');
/*!40000 ALTER TABLE `SirmotoDeviceSchedule` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.Transactions
CREATE TABLE IF NOT EXISTS `Transactions` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) COLLATE latin1_general_ci NOT NULL,
  `CompanyId` int(11) NOT NULL,
  `Location` text COLLATE latin1_general_ci NOT NULL,
  `State` text COLLATE latin1_general_ci NOT NULL,
  `PaymentMethod` text COLLATE latin1_general_ci,
  `Discount` float NOT NULL,
  `TimeStamp` datetime NOT NULL,
  `Total` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `TransactionOwnedByUser` (`UserId`),
  KEY `OwnedByCompany1` (`CompanyId`),
  CONSTRAINT `OwnedByCompany1` FOREIGN KEY (`CompanyId`) REFERENCES `Companies` (`Id`),
  CONSTRAINT `TransactionOwnedByUser` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.Transactions: ~3 rows (approximately)
/*!40000 ALTER TABLE `Transactions` DISABLE KEYS */;
INSERT INTO `Transactions` (`Id`, `UserId`, `CompanyId`, `Location`, `State`, `PaymentMethod`, `Discount`, `TimeStamp`, `Total`) VALUES
	(361117326, 'af6827ea-487c-4c78-a34d-5470697ee139', 1, '{ "x": 1312321, "y": 312321 }', 'FINAL', 'Nothing', 0, '2018-11-05 16:17:00', 0),
	(578887924, 'af6827ea-487c-4c78-a34d-5470697ee139', 1, '{ "x": 1312321, "y": 312321 }', 'FINAL', 'Nothing', 0, '2018-11-05 19:42:13', 0),
	(1885016268, 'af6827ea-487c-4c78-a34d-5470697ee139', 1, '{ "x": 1312321, "y": 312321 }', 'FINAL', 'Nothing', 0, '2018-11-05 19:13:30', 0);
/*!40000 ALTER TABLE `Transactions` ENABLE KEYS */;

-- Dumping structure for table sirmotodevel.__EFMigrationsHistory
CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
  `MigrationId` varchar(95) COLLATE latin1_general_ci NOT NULL,
  `ProductVersion` varchar(32) COLLATE latin1_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

-- Dumping data for table sirmotodevel.__EFMigrationsHistory: ~5 rows (approximately)
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
	('00000000000000_CreateIdentitySchema', '2.1.4-rtm-31024'),
	('20181031173002_CreateIdentityModels', '2.1.4-rtm-31024'),
	('20181031173756_addressphonenumfields', '2.1.4-rtm-31024'),
	('20181031183852_PhoneAndAddressUserTable', '2.1.4-rtm-31024'),
	('20181031184340_PhoneAndAddressUserTable1', '2.1.4-rtm-31024');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
