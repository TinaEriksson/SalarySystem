using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalarySystem
{
    public class User:Account
    {
        public static List<User> listOfUsers = new List<User>();

        public User() 
        { 
        
        }

        public User(string username, string password) : base(username, password)
        {
            this.username = username;
            this.password = password;
        }

        public bool DeleteMe(User user)
        {
            if (listOfUsers.Contains(user))
            {
                listOfUsers.Remove(user);
                return true;
            }
            return false;
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
