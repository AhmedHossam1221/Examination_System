using ExaminationSystem.ViewModels;
using Microsoft.VisualBasic;

namespace ExaminationSystem.ViewModels.Students
{
    public class StudentToReturnViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Courses { get; set; } = new List<string>();
    }
}
