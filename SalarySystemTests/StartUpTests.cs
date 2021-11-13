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
        public void FindUserTest(string username)
        {
            var startUp = new StartUp();
            var actual = startUp.FindUser(username);
            Assert.Fail();
        }

        [TestMethod()]
        public void LogInTest1()
        {
            Assert.Fail();
        }
    }
}