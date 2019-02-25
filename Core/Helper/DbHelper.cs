using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;


namespace Core.Helper
{
    public static class DbHelper
    {
        private static readonly string _dataSource = "sql7.freemysqlhosting.net";
        private static readonly string _port = "3306";
        private static readonly string _userName = "sql7280199";
        private static readonly string _password = "BmyHbWTuEX";
  

        public static void CheckDbConnection(IDbConnection con)
        {
            if (con == null)
                throw new ArgumentNullException("connection is null");
        }

        /// <summary>
        /// Liefert eine gültige IDbConnection zurück. 
        /// </summary>
        /// <returns>Dbconnection die das Interface IDbConnection aufweist.</returns>
        public static IDbConnection GetDbConnection()
        {
            var conString =
                $"Server={_dataSource}; Port={_port}; UserId={_userName}; Password={_password};";
            MySqlConnection connection = new MySqlConnection(conString);
            var con = connection;
            return con;
        }



    }
}
