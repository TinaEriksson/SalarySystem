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
        [DataRow("admin1", "admin1234")]
        public void LogInTest(string username, string password)
        {
            var startUp = new StartUp();
            var actual = startUp.LogIn(username, password);
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [DataRow("Greta")]
        public void FindUserTest(string username)
        {
            var startUp = new StartUp();
            User.listOfUsers.Add(new() { username = "Greta" });
            var actual = startUp.FindUser(username).username;
            var expected = "Greta";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        [DataRow("Ellen")]
        public void FindUserTestNull(string username)
        {
            var startUp = new StartUp();
            var actual = startUp.FindUser(username);
            Assert.IsNull(actual);
        }

        [TestMethod()]
        [DataRow("Lo")]
        public void FindUserTestZero(string username)
        {
            var startUp = new StartUp();
            User.listOfUsers.Add(new() { username = "Frida" });
            var actual = startUp.FindUser(username);
            Assert.IsNull(actual);
        }
    }
}