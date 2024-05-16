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
    public class AreaRepository:BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(ApplicationDbContext context) : base(context) { }

        public Task<bool> VerifyAlreadyExist(string name, CancellationToken cancellationToken)
        {
            return _context.Areas.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
        }
    }
}
