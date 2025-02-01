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

namespace Application.Services.Patient.Query.GetPatientByIdQuery
{
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQueryRequest, ErrorOr<GetPatientByIdQueryResponce>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GetPatientByIdQueryHandler(IPatientRepository patientRepository, IMapper mapper,
            IUnitOfWork unitOfWork) {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<GetPatientByIdQueryResponce>> Handle(GetPatientByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var record = await _patientRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<GetPatientByIdQueryResponce>(record);
        }
    }
}
