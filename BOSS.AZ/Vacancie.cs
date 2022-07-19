using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationNamespace;
namespace VacancieNamespace
{
    public class Vacancie
    {
        public static int ID { get; set; } = 0;
        public int Id { get; set; } = ++ID;

        public List<Notification> notifications { get; set; } = new List<Notification>();
        public string Name { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public void ShowNotificatons()
        {
            if(notifications.Count > 0)
            {

            Console.WriteLine($"Vacancie ID : {Id}");
            foreach (var notification in notifications)
            {
                Console.WriteLine(notification);
            }
            }
        }
        public override string ToString()
        {
            return $@"ID: {Id}
Company Name : {Name}
Description : {Description}
Salary : {Salary} AZN";
        }
    }
}
