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
    public class QuotationRepository : BaseRepository<Quotation>, IQuotationRepository
    {
        public QuotationRepository(ApplicationDbContext context) : base(context) { }

        public Task<bool> VerifyAlreadyExist(string code, CancellationToken cancellationToken)
        {
            return _context.Quotations.AnyAsync(x => x.Code.ToLower() == code.ToLower(), cancellationToken);
        }
        public Task<Quotation> GetQuotationByIdWithItem(Guid id, CancellationToken cancellationToken)
        {
            return _context.Quotations.Include(x => x.QuotationItems).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public Task<List<Quotation>> GetAllQuotationWithItem(CancellationToken cancellationToken)
        {
            return _context.Quotations.Include(x => x.QuotationItems).Include(x=>x.Contact).OrderBy(x => x.CreatedDate).ToListAsync();
        }

        public async Task<List<Quotation>> Search(string search, CancellationToken cancellationToken)
        {
            var data = await _context.Set<Quotation>().Include(x => x.QuotationItems).ToListAsync(cancellationToken);
            return data.Where(a => a.Code.ToLower().Contains(search.ToLower()) || a.Contact.CompanyTitle.ToLower().Contains(search.ToLower())).ToList();
        }
    }
}
