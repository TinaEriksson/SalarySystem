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
    public class EmployeeTests
    {
        [TestMethod()]
        [DataRow("Pelle","pelle123")]
        public void DeleteMeTest(string username, string password)
        {
            Employee user = new() { username = username, password = password };
            Employee.listOfEmployees.Add(user);
            var actual = user.DeleteMe(user);
            Assert.IsTrue(actual);
        }
    }
}