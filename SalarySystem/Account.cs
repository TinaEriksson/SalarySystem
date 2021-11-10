using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    class Account
    {
        static List<Account> users = new List<Account>();

        public string username { get; set; }
        public string password { get; set; }
        public string profession { get; set; }
        public int salary { get; set; }

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
