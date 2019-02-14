using Core.Access;
using Core.Helper;
using Core.Models;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        /*
         * DateTime today = DateTime.Today;
        int currentDayOfWeek = (int) today.DayOfWeek;
        DateTime sunday = today.AddDays(-currentDayOfWeek);
        DateTime monday = sunday.AddDays(1);
        // If we started on Sunday, we should actually have gone *back*
        // 6 days instead of forward 1...
        if (currentDayOfWeek == 0)
        {
        monday = monday.AddDays(-7);
        }
        var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();
         * */

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
            UserAccess.AddUser(con,"Test","Test");
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
            if(string.IsNullOrEmpty(UserAccess.GetName(con,"Justin_Vazquez")))
            {
                var SaltnHash = SaltHashHelper.CreateHash("Test1234");
                UserAccess.AddUser(con, "Justin_Vazquez", SaltnHash.Item1);
                var ID = UserAccess.GetIdByName(con, "Justin_Vazquez");
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
        public void TestMethod()
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
            Console.Write(woche);
        }
        
    }
}
//https://monarigmbh-my.sharepoint.com/:o:/g/personal/vazquez_monari_de/EgmFD6PxBkdLsl_yK4Kq0iAB3cP40WsfG2mlBJZSNBD70w?e=PfuTXd