namespace ITI
{
    public class Degrees
    {
        int StudentID {get;set;}
        int Degree{get;set;}

        public void calcDegree(int stdId){
            //STDID Override
            StudentID = stdId;
            Degree = 80;

        }



    }

    
}