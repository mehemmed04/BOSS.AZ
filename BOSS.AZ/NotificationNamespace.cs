using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationNamespace
{
    public class Notification
    {
        public static int ID { get; set; }
        public int Id { get; set; }=++ID;
        public string WorkerName { get; set; }
        public int WorkerID { get; set; }
        public string WorkerEmail { get; set; }
        public DateTime NotificatinDate { get; set; } = DateTime.Now;
        public override string ToString()
        {
            return $@"Notification ID: {Id}
Name : {WorkerName}
Worker ID: {WorkerID}
Email : {WorkerEmail}
DATE : {NotificatinDate.ToShortDateString()}
";
        }
    }
}
