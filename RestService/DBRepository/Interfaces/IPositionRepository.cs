using System.Threading.Tasks;
using Models.EntityModels;
using Models.RequestModels;

namespace DBRepository.Interfaces
{
    public interface IPositionRepository
    {
        Task<Page<Position>> GetPositions();
    }
}