using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITI
{
    public class User 
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        
        public string UserName{get; set;}
        public string Password{get;set;}

        public string Rule{get;set;}
        public string Path{get;set;}
        public bool Logged{get;set;}
        public int TrackId {get;set;}
        Account ac1 = new Account();

        public User()
        {
           Logged = false;

        }

        public static  void WelcomUser(string rule)
        {
            string WelcomeStudent = @"


             __          __  _                             _____ _             _            _   
             \ \        / / | |                           / ____| |           | |          | |  
              \ \  /\  / /__| | ___ ___  _ __ ___   ___  | (___ | |_ _   _  __| | ___ _ __ | |_ 
               \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \  \___ \| __| | | |/ _` |/ _ \ '_ \| __|
                \  /\  /  __/ | (_| (_) | | | | | |  __/  ____) | |_| |_| | (_| |  __/ | | | |_ 
                 \/  \/ \___|_|\___\___/|_| |_| |_|\___| |_____/ \__|\__,_|\__,_|\___|_| |_|\__|



                                                                                               ";

            string WelcomeInstructor = @"


             __          __  _                            _____           _                   _             
             \ \        / / | |                          |_   _|         | |                 | |            
              \ \  /\  / /__| | ___ ___  _ __ ___   ___    | |  _ __  ___| |_ _ __ _   _  ___| |_ ___  _ __ 
               \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \   | | | '_ \/ __| __| '__| | | |/ __| __/ _ \| '__|
                \  /\  /  __/ | (_| (_) | | | | | |  __/  _| |_| | | \__ \ |_| |  | |_| | (__| || (_) | |   
                 \/  \/ \___|_|\___\___/|_| |_| |_|\___| |_____|_| |_|___/\__|_|   \__,_|\___|\__\___/|_|   
                                                                                                
                                                                                                

                                                                                               ";

            string WelcomeAdmin = @" 


             __          __  _                                        _           _       
             \ \        / / | |                              /\      | |         (_)      
              \ \  /\  / /__| | ___ ___  _ __ ___   ___     /  \   __| |_ __ ___  _ _ __  
               \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \   / /\ \ / _` | '_ ` _ \| | '_ \ 
                \  /\  /  __/ | (_| (_) | | | | | |  __/  / ____ \ (_| | | | | | | | | | |
                 \/  \/ \___|_|\___\___/|_| |_| |_|\___| /_/    \_\__,_|_| |_| |_|_|_| |_|
                                                                              
                                                                              
                                                                                               ";
            if (rule == "student")
            {
                Console.WriteLine(WelcomeStudent);
            }
            else if (rule == "instructor")
            {
                Console.WriteLine(WelcomeInstructor);
            }
            else if (rule == "admin")
            {
                Console.WriteLine(WelcomeAdmin);
            }
        }

        public virtual void  WelcomeScreen()
        {

            //Console.WriteLine("Welcome To Student Area");
            WelcomUser(Rule);
            Console.WriteLine("[ 1 ] Login");
            Console.WriteLine("[ 2 ] Register");
            Console.Write("\n>>  ");
        }

        public void login(object type){

            User ResivedData = null;
            // loop
            while(ResivedData == null)
            {
                GetLoginDataFromUser();
                ResivedData = Account.login(Email , Password , Rule , Path);
            }
            // save logged userdata
            SaveLoggedData(ResivedData);
            //printData();
        }

        public void GetLoginDataFromUser(){
           string logIn = @"

                                          _                 _       
                                         | |               (_)      
                                         | |     ___   __ _ _ _ __  
                                         | |    / _ \ / _` | | '_ \ 
                                         | |___| (_) | (_| | | | | |
                                         |______\___/ \__, |_|_| |_|
                                                       __/ |        
                                                      |___/         

";
            Console.WriteLine(logIn);

            Console.WriteLine("* Enter email");
            Console.Write(">>  ");
            Email = Console.ReadLine();

            Console.WriteLine("\n* Enter Password");
            Console.Write(">>  ");
            Password = Console.ReadLine();
        }

        private void SaveLoggedData(User ResivedData)
        {
            Id = ResivedData.Id;
            Name = ResivedData.Name;
            Email = ResivedData.Email;
            Phone = ResivedData.Phone;
            Address = ResivedData.Address;
            Age = ResivedData.Age;
            UserName = ResivedData.UserName;
            Password = ResivedData.Password;
            Rule = ResivedData.Rule;
            Path =ResivedData.Path;
            Logged = true;
            TrackId = ResivedData.TrackId;

        }

         public void register(object type){
            //get Data From User
            GetDataFromUser();
            // Run Register Function 
            ac1.register(type , Rule , Path);
            // Save Data to path
            
           
         }

        public void GetDataFromUser(){
            string register = @"
                                      _____            _     _            
                                     |  __ \          (_)   | |           
                                     | |__) |___  __ _ _ ___| |_ ___ _ __ 
                                     |  _  // _ \/ _` | / __| __/ _ \ '__|
                                     | | \ \  __/ (_| | \__ \ ||  __/ |   
                                     |_|  \_\___|\__, |_|___/\__\___|_|   
                                                  __/ |                   
                                                 |___/                    

";
            Console.WriteLine(register);

            Console.WriteLine("* Enter id");
            Console.Write(">>  ");
            Id = int.Parse(Console.ReadLine());

            Console.WriteLine("\n* Enter name");
            Console.Write(">>  ");
            Name = Console.ReadLine();

            Console.WriteLine("\n* Enter phone");
            Console.Write(">>  ");
            Phone = int.Parse(Console.ReadLine());

            Console.WriteLine("\n* Enter Age");
            Console.Write(">>  ");
            Age = int.Parse(Console.ReadLine());

            Console.WriteLine("\n* Enter email");
            Console.Write(">>  ");
            Email = Console.ReadLine();

            Console.WriteLine("\n* Enter Address");
            Console.Write(">>  ");
            Address = Console.ReadLine();

            Console.WriteLine("\n* Enter username");
            Console.Write(">>  ");
            UserName = Console.ReadLine();

            Console.WriteLine("\n* Enter password");
            Console.Write(">>  ");
            Password = Console.ReadLine();
        }
        
        
        public void printData(){
            Console.WriteLine("-------------------------------");
            Console.Write("ID = " + Id + " \t ");
            Console.Write("Name = " + Name + " \t" );
            Console.Write("Email  = " + Email  + " \t");
            Console.Write("Phone = " + Phone + " \n");
            Console.Write("Address = " + Address + " \t");
            Console.Write("Age = " + Age + "Years \t");
            Console.Write("Username = " + UserName + " \t");
            Console.Write("Password = " + Password + " \n");
            Console.Write("Role = " + Rule + " \t");
            // Console.Write(Path);
            Console.Write("Login =" + Logged + " \n");

        }


        // public  virtual void register(string Rule ){
        //     Console.WriteLine("Enter id");
        //     Id = int.Parse(Console.ReadLine());

        //     Console.WriteLine("Enter name");
        //     Name = Console.ReadLine();

        //     Console.WriteLine("Enter phone");
        //     Phone = int.Parse(Console.ReadLine());

        //     Console.WriteLine("Enter Age");
        //     Age = int.Parse(Console.ReadLine());

        //     Console.WriteLine("Enter email");
        //     Email = Console.ReadLine();

        //     Console.WriteLine("Enter Address");
        //     Address = Console.ReadLine();

        //     Console.WriteLine("Enter username");
        //     UserName = Console.ReadLine();

        //     Console.WriteLine("Enter password");
        //     Password = Console.ReadLine();
           

        // }
    }
}
