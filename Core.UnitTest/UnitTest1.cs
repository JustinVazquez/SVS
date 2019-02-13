using Core.Access;
using Core.Helper;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var con = DbHelper.GetDbConnection();
            con.Open();
            UserAccess.AddUser(con,"Test","Test");
        }
    }
}
//https://monarigmbh-my.sharepoint.com/:o:/g/personal/vazquez_monari_de/EgmFD6PxBkdLsl_yK4Kq0iAB3cP40WsfG2mlBJZSNBD70w?e=PfuTXd