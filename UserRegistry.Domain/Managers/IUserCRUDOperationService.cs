
using UserRegistry.Domain.Models;

namespace UserRegistry.Domain.Managers
{
    public interface IUserCRUDOperationService
    {
        Task<IEnumerable<UserEntityModel>> Get();
        Task<UserEntityModel> Get(int id);
        Task<UserEntityModel> Create(UserEntityModel user);
        Task Update(UserEntityModel user);
        Task Delete(int id);
    }
}
