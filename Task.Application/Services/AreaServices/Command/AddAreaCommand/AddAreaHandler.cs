using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddAreaCommand
{
    public class AddAreaHandler : IRequestHandler<AddAreaRequest, AddAreaResponse>
    {
        protected readonly IAreaRepository _areaRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public AddAreaHandler(IAreaRepository areaRepository, IUnitOfWork unitOfWork, IMapper mapper) {
            _areaRepository = areaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddAreaResponse> Handle(AddAreaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                
                var area = _mapper.Map<Area>(request);

                //Validate Area already exist
                var isAlreadyExist = await _areaRepository.VerifyAlreadyExist(area.Name, cancellationToken);
                if (isAlreadyExist)
                    throw new AlreadyExistException(" Area is already exist.");
                _areaRepository.Create(area);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new AddAreaResponse()
                {
                    Id = area.Id,
                    Message = "Area has been created"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
