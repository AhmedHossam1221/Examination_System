using ExaminationSystem.ViewModels;

namespace ExaminationSystem.ViewModels.Instructors
{
    public class InstructorToReturnViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public string Course { get; set; }
    }

}
