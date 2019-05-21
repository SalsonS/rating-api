Instruction

You might need to install the mysqlconnector:
https://dev.mysql.com/downloads/connector/net/6.9.html

Use the following in MySql for set up the database:

DROP SCHEMA IF EXISTS RatingEvaluation;
CREATE SCHEMA `RatingEvaluation`;

DROP DATABASE IF EXISTS RatingEvaluation;
CREATE DATABASE `RatingEvaluation`;

CREATE TABLE RatingEvaluation.RatingValue (
    RatingValueId int NOT NULL AUTO_INCREMENT,
	Value varchar(50) NOT NULL,
    PRIMARY KEY (RatingValueId)
);

CREATE TABLE RatingEvaluation.Rating (
    RatingId int NOT NULL AUTO_INCREMENT,
	RatingValueId int NOT NULL,
    User varchar(255) NOT NULL,
    Date datetime NOT NULL,
    PRIMARY KEY (RatingId),
	FOREIGN KEY (RatingValueId) REFERENCES RatingValue(RatingValueId)
);

CREATE USER 'rating-tester'@'localhost' IDENTIFIED BY 'test123';
GRANT ALL PRIVILEGES ON * . * TO 'rating-tester'@'localhost' WITH GRANT OPTION;

INSERT INTO `ratingevaluation`.`ratingvalue` (`Value`) VALUES ('Great');
INSERT INTO `ratingevaluation`.`ratingvalue` (`Value`) VALUES ('Good');
INSERT INTO `ratingevaluation`.`ratingvalue` (`Value`) VALUES ('Meh');
INSERT INTO `ratingevaluation`.`ratingvalue` (`Value`) VALUES ('Bad');
INSERT INTO `ratingevaluation`.`ratingvalue` (`Value`) VALUES ('Awfull');

INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('1', 'Sale', '2019-05-21 07:00');
INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('2', 'Sale', '2019-05-21 08:00');
INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('3', 'Sale', '2019-05-21 09:00');
INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('4', 'Sale', '2019-05-21 1:00');
INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('5', 'Cone', '2019-05-21 3:00');
INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('2', 'Cone', '2019-05-21 4:00');
INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('2', 'Cone', '2019-05-21 5:00');
INSERT INTO `ratingevaluation`.`rating` (`RatingValueId`, `User`, `Date`) VALUES ('4', 'Cone', '2019-05-21 6:00');
