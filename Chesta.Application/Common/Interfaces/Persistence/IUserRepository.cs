using Chesta.Domain.Entities;

namespace Chesta.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetUserByEmail(string email);

        User Add(User user);
    }
}