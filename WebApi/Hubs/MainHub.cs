using Core.Access;
using Core.Helper;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using SVS;
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
         
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();
            var woche = new WocheModel();

            for (int i = 0; i <= 4; i++)
            {
                if (i == 0)
                    woche.monday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 1)
                    woche.tuesday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 2)
                    woche.wednesday= StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 3)
                    woche.thursday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                if (i == 4)
                    woche.friday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
            }

            woche.weekNotes = NotizAccess.GetWochenNotizenByID(con, dates[0].ToString("yyyy-MM-dd"), dates[4].ToString("yyyy-MM-dd"));
            return woche;
        }      
        #endregion

        public bool addWeekNote(int klasse,string text)
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            try { NotizAccess.AddWochenNotiz(con, klasse, text, DateTime.Now.ToString("yyyy-MM-dd")); return true; }
            catch { return false; }
            finally { con.Close(); }
          
            
        }

        public bool SendMail(int klasse,string text) {

            var con = DbHelper.GetDbConnection();
            con.Open();
            var list = UserAccess.getEmails(con, klasse);
            try
            {
               Email.sendMail(list, text);
                return true;
            }
            catch
            {
                return false;
            }
                
            
        }

        public WocheModel TestWoche()
        {
            var woche = new WocheModel();
            var montag = new List<StundenplanModel>();
            var dienstag = new List<StundenplanModel>();
            var stunde = new StundenplanModel();

            stunde.ID = 1;
            stunde.Klasse_ID = 1;
            stunde.Klasse = "ITM-3";
            stunde.Lehrer_ID = 1;
            stunde.Lehrer = "Max Musterman";
            stunde.Raum_ID = 1;
            stunde.Raum = "Test Raum";
            stunde.Fach_ID = 1;
            stunde.Stunde = 1;
            montag.Add(stunde);
            stunde.Stunde = 2;
            montag.Add(stunde);
            stunde.Stunde = 3;
            montag.Add(stunde);
            stunde.Stunde = 4;
            montag.Add(stunde);
            stunde.Stunde = 5;
            montag.Add(stunde);
            stunde.Stunde = 6;
            montag.Add(stunde);
            stunde.Stunde = 7;
            montag.Add(stunde);
            stunde.Stunde = 8;
            montag.Add(stunde);

            var stunde2 = new StundenplanModel();
            stunde2.ID = 2;
            stunde2.Klasse_ID = 1;
            stunde2.Klasse = "ITM-3";
            stunde2.Lehrer_ID = 2;
            stunde2.Lehrer = "Max Musterman2";
            stunde2.Raum_ID = 2;
            stunde2.Raum = "Test Raum2";
            stunde2.Fach_ID = 2;
            stunde2.Stunde = 1;
            dienstag.Add(stunde2);
            stunde2.Stunde = 2;
            dienstag.Add(stunde2);
            stunde2.Stunde = 3;
            dienstag.Add(stunde2);
            stunde2.Stunde = 4;
            dienstag.Add(stunde2);
            stunde2.Stunde = 5;
            dienstag.Add(stunde2);
            stunde2.Stunde = 6;
            dienstag.Add(stunde2);
            stunde2.Stunde = 7;
            dienstag.Add(stunde2);
            stunde2.Stunde = 8;
            dienstag.Add(stunde2);


            woche.monday = montag;
            woche.tuesday = dienstag;

            var notiz = new WochenNotizModel();
            var listNotiz = new List<WochenNotizModel>();
            notiz.Stundenplan_ID = 1;
            notiz.ID = 1;
            notiz.Text = "Test Notiz";

            listNotiz.Add(notiz);

            notiz.Stundenplan_ID = 2;
            notiz.ID = 2;
            notiz.Text = "Test Notiz2";

            listNotiz.Add(notiz);

            
            return woche;
        }

    }
}
