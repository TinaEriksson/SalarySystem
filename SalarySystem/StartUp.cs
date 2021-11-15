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
        }
        
        void UserMenu(Employee user)
        {
            bool loop = true;
            do
            {
                Console.WriteLine("1. See salary");
                Console.WriteLine("2. See profession");
                Console.WriteLine("3. Delete yourself");
                Console.WriteLine("0. Exit");
                var checkInput = int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(user.salary);
                        break;
                    case 2:
                        Console.WriteLine(user.profession);
                        break;
                    case 3:
                        var aUser = new Employee();
                        aUser.DeleteMe(user);
                        break;
                    case 0:
                        Console.WriteLine("Closing program..");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            } while (loop);

        }

        void AdminMenu()
        {
            var admin = new Admin();
            bool loop = true;

            do
            {
                Console.WriteLine("1. See salary");
                Console.WriteLine("2. Se profession");
                Console.WriteLine("3. List users");
                Console.WriteLine("4. Add user");
                Console.WriteLine("5. Delete user");
                Console.WriteLine("0. Exit");
                var checkInput = int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(admin.salary);
                        break;
                    case 2:
                        Console.WriteLine(admin.profession); 
                        break;
                    case 3:
                        admin.ListUsers();
                        break;
                    case 4:
                        admin.CreateUser();
                        break;
                    case 5:
                        admin.DeleteUser();
                        break;
                    case 0:
                        Console.WriteLine("Closing program..");
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
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
            return Employee.listOfUsers.Where(x => x.username == username).FirstOrDefault();
        }
    }
}


