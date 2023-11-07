using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Sentral
{
    internal class Database
    {
        private static DataTable dtgetData = new DataTable();
        private static NpgsqlConnection vCon;// = new NpgsqlConnection();
        private static NpgsqlCommand vCmd;// = new NpgsqlCommand();
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
            //vCon.ConnectionString = vstrConnection;
            try
            {
                if (vCon.State == ConnectionState.Closed)
                {
                    vCon.Open();
                }//vCon.Open();
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
        public NpgsqlConnection Con()
        {
            return vCon;
        }
        public NpgsqlCommand Cmd()
        {
            return vCmd;
        }
    }
}
