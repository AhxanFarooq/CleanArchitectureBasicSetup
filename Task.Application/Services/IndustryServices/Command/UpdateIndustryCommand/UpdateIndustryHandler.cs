using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.IndustryServices.Command.UpdateIndustryCommand;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.UpdateIndustryCommand
{
    public class UpdateIndustryHandler : IRequestHandler<UpdateIndustryRequest, UpdateIndustryResponse>
    {
        protected readonly IIndustryRepository _industryRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public UpdateIndustryHandler(IIndustryRepository industryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateIndustryResponse> Handle(UpdateIndustryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var industry = await _industryRepository.GetByIdAsync(request.Id, cancellationToken);
                if (industry is null)
                    throw new NotFoundException("Record not found");

                //Validate Industry already exist
                if (industry.Name != request.Name)
                {
                    var isAlreadyExist = await _industryRepository.VerifyAlreadyExist(request.Name, cancellationToken);
                    if (isAlreadyExist)
                        throw new AlreadyExistException(" Industry is already exist.");
                }
                industry.Name = request.Name;
                industry.Description = request.Description;
                industry.IsActive = request.IsActive;

                _industryRepository.Update(industry);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new UpdateIndustryResponse()
                {
                    Message = "Industry has been update"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
