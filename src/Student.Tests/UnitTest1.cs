using System;
using Xunit;

namespace Student.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void EvaluateAndRetrieveStatus_is_new_active_dropout_and_graduated_for_started_yesterday_started_a_month_ago_enddate_yesterday_no_graddate_and_all_dates_set()
        {
            var newStudent = new Student(1);
            newStudent.GivenName = "Mads";
            newStudent.Surname = "Ljungberg";
            newStudent.StartDate = DateTime.Now.AddDays(-1); // Yesterday

            var activeStudent = new Student(2);
            activeStudent.GivenName = "Paolo";
            activeStudent.Surname = "Tell";
            activeStudent.StartDate = DateTime.Now.AddDays(-30); 

            var dropoutStudent = new Student(3);
            dropoutStudent.GivenName = "Asmus";
            dropoutStudent.Surname = "Tørsleff";
            dropoutStudent.StartDate = DateTime.Now.AddDays(-30); 
            dropoutStudent.EndDate = DateTime.Now.AddDays(-1); 

            
            var graduateStudent = new Student(4);
            graduateStudent.GivenName = "Sebastian";
            graduateStudent.Surname = "Fugmann";
            graduateStudent.StartDate = DateTime.Now.AddDays(-60); 
            graduateStudent.EndDate = DateTime.Now.AddDays(-7); 
            graduateStudent.GraduationDate = DateTime.Now.AddDays(-1); 

            Assert.Equal(Status.New, newStudent.Status);
            Assert.Equal(Status.Active, activeStudent.Status);
            Assert.Equal(Status.Dropout, dropoutStudent.Status);
            Assert.Equal(Status.Graduated, graduateStudent.Status);
        }

        [Fact]
        public void ToSting_new_active_dropout_and_graduated_Student()
        {
            var newStudent = new Student(1);
            newStudent.GivenName = "Mads";
            newStudent.Surname = "Ljungberg";
            newStudent.StartDate = DateTime.Now.AddDays(-1); // Yesterday

            var activeStudent = new Student(2);
            activeStudent.GivenName = "Paolo";
            activeStudent.Surname = "Tell";
            activeStudent.StartDate = DateTime.Now.AddDays(-30); 

            var dropoutStudent = new Student(3);
            dropoutStudent.GivenName = "Asmus";
            dropoutStudent.Surname = "Tørsleff";
            dropoutStudent.StartDate = DateTime.Now.AddDays(-30); 
            dropoutStudent.EndDate = DateTime.Now.AddDays(-1); 

            
            var graduateStudent = new Student(4);
            graduateStudent.GivenName = "Sebastian";
            graduateStudent.Surname = "Fugmann";
            graduateStudent.StartDate = DateTime.Now.AddDays(-60); 
            graduateStudent.EndDate = DateTime.Now.AddDays(-7); 
            graduateStudent.GraduationDate = DateTime.Now.AddDays(-1); 

            var newExpected = $"Mads Ljungberg\nID: 1\nStatus: New\nEducation start: {newStudent.StartDate.ToString()}";
            var activeExpected = $"Paolo Tell\nID: 2\nStatus: Active\nEducation start: {activeStudent.StartDate.ToString()}";
            var dropouExpected =  $"Asmus Tørsleff\nID: 3\nStatus: Dropout\nEducation start: {dropoutStudent.StartDate.ToString()}\nEducation end: {dropoutStudent.EndDate.ToString()}";
            var graduateExpected = $"Sebastian Fugmann\nID: 4\nStatus: Graduated\nEducation start: {graduateStudent.StartDate.ToString()}\nEducation end: {graduateStudent.EndDate.ToString()}\nGraduation day: {graduateStudent.GraduationDate.ToString()}";
            Assert.Equal(newExpected, newStudent.ToString());
            Assert.Equal(activeExpected, activeStudent.ToString());
            Assert.Equal(dropouExpected, dropoutStudent.ToString());
            Assert.Equal(graduateExpected, graduateStudent.ToString());
        }

        [Fact]
        public void ToSting_new_active_dropout_and_graduated_ImmutableStudent()
        {
            var newStudent = new ImmutableStudent{ ID = 1, GivenName = "Mads", Surname = "Ljungberg", StartDate = DateTime.Now.AddDays(-1) };
            var activeStudent = new ImmutableStudent{ ID = 2, GivenName = "Paolo", Surname = "Tell", StartDate = DateTime.Now.AddDays(-30) };
            var dropoutStudent = new ImmutableStudent{ ID = 3, GivenName = "Asmus", Surname = "Tørsleff", StartDate = DateTime.Now.AddDays(-30), EndDate = DateTime.Now.AddDays(-1) };
            var graduateStudent = new ImmutableStudent{ ID = 4, GivenName = "Sebastian", Surname = "Fugmann", StartDate = DateTime.Now.AddDays(-60), EndDate = DateTime.Now.AddDays(-7), GraduationDate = DateTime.Now.AddDays(-1) };

            var newExpected = $"Mads Ljungberg\nID: 1\nStatus: New\nEducation start: {newStudent.StartDate.ToString()}";
            var activeExpected = $"Paolo Tell\nID: 2\nStatus: Active\nEducation start: {activeStudent.StartDate.ToString()}";
            var dropouExpected =  $"Asmus Tørsleff\nID: 3\nStatus: Dropout\nEducation start: {dropoutStudent.StartDate.ToString()}\nEducation end: {dropoutStudent.EndDate.ToString()}";
            var graduateExpected = $"Sebastian Fugmann\nID: 4\nStatus: Graduated\nEducation start: {graduateStudent.StartDate.ToString()}\nEducation end: {graduateStudent.EndDate.ToString()}\nGraduation day: {graduateStudent.GraduationDate.ToString()}";
            Assert.Equal(newExpected, newStudent.ToString());
            Assert.Equal(activeExpected, activeStudent.ToString());
            Assert.Equal(dropouExpected, dropoutStudent.ToString());
            Assert.Equal(graduateExpected, graduateStudent.ToString());
        }

        [Fact]
        public void Equal_ID_1_GivenName_Rasmus_Surname_Lystrøm_StartDate_yesterday_ImmutableStudent()
        {
            var date = DateTime.Now.AddDays(-1);
            var immutableRasmus1 = new ImmutableStudent{ ID = 1, GivenName = "Rasmus", Surname = "Lystrøm", StartDate = date };
            var immutableRasmus2 = new ImmutableStudent{ ID = 1, GivenName = "Rasmus", Surname = "Lystrøm", StartDate = date };
            
            Assert.Equal(immutableRasmus1, immutableRasmus2);
        }
    }
}
