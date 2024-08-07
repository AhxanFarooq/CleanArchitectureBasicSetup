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
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context) : base(context) { }

        public Task<bool> VerifyAlreadyExist(string companyTitle, CancellationToken cancellationToken)
        {
            return _context.Contacts.AnyAsync(x => x.CompanyTitle.ToLower() == companyTitle.ToLower(), cancellationToken);
        }
        public Task<Contact> GetContactByIdWithDetail(Guid id, CancellationToken cancellationToken)
        {
            return _context.Contacts.Include(x=>x.ContactDetails).Include(x=>x.ContactCoversations).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public Task<List<Contact>> GetAllContactWithDetail( CancellationToken cancellationToken)
        {
            return _context.Contacts.Include(x=>x.Area).Include(x=>x.Industry).OrderBy(x=>x.CreatedDate).ToListAsync();
        }

        public async Task<List<Contact>> Search(string search, CancellationToken cancellationToken)
        {
            var data =  await _context.Set<Contact>().Include(x => x.Area).Include(x => x.Industry).ToListAsync(cancellationToken);
            return data.Where(a => a.CompanyTitle.ToLower().Contains(search.ToLower()) || a.City.ToLower().Contains(search.ToLower()) || a.Source.ToLower().Contains(search.ToLower()) || a.Area.Name.ToLower().Contains(search.ToLower()) || a.Industry.Name.ToLower().Contains(search.ToLower())).ToList();
        }
    }
}
