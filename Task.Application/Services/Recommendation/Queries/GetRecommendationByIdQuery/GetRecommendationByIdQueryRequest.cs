using Application.Services.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Recommendation.Query.GetRecommendationByIdQuery
{
    public record GetRecommendationByIdQueryRequest:BaseRequest,IRequest<ErrorOr<GetRecommendationByIdQueryResponce>>
    {
        public Guid Id { get; set; }
    }
}
