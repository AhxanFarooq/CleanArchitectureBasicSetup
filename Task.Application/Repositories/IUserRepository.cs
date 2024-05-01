
using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<User> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
