using Newtonsoft.Json;

namespace ITI
{
    public class Instructor : User
    {
        //List<Courses> courses;

         

        public Instructor()
        {

            base.Rule = "instructor";
            base.Path = "D:\\ITI_Test_Rep (1)\\ITI\\Instructor.json";
            

        }

        public void WelcomeScreen()
        {

            base.WelcomeScreen();
            int action = int.Parse(Console.ReadLine());
            if (action == 1)
            {
                login(this);
                InstructorDashboard();
            }
            else if (action == 2)
            {
                register(this);
                InstructorDashboard(); 
            }
        }

        public void InstructorDashboard()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Welcome Mr " + UserName);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[ 1 ] View Your Courses");
            // Console.WriteLine("[ 2 ] Set Student Degree");
            Console.WriteLine("[ 2 ] View Exams");
            Console.WriteLine("[ 3 ] Set Exam");

            Console.Write("\n>>  ");
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    ViewCourses();
                    break;
                case 2:
                    viewExams();
                    break;
                case 3:
                    SetExam();
                    break;

            }
            InstructorDashboard();
        }

        public void ViewCourses()
        {
            Courses c1 = new Courses();
            List<Courses> trackCourses = c1.showInstructorCourses(base.Id);

            for(int i = 0 ; i < trackCourses.Count ; i++){
                Console.WriteLine("-----------------");
                Console.WriteLine("Course ID " + trackCourses[i].Id);
                Console.WriteLine("Course Name " + trackCourses[i].Name);
            }

        }


        public void SetDegree()
        {

        }

        public void viewExams()//viewExams
        {
//             var SetExam = @"

//                                    _____      _     ______                     
//                                   / ____|    | |   |  ____|                    
//                                  | (___   ___| |_  | |__  __  ____ _ _ __ ___  
//                                   \___ \ / _ \ __| |  __| \ \/ / _` | '_ ` _ \ 
//                                   ____) |  __/ |_  | |____ >  < (_| | | | | | |
//                                  |_____/ \___|\__| |______/_/\_\__,_|_| |_| |_|
                                               
                                                                               
// ";
            // Console.WriteLine("Please Enter the number of Quetions : ");
            // Console.Write("\n>> ");
            // int number = int.Parse(Console.ReadLine());
            // string[] questions = new string[number];

            // for (int i = 0; i < number; i++)
            // {
            //     Console.WriteLine("* Quetions "+ (1+i) + " : ");
            //     Console.Write("\n>> ");
            //     questions[i] = Console.ReadLine();
            //     Console.WriteLine("\n**************************");
            // }

            //pick track
            
            int trackId = base.TrackId;
            //pick course
            Courses c1 = new Courses();
            List<Courses> returnedCourses = c1.showInstructorCourses(base.Id);
            foreach(Courses Course in returnedCourses){
                Console.WriteLine("---------------------------");
                Console.WriteLine("Course ID =" + Course.Id);
                Console.WriteLine("Course Name =" + Course.Name);
                Console.WriteLine("------------");

            }
            Console.WriteLine("------------");
            Console.WriteLine("Enter Course ID");
            int courseId = int.Parse(Console.ReadLine());
            //Show All Exams
            Exam ex1 = new Exam();
            List<Exam> ReturnedExams = ex1.showAllExams(trackId);
             for(int i = 0 ; i < ReturnedExams.Count ; i++){
                Console.WriteLine("-----------------");
                Console.Write("["+(i+1)+"]" );
                Console.WriteLine("Exam ID " + ReturnedExams[i].ExamId);
                Console.WriteLine("Course ID " + ReturnedExams[i].CourseId);
            }
            // pick ID
            Console.WriteLine("----------------------");
            Console.WriteLine("Enter Exam ID");
            int examId = int.Parse(Console.ReadLine());
            ex1.printExam(ReturnedExams[examId-1]);
            


            

        }


        public void SetExam(){


            Track t1 = new Track();
            t1.PrintAllTracks();
            Console.WriteLine("Enter Track ID");
            int trackId = int.Parse(Console.ReadLine());
            //pick course
            Courses c1 = new Courses();
            List<Courses> returnedCourses = c1.showInstructorCourses(base.Id);
            foreach(Courses Course in returnedCourses){
                Console.WriteLine(Course.Id);
                Console.WriteLine(Course.Name);
                Console.WriteLine("------------");

            }
            Console.WriteLine("------------");
            Console.WriteLine("Enter Course ID");
            int courseId = int.Parse(Console.ReadLine());
            // pick ID
            Console.WriteLine("Enter Exam ID");
            int examId = int.Parse(Console.ReadLine());

            // Add New Exam
            Exam ex1 = new Exam();
            ex1.addNewExam(trackId , courseId , examId);

        }




        public void ShowAllInstructor()
        {
            string json = File.ReadAllText(base.@Path);
            List<Instructor> allInstructor = JsonConvert.DeserializeObject<List<Instructor>>(json);
            foreach (Instructor instructor in allInstructor) 
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Instructor ID : " + instructor.Id);
                Console.WriteLine("Instructor Name : " + instructor.Name);
            }
        }

        public void EditInstructor()
        {
            Console.WriteLine("Please Enter Instructor ID");
            int INSTRId = int.Parse(Console.ReadLine());

            string json = File.ReadAllText(base.@Path);
            List<Instructor> allInstructor = JsonConvert.DeserializeObject<List<Instructor>>(json);
            int position = 0;
            for(int i = 0 ; i < allInstructor.Count ; i++){
                if(allInstructor[i].Id == INSTRId){
                    Console.WriteLine("Track ID = " + allInstructor[i].TrackId);
                    Console.WriteLine("Student ID = " + allInstructor[i].Id);
                    Console.WriteLine("Student Email = " + allInstructor[i].Email);
                    Console.WriteLine("Student Phone = " + allInstructor[i].Phone);
                    Console.WriteLine("Student Address = " + allInstructor[i].Address);
                    Console.WriteLine("Student Age = " + allInstructor[i].Age);
                    Console.WriteLine("Student UserName = " + allInstructor[i].UserName);
                    Console.WriteLine("Student Password = " + allInstructor[i].Password);
                    position = i;
                    break; 
                }
            }

            Console.WriteLine("------------------");
            Console.WriteLine("[ 1 ] Edit Track ID");
            Console.WriteLine("[ 2 ] Edit Instructor ID");
            Console.WriteLine("[ 3 ] Edit Instructor Email ");
            Console.WriteLine("[ 4 ] Edit Instructor Phone");
            Console.WriteLine("[ 5 ] Edit Instructor Address");
            Console.WriteLine("[ 6 ] Edit Instructor Age");
            Console.WriteLine("[ 7 ] Edit Instructor UserName");
            Console.WriteLine("[ 8 ] Edit Instructor Password");
        

            Console.WriteLine("What Do You Want To Edit");
            int action = int.Parse(Console.ReadLine());


             switch (action)
            {
                case 1:
                    Track t1 = new Track();
                    t1.PrintAllTracks();
                    Console.WriteLine("Please Enter New Track ID");
                    allInstructor[position].TrackId = int.Parse(Console.ReadLine());
                    //c1.addNewCourse(trackid);
                    break;
                case 2:
                    Console.WriteLine("Please Enter New Student ID");
                    allInstructor[position].Id = int.Parse(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Please Enter New Student Email");
                    allInstructor[position].Email = Console.ReadLine();
                    break;

                case 4:
                    Console.WriteLine("Please Enter New Student Phone");
                    allInstructor[position].Phone = int.Parse(Console.ReadLine());
                    break;

                case 5:
                    Console.WriteLine("Please Enter New Student Address");
                    allInstructor[position].Address = Console.ReadLine();
                    break;
                case 6:
                    Console.WriteLine("Please Enter New Student Age");
                    allInstructor[position].Age = int.Parse(Console.ReadLine());
                    break;

                case 7:
                    Console.WriteLine("Please Enter New Student Username");
                    allInstructor[position].UserName = Console.ReadLine();
                    break;
                case 8:
                    Console.WriteLine("Please Enter New Student Age");
                    allInstructor[position].Password = Console.ReadLine();
                    break;

            }

            var StoreStudentData = JsonConvert.SerializeObject(allInstructor, Formatting.Indented);
                File.WriteAllText(base.@Path, 
                    StoreStudentData);
        }

        public void DeleteInstructor()
        {
            Console.WriteLine("Please Enter Student ID");
            int INSTRId = int.Parse(Console.ReadLine());

            string json = File.ReadAllText(base.@Path);
            List<Instructor> allInstructor = JsonConvert.DeserializeObject<List<Instructor>>(json);
            int position = 0;
            for(int i = 0 ; i < allInstructor.Count ; i++){
                if(allInstructor[i].Id == INSTRId){
                    position = i;
                    break; 
                }
            }

            allInstructor.Remove(allInstructor[position]);
            var StoreStudentData = JsonConvert.SerializeObject(allInstructor, Formatting.Indented);
                File.WriteAllText(base.@Path, 
                    StoreStudentData);




        }



    }
}