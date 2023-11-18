--todo

--hekt alle queries til noe i programet sentral, slik at en hendelse trigger hver av queriene
--fyll ut UI for logg meny - se notater "elementer: log vindu"
--endre oppkoblings informasjonen i sentral
--gå over ER for å dobeltsjekke logik
--dobelt sjekk notasjon - egen fil og kommentarer i kode - forklar valg 
--skal jeg lage views på alle queriene? kommer ann på hvordan kommunikasjon fungerer



--elementer: log vindu
--dropdown med de forskjellige loggene - se lengere ned, der er alle queriene som skal inn i logg velgern

--kort_id vindu

--kortleser_id vindu

--start tid vindu

--slutt tid vindu - disse skal bli writable når rett valg i dropdown er valgt/altid writable men noter hvilke vindu skal skrives i per dropdown valg.

--clear knapp - fjerner allt skrevet

--hent knap - gjør query og displayer til display vinduet

--lagre knap - lagrer det som er i display som en .txt fil - finn måte for valg av lagrings plass

--display vindu - bruk data felt 




-- merk at alle plasser hvor et variable er i '' skal det fylles inn ny data av programet sentral.

--drop down kommandoer: 
--liste brukerdata på grunnlag av kort_id
select * from bruker

-- liste adgangslogg (inkludert forsøk på adgang) på grunnlag av kort_id mellom to datoer
select * from log where kort_id = 'x' and (log_type = 0 or log_type = 1 or log_type = 2) and log_tid between 'start_date' and 'end_date'

-- liste alle innpasseringsforsøk for en dør med ikke-godkjent adgang (uansett bruker) mellom to datoer
select * from log where log_type = 1 and log_tid between 'start_date' and 'end_date'

--liste alle kort_id med over 10 ikke godkjente log_type = 1
select log.log_type, log.kort_id from log
where log_type = 1 and log_tid between '1753-01-01 00:00:00.000' and '2999-01-01 00:00:00.000'
group by log.kort_id, log.log_type
having count(*) >= 10

--liste av alarmer mellom to datoer
select * from log where (log_type = 3 or log_type = 2) and log_tid between 'start_date' and 'end_date'

-- liste alle entries log 
select * from log

--liste alle entries basert på kort_id
select * from log where kort_id = 'kort_id'

--liste alle entries for bestemt kortleser_id
select * from log where kortleser_id = 'kortleser_id'

--liste av alarmer
select * from log where (log_type = 3 or log_type = 2)

--liste av alarmer basert på kort_id
select * from log where (log_type = 3 or log_type = 2) and kort_id = 'kort_id'

--liste av alarmer basert på kort_id
select * from log where (log_type = 3 or log_type = 2) and kortleser_id = 'kortleser_id'



--Spørringer for brukere:
--legg til bruker(kort_id, fornavn, etternavn, email, g_start, g_slutt, pin, tilgang_id)
insert into bruker values ('kort_id', 'fornavn', 'etternavn', 'email', 'g_start', 'g_slutt', 'pin', 'tilgang_id')

--endre bruker(kort_id, fornavn, etternavn, email, g_start, g_slutt, pin, tilgang_id)
update bruker 
set fornavn = 'fornavn', etternavn = 'etternavn', email = 'email', gyldighet_start = 'g_start',
gyldighet_slutt = 'g_slutt',pin = 'pin', tilgang_id = 'tilgang_id'
where kort_id = 'kort_id'

-- slett bruker
delete from bruker where kort_id = 'kort_id'




--Spørringer for kortlesere:
--legg til kortleser(kortleser_id, seksjon_id, plass)
insert into kortleser values ('kortleser_id', 'seksjon_id', 'plass')

--endre kortleser(kortleser_id, seksjon_id, plass)
update kortleser
set kortleser_id = 'kortleser_id', seksjon_id = 'seksjon_id', plass = 'plass'
where kortleser_id = 'kortleser_id'

-- slett kortleser
delete from kortleser where kortleser_id = 'kortleser_id'





--validering prosses: den returnerer en rad med info om det er finnes en match og ikke om det ikke finnes

select * from tilgangrelasjon
join bruker on tilgangrelasjon.tilgang_id = bruker.tilgang_id
join kortleser on tilgangrelasjon.seksjon_id = kortleser.seksjon_id
where kort_id = 'kort_id'
and pin = 'pin'
and kortleser_id = 'kortleser_id'
and CURRENT_DATE between gyldighet_start and gyldighet_slutt


--dann log alarmer
insert into log values ('log_type', 'log_tid', 'kortleser_id', 'kort_id')
--for situasjoner hvor log skal inkludere siste kort_id : denne returnerer siste log fra den 
SELECt * FROM log where kortleser_id = 'kortleser_id' ORDER BY log_tid DESC limit 1

--NB merk det må finnes plasser hvor disse queries kan sendes, altså alerede etablerte hendelser og noen kommandoer som har med log menyen må det lages hendelser og gui for. er markert hvilke elementer som trengs i toppen.