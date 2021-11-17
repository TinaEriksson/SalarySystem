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
        [DataRow("Ebba", "Ebba25")]
        public void LogInTest(string username, string password)
        {
            StartUp startUp = new();
            Employee.listOfEmployees.Add(new() { username = "Ebba", password = "Ebba25"});
            var actual = startUp.LogIn(username, password);
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        [DataRow("", "")]
        public void LogInTestNameIsEmpty(string username, string password)
        {
            StartUp startUp = new();
            var actual = startUp.LogIn(username, password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        [DataRow("Greta")]
        public void FindUserTest(string username)
        {
            StartUp startUp = new();
            Employee.listOfEmployees.Add(new() { username = "Greta" });
            var actual = startUp.FindUser(username).username;
            var expected = "Greta";
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        [DataRow("Ellen")]
        public void FindUserTestListIsNull(string username)
        {
            StartUp startUp = new();
            var actual = startUp.FindUser(username);
            Assert.IsNull(actual);
        }

        [TestMethod()]
        [DataRow("Lo")]
        public void FindUserTestNameIsNull(string username)
        {
            StartUp startUp = new();
            Employee.listOfEmployees.Add(new() { username = "Frida" });
            var actual = startUp.FindUser(username);
            Assert.IsNull(actual);
        }
    }
}