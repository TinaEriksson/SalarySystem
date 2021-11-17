using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SalarySystem
{
    public class Admin : Account
    {
        StartUp start = new();
        Employee employee = new();
        public Admin()
        {
            username = "admin1";
            password = "admin1234";
            profession = "administrator";
            salary = 100000;
        }

        public void PrintListOfEmployees()
        {
            if(Employee.listOfEmployees != null)
            {
                foreach (var person in Employee.listOfEmployees)
                {
                    Console.WriteLine($"EmployeeId: {person.employeeId}. " +
                                      $"Username: {person.username} " +
                                      $"Password: {person.password}");
                }
            }
        }

        public void CreateEmployee()
        {
            var keepGoing = true;
            Console.Write("Username: ");
            var username = Console.ReadLine();
            do
            {
                Console.Write("Password: ");
                var password = Console.ReadLine();
                if (passwordIsValidated(password))
                {
                    Console.Write("Profession: ");
                    var profession = Console.ReadLine();
                    Console.Write("Salary: ");
                    var checkIfNumber = int.TryParse(Console.ReadLine(), out int salary);
                    Employee.listOfEmployees.Add(new()
                    {
                        employeeId = FindLastEmployee() + 1,
                        username = username,
                        password = password,
                        profession = profession,
                        salary = salary,
                    });
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine("Password needs to contain letters and numbers.");
                }
            } while (keepGoing);
        }

        private bool passwordIsValidated(string password)
        {
            var demands = new Regex("^(?=.*[a-zA-Z])(?=.*[0-9])");
            return demands.IsMatch(password);
        }

        private int FindLastEmployee()
        {
            var lastEmployee = Employee.listOfEmployees.LastOrDefault();
            if (lastEmployee is null) return 0;
            return lastEmployee.employeeId;
        }

        public static bool IsAdmin(string username, string password)
        {
            if (username == "admin1" && password == "admin1234")
                return true;
            else
                return false;
        }

        internal void DeleteEmployee()
        {
            Console.Write("Enter username of employee to delete: ");
            var username = Console.ReadLine();
            Console.Write("Enter password of employee to delete: ");
            var password = Console.ReadLine();
            var employee = start.FindUser(username, password);
            
            if(employee is not null && employee.DeleteMe(employee))
            {
                Console.WriteLine("Employee was deleted.");
            }
            else
            {
                Console.WriteLine("No matching employee..");
            }
        }


    }
}
