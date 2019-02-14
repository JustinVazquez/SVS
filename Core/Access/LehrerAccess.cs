using Core.Helper;
using Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Access
{
    public static class LehrerAccess
    {
        public static List<LehrerModel> GetAllFach()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From SVS.Lehrer";
            var result = con.Query<LehrerModel>(sql).AsList();
            return result;
        }
    }
}
