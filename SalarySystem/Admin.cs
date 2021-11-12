using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class Admin : Account
    {
        public Admin(string username, string password) : base(username, password)
        {
            username = "admin1";
            password = "admin1234";
        }

        public void ListUsers()
        {

        }
        void CreateUser()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.Write("Username: ");
            var profession = Console.ReadLine();
            Console.Write("Password: ");
            var salary = Console.ReadLine();


        }

        public static bool IsAdmin(string username, string password)
        {
            if (username == "admin1" && password == "admin1234")
                return true;
            else
                return false;
        }
    }
}
