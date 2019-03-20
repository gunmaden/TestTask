using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.EntityModels;
using Models.RequestModels;

namespace DBRepository.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(
            connectionString, contextFactory)
        {
        }

        public async Task<Page<User>> GetUsers(RequestUsersModel requestUsersModel)
        {
            var result = new Page<User>
            {
                CurrentPage = requestUsersModel.Page > 1 ? requestUsersModel.Page : 1,
                PageSize = requestUsersModel.PageSize > 0 ? requestUsersModel.PageSize : 20
            };

            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var query = context.Users.AsQueryable();
                if (requestUsersModel.Positions?.Any() != null)
                    query = query.Where(u => requestUsersModel.Positions.Contains(u.Position.Id));

                if (requestUsersModel.Age != null)
                    query = query.Where(u => u.GetAge() <= requestUsersModel.Age.MaxValue.GetValueOrDefault(100)
                                             && u.GetAge() >= requestUsersModel.Age.MinValue.GetValueOrDefault(1)
                    );

                if (requestUsersModel.WorkingExperience != null)
                    query = query.Where(u =>
                        u.GetYearsOfExperience() <= requestUsersModel.WorkingExperience.MaxValue.GetValueOrDefault(100)
                        && u.GetYearsOfExperience() >= requestUsersModel.WorkingExperience.MinValue.GetValueOrDefault(1)
                    );

                result.TotalPages = await query.CountAsync();
                query = query
                    .Include(p => p.Position)
                    .OrderBy(p => p.WorkPeriodStartDate)
                    .Skip((result.CurrentPage - 1) * result.PageSize)
                    .Take(result.PageSize);

                result.Records = await query.ToListAsync();
            }

            return result;
        }

        public async Task<User> PutUser(CreationUserModel user)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var positionEntry = context.Set<Position>()
                    .AsQueryable().FirstOrDefault(x => user.PositionId != null && x.Id == new Guid(user.PositionId));
                if (positionEntry == null) throw new ValidationException("Position not found");
                var createdUser = await context.Set<User>().AddAsync(new User
                {
                    Position = positionEntry,
                    BirthDate = user.GetBirthDateTime(),
                    DisplayName = user.DisplayName,
                    WorkPeriodStartDate = user.GetWorkPeriodStartDateTime()
                });
                await context.SaveChangesAsync();
                return createdUser.Entity;
            }
        }

        public async Task<int> Delete(Guid userId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                var userToDelete = await GetUser(userId);
                if (userToDelete == null) throw new ValidationException("User not found");
                context.Set<User>().Remove(userToDelete);
                return await context.SaveChangesAsync();
            }
        }

        private async Task<User> GetUser(Guid userId)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                return await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
            }
        }
    }
}