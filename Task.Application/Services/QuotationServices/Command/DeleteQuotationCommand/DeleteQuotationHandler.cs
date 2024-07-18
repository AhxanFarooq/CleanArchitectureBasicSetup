using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.DeleteQuotationCommand;
using MediatR;

namespace Application.Services.QuotationServices.Command.DeleteQuotationCommand
{
    public class DeleteQuotationHandler : IRequestHandler<DeleteQuotationRequest, DeleteQuotationResponse>
    {
        protected readonly IQuotationRepository _quotationRepository;
        protected readonly IUnitOfWork _unitOfWork;
        public DeleteQuotationHandler(IQuotationRepository quotationRepository, IUnitOfWork unitOfWork)
        {
            _quotationRepository = quotationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteQuotationResponse> Handle(DeleteQuotationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var quotation = await _quotationRepository.GetQuotationByIdWithItem(request.Id, cancellationToken);
                if (quotation is null)
                    throw new NotFoundException("Record not found");
                foreach (var detail in quotation.QuotationItems)
                {
                    quotation.QuotationItems.Remove(detail);
                }
               
                _quotationRepository.Delete(quotation);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new DeleteQuotationResponse()
                {
                    Message = "Quotation has been deleted"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
