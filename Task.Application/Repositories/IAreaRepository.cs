using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        Task<bool> VerifyAlreadyExist(string name, CancellationToken cancellationToken);
    }
}
