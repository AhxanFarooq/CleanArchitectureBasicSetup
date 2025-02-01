
using Application.Services.Authentication.Command.RecommendationCommand;
using AutoMapper;

namespace Application.Services.Recommendation.Command.RecommendationCommand
{
    public class RecommendationCommandMapper:Profile
    {
        public RecommendationCommandMapper()
        {
            CreateMap<RecommendationCommandRequest, Domain.Entities.Recommendation>();
        }
    }
}
