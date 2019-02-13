using Core.Access;
using Core.Helper;
using NUnit.Framework;
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
            UserAccess.AddUser(con,"Test2","Test2");
        }

        [Test]
        public void GetUser()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            var User = UserAccess.GetUser(con, "Test", "Test");
            con.Close();
            Debug.Write(User);
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
    }
}
//https://monarigmbh-my.sharepoint.com/:o:/g/personal/vazquez_monari_de/EgmFD6PxBkdLsl_yK4Kq0iAB3cP40WsfG2mlBJZSNBD70w?e=PfuTXd