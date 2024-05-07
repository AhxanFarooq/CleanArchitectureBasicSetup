using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.IndustryServices.Command.GetIndustryQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.GetIndustryQuery
{
    public class GetIndustryHandler : IRequestHandler<GetIndustryRequest, GetIndustryResponse>
    {
        protected readonly IIndustryRepository _industryRepository;
        protected readonly IMapper _mapper;
        public GetIndustryHandler(IIndustryRepository industryRepository, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _mapper = mapper;
        }
        public async Task<GetIndustryResponse> Handle(GetIndustryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _industryRepository.GetByIdAsync(request.Id, cancellationToken);
                return _mapper.Map<GetIndustryResponse>(record);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
