using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<bool> VerifyAlreadyExist(string companyTitle, CancellationToken cancellationToken);
        Task<Contact> GetContactByIdWithDetail(Guid id, CancellationToken cancellationToken);
        Task<List<Contact>> GetAllContactWithDetail( CancellationToken cancellationToken);
        Task<List<Contact>> Search(string search, CancellationToken cancellationToken);
    }
}
