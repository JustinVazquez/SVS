using Core.Access;
using Core.Helper;
using Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }   

        [Test]
        public void GetStundenPlanbyDatumAndKlasse()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
      
            var result = StundeplanAccess.GetStundenplanByKlassAndDate(con,1, DateTime.Today.ToString("yyyy-MM-dd"));
            foreach (var item in result)
            {
                item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                item.Fach = StundeplanAccess.GetRaumText(con, item.Fach_ID);
                item.Notiz = StundeplanAccess.GetNotiz(con, item.Notiz_ID);
                item.Notiz.User_Name = UserAccess.GetNameByID(con, item.Notiz.User_ID);               
            }
            con.Close();
            Console.Write("OK");
        }



        [Test]
        public void UserAddTest()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            UserAccess.AddUser(con,"Test2","Test2");
        }

        [Test]
        public void GetUser()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            var User = UserAccess.GetUser(con, "Test", "Test");
            con.Close();
            Console.Write(User);
            Debug.Write(User);
        }

        [Test]
        public void ChangeMail()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            UserAccess.ChangeEmail(con, "Justin_Vazquez", "JustinRamon.Vazquez@gmail.com");
            con.Close();         
        }

        [Test]
        public void ChangePassword()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            var name = "Justin_Vazquez";
            var password = "Test1234";
            var newPassword = "Test12345";

            if (!string.IsNullOrWhiteSpace(UserAccess.GetName(con, name)))
            {
                var userID = UserAccess.GetIdByName(con, name);
                var hash = UserAccess.GetHash(con, userID);
                var salt = UserAccess.GetSalt(con, userID);

                try
                {
                    if (SaltHashHelper.ValidatePassword(password, hash, salt))
                    {                     
                        var HashnSalt = SaltHashHelper.CreateHash(newPassword);
                        UserAccess.ChangeHash(con, name, HashnSalt.Item1);
                        UserAccess.ChangeSalt(con, name, HashnSalt.Item2);
                        con.Close();
                    }
                    else
                    {
                        Console.Write("Error");
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
        }

        [Test]
        public void UserAnlegen()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            if(string.IsNullOrEmpty(UserAccess.GetName(con,"Test")))
            {
                var SaltnHash = SaltHashHelper.CreateHash("Test");
                UserAccess.AddUser(con, "Test", SaltnHash.Item1);
                var ID = UserAccess.GetIdByName(con, "Test");
                UserAccess.AddSalt(con, ID, SaltnHash.Item2);
            }
            else
            {
                Console.Write("Error");
            }          
            con.Close();
        }

        [Test]
        public void Validate()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            var name = "Justin_Vazquez";
            var password = "Test12345";

            if (!string.IsNullOrWhiteSpace(UserAccess.GetName(con, name)))
            {
                var userID = UserAccess.GetIdByName(con, name);
                var hash = UserAccess.GetHash(con, userID);
                var salt = UserAccess.GetSalt(con, userID);

                try
                {
                    if (SaltHashHelper.ValidatePassword(password, hash, salt))
                    {
                        Console.Write(UserAccess.GetUser(con, name, hash));
                    }
                    else
                    {
                        Console.Write("Error");
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
        }

        [Test]
        public void GetWochenPlan()
        {
            var today = DateTime.Today;
            var klasse = 1;
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
                if(i == 0)
                    woche.monday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                foreach (var item in woche.monday)
                {
                    item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                    item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                    item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                    item.Fach = StundeplanAccess.GetRaumText(con, item.Fach_ID);
                }
                if (i == 1)
                    woche.tuesday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                foreach (var item in woche.tuesday)
                {
                    item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                    item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                    item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                    item.Fach = StundeplanAccess.GetRaumText(con, item.Fach_ID);
                }
                if (i == 2)
                    woche.wednesday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                foreach (var item in woche.wednesday)
                {
                    item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                    item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                    item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                    item.Fach = StundeplanAccess.GetRaumText(con, item.Fach_ID);
                }
                if (i == 3)
                    woche.thursday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                foreach (var item in woche.thursday)
                {
                    item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                    item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                    item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                    item.Fach = StundeplanAccess.GetRaumText(con, item.Fach_ID);
                }
                if (i == 4)
                    woche.friday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                foreach (var item in woche.friday)
                {
                    item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                    item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                    item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                    item.Fach = StundeplanAccess.GetRaumText(con, item.Fach_ID);
                }
            }
            woche.weekNotes = NotizAccess.GetWochenNotizenByID(con, dates[0].ToString("yyyy-MM-dd"), dates[4].ToString("yyyy-MM-dd"),klasse);
            Console.Write(woche);
        }

        [Test]
        public void sendMail()
        {              
            var email = "JustinRamon.Vazquez@gmail.com";


            //var tmp = UserAccess.getEmails(con, 1); //Alle Emails der ITM-3
            var list = new List<string>();
            list.Add(email);
            list.Add(email);

            var text = "Test";
            var client = new SmtpClient("smtp.googlemail.com", 465)
            {
                Credentials = new NetworkCredential("svs.aenderung@gmail.com", "Projekttage123!"),
                EnableSsl = true,               
                
            };
            foreach (var item in list)
            {                       
                client.Send("svs.aenderung@gmail.com", "JustinRamon.Vazquez@gmail.com", "�nderung Stundenplan", "Test");
            }
          
            Console.WriteLine("Sent");        
        }

    }
}