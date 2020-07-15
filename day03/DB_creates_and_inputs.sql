CREATE TABLE Owner(
	owner_id INT CONSTRAINT owner_pk PRIMARY KEY,
	firstName VARCHAR(20) NOT NULL,
	lastName VARCHAR(20) NOT NULL,
	age INT NOT NULL,
	town VARCHAR(20) NOT NULL
);

CREATE TABLE Vehicle(
	vehicle_id INT CONSTRAINT vehicle_pk PRIMARY KEY,
	model VARCHAR(20) NOT NULL,
	kilometers INT NOT NULL,
	color VARCHAR(20) NOT NULL,
	owner_id INT CONSTRAINT vehicle_fk_owner REFERENCES Owner(owner_id)
);

INSERT INTO Owner values (1,'Borna','Sirovec',20,'Valpovo');
INSERT INTO Owner values (2,'Rene','Šandor',21,'Belišće');
INSERT INTO Owner values (3,'Arijan','Fuis',22,'Valpovo');
INSERT INTO Owner values (4,'Luka','Štrok',20,'Valpovo');
INSERT INTO Owner values (5,'Petar','Čvagić',20,'Šag');
INSERT INTO Owner values (6,'Dario','Zavišić',21,'Vinkovci');
INSERT INTO Owner values (7,'Luka','Žunić',19,'Zadar');

INSERT INTO Vehicle values (1,'Astra',215000,'black',1);
INSERT INTO Vehicle values (2,'A6',15000,'red',1);
INSERT INTO Vehicle values (3,'A1',150000,'white',2);
INSERT INTO Vehicle values (4,'Punto',214000,'purple',3);
INSERT INTO Vehicle values (5,'Corolla',300000,'mild green',3);
INSERT INTO Vehicle values (6,'R34',21000,'grey',4);
INSERT INTO Vehicle values (7,'E36',299999,'blue',4);
INSERT INTO Vehicle values (8,'Corsa',123000,'black',4);
INSERT INTO Vehicle values (9,'C_TWO',524,'white',5);
INSERT INTO Vehicle values (10,'Sharan',214710,'black',5);
INSERT INTO Vehicle values (11,'Golf',245136,'pink',6);
INSERT INTO Vehicle values (12,'Sccirocco',189620,'red',6);
INSERT INTO Vehicle values (13,'Yugo 45',84210,'yellow',7);
INSERT INTO Vehicle values (14,'RMax',745320,'gold',7);
INSERT INTO Vehicle values (15,'Octavia',382423,'black',7);
INSERT INTO Vehicle values (16,'Focus',123456,'black',7);
