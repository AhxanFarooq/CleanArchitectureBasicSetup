using Application.Common.Exceptions;
using Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;
using Domain.Common.Errors;
using Application.Repositories;
using AutoMapper;
using Application.Services.Common;

namespace Application.Services.Recommendation.Query.GetRecommendationByIdQuery
{
    public class GetRecommendationByIdQueryHandler : IRequestHandler<GetRecommendationByIdQueryRequest, ErrorOr<GetRecommendationByIdQueryResponce>>
    {
        private readonly IRecommendationRepository _RecommendationRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GetRecommendationByIdQueryHandler(IRecommendationRepository RecommendationRepository, IMapper mapper,
            IUnitOfWork unitOfWork) {
            _RecommendationRepository = RecommendationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<GetRecommendationByIdQueryResponce>> Handle(GetRecommendationByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var record = await _RecommendationRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<GetRecommendationByIdQueryResponce>(record);
        }
    }
}
