using Core.Helper;
using Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.Access
{
    public class UserAccess
    {
        public static string GetHash(IDbConnection con,int userID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT HASH FROM VAZQUEZ.PROJEKTTAGE_USER WHERE ID = '{userID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        public static string GetSalt(IDbConnection con,int userID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT SALT FROM VAZQUEZ.PROJEKTTAGE_SALT WHERE USER_ID = '{userID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }     

        public static string GetName(IDbConnection con, string user)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT NAME FROM VAZQUEZ.PROJEKTTAGE_USER WHERE NAME = '{user}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        public static void AddSalt(IDbConnection con,int UserId,string salt)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"INSERT INTO VAZQUEZ.PROJEKTTAGE_SALT (USER_ID,Salt) VALUES ({UserId},'{salt}')";
            con.Execute(sql);
        }

        public static int GetIdByName(IDbConnection con, string user)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT ID FROM Vazquez.Projekttage_User WHERE name = '{user}'";
            var result = con.ExecuteScalar<int>(sql);
            return result;
          
        }

        public static void ChangePassword(IDbConnection con,string password,string newPassword)
        {

        }

        public static void AddUser(IDbConnection con,string name,string password/*,string email,bool autoversand*/)
        {           
            DbHelper.CheckDbConnection(con);
            var sql =  $"INSERT INTO SVS.PROJEKTTAGE_USER (Name,Hash) VALUES ('{name}','{password}')";          
            con.Execute(sql);                   
        }

        public static User GetUser(IDbConnection con,string user, string password)
        {      
                DbHelper.CheckDbConnection(con);
                var sql = $"SELECT * FROM USER WHERE name = '{user}' and hash = '{password}'";
                var result = con.QueryFirst<User>(sql);
                return result;           
        }       
    }
}
