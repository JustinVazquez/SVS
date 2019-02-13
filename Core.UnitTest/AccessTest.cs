using Core.Access;
using Core.Helper;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

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
            var SaltnHash = SaltHashHelper.CreateHash("Test1234");
            UserAccess.AddUser(con, "Justin_Vazquez", SaltnHash.Item1);
            var ID = UserAccess.GetIdByName(con, "Justin_Vazquez");
            UserAccess.AddSalt(con, ID, SaltnHash.Item2);
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
    }
}
//https://monarigmbh-my.sharepoint.com/:o:/g/personal/vazquez_monari_de/EgmFD6PxBkdLsl_yK4Kq0iAB3cP40WsfG2mlBJZSNBD70w?e=PfuTXd