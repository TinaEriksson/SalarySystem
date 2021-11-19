using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    class Helper
    {
        /// <summary>
        /// Mockdata för att använda i programmet.
        /// </summary>
        public void MockdataEmployees()
        {
            Employee.listOfEmployees.Add(new Employee()
            {
                employeeId = 1,
                username = "Lo",
                password = "Lo1234",
                profession = "CoffeeMaker",
                salary = 10000
            }); ;
            Employee.listOfEmployees.Add(new Employee()
            {
                employeeId = 2,
                username = "Bob",
                password = "Bob1234",
                profession = "ElevatorDriver",
                salary = 30000
            });
            Employee.listOfEmployees.Add(new Employee()
            {
                employeeId = 3,
                username = "Ping",
                password = "Pong1234",
                profession = "PaperFlipper",
                salary = 30000
            });
        }
    }
}
