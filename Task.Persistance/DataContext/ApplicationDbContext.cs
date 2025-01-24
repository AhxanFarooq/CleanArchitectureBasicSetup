using Microsoft.EntityFrameworkCore;


namespace Persistance.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        
    }
}
