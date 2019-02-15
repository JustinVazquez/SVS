using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Core.Helper;
using Dapper;
using Core.Models;

namespace Core.Access
{
    public static class StundeplanAccess
    {
        /// <summary>
        /// Liefert alle Stunden einer Woche
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <returns>Eine Liste aus Elementen vom Typ StundenplanModel</returns>
        public static List<StundenplanModel> GetAllStundenplaene(IDbConnection con)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.Stundenplan Order By Datum,Stunde";
            var result = con.Query<StundenplanModel>(sql).AsList();
            return result;
        }

        /// <summary>
        /// Liefert alle Stunden einer Klasse für eine Woche
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="klasse">Klasse</param>
        /// <param name="datum">Datum</param>
        /// <returns>Eine Liste aus Elementen vom Typ StundenplanModel</returns>
        public static List<StundenplanModel> GetStundenplanByKlassAndDate(IDbConnection con,int klasse,string datum)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.Stundenplan Where Klasse_ID = {klasse} and Datum = '{datum}'";
            var result = con.Query<StundenplanModel>(sql).AsList();
            return result;
        }

        public static void AddStundenplan()
        {

        }

        public static void EditStundenplan()
        {

        }

        public static void DeleteStundenplan()
        {

        }

        /// <summary>
        /// Liefert den Namen einer Klasse
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="ID">ID der Klasse</param>
        /// <returns>String</returns>
        public static string GetKlasseText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Klasse Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        /// <summary>
        /// Liefert den Namen eines Fachs
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="ID">ID des Fachs</param>
        /// <returns>String</returns>
        public static string GetFachText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Fach Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        /// <summary>
        /// Liefert den Namen eines Lehrers
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="ID">ID des Lehrers</param>
        /// <returns>String</returns>
        public static string GetLehrerText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Lehrer Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;

        }

        /// <summary>
        /// Liefert den Namen eines Status
        /// </summary>
        /// <param name="con"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string GetStatusText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Status Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        /// <summary>
        /// Liefert den Namen eines Raums
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="ID">ID des Raums</param>
        /// <returns>String</returns>
        public static string GetRaumText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Raum Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;

        }

        /// <summary>
        /// Liefert die Notiz einer ID
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="ID">ID der Notiz</param>
        /// <returns>Ein Objekt vom Typ NotizModel</returns>
        public static NotizModel GetNotiz(IDbConnection con,int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.Notiz Where ID = {ID}";
            var result = con.QueryFirstOrDefault<NotizModel>(sql);
            return result;
        }

        /// <summary>
        /// Liefert Notiz anhand des Datums und der Stunde
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="Datum">Datum</param>
        /// <param name="Stunde">Stunde</param>
        /// <returns>Ein Objekt vom Typ NotizModel</returns>
        public static NotizModel GetNotizByDateAndStunde(IDbConnection con,string Datum,int Stunde)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.Notiz Where Datum = '{Datum}' And Stunde = {Stunde}";
            var result = con.QueryFirstOrDefault<NotizModel>(sql);
            return result;           
        }

        /// <summary>
        /// Ändert den Status
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="ID">Status ID</param>
        /// <param name="Status_ID">Status_ID</param>
        public static void ChangeStatus(IDbConnection con, int ID, int Status_ID)
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Update SVS.Stundenplan Set Status_ID = {Status_ID} Where ID = {ID} ";
            con.Execute(sql);


        }


    }
}
