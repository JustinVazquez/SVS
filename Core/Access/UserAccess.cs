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
            var sql = $"SELECT HASH FROM SVS.USER WHERE ID = '{userID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        public static string GetSalt(IDbConnection con,int userID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT SALT FROM SVS.SALT WHERE USER_ID = '{userID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }     

        public static string GetName(IDbConnection con, string user)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT NAME FROM SVS.USER WHERE NAME = '{user}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        public static void AddSalt(IDbConnection con,int UserId,string salt)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"INSERT INTO SVS.SALT (USER_ID,Salt) VALUES ({UserId},'{salt}')";
            con.Execute(sql);
        }

        public static int GetIdByName(IDbConnection con, string user)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT ID FROM SVS.User WHERE name = '{user}'";
            var result = con.ExecuteScalar<int>(sql);
            return result;
          
        }

        public static string GetNameByID(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT Name FROM SVS.User WHERE ID = '{ID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;

        }

        public static void ChangeSalt(IDbConnection con, string name,string salt)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"UPDATE SVS.SALT SET salt = '{salt}' where User_ID = {UserAccess.GetIdByName(con, name)}";
            con.Execute(sql);
        }

        public static void ChangeHash(IDbConnection con,string name, string newPassword)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"UPDATE SVS.USER SET hash = '{newPassword}' where ID = {UserAccess.GetIdByName(con, name)}";
            con.Execute(sql);
        }

        public static void AddUser(IDbConnection con,string name,string password/*,string email,bool autoversand*/)
        {           
            DbHelper.CheckDbConnection(con);
            var sql =  $"INSERT INTO SVS.USER (Name,Hash) VALUES ('{name}','{password}')";          
            con.Execute(sql);                   
        }

        public static UserModel GetUser(IDbConnection con,string user, string password)
        {      
                DbHelper.CheckDbConnection(con);
                var sql = $"SELECT * FROM SVS.USER WHERE name = '{user}' and hash = '{password}'";
                var result = con.QueryFirst<UserModel>(sql);
                return result;           
        }     
        
        public static void ChangeEmail(IDbConnection con, string name,string mail)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"UPDATE SVS.USER SET email = '{mail}' where ID = {UserAccess.GetIdByName(con,name)}";
            con.Execute(sql);
         
        }
    }
}
