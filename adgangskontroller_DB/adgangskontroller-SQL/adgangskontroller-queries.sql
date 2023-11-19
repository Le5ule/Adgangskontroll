--todo

--hekt alle queries til noe i programet sentral, slik at en hendelse trigger hver av queriene
--fyll ut UI for logg meny - se notater "elementer: logg vindu"
--endre oppkoblings informasjonen i sentral
--gå over ER for å dobeltsjekke logik
--dobelt sjekk notasjon - egen fil og kommentarer i kode - forklar valg 
--skal jeg lage views på alle queriene? kommer ann på hvordan kommunikasjon fungerer



--elementer: loggvindu
--dropdown med de forskjellige loggene - se lengre ned, der er alle queriene som skal inn i loggvelgeren

--kort_id-vindu

--kortleser_id-vindu

--start_tid-vindu

--slutt_tid-vindu - disse skal bli writable når rett valg i dropdown er valgt/alltid writable, men notér hvilke vindu skal skrives i per dropdown valg.

--clear-knapp - fjerner alt skrevet

--hent-knapp - gjør query og displayer til display vinduet

--lagre-knapp - lagrer det som er i display som en .txt fil - finn måte for valg av lagrings plass

--display-vindu - bruk datafelt 




-- merk at alle plasser hvor et variable er i '' skal det fylles inn ny data av programet sentral.

--drop-down-kommandoer: 
--liste brukerdata på grunnlag av kort_id
select * from bruker

-- liste adgangslogg (inkludert forsøk på adgang) på grunnlag av kort_id mellom to datoer
select * from logg where kort_id = 'x' and (logg_type = 0 or logg_type = 1 or logg_type = 2) and logg_tid between 'start_date' and 'end_date'

-- liste alle innpasseringsforsøk for en dør med ikke-godkjent adgang (uansett bruker) mellom to datoer
select * from logg where kortleser_id = 'kortleser_id' and logg_type = 1 and logg_tid between 'start_date' and 'end_date'

--liste alle kort_id med over 10 ikke godkjente logg_type = 1
select logg.logg_type, logg.kort_id from logg
where logg_type = 1 and logg_tid between '1753-01-01 00:00:00.000' and '2999-01-01 00:00:00.000'
group by logg.kort_id, logg.logg_type
having count(*) >= 10

--liste av alarmer mellom to datoer
select * from logg where (logg_type = 3 or logg_type = 2) and logg_tid between 'start_date' and 'end_date'

-- liste alle entries logg 
select * from logg

--liste alle entries basert på kort_id
select * from logg where kort_id = 'kort_id'

--liste alle entries for bestemt kortleser_id
select * from logg where kortleser_id = 'kortleser_id'

--liste av alarmer
select * from logg where (logg_type = 3 or logg_type = 2)

--liste av alarmer basert på kort_id
select * from logg where (logg_type = 3 or logg_type = 2) and kort_id = 'kort_id'

--liste av alarmer basert på kort_id
select * from logg where (logg_type = 3 or logg_type = 2) and kortleser_id = 'kortleser_id'



--Spørringer for brukere:
--legg til bruker(kort_id, fornavn, etternavn, epost, g_start, g_slutt, pin, tilgang_id)
insert into bruker values ('kort_id', 'fornavn', 'etternavn', 'epost', 'g_start', 'g_slutt', 'pin', 'tilgang_id')

--endre bruker(kort_id, fornavn, etternavn, epost, g_start, g_slutt, pin, tilgang_id)
update bruker 
set fornavn = 'fornavn', etternavn = 'etternavn', epost = 'epost', gyldighet_start = 'g_start',
gyldighet_slutt = 'g_slutt',pin = 'pin', tilgang_id = 'tilgang_id'
where kort_id = 'kort_id'

-- slett bruker
delete from bruker where kort_id = 'kort_id'




--Spørringer for kortlesere:
--legg til kortleser(kortleser_id, seksjon_id, plass)
insert into kortleser values ('kortleser_id', 'seksjon_id', 'plass')

--endre kortleser(kortleser_id, seksjon_id, plass)
update kortleser
set seksjon_id = 'seksjon_id', plass = 'plass'
where kortleser_id = 'kortleser_id'

-- slett kortleser
delete from kortleser where kortleser_id = 'kortleser_id'



--autentiseringsprosses: denne returnerer en rad med info om det er finnes en match og ikke om det ikke finnes

select * from tilgangrelasjon
join bruker on tilgangrelasjon.tilgang_id = bruker.tilgang_id
join kortleser on tilgangrelasjon.seksjon_id = kortleser.seksjon_id
where kort_id = 'kort_id'
and pin = 'pin'
and kortleser_id = 'kortleser_id'
and CURRENT_DATE between gyldighet_start and gyldighet_slutt


--dann logg alarmer
insert into logg values ('logg_type', 'logg_tid', 'kortleser_id', 'kort_id')
--for situasjoner hvor logg skal inkludere siste kort_id : denne returnerer siste logg 
SELECt * FROM logg where kortleser_id = 'kortleser_id' ORDER BY logg_tid DESC limit 1

--NB merk det må finnes plasser hvor disse queries kan sendes, altså allerede-etablerte hendelser og noen kommandoer som har med loggmenyen må det lages hendelser og gui for. Er markert hvilke elementer som trengs i toppen.