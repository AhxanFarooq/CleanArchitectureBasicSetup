using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<bool> VerifyAlreadyExist(string name, CancellationToken cancellationToken);
        Task<List<Product>> Search(string search, CancellationToken cancellationToken);
    }
}
