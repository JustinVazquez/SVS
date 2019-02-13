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
            if (UserAccess.GetName(con, user) == user)
            {
                var userID = UserAccess.GetIdByName(con, user);
                var salt = UserAccess.GetSalt(con, userID);
                var hash = UserAccess.GetHash(con, userID);
                con.Close();

                if(SaltHashHelper.ValidatePassword(password, hash, salt))
                {
                    return UserAccess.GetUser(con, user, hash);
                }

            }
            else
            {
                con.Close();
                Debug.Write(false);

            }

            return null;
        }

        public void Anlegen(string name,string password)
        {

        }
    }
}
