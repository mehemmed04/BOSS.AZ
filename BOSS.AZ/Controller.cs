using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseNamespace;
using UserNamespace;
using VacancieNamespace;
using CVnamespace;
namespace ControllerNamespace
{
    public class Controller
    {
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
                         Password ="18022004",
                          Phone="+994552554321",
                           Surname="Hesenov",
                            Username="hesenof_075",
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
                           Password = "memmed123",
                            Phone="+994555876382",
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
                           Password = "xanim123",
                            Phone="+994555642192",
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
            int select = 0;
            Console.WriteLine("SIGN IN [1]");
            Console.WriteLine("SIGN UP [2]");
            select=int.Parse(Console.ReadLine());
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
                if(CurrentUser is Worker)
                {
                    Worker CurrentWorker = (Worker)CurrentUser;
                    Console.WriteLine("Show All Vacancies ".PadRight(20)+"[1]");
                    Console.WriteLine("Apply To Vacancie ".PadRight(20)+"[2]");
                    Console.WriteLine("Add CV ".PadRight(20)+"[3]");

                    int select = int.Parse(Console.ReadLine());
                    if (select == 1)
                    {
                        database.ShowAllVacancies();
                    }
                    else if(select == 2)
                    {
                        database.ShowAllVacancies();
                        Console.WriteLine("Choose Vacancie with ID [-1 exit] : ");
                        int id = int.Parse(Console.ReadLine());
                        if (id == -1)
                        {
                            Start();
                        }
                        /*------------------------------------------------*/
                    }
                    else if (select == 3)
                    {
                        CV cV = database.GetCV();
                        CurrentWorker.Cvs.Add(cV);
                    }

                }
                else if(CurrentUser is Employer)
                {
                    Employer CurrentEmployer = (Employer)CurrentUser;

                }
                else
                {
                    Console.WriteLine("Oops... Something went wrong. Enter again");
                    Start();
                }

            }
            else
            {
                Console.WriteLine("Username or Password is incorrect. Try Again");
                Start();
            }


        }
        public static void SignUp()
        {
            database.AddUser();
        }
    }
}
