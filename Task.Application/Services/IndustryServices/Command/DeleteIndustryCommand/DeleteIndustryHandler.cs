using Application.Common.Exceptions;
using Application.Repositories;
using MediatR;

namespace Application.Services.IndustryServices.Command.DeleteIndustryCommand
{
    public class DeleteIndustryHandler : IRequestHandler<DeleteIndustryRequest, DeleteIndustryResponse>
    {
        protected readonly IIndustryRepository _industryRepository;
        protected readonly IUnitOfWork _unitOfWork;
        public DeleteIndustryHandler(IIndustryRepository industryRepository, IUnitOfWork unitOfWork)
        {
            _industryRepository = industryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteIndustryResponse> Handle(DeleteIndustryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var industry = await _industryRepository.GetByIdAsync(request.Id, cancellationToken);
                if (industry is null)
                    throw new NotFoundException("Record not found");
                _industryRepository.Delete(industry);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new DeleteIndustryResponse()
                {
                    Message = "Industry has been deleted"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
