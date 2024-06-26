﻿using Application.Repositories;
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
    public class IndustryRepository : BaseRepository<Industry>, IIndustryRepository
    {
        public IndustryRepository(ApplicationDbContext context) : base(context) { }

        public Task<List<Industry>> SearchByIndustry(string search, CancellationToken cancellationToken)
        {
            return _context.Set<Industry>().Where(a => a.Name.Contains(search)).ToListAsync(cancellationToken);
        }

        public Task<bool> VerifyAlreadyExist(string name, CancellationToken cancellationToken)
        {
            return _context.Industries.AnyAsync(x => x.Name.ToLower() == name.ToLower(), cancellationToken);
        }
    }
}
