using ExaminatiomnSystem.DTO;
using ExaminatiomnSystem.DTO.Instractor;

namespace ExaminatiomnSystem.Services.Instractours
{
    public interface IInstractourService
    {
        IEnumerable<InstractourReturenDTO> GetAll();
        InstractourReturenDTO GetById(int id);
        void Add(InstractourCreateDTO instractour);
        bool Update(int id, InstractourUpdateDTO instractour);
        void Delete(int id);

    }
}
