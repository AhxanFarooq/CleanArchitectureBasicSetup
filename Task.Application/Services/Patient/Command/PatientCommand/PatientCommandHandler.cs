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

namespace Application.Services.Authentication.Command.PatientCommand
{
    public class PatientCommandHandler : IRequestHandler<PatientCommandRequest, ErrorOr<PatientCommandResponce>>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public PatientCommandHandler(IPatientRepository patientRepository, IMapper mapper,
            IUnitOfWork unitOfWork) {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<PatientCommandResponce>> Handle(PatientCommandRequest request, CancellationToken cancellationToken)
        {
            var patient = _mapper.Map<Domain.Entities.Patient>(request);

            //Validate Area already exist
            var isAlreadyExist = await _patientRepository.VerifyAlreadyExist(patient.Code, cancellationToken);
            if (isAlreadyExist)
                return Errors.AlreadyExist.RecordExist;
           _patientRepository.Create(patient);
            await _unitOfWork.SaveChanges(cancellationToken);
            return new PatientCommandResponce()
            {
                Id = patient.Id,
                Message = "Patient has been created"
            };
        }
    }
}
