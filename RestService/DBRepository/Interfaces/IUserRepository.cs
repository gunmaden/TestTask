using System;
using System.Threading.Tasks;
using Models.EntityModels;
using Models.RequestModels;

namespace DBRepository.Interfaces
{
    public interface IUserRepository
    {
        Task<Page<User>> GetUsers(RequestUsersModel requestUsersModel);
        Task<User> PutUser(CreationUserModel user);
        Task<int> Delete(Guid userId);
    }
}