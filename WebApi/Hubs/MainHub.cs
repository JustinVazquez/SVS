using Core.Access;
using Core.Helper;
using Core.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public class MainHub : Hub
    {

        public bool Test()
        {
            return true;
        }

        public User Login(string user,string password)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            var test = UserAccess.GetUser(con, user, password);
            con.Close();

            return test;

        }

        public void Anlegen(string name,string password)
        {

        }
    }
}
