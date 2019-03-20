using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.EntityModels;
using Models.RequestModels;

namespace DBRepository.Repositories
{
    public class PositionRepository : BaseRepository, IPositionRepository
    {
        public PositionRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(
            connectionString,
            contextFactory)
        {
        }

        public async Task<Page<Position>> GetPositions()
        {
            var result = new Page<Position>
                {CurrentPage = 1, PageSize = 100500};

            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Positions.AsQueryable();

                result.TotalPages = await query.CountAsync();
                query = query
                    .Skip(0)
                    .Take(100500);
                result.Records = await query.ToListAsync();
            }

            return result;
        }
    }
}