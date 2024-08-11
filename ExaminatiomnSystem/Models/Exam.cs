namespace ExaminatiomnSystem.Models
{
    public class Exam : BaseModel
    {
        public DateTime StartDate { get; set; }
        public int TotalDegree { get; set; }
        public int InstractourID { get; set; }
        public Instractours? Instractour { get; set; }
        public Course Course { get; set; }
        public HashSet<ExamQuestion> ExamQuestions { get; set; }
        public HashSet<ExamStudent> ExamStudents { get; set; }
    }
}
