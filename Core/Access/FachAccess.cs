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
        /// <summary>
        /// Liefert eine Liste mit allen Fächern
        /// </summary>
        /// <returns>Eine Liste mit Elementen vom Typ FachModel</returns>
        public static List<FachModel> GetAllFach()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From sql7280199.Fach";
            var result = con.Query<FachModel>(sql).AsList();
            return result;
        }
    }
}
