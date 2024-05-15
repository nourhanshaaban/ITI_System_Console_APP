using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ITI
{
    public class Student : User 
    {

        // public string[] Cources { get; set; }
        public Student(){
          
            base.Rule = "student";
            base.Path = "D:\\ITI_Test_Rep (1)\\ITI\\Student.json";

            // base.CreateNewAccount();
            // base.printData();
            
        }

       public override void  WelcomeScreen(){
            base.WelcomeScreen();
            int action = int.Parse(Console.ReadLine());
            if(action == 1 ){
                login(this);
                StudentDashboard();
            }else if (action == 2){
                register(this);
            }
       }
    
        public void StudentDashboard(){
            Console.WriteLine("Welcome Mr " + UserName);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[ 1 ] View Your Profile");
            Console.WriteLine("[ 2 ] View Your Courses");
            Console.WriteLine("[ 3 ] Enter Your Exams");
            int action = int.Parse(Console.ReadLine());
            Courses c1 = new Courses();

            switch(action){
                case 1 :
                    printData();
                    
                break;
                case 2 :
                List<Courses> returnedCourses = c1.showCourses(base.TrackId);
                for(int i = 0 ; i < returnedCourses.Count ; i++){
                Console.WriteLine("-----------------");
                Console.WriteLine("Course ID " + returnedCourses[i].Id);
                Console.WriteLine("Course Name " + returnedCourses[i].Name);
                    }
                
                break;

                case 3:
                Exam ex1 = new Exam();
                List<Exam> returnedExams  = ex1.showAllExams(base.TrackId);
                for(int i = 0 ; i < returnedExams.Count ; i++){
                Console.WriteLine("-----------------");
                Console.WriteLine("Course ID " + returnedExams[i].CourseId);
                //Get Course By ID
                Courses returned = c1.showCourseById(returnedExams[i].CourseId);    
                Console.WriteLine("Course Name : " + returned.Name);
                Console.WriteLine("Exam ID " + returnedExams[i].ExamId);
                    }

                Console.WriteLine("Enter ID Of Exam That You Want To Solve");
                int examid = int.Parse(Console.ReadLine());
                ex1.solveExam(examid);
                break;

            }

            StudentDashboard();

           
           
        }

        public void ShowAllStudents()
        {
            string json = File.ReadAllText(base.@Path);
            List<Student> allStudents = JsonConvert.DeserializeObject<List<Student>>(json);
            foreach (Student student in allStudents) 
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Student ID : " + student.Id);
                Console.WriteLine("Student Name : " + student.Name);
            }
        }

        public void EditStudent()
        {
            Console.WriteLine("Please Enter Student ID");
            int STDId = int.Parse(Console.ReadLine());

            string json = File.ReadAllText(base.@Path);
            List<Student> allStudents = JsonConvert.DeserializeObject<List<Student>>(json);
            int position = 0;
            for(int i = 0 ; i < allStudents.Count ; i++){
                if(allStudents[i].Id == STDId){
                    Console.WriteLine("Track ID = " + allStudents[i].TrackId);
                    Console.WriteLine("Student ID = " + allStudents[i].Id);
                    Console.WriteLine("Student Email = " + allStudents[i].Email);
                    Console.WriteLine("Student Phone = " + allStudents[i].Phone);
                    Console.WriteLine("Student Address = " + allStudents[i].Address);
                    Console.WriteLine("Student Age = " + allStudents[i].Age);
                    Console.WriteLine("Student UserName = " + allStudents[i].UserName);
                    Console.WriteLine("Student Password = " + allStudents[i].Password);
                    position = i;
                    break; 
                }
            }

            Console.WriteLine("------------------");
            Console.WriteLine("[ 1 ] Edit Track ID");
            Console.WriteLine("[ 2 ] Edit Student ID");
            Console.WriteLine("[ 3 ] Edit Student Email ");
            Console.WriteLine("[ 4 ] Edit Student Phone");
            Console.WriteLine("[ 5 ] Edit Student Address");
            Console.WriteLine("[ 6 ] Edit Student Age");
            Console.WriteLine("[ 7 ] Edit Student UserName");
            Console.WriteLine("[ 8 ] Edit Student Password");
        

            Console.WriteLine("What Do You Want To Edit");
            int action = int.Parse(Console.ReadLine());


             switch (action)
            {
                case 1:
                    Track t1 = new Track();
                    t1.PrintAllTracks();
                    Console.WriteLine("Please Enter New Track ID");
                    allStudents[position].TrackId = int.Parse(Console.ReadLine());
                    //c1.addNewCourse(trackid);
                    break;
                case 2:
                    Console.WriteLine("Please Enter New Student ID");
                    allStudents[position].Id = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Please Enter New Student Email");
                    allStudents[position].Email = Console.ReadLine();
                    break;

                case 4:
                    Console.WriteLine("Please Enter New Student Phone");
                    allStudents[position].Phone = int.Parse(Console.ReadLine());
                    break;

                case 5:
                    Console.WriteLine("Please Enter New Student Address");
                    allStudents[position].Address = Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine("Please Enter New Student Age");
                    allStudents[position].Age = int.Parse(Console.ReadLine());
                    break;

                case 7:
                    Console.WriteLine("Please Enter New Student Username");
                    allStudents[position].UserName = Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("Please Enter New Student Age");
                    allStudents[position].Password = Console.ReadLine();
                    break;

            }

            var StoreStudentData = JsonConvert.SerializeObject(allStudents, Formatting.Indented);
                File.WriteAllText(base.@Path, 
                    StoreStudentData);
        }

        public void DeleteStudent()
        {
            Console.WriteLine("Please Enter Student ID");
            int STDId = int.Parse(Console.ReadLine());

            string json = File.ReadAllText(base.@Path);
            List<Student> allStudents = JsonConvert.DeserializeObject<List<Student>>(json);
            int position = 0;
            for(int i = 0 ; i < allStudents.Count ; i++){
                if(allStudents[i].Id == STDId){
                    position = i;
                    break; 
                }
            }

            allStudents.Remove(allStudents[position]);
            var StoreStudentData = JsonConvert.SerializeObject(allStudents, Formatting.Indented);
                File.WriteAllText(base.@Path, 
                    StoreStudentData);




        }

    }
}
