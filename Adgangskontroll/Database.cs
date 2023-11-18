﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Sentral
{
    internal class Database
    {
        private static DataTable dtgetData = new DataTable();
        private static NpgsqlConnection vCon;
        private static NpgsqlCommand vCmd;

        // legg inn din informasjon her for kobling mot din database
        static string kobling = "server=129.151.221.119 ; port=5432 ; user id=595672 ; password=Ha1FinDagIDag! ; database=595672 ;";


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
        public Database()
        {
            //
        }
        public NpgsqlConnection Connection()
        {
            vCon = new NpgsqlConnection(kobling);
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
        public string Innlogging(string id, string pin) //login er dette samme som validate for åpning av dør? + sjekk om id og pin skal være string?
        {
            string suksess;
            string query = ($"select * from Brukere where Kort_ID ='{id}' and Pin = '{pin}';");
            VCmd = new NpgsqlCommand(query, VCon);

            using NpgsqlDataReader reader = VCmd.ExecuteReader();
            if (reader.Read())
            {
                suksess = "korrekt";
            }
            else
            {
                suksess = "feil";
            }
            return suksess;
        }
        //NBNB gå over alt dette felles


        //legger en ny rad inn i bruker databasen 
        public DataTable LeggTilNyBruker(int kort_id, string fornavn, string etternavn, DateTime start, DateTime slutt, int pin, int tilgang_id)
        {
            string email = $"{fornavn}.{etternavn}@bedrift.no";
            dtgetData = getData($"insert into bruker values ({kort_id}, {fornavn}, {etternavn}, {email}, {start}, {slutt}, {pin}, {tilgang_id});");
            DataTable dt = dtgetData;

            return dt;
        }
        //skriv inn alle verdiene til en rad i bruker databasen pånytt, ved å identifisere raden med kort_id
        public DataTable EndreBruker(int kort_id, string fornavn, string etternavn, DateTime start, DateTime slutt, int pin, int tilgang_id)
        {
            string email = $"{fornavn}.{etternavn}@bedrift.no";
            dtgetData = getData($"update bruker set fornavn = {fornavn}, etternavn = {etternavn}, email = {email}, gyldighet_start = {start}, gyldighet_slutt = {slutt},pin = {pin}, tilgang_id = {tilgang_id} where kort_id = {kort_id}");
            DataTable dt = dtgetData;

            return dt;
        }
        //slett en rad fra bruker databasen, ved å identifisere raden med kort_id
        public DataTable SlettBruker(int kort_id)
        {
            dtgetData = getData($"delete from bruker where kort_id = {kort_id}");
            DataTable dt = dtgetData;

            return dt;
        }


        //legger en ny rad inn i kortleser databasen 
        public DataTable LeggTilNyKortleser(int kortleser_id, int seksjon_id, string plass)
        {
            dtgetData = getData($"insert into kortleser values ({kortleser_id}, {seksjon_id}, {plass});");
            DataTable dt = dtgetData;

            return dt;
        }
        //skriv inn alle verdiene til en rad i kortleser databasen på nytt, ved å identifisere raden med kort_id
        public DataTable EndreKortleser(int kortleser_id, int seksjon_id, string plass)
        {
            dtgetData = getData($"update kortleser set seksjon_id = {seksjon_id}, plass = {plass} where kortleser_id = {kortleser_id}");
            DataTable dt = dtgetData;

            return dt;
        }
        //slett en rad fra kortleser databasen, ved å identifisere raden med kort_id
        public DataTable SlettKortleser(int kortleser_id)
        {
            dtgetData = getData($"delete from kortleser where kortleser_id = {kortleser_id}");
            DataTable dt = dtgetData;

            return dt;
        }


        //danner og legger inn en rad i log databasen
        public DataTable LeggTilLog(int log_type, DateTime log_tid, int kortleser_id, int kort_id)
        {
            dtgetData = getData($"insert into log values ({log_type}, {log_tid}, {kortleser_id}, {kort_id});");
            DataTable dt = dtgetData;

            return dt;
        }
        //henter ut nyligste rad fra log databasen for en viss kortleser_id, brukes for å hente sist kort_id registrert på en kortleser (brukes ved enkelte loger)
        //for mer informasjon om log_type se adgangskontroller-DB-notasjon.txt
        public DataTable VisSisteLog(int log_type, DateTime log_tid, int kortleser_id, int kort_id)
        {
            dtgetData = getData($"SELECt * FROM log where kortleser_id = {kortleser_id} ORDER BY log_tid DESC limit 1");
            DataTable dt = dtgetData;

            return dt;
        }


        //validerings prossesen, den tar in kort_id, pin og kortleser_id. sjekker om pin matcher kort_id, om kort_id er innenfor gyldighetsperioden og om kort_id har tilgang til kortleser_id
        //om prossesen feiler returnerer den blankt, om den er er ok returnerer den en rad med bruker og kortleser (den informasjonen som ble sendt inn) spleiset sammen
        public DataTable Validate(int kort_id, int pin, int kortleser_id)
        {
            dtgetData = getData($"select * from tilgangrelasjon join bruker on tilgangrelasjon.tilgang_id = bruker.tilgang_id join kortleser on tilgangrelasjon.seksjon_id = kortleser.seksjon_id where kort_id = {kort_id} and pin = {pin} and kortleser_id = {kortleser_id} and CURRENT_DATE between gyldighet_start and gyldighet_slutt");
            DataTable dt = dtgetData;

            return dt;
        }


        //gir en tabell med alle rader i kortleser databasen
        public DataTable VisKortleser()
        {
            dtgetData = getData("select * from kortleser");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //gir en tabell med alle rader i bruker databasen
        public DataTable VisBrukere()
        {
            dtgetData = getData("select * from bruker");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste adgangslogg (inkludert forsøk på adgang) på grunnlag av kort_id mellom to datoer
        public DataTable VisAdganglogForBrukerVedDato(int kort_id, DateTime start, DateTime slutt)
        {
            dtgetData = getData($"select * from log where kort_id = {kort_id} and (log_type = 0 or log_type = 1 or log_type = 2) and log_tid between {start} and {slutt}");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste alle innpasseringsforsøk for en dør med ikke-godkjent adgang (uansett bruker) mellom to datoer
        public DataTable VisNegativAdganglogKortleserVedDato(int kortleser_id, DateTime start, DateTime slutt)
        {
            dtgetData = getData($"select * from log where kortleser_id = {kortleser_id} and log_type = 1 and log_tid between {start} and {slutt}");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste av alarmer
        public DataTable VisAlarm()
        {
            dtgetData = getData($"select * from log where (log_type = 3 or log_type = 2)");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste av alarmer ved kort_id
        public DataTable VisAlarmVedBruker(int kort_id)
        {
            dtgetData = getData($"select * from log where (log_type = 3 or log_type = 2) and kort_id = {kort_id}");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste av alarmer ved kortleser_id
        public DataTable VisAlarmVedKortleser(int kortleser_id)
        {
            dtgetData = getData($"select * from log where (log_type = 3 or log_type = 2) and kortleser_id = {kortleser_id}");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste av alarmer mellom to datoer
        public DataTable VisAlarmVedDato(DateTime start, DateTime slutt)
        {
            dtgetData = getData($"select * from log where (log_type = 3 or log_type = 2) and log_tid between {start} and {slutt}");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste alle entries log 
        public DataTable VisLog()
        {
            dtgetData = getData($"select * from log");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste alle entries log basert på kort_id
        public DataTable VisLogVedBruker(int kort_id)
        {
            dtgetData = getData($"select * from log where kort_id = {kort_id}");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //liste alle entries log basert på kortleser_id
        public DataTable VisLogVedKortleser(int kortleser_id)
        {
            dtgetData = getData($"select * from log where kortleser_id = {kortleser_id}");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        //string log1 = "Alle Kortlesere";
        //string log2 = "Alle Brukere";
        //string log3 = "Alle adgangs hendelser for Bruker i en periode";
        //string log4 = "Alle ikke godkjente adgangs forsøk for en Kortleser i en periode";
        //string log5 = "Alle Alarm hendelser";
        //string log6 = "Alle Alarm hendelser knyttet til Bruker";
        //string log7 = "Alle Alarm hendelser for en Kortleser";
        //string log8 = "Alle Alarm hendelser i en periode";
        //string log9 = "Alle Log hendelser";
        //string log10 = "Alle Log hendelser kyttet til en Bruker";
        //string log11 = "Alle Log hendelser for en Kortleser";
        ////switch case for hvordan bestemme hva som skjer med log velger meny
        //switch(LogVelger.Text)
        //    {
        //    case log1:
        //        Database.VisKortleser();//ingen ekstra informasjon trengs å leses fra text box
        //        break;
        //    case log2:
        //         Database.VisBrukere(); 
        //        break;            
        //     case log3:
        //        Database.VisAdganglogForBrukerVedDato(int kort_id, DateTime start, DateTime slutt); //trenger kort id, date start og slutt
        //        break;
        //     case log4:
        //        Database.VisNegativAdganglogKortleserVedDato(int kortleser_id, DateTime start, DateTime slutt);
        //        break;
        //     case log5:
        //        Database.VisAlarm();
        //        break;
        //     case log6:
        //        Database.VisAlarmVedBruker(int kort_id);
        //        break;
        //     case log7:
        //        Database.VisAlarmVedKortleser(int kortleser_id);
        //        break;
        //     case log8:
        //        Database.VisAlarmVedDato(DateTime start, DateTime slutt);
        //     case log9:
        //        Database.VisLog();
        //     case log10:
        //        Database.VisLogVedBruker(int kort_id);
        //        break;
        //     case log11:
        //        Database.VisLogVedKortleser(int kortleser_id);
        //        break;
        //    }
    }
}
