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
        public void DeleteMeTest()
        {
            Employee user = new() { username = "Pelle", password = "pelle123" };
            Employee.listOfEmployees.Add(user);
            var actual = user.DeleteMe(user);
            Assert.IsTrue(actual);
        }
    }
}