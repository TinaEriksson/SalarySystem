using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem.Tests
{
    [TestClass()]
    public class AdminTests
    {
        //[TestMethod()]
        //public void ListUsersTest()
        //{
        //    Admin admin = new();
        //    admin.PrintListOfEmployees();
        //    var expected = "Kalle Kalle1234"+
        //                   "Olle Olle1234";
        //    Assert.AreEqual(actual, expected);
        //}

        [TestMethod()]
        public void IsAdminTest()
        {
            Admin admin = new() { username = "admin2", password = "admin1234"};
            var actual = Admin.IsAdmin(admin.username, admin.password);
            Assert.IsFalse(actual);
        }
    }
}