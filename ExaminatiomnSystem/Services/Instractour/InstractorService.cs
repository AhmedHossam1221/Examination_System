using ExaminatiomnSystem.DTO;
using ExaminatiomnSystem.DTO.Instractor;
using ExaminatiomnSystem.Helpers;
using ExaminatiomnSystem.Models;
using ExaminatiomnSystem.Repositories;
using System.Linq;

namespace ExaminatiomnSystem.Services.Instractours
{
    public class InstractorService : IInstractourService
    {
        private readonly IRepository<Models.Instractours> _repository;
        public InstractorService(IRepository<Models.Instractours> repository)
        {
            _repository = repository;   
        }
        public void Add(InstractourCreateDTO instructorDTO)
        {
            var instructor = instructorDTO.MapOne<Models.Instractours>();
            _repository.Add(instructor);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            var instructor =_repository.GetByIDWithTracing(id);
            if (instructor != null)
            {
                _repository.Delete(instructor);
                _repository.SaveChanges();
            }
        }

        public IEnumerable<InstractourReturenDTO> GetAll()
        {
            var instractours = _repository.GetAll();
            return instractours.Map<InstractourReturenDTO>();
        }

        public InstractourReturenDTO GetById(int id)
        {
            var instractour = _repository.GetByID(id);
            return instractour.MapOne<InstractourReturenDTO>();
        }

        public bool Update(int id, InstractourUpdateDTO instractour)
        {
            var instructor =_repository.GetByIDWithTracing(id);
            if (instructor is null)
            {
                throw new KeyNotFoundException("instructor not found");
            }
            var updatedInstructor = instractour.MapOne<Models.Instractours>();
            
                instructor.FirstName = updatedInstructor.FirstName;
                instructor.LastName = updatedInstructor.LastName;
                _repository.Update(instructor);
                _repository.SaveChanges();
                return true;
        }
    }
}
