SET datestyle = dmy;
-- lager kortlesertabellen
CREATE TABLE Kortleser (
    kortleser_ID CHAR(4) PRIMARY KEY not null,
    seksjon_ID INT not null,
    beskrivelse VARCHAR(100)
);

-- lager persontabellen
CREATE TABLE Bruker (
    kort_ID CHAR(4) PRIMARY KEY not null,
    fornavn VARCHAR(50) not null,
    etternavn VARCHAR(50) not null,
    epost CHAR(15),
    gyldighet_start TIMESTAMP DEFAULT '01.01.1753 00:00:00.000' not null,
    gyldighet_slutt TIMESTAMP DEFAULT '01.01.2999 00:00:00.000' not null,
    pin CHAR(4) not null,
    tilgang_ID INT
);

-- lager seksjonstabellen
CREATE TABLE Tilgangrelasjon (
    tilgangrelasjon_ID INT PRIMARY KEY,
    tilgang_ID INT not null,
    seksjon_ID INT not null
);

-- lager loggtabellen
CREATE TABLE logg (
    logg_type INT not null,
    logg_tid TIMESTAMP not null,
    kortleser_ID CHAR(4) not null,
    kort_ID CHAR(4) not null,
        -- FOREIGN KEY (kortleser_ID) REFERENCES kortleser(kortleser_ID),
        -- FOREIGN KEY (kort_ID) REFERENCES bruker(kort_ID)
);

--test data for kortleser, bruker- og seksjonstabellene
INSERT INTO kortleser (kortleser_ID, seksjon_ID, beskrivelse)
VALUES
('0001', 1, 'Inngang'),
('0002', 2, 'Datalab'),
('0003', 2, 'Kommunikasjonslab'),
('0004', 3, 'Kjemilab'),
('0005', 4, 'Lagerrom'),
('0006', 4, 'Bossrom'),
('0007', 1, 'Seminarrom'),
('0008', 1, 'Seminarrom'),
('0009', 1, 'Lesesal');

INSERT INTO bruker (kort_ID, fornavn, etternavn, epost, gyldighet_start, gyldighet_slutt, pin, tilgang_ID)
VALUES 
('0000', 'Anne', 'Andersen', '0000@bedrift.no', '2.11.2023 00:00:00.000', '20.11.2024 00:00:00.000', '0000', 1),
('1111', 'Ben', 'Bergsvik', '1111@bedrift.no', '2.11.2023 00:00:00.000', '20.11.2024 00:00:00.000', '0001', 1), 
('2222', 'Carl', 'Kristoffersen', '2222@bedrift.no', '2.11.2023 00:00:00.000', '20.11.2024 00:00:00.000', '0010', 2), 
('3333', 'Dennis', 'Drange', '3333@bedrift.no', '2.11.2023 00:00:00.000', '20.11.2024 00:00:00.000', '0011', 3);

INSERT INTO tilgangrelasjon (tilgangrelasjon_ID, tilgang_ID, seksjon_ID)
VALUES
(1, 1, 1),
(2, 1, 3),
(3, 2, 1),
(4, 2, 2),
(5, 3, 1),
(6, 3, 4);

--testdata for logg
insert into logg
values 
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(0, CURRENT_DATE, '0003', '1111'),
(2, CURRENT_DATE, '0002', '2222'),
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(0, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(1, CURRENT_DATE, '0003', '1111'),
(4, CURRENT_DATE, '0003', '1111'),
(2, CURRENT_DATE, '0003', '1111');