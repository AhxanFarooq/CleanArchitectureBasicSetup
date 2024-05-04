using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.AddAreaCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.UpdateAreaCommand
{
    public class UpdateAreaHandler : IRequestHandler<UpdateAreaRequest, UpdateAreaResponse>
    {
        protected readonly IAreaRepository _areaRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public UpdateAreaHandler(IAreaRepository areaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateAreaResponse> Handle(UpdateAreaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var area = await _areaRepository.GetByIdAsync(request.Id, cancellationToken);
                if (area is null)
                    throw new NotFoundException("Record not found");

                //Validate Area already exist
                if(area.Name != request.Name)
                {
                    var isAlreadyExist = await _areaRepository.VerifyAlreadyExist(request.Name, cancellationToken);
                    if (isAlreadyExist)
                        throw new AlreadyExistException(" Area is already exist.");
                }
                area.Name = request.Name;
                area.Description = request.Description;
                area.IsActive =   request.IsActive;

                _areaRepository.Update(area);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new UpdateAreaResponse()
                {
                    Message = "Area has been update"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
