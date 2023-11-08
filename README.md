# Adgangskontroll

Legg til dette i din database før du bruker programmet.
Denne tabellen er kun for enkle tester, vil bli utvidet og laget flere etterhvert.

Husk å les gjennom kode og kommentarer før bruk for å sikre at du forstår bruksområde.
Skikkelig bruksanvisning vil bli laget senere.


CREATE TABLE Brukere 
(
	Kort_ID CHAR(4) UNIQUE,
	Pin CHAR(4),
	PRIMARY KEY (Kort_ID, Pin)
);


INSERT INTO Brukere values('0000','0000');
INSERT INTO Brukere values('1111','0001');
INSERT INTO Brukere values('2222','0010');
INSERT INTO Brukere values('3333','0011');
