using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNamespace;
namespace DatabaseNamespace
{
    public class DatabaseNamespace
    {
        List<User> users = new List<User>();
        public User GetUser()
        {
            string username;
            string password;
            Console.Write("Enter Username : ");
            Console.Write("Enter Password : ");
            return new User();
        }
    }
}
