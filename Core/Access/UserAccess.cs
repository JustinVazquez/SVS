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
        /// <summary>
        /// Liefert den Hash eines Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="userID">UserID</param>
        /// <returns>String</returns>
        public static string GetHash(IDbConnection con,int userID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT HASH FROM sql7280199.USER WHERE ID = '{userID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        /// <summary>
        /// Liefert den Salt eines Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="userID">UserID</param>
        /// <returns>String</returns>
        public static string GetSalt(IDbConnection con,int userID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT SALT FROM sql7280199.SALT WHERE USER_ID = '{userID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }     

        /// <summary>
        /// Liefert den Namen eines Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="user">User</param>
        /// <returns>String</returns>
        public static string GetName(IDbConnection con, string user)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT NAME FROM SVS.USER WHERE NAME = '{user}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        /// <summary>
        /// Fügt Salt zum User hinzu
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="UserId">UserID</param>
        /// <param name="salt">Salt</param>
        public static void AddSalt(IDbConnection con,int UserId,string salt)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"INSERT INTO sql7280199.SALT (USER_ID,Salt) VALUES ({UserId},'{salt}')";
            con.Execute(sql);
        }

        /// <summary>
        /// Liefert die ID über den Namen eines Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="user">User</param>
        /// <returns>int</returns>
        public static int GetIdByName(IDbConnection con, string user)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT ID FROM sql7280199.User WHERE name = '{user}'";
            var result = con.ExecuteScalar<int>(sql);
            return result;
          
        }

        /// <summary>
        /// Liefert den Namen eines User über die ID
        /// </summary>
        /// <param name="con"></param>
        /// <param name="ID"></param>
        /// <returns>String</returns>
        public static string GetNameByID(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT Name FROM SVS.User WHERE ID = '{ID}'";
            var result = con.ExecuteScalar<string>(sql);
            return result;

        }

        /// <summary>
        /// Ändert den Salt des Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="name">Name</param>
        /// <param name="salt">Salt</param>
        public static void ChangeSalt(IDbConnection con, string name,string salt)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"UPDATE sql7280199.SALT SET salt = '{salt}' where User_ID = {UserAccess.GetIdByName(con, name)}";
            con.Execute(sql);
        }

        /// <summary>
        /// Ändert den Hash eines Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="name">Name</param>
        /// <param name="newPassword">NewPassword</param>
        public static void ChangeHash(IDbConnection con,string name, string newPassword)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"UPDATE sql7280199.USER SET hash = '{newPassword}' where ID = {UserAccess.GetIdByName(con, name)}";
            con.Execute(sql);
        }

        /// <summary>
        /// Fügt einen User hinzu
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="name">Name</param>
        /// <param name="password">Password</param>
        public static void AddUser(IDbConnection con,string name,string password/*,string email,bool autoversand*/)
        {           
            DbHelper.CheckDbConnection(con);
            var sql =  $"INSERT INTO sql7280199.USER (Name,Hash) VALUES ('{name}','{password}')";          
            con.Execute(sql);                   
        }

        /// <summary>
        /// Liefert einen User über Name und Hash
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        /// <returns>Ein Objekt vom Typ UserModel</returns>
        public static UserModel GetUser(IDbConnection con,string user, string password)
        {      
                DbHelper.CheckDbConnection(con);
                var sql = $"SELECT * FROM sql7280199.USER WHERE name = '{user}' and hash = '{password}'";
                var result = con.QueryFirst<UserModel>(sql);
                return result;           
        }     
        
        /// <summary>
        /// Ändert die Email eines Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="name">Name</param>
        /// <param name="mail">Mail</param>
        public static void ChangeEmail(IDbConnection con, string name,string mail)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"UPDATE sql7280199.USER SET email = '{mail}' where ID = {UserAccess.GetIdByName(con,name)}";
            con.Execute(sql);
         
        }

        /// <summary>
        /// Liefert die Email eines Users
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="klasse">Klasse</param>
        /// <returns>Eine Liste aus Elementen vom Typ string</returns>
        public static List<string> getEmails(IDbConnection con, int klasse)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"SELECT email FROM sql7280199.USER WHERE klasse = {klasse}";
            var result = con.Query<string>(sql).AsList();
            return result;
        }
    }
}
