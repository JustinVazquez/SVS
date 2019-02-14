using Core.Helper;
using Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Core.Access
{
    public static class NotizAccess
    {
        /// <summary>
        /// Fügt der Datenbank eine Notiz hinzu.
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="UserID">User_ID</param>
        /// <param name="Text">Inhalt der Notiz</param>
        /// <param name="Stunde">Stunde</param>
        /// <param name="Datum">Datum der Notiz</param>
        public static void AddNotiz(IDbConnection con,int UserID,string Text, int Stunde, DateTime Datum)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Insert into SVS.stundennotiz (User_ID,Text,Stunde,Datum) Values ({UserID},'{Text}'{Stunde},'{Datum}'";
            con.Execute(sql);
        }

        /// <summary>
        /// Liefert eine Notiz anhand des Datums und der Stunde
        /// </summary>
        /// <param name="con">Datenbankverbindung</param>
        /// <param name="Datum">Datum</param>
        /// <param name="Stunde">Stunde</param>
        /// <returns>Ein Objekt vom Typ NotizModel</returns>
        public static NotizModel GetNotizByDateAndStunde(IDbConnection con, string Datum, int Stunde)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.stundennotiz Where Datum = '{Datum}' And Stunde = {Stunde}";
            var result = con.QueryFirstOrDefault<NotizModel>(sql);
            return result;
        }
    }
}
