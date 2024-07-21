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

namespace Application.Services.AreaServices.Command.AddQuotationCommand
{
    public class AddQuotationHandler : IRequestHandler<AddQuotationRequest, AddQuotationResponse>
    {
        protected readonly IQuotationRepository _quotationRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public AddQuotationHandler(IQuotationRepository quotationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _quotationRepository = quotationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddQuotationResponse> Handle(AddQuotationRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var quotation = _mapper.Map<Quotation>(request);

                Guid newId = Guid.NewGuid();
                //Validate Area already exist
                var isAlreadyExist = await _quotationRepository.VerifyAlreadyExist(quotation.Code, cancellationToken);
                if (isAlreadyExist)
                    throw new AlreadyExistException(" Company title is already exist.");
                quotation.Id = newId;
                quotation.QuotationItems = request.QuotationItemModels.Select(d => new QuotationItem
                {
                    ProductId = d.ProductId,
                    QuotationId = d.QuotationId,
                    UnitPrice = d.UnitPrice,
                    Quantity = d.Quantity,
                    Discount = d.Discount,
                    LineTotal = d.LineTotal,
                    DiscountSign = d.DiscountSign
                }).ToList();
               
                _quotationRepository.Create(quotation);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new AddQuotationResponse()
                {
                    Id = quotation.Id,
                    Message = "Quotation has been created"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
