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
        /// <summary>
        /// Liefert eine Liste mit allen Räumen
        /// </summary>
        /// <returns>Eine Liste aus Elementen vom Typ RaumModel</returns>
        public static List<RaumModel> GetAllRaum()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From sql7280199.Raum";
            var result = con.Query<RaumModel>(sql).AsList();
            return result;
        }
    }
}
