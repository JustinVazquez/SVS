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

        public User Login(string name,string password)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
              
            if (string.IsNullOrWhiteSpace(UserAccess.GetName(con,name)))
            {
                var userID = UserAccess.GetIdByName(con,name);
                var hash = UserAccess.GetHash(con, userID);
                var salt = UserAccess.GetSalt(con, userID);

                try
                {
                    if (SaltHashHelper.ValidatePassword(password, hash, salt))
                    {
                        return UserAccess.GetUser(con, name, hash);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch(Exception error)
                {
                    Console.Write(error);
                }
                finally
                {
                    con.Close();
                }

              
            }
            

            return null;

        }

        public void Anlegen(string name,string password)
        {

        }
    }
}
