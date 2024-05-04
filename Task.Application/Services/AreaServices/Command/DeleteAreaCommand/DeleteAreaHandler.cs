using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.AddAreaCommand;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.DeleteAreaCommand
{
    public class DeleteAreaHandler : IRequestHandler<DeleteAreaRequest, DeleteAreaResponse>
    {
        protected readonly IAreaRepository _areaRepository;
        protected readonly IUnitOfWork _unitOfWork;
        public DeleteAreaHandler(IAreaRepository areaRepository, IUnitOfWork unitOfWork) {
            _areaRepository = areaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteAreaResponse> Handle(DeleteAreaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var area = await _areaRepository.GetByIdAsync(request.Id, cancellationToken);
                if (area is null)
                    throw new NotFoundException("Record not found");
                _areaRepository.Delete(area);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new DeleteAreaResponse()
                {
                    Message = "Area has been deleted"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException( ex.Message);
            }
        }
    }
}
