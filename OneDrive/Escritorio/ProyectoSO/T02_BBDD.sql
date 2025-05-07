DROP DATABASE IF EXISTS T02_BBDD;
CREATE DATABASE T02_BBDD;
USE T02_BBDD;

CREATE TABLE jugadores (
	id INT not NULL, 
	PRIMARY KEY(id),
	nombre VARCHAR(25),
	contrasenya VARCHAR(20),
	mail VARCHAR(100)
)ENGINE = InnoDB;

CREATE TABLE partidas (
	id INT not NULL,
	PRIMARY KEY(id),
	fecha VARCHAR(10),
	ganador VARCHAR(25) DEFAULT '-',
	duracion INT not NULL
)ENGINE = InnoDB;

CREATE TABLE registro (
	idJ INT,
	FOREIGN KEY(idJ) REFERENCES jugadores(id),
	idP INT,
	FOREIGN KEY(idP) REFERENCES partidas(id),
	puntos INT not NULL
)ENGINE = InnoDB;

INSERT INTO jugadores VALUES (1, 'Marc', 'marc123','marc.fernandez@estudiantat.upc.edu');
INSERT INTO jugadores VALUES (2, 'Alvaro', 'alvaro123','alvaro.jimenez@estudiantat.upc.edu');
INSERT INTO jugadores VALUES (3, 'Andres', 'andres123','andres.iniesta@upc.edu');
INSERT INTO jugadores VALUES (4, 'David', 'david123','david.villa@upc.edu');

INSERT INTO partidas VALUES (1, '05/11/2023', 'Marc',100);
INSERT INTO partidas VALUES (2, '05/11/2023', 'Alvaro', 500);
INSERT INTO partidas VALUES (3, '05/11/2023', 'Andres',750);
INSERT INTO partidas VALUES (4, '05/11/2023', 'David',240);


INSERT INTO registro VALUES (1, 1, 10);
INSERT INTO registro VALUES (2, 1, 8);
INSERT INTO registro VALUES (2, 2, 7);
INSERT INTO registro VALUES (3, 2, 5);
INSERT INTO registro VALUES (4, 3, 11);
INSERT INTO registro VALUES (2, 3, 9);
INSERT INTO registro VALUES (4, 4, 8);
INSERT INTO registro VALUES (1, 4, 7);

