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
        public static void AddNotiz(IDbConnection con,int UserID,string Text, int Stunde, DateTime Datum)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Insert into SVS.stundennotiz (User_ID,Text,Stunde,Datum) Values ({UserID},'{Text}'{Stunde},'{Datum}'";
            con.Execute(sql);
        }

        public static NotizModel GetNotizByDateAndStunde(IDbConnection con, string Datum, int Stunde)
        {
            DbHelper.CheckDbConnection(con);
            var sql = $"Select * From SVS.stundennotiz Where Datum = '{Datum}' And Stunde = {Stunde}";
            var result = con.QueryFirstOrDefault<NotizModel>(sql);
            return result;
        }
    }
}
