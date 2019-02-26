using System;
using System.Linq;
using Core.Access;
using Core.Helper;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAPI.Test
{
    [TestClass]
    public class HubTest
    {
        [TestMethod]
        public void GetWoche()
        {
            try
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
                    if (i == 0)
                    {
                        woche.monday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                        foreach (var item in woche.monday)
                        {
                            item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                            item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                            item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                            item.Fach = StundeplanAccess.GetFachText(con, item.Fach_ID);
                            item.Status = StundeplanAccess.GetStatusText(con, item.Status_ID);
                        }
                    }


                    if (i == 1)
                    {
                        woche.tuesday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                        foreach (var item in woche.tuesday)
                        {
                            item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                            item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                            item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                            item.Fach = StundeplanAccess.GetFachText(con, item.Fach_ID);
                            item.Status = StundeplanAccess.GetStatusText(con, item.Status_ID);
                        }
                    }

                    if (i == 2)
                    {
                        woche.wednesday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                        foreach (var item in woche.wednesday)
                        {
                            item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                            item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                            item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                            item.Fach = StundeplanAccess.GetFachText(con, item.Fach_ID);
                            item.Status = StundeplanAccess.GetStatusText(con, item.Status_ID);
                        }
                    }

                    if (i == 3)
                    {
                        woche.thursday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                        foreach (var item in woche.thursday)
                        {
                            item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                            item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                            item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                            item.Fach = StundeplanAccess.GetFachText(con, item.Fach_ID);
                            item.Status = StundeplanAccess.GetStatusText(con, item.Status_ID);
                        }
                    }


                    if (i == 4)
                    {
                        woche.friday = StundeplanAccess.GetStundenplanByKlassAndDate(con, klasse, dates[i].ToString("yyyy-MM-dd"));
                        foreach (var item in woche.friday)
                        {
                            item.Klasse = StundeplanAccess.GetKlasseText(con, item.Klasse_ID);
                            item.Lehrer = StundeplanAccess.GetLehrerText(con, item.Lehrer_ID);
                            item.Raum = StundeplanAccess.GetRaumText(con, item.Raum_ID);
                            item.Fach = StundeplanAccess.GetFachText(con, item.Fach_ID);
                            item.Status = StundeplanAccess.GetStatusText(con, item.Status_ID);
                        }
                    }

                }

                woche.weekNotes = NotizAccess.GetWochenNotizenByID(con, dates[0].ToString("yyyy-MM-dd"), dates[4].ToString("yyyy-MM-dd"), klasse);
                Console.WriteLine("Success");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [TestMethod]
        public void AddUser()
        {
            try
            {
                var con = DbHelper.GetDbConnection();
                con.Open();
                UserAccess.AddUser(con, "Test2", "Test2");
                Console.WriteLine("Success");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

         
        }

        [TestMethod]
        public void Name()
        {
            try
            {
                var con = DbHelper.GetDbConnection();
                con.Open();
                var User = UserAccess.GetUser(con, "Test", "Test");
                con.Close();
                Console.WriteLine("Success");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
