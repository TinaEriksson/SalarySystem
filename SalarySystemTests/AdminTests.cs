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
        public void IsAdminTest()
        {
            Admin admin = new() { username = "admin2", password = "admin1234" };
            var actual = Admin.IsAdmin(admin.username, admin.password);
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        [DataRow("Judit", "Judit12", "Syslöjdslärare", 35000)]
        [DataRow("Kalle", "Karl123", null, null)]
        [DataRow("Olle", "Olle123", "", 123456)]
        [DataRow("Olle", "Olle123", "", null)]
        public void CreateEmployeeTest(string username, string password,
            string profession, int salary)
        {
            Admin admin = new();
            var actual = admin.CreateEmployee(username, password, 
                profession, salary);
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void DeleteEmployeeTest()
        {
            Admin admin = new();
            Employee anEmployee = new() { username = "Magda", password = "Magda35" };
            Employee.listOfEmployees.Add(anEmployee);
            var actual = admin.DeleteEmployee(anEmployee);
            Assert.IsTrue(actual);
        }


    }
}