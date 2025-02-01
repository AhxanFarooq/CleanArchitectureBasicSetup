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

namespace Application.Services.Patient.Query.GetPatientListQuery
{
    public class GetPatientListQueryHandler : IRequestHandler<GetPatientListQueryRequest, ErrorOr<PaginatedResponse<GetPatientListQueryResponce>>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GetPatientListQueryHandler(IPatientRepository patientRepository, IMapper mapper,
            IUnitOfWork unitOfWork) {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<PaginatedResponse<GetPatientListQueryResponce>>> Handle(GetPatientListQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Patient> list;
            if (string.IsNullOrEmpty(request.Search))
            {
                list = await _patientRepository.GetAll(cancellationToken);
            }
            else
            {
                list = await _patientRepository.SearchByNameOrId(request.Search, cancellationToken);
            }

            list = list.OrderBy(x => x.Code).ToList();
            var totalRecord = list.Count;
            if (request.TotalPages > 0)
                list = list.Skip((request.PageIndex - 1) * request.TotalPages).Take(request.TotalPages).ToList();
            var response = _mapper.Map<List<GetPatientListQueryResponce>>(list);
            return new PaginatedResponse<GetPatientListQueryResponce>(response, request.PageIndex, request.TotalPages, totalRecord);
        }
    }
}
