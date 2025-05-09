-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Jún 14. 20:01
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `webprog_rest_api_II`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `emailAddress` varchar(100) NOT NULL,
  `address` varchar(255) NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`id`, `name`, `emailAddress`, `address`, `active`) VALUES
(1, 'Brew Irvin', 'birvin0@vkontakte.ru', '1242 David Pass', 1),
(2, 'Germaine Cadd', 'gcadd1@google.ru', '66640 Lukken Center', 0),
(3, 'Shelli Tremayle', 'stremayle2@imgur.com', '38 Dahle Park', 0),
(4, 'Milicent Antonacci', 'mantonacci3@upenn.edu', '63276 Westridge Alley', 1),
(5, 'Rhody Bruniges', 'rbruniges4@studiopress.com', '0244 Arizona Street', 0),
(6, 'Indira Christou', 'ichristou5@prnewswire.com', '9841 Bluejay Plaza', 0),
(7, 'Oralie Ovitz', 'oovitz6@privacy.gov.au', '2755 Moulton Crossing', 1),
(8, 'Mendel Lampett', 'mlampett7@auda.org.au', '3 Montana Junction', 1),
(9, 'Stormy Verry', 'sverry8@salon.com', '46127 Northwestern Parkway', 0),
(10, 'Dani Gewer', 'dgewer9@weibo.com', '7 Cottonwood Court', 0),
(11, 'Ariel Haney', 'ahaneya@wiley.com', '15358 Lukken Trail', 1),
(12, 'Aylmer Mallon', 'amallonb@ifeng.com', '89079 Mcguire Alley', 0),
(13, 'Delly Dixsee', 'ddixseec@slate.com', '1 Pierstorff Court', 0),
(14, 'Jule Borghese', 'jborghesed@ucla.edu', '4327 Norway Maple Alley', 0),
(15, 'Kinna Jannequin', 'kjannequine@java.com', '24 Gerald Crossing', 0),
(16, 'Alix Dwelly', 'adwellyf@marketwatch.com', '1246 Delladonna Place', 0),
(17, 'Lizzie Boase', 'lboaseg@youtu.be', '091 Burning Wood Alley', 1),
(18, 'Howie Beard', 'hbeardh@mail.ru', '58 Ludington Drive', 0),
(19, 'Sibby Ackers', 'sackersi@vinaora.com', '79 New Castle Trail', 0),
(20, 'Phillip Bayless', 'pbaylessj@skype.com', '42520 Montana Lane', 0),
(21, 'Rodrique Daniele', 'rdanielek@nba.com', '16285 Corry Court', 1),
(22, 'Cherianne Tomkys', 'ctomkysl@fema.gov', '520 Thackeray Way', 0),
(23, 'Frances Verlinde', 'fverlindem@nba.com', '00 Crescent Oaks Parkway', 0),
(24, 'Em Jahnisch', 'ejahnischn@mozilla.com', '01938 Logan Street', 1),
(25, 'Kipp Tingey', 'ktingeyo@livejournal.com', '6917 Hovde Hill', 0),
(26, 'Marcelia Blazek', 'mblazekp@google.co.uk', '1513 Vahlen Terrace', 1),
(27, 'Jase Scorer', 'jscorerq@state.tx.us', '282 Green Avenue', 0),
(28, 'Celestyna Danniell', 'cdanniellr@ustream.tv', '12212 Anzinger Crossing', 0),
(29, 'Sheelagh Monday', 'smondays@quantcast.com', '5578 Sloan Street', 0),
(30, 'Raff Clapham', 'rclaphamt@fastcompany.com', '5 Johnson Pass', 0),
(31, 'Dalston Ravenhills', 'dravenhillsu@weather.com', '0660 Vernon Trail', 0),
(32, 'Jolyn Dorkins', 'jdorkinsv@arizona.edu', '7 Straubel Street', 0),
(33, 'Bale Ipplett', 'bipplettw@youtube.com', '98511 Crowley Lane', 1),
(34, 'Jamie Berryann', 'jberryannx@google.com.br', '37 Mendota Way', 1),
(35, 'Gertruda Constable', 'gconstabley@canalblog.com', '9307 Killdeer Crossing', 1),
(36, 'Pail Bartczak', 'pbartczakz@ocn.ne.jp', '67734 Utah Crossing', 0),
(37, 'Armstrong Strut', 'astrut10@usatoday.com', '50586 Division Circle', 0),
(38, 'Dall Leinthall', 'dleinthall11@wsj.com', '0 Mariners Cove Place', 0),
(39, 'Sonny Benedyktowicz', 'sbenedyktowicz12@about.com', '72361 Donald Street', 0),
(40, 'Jorgan Buckel', 'jbuckel13@prnewswire.com', '7331 North Junction', 1),
(41, 'Catlee Beeden', 'cbeeden14@multiply.com', '16933 Village Green Circle', 0),
(42, 'Ramonda Francescuzzi', 'rfrancescuzzi15@odnoklassniki.ru', '07729 Artisan Center', 0),
(43, 'Vin Prettyman', 'vprettyman16@nhs.uk', '5825 Logan Center', 1),
(44, 'Charissa Nolan', 'cnolan17@nymag.com', '9 Johnson Parkway', 0),
(45, 'Klarika Hollibone', 'khollibone18@ucsd.edu', '5 Namekagon Trail', 0),
(46, 'Harold Seely', 'hseely19@nyu.edu', '77730 Lillian Parkway', 1),
(47, 'Adaline Villa', 'avilla1a@newsvine.com', '6 Glacier Hill Drive', 0),
(48, 'Vaclav Hayter', 'vhayter1b@gmpg.org', '2087 Vidon Trail', 0),
(49, 'Wilfrid Goshawke', 'wgoshawke1c@usnews.com', '697 Monica Place', 1),
(50, 'Rafferty Bluschke', 'rbluschke1d@europa.eu', '9392 Shasta Place', 0),
(51, 'Johnnie Morffew', 'jmorffew1e@wsj.com', '8 Karstens Trail', 0),
(52, 'Jilli Konrad', 'jkonrad1f@biblegateway.com', '631 Golf Course Terrace', 0),
(53, 'Caresa Welling', 'cwelling1g@mail.ru', '115 Pine View Circle', 0),
(54, 'Justina Urpeth', 'jurpeth1h@washington.edu', '808 Pond Alley', 0),
(55, 'Putnam Bissex', 'pbissex1i@nyu.edu', '26263 David Way', 0),
(56, 'Terrie Shankster', 'tshankster1j@hud.gov', '0889 Northview Street', 1),
(57, 'Bartholomeus Gartin', 'bgartin1k@vimeo.com', '5 Schlimgen Hill', 0),
(58, 'Hephzibah Tant', 'htant1l@fotki.com', '3 Eastwood Trail', 0),
(59, 'Sybilla Focke', 'sfocke1m@addtoany.com', '57473 Moulton Terrace', 0),
(60, 'Tadd Fetherston', 'tfetherston1n@youku.com', '8 Cambridge Center', 0),
(61, 'Adelaida Ridgley', 'aridgley1o@apple.com', '43 Carioca Circle', 1),
(62, 'Zita Mitro', 'zmitro1p@seesaa.net', '42 Monument Parkway', 0),
(63, 'Creight Mindenhall', 'cmindenhall1q@princeton.edu', '81788 Tomscot Park', 0),
(64, 'Rozina Markwick', 'rmarkwick1r@myspace.com', '9698 Bluestem Crossing', 0),
(65, 'Bryn Pembridge', 'bpembridge1s@twitter.com', '6649 Bartelt Avenue', 0),
(66, 'Konstance Talmadge', 'ktalmadge1t@stanford.edu', '94 Briar Crest Street', 1),
(67, 'Ado Hardwich', 'ahardwich1u@live.com', '11 Ohio Court', 0),
(68, 'Lynett Blackhall', 'lblackhall1v@soundcloud.com', '64 Springs Trail', 0),
(69, 'Antin Jeeves', 'ajeeves1w@fastcompany.com', '4016 Corscot Court', 1),
(70, 'Anthe Simukov', 'asimukov1x@amazon.co.jp', '4 Bellgrove Way', 1),
(71, 'Tobit Verheijden', 'tverheijden1y@cpanel.net', '028 Fremont Pass', 0),
(72, 'Allyce Scripture', 'ascripture1z@mashable.com', '511 Ohio Way', 0),
(73, 'Gabbie Ferre', 'gferre20@fotki.com', '6 Forest Run Avenue', 0),
(74, 'Benedicta Ronan', 'bronan21@printfriendly.com', '7202 Larry Plaza', 0),
(75, 'Aguste La Grange', 'ala22@businessweek.com', '3 Grayhawk Terrace', 0),
(76, 'Sigismund Nial', 'snial23@rakuten.co.jp', '3584 Kennedy Court', 0),
(77, 'Cyndia Sargeaunt', 'csargeaunt24@bravesites.com', '4903 Carberry Place', 0),
(78, 'Land Jamison', 'ljamison25@i2i.jp', '987 Farwell Street', 0),
(79, 'Vladimir Capineer', 'vcapineer26@columbia.edu', '642 Upham Alley', 0),
(80, 'Karleen Scotchmer', 'kscotchmer27@cocolog-nifty.com', '4686 Little Fleur Junction', 0),
(81, 'Jarib Beckenham', 'jbeckenham28@simplemachines.org', '56 Sloan Crossing', 1),
(82, 'Ginevra Corder', 'gcorder29@nyu.edu', '5 Monica Trail', 0),
(83, 'Lauretta Wheatcroft', 'lwheatcroft2a@prnewswire.com', '93 Myrtle Plaza', 0),
(84, 'Nick Imos', 'nimos2b@com.com', '7212 Stuart Street', 1),
(85, 'Bonni Steljes', 'bsteljes2c@domainmarket.com', '2369 Heffernan Crossing', 0),
(86, 'Hazel Bradie', 'hbradie2d@state.gov', '86623 Sauthoff Pass', 1),
(87, 'Eugine LeEstut', 'eleestut2e@hibu.com', '2985 Macpherson Crossing', 0),
(88, 'Burk Curnokk', 'bcurnokk2f@fotki.com', '9745 Sloan Avenue', 0),
(89, 'Torey Shorto', 'tshorto2g@mapy.cz', '8 Kensington Point', 0),
(90, 'Shandie Ingman', 'singman2h@un.org', '1435 New Castle Place', 0),
(91, 'Feliks Ruffy', 'fruffy2i@wikia.com', '53930 Portage Trail', 0),
(92, 'Cathrine Dawson', 'cdawson2j@cbslocal.com', '4312 Sage Point', 0),
(93, 'Jenni Goede', 'jgoede2k@pinterest.com', '6 Mcbride Parkway', 0),
(94, 'Byrom Binham', 'bbinham2l@taobao.com', '1 Lake View Circle', 0),
(95, 'Elga Isham', 'eisham2m@disqus.com', '79669 Riverside Place', 0),
(96, 'Willis Reisk', 'wreisk2n@devhub.com', '425 Clove Place', 1),
(97, 'Ilise Naylor', 'inaylor2o@google.ca', '2 Tomscot Circle', 0),
(98, 'Marybeth Murrthum', 'mmurrthum2p@skype.com', '7 Becker Park', 1),
(99, 'Tadeo Witherspoon', 'twitherspoon2q@buzzfeed.com', '60 Waywood Terrace', 0),
(100, 'Phillida Betun', 'pbetun2r@reverbnation.com', '9 Portage Circle', 0);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
