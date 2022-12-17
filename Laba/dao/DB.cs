using MySql.Data.MySqlClient;
using System;


namespace Laba.dao
{
    internal class DB
    {

        private static MySqlConnection conn;
        private static string server;
        private static string user;
        private static string pass;
        private static string db;

        public static MySqlConnection OpenConnection()
        {
            try
            {
              
                server = "localhost";
                db = "storage";
                user = "root";
                pass = "TypicalDatabasePassword";
                conn = new MySqlConnection("Data Source=" + server + ";Database=" + db + ";User Id=" + user + ";Password=" + pass + ";SSL Mode=0");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return conn;
        }
        public void CloseConnection()
        {
            conn.Close();
        }
     
    }
}

