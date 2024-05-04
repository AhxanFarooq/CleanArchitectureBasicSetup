using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using Domain.Entities;

namespace Persistance.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactCoversation> ContactCoversations { get; set; }
    }
}
