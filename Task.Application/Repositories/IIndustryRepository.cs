using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IIndustryRepository : IBaseRepository<Industry>
    {
        Task<bool> VerifyAlreadyExist(string name, CancellationToken cancellationToken);
    }
}
