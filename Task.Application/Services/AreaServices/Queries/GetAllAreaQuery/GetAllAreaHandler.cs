using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetAllAreaQuery
{
    public class GetAllAreaHandler : IRequestHandler<GetAllAreaRequest, List<GetAllAreaResponse>>
    {
        protected readonly IAreaRepository _areaRepository;
        protected readonly IMapper _mapper;
        public GetAllAreaHandler(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAreaResponse>> Handle(GetAllAreaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _areaRepository.GetAll(cancellationToken);
                return _mapper.Map<List<GetAllAreaResponse>>(list);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
