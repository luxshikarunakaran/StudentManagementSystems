-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 18, 2023 at 12:06 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `student_management_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `course`
--

CREATE TABLE `course` (
  `CourseID` int(50) NOT NULL,
  `CourseName` varchar(50) NOT NULL,
  `HoursNo` int(50) NOT NULL,
  `Description` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `course`
--

INSERT INTO `course` (`CourseID`, `CourseName`, `HoursNo`, `Description`) VALUES
(1, 'C#', 15, 'C# is a programming Language'),
(2, 'Electronics', 30, 'Electrics is a Physics Subject '),
(3, 'General Chemistry', 30, 'This course is a Theory '),
(4, 'Cyber Security', 15, 'It is very Intersting Course'),
(5, 'Optics', 30, 'It is a Practical Course\r\n'),
(6, 'Java', 20, 'Java is a programming Language'),
(7, 'Robotics', 45, 'This is very interesting ');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `Username` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`Username`, `Password`) VALUES
('[value-1]', '[value-2]'),
('admin', 'admin'),
('admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `score`
--

CREATE TABLE `score` (
  `StudentID` int(50) NOT NULL,
  `CourseName` varchar(50) NOT NULL,
  `Score` int(50) NOT NULL,
  `Description` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `score`
--

INSERT INTO `score` (`StudentID`, `CourseName`, `Score`, `Description`) VALUES
(1, 'C#', 90, 'Good reults\r\n'),
(2, 'Electronics', 85, 'Mavarlous'),
(3, 'General Chemistry', 69, 'Well done '),
(5, 'Optics', 95, 'Keep it '),
(6, 'Cyber Security', 87, 'Great'),
(3, 'General Chemistry', 54, 'Marked'),
(17, 'Electronics', 90, 'Great');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `StudentID` int(50) NOT NULL,
  `StudentName` varchar(50) NOT NULL,
  `BirthDay` varchar(50) NOT NULL,
  `Gender` varchar(50) NOT NULL,
  `PhoneNo` varchar(50) NOT NULL,
  `Address` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`StudentID`, `StudentName`, `BirthDay`, `Gender`, `PhoneNo`, `Address`) VALUES
(1, 'Luxshi Karunakaran', '25-Oct-99 10:02:35 AM', 'Female', '0765379820', 'Jaffna'),
(2, 'Gowsika Arasu', '22-Sep-99 10:08:03 AM', 'Female', '0761267686', 'Jaffna'),
(3, 'Shalini Balachcharan', '16-Jul-99 10:15:44 AM', 'Female', '0768978655', 'Jaffna'),
(4, 'Kuganpriyan Sivasingam', '18-Aug-99 7:47:42 AM', 'Male', '0756789234', 'Jaffna'),
(5, 'Mahesika Wanigarathne', '06-Jan-99 12:00:00 AM', 'Female', '0781278567', 'Galle'),
(6, 'Karunakaran Kajeepan', '02-Feb-03 12:00:00 AM', 'Male', '0761234678', 'United Kingdom'),
(7, 'Selvan Anojan', '11-Mar-99 12:00:00 AM', 'Male', '0765890123', 'Qutar'),
(8, 'Raja Mokan', '07-Jun-00 9:04:00 PM', 'Male', '0768912345', 'Kandy'),
(9, 'Tharmutha Pakalavan', '02-Feb-00 12:00:00 AM', 'Female', '0769087678', 'Jaffna'),
(10, 'Lavanya Thirumoorthy', '17-Jun-04 12:00:00 AM', 'Female', '0768923456', 'Matharai'),
(11, 'Raju Velmurugan', '21-Apr-05 12:00:00 AM', 'Male', '0768912345', 'Jaffna'),
(12, 'Wani Saravanan', '31-Dec-99 12:00:00 AM', 'Female', '0789012345', 'Jaffna'),
(13, 'Kayathiri Manoj', '21-Dec-00 9:49:33 AM', 'Female', '0768912891', 'Kandy\r\n'),
(14, 'Sanujan Keetheeswaran', '05-Feb-99 10:58:04 AM', 'Male', '0768923456', 'Nuwareliya'),
(15, 'Saranja Sivakaran', '08-Jun-04 12:00:00 AM', 'Female', '0765489123', 'Jaffna'),
(16, 'Saravanan Velu', '02-Feb-00 2:51:27 PM', 'Male', '0769012345', 'Jaffna'),
(17, 'Makesh Babu', '07-Jul-05 5:51:38 PM', 'Male', '0768912345', 'Jaffna'),
(18, 'Ratha Kirishna', '25-Nov-99 12:00:00 AM', 'Female', '0764567890', 'Matharai'),
(19, 'Sasimalini Praputheva', '02-Mar-00 9:00:55 AM', 'Female', '0768923456', 'Kandy');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `course`
--
ALTER TABLE `course`
  ADD PRIMARY KEY (`CourseID`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`StudentID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `course`
--
ALTER TABLE `course`
  MODIFY `CourseID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
  MODIFY `StudentID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
