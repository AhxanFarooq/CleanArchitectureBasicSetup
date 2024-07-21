using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.UpdateQuotationCommand;
using Application.Services.QuotationServices.Command.UpdateQuotationCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.UpdateQuotationCommand
{
    public class UpdateQuotationHandler : IRequestHandler<UpdateQuotationRequest, UpdateQuotationResponse>
    {
        protected readonly IQuotationRepository _quotationRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public UpdateQuotationHandler(IQuotationRepository quotationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _quotationRepository = quotationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateQuotationResponse> Handle(UpdateQuotationRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var quotation = await _quotationRepository.GetQuotationByIdWithItem(request.Id, cancellationToken);
                if (quotation is null)
                    throw new NotFoundException("Record not found");

                //Validate Quotation already exist
                if (quotation.Code != request.Code)
                {
                    var isAlreadyExist = await _quotationRepository.VerifyAlreadyExist(request.Code, cancellationToken);
                    if (isAlreadyExist)
                        throw new AlreadyExistException(" Quotation is already exist.");
                }
                quotation.Code = request.Code;
                quotation.ContactId = request.ContactId;
                quotation.Date = request.Date;
                quotation.DueDate = request.DueDate;
                quotation.TotalAmount = request.TotalAmount;
                quotation.NetAmount = request.NetAmount;
                quotation.Discount = request.Discount;
                quotation.SaleTax = request.SaleTax;
                quotation.TaxSign = request.TaxSign;
                quotation.OverallDiscSign = request.OverallDiscSign;
                                                    
                // Update existing quotation details
                foreach (var updatedDetailCommand in request.QuotationItemModels)
                {
                    var existingDetail = quotation.QuotationItems.FirstOrDefault(d => d.Id == updatedDetailCommand.Id);
                    if (existingDetail != null)
                    {
                        existingDetail.ProductId = updatedDetailCommand.ProductId;
                        existingDetail.QuotationId = updatedDetailCommand.QuotationId;
                        existingDetail.UnitPrice = updatedDetailCommand.UnitPrice;
                        existingDetail.Quantity = updatedDetailCommand.Quantity;
                        existingDetail.Discount = updatedDetailCommand.Discount;
                        existingDetail.LineTotal = updatedDetailCommand.LineTotal;
                        existingDetail.DiscountSign = updatedDetailCommand.DiscountSign;
                    }
                }

                // Add new quotation details
                var existingDetailIds = quotation.QuotationItems.Select(d => d.Id).ToList();
                foreach (var updatedDetailCommand in request.QuotationItemModels.Where(d => d.Id == Guid.Empty))
                {
                    quotation.QuotationItems.Add(new QuotationItem {
                        ProductId = updatedDetailCommand.ProductId,
                        QuotationId = updatedDetailCommand.QuotationId,
                        UnitPrice = updatedDetailCommand.UnitPrice,
                        Quantity = updatedDetailCommand.Quantity,
                        Discount = updatedDetailCommand.Discount,
                        LineTotal = updatedDetailCommand.LineTotal,
                        DiscountSign = updatedDetailCommand.DiscountSign
                });
                }

                // Optionally, remove quotation details that are missing from the updated details
                var removedDetails = quotation.QuotationItems.Where(d => !request.QuotationItemModels.Any(ud => ud.Id == d.Id)).ToList();
                foreach (var detail in removedDetails)
                {
                    quotation.QuotationItems.Remove(detail);
                }


                _quotationRepository.Update(quotation);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new UpdateQuotationResponse()
                {
                    Message = "Quotation has been update"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
