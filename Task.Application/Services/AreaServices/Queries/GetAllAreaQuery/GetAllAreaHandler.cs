using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.Common;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetAllAreaQuery
{
    public class GetAllAreaHandler : IRequestHandler<GetAllAreaRequest, PaginatedResponse<GetAllAreaResponse>>
    {
        protected readonly IAreaRepository _areaRepository;
        protected readonly IMapper _mapper;
        public GetAllAreaHandler(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<GetAllAreaResponse>> Handle(GetAllAreaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Area> list;
                if (string.IsNullOrEmpty(request.Search))
                {
                    list = await _areaRepository.GetAll(cancellationToken);
                }
                else
                {
                    list = await _areaRepository.SearchByArea(request.Search,cancellationToken);
                }
                list = list.OrderBy(x => x.Name).ToList();
                var totalRecord = list.Count;
                if (request.TotalSize > 0)
                    list = list.Skip((request.PageIndex -1 ) * request.TotalSize).Take(request.TotalSize).ToList();

                var response =  _mapper.Map<List<GetAllAreaResponse>>(list);
                return new PaginatedResponse<GetAllAreaResponse>(response, request.PageIndex, request.TotalSize, totalRecord);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
