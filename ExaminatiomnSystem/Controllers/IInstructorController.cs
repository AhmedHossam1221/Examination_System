using ExaminatiomnSystem.DTO;
using ExaminatiomnSystem.DTO.Instractor;
using ExaminatiomnSystem.Helpers;
using ExaminatiomnSystem.Services.Instractours;
using ExaminationSystem.ViewModels.Instructors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminatiomnSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IInstructorController : ControllerBase
    {
        private readonly IInstractourService _instractourService;
        public IInstructorController(IInstractourService instractourService)
        {
            _instractourService = instractourService;
        }
        [HttpGet]
        public IEnumerable<InstructorToReturnViewModel>GetAll()
        {
            var instractors =_instractourService.GetAll();
            return instractors.Select(x => x.MapOne<InstructorToReturnViewModel>());
        }
        [HttpGet("{id:int}")]
        public InstructorToReturnViewModel GetByID(int id)
        {
            var instractor = _instractourService.GetById(id);
            return instractor.MapOne<InstructorToReturnViewModel>();
        }
        [HttpPost]
        public bool Add (InstructorToCreateViewModel viewModel)
        {
            var instractor = viewModel.MapOne<InstractourCreateDTO>();
            _instractourService.Add(instractor);
            return true;
        }
        [HttpPut("{id:int}")]
        public bool Update(int id,InstructorToUpdateViewModel viewModel) 
        {
            var updatedInstarctor = viewModel.MapOne<InstractourUpdateDTO>();
            _instractourService.Update(id, updatedInstarctor);
            return true;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            _instractourService.Delete(id);
            return true;
        }
    }
}
