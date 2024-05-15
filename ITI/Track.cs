using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace ITI
{
    public class Track
    {
        public int Id{get;set;}
        public string Name{get;set;}

        Courses c1 = new Courses();
        
        //public List<Courses> Coursess  = new List<Courses>();
        
        //Admin ad1 = new Admin();

        public void addNewTrack()
        {
                //Get Data From User
                //OverRidde Object 
                Console.WriteLine("Please Enter Track ID");
                Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter Track Name");
                Name = Console.ReadLine();
            
                // Save To Json
                string json = File.ReadAllText(@"Track.json");
                List<Track> allTracks = JsonConvert.DeserializeObject<List<Track>>(json);


                Track NewTrack = this;
                allTracks.Add(NewTrack);
                var StoreStudentData = JsonConvert.SerializeObject(allTracks, Formatting.Indented);
                File.WriteAllText(@"Track.json", 
                    StoreStudentData);

                //Back Message
                Console.WriteLine("----------------------");
                Console.WriteLine("**** Track Has Been Added ****");
                Console.WriteLine("----------------------");

                Admin ad1 = new Admin();
                ad1.AdminDashboard();
                
                

        }

        public void GetDataFromAdmin(){
            Console.WriteLine("Please Enter Track ID");
            Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter Track Name");
            Name = Console.ReadLine();

        }

        public void ViewTrack(){
            PrintAllTracks();
            Console.WriteLine("Please Enter Track ID");
            int trackid = int.Parse(Console.ReadLine());



            List<Courses> trackCourses = c1.showCourses(trackid);

            for(int i = 0 ; i < trackCourses.Count ; i++){
                Console.WriteLine("-----------------");
                Console.WriteLine("Course ID " + trackCourses[i].Id);
                Console.WriteLine("Course Name " + trackCourses[i].Name);
            }

            Console.WriteLine("---------------------------");
            Console.WriteLine("[ 1 ] Add Course");
            Console.WriteLine("[ 2 ] Add Courses");
            Console.WriteLine("[ 3 ] Edit Course");
            Console.WriteLine("[ 4 ] Delete Course");

            Console.Write("\n>>  ");
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    c1.addNewCourse(trackid);
                    break;
                case 2:
                    c1.addNewCourses(trackid);
                    break;
                case 3:
                    c1.EditCourse();
                    break;
                case 4:
                    c1.DeleteCourse();
                    break;

            }


        }



        public void PrintAllTracks(){

        string json = File.ReadAllText(@"Track.json");
        List<Track> allTracks = JsonConvert.DeserializeObject<List<Track>>(json);
        foreach (Track track in allTracks) 
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Track ID : " + track.Id);
            Console.WriteLine("Track Name : " + track.Name);
        }

        // PublicKey void showCourses(){

        // }



        }


        public void EditTrack()
        {
            PrintAllTracks();

            Console.WriteLine("\n* Please Enter Track ID to Edit Name");
            Console.Write("\n>> ");
            int TrackId = int.Parse(Console.ReadLine());

            string json = File.ReadAllText(@"Track.json");
            List<Track> allTracks = JsonConvert.DeserializeObject<List<Track>>(json);
            
            for (int i = 0; i < allTracks.Count; i++)
            {
                if (allTracks[i].Id == TrackId)
                {
                    Console.WriteLine("\n* Please Enter New Track Name :");
                    allTracks[i].Name = Console.ReadLine();
                    
                    break;
                }
            }
            var StoreTrackData = JsonConvert.SerializeObject(allTracks, Formatting.Indented);
            File.WriteAllText(@"Track.json",
                StoreTrackData);


                Console.WriteLine("----------------------");
                Console.WriteLine("**** Track Has Been Edited ****");
                Console.WriteLine("----------------------");

                Admin ad1 = new Admin();
                ad1.AdminDashboard();



        }




        public void ReturnCourses (){

        }

        public void GetAllTracks()
        {

        }
    }

    
}