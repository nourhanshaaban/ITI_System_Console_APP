namespace ITI
{
    public class Questions
    {
        
        public int QuestionId{get;set;}
        public string QuestionDesc{get;set;}
        public string [,] QuestionChoices{get;set;}
        public int QuestionAwnser{get;set;}


        public Questions addQuestion(int questionId){

        
            QuestionChoices = new string [5,2];

            QuestionId = questionId;

            Console.WriteLine("Please Enter Question Descreption");
            QuestionDesc = Console.ReadLine();

            // Console.WriteLine("Please Enter Question Choices");
            for(int i = 0 ; i < 5 ; i++){
                QuestionChoices[i,0] = Convert.ToString(i);
                Console.WriteLine("Please Enter Awnser Number " + (i+1));
                QuestionChoices[i,1] = Console.ReadLine();

            }

            Console.WriteLine("Please Enter Question Right Awnser");
            QuestionAwnser = int.Parse(Console.ReadLine()) -1 ;

            return this;
        }


    }
}