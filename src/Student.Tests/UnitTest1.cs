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
    }
}
