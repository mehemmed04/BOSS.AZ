using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVnamespace;
namespace UserNamespace
{
    public class User
    {
        public static int ID { get; set; } = 0;
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
    class Worker : User
    {
        public List<CV> Cvs { get; set; } = new List<CV>();
    }
    class Employer : User
    {

    }
}