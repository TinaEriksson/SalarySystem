using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class Employee:Account
    {
        public static List<Employee> listOfEmployees = new List<Employee>();
        public int employeeId { get; set; }

        public Employee() 
        { 
        
        }

        public Employee(string username, string password) : base(username, password)
        {
            this.username = username;
            this.password = password;

        }

        /// <summary>
        /// Tar bort användare
        /// </summary>
        /// <param name="user">Användare</param>
        /// <returns>Om raderandet lyckades</returns>
        public bool DeleteMe(Employee user)
        {
            if (listOfEmployees.Contains(user))
            {
                listOfEmployees.Remove(user);
                return true;
            }
            return false;
        }
    }
}
