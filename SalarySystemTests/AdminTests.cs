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
        [TestMethod()]
        public void ListUsersTest()
        {
            Admin admin = new();
            User.listOfUsers.Add(new User() { username = "Kalle", password = "Kalle1234" });
            User.listOfUsers.Add(new User() { username = "Olle", password = "Olle1234" });
            var actual = admin.ListUsers();
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void IsAdminTest()
        {
            Admin admin = new() { username = "admin2", password = "admin1234"};
            var actual = Admin.IsAdmin(admin.username, admin.password);
            Assert.IsFalse(actual);
        }
    }
}