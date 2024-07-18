using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.GetAllQuotationQuery;
using Application.Services.Common;
using Application.Services.QuotationServices.Command.GetAllQuotationQuery;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.GetAllQuotationQuery
{
    public class GetAllQuotationHandler : IRequestHandler<GetAllQuotationRequest, PaginatedResponse<GetAllQuotationResponse>>
    {
        protected readonly IQuotationRepository _quotationRepository;
        protected readonly IMapper _mapper;
        public GetAllQuotationHandler(IQuotationRepository quotationRepository, IMapper mapper)
        {
            _quotationRepository = quotationRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<GetAllQuotationResponse>> Handle(GetAllQuotationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Quotation> list;
                if (string.IsNullOrEmpty(request.Search))
                {
                    list = await _quotationRepository.GetAllQuotationWithItem(cancellationToken);
                }
                else
                {
                    list = await _quotationRepository.Search(request.Search, cancellationToken);
                }
                list = list.OrderBy(x => x.Code).ToList();
                var totalRecord = list.Count;
                if(request.TotalPages > 0)
                    list = list.Skip((request.PageIndex - 1) * request.TotalPages).Take(request.TotalPages).ToList();
                var response =  list.Select(x=>new GetAllQuotationResponse()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Date = x.Date,
                    ContactId = x.ContactId,
                    DueDate = x.DueDate,
                    TotalAmount = x.TotalAmount,
                    NetAmount = x.NetAmount,
                    Discount = x.Discount,
                    SaleTax = x.SaleTax,
                    TermAndCondition = x.TermAndCondition,
                    ContactName = x.Contact.CompanyTitle,
                    DueDateStr = x.DueDate?.ToString("d"),
                    DateStr = x.Date?.ToString("d")

                }).ToList();
                return new PaginatedResponse<GetAllQuotationResponse>(response, request.PageIndex, request.TotalPages, totalRecord);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
