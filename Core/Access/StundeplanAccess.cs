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
            var sql = $"Select * From Stundenplan Order By Datum,Stunde";
            var result = con.Query<StundenplanModel>(sql).AsList();
            return result;
        }

        public static StundenplanModel GetStundenplanByKlassAndDate(IDbConnection con,string klasse,DateTime datum)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From Stundenplan Where Klasse = {klasse} and Datum = {datum}";
            var result = con.QueryFirstOrDefault<StundenplanModel>(sql);
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


    }
}
