using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNamespace;
using VacancieNamespace;
using CVnamespace;
using NotificationNamespace;
using CustomExceptionsNamespace;
using System.Diagnostics;

namespace DatabaseNamespace
{
    public class Database
    {
        public List<User> Users = new List<User>();
        public User GetUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public void AddUser()
        {
            Console.WriteLine("Enter Username : ");
            string username = Console.ReadLine();
            StackFrame callStack = new StackFrame(1, true);

            foreach (var user in Users)
            {
                if (user.Username == username)
                {
                    Console.WriteLine("Tekrarlana bilmez");
                    throw new CustomException(DateTime.Now, "This username already exists!", callStack.GetFileLineNumber(), System.Reflection.Assembly.GetExecutingAssembly().Location);

                }
            }

            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Surname : ");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter Password : ");
            string password = Console.ReadLine();

            Console.WriteLine("Enter City : ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter Phone : ");
            string phone = Console.ReadLine();

            Console.WriteLine("Enter Age : ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Employer or Worker : ");
            string choose = Console.ReadLine();

            if (choose.ToLower() == "employer")
            {
                Console.WriteLine("How much do you want to Add Vacancie?");
                int count = int.Parse(Console.ReadLine());
                List<Vacancie> vacancies = new List<Vacancie>();
                for (int i = 0; i < count; i++)
                {
                    Vacancie vacancie = GetVacancie();
                    vacancies.Add(vacancie);
                }
                Users.Add(new Employer
                {
                    Name = name,
                    Age = age,
                    City = city,
                    Phone = phone,
                    Password = password,
                    Surname = surname,
                    Username = username,
                    Vacancies = vacancies
                });
            }
            else if (choose.ToLower() == "worker")
            {
                Console.WriteLine("How much do you want to Add CV?");
                int count = int.Parse(Console.ReadLine());
                List<CV> cvs = new List<CV>();
                for (int i = 0; i < count; i++)
                {
                    CV cv = GetCV();
                    cvs.Add(cv);
                }
                Users.Add(new Worker
                {
                    Name = name,
                    Age = age,
                    City = city,
                    Phone = phone,
                    Password = password,
                    Surname = surname,
                    Username = username,
                    Cvs = cvs
                });
            }

        }

        public Vacancie GetVacancie()
        {
            Console.WriteLine("Company Name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Job Description : ");
            string description = Console.ReadLine();

            Console.WriteLine("Salary : ");
            double salary = double.Parse(Console.ReadLine());

            return new Vacancie
            {
                Description = description,
                Name = name,
                Salary = salary
            };

        }

        public CV GetCV()
        {
            Console.WriteLine("Speciality : ");
            string Speciality = Console.ReadLine();
            Console.WriteLine("Graduated University : ");
            string GraduatedUniversity = Console.ReadLine();
            Console.WriteLine("Univercity Score : ");
            double UnivercityScore = double.Parse(Console.ReadLine());
            Console.WriteLine("Have Honors Degree : ");
            string option = Console.ReadLine();
            bool HaveHonorsDegree = false;
            if (option.ToLower() == "no") HaveHonorsDegree = false;
            else if (option.ToLower() == "yes") HaveHonorsDegree = true;

            Console.WriteLine("How much skill do you have ? ");
            int skillcount = int.Parse(Console.ReadLine());
            List<string> Skills = new List<string>();
            for (int i = 0; i < skillcount; i++)
            {
                Console.WriteLine($"Enter {i + 1}. skill : ");
                string skill = Console.ReadLine();
                Skills.Add(skill);
            }

            List<string> ForeignLanguages = new List<string>();
            Console.WriteLine("How much foreign language do you know ? ");
            int flcount = int.Parse(Console.ReadLine());
            for (int i = 0; i < flcount; i++)
            {
                Console.WriteLine($"Enter {i + 1}. language : ");
                string language = Console.ReadLine();
                ForeignLanguages.Add(language);
            }

            return new CV
            {
                ForeignLanguages = ForeignLanguages,
                Skills = Skills,
                GraduatedUniversity = GraduatedUniversity,
                UnivercityScore = UnivercityScore,
                HaveHonorsDegree = HaveHonorsDegree,
                Speciality = Speciality,
            };
        }
        public Vacancie GetVacancieById(int id)
        {
            foreach (var user in Users)
            {
                if (user is Employer)
                {
                    Employer emp = (Employer)user;
                    foreach (var vacancie in emp.Vacancies)
                    {
                        if (vacancie.Id == id) return vacancie;
                    }
                }
            }
            return null;
        }
        public Worker GetWorkerById(int id)
        {
            foreach (var user in Users)
            {
                if (user is Worker)
                {
                    Worker worker = (Worker)user;
                    if (worker.Id == id) return worker;
                }
            }
            return null;
        }
        public Notification GetNotificationById(int id)
        {
            foreach (var user in Users)
            {
                if (user is Employer)
                {
                    Employer emp = (Employer)user;
                    foreach (var vacancie in emp.Vacancies)
                    {
                        foreach (var notification in vacancie.notifications)
                        {
                            if (notification.Id == id) return notification;
                        }
                    }
                }
            }
            return null;
        }
        public void ShowAllVacancies()
        {
            foreach (var user in Users)
            {
                if (user is Employer)
                {
                    Employer employer = (Employer)user;
                    employer.ShowVacancies();
                }
            }
        }

    }
}
