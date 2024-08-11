namespace ExaminatiomnSystem.Models
{
    public class Instractours : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HashSet<Exam> Exams { get; set; }
        public Course Course { get; set; }
    }
}
