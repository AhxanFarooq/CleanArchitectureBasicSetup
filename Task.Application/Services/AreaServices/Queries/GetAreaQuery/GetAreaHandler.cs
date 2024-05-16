using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.GetAllAreaQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetAreaQuery
{
    public class GetAreaHandler : IRequestHandler<GetAreaRequest, GetAreaResponse>
    {
        protected readonly IAreaRepository _areaRepository;
        protected readonly IMapper _mapper;
        public GetAreaHandler(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }
        public async Task<GetAreaResponse> Handle(GetAreaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _areaRepository.GetByIdAsync(request.Id, cancellationToken);
                return _mapper.Map<GetAreaResponse>(record);
            }
            catch (Exception ex)
            {
                throw new BadRequestException( ex.Message);
            }
        }
    }
}
