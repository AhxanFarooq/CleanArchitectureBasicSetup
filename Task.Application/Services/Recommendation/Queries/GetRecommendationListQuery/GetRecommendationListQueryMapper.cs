

using AutoMapper;

namespace Application.Services.Recommendation.Query.GetRecommendationListQuery
{
    public class GetRecommendationListQueryMapper:Profile
    {
        public GetRecommendationListQueryMapper()
        {
            CreateMap<Domain.Entities.Recommendation, GetRecommendationListQueryResponce>();
        }
    }
}
