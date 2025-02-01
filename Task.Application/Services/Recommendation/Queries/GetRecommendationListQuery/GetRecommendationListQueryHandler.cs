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

namespace Application.Services.Recommendation.Query.GetRecommendationListQuery
{
    public class GetRecommendationListQueryHandler : IRequestHandler<GetRecommendationListQueryRequest, ErrorOr<PaginatedResponse<GetRecommendationListQueryResponce>>>
    {
        private readonly IRecommendationRepository _RecommendationRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GetRecommendationListQueryHandler(IRecommendationRepository RecommendationRepository, IMapper mapper,
            IUnitOfWork unitOfWork) {
            _RecommendationRepository = RecommendationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<PaginatedResponse<GetRecommendationListQueryResponce>>> Handle(GetRecommendationListQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Recommendation> list;
            list = await _RecommendationRepository.GetAll(cancellationToken);

            var totalRecord = list.Count;
            if (request.TotalPages > 0)
                list = list.Skip((request.PageIndex - 1) * request.TotalPages).Take(request.TotalPages).ToList();
            var response = _mapper.Map<List<GetRecommendationListQueryResponce>>(list);
            return new PaginatedResponse<GetRecommendationListQueryResponce>(response, request.PageIndex, request.TotalPages, totalRecord);
        }
    }
}
