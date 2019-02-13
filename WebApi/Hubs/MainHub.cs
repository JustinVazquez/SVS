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
            User test = new User();
            test.ID = 1;
            test.Name = "Test";
            test.Email = "Test.Test@Test.de";

            var con = DbHelper.GetDbConnection();
            con.Open();
            if (UserAccess.GetName(con, user) == user)
            {
                var userID = UserAccess.GetIdByName(con, user);
                var salt = UserAccess.GetSalt(con, userID);
                var hash = UserAccess.GetHash(con, userID);
                con.Close();

                Debug.Write(SaltHashHelper.ValidatePassword(password, hash, salt));

            }
            else
            {
                con.Close();
                Debug.Write(false);

            }

            return test;
        }

        public void Anlegen(string name,string password)
        {

        }
    }
}
