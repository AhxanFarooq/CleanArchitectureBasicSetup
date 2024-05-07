using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.IndustryServices.Command.AddIndustryCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Services.IndustryServices.Command.AddIndustryCommand
{
    public class AddIndustryHandler : IRequestHandler<AddIndustryRequest, AddIndustryResponse>
    {
        protected readonly IIndustryRepository _industryRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public AddIndustryHandler(IIndustryRepository industryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddIndustryResponse> Handle(AddIndustryRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var industry = _mapper.Map<Industry>(request);

                //Validate industry already exist
                var isAlreadyExist = await _industryRepository.VerifyAlreadyExist(industry.Name, cancellationToken);
                if (isAlreadyExist)
                    throw new AlreadyExistException("Industry is already exist.");
                _industryRepository.Create(industry);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new AddIndustryResponse()
                {
                    Id = industry.Id,
                    Message = "Industry has been created"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
