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
using FileHelperNamespace;
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
                                      Name="EBA’s Comapny",
                                       Salary=2500,
                                        Description=@"Higher education in Economics, Finance and Business Administration
At least 1-3 years of experience in Finance and Accounting
Above average Excel skills
Good knowledge of English, and Azerbaijani languages
Financial Accounting (F3) certification is advantage
Good analytical skills
Good interpersonal communication skills
Understanding of financial analysis"
                                 },
                                  new Vacancie
                                  {
                                       Name="EBA’s Comapny",
                                       Salary=1500,
                                        Description=@"High degree of self-motivation and strong career aspirations
University diploma (Bachelor and Master)
Advanced written and spoken Azerbaijani, English; Russian is advantage
Ability to thrive in an environment of pressing deadlines and dynamic conditions and work under pressure
Excellent knowledge of MS Office programs "
                                  },
                                  new Vacancie
                                  {
                                       Name="Atlas Ventures Comapny",
                                       Salary=400,
                                        Description=@"Previous experience within Public Relations required
Computer literate in Microsoft Window applications required
University/College degree in a related discipline preferred
Excellent verbal and written communication skills in Azerbaijani and English, and Russian, preferably
Strong interpersonal and problem solving abilities
Highly responsible & reliable
Ability to focus attention on guest needs, remaining calm and courteous at all"
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
                                      Name="Superscapes Comapny",
                                       Salary=2200,
                                        Description=@"4+ years of work experience in copywriting
Excellent knowledge of Azerbaijani and Russian languages
Familiar with all proverbs, phraseologies, aphorisms, idioms
Good knowledge of English is big plus."
                                 },
                                  new Vacancie
                                  {
                                       Name="Thump Coffee Comapny",
                                       Salary=500,
                                        Description=@"Knowledge and expertise in Azerbaijan Labor Regulations (essential).
Strong knowledge/expertise of HR record keeping (essential).
Knowledge and expertise in Payroll Processes and rules (essential)."
                                  },
                                  new Vacancie
                                  {
                                       Name="Superscapes Comapny",
                                       Salary=800,
                                        Description=@"Prepare and develop marketing strategies in accordance with the company's goals;
Manage all marketing activities related to the company and marketing department in general;
        Monitor the effectiveness of marketing communications and preparing appropriate reports;
        Market research and client attraction; 
Promote the venue as a brand;
        Anticipate new opportunities to maintain relationship with important clients;
Establish the company strategy to achieve set sales targets;"
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
                    FileHelper.WriteToJson(database);
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
                    string CURRENT_PATH = Directory.GetCurrentDirectory();
                    DirectoryInfo dir = new DirectoryInfo(CURRENT_PATH);
                    CURRENT_PATH = dir.Parent.Parent.FullName;
                    File.AppendAllText(CURRENT_PATH + "/errors.log", ex.ToString());
                    Console.WriteLine(ex);
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
                FileHelper.WriteToJson(database);
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
                FileHelper.WriteToJson(database);
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
