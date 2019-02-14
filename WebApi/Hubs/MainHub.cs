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

        /// <summary>
        /// Methode um einen User für den Login zu Validieren
        /// </summary>
        /// <param name="name">User Name</param>
        /// <param name="password">User Password</param>
        /// <returns>Ein Objekt vom Typ User</returns>
        public UserModel Login(string name, string password)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();

            //Wenn der User existiert dann weiter.
            if (string.IsNullOrWhiteSpace(UserAccess.GetName(con, name)))
            {
                //Hash und Salt aus der Datenbank anhand der UserID die durch den Username ermittelt wird
                var userID = UserAccess.GetIdByName(con, name);
                var hash = UserAccess.GetHash(con, userID);
                var salt = UserAccess.GetSalt(con, userID);

                try
                {
                    //Validiert den Hash aus der Datenbank mit dem Passwort aus der Login-Form 
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

        /// <summary>
        /// Legt einen neuen User in der Datenbank an
        /// </summary>
        /// <param name="name">User Name</param>
        /// <param name="password">User Password</param>
        /// <returns>Einen HttpStatusCode OK bei Erfolg InternalServerError bei Fehlschlag</returns>
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

        /// <summary>
        /// Updated die Email eines Users anhand des Usernamen
        /// </summary>
        /// <param name="name">User Name</param>
        /// <param name="mail">User Email</param>
        /// <returns>Einen HttpStatusCode OK bei Erfolg InternalServerError bei Fehlschlag</returns>
        public HttpStatusCode UpdateMail(string name, string mail)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            try
            {
                //Anhand des Usernamen wird die ID des Users ermittelt und die Email an stelle der ID geändert.
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


        /// <summary>
        /// Ändert das Passwort eines Users
        /// </summary>
        /// <param name="name">User Name</param>
        /// <param name="password">Aktuelles User Password</param>
        /// <param name="newPassword">Neues User Password</param>
        /// <returns>Einen HttpStatusCode OK bei Erfolg InternalServerError bei Fehlschlag</returns>
        public HttpStatusCode ChangePassword(string name, string password, string newPassword)
        {
            //Validierung des Users
            var User = Login(name, password);
            if (User != null)
            {
                var con = DbHelper.GetDbConnection();
                con.Open();
                //Erstellt einen neuen Hash und Updated diesen und den Salt des Users
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

        //TODO: Kommentar Anpassen

        /// <summary>
        /// Liefert eine Liste mit Inhalt des Stundenplans für die Klasse an einem bestimmten Datum
        /// </summary>
        /// <param name="Klasse">Klasse</param>
        /// <param name="date">Datum</param>
        /// <returns>Eine Liste aus Elementen vom Typ StundenplanModel</returns>
        public WocheModel GetStundenplan(int klasse, DateTime today)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            // If we started on Sunday, we should actually have gone *back*
            // 6 days instead of forward 1...
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();
            var woche = new WocheModel();

            for (int i = 0; i <= 4; i++)
            {
                if (i == 0)
                    woche.Montag = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 1)
                    woche.Dienstag = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 2)
                    woche.Mittwoch = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 3)
                    woche.Donnerstag = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 4)
                    woche.Freitag = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
            }
            return woche;
        }
       

        public WochenNotizModel GetWochenNotiz(int Stundenplan_ID)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            var result = NotizAccess.GetWochenNotizByID(con, Stundenplan_ID);
            con.Close();
            return result;
        }

        #endregion



    }
}
