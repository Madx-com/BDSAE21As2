using System.Security.AccessControl;
using System;
using System.Text;

namespace Student
{
    public enum Status {New, Active, Dropout, Graduated}

    public record ImmutableStudent{
        public int ID {get ; init;} = Int32.MinValue; // default value should be handled differently. ie. errorhandling.
        public string GivenName {get; init;}
        public string Surname {get; init;}
        public Status Status {get => evaluateAndRetrieveStatus();}
        public DateTime StartDate {get; init;} = DateTime.Now; // StartDate should be set when created but in this not required.
        public DateTime EndDate {get; init;}
        public DateTime GraduationDate {get; init;}

        private Status evaluateAndRetrieveStatus()
        {
            if (GraduationDate != DateTime.MinValue && GraduationDate < DateTime.Now)
                return Status.Graduated;
            else if (StartDate.AddDays(7) > DateTime.Now)
                return Status.New;
            else if (EndDate != DateTime.MinValue && EndDate < DateTime.Now && GraduationDate == DateTime.MinValue)
                return Status.Dropout;
            return Status.Active;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{GivenName} {Surname}\nID: {ID}\nStatus: {Status}");
            if (StartDate != DateTime.MinValue)
                sb.Append($"\nEducation start: {StartDate.ToString()}");
            if (EndDate != DateTime.MinValue)
                sb.Append($"\nEducation end: {EndDate.ToString()}");
            if (GraduationDate != DateTime.MinValue)
                sb.Append($"\nGraduation day: {GraduationDate.ToString()}");    
            return sb.ToString();
        }
    }
    public class Student
    {
        public int ID {get ; init;} = Int32.MinValue; // default value should be handled differently. ie. errorhandling.
        public string GivenName {get; set;}
        public string Surname {get; set;}
        public Status Status {get => evaluateAndRetrieveStatus();}
        public DateTime StartDate {get; set;} = DateTime.Now; // StartDate should be set when created but in this not required.
        public DateTime EndDate {get; set;}
        public DateTime GraduationDate {get; set;}

        public Student(int id)
        {
            ID = id;
        }

        private Status evaluateAndRetrieveStatus()
        {
            if (GraduationDate != DateTime.MinValue && GraduationDate < DateTime.Now)
                return Status.Graduated;
            else if (StartDate.AddDays(7) > DateTime.Now)
                return Status.New;
            else if (EndDate != DateTime.MinValue && EndDate < DateTime.Now && GraduationDate == DateTime.MinValue)
                return Status.Dropout;
            return Status.Active;
            // if(StartDate) //== around same day. -> new
            // start set but older than new. -> active
            // EndDate set but not Grad -> dropout
            // End and Grad set -> graduated
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{GivenName} {Surname}\nID: {ID}\nStatus: {Status}");
            if (StartDate != DateTime.MinValue)
                sb.Append($"\nEducation start: {StartDate.ToString()}");
            if (EndDate != DateTime.MinValue)
                sb.Append($"\nEducation end: {EndDate.ToString()}");
            if (GraduationDate != DateTime.MinValue)
                sb.Append($"\nGraduation day: {GraduationDate.ToString()}");    
            return sb.ToString();
        }
    }
}
