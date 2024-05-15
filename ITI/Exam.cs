using Newtonsoft.Json;

namespace ITI
{
    public class Exam
    {
        public int TrackId { get; set; }
        public int CourseId { get; set; }
        public int ExamId { get; set; }
        public List<Questions> Questions {get;set;}

        Questions q1 = new Questions();

        public Exam(){
            Questions = new List<Questions>();
        }


        public List<Exam> showAllExams(int trackid){
            // Read Json
                string json = File.ReadAllText(@"Exam.json");
                List<Exam> allExams = JsonConvert.DeserializeObject<List<Exam>>(json);
                List<Exam> TrackExams = new  List<Exam>();
                for(int i = 0 ; i < allExams.Count ; i++){
                   if(allExams[i].TrackId == trackid){
                   TrackExams.Add(allExams[i]);
                   }
                }
                return TrackExams;
        }

        public Exam showExam(int examid){
            string json = File.ReadAllText(@"Exam.json");
                List<Exam> allExams = JsonConvert.DeserializeObject<List<Exam>>(json);
                Exam ReturnedExam = null;
                for(int i = 0 ; i < allExams.Count ; i++){
                   if(allExams[i].ExamId == examid){
                    return ReturnedExam = allExams[i];
                   }
                }
                return null;

        }

        public List<Exam> showExamByCourseId(int courseId){

            string json = File.ReadAllText(@"Exam.json");
                List<Exam> allExams = JsonConvert.DeserializeObject<List<Exam>>(json);
                List<Exam> ReturnedExam = null;
                for(int i = 0 ; i < allExams.Count ; i++){
                   if(allExams[i].CourseId == courseId){
                     ReturnedExam.Add(allExams[i]);
                   }
                }
                return ReturnedExam;

        }
        public void printExam(Exam inputexam){
            Exam InputExam = inputexam;
                Console.WriteLine("Exam ID: " + InputExam.ExamId);
                    Console.WriteLine("Course ID: " + InputExam.CourseId);
                    Console.WriteLine("Track ID: " + InputExam.TrackId);
                    for(int j = 0 ; j<InputExam.Questions.Count ; j++){
                        Console.WriteLine("Question: " + InputExam.Questions[j].QuestionId);
                        Console.WriteLine("Question Title : " +InputExam.Questions[j].QuestionDesc);
                        Console.WriteLine("----------------------------");
                        for(int k = 0 ; k < 5 ; k++){
                            Console.Write("(" + (1+k) + ") ");
                            Console.Write(InputExam.Questions[j].QuestionChoices[k,1]);
                            Console.WriteLine("     ");

                        }
                       Console.WriteLine("----------------------------");

                    }

        }


        public void addNewExam(int trackId , int courseId , int examId){
            

                 //OverRidde Object 
                TrackId = trackId;
                CourseId = courseId;
                ExamId = examId;


                //Add Questions To List Of Questions

                Console.WriteLine("Please Enter the number of Quetions : "); // 5
                Console.Write("\n>> ");
                int number = int.Parse(Console.ReadLine()); //5
                
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("* Quetions "+ (1+i) + " : ");
                    Console.Write("\n>> ");
                    Questions CurrentQuestion = q1.addQuestion(i);
                   
                    Questions.Add(CurrentQuestion);
                    Console.WriteLine("\n**************************");
                }

                

                // Read Json
                string json = File.ReadAllText(@"Exam.json");
                List<Exam> allExam = JsonConvert.DeserializeObject<List<Exam>>(json);


                Exam NewExam = this;
                allExam.Add(NewExam);
                var StoreStudentData = JsonConvert.SerializeObject(allExam, Formatting.Indented);
                File.WriteAllText(@"Exam.json", 
                    StoreStudentData);
               



        }

        public void solveExam(int examid){
            int[] awnsers = new int[1];
            Exam returnedExam = showExam(examid);
            printExam(returnedExam);

            // awnsers[]
           

        }
        public void viewAllExams(){

        }
        
    }

    
}