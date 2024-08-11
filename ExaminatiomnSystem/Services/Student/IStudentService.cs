using ExaminatiomnSystem.DTO.Student;

namespace ExaminatiomnSystem.Services.Student
{
    public interface IStudentService
    {
        IEnumerable<StudentReturenDTO> GetAll();
        StudentReturenDTO GetById(int id);
        void Add(StudentCreateDTO student);
        bool Update(int id, StudentUpdateDTO studentDTO);
        void Delete(int id);
    }
}
