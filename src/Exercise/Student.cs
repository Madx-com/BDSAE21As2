using System;
namespace Exercise
{

    public enum Status = {New, Active, Dropout, Graduated}

    public class Student
    {
        public int ID {get ; private set} = Int32.MinValue; // default value should be handled differently. ie. errorhandling.
        public string GivenName {get; set};
        public string Surname {get; set};
        public enum Status {get; private set};
        public DateTime StartDate {get; set} = DateTime.Now; // StartDate should be set when created but in this not required.
        public DateTime EndDate {get; set};
        public DateTime GraduationDate {get; set};

        public Student(int id)
        {
            ID = id;
        } 

        private enum checkStatus()
        {
            // if(StartDate) //== around same day. -> new
            // start set but older than new. -> active
            // EndDate set but not Grad -> dropout
            // End and Grad set -> graduated
        }

        public override string ToString()
        {

        }
    }
}