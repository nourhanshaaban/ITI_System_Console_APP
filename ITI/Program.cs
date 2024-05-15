using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Security.Principal;
using System.Threading.Channels;

namespace ITI
{
    internal class Program
    {

       
        public static void writeLogo()
        {
           string logo = @"
                                                    ██╗████████╗██╗
                                                    ██║╚══██╔══╝██║
                                                    ██║   ██║   ██║
                                                    ██║   ██║   ██║
                                                    ██║   ██║   ██║
                                                    ╚═╝   ╚═╝   ╚═╝
";
            Console.WriteLine(logo);
        }
        static void Main(string[] args)
        {
            // string json = File.ReadAllText(@"Student.json");
            // List<Student> des = JsonConvert.DeserializeObject<List<Student>>(json);


            // Student studentData = new Student(Cources, Id, Name, Email, Phone,
            //                                  Address, UserName, Password, Rule, Age);
            // des.Add(studentData);
            // var StoreStudentData = JsonConvert.SerializeObject(des, Formatting.Indented);
            // File.WriteAllText(@"C:\Users\DELL\source\repos\ITI\ITI\Student.json", 
            //     StoreStudentData);
            // Console.ReadKey();
            Console.Clear();
            writeLogo();
            //Console.WindowWidth = 120;
            Console.WriteLine("Welcome to ITI Project");
            Console.WriteLine("Please Choose Your Role");
            Console.WriteLine("[ 1 ] Student");
            Console.WriteLine("[ 2 ] Instructor");
            Console.WriteLine("[ 3 ] Admin");
            Console.Write("\n>>  ");
            // Account ac2 = new Account();
            // ac2.login();

            //int choice = int.Parse(Console.ReadLine()); 
            int choice;
            for (int i = 0;i<3; i++)
            {
                choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Student s1 = new Student();
                    s1.WelcomeScreen();
                }else if(choice == 2)
                {
                    Instructor Ins1 = new Instructor();
                    Ins1.WelcomeScreen();
                }
                else if (choice == 3)
                {
                    Admin admin = new Admin();
                    admin.WelcomeScreen();
                }
                else
                {
                    if(i < 2)
                    {
                        Console.WriteLine("Not Valid This Option ! pleace choice again");
                    }
                    else
                    {
                        Console.WriteLine("You've run out of attempts! \nExit ....");
                        Thread.Sleep(500);
                    }
                }
            }
            //switch(choice){
            //    case 1:
                    
            //        Student s1 = new Student();
            //        s1.WelcomeScreen();

                    
            //    break;
            //    case 2:


            //    break;
            //    case 3:

            //    break;
            //    default:
            //        Console.WriteLine("Not Valid This Option !");
            //        Thread.Sleep(1500);
            //    continue;
            //}
            

            
        }
    }
}
