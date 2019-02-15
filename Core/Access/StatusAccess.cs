using Core.Helper;
using Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Access
{
    public static class StatusAccess
    {
        public static List<StatusModel> GetAllFach()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From SVS.Status";
            var result = con.Query<StatusModel>(sql).AsList();
            return result;
        }


      
    }
}
