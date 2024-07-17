using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public Task<List<Product>> Search(string search, CancellationToken cancellationToken)
        {
            return _context.Set<Product>().Where(a => a.Name.Contains(search)).ToListAsync(cancellationToken);
        }

        public Task<bool> VerifyAlreadyExist(string name, CancellationToken cancellationToken)
        {
            return _context.Products.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
        }

    }
}
