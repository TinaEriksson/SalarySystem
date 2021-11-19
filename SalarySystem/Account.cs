using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    /// <summary>
    /// Klass som Admin och Employee ärver ifrån.
    /// </summary>
    public class Account
    {
        
        public string username { get; set; }
        public string password { get; set; }
        public string profession { get; set; }
        public int salary { get; set; }

        public Account()
        {

        }
        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Account(string username, string password, string profession, int salary)
        {
            this.username = username;
            this.password = password;
            this.profession = profession;
            this.salary = salary;
        }
    }
}
