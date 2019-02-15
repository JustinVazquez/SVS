using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;


namespace Core.Helper
{
    public static class DbHelper
    {
        private static readonly string _host = "192.168.10.7";
        private static readonly string _dataSource = "127.0.0.1";
        private static readonly string _userName = "root";
        private static readonly string _password = "";
  

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
                $"Server={_host}; DataSource={_dataSource}; UserId={_userName}; Password={_password};";
            MySqlConnection connection = new MySqlConnection(conString);
            var con = connection;
            return con;
        }



    }
}
