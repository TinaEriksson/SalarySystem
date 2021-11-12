﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        [DataRow(18000)]
        public void SeeSalaryTest(int expected)
        {
            var user = new User()
            {
                salary = 18000,
            };
            var actual = user.SeeSalary(user);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void DeleteMeTest()
        {
            Assert.Fail();
        }
    }
}