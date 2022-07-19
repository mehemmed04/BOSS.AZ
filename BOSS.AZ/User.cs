using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVnamespace;
using VacancieNamespace;
namespace UserNamespace
{
    public class User
    {
        public static int ID { get; set; } = 0;
        public int Id { get; set; } = ++ID;
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

    }
   public class Worker : User
    {
        public List<CV> Cvs { get; set; }
        public List<string> Notifications { get; set; }=new List<string>();
        public int UnreadNotificationsCount { get; set; } = 0;
        public void ShowAllNotifications()
        {
            for (int i = 0; i < Notifications.Count; i++)
            {
                Console.WriteLine($"{i+1}) {Notifications[i]}");
            }
        }
    }
   public class Employer : User
    {
        public List<Vacancie> Vacancies { get; set; }
        public void ShowVacancies()
        {
            foreach (var vacancie in Vacancies)
            {
                Console.WriteLine(vacancie);
                Console.WriteLine("-------------------------");
            }
        }

    }
}