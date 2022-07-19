using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancieNamespace
{
    public class Vacancie
    {
        public static int ID { get; set; } = 0;
        public int Id { get; set; } = ++ID;

        public string Name { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public override string ToString()
        {
            return $@"ID: {Id}
Company Name : {Name}
Description : {Description}
Salary : {Salary} AZN";
        }
    }
}
