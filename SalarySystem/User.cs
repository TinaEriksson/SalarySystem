using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class User:Account
    {


        public User() 
        { 
        
        }

        public User(string username, string password) : base(username, password)
        {
            this.username = username;
            this.password = password;
        }

        public void DeleteMe()
        {
            
        }
         public int SeeSalary(User user)
        {
            return user.salary;
        }
         void SeeProfession()
        {

        }

    }
}
