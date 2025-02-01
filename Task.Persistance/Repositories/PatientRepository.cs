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
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context) { }
        public Task<bool> VerifyAlreadyExist(string code, CancellationToken cancellationToken)
        {
            return _context.Patients.AnyAsync(x => x.Code.ToLower() == code.ToLower(), cancellationToken);
        }
        public Task<List<Patient>> SearchByNameOrId(string search, CancellationToken cancellationToken)
        {
            return _context.Set<Patient>().Where(a => a.Name.Contains(search) || a.Code.Contains(search)).ToListAsync(cancellationToken);
        }
    }
}
