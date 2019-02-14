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
        public static List<StundenplanModel> GetAllStundenplaene(IDbConnection con)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.Stundenplan Order By Datum,Stunde";
            var result = con.Query<StundenplanModel>(sql).AsList();
            return result;
        }

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

        public static string GetKlasseText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Klasse Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        public static string GetFachText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Fach Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;
        }

        public static string GetLehrerText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Lehrer Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;

        }

        public static string GetRaumText(IDbConnection con, int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select Name From SVS.Raum Where ID = {ID}";
            var result = con.ExecuteScalar<string>(sql);
            return result;

        }

        public static NotizModel GetNotiz(IDbConnection con,int ID)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.Notiz Where ID = {ID}";
            var result = con.QueryFirstOrDefault<NotizModel>(sql);
            return result;
        }

        public static NotizModel GetNotizByDateAndStunde(IDbConnection con,string Datum,int Stunde)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.Notiz Where Datum = '{Datum}' And Stunde = {Stunde}";
            var result = con.QueryFirstOrDefault<NotizModel>(sql);
            return result;           
        }


    }
}
