using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IQuotationRepository : IBaseRepository<Quotation>
    {
        Task<bool> VerifyAlreadyExist(string companyTitle, CancellationToken cancellationToken);
        Task<Quotation> GetQuotationByIdWithItem(Guid id, CancellationToken cancellationToken);
        Task<List<Quotation>> GetAllQuotationWithItem(CancellationToken cancellationToken);
        Task<List<Quotation>> Search(string search, CancellationToken cancellationToken);
    }
}
