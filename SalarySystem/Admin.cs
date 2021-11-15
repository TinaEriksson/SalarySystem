using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class Admin : Account
    {
        public Admin()
        {

        }

        public Admin(string username, string password, string profession, int salary) : base(username, password, profession, salary)
        {
            username = "admin1";
            password = "admin1234";
            profession = "administrator";
            salary = 100000;
        }

        public void ListUsers()
        {
            if(Employee.listOfUsers != null)
            {
                int counter = 1;
                foreach (var person in Employee.listOfUsers)
                {
                    Console.WriteLine($"{counter}. {person.username} {person.password}");
                    counter++;
                }
            }
        }

        public void CreateUser()
        {
            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            Console.Write("Profession: ");
            var profession = Console.ReadLine();
            Console.Write("Salary: ");
            var checkIfNumber = int.TryParse(Console.ReadLine(), out int salary);
            Employee.listOfUsers.Add(new()
            {
                username = username,
                password = password,
                profession = profession,
                salary = salary,
            });
        }

        public static bool IsAdmin(string username, string password)
        {
            if (username == "admin1" && password == "admin1234")
                return true;
            else
                return false;
        }

        internal void DeleteUser()
        {
            ListUsers();
            Console.WriteLine("Enter number of user to delete");
            var checkNumber = int.TryParse(Console.ReadLine(), out int choice);

        }
    }
}
