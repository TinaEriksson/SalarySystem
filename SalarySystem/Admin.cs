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

        /// <summary>
        /// Skriver ut listan på anställda.
        /// Om listan är null, skrivs felmeddelande ut. 
        /// </summary>
        public void PrintListOfEmployees()
        {
            Console.Clear();
            Console.WriteLine("\nEmployees in the system.");
            if(Employee.listOfEmployees.Count > 0)
            {
                foreach (var person in Employee.listOfEmployees)
                {
                    Console.WriteLine($"EmployeeId: {person.employeeId}. " +
                                      $"Username: {person.username} " +
                                      $"Password: {person.password}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThere is no employees in the system.");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// En metod för att skriva in data om en användare
        /// som ska skapas upp.
        /// </summary>
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
                    if(CreateEmployee(username, password, profession, salary))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Added to system:");
                        Console.ResetColor();
                           Console.WriteLine($"\n{username}\npassword: {password}" +
                            $"\nprofession: {profession} \nsalary: {salary}");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ResetColor();
                        keepGoing = false;
                    }
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Password needs to contain letters and numbers.");
                    Console.ResetColor();
                }
            } while (keepGoing);
        }

        /// <summary>
        /// Metod som skapar upp användaren.
        /// </summary>
        /// <param name="username">Användarnamnet på nya användaren</param>
        /// <param name="password">Nya användarens lösenord</param>
        /// <param name="profession">Nya användarens yrke</param>
        /// <param name="salary">Nya användarens lön</param>
        /// <returns>True om användaren kunde skapas, annars false.</returns>
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

        /// <summary>
        /// Metod för att validera lösenordet.
        /// </summary>
        /// <param name="password">Det lösenord som ska valideras.</param>
        /// <returns>True om det inskrivna lösenordet matchar kravet.</returns>
        private bool passwordIsValidated(string password)
        {
            var demands = new Regex("^(?=.*[a-zA-Z])(?=.*[0-9])");
            return demands.IsMatch(password);
        }

        /// <summary>
        /// Letar upp id på den senast tillagda anställda. 
        /// Om det inte finns nån, så kommer det sättas till 0.
        /// </summary>
        /// <returns>Id på senast tillagda användare, eller 0</returns>
        private int FindLastEmployee()
        {
            var lastEmployee = Employee.listOfEmployees.LastOrDefault();
            if (lastEmployee is null) return 0;
            return lastEmployee.employeeId;
        }

        /// <summary>
        /// Kollar om en användare är admin eller inte.
        /// </summary>
        /// <param name="username">Användarnamnet som ska kollas.</param>
        /// <param name="password">Lösenordet som ska kollas.</param>
        /// <returns>Sant om användaren är en admin, annars falskt.</returns>
        public static bool IsAdmin(string username, string password)
        {
            if (username == "admin1" && password == "admin1234")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// En metod där man får skriva in användarnamn och lösenord på 
        /// användare som man vill ta bort.
        /// </summary>
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee was deleted.");
                Console.ResetColor();
            }
            else
            {
                EnterDataToDeleteEmployee();
            }   
        }

        /// <summary>
        /// Metod som tar bord vald användare.
        /// </summary>
        /// <param name="employee">Den användare som ska tas bort.</param>
        /// <returns>Sant om det lyckades, falsk om matchande användare
        /// inte finns.</returns>
        public bool DeleteEmployee(Employee employee)
        {
            if(employee is not null && employee.DeleteMe(employee))
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No matching employee..");
                Console.ResetColor();
                Thread.Sleep(1500);
                return false;
            }
        }


    }
}
