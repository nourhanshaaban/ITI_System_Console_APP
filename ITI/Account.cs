using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Security.Principal;
using System.Threading.Channels;


namespace ITI
{
    internal class Account
    {
        public Account()
        {
        }

        // public virtual void register(int Id  , string Name , int Phone , int Age , string Email , string Address , string UserName , string Password , string Rule ){
        //     // name , id , email , password ,,,,,,

        //     // Save Json()
        //     // Save All Inputed Data to the Json File

        // }


        public static User login(string email, string password, string rule, string path)
        {
            if (rule == "student")
            {
                string json = File.ReadAllText(@path);
                List<Student> des = JsonConvert.DeserializeObject<List<Student>>(json);
                //flag
                for (int i = 0; i < des.Count; i++)
                {
                    if (des[i].Email == email)
                    {
                        if (des[i].Password == password)
                        {
                            return des[i];
                        }
                    }
                }
                Console.WriteLine("Wrong Email Or Password. Please Try Again");
                return null;
            }
            else if (rule == "instructor")
            {
                string json = File.ReadAllText(@path);
                List<Instructor> des = JsonConvert.DeserializeObject<List<Instructor>>(json);
                for (int i = 0; i < des.Count; i++)
                {
                    if (des[i].Email == email)
                    {
                        if (des[i].Password == password)
                        {
                            return des[i];
                        }
                    }
                }
                Console.WriteLine("Wrong Email Or Password. Please Try Again");
                return null;
            }
            else if (rule == "admin")
            {
                string json = File.ReadAllText(@path);
                List<Admin> des = JsonConvert.DeserializeObject<List<Admin>>(json);
                for (int i = 0; i < des.Count; i++)
                {
                    if (des[i].Email == email)
                    {
                        if (des[i].Password == password)
                        {
                            return des[i];
                        }
                    }
                }
                Console.WriteLine("Wrong Email Or Password. Please Try Again");
                return null;
            }
            else
            {
                return null;
            }

        }
    
            // foreach( var std in des){
            //     Console.WriteLine(std.Name);

            // }
            
        public void register(object type, string rule, string path){
            // Console.WriteLine(path);
            // Console.WriteLine(rule);

            if(rule == "student"){
                // Save To Json
                string json = File.ReadAllText(@path);
                List<Student> des = JsonConvert.DeserializeObject<List<Student>>(json);


                Student studentData = (Student)type;
                des.Add(studentData);
                var StoreStudentData = JsonConvert.SerializeObject(des, Formatting.Indented);
                File.WriteAllText(@path, 
                    StoreStudentData);
                // Console.ReadKey();

            }else if(rule == "instructor"){
                // Save To Json
                string json = File.ReadAllText(@path);
                List<Instructor> des = JsonConvert.DeserializeObject<List<Instructor>>(json);


                Instructor instuctorData = (Instructor)type;
                des.Add(instuctorData);
                var StoreInstructorData = JsonConvert.SerializeObject(des, Formatting.Indented);
                File.WriteAllText(@path, 
                    StoreInstructorData);
                // Console.ReadKey();
            }else if(rule == "admin"){
                // Save To Json
                string json = File.ReadAllText(@path);
                List<Admin> des = JsonConvert.DeserializeObject<List<Admin>>(json);


                Admin adminData = (Admin)type;
                des.Add(adminData);
                var StoreAdminData = JsonConvert.SerializeObject(des, Formatting.Indented);
                File.WriteAllText(@path, 
                    StoreAdminData);
                // Console.ReadKey();
            }

        }
        
        // public void login(){
        //     // email , password
        //     // Check if user Data Is Right or wrong
        // }
    }
}
