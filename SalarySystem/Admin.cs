using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

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
            Console.Clear();
            Console.WriteLine("\nEmployees in the system.");
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

        public void EnterDataToCreateEmployee()
        {
            Console.Clear();
            Console.WriteLine("\nAdd a new employee.\n");
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
                    CreateEmployee(username, password, profession, salary);
                    keepGoing = false;
                }
                else
                {
                    Console.WriteLine("Password needs to contain letters and numbers.");
                }
            } while (keepGoing);
        }

        public bool CreateEmployee(string username, string password,
            string profession, int salary)
        {
            if(username != null && password != null)
            {
                Employee.listOfEmployees.Add(new()
                {
                    employeeId = FindLastEmployee() + 1,
                    username = username,
                    password = password,
                    profession = profession,
                    salary = salary,
                });
                return true;
            }
            return false;
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

        public void EnterDataToDeleteEmployee()
        {
            Console.Clear();
            Console.WriteLine("\nDelete employee.\n");
            Console.Write("Enter username of employee to delete: ");
            var username = Console.ReadLine();
            Console.Write("Enter password of employee to delete: ");
            var password = Console.ReadLine();
            var employee = start.FindUser(username, password);
            if (DeleteEmployee(employee))
            {
                Console.WriteLine("Employee was deleted.");
            }
            else
            {
                EnterDataToDeleteEmployee();
            }   
        }

        public bool DeleteEmployee(Employee employee)
        {
            if(employee is not null && employee.DeleteMe(employee))
            {
                return true;
            }
            else
            {
                Console.WriteLine("No matching employee..");
                Thread.Sleep(1500);
                return false;
            }
        }


    }
}
