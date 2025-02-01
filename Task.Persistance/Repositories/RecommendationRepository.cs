using Application.Repositories;
using Domain.Entities;
using Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class RecommendationRepository : BaseRepository<Recommendation>, IRecommendationRepository
    {
        public RecommendationRepository(ApplicationDbContext context) : base(context) { }
    }
}
