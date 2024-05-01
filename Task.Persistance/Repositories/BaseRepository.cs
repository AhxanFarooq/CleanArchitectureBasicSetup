using Microsoft.EntityFrameworkCore;

using Application.Repositories;
using Domain.Common;
using Persistance.DataContext;

namespace Persistance.Repositories
{
    public class BaseRepository<T> : Application.Repositories.IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return _context.Set<T>().ToListAsync(cancellationToken);
        }

        public Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
        }

        public void Update(T entity)
        {
            entity.ModefiedDate = DateTime.Now;
            _context.Update(entity);
        }
    }
}
