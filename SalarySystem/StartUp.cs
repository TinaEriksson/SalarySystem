using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class StartUp
    {
        public void StartMenu()
        {
            Console.WriteLine("Enter username and password.");
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            LogIn(username, password);
        }
        
        void UserMenu()
        {
            Console.WriteLine("1. See salary");
            Console.WriteLine("2. See profession");
            Console.WriteLine("3. Delete yourself");
        }

        void AdminMenu()
        {
            Console.WriteLine("1. See salary");
            Console.WriteLine("2. Se profession");
            Console.WriteLine("3. List users");
            Console.WriteLine("4. Add user");
            Console.WriteLine("5. Delete user");
        }
        public bool LogIn(string username, string password)
        {
            if (Admin.IsAdmin(username, password))
            {
                AdminMenu();
                return true;
            }
            else
            {
                var isUser = FindUser(username);
                if (isUser is not null && isUser.password == password)
                {
                    UserMenu();
                    return true;
                }
                else
                {
                    Console.WriteLine("Login failed");
                    StartMenu();
                    return false;
                }
            }
        }

        public User FindUser(string username) //Fundera om if-sats ska finnas 
        {                                                  //Se över testerna
            return User.listOfUsers.Where(x => x.username == username).FirstOrDefault();
        }
    }
}


