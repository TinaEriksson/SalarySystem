using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class StartUp
    {
        /// <summary>
        /// Startup metod, där användaren får skriva in 
        /// inloggningsuppgifter.
        /// </summary>
        public void StartMenu()
        {
            Helper help = new();
            help.MockdataEmployees();
            var keepGoing = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter username and password.");
                Console.Write("Username: ");
                var username = Console.ReadLine();
                Console.Write("Password: ");
                var password = Console.ReadLine();
                if (LogIn(username, password))
                {
                    if (Admin.IsAdmin(username, password))
                    {
                        AdminMenu();
                    }
                    else
                    {
                        UserMenu(FindUser(username));
                    }
                };
            } while (keepGoing);
        }
        
        /// <summary>
        /// Meny för om användaren är en valig anställd, 
        /// och inte admin.
        /// </summary>
        /// <param name="employee">En anställd.</param>
        void UserMenu(Employee employee)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                Console.Write($"Logged in as: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{employee.username}\n");
                Console.ResetColor();
                Console.WriteLine("1. See salary");
                Console.WriteLine("2. See profession");
                Console.WriteLine("3. Delete yourself");
                Console.WriteLine("0. Log out");
                Console.Write("Enter choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(employee.salary);
                        break;
                    case "2":
                        Console.WriteLine(employee.profession);
                        break;
                    case "3":
                        Employee aEmployee = new();
                        if (aEmployee.DeleteMe(employee))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Employee deleted from system.");
                            Console.ResetColor();
                            keepGoing = false;
                        }
                        break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Logging out..");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        keepGoing = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input");
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press enter to continue..");
                Console.ResetColor();
                Console.ReadKey();
            } while (keepGoing);

        }

        /// <summary>
        /// Meny för admin.
        /// </summary>
        void AdminMenu()
        {
            Admin admin = new();
            bool loop = true;
            do
            {
                Console.Clear();
                Console.Write($"Logged in as: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{admin.username}\n");
                Console.ResetColor();
                Console.WriteLine("1. See salary");
                Console.WriteLine("2. Se profession");
                Console.WriteLine("3. List employees");
                Console.WriteLine("4. Add employee");
                Console.WriteLine("5. Delete employee");
                Console.WriteLine("0. Log out");
                Console.Write("Enter choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n" + admin.salary);
                        break;
                    case "2":
                        Console.WriteLine("\n" + admin.profession); 
                        break;
                    case "3":
                        admin.PrintListOfEmployees();
                        break;
                    case "4":
                        admin.EnterDataToCreateEmployee();
                        break;
                    case "5":
                        admin.EnterDataToDeleteEmployee();
                        break;
                    case "0":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nLogging out..");
                        Console.ResetColor();
                        loop = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input");
                        Console.ResetColor();
                        break;
                }
                Thread.Sleep(2500);
            } while (loop);
            
        }
        /// <summary>
        /// Kollar om användaren finns och är admin eller en anställd.  
        /// </summary>
        /// <param name="username">Användarens användarnamn</param>
        /// <param name="password">Användarens lösenord</param>
        /// <returns></returns>
        public bool LogIn(string username, string password)
        {
            if (Admin.IsAdmin(username, password))
            {
                return true;
            }
            else
            {
                var theUser = FindUser(username);
                if (theUser is not null && theUser.password == password)
                {
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Login failed, try again..");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    return false;
                }
            }
        }

        /// <summary>
        /// Kollar om en användare med ett visst användarnamn
        /// finns i listan för anställda.
        /// </summary>
        /// <param name="username">Användarnamn på användare som söks efter</param>
        /// <returns>En användare om det finns en, annas defaultvärde.</returns>
        public Employee FindUser(string username)
        {    
            return Employee.listOfEmployees.Where(x =>
            x.username == username).FirstOrDefault();
        }

        /// <summary>
        /// Kollar om en användare med ett visst användarnamn
        /// finns i listan för anställda.
        /// </summary>
        /// <param name="username">Användarnamn på användare som söks efter</</param>
        /// <param name="password">Lösenord på användare som söks efter</param>
        /// <returns>En användare om det finns en, annars defaultvärdet.</returns>
        public Employee FindUser(string username, string password)
        {
            return Employee.listOfEmployees.Where(x => x.username == username 
            && x.password == password).FirstOrDefault();
        }
    }
}


