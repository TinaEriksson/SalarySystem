using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    class User:Account
    {
        

        public User(string username, string password) : base(username, password)
        {
            this.username = username;
            this.password = password;
        }

        void DeleteMe()
        {
            
        }
    }
}
