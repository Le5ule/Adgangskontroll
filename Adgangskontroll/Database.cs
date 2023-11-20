using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Npgsql;

namespace Sentral
{
    internal class Database
    {
        private static Random r = new Random();
        private static int random = r.Next(0, 9999);    // Brukes til å generere pin-kode for å legge inn nye brukere

        private static DataTable dtgetData = new DataTable();
        private static NpgsqlConnection vCon;
        private static NpgsqlCommand vCmd;


        // Datamedlemmer for å oppdatere disse variablene fra programmet ved sending av ulike spørringer
        public static NpgsqlCommand VCmd
        {
            get { return vCmd; }
            set { vCmd = value; }
        }
        public static NpgsqlConnection VCon
        {
            get { return vCon; }
            set { vCon = value; }
        }
        public static DataTable DtgetData
        {
            get { return dtgetData; }
            set { dtgetData = value; }
        }

        // Konstruktør for generel tilkobling fra andre klasser/forms til database-metodene
        public Database()
        {

        }

        // Konstruktør for opprette tilkobling til database via sentral
        public Database(string server, string port, string user_id, string password, string database)
        {
            // Etablerer tilkobling
            vCon = new NpgsqlConnection($"server={server} ; port={port} ; user id={user_id} ; password={password} ; database={database} ;");

            // Etablerer queryobjekt
            vCmd = new NpgsqlCommand();

            // Kobler til databasen
            Connection();
        }

        // Metode for å opprette tilkobling mot database
        public NpgsqlConnection Connection()
        {
            try
            {
                if (vCon.State == ConnectionState.Closed)
                {
                    vCon.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vCon;
        }

        // Metode for å sende og motta informasjon mellom sentral og database
        public DataTable getData(string sql)
        {
            DataTable dt = new DataTable();
            vCmd = new NpgsqlCommand();
            vCmd.Connection = vCon;
            vCmd.CommandText = sql;

            NpgsqlDataReader dr = vCmd.ExecuteReader();
            dt.Load(dr);

            return dt;
        }
      

        // Autentisering tar inn kort_id, pin og kortleser_id.
        // Sjekker om pin matcher kort_id, om kort_id er innenfor gyldighetsperioden
        // og om kort_id har tilgang til kortleser_id.
        // Hvis prossesen feiler returnerer den blankt, om den er er ok returnerer den
        // en rad med bruker og kortleser (den informasjonen som ble sendt inn) spleiset sammen.
        public string Autentisering(string kort_id, string pin, string kortleser_id)
        {
            string suksess;
            string query = ($"select * from tilgangrelasjon join bruker on tilgangrelasjon.tilgang_id = bruker.tilgang_id join kortleser on tilgangrelasjon.seksjon_id = kortleser.seksjon_id where kort_id = '{kort_id}' and pin = '{pin}' and kortleser_id = '{kortleser_id}' and CURRENT_DATE between gyldighet_start and gyldighet_slutt;");
            VCmd = new NpgsqlCommand(query, VCon);

            using NpgsqlDataReader reader = VCmd.ExecuteReader();
            if (reader.Read())  // Kommando for å "lese" om vi får returnert en tabell fra spørringen vi sender
            {
                suksess = "Godkjent";
            }
            else  // Dersom vi ikke får returnert en tabell fra spøøringen
            {
                suksess = "Ikke godkjent";
            }
            return suksess; // Blir sendt som dataTilKortleser
        }
        


        // Legger en ny rad inn i brukertabellen 
        public DataTable LeggTilNyBruker(string fornavn, string etternavn, string kort_id, string seksjon, string start, string slutt)
        {
            int pin = r.Next(0,9999);
            string epost = $"{kort_id}@bedrift.no";     //hvis ikke kan vi få duplikater
            dtgetData = getData($"insert into bruker values ('{kort_id}', '{fornavn}', '{etternavn}', '{epost}', '{start}', '{slutt}', '{pin}', {seksjon});");
            DataTable dt = dtgetData;

            return dt;
        }

        // Skriver inn alle verdiene til en rad i brukertabellen på nytt, ved å identifisere raden utifra kort_id
        public DataTable EndreBruker(string fornavn, string etternavn, string kort_id, string seksjon, string start, string slutt)
        {
            int pin = r.Next(0, 9999);
            string epost = $"{kort_id}@bedrift.no";     // hvis ikke kan vi få duplikater
            dtgetData = getData($"update bruker set fornavn = '{fornavn}', etternavn = '{etternavn}', epost = '{epost}', gyldighet_start = '{start}', gyldighet_slutt = '{slutt}',pin = '{pin}', tilgang_id = {seksjon} where kort_id = '{kort_id}'"); 
            DataTable dt = dtgetData;

            return dt;
        }

        // Sletter en rad fra brukertabellen ved å identifisere raden utifra kort_id
        public DataTable SlettBruker(string kort_id)
        {
            dtgetData = getData($"delete from bruker where kort_id = '{kort_id}'");
            DataTable dt = dtgetData;

            return dt;
        }


        // Legger inn en ny rad i kortlesertabellen 
        public DataTable LeggTilNyKortleser(string kortleser_id, string seksjon_id, string beskrivelse)
        {
            dtgetData = getData($"insert into kortleser values ('{kortleser_id}', '{seksjon_id}', '{beskrivelse}');");
            DataTable dt = dtgetData;

            return dt;
        }

        // Skriver inn alle verdiene til en rad i kortlesertabellen på nytt, ved å identifisere raden utifra kort_id
        public DataTable EndreKortleser(string kortleser_id, string seksjon_id, string beskrivelse)
        {
            dtgetData = getData($"update kortleser set seksjon_id = {seksjon_id}, beskrivelse = '{beskrivelse}' where kortleser_id = '{kortleser_id}'");
            DataTable dt = dtgetData;

            return dt;
        }

        // Sletter en rad fra kortlesertabellen, ved å identifisere raden utofra kort_id
        public DataTable SlettKortleser(string kortleser_id)
        {
            dtgetData = getData($"delete from kortleser where kortleser_id = '{kortleser_id}'");
            DataTable dt = dtgetData;

            return dt;
        }

        // Loggfører og legger inn en rad i loggtabellen
        public DataTable LeggTilLogg(int logg_type, string kortleser_id, string kort_id)
        {
            
            dtgetData = getData($"insert into logg values ({logg_type}, CURRENT_TIMESTAMP, '{kortleser_id}', '{kort_id}');");
            DataTable dt = dtgetData;

            return dt;
        }

        // ikke i bruk

        // Henter ut nyligste rad fra logtabellen for en viss kortleser_id, brukes for å hente siste kort_id registrert på en kortleser (brukes ved enkelte logger)
        // For mer informasjon om logg_type se adgangskontroller-DB-notasjon.txt
        public DataTable VisSisteLogg(int logg_type, string logg_tid, string kortleser_id, int kort_id)
        {
            dtgetData = getData($"SELECt * FROM logg where kortleser_id = '{kortleser_id}' ORDER BY logg_tid DESC limit 1");
            DataTable dt = dtgetData;

            return dt;
        }


        // Returnerer en tabell med alle rader i kortlesertabellen
        public DataTable VisKortlesere()
        {
            dtgetData = getData("select * from kortleser");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer en tabell med alle rader i kortlesertabellen for en valgt seksjon
        public DataTable VisKortleserVedSeksjon(int seksjon_id)
        {
            dtgetData = getData($"select * from kortleser where seksjon_id = {seksjon_id}");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returener en tabell med alle rader i brukertabellen
        public DataTable VisBrukere()
        {
            dtgetData = getData("select * from bruker");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Lister adgangslogg (inkludert forsøk på adgang) utifra kort_id mellom to datoer
        public DataTable VisAdgangsloggForBrukerVedDato(string kort_id, string start, string slutt)
        {
            dtgetData = getData($"select * from logg where kort_id = '{kort_id}' and (logg_type = 0 or logg_type = 1 or logg_type = 2) and logg_tid between '{start}' and '{slutt}'");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer alle innpasseringsforsøk for en dør med ikke-godkjent adgang (uansett bruker) mellom to datoer
        public DataTable VisNegativAdgangsloggKortleserVedDato(string kortleser_id, string start, string slutt)
        {
            dtgetData = getData($"select * from logg where kortleser_id = '{kortleser_id}' and logg_type = 1 and logg_tid between '{start}' and '{slutt}'");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer alarmer
        public DataTable VisAlarm()
        {
            dtgetData = getData($"select * from logg where (logg_type = 3 or logg_type = 4)");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer alarmer ved kort_id
        public DataTable VisAlarmVedBruker(string kort_id)
        {
            dtgetData = getData($"select * from logg where (logg_type = 3 or logg_type = 4) and kort_id = '{kort_id}'");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer alarmer ved kortleser_id
        public DataTable VisAlarmVedKortleser(string kortleser_id)
        {
            dtgetData = getData($"select * from logg where (logg_type = 3 or logg_type = 4) and kortleser_id = '{kortleser_id}'");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer alarmer mellom to datoer
        public DataTable VisAlarmVedDato(string start, string slutt)
        {
            dtgetData = getData($"select * from logg where (logg_type = 3 or logg_type = 4) and logg_tid between '{start}' and '{slutt}'");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // returnerer alle entries i loggtabellen
        public DataTable VisLogg()
        {
            dtgetData = getData($"select * from logg");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer alle entries fra loggtabellen basert på kort_id
        public DataTable VisLoggVedBruker(string kort_id)
        {
            dtgetData = getData($"select * from logg where kort_id = '{kort_id}'");
            DataTable dt = Database.DtgetData;

            return dt;
        }

        // Returnerer alle entries fra loggtabellen basert på kortleser_id
        public DataTable VisLoggVedKortleser(string kortleser_id)
        {
            dtgetData = getData($"select * from logg where kortleser_id = '{kortleser_id}'");
            DataTable dt = Database.DtgetData;

            return dt;
        }
    }
}
