using Core.Helper;
using Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Access
{
    public static class RaumAccess
    {
        public static List<RaumModel> GetAllFach()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From SVS.Raum";
            var result = con.Query<RaumModel>(sql).AsList();
            return result;
        }
    }
}
