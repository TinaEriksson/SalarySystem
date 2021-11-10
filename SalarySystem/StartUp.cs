using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    class StartUp
    {
        public static void StartMenu()
        {
            Console.WriteLine("Enter username and password.");
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
        }
        
        public static void UserMenu()
        {
            Console.WriteLine("1. See salary");
            Console.WriteLine("2. Se profession");
            Console.WriteLine("3. Delete yourself");
        }

        public static void AdminMenu()
        {
            Console.WriteLine("1. See salary");
            Console.WriteLine("2. Se profession");
            Console.WriteLine("3. List users");
            Console.WriteLine("4. Add user");
            Console.WriteLine("5. Delete user");
        }
    }
}


