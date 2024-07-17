using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.Common;
using Application.Services.IndustryServices.Command.GetAllIndustryQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.GetAllIndustryQuery
{
    public class GetAllIndustryHandler : IRequestHandler<GetAllIndustryRequest, PaginatedResponse<GetAllIndustryResponse>>
    {
        protected readonly IIndustryRepository _industryRepository;
        protected readonly IMapper _mapper;
        public GetAllIndustryHandler(IIndustryRepository industryRepository, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<GetAllIndustryResponse>> Handle(GetAllIndustryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Industry> list;
                if (string.IsNullOrEmpty(request.Search))
                {
                    list = await _industryRepository.GetAll(cancellationToken);
                }
                else
                {
                    list = await _industryRepository.SearchByIndustry(request.Search, cancellationToken);
                }

                list = list.OrderBy(x => x.Name).ToList();
                var totalRecord = list.Count;
                if (request.TotalPages > 0)
                    list = list.Skip((request.PageIndex - 1)* request.TotalPages).Take(request.TotalPages).ToList();
                var response =  _mapper.Map<List<GetAllIndustryResponse>>(list);
                return new PaginatedResponse<GetAllIndustryResponse>(response, request.PageIndex, request.TotalPages, totalRecord);

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
