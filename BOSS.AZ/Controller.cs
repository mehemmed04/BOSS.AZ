using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseNamespace;
using UserNamespace;
using VacancieNamespace;
using CVnamespace;
using NotificationNamespace;
using System.IO;
using CustomExceptionsNamespace;
using System.Diagnostics;

namespace ControllerNamespace
{
    public class Controller
    {
       public static StackFrame callStack = new StackFrame(1, true);
        public static User CurrentUser = null;
        public static Database database = new Database
        {
            Users = new List<User>
             {
                 new Worker
                 {
                      Name = "Remzi",
                       Age=18,
                        City="Naxhivan",
                         Password ="123456",
                          Phone="+994552554321",
                           Surname="Hesenov",
                            Username="hesenof_075",
                             Email="remzihesenoff075@gmail.com",
                            Cvs = new List<CV>
                            {
                                new CV
                                {
                                     ForeignLanguages= new List<string>
                                     {
                                         "English",
                                         "Russian",
                                     },
                                       UnivercityScore=456.6,
                                        GraduatedUniversity="Baku State University",
                                         HaveHonorsDegree = false,
                                          GitHubProfileLink=string.Empty,
                                           LİNKEDİNProfileLink=string.Empty,
                                            Skills = new List<string>
                                            {
                                                "C++",
                                                "Java"
                                            },
                                             Speciality="Programmer",
                                              WorkedCompanies=null
                                }
                            }
                 },
                 new Worker
                 {
                      Name = "Nihad",
                       Age=22,
                        City="Baku",
                         Password ="123456",
                          Phone="+994778526482",
                           Surname="Eminov",
                            Username="nihat_eminov",
                             Email="nihateminov00@gmail.com",

                            Cvs = new List<CV>
                            {
                                new CV
                                {
                                     ForeignLanguages= new List<string>
                                     {
                                         "English",
                                         "Russian",
                                         "Chienese"
                                     },
                                       UnivercityScore=427.3,
                                        GraduatedUniversity="Baku State University",
                                         HaveHonorsDegree = false,
                                          GitHubProfileLink=string.Empty,
                                           LİNKEDİNProfileLink=string.Empty,
                                            Skills = new List<string>
                                            {
                                                "C++",
                                                "Java",
                                                "C#",
                                                "HTML",
                                                "CSS"
                                            },
                                             Speciality="Programmer",
                                    WorkedCompanies =
                                    {
                                        new WorkTimes
                                        {
                                            CompanyName = "Adsiz Company",
                                             StartWorkTime = new DateTime(2018,2,18),
                                             EndWorkTime = new DateTime(2020,4,23)
                                        },
                                        new WorkTimes
                                        {
                                            CompanyName = "Adsiz Company",
                                             StartWorkTime = new DateTime(2020,4,28),
                                             EndWorkTime = new DateTime(2022,7,13)
                                        }
                                    }
                                }
                            }
                 },
                 new Employer
                 {
                      Age=34,
                       City="Baku",
                        Name="Elgun",
                         Username = "elgun_123",
                          Surname="Memmedzade",
                           Password = "123456",
                            Phone="+994555876382",
                             Email="elgunmemmedxade34@gmail.com",

                             Vacancies=new List<Vacancie>
                             {
                                 new Vacancie
                                 {
                                      Name="Adsiz Comapny",
                                       Salary=2500,
                                        Description="We need clever programmer"
                                 },
                                  new Vacancie
                                  {
                                       Name="Adsiz Comapny",
                                       Salary=1500,
                                        Description="We need clever designer"
                                  },
                                  new Vacancie
                                  {
                                       Name="Adsiz Comapny",
                                       Salary=400,
                                        Description="We need cleaner"
                                  }
                             }
                 },
                 new Employer
                 {
                      Age=44,
                       City="Baku",
                        Name="Xanim",
                         Username = "xanim_quluyeva",
                          Surname="Quluyeva",
                           Password = "123456",
                            Phone="+994555642192",
                             Email="xanimquluyeva989@gmail.com",

                             Vacancies=new List<Vacancie>
                             {
                                 new Vacancie
                                 {
                                      Name="Adsiz Comapny",
                                       Salary=2200,
                                        Description="We need clever Sales Manager"
                                 },
                                  new Vacancie
                                  {
                                       Name="Adsiz Comapny",
                                       Salary=500,
                                        Description="We need Operator"
                                  },
                                  new Vacancie
                                  {
                                       Name="Adsiz Comapny",
                                       Salary=800,
                                        Description="We need driver"
                                  }
                             }
                 }
             },
        };
        public static void Start()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    bool IsInt = false;
                    Console.WriteLine("SIGN IN [1]");
                    Console.WriteLine("SIGN UP [2]");
                    IsInt = int.TryParse(Console.ReadLine(), out int select);

                    if (!IsInt)
                    {
                        throw new CustomException(DateTime.Now, "Input Type Error. Entered charachter must be digit", callStack.GetFileLineNumber(), System.Reflection.Assembly.GetExecutingAssembly().Location);
                    }
                    if (select == 1)
                    {
                        SignIn();
                    }
                    else if (select == 2)
                    {
                        SignUp();
                    }
                    else
                    {

                    }
                    Console.WriteLine("Press any key to continue ...  ");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    File.AppendAllText("errors.log", ex.ToString());
                }
            }
        }
        public static void SignIn()
        {
            Console.WriteLine("Enter Username : ");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password : ");
            string password = Console.ReadLine();

            CurrentUser = database.GetUser(username, password);

            if (CurrentUser != null)
            {
                if (CurrentUser is Worker)
                {
                    WorkerPage();
                }
                else if (CurrentUser is Employer)
                {
                    EmployerPage();
                }
                else
                {
                    Console.WriteLine("Oops... Something went wrong. Enter again");
                    Start();
                    throw new CustomException(DateTime.Now, "Type Casting Error", callStack.GetFileLineNumber(), System.Reflection.Assembly.GetExecutingAssembly().Location);

                }
            }
            else
            {
                Console.WriteLine("Username or Password is incorrect. Try Again");
                Start();
                throw new CustomException(DateTime.Now, "Username or Password is incorrect", callStack.GetFileLineNumber(), System.Reflection.Assembly.GetExecutingAssembly().Location);
            }


        }
        public static void EmployerPage()
        {
            Employer CurrentEmployer = (Employer)CurrentUser;
            Console.WriteLine("Show Vacancies : ".PadRight(22) + "[1]");
            Console.WriteLine("Show Notifications : ".PadRight(22) + "[2]");
            Console.WriteLine("Add Vacancies : ".PadRight(22) + "[3]");
            Console.WriteLine("Exit : ".PadRight(22) + "[4]");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                CurrentEmployer.ShowVacancies();
                Console.WriteLine("Press any key to continue ...  ");
                Console.ReadKey();
                EmployerPage();
            }
            else if (select == 2)
            {
                foreach (var vacancie in CurrentEmployer.Vacancies)
                {
                    vacancie.ShowNotificatons();
                }
                Console.WriteLine("Select  Notification ID for reply [-1 exit]: ");
                int id = int.Parse(Console.ReadLine());
                if (id == -1)
                {
                    EmployerPage();
                }
                Notification notification = database.GetNotificationById(id);
                Worker worker = database.GetWorkerById(notification.WorkerID);
                Vacancie CurrentVacancie = null;
                string CompanyName = string.Empty;
                foreach (var vacancie in CurrentEmployer.Vacancies)
                {
                    foreach (var n in vacancie.notifications)
                    {
                        if (n.Id == notification.Id)
                        {
                            CompanyName = vacancie.Name;
                            CurrentVacancie = vacancie;
                            break;
                        }
                    }
                }

                if (worker != null)
                {
                    Console.WriteLine("accept [1]  or  reject [2]  : ");
                    select = int.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        worker.Notifications.Add($@"You are accepted to {CompanyName} at {DateTime.Now.ToString()}. Contact us!");
                        CurrentEmployer.Vacancies.Remove(CurrentVacancie);
                        worker.UnreadNotificationsCount++;
                    }
                    else if (select == 2)
                    {
                        worker.Notifications.Add($@"You are rejected by {CompanyName} at {DateTime.Now.ToString()}.");
                        worker.UnreadNotificationsCount++;

                    }
                    else
                    {

                    }
                }
                else
                {

                }

            }
            else if (select == 3)
            {
                Vacancie vacancie = database.GetVacancie();
                CurrentEmployer.Vacancies.Add(vacancie);
            }
            else if (select == 4)
            {
                Start();
            }
            else
            {
                throw new CustomException(DateTime.Now, "There is not such option. Choose 1-4!", callStack.GetFileLineNumber(), System.Reflection.Assembly.GetExecutingAssembly().Location);
            }

        }
        public static void WorkerPage()
        {
            Worker CurrentWorker = (Worker)CurrentUser;
            Console.WriteLine("Show All Vacancies ".PadRight(22) + "[1]");
            Console.WriteLine("Apply To Vacancie ".PadRight(22) + "[2]");
            Console.WriteLine("Add CV ".PadRight(22) + "[3]");
            Console.WriteLine($"Notifications({CurrentWorker.UnreadNotificationsCount}) ".PadRight(22) + "[4]");
            Console.WriteLine("Exit ".PadRight(22) + "[5]");

            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                database.ShowAllVacancies();
                Console.WriteLine("Press any key to continue ...  ");
                Console.ReadKey();
                WorkerPage();
            }
            else if (select == 2)
            {
                database.ShowAllVacancies();
                Console.WriteLine("Choose Vacancie with ID [-1 exit] : ");
                int id = int.Parse(Console.ReadLine());
                if (id == -1)
                {
                    WorkerPage();
                }
                Vacancie CurrentVacancie = database.GetVacancieById(id);
                if (CurrentVacancie != null)
                {

                    Notification notification = new Notification
                    {
                        WorkerEmail = CurrentUser.Email,
                        WorkerID = CurrentUser.Id,
                        WorkerName = CurrentUser.Name,
                    };
                    CurrentVacancie.notifications.Add(notification);
                    Console.WriteLine("Applied Vacancie successfully. Wait for Answer!");
                }
                else
                {
                    Console.WriteLine("There is not Vacancie with this ID!");
                    throw new CustomException(DateTime.Now, "There is not Vacancie with this ID!", callStack.GetFileLineNumber(), System.Reflection.Assembly.GetExecutingAssembly().Location);
                }
            }
            else if (select == 3)
            {
                CV cV = database.GetCV();
                CurrentWorker.Cvs.Add(cV);
            }
            else if (select == 4)
            {
                CurrentWorker.ShowAllNotifications();
                CurrentWorker.UnreadNotificationsCount = 0;
                Console.WriteLine("Press any key to continue ...  ");
                Console.ReadKey();
                WorkerPage();
            }
            else if (select == 5)
            {
                Start();
            }
            else
            {
                throw new CustomException(DateTime.Now, "There is not such option. Choose 1-4!", callStack.GetFileLineNumber(), System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
        }
        public static void SignUp()
        {
            database.AddUser();
        }
    }
}
