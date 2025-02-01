using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<bool> VerifyAlreadyExist(string code, CancellationToken cancellationToken);
        Task<List<Patient>> SearchByNameOrId(string search, CancellationToken cancellationToken);
    }
}
