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
        /// <summary>
        /// Liefert eine Liste mit allen Lehrern
        /// </summary>
        /// <returns>Eine Liste aus Elementen vom Typ LehrerModel</returns>
        public static List<LehrerModel> GetAllLehrer()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From SVS.Lehrer";
            var result = con.Query<LehrerModel>(sql).AsList();
            return result;
        }
    }
}
