-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 27, 2022 at 11:22 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sveikomaistoirpapilduprekyba`
--

-- --------------------------------------------------------

--
-- Table structure for table `busenos`
--

CREATE TABLE `busenos` (
  `id` int(11) NOT NULL,
  `name` char(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `busenos`
--

INSERT INTO `busenos` (`id`, `name`) VALUES
(1, 'Užsakytas'),
(2, 'Vykdomas'),
(3, 'Įvykdytas');

-- --------------------------------------------------------

--
-- Table structure for table `darbuotojai`
--

CREATE TABLE `darbuotojai` (
  `darbuotojo_id` int(11) NOT NULL,
  `vardas` varchar(20) NOT NULL,
  `pavarde` varchar(20) NOT NULL,
  `fk_parduotuves_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `darbuotojai`
--

INSERT INTO `darbuotojai` (`darbuotojo_id`, `vardas`, `pavarde`, `fk_parduotuves_id`) VALUES
(1, 'Fabe', 'Kunze', 1),
(2, 'Lori', 'Gorch', 2),
(3, 'Jaynell', 'Kivits', 3),
(4, 'Matteo', 'Demangel', 4),
(5, 'Finlay', 'Kubal', 1),
(6, 'Betsey', 'Westmarland', 1),
(7, 'Marna', 'Narrie', 1),
(8, 'Ruggiero', 'Boorne', 2),
(10, 'Margette', 'Lattka', 3),
(11, 'Kalil', 'Youthead', 1),
(12, 'Yardley', 'Keiling', 4),
(13, 'Arabella', 'Dreher', 4),
(14, 'Tiffi', 'Lelievre', 1),
(15, 'Peri', 'Surby', 2),
(16, 'Shayne', 'Lipmann', 2),
(17, 'Kippie', 'Lyptratt', 2),
(18, 'Gerti', 'Larder', 3),
(19, 'Johann', 'Lacasa', 3),
(20, 'Courtnay', 'Dundredge', 4),
(21, 'Reeba', 'Gosz', 1),
(22, 'Oneida', 'Rajchert', 2),
(23, 'Gilbert', 'Espadero', 2),
(24, 'Melitta', 'Chaffer', 2),
(25, 'Caria', 'Meader', 1);

-- --------------------------------------------------------

--
-- Table structure for table `dietos`
--

CREATE TABLE `dietos` (
  `id` int(11) NOT NULL,
  `name` char(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `dietos`
--

INSERT INTO `dietos` (`id`, `name`) VALUES
(1, 'Vegetariška'),
(2, 'Veganiška'),
(3, 'Organinis'),
(4, 'Be glitimo'),
(5, 'Mažai cukraus'),
(6, 'Mažai riebalų'),
(7, 'Be laktozės');

-- --------------------------------------------------------

--
-- Table structure for table `kategorijos`
--

CREATE TABLE `kategorijos` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kategorijos`
--

INSERT INTO `kategorijos` (`id`, `pavadinimas`) VALUES
(1, 'Kreatinas'),
(2, 'Aminorūgštys'),
(3, 'Baltymai'),
(4, 'Vitaminai'),
(5, 'Aksesuarai'),
(6, 'Mineralai'),
(7, 'Angliavandeniai'),
(8, 'Papildai svoriui reg'),
(9, 'Maistas'),
(10, 'Užkandžiai'),
(11, 'Papildai pries/per/p');

-- --------------------------------------------------------

--
-- Table structure for table `klientai`
--

CREATE TABLE `klientai` (
  `id_klientas` int(11) NOT NULL,
  `asmens_kodas` int(11) NOT NULL,
  `vardas` varchar(20) NOT NULL,
  `pavarde` varchar(20) NOT NULL,
  `telefonas` varchar(20) NOT NULL,
  `epastas` varchar(40) NOT NULL,
  `adresas` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `klientai`
--

INSERT INTO `klientai` (`id_klientas`, `asmens_kodas`, `vardas`, `pavarde`, `telefonas`, `epastas`, `adresas`) VALUES
(1, 28, 'Constancy', 'Rogan', '+230-365-216-7339', 'crogan0@moonfruit.com', '45 Hintze Terrace'),
(2, 58, 'Alden', 'Loakes', '+37066038054', 'aloakes1@eepurl.com', '87 Red Cloud Way'),
(3, 52, 'Blakelee', 'De Matteis', '+37061448127', 'bdematteis2@t.co', '36 Sage Lane'),
(4, 84, 'Michaelina', 'Taynton', '+3703306850', 'mtaynton3@sciencedirect.com', '3279 Hoffman Lane'),
(5, 72, 'Crystal', 'Jikovsky', '+37019162715', 'cjikovsky4@github.io', '51 Butternut Drive'),
(6, 77, 'Jdavie', 'Waren', '+37028829687', 'jwaren5@netscape.com', '159 Twin Pines Center'),
(7, 27, 'Buffy', 'Bagley', '+37066346888', 'bbagley6@reference.com', '76989 Scott Court'),
(8, 41, 'Michelina', 'Scurrey', '+37067820886', 'mscurrey7@123-reg.co.uk', '233 Sommers Road'),
(9, 16, 'Poppy', 'Doncaster', '+37061928880', 'pdoncaster8@walmart.com', '10635 Parkside Hill'),
(10, 16, 'Ros', 'Meco', '+37067845309', 'rmeco9@cnn.com', '24 Morning Plaza'),
(11, 3, 'Berti', 'Cornhill', '+37060405246', 'bcornhilla@odnoklassniki.ru', '6 Debra Road'),
(12, 99, 'Evangeline', 'Bernini', '+37065787404', 'eberninib@livejournal.com', '8 Oriole Drive'),
(13, 93, 'Gale', 'Renne', '+37067318814', 'grennec@squarespace.com', '1 South Lane'),
(14, 53, 'Dulsea', 'Tures', '+37066244999', 'dturesd@seattletimes.com', '1870 Old Shore Parkway'),
(15, 71, 'Ginger', 'Petschel', '+37036296922', 'gpetschele@cmu.edu', '65 Lake View Pass'),
(16, 15, 'Ingunna', 'Ostridge', '+3709434947684', 'iostridgef@acquirethisname.com', '73 Sugar Lane'),
(17, 4, 'Vick', 'Allicock', '+37062433978', 'vallicockg@infoseek.co.jp', '6 Merry Court'),
(18, 45, 'Clevie', 'Joul', '+37060755795', 'cjoulh@wikia.com', '2 Ramsey Lane'),
(19, 60, 'Mildred', 'Demkowicz', '+37064041938', 'mdemkowiczi@usatoday.com', '5466 Del Sol Court'),
(20, 26, 'Kameko', 'Simmens', '+37062063373', 'ksimmensj@e-recht24.de', '964 Dayton Place'),
(21, 70, 'Barby', 'Ughelli', '+37062884717', 'bughellik@blogspot.com', '51020 Redwing Center'),
(22, 75, 'Liam', 'Whales', '+37068622999', 'lwhalesl@illinois.edu', '6416 Hermina Parkway'),
(23, 29, 'Gifford', 'Zukerman', '+37062490266', 'gzukermanm@naver.com', '77 Luster Parkway'),
(24, 75, 'Kerstin', 'Chazerand', '+37084524310', 'kchazerandn@desdev.cn', '035 John Wall Street'),
(25, 31, 'Lynn', 'Haw', '+37067650062', 'lhawo@illinois.edu', '195 Laurel Park');

-- --------------------------------------------------------

--
-- Table structure for table `miestai`
--

CREATE TABLE `miestai` (
  `pavadinimas` varchar(30) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `miestai`
--

INSERT INTO `miestai` (`pavadinimas`, `id`) VALUES
('Benito Juarez', 1),
('Esperanza', 2),
('Liushutun', 3),
('Dongxing', 4),
('Chincha Baja', 5),
('Tongjing', 6),
('Älvsjö', 7),
('Itararé', 8),
('Stara Błotnica', 9),
('Sines', 10),
('Venezuela', 11),
('Saidpur', 12),
('Perpignan', 13),
('Hongsipu', 14),
('Portëz', 15),
('Citeluk', 16),
('Yanzhou', 17),
('Sabnova', 18),
('Khulm', 19),
('Dengmu', 20),
('Baibu', 21),
('Pakemitan', 22),
('Esmeralda', 23),
('Kiyawa', 24),
('Syrskoye', 25);

-- --------------------------------------------------------

--
-- Table structure for table `mokejimai`
--

CREATE TABLE `mokejimai` (
  `id` int(11) NOT NULL,
  `data` date NOT NULL,
  `suma` decimal(8,2) NOT NULL,
  `fk_klientas` int(11) NOT NULL,
  `fk_saskaita` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `mokejimai`
--

INSERT INTO `mokejimai` (`id`, `data`, `suma`, `fk_klientas`, `fk_saskaita`) VALUES
(1, '2022-03-10', '4253.43', 2, 4),
(2, '2022-02-16', '255.00', 18, 9),
(5, '2021-09-12', '300.89', 1, 18),
(6, '2021-03-22', '777.74', 14, 32),
(9, '2021-09-01', '4152.66', 15, 33),
(10, '2021-08-18', '4558.66', 16, 34),
(11, '2022-01-05', '994.72', 24, 7),
(12, '2022-01-02', '2032.15', 5, 19),
(15, '2021-12-07', '469.77', 21, 21),
(16, '2021-09-02', '4623.98', 21, 31);

-- --------------------------------------------------------

--
-- Table structure for table `parduotuves`
--

CREATE TABLE `parduotuves` (
  `parduotuves_id` int(11) NOT NULL,
  `pavadinimas` varchar(30) NOT NULL,
  `adresas` text NOT NULL,
  `telefonas` varchar(20) NOT NULL,
  `epastas` varchar(40) NOT NULL,
  `fk_miestas` int(11) NOT NULL,
  `fk_parduotuves_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `parduotuves`
--

INSERT INTO `parduotuves` (`parduotuves_id`, `pavadinimas`, `adresas`, `telefonas`, `epastas`, `fk_miestas`, `fk_parduotuves_id`) VALUES
(1, 'Morissette', '8940 Vera Lane', '733-372-6540', 'jsowerbutts0@cam.ac.uk', 1, NULL),
(2, 'Ratke and Sons', '5 Mcbride Circle', '367-901-4537', 'dhollidgei@shop-pro.jp', 5, 1),
(3, 'Luettgen-Kuhn', '67127 Prentice Way', '659-890-2398', 'cnotleyk@samsung.com', 9, NULL),
(4, 'Keeling ', '66852 Dixon Trail', '187-706-0727', 'gspoolel@businesswire.com', 13, 3),
(5, 'Stim', '1 South Lane', '+37067318814', 'grennec@squarespace.com', 7, NULL),
(6, 'Overhold', '85 Holmberg Crossing', '+37065787404', 'bcornhilla@odnoklassniki.ru', 12, NULL),
(7, 'Treeflex', '23703 6th Hill', '+37067845309', 'lhawo@illinois.edu', 7, 5),
(8, 'Thiel LLC', '44422 Gulseth Junction', '+37067650062', 'mmeiklam8@de.vu', 21, NULL),
(9, 'Herzog', '367 Tony Circle', '+37069992185', 'vmourgue7@vkontakte.ru', 19, NULL),
(10, 'Reilly-Ratke', '144 Weeping Birch Avenue', '+37068882156', 'mphizaclea6@microsoft.com', 22, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `prekes`
--

CREATE TABLE `prekes` (
  `kodas` int(11) NOT NULL,
  `pavadinimas` varchar(40) NOT NULL,
  `kaina` decimal(8,2) NOT NULL,
  `aprasymas` text NOT NULL,
  `maistine_informacija` text NOT NULL,
  `galiojimo_laikas` date NOT NULL,
  `dieta` int(11) NOT NULL,
  `fk_kategorija` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `prekes`
--

INSERT INTO `prekes` (`kodas`, `pavadinimas`, `kaina`, `aprasymas`, `maistine_informacija`, `galiojimo_laikas`, `dieta`, `fk_kategorija`) VALUES
(1, 'Whey protein', '20.50', 'Vienoje šių aukščiausios kokybės išrūgų porcijoje yra 21 g baltymų. Be to, šiuos baltymus gaunate iš kokybiško šaltinio – iš tų pačių karvių, iš kurių gaminamas pienas ir sūris. Išfiltruojant ir sausai išpurškiant juos gaunamos natūralios maistinės medžiagos', '100g	Porcijoje\r\nEnergetinė vertė	845 kJ/202 kcal', '2025-03-19', 1, 3),
(2, 'Kreatinmonohidratas', '15.00', 'Tai yra viena labiausiai pasaulyje ištyrinėtų kreatino formų. Moksliškai įrodyta, kad mūsų labai veiksmingi milteliai padidina fizinį pajėgumą1, nes bendrai padaugėja jėgų.', 'Vienoje porcijoje\r\nKreatino monohidratas	3 g', '2024-03-13', 4, 1),
(3, 'Alkalyn Kreatinas', '30.00', 'Kreatinas padeda siekti tikslų – nuo svorių kėlimo iki pratimų širdžiai. „Kre–Alkalyn®“ yra tinkamo PH kreatino forma, tinkama vartoti siekiant įvairių tikslų, laikantis treniruočių režimų ir sportuojant.', 'Vienoje porcijoje\r\nSušvelninto poveikio kreatino (Kre-Alkalyn®)	3g', '2025-03-19', 2, 1),
(4, 'angliavandeniai iš g', '5.00', 'Dekstrozė, dar žinoma kaip gliukozė ar kukurūzų cukrus, yra saldaus skonio angliavandenis, puikiai tinkantis vartoti prieš treniruotę ir po jos, kad suteiktų jėgų sportuojant ir pasportavus1. Tinka vartoti užsiimant bet kokiomis treniruotėmis ir kaskart padeda grįžti į sporto salę ar aikštelę.', '100g	1 porcijoje	*RPN\r\nEnergetinė vertė	1700 kJ/400 kcal	850 kJ/200 kcal	10%\r\nRiebalai	0 g	0 g	0%\r\n 	iš kurių sočiųjų rūgščių	0 g	0 g	0%\r\nAngliavandeniai	100 g	50 g	19%\r\n 	iš kurių cukrų	100 g	50 g	56%\r\nBaltymai	0 g	0 g	0%\r\nDruska	<0.01 g	<0.01 g	0%', '2024-03-23', 2, 7),
(5, 'Avižiniai dribsniai', '0.00', 'Mūsų traiškytos avižos iškels tavo pusryčius į naują lygį — daug sudėtinių angliavandenių ir skaidulų turintis produktas yra idealus būdas padėti raumenims atsigauti po treniruotės.', 'Energetinė vertė	1541 kJ/366 kcal	771 kJ/ 183 kcal	9%\r\nRiebalai	8.4 g	4.2 g	6%\r\n 	iš kurių sočiųjų rūgščių	1.3 g	0.7 g	4%\r\nAngliavandeniai	56 g	28 g	11%\r\n 	iš kurių cukrų	1 g	0.5 g	1%\r\nSkaidulinės medžiagos	9.1 g	4.5 g	~\r\nBaltymai	12 g	6.2 g	12%\r\nDruska	<0.01 g	<0.01 g	0%\r\nβ-glukanai	4.4 g	2.2 g', '2024-05-16', 1, 7),
(6, 'Vitafiber', '10.99', 'Šie vandenyje tirpūs milteliai yra pagaminti iš genetiškai nemodifikuoto kukurūzų krakmolo. Juose yra 88 % maistinių skaidulų, tad tai – puikus maisto papildas, galintis padidinti kasdien suvartojamų medžiagų kiekį bei natūraliai pasaldinti maistą ir gėrimus.', ' 	100g	Porcijoje\r\nEnergetinė vertė	845 kJ/202 kcal	126 kJ/30 kcal\r\nRiebalai	0 g	0 g\r\n 	iš kurių sočiųjų	0 g	0 g\r\nAngliavandeniais	5.0g	0.8g\r\n 	iš kurių cukrų	0 g	0 g\r\nSkaidulinės medžiagos	91 g	14 g\r\nBaltymai	0 g	0 g\r\nDruska	0.03 g	0 g', '2025-03-01', 1, 7),
(7, 'THE Pump', '29.99', 'Ar siektumėte nervingumo nesukeliančio užtaiso, ar tiesiog nenorite per didelės stimuliacijos prieš miegą po vakarinės treniruotės, THE Pump yra tobula formulė prieš treniruotę. Ingredientai, esantys joje, buvo specialiai atrinkti tam, kad padėtų jums pasiekti dar daugiau ir įveikti visus barjerus, pratimas po pratimo, treniruotė po treniruotės.', '	Vienoje porcijoje\r\nL-citrulino	6000mg\r\nBeta alanino	3200mg\r\nBevandenio betaino	1500mg\r\nTaurino	1000mg\r\nVAS06™	300mg\r\nAstraGin©	50mg\r\nVynuogių sėklų ekstrakto	25mg\r\nBioPerine©	5mg', '2026-03-02', 5, 2),
(8, 'THE Amino Boost', '29.99', '„Įkraukite“ savo organizmą ir mintis „Myamino“ energija — įvairių gaivinančių vaisių skonių, kurios sudėtyje yra amino rūgščių, vitaminas C be natūralaus kofeino, suteikiančio energijos, kai jums reikia.', '1 porcijoje\r\nL-leucinas	1.5 g\r\nL-glutaminas	1 g\r\nL-izoleucinas	750 mg\r\nL-valinas	750 mg\r\nL-lizinas	200 mg\r\nL-treoninas	200 mg\r\nL-histidinas	200 mg\r\nL-metioninas 	200 mg\r\nL-citrulinas	500 mg\r\nL-tirozinas	500 mg\r\ntaurinas	500 mg\r\nL-argininas	500 mg\r\nL-teaninas	200 mg\r\nžaliųjų kavos pupelių ekstraktas ​	140 mg\r\nnatūralus kofeinas 	100 mg\r\nžaliosios arbatos ekstraktas	78 mg\r\nvitaminas C	24 mg (*30%)', '2026-06-18', 5, 2),
(9, '„Lean Cookie“', '25.99', 'Net 80 % mažiau cukraus ir 70 % mažiau riebalų lyginant su įprastinėmis prekybos centruose parduodamomis alternatyvomis. Šiais gardžiais sausainiais galite mėgautis net laikydamiesi griežtos kūno rengybos programos.\r\n\r\nPagaminti iš 25 g pieno baltymų, avižinių miltų ir apibarstyti šokolado skonio traškučiais mūsų liesi sausainiai „Lean Cookie“ – puikus užkandis, kai norisi ko nors saldaus.', '	100g	1 sausainyje (50g)\r\nEnergetinė vertė	1618 kJ/387 kcal	809 kJ/194 kcal\r\nRiebalai	6.0 g	3.0 g\r\n 	iš kurių sočiųjų	2.5 g	1.3 g\r\nAngliavandeniai	32 g	16 g\r\n 	iš kurių cukrų	7.1 g	3.6 g\r\nSkaidulų	2.0 g	1.0 g\r\nBaltymų	50 g	25 g\r\nDruska	0.70 g	0.35 g', '2023-03-16', 1, 10),
(10, 'Command Energy Drink', '15.99', 'Welcome to the Command range - the cutting-edge of premium gaming nutrition. When gaming, winning those clutch moments can make the difference between winning and losing — so you need to make every moment count. At Command, we understand this. That\'s why our Energy Drinks are packed with key ingredients, vitamins, and minerals, to help you reach your gaming potential.', 'NUTRITIONAL INFORMATION	Per 100ml	Per 440ml\r\nEnergy	11kJ/ 2kcal	46kJ/ 11kcal	 \r\nFat	0g	0g	 \r\n(of which saturates)	0g	0g	 \r\nCarbohydrate	0.6g	2.7g	 \r\n(of which sugars)	0g	0g	 \r\nProtein	0g	0g	 \r\nSalt	0g	0g	 \r\nACTIVE INGREDIENTS	Per 100ml	Per 440ml\r\nZinc	2.3mg (23%*)	10mg (100%*)\r\nNiacin	1.5mg (9%*)	6.4mg (40%*)\r\nVitamin B6	0.32mg (23%*)	1.4mg (100%*)\r\nVitamin A	110µg (14%*)	484µg (61%*)\r\nVitamin D3	0.56µg (11%*)	2.5µg (49%*)\r\nVitamin B12	0.29µg (12%*)	1.3µg (52%)\r\nTaurine	230mg	1000mg\r\nLions Mane Mushroom Powder	110mg	500mg\r\nCaffeine	41mg	180mg\r\nLutein	1.4mg	6.0mg', '2023-03-19', 5, 10);

-- --------------------------------------------------------

--
-- Table structure for table `sandeliai`
--

CREATE TABLE `sandeliai` (
  `kodas` int(11) NOT NULL,
  `fk_prekes_kodas` int(11) NOT NULL,
  `kiekis` int(5) NOT NULL,
  `fk_parduotuves_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sandeliai`
--

INSERT INTO `sandeliai` (`kodas`, `fk_prekes_kodas`, `kiekis`, `fk_parduotuves_id`) VALUES
(1, 1, 50, 4),
(2, 2, 40, 4),
(3, 6, 560, 3),
(4, 3, 153, 1),
(5, 4, 852, 2),
(6, 5, 2, 1),
(7, 1, 50, 10),
(8, 5, 40, 10),
(9, 4, 100, 10),
(10, 3, 566, 9),
(11, 2, 111, 8),
(12, 6, 99, 8),
(13, 9, 51, 6),
(14, 5, 555, 5),
(15, 5, 645, 7),
(16, 7, 46, 3),
(17, 3, 33, 3),
(18, 2, 11, 1),
(19, 6, 46, 7);

-- --------------------------------------------------------

--
-- Table structure for table `saskaitos`
--

CREATE TABLE `saskaitos` (
  `nr` int(11) NOT NULL,
  `data` date NOT NULL,
  `suma` decimal(8,2) NOT NULL,
  `fk_uzsakymas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `saskaitos`
--

INSERT INTO `saskaitos` (`nr`, `data`, `suma`, `fk_uzsakymas`) VALUES
(1, '2022-03-09', '500.00', 1),
(2, '2022-03-11', '423.00', 1),
(3, '2021-12-08', '1701.85', 11),
(4, '2021-03-21', '777.74', 14),
(5, '2021-11-13', '3711.49', 19),
(6, '2022-02-03', '464.21', 87),
(7, '2021-04-23', '3448.31', 23),
(9, '2021-08-16', '4152.66', 62),
(11, '2022-02-15', '1041.82', 23),
(12, '2021-11-02', '1358.76', 24),
(14, '2021-08-23', '4002.24', 21),
(15, '2021-04-18', '3596.46', 86),
(18, '2021-09-29', '963.84', 73),
(19, '2022-01-02', '2032.15', 31),
(20, '2022-03-01', '233.00', 58),
(21, '2021-07-06', '167.66', 65),
(31, '2021-04-07', '2270.42', 64),
(32, '2021-06-28', '1662.06', 20),
(33, '2021-06-06', '3893.52', 81),
(34, '2022-02-08', '566.00', 34);

-- --------------------------------------------------------

--
-- Table structure for table `uzsakymai`
--

CREATE TABLE `uzsakymai` (
  `nr` int(11) NOT NULL,
  `uzsakymo_data` date NOT NULL,
  `suma` decimal(8,2) NOT NULL,
  `parduotuves_id` int(11) NOT NULL,
  `busena` int(11) NOT NULL,
  `fk_darbuotojo_id` int(11) NOT NULL,
  `fk_id_klientas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `uzsakymai`
--

INSERT INTO `uzsakymai` (`nr`, `uzsakymo_data`, `suma`, `parduotuves_id`, `busena`, `fk_darbuotojo_id`, `fk_id_klientas`) VALUES
(1, '2022-03-09', '500.00', 1, 1, 13, 3),
(4, '2021-09-07', '4253.43', 1, 1, 15, 23),
(11, '2021-12-08', '1701.85', 3, 2, 6, 10),
(14, '2021-03-21', '777.74', 4, 3, 19, 20),
(20, '2021-03-30', '3635.90', 1, 3, 3, 14),
(21, '2021-08-31', '4623.98', 1, 2, 5, 21),
(23, '2021-04-23', '3278.28', 4, 2, 7, 7),
(24, '2021-11-02', '469.77', 3, 2, 14, 21),
(31, '2022-01-02', '994.72', 3, 2, 17, 24),
(64, '2021-04-07', '2270.42', 1, 1, 13, 7);

-- --------------------------------------------------------

--
-- Table structure for table `uzsakymo_prekes`
--

CREATE TABLE `uzsakymo_prekes` (
  `kiekis` int(5) NOT NULL DEFAULT 0,
  `kodas` int(11) NOT NULL,
  `fk_preke` int(11) NOT NULL,
  `fk_uzsakymas` int(11) NOT NULL,
  `fk_uzsakymo_data` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `uzsakymo_prekes`
--

INSERT INTO `uzsakymo_prekes` (`kiekis`, `kodas`, `fk_preke`, `fk_uzsakymas`, `fk_uzsakymo_data`) VALUES
(4, 1, 3, 4, '2021-09-07'),
(2, 2, 2, 14, '2021-03-21'),
(13, 3, 8, 1, '2022-03-09'),
(23, 4, 7, 11, '2021-12-08'),
(1, 5, 9, 20, '2021-03-30'),
(2, 6, 1, 21, '2021-08-31'),
(3, 7, 5, 23, '2021-04-23'),
(2, 8, 3, 24, '2021-11-02'),
(10, 9, 10, 31, '2022-01-02'),
(13, 10, 6, 64, '2021-04-07');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `busenos`
--
ALTER TABLE `busenos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD PRIMARY KEY (`darbuotojo_id`),
  ADD KEY `dirba` (`fk_parduotuves_id`);

--
-- Indexes for table `dietos`
--
ALTER TABLE `dietos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `kategorijos`
--
ALTER TABLE `kategorijos`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `klientai`
--
ALTER TABLE `klientai`
  ADD PRIMARY KEY (`id_klientas`);

--
-- Indexes for table `miestai`
--
ALTER TABLE `miestai`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mokejimai`
--
ALTER TABLE `mokejimai`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sumokejo` (`fk_klientas`),
  ADD KEY `apmoka` (`fk_saskaita`);

--
-- Indexes for table `parduotuves`
--
ALTER TABLE `parduotuves`
  ADD PRIMARY KEY (`parduotuves_id`),
  ADD KEY `turi` (`fk_miestas`);

--
-- Indexes for table `prekes`
--
ALTER TABLE `prekes`
  ADD PRIMARY KEY (`kodas`),
  ADD KEY `priklauso_` (`fk_kategorija`),
  ADD KEY `dieta` (`dieta`);

--
-- Indexes for table `sandeliai`
--
ALTER TABLE `sandeliai`
  ADD PRIMARY KEY (`kodas`),
  ADD KEY `turi_` (`fk_parduotuves_id`);

--
-- Indexes for table `saskaitos`
--
ALTER TABLE `saskaitos`
  ADD PRIMARY KEY (`nr`),
  ADD KEY `israsyta` (`fk_uzsakymas`);

--
-- Indexes for table `uzsakymai`
--
ALTER TABLE `uzsakymai`
  ADD PRIMARY KEY (`nr`,`uzsakymo_data`),
  ADD KEY `vykdo` (`fk_darbuotojo_id`),
  ADD KEY `sudaro` (`fk_id_klientas`),
  ADD KEY `busena` (`busena`);

--
-- Indexes for table `uzsakymo_prekes`
--
ALTER TABLE `uzsakymo_prekes`
  ADD PRIMARY KEY (`kodas`),
  ADD KEY `itraukta_i` (`fk_preke`),
  ADD KEY `sudarytas_is` (`fk_uzsakymas`,`fk_uzsakymo_data`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `busenos`
--
ALTER TABLE `busenos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  MODIFY `darbuotojo_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `prekes`
--
ALTER TABLE `prekes`
  MODIFY `kodas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `sandeliai`
--
ALTER TABLE `sandeliai`
  MODIFY `kodas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT for table `uzsakymo_prekes`
--
ALTER TABLE `uzsakymo_prekes`
  MODIFY `kodas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `darbuotojai`
--
ALTER TABLE `darbuotojai`
  ADD CONSTRAINT `dirba` FOREIGN KEY (`fk_parduotuves_id`) REFERENCES `parduotuves` (`parduotuves_id`);

--
-- Constraints for table `mokejimai`
--
ALTER TABLE `mokejimai`
  ADD CONSTRAINT `apmoka` FOREIGN KEY (`fk_saskaita`) REFERENCES `saskaitos` (`nr`),
  ADD CONSTRAINT `sumokejo` FOREIGN KEY (`fk_klientas`) REFERENCES `klientai` (`id_klientas`);

--
-- Constraints for table `parduotuves`
--
ALTER TABLE `parduotuves`
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_miestas`) REFERENCES `miestai` (`id`);

--
-- Constraints for table `prekes`
--
ALTER TABLE `prekes`
  ADD CONSTRAINT `prekes_ibfk_1` FOREIGN KEY (`dieta`) REFERENCES `dietos` (`id`),
  ADD CONSTRAINT `priklauso_` FOREIGN KEY (`fk_kategorija`) REFERENCES `kategorijos` (`id`);

--
-- Constraints for table `sandeliai`
--
ALTER TABLE `sandeliai`
  ADD CONSTRAINT `turi_` FOREIGN KEY (`fk_parduotuves_id`) REFERENCES `parduotuves` (`parduotuves_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
