namespace ExaminatiomnSystem.Models
{
    public class ExamStudent : BaseModel
    {
        public int ExamID { get; set; }
        public Exam Exam { get; set; }

        public int StudentID { get; set; }
        public Student Student { get; set; }
    }
}
