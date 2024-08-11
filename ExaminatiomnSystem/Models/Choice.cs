namespace ExaminatiomnSystem.Models
{
    public class Choice: BaseModel
    {
        public string Text { get; set; }
        public bool IsRightAnswer { get; set; }
        public int QusetionID { get; set; }
        public Question Question { get; set; }
    }
}
