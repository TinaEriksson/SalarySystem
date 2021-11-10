using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    internal class Admin : Account
    {
        public Admin(string username, string password) : base(username, password)
        {
            username = "admin1";
            password = "admin1234";
        }

        void ListUsers()
        {

        }
        void CreateUser()
        {

        }
    }
}
