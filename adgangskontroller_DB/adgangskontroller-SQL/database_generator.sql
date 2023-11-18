-- lager kortleser tabellen
CREATE TABLE kortleser (
    kortleser_id INT PRIMARY KEY not null,
    seksjon_id INT not null,
    plass VARCHAR(100) not null
);

-- lager person tabellen
CREATE TABLE bruker (
    kort_id INT PRIMARY KEY not null,
    fornavn VARCHAR(50) not null,
    etternavn VARCHAR(50) not null,
    email VARCHAR(50),
    gyldighet_start TIMESTAMP DEFAULT '1753-01-01 00:00:00.000' not null,
    gyldighet_slutt TIMESTAMP DEFAULT '2999-01-01 00:00:00.000' not null,
    pin INT not null,
    tilgang_id INT
);

-- lager seksjon tabellen
CREATE TABLE tilgangrelasjon (
    tilgangrelasjon_id INT PRIMARY KEY,
    tilgang_id INT not null,
    seksjon_id INT not null
);

-- lager log tabellen
CREATE TABLE log (
    log_type INT not null,
    log_tid TIMESTAMP not null,
    kortleser_id INT not null,
    kort_id INT not null,
    FOREIGN KEY (kortleser_id) REFERENCES kortleser(kortleser_id),
    FOREIGN KEY (kort_id) REFERENCES bruker(kort_id));
);

--test data for kortleser, bruker og seksjon tabellene
INSERT INTO kortleser (kortleser_id, seksjon_id, plass)
VALUES
(1, 1, 'ingang'),
(2, 2, 'datalab'),
(3, 3, 'kjemilab'),
(4, 4, 'lagerrom'),
(5, 4, 'søppelrom');

INSERT INTO bruker (kort_id, fornavn, etternavn, pin, tilgang_id)
VALUES 
(0000, 'ana', 'anders', 0000, 1),
(1111, 'ben', 'berg', 0001, 1), 
(2222, 'carl', 'christofer', 0010, 2), 
(3333, 'dennis', 'dreng', 0011, 3);

INSERT INTO tilgangrelasjon (tilgangrelasjon_id, tilgang_id, seksjon_id)
VALUES
(1, 1, 1),
(2, 1, 3),
(3, 2, 1),
(4, 2, 2),
(5, 3, 1),
(6, 3, 4);

--test data for log
insert into log
values 
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(0, CURRENT_DATE, 3, 1111),
(2, CURRENT_DATE, 2, 2222),
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(0, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(1, CURRENT_DATE, 3, 1111),
(4, CURRENT_DATE, 3, 1111),
(2, CURRENT_DATE, 3, 1111)