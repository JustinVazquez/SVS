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
        /// <summary>
        ///  Liefert den Status einer einzelnen Stunden
        /// </summary>
        /// <returns>Eine Liste aus Elementen vom Typ StatusModel</returns>
        public static List<StatusModel> GetAllStatus()
        {
            var con = DbHelper.GetDbConnection();
            var sql = $"Select * From SVS.Status";
            var result = con.Query<StatusModel>(sql).AsList();
            return result;
        }


      
    }
}
