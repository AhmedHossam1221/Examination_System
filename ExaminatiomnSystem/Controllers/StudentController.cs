using ExaminatiomnSystem.DTO.Student;
using ExaminatiomnSystem.Helpers;
using ExaminatiomnSystem.Services.Student;
using ExaminationSystem.ViewModels.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminatiomnSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IEnumerable<StudentToReturnViewModel> GetAll()
        {
            var students = _studentService.GetAll();
            return students.Select(x => x.MapOne<StudentToReturnViewModel>());
        }
        [HttpGet("{id:int}")]
        public StudentToReturnViewModel GetById(int id)
        {
            var student = _studentService.GetById(id);
            return student.MapOne<StudentToReturnViewModel>();
        }
        [HttpPost]
        public bool Add(StudentToReturnViewModel student)
        {
            var newStudent = student.MapOne<StudentCreateDTO>();
            _studentService.Add(newStudent);
            return true;
        }
        [HttpPut]
        public bool Update(int id,StudentToUpdateViewModel viewModel)
        {
            var updatedStudent = viewModel.MapOne<StudentUpdateDTO>();  
            _studentService.Update(id, updatedStudent);
            return true;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            _studentService.Delete(id);
            return true;
        }
    }
}
