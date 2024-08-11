namespace ExaminatiomnSystem.Models
{
    public class Student : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HashSet<CourseStudent> CourseStudents { get; set; } 
        public HashSet<ExamStudent> ExamStudents { get; set; } 
    }
}
