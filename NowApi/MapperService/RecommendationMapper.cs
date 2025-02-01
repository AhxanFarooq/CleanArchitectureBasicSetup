using Application.Services.Authentication.Command.RecommendationCommand;
using Application.Services.Recommendation.Query.GetRecommendationListQuery;
using AutoMapper;
using NowApi.ViewModel.Recommendation;

namespace NowApi.MapperService
{
    public class RecommendationMapper:Profile
    {
        public RecommendationMapper()
        {
            CreateMap<UpsertRecommendation, RecommendationCommandRequest>();
            CreateMap<GetAllRecommendation, GetRecommendationListQueryRequest>();
        }
    }
}
