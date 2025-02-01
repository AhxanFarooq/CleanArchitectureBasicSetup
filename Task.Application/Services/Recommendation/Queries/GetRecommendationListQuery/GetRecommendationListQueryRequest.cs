using Application.Services.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Recommendation.Query.GetRecommendationListQuery
{
    public record GetRecommendationListQueryRequest:BaseRequest,IRequest<ErrorOr<PaginatedResponse<GetRecommendationListQueryResponce>>>
    {
       // public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
