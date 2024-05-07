using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Application.Repositories;
using Persistance.DataContext;
using Persistance.Repositories;

namespace Persistance.Services
{
    public static class PersistenceService
    {
        public static void PersistanceConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IIndustryRepository, IndustryRepository>();
        }
    }
}
