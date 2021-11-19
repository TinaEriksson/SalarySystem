using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem;
using SalarySystem.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystemTests
{
    [TestClass()]
    public class IntegrationTests
    {
        [TestMethod()]
        public void IntegrationTestEmployee()
        {
            Employee employee = new()
            {
                username="Ulla",
                password= "Ulla1234",
                profession="Copiater",
                salary= 10000,
            };
            Employee.listOfEmployees.Add(employee);
            StartUp start = new();
         
            var actual = start.LogIn(employee.username, employee.password);
            var actual2 = employee.DeleteMe(employee);
            var actual3 = start.LogIn(employee.username, employee.password);

            Assert.IsTrue(actual);
            Assert.IsTrue(actual2);
            Assert.IsFalse(actual3);

        }

        [TestMethod()]
        public void IntegrationTestAdmin()
        {
            Admin admin = new();
            StartUp start = new();

            var actual = start.LogIn(admin.username, admin.password);
            var actual2 = admin.CreateEmployee("Ulla", "Ulla1234", "Copiater", 10000);
            var employee = start.FindUser("Ulla");
            var actual3 = admin.DeleteEmployee(employee);
            var actual4 = start.FindUser("Ulla");

            Assert.IsTrue(actual);
            Assert.IsTrue(actual2);
            Assert.IsTrue(actual3);
            Assert.IsNull(actual4);
        }
    }
}
