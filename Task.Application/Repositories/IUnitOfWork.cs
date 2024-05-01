

namespace Application.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
