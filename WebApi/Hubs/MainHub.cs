using Core.Access;
using Core.Helper;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Hubs
{
    public class MainHub : Hub
    {

        public bool Test()
        {
            return true;
        }

        #region Login und Userverwaltung

        public User Login(string name, string password)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();

            if (string.IsNullOrWhiteSpace(UserAccess.GetName(con, name)))
            {
                var userID = UserAccess.GetIdByName(con, name);
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
                catch (Exception error)
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

        public HttpStatusCode Anlegen(string name, string password)
        {

            var con = DbHelper.GetDbConnection();
            con.Open();

            if (string.IsNullOrWhiteSpace(UserAccess.GetName(con, name)))
            {
                var HashnSalt = SaltHashHelper.CreateHash(password);
                UserAccess.AddUser(con, name, HashnSalt.Item1);
                UserAccess.AddSalt(con, UserAccess.GetIdByName(con, name), HashnSalt.Item2);
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode UpdateMail(string name, string mail)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            try
            {
                UserAccess.ChangeEmail(con, name, mail);
                return HttpStatusCode.OK;
            }
            catch (Exception error)
            {
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                con.Close();
            }
        }


        public HttpStatusCode ChangePassword(string name, string password, string newPassword)
        {
            var User = Login(name, password);
            if (User != null)
            {
                var con = DbHelper.GetDbConnection();
                con.Open();
                var HashnSalt = SaltHashHelper.CreateHash(newPassword);
                UserAccess.ChangeHash(con, name, HashnSalt.Item1);
                UserAccess.ChangeSalt(con, name, HashnSalt.Item2);
                con.Close();
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }


        }
        #endregion

        #region Stundenplanverwaltung

        public List<StundenplanModel> GetStundenplan(string Klasse,DateTime date)
        {


            return null;
        }

        #endregion



    }
}
