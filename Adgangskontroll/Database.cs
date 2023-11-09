using System;
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
        static string kobling = "server=129.151.221.119 ; port=5432 ; user id=596237 ; password=Ha1FinDagIDag! ; database=596237 ;";

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
        public string Innlogging(string id, string pin)
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
        public DataTable VisAnsatt()
        {
            dtgetData = getData("select * from ansatt0;");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        public DataTable VisBrukere()
        {
            dtgetData = getData("select * from Brukere;");
            DataTable dt = Database.DtgetData;

            return dt;
        }
        public DataTable LeggTilNyBruker(string id, string pin)
        {
            dtgetData = getData($"INSERT INTO Brukere values('{id}', '{pin}');");
            DataTable dt = dtgetData;

            return dt;
        }
    }
}
