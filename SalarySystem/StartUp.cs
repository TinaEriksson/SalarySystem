﻿using System;
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
        public void LogIn(string username, string password)
        {
            //if (Admin.IsAdmin(username, password))
            //{
            //    AdminMenu();
            //}
            //else //Vad händer vid default???
            //{
            //    var isUser = FindUser(username);
            //    if (isUser.password == password)
            //    {
            //        UserMenu();
            //    }
            //    else
            //    {
            //        Console.WriteLine("Login failed");
            //        StartMenu();
            //    }
            //}
        }

        public IEnumerable<User> FindUser(string username) //Fundera om if-sats ska finnas 
        {                                                  //Se över testerna
            return User.listOfUsers?.Where(x => x.username == username);
        }
    }
}


