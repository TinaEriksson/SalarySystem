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
        
        void UserMenu(Employee employee)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1. See salary");
                Console.WriteLine("2. See profession");
                Console.WriteLine("3. Delete yourself");
                Console.WriteLine("0. Log out");
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
                        var aEmployee = new Employee();
                        aEmployee.DeleteMe(employee);
                        break;
                    case "0":
                        Console.WriteLine("Logging out..");
                        Thread.Sleep(1000);
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.WriteLine("Press enter to continue..");
                Console.ReadKey();
            } while (keepGoing);

        }

        void AdminMenu()
        {
            Admin admin = new();
            bool loop = true;

            do
            {
                Console.Clear();
                Console.WriteLine("1. See salary");
                Console.WriteLine("2. Se profession");
                Console.WriteLine("3. List employees");
                Console.WriteLine("4. Add employee");
                Console.WriteLine("5. Delete employee");
                Console.WriteLine("0. Log out");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(admin.salary);
                        break;
                    case "2":
                        Console.WriteLine(admin.profession); 
                        break;
                    case "3":
                        admin.PrintListOfEmployees();
                        break;
                    case "4":
                        admin.CreateEmployee();
                        break;
                    case "5":
                        admin.DeleteEmployee();
                        break;
                    case "0":
                        Console.WriteLine("Logging out..");
                        Thread.Sleep(1000);
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.WriteLine("Press enter to continue..");
                Console.ReadKey();
            } while (loop);
            
        }
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
                    Console.WriteLine("Login failed");
                    return false;
                }
            }
        }

        public Employee FindUser(string username)
        {    
            return Employee.listOfEmployees.Where(x => x.username == username).FirstOrDefault();
        }
    }
}


