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

namespace Application.Services.Authentication.Command.RecommendationCommand
{
    public class RecommendationCommandHandler : IRequestHandler<RecommendationCommandRequest, ErrorOr<RecommendationCommandResponce>>
    {
        private readonly IRecommendationRepository _RecommendationRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public RecommendationCommandHandler(IRecommendationRepository RecommendationRepository, IMapper mapper,
            IUnitOfWork unitOfWork) {
            _RecommendationRepository = RecommendationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<RecommendationCommandResponce>> Handle(RecommendationCommandRequest request, CancellationToken cancellationToken)
        {
            var Recommendation = _mapper.Map<Domain.Entities.Recommendation>(request);

            if (Recommendation.Id != Guid.Empty)
            {
                var data = await _RecommendationRepository.GetByIdAsync(Recommendation.Id, cancellationToken);
                data.Status = Recommendation.Status;
                data.Type = Recommendation.Type;
                data.DueDate = Recommendation.DueDate;
                await _unitOfWork.SaveChanges(cancellationToken);
                return new RecommendationCommandResponce()
                {
                    Id = Recommendation.Id,
                    Message = "Recommendation has been Updated"
                };
            }
            else
            {
                _RecommendationRepository.Create(Recommendation);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new RecommendationCommandResponce()
                {
                    Id = Recommendation.Id,
                    Message = "Recommendation has been created"
                };
            }
        }
    }
}
