namespace ExaminatiomnSystem.Models
{
    public class Course: BaseModel
    {
        public string Name { get; set; }
        public int CreditHoure { get; set; }
        
        public HashSet<Exam> Exams { get; set; }
        public HashSet<CourseStudent> CourseStudents { get; set; }
        public int InstractoursID { get; set; }
        public Instractours Instractour { get; set; }
    }
}
