using ExaminatiomnSystem.DTO;
using ExaminatiomnSystem.DTO.Student;
using ExaminatiomnSystem.Helpers;
using ExaminatiomnSystem.Repositories;

namespace ExaminatiomnSystem.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Models.Student> _repository;
        public StudentService(IRepository<Models.Student> repository)
        {
            _repository = repository;
        }
        public void Add(StudentCreateDTO studentDTO)
        {
            var student= studentDTO.MapOne<Models.Student>();
            _repository.Add(student);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var student=_repository.GetByIDWithTracing(id);
            if(student!=null)
            {
                _repository.Delete(student);
                _repository.SaveChanges();
            }
        }

        public IEnumerable<StudentReturenDTO> GetAll()
        {
            var students = _repository.GetAll();
            return students.Map<StudentReturenDTO>();
        }

        public StudentReturenDTO GetById(int id)
        {
            var student=_repository.GetByID(id);
            return student.MapOne<StudentReturenDTO>();
        }

        public bool Update(int id, StudentUpdateDTO studentDTO)
        {
            var student = _repository.GetByIDWithTracing(id);
            if(student is null)
            {
                throw new KeyNotFoundException("Student not found");
            }
            var updatedStudent = studentDTO.MapOne<Models.Student>();
            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            _repository.Update(student);
            _repository.SaveChanges();
            return true;
        }
    }
}
