-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Hoszt: 127.0.0.1
-- Létrehozás ideje: 2014. Dec 09. 15:33
-- Szerver verzió: 5.6.20
-- PHP verzió: 5.5.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Adatbázis: `kosarlabda_1`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `csapat`
--

CREATE TABLE IF NOT EXISTS `csapat` (
`id` int(11) NOT NULL,
  `nev` text NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- A tábla adatainak kiíratása `csapat`
--

INSERT INTO `csapat` (`id`, `nev`) VALUES
(1, 'KrumpliCsapat'),
(2, 'Káposzták'),
(3, 'Potato');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jatekosok`
--

CREATE TABLE IF NOT EXISTS `jatekosok` (
`id` int(11) NOT NULL,
  `csapat` text NOT NULL,
  `nev` text NOT NULL,
  `mez` int(11) NOT NULL,
  `magassag` int(11) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- A tábla adatainak kiíratása `jatekosok`
--

INSERT INTO `jatekosok` (`id`, `csapat`, `nev`, `mez`, `magassag`) VALUES
(1, '1', 'Krumpli János', 1, 197),
(2, '1;2;3', 'Árendás Pista', 2, 194),
(3, '3;2', 'Kovács Pistike', 52, 163);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `csapat`
--
ALTER TABLE `csapat`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `jatekosok`
--
ALTER TABLE `jatekosok`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `csapat`
--
ALTER TABLE `csapat`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `jatekosok`
--
ALTER TABLE `jatekosok`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=4;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
