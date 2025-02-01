

using AutoMapper;

namespace Application.Services.Recommendation.Query.GetRecommendationByIdQuery
{
    public class GetRecommendationByIdQueryMapper:Profile
    {
        public GetRecommendationByIdQueryMapper()
        {
            CreateMap<Domain.Entities.Recommendation, GetRecommendationByIdQueryResponce>();
        }
    }
}
