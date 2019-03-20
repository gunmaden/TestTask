using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.EntityModels;
using Models.RequestModels;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : Controller
    {
        private readonly IPositionRepository _positionRepository;

        public PositionsController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        // GET api/positions
        [HttpGet]
        public async Task<Page<Position>> Get()
        {
            return await _positionRepository.GetPositions();
        }
    }
}