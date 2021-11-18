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
        public void IntegrationTest()
        {
            Employee employee = new()
            {
                username="Ulla",
                password= "Ulla1234",
                profession="Copiater",
                salary= 10000,
            };
            AdminTests admin = new();
            StartUpTests start = new();
            EmployeeTests employeeTests = new();

            admin.CreateEmployeeTest(employee.username, employee.password,
                                    employee.profession, employee.salary);          
            start.LogInTest(employee.username, employee.password);
            start.FindUserTest(employee.username);          
            employeeTests.DeleteMeTest(employee.username, employee.password);

            A


        }
    }
}
