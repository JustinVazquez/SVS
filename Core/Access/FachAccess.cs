using Core.Helper;
using Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Access
{
    public static class FachAccess
    {
        public static List<FachModel> GetAllFach()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From SVS.Fach";
            var result = con.Query<FachModel>(sql).AsList();
            return result;
        }
    }
}
