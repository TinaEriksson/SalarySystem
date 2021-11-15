using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class StartUpTests
    {
        [TestMethod()]
        public void LogInTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        [DataRow("Josefine")]
        public void FindUserTest(string username)
        {
            var startUp = new StartUp();
            User.listOfUsers.Add(new() { username = "Josefine" });
            var actual = startUp.FindUser(username);
            Assert.IsTrue(actual.Count()>0);
        }

        [TestMethod()]
        [DataRow("Lo")]
        public void FindUserTestZero(string username)
        {
            var startUp = new StartUp();
            User.listOfUsers.Add(new() { username = "Josefine" });
            var actual = startUp.FindUser(username);
            Assert.IsTrue(actual.Count()==0);
        }

        [TestMethod()]
        [DataRow("Josefine")]
        public void FindUserTestNull(string username)
        {
            var startUp = new StartUp();
            var actual = startUp.FindUser(username);
            Assert.IsTrue(actual.Count() == 0);
        }
    }
}