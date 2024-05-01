using System;
using System.Collections.Generic;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.DataContext;

namespace Persistance.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<User> GetUserByEmail(string userName, CancellationToken cancellationToken)
        {
            return _context.Users.FirstOrDefaultAsync(x=>x.UserName == userName, cancellationToken);
        }
    }
}
